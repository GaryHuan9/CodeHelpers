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

		protected bool Equals(SerializableMethod other) => declaringPath == other?.declaringPath && namePath == other?.namePath;
		public override bool Equals(object obj) => obj is SerializableMethod other && Equals(other);

		public override int GetHashCode()
		{
			unchecked
			{
				return ((declaringPath?.GetHashCode() ?? 0) * 397) ^ (namePath?.GetHashCode() ?? 0);
			}
		}

		public static bool operator ==(SerializableMethod method, object other) => method?.Equals(other) ?? other is null;
		public static bool operator !=(SerializableMethod method, object other) => !(method == other);
	}

	[Serializable]
	public class SerializableType : IEquatable<SerializableType>
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

		public bool Equals(SerializableType other) => fullPath == other?.fullPath;
		public override bool Equals(object obj) => obj is SerializableMethod other && Equals(other);

		public override int GetHashCode() => fullPath?.GetHashCode() ?? 0;

		public static bool operator ==(SerializableType type, object other) => type?.Equals(other) ?? other is null;
		public static bool operator !=(SerializableType type, object other) => !(type == other);
	}
}