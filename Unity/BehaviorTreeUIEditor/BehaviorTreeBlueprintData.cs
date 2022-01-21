#if CODE_HELPERS_UNITY

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using CodeHelpers.AI.BehaviorTrees;
using CodeHelpers.Collections;
using CodeHelpers.Diagnostics;
using UnityEngine;

namespace CodeHelpers.Unity.BehaviorTreeUIEditor
{
	[CreateAssetMenu(fileName = "Behavior Tree Blueprint", menuName = "CodeHelpers/Behavior Trees/Blueprint")]
	public class BehaviorTreeBlueprintData : ScriptableObject
	{
		public ActionImportData importData;
		public SerializableMethod targetContextTypeMethod; //The serializable method used to store our target context

		public List<TreeNodeData> allNodes;
		public int mainRootNode;
		public int[] rootNodes;

		public BehaviorTreeBlueprint<T> GetBlueprint<T>()
		{
			if (importData == null || targetContextTypeMethod == null) throw new Exception("Data not ready for blueprint!");
			if (allNodes == null || allNodes.Count == 0) throw new Exception("No serialized graph node!");
			if (!targetContextTypeMethod.TargetContextType.IsAssignableFrom(typeof(T))) throw new Exception($"Unmatched requested type {typeof(T)} with {targetContextTypeMethod.TargetContextType}!");

			var blueprint = new BehaviorTreeBlueprint<T>();

			LoadBranch(blueprint.RootLocation, blueprint, mainRootNode);
			blueprint.Seal();

			return blueprint;
		}

		void LoadBranch<T>(Location<T> parent, BehaviorTreeBlueprint<T> blueprint, int index)
		{
			TreeNodeData data = allNodes[index];

			for (int i = 0; i < data.children.Length; i++)
			{
				int childIndex = data.children[i];
				var location = LoadNode(parent, blueprint, childIndex);

				LoadBranch(location, blueprint, childIndex);
			}
		}

		Location<T> LoadNode<T>(Location<T> parent, BehaviorTreeBlueprint<T> blueprint, int index)
		{
			TreeNodeData data = allNodes[index];
			Type type = BehaviorTreeNodeAttribute.SerializedNameToType.TryGetValue(data.nodeTypeSerializableName);

			if (type == null) throw new Exception($"Unexpected serialized node type name {data.nodeTypeSerializableName}.");
			if (type.ContainsGenericParameters) type = type.MakeGenericType(typeof(T));

			INodeType node;

			//Prepare node and parameters
			if (data.parameters == null || data.parameters.Length == 0)
			{
				node = (INodeType)Activator.CreateInstance(type);
			}
			else
			{
				object[] parameters = new object[data.parameters.Length];

				for (int i = 0; i < data.parameters.Length; i++)
				{
					SerializableParameter parameter = data.parameters[i];

					if (parameter.Type == ParameterType.behaviorAction)
					{
						parameter.LoadBehaviorAction(importData);
						parameters[i] = GetAction<T>(parameter);
					}
					else parameters[i] = parameter.GetValue();
				}

				node = (INodeType)Activator.CreateInstance(type, parameters);
			}

			//Add to blueprint
			Location<T> location = blueprint.Add(parent, node, out bool success);
			if (!success) throw new Exception($"Invalid node create from graph at GUID: {data.GUID}, position: {data.position}, serialized node name: {data.nodeTypeSerializableName}!");

			return location;
		}

		static BehaviorAction<T> GetAction<T>(SerializableParameter sourceParameter)
		{
			MethodInfo methodInfo = sourceParameter.BehaviorActionValue.method.Method;
			ParameterInfo[] methodParameters = methodInfo.GetParameters();
			var parameterAccessor = sourceParameter.BehaviorActionParameters;

			Type returnType = typeof(Result);
			Assert.IsTrue(methodInfo.ReturnType == returnType);

			//If has no extra parameter than the context, we can just simply create and return the delegate
			if (methodParameters.Length == 1) return (BehaviorAction<T>)methodInfo.CreateDelegate(typeof(BehaviorAction<T>));

			var parameters = new Expression[methodParameters.Length];
			ParameterExpression contextParameter = Expression.Parameter(typeof(T));

			//Assemble constant parameters
			for (int i = 0; i < parameters.Length - 1; i++) parameters[i + 1] = Expression.Constant(parameterAccessor[i].GetValue());
			parameters[0] = contextParameter;

			var callExpression = Expression.Call(null, methodInfo, parameters);                            //Call expression with constant parameters
			var lambdaExpression = Expression.Lambda<BehaviorAction<T>>(callExpression, contextParameter); //Precompiled delegate

			return lambdaExpression.Compile();
		}
	}

	[Serializable]
	public class TreeNodeData
	{
		public Vector2 position;
		public int GUID; //This is also the index in the node list
		public string nodeTypeSerializableName;

		public int[] children; //NOTE: These children indices are stored respecting to their priorities.
		public SerializableParameter[] parameters;
	}
}

#endif