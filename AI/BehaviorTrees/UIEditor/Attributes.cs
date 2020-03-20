using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace CodeHelpers.AI.BehaviorTrees
{
	[AttributeUsage(AttributeTargets.Method)]
	public class BehaviorActionAttribute : Attribute
	{
		public const BindingFlags MethodBindings = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
	}

	[AttributeUsage(AttributeTargets.Struct)]
	public class BehaviorTreeNodeAttribute : Attribute
	{
		/// <param name="serializedName">The string used to serialize this node in files. Do not change this name</param>
		/// <param name="nodeTypeName">The name of the type in editor code that should represent this node. This name must be exact and contains namespace.</param>
		/// <param name="displayedName">The name of this node that is shown to the user. Can be changed.</param>
		public BehaviorTreeNodeAttribute(string serializedName, string nodeTypeName, string displayedName)
		{
			this.serializedName = serializedName;
			this.nodeTypeName = nodeTypeName;
			this.displayedName = displayedName;
		}

		static BehaviorTreeNodeAttribute()
		{
			serializedNameToAttributeInternal = new Dictionary<string, BehaviorTreeNodeAttribute>();
			serializedNameToAttribute = new ReadOnlyDictionary<string, BehaviorTreeNodeAttribute>(serializedNameToAttributeInternal);

			RescanAttributes();
		}


		public readonly string serializedName;
		public readonly string nodeTypeName;
		public readonly string displayedName;

		static readonly Dictionary<string, BehaviorTreeNodeAttribute> serializedNameToAttributeInternal;
		public readonly static ReadOnlyDictionary<string, BehaviorTreeNodeAttribute> serializedNameToAttribute;

		public static void RescanAttributes()
		{
			var collection = serializedNameToAttributeInternal;
			collection.Clear();

			foreach (BehaviorTreeNodeAttribute attribute in from assembly in AppDomain.CurrentDomain.GetAssemblies()
															from type in assembly.GetTypes()
															where type.IsValueType
															select type.GetCustomAttribute<BehaviorTreeNodeAttribute>())
			{
				if (attribute != null) collection.Add(attribute.serializedName, attribute);
			}
		}
	}
}