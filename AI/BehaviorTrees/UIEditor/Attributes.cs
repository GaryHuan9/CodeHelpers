using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using CodeHelpers.DebugHelpers;
using UnityEditor;

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

		public readonly string serializedName;
		public readonly string nodeTypeName;
		public readonly string displayedName;

		static readonly Dictionary<string, BehaviorTreeNodeAttribute> serializedNameToAttribute = new Dictionary<string, BehaviorTreeNodeAttribute>();
		static readonly Dictionary<string, Type> serializedNameToType = new Dictionary<string, Type>();

		public static IReadOnlyDictionary<string, BehaviorTreeNodeAttribute> SerializedNameToAttribute => scannedAttributes ? serializedNameToAttribute : throw GetNotScanned();
		public static IReadOnlyDictionary<string, Type> SerializedNameToType => scannedAttributes ? serializedNameToType : throw GetNotScanned();

		static bool scannedAttributes;

		public static void RescanAttributes()
		{
			serializedNameToAttribute.Clear();
			serializedNameToType.Clear();

			var stopwatch = Stopwatch.StartNew();

			foreach ((BehaviorTreeNodeAttribute attribute, Type type) in from assembly in AppDomain.CurrentDomain.GetAssemblies()
																		 from type in assembly.GetTypes()
																		 where type.IsValueType && IsDefined(type, typeof(BehaviorTreeNodeAttribute))
																		 select (type.GetCustomAttribute<BehaviorTreeNodeAttribute>(), type))
			{
				serializedNameToAttribute.Add(attribute.serializedName, attribute);
				serializedNameToType.Add(attribute.serializedName, type);
			}

			stopwatch.Stop();
			DebugHelper.Log($"Rescanned Behavior Tree Node attributes in {stopwatch.Elapsed.TotalMilliseconds} ms");

			scannedAttributes = true;
		}

		static Exception GetNotScanned() => new Exception($"You have not scanned for attributes before! Scan them using the {nameof(RescanAttributes)} method!");
	}
}