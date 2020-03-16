using System;
using System.Reflection;
using UnityEngine;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	[Serializable]
	public class SerializableMethod
	{
		public SerializableMethod(MethodInfo info)
		{
			declaringPath = info.DeclaringType.FullName;
			namePath = info.Name;
		}

		public SerializableMethod(string declaringPath, string namePath)
		{
			this.declaringPath = declaringPath;
			this.namePath = namePath;
		}

		[SerializeField] string declaringPath;
		[SerializeField] string namePath;

		MethodInfo _method;
		SerializableType _type;

		public MethodInfo Method => _method ?? (_method = System.Type.GetType(declaringPath)?.GetMethod(namePath));
		public SerializableType Type => _type ?? (_type = new SerializableType(declaringPath));

		public float CompareToKeyword(string keyword) => Mathf.RoundToInt(StringHelper.CalculateSimilarity(keyword, namePath) * 100000f);

		public override string ToString() => $"{declaringPath}: {namePath}";

		public static bool operator ==(SerializableMethod method, object other) => other == null ? string.IsNullOrEmpty(method?.declaringPath) || string.IsNullOrEmpty(method?.namePath) : ReferenceEquals(method, other);
		public static bool operator !=(SerializableMethod method, object other) => !(method == other);
	}

	[Serializable]
	public class SerializableType
	{
		public SerializableType(Type type)
		{
			fullPath = type.FullName;
			_type = type;
		}

		public SerializableType(string fullPath) => this.fullPath = fullPath;

		[SerializeField] string fullPath;

		Type _type;
		public Type Type => _type ?? (_type = Type.GetType(fullPath));

		public override string ToString() => fullPath;

		public static bool operator ==(SerializableType type, object other) => other == null ? string.IsNullOrEmpty(type?.fullPath) : ReferenceEquals(type, other);
		public static bool operator !=(SerializableType type, object other) => !(type == other);
	}
}