using System;
using System.Collections.Generic;
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
		public BehaviorTreeNodeAttribute(string serializedName, string nodeTypeName)
		{
			this.serializedName = serializedName;
			this.nodeTypeName = nodeTypeName;
		}

		public readonly string serializedName;
		public readonly string nodeTypeName;

		static readonly Dictionary<string, BehaviorTreeNodeAttribute> serializedNameToAttribute = new Dictionary<string, BehaviorTreeNodeAttribute>();
		static readonly Dictionary<string, Type> serializedNameToType = new Dictionary<string, Type>();

		public static IReadOnlyDictionary<string, BehaviorTreeNodeAttribute> SerializedNameToAttribute => scannedAttributes ? serializedNameToAttribute : throw GetNotScanned();
		public static IReadOnlyDictionary<string, Type> SerializedNameToType => scannedAttributes ? serializedNameToType : throw GetNotScanned();

		static bool scannedAttributes;

		public static void RescanAttributes()
		{
			serializedNameToAttribute.Clear();
			serializedNameToType.Clear();

			foreach ((BehaviorTreeNodeAttribute attribute, Type type) in from assembly in AppDomain.CurrentDomain.GetAssemblies()
																		 from type in assembly.GetTypes()
																		 where type.IsValueType && IsDefined(type, typeof(BehaviorTreeNodeAttribute))
																		 select (type.GetCustomAttribute<BehaviorTreeNodeAttribute>(), type))
			{
				serializedNameToAttribute.Add(attribute.serializedName, attribute);
				serializedNameToType.Add(attribute.serializedName, type);
			}

			scannedAttributes = true;
		}

		static Exception GetNotScanned() => new Exception($"You have not scanned for attributes before! Scan them using the {nameof(RescanAttributes)} method!");
	}
}