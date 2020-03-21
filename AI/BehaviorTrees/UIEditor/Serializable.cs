using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using CodeHelpers.DebugHelpers;
using UnityEngine;
using UnityEngine.Assertions;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	[Serializable]
	public class SerializableMethod : IEquatable<SerializableMethod>
	{
		public SerializableMethod(MethodInfo info)
		{
			Assert.IsNotNull(info);

			declaringPath = info.DeclaringType.AssemblyQualifiedName;
			namePath = info.Name;
		}

		[SerializeField] string declaringPath;
		[SerializeField] string namePath;

		MethodInfo _method;
		Type _targetContextType;

		public MethodInfo Method
		{
			get
			{
				if (_method != null) return _method;
				if (string.IsNullOrEmpty(declaringPath) || string.IsNullOrEmpty(namePath)) return null;

				return _method = Type.GetType(declaringPath)?.GetMethod(namePath, BehaviorActionAttribute.MethodBindings);
			}
		}

		public Type TargetContextType
		{
			get
			{
				if (_targetContextType != null) return _targetContextType;
				if (Method == null) return null;

				return _targetContextType = Method.GetParameters()[0].ParameterType;
			}
		}

		public float CompareToKeyword(string keyword) => StringHelper.CalculateSimilarity(keyword, namePath);

		public override string ToString()
		{
			if (Equals(null)) return "";
			if (Method == null) return "Missing method";

			return $"{Method.DeclaringType?.FullName}: {namePath}";
		}

		public bool Equals(SerializableMethod other) => other is null ? string.IsNullOrEmpty(declaringPath) && string.IsNullOrEmpty(namePath) : declaringPath == other.declaringPath && namePath == other.namePath;
		public override bool Equals(object obj) => obj is null ? Equals(null) : obj is SerializableMethod other && Equals(other);

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
	public class SerializableParameter
	{
		public SerializableParameter(BehaviorAction behaviorAction)
		{
			type = ParameterType.behaviorAction;
			BehaviorActionValue = behaviorAction;
		}

		public SerializableParameter(bool booleanValue)
		{
			type = ParameterType.boolean;
			BooleanValue = booleanValue;
		}

		public SerializableParameter(int integer1Value)
		{
			type = ParameterType.integer1;
			Integer1Value = integer1Value;
		}

		public SerializableParameter(Vector2Int integer2Value)
		{
			type = ParameterType.integer2;
			Integer2Value = integer2Value;
		}

		public SerializableParameter(Vector3Int integer3Value)
		{
			type = ParameterType.integer3;
			Integer3Value = integer3Value;
		}

		public SerializableParameter(float float1Value)
		{
			type = ParameterType.float1;
			Float1Value = float1Value;
		}

		public SerializableParameter(Vector2 float2Value)
		{
			type = ParameterType.float2;
			Float2Value = float2Value;
		}

		public SerializableParameter(Vector3 float3Value)
		{
			type = ParameterType.float3;
			Float3Value = float3Value;
		}

		[SerializeField] ParameterType type;
		public ParameterType Type => type;

		[SerializeField] BehaviorAction behaviorAction;

		[SerializeField] int scaler1;
		[SerializeField] int scaler2;
		[SerializeField] int scaler3;

		public BehaviorAction BehaviorActionValue
		{
			get => CheckReturn(behaviorAction);
			set
			{
				CheckReturn(value);
				if (behaviorAction == value) return;

				behaviorAction = value;
				OnValueChangedMethods?.Invoke();
			}
		}

		public bool BooleanValue
		{
			get => CheckReturn(scaler1 == 1);
			set
			{
				CheckReturn(value);
				if (BooleanValue == value) return;

				scaler1 = value ? 1 : 0;
				OnValueChangedMethods?.Invoke();
			}
		}

		public int Integer1Value
		{
			get => CheckReturn(scaler1);
			set
			{
				CheckReturn(value);
				if (Integer1Value == value) return;

				scaler1 = value;
				OnValueChangedMethods?.Invoke();
			}
		}

		public Vector2Int Integer2Value
		{
			get => CheckReturn(new Vector2Int(scaler1, scaler2));
			set
			{
				CheckReturn(value);
				if (Integer2Value == value) return;

				scaler1 = value.x;
				scaler2 = value.y;

				OnValueChangedMethods?.Invoke();
			}
		}

		public Vector3Int Integer3Value
		{
			get => CheckReturn(new Vector3Int(scaler1, scaler2, scaler3));
			set
			{
				CheckReturn(value);
				if (Integer3Value == value) return;

				scaler1 = value.x;
				scaler2 = value.y;
				scaler3 = value.z;

				OnValueChangedMethods?.Invoke();
			}
		}

		public float Float1Value
		{
			get => CheckReturn(BitwiseConvert(scaler1));
			set
			{
				CheckReturn(value);
				if (Mathf.Approximately(Float1Value, value)) return;

				scaler1 = BitwiseConvert(value);
				OnValueChangedMethods?.Invoke();
			}
		}

		public Vector2 Float2Value
		{
			get => CheckReturn(new Vector2(BitwiseConvert(scaler1), BitwiseConvert(scaler2)));
			set
			{
				CheckReturn(value);
				if (Float2Value == value) return;

				scaler1 = BitwiseConvert(value.x);
				scaler2 = BitwiseConvert(value.y);

				OnValueChangedMethods?.Invoke();
			}
		}

		public Vector3 Float3Value
		{
			get => CheckReturn(new Vector3(BitwiseConvert(scaler1), BitwiseConvert(scaler2), BitwiseConvert(scaler3)));
			set
			{
				CheckReturn(value);
				if (Float3Value == value) return;

				scaler1 = BitwiseConvert(value.x);
				scaler2 = BitwiseConvert(value.y);
				scaler3 = BitwiseConvert(value.z);

				OnValueChangedMethods?.Invoke();
			}
		}

		public event Action OnValueChangedMethods;

		public void CopyFrom(SerializableParameter parameter)
		{
			if (parameter.Type != Type) throw ExceptionHelper.Invalid(nameof(parameter), parameter, "has a mismatched parameter type!");

			behaviorAction = parameter.behaviorAction;
			scaler1 = parameter.scaler1;
			scaler2 = parameter.scaler2;
			scaler3 = parameter.scaler3;
		}

		T CheckReturn<T>(T value)
		{
			if (typeof(T) == Type.GetParameterType()) return value;
			throw new Exception($"This {nameof(SerializableParameter)} has the type {Type} but you are trying to yse its value as an {typeof(T)}!");
		}

		static float BitwiseConvert(int value) => CodeHelper.Int32BitsToSingle(value);
		static int BitwiseConvert(float value) => CodeHelper.SingleToInt32Bits(value);

		public static implicit operator BehaviorAction(SerializableParameter parameter) => parameter.BehaviorActionValue;
		public static implicit operator bool(SerializableParameter parameter) => parameter.BooleanValue;

		public static implicit operator int(SerializableParameter parameter) => parameter.Integer1Value;
		public static implicit operator Vector2Int(SerializableParameter parameter) => parameter.Integer2Value;
		public static implicit operator Vector3Int(SerializableParameter parameter) => parameter.Integer3Value;

		public static implicit operator float(SerializableParameter parameter) => parameter.Float1Value;
		public static implicit operator Vector2(SerializableParameter parameter) => parameter.Float2Value;
		public static implicit operator Vector3(SerializableParameter parameter) => parameter.Float3Value;
	}

	public static class ParameterTypeExtensions
	{
		public static Type GetParameterType(this ParameterType type)
		{
			switch (type)
			{
				case ParameterType.behaviorAction: return typeof(BehaviorAction);
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

	public enum ParameterType : byte
	{
		behaviorAction,
		boolean,
		integer1,
		integer2,
		integer3,
		float1,
		float2,
		float3
	}
}