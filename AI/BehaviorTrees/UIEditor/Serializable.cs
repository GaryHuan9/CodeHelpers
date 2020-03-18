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

		public float CompareToKeyword(string keyword) => StringHelper.CalculateSimilarity(keyword, namePath);

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

	[Serializable]
	public class SerializedParameter
	{
		public SerializedParameter(object behaviorAction) => throw new NotImplementedException();

		public SerializedParameter(bool booleanValue)
		{
			scaler1 = booleanValue ? 1 : 0;
			type = ParameterType.boolean;
		}

		public SerializedParameter(int integer1Value)
		{
			scaler1 = integer1Value;
			type = ParameterType.integer1;
		}

		public SerializedParameter(Vector2Int integer2Value)
		{
			scaler1 = integer2Value.x;
			scaler2 = integer2Value.y;
			type = ParameterType.integer2;
		}

		public SerializedParameter(Vector3Int integer3Value)
		{
			scaler1 = integer3Value.x;
			scaler2 = integer3Value.y;
			scaler3 = integer3Value.z;
			type = ParameterType.integer3;
		}

		public SerializedParameter(float float1Value)
		{
			scaler1 = BitwiseConvert(float1Value);
			type = ParameterType.float1;
		}

		public SerializedParameter(Vector2 float2Value)
		{
			scaler1 = BitwiseConvert(float2Value.x);
			scaler2 = BitwiseConvert(float2Value.y);
			type = ParameterType.float2;
		}

		public SerializedParameter(Vector3 float3Value)
		{
			scaler1 = BitwiseConvert(float3Value.x);
			scaler2 = BitwiseConvert(float3Value.y);
			scaler3 = BitwiseConvert(float3Value.z);
			type = ParameterType.float3;
		}

		[SerializeField] ParameterType type;
		public ParameterType Type => type;

		[SerializeField] int scaler1;
		[SerializeField] int scaler2;
		[SerializeField] int scaler3;

		[SerializeField] object behaviorAction;

		public bool BooleanValue => CheckReturn(scaler1 == 1);

		public int Integer1Value => CheckReturn(scaler1);
		public Vector2Int Integer2Value => CheckReturn(new Vector2Int(scaler1, scaler2));
		public Vector3Int Integer3Value => CheckReturn(new Vector3Int(scaler1, scaler2, scaler3));

		public float Float1Value => CheckReturn(BitwiseConvert(scaler1));
		public Vector2 Float2Value => CheckReturn(new Vector2(BitwiseConvert(scaler1), BitwiseConvert(scaler2)));
		public Vector3 Float3Value => CheckReturn(new Vector3(BitwiseConvert(scaler1), BitwiseConvert(scaler2), BitwiseConvert(scaler3)));

		T CheckReturn<T>(T value)
		{
			if (typeof(T) == Type.GetType()) return value;
			throw new Exception($"This {nameof(SerializedParameter)} has the type {Type} but you are trying to get its value as an {typeof(T)}!");
		}

		static float BitwiseConvert(int value) => CodeHelper.Int32BitsToSingle(value);
		static int BitwiseConvert(float value) => CodeHelper.SingleToInt32Bits(value);
	}

	public static class ParameterTypeExtensions
	{
		public static Type GetParameterType(this ParameterType type)
		{
			switch (type)
			{
				case ParameterType.behaviorAciton: throw new NotImplementedException();
				case ParameterType.boolean:        return typeof(bool);
				case ParameterType.integer1:       return typeof(int);
				case ParameterType.integer2:       return typeof(Vector2Int);
				case ParameterType.integer3:       return typeof(Vector3Int);
				case ParameterType.float1:         return typeof(float);
				case ParameterType.float2:         return typeof(Vector2);
				case ParameterType.float3:         return typeof(Vector3);
			}

			throw ExceptionHelper.Invalid(nameof(type), type, InvalidType.unexpected);
		}
	}

	public enum ParameterType
	{
		behaviorAciton,
		boolean,
		integer1,
		integer2,
		integer3,
		float1,
		float2,
		float3
	}
}