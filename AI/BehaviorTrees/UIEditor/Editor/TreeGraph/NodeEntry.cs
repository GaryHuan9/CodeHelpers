using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	public class NodeEntry : NodeInfo
	{
		public NodeEntry(BehaviorTreeNodeAttribute attribute) : base(attribute) => this.attribute = attribute;

		public readonly BehaviorTreeNodeAttribute attribute;
	}

	public class NodeInfo : IEquatable<NodeInfo>
	{
		public NodeInfo(string serializedName, string displayedName, Type graphNodeType)
		{
			this.serializedName = serializedName;
			this.displayedName = displayedName;
			this.graphNodeType = graphNodeType;
		}

		public NodeInfo(BehaviorTreeNodeAttribute attribute)
		{
			serializedName = attribute.serializedName;
			displayedName = attribute.displayedName;
			graphNodeType = GetTypeFromName(attribute.nodeTypeName);
		}

		public readonly string serializedName;
		public readonly string displayedName;
		public readonly Type graphNodeType;

		public static readonly NodeInfo rootInfo = new NodeInfo("Internal_Root", "Root", typeof(RootNode));

		public bool Equals(NodeInfo other) => serializedName == other?.serializedName;
		public override bool Equals(object obj) => obj is NodeInfo other && Equals(other);

		public static bool operator ==(NodeInfo type, object other) => type?.Equals(other) ?? other is null;
		public static bool operator !=(NodeInfo type, object other) => !(type == other);

		public override int GetHashCode() => serializedName?.GetHashCode() ?? 0;

		static Type GetTypeFromName(string nodeTypeName)
		{
			if (string.IsNullOrEmpty(nodeTypeName)) throw ExceptionHelper.Invalid(nameof(nodeTypeName), nodeTypeName, InvalidType.isNull);
			return Type.GetType(nodeTypeName) ?? throw new Exception($"Invalid name \"{nodeTypeName}\" for a {nameof(TreeGraphNode)}!");
		}
	}
}