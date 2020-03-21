using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
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

			BehaviorTreeNodeAttribute.RescanAttributes();
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
			Type type = BehaviorTreeNodeAttribute.serializedNameToType.TryGetValue(data.nodeTypeSerializableName);

			if (type == null) throw new Exception($"Unexpected serialized node type name {data.nodeTypeSerializableName}.");

			Location<T> location = blueprint.Add(parent, (INodeType)Activator.CreateInstance(type, data.parameters), out bool success);
			if (!success) throw new Exception($"Invalid node create from graph at GUID: {data.GUID}, position: {data.position}, serialized node name: {data.nodeTypeSerializableName}!");

			return location;
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