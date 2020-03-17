using System;
using UnityEditor.Experimental.GraphView;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	public class TreeGraphNode : Node
	{
		public TreeGraphNode(bool entryPoint = false)
		{
			GUID = Guid.NewGuid().ToString();
			this.entryPoint = entryPoint;
		}

		public readonly string GUID;
		public readonly bool entryPoint;
	}

	public class FunctionalNode : TreeGraphNode
	{

	}

	public class LeafNode : TreeGraphNode
	{

	}
}