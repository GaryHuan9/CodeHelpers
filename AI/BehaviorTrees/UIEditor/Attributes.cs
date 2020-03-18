using System;

namespace CodeHelpers.AI.BehaviorTrees
{
	[AttributeUsage(AttributeTargets.Method)]
	public class BehaviorActionAttribute : Attribute { }

	[AttributeUsage(AttributeTargets.Struct)]
	public class BehaviorTreeNodeAttribute : Attribute
	{
		public BehaviorTreeNodeAttribute(string serializedName = null, int maxChildCount = int.MaxValue, string displayedName = null)
		{
			this.serializedName = serializedName;
			this.displayedName = displayedName;

			this.maxChildCount = maxChildCount;
		}

		public readonly string serializedName;
		public readonly string displayedName;

		public readonly int maxChildCount;
	}

	[AttributeUsage(AttributeTargets.Constructor)]
	public class BehaviorNodeConstructorAttribute : Attribute { }
}