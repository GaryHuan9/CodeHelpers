using System;
using System.Reflection;
using System.Reflection.Emit;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	public class TreeGraphNode : Node
	{
		public TreeGraphNode(NodeInfo info)
		{
			GUID = Guid.NewGuid().ToString();
			this.info = info;

			Initialize();
		}

		void Initialize() //IDK why would we need a separate method but yeah (actually it's because the warning when you call virtual method in construtor)
		{
			title = info.displayedName;

			//Generate parent port
			if (info.hasParent)
			{
				var port = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(int));
				port.portName = "Parent";
				inputContainer.Add(port);
			}

			//Generate child port
			if (info.maxChildCount > 0)
			{
				var port = InstantiatePort(Orientation.Horizontal, Direction.Output, info.maxChildCount == 1 ? Port.Capacity.Single : Port.Capacity.Multi, typeof(int));
				port.portName = "Child";
				outputContainer.Add(port);
			}

			//Generate parameter ports
			for (int i = 0; i < info.parameters.Count; i++)
			{
				var parameter = info.parameters[i];
				var control = new FloatField {label = parameter.Name, [0] = {style = {minWidth = 0f}}}; //To remove ugly gap

				inputContainer.Add(control);
			}
		}

		public readonly string GUID;
		public readonly NodeInfo info;

		// static BaseField GetParameterControl(ParameterInfo parameter)
		// {
		// 	VisualElement control = null;
		// 	var type = parameter.ParameterType;
		//
		// 	if (type == typeof(int))
		// 	{
		// 		control = new IntegerField(){value = };
		// 	}
		// }
	}

	/// <summary>
	/// Regular nodes
	/// </summary>
	public class FunctionalNode : TreeGraphNode
	{
		public FunctionalNode(NodeInfo info) : base(info) { }
	}

	/// <summary>
	/// Action nodes
	/// </summary>
	public class LeafNode : TreeGraphNode
	{
		public LeafNode(NodeInfo info) : base(info) { }
	}
}