using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	public class NodeEntry : NodeInfo
	{
		public NodeEntry(Type nodeType, BehaviorTreeNodeAttribute attribute)
			: base(
				attribute.serializedName, string.IsNullOrEmpty(attribute.displayedName) ? nodeType.Name : attribute.displayedName,
				attribute.maxChildCount, GetAttributedConstructorParameters(nodeType)
			)
		{
			this.nodeType = nodeType;
			this.attribute = attribute;
		}

		public readonly Type nodeType;
		public readonly BehaviorTreeNodeAttribute attribute;

		static ParameterInfo[] GetAttributedConstructorParameters(Type type)
		{
			var attributedConstructor = type.GetConstructors().FirstOrDefault(constructor => constructor.GetCustomAttribute<BehaviorNodeConstructorAttribute>() != null);
			return (attributedConstructor ?? type.GetConstructor(Type.EmptyTypes))?.GetParameters();
		}
	}

	public class NodeInfo : IEquatable<NodeInfo>
	{
		public NodeInfo(string serializedName, string displayedName, int maxChildCount, ParameterInfo[] parameters = null, bool hasParent = true)
		{
			this.serializedName = serializedName;
			this.displayedName = displayedName;

			this.maxChildCount = maxChildCount;
			this.parameters = new ReadOnlyCollection<ParameterInfo>(parameters ?? Array.Empty<ParameterInfo>());
			this.hasParent = hasParent;
		}

		public readonly string serializedName;
		public readonly string displayedName;

		public readonly int maxChildCount;
		public readonly ReadOnlyCollection<ParameterInfo> parameters;
		public readonly bool hasParent;

		public bool Equals(NodeInfo other) => serializedName == other?.serializedName;
		public override bool Equals(object obj) => obj is NodeInfo other && Equals(other);

		public static bool operator ==(NodeInfo type, object other) => type?.Equals(other) ?? other is null;
		public static bool operator !=(NodeInfo type, object other) => !(type == other);

		public override int GetHashCode() => serializedName?.GetHashCode() ?? 0;
	}
}