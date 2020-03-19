using System;
using System.Reflection;

namespace CodeHelpers.AI.BehaviorTrees
{
	[AttributeUsage(AttributeTargets.Method)]
	public class BehaviorActionAttribute : Attribute
	{
		public readonly static BindingFlags methodBindings = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
	}

	[AttributeUsage(AttributeTargets.Struct)]
	public class BehaviorTreeNodeAttribute : Attribute
	{
		/// <param name="serializedName">The string used to serialize this node in files. Do not change this name</param>
		/// <param name="nodeTypeName">The name of the type in editor code that should represent this node. This name must be exact and contains namespace.</param>
		/// <param name="displayedName">The name of this node that is shown to the user. Can be changed.</param>
		public BehaviorTreeNodeAttribute(string serializedName, string nodeTypeName, string displayedName = null)
		{
			this.serializedName = serializedName;
			this.nodeTypeName = nodeTypeName;
			this.displayedName = displayedName;
		}

		public readonly string serializedName;
		public readonly string nodeTypeName;
		public readonly string displayedName;
	}
}