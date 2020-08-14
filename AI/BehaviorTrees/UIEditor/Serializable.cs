using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using CodeHelpers.DebugHelpers;
using CodeHelpers.VectorHelpers;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;

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
		IReadOnlyList<BehaviorActionParameterInfo> _parameters;

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

		public IReadOnlyList<BehaviorActionParameterInfo> Parameters
		{
			get
			{
				if (_parameters != null) return _parameters;
				if (Method == null) return null;

				Type contextType = TargetContextType;

				return _parameters = new ReadOnlyCollection<BehaviorActionParameterInfo>
					   (
						   (from parameter in Method.GetParameters()
							let type = parameter.ParameterType
							where type.HasParameterType() && type != contextType
							select new BehaviorActionParameterInfo(parameter.Name, type.GetParameterType())).ToArray()
					   );
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

	public readonly struct BehaviorActionParameterInfo
	{
		public BehaviorActionParameterInfo(string name, ParameterType type)
		{
			Assert.IsFalse(type == ParameterType.behaviorAction);

			this.name = name;
			this.type = type;
		}

		public readonly string name;
		public readonly ParameterType type;
	}

	[Serializable]
	public class SingularSerializableParameter
	{
		public SingularSerializableParameter(ParameterType type) => this.type = type;

		public SingularSerializableParameter(SingularSerializableParameter source)
		{
			type = source.Type;
			CopyFrom(source);
		}

		public SingularSerializableParameter(BehaviorAction behaviorAction)
		{
			type = ParameterType.behaviorAction;
			BehaviorActionValue = behaviorAction;
		}

		public SingularSerializableParameter(bool booleanValue)
		{
			type = ParameterType.boolean;
			BooleanValue = booleanValue;
		}

		public SingularSerializableParameter(int integer1Value)
		{
			type = ParameterType.integer1;
			Integer1Value = integer1Value;
		}

		public SingularSerializableParameter(Vector2Int integer2Value)
		{
			type = ParameterType.integer2;
			Integer2Value = integer2Value;
		}

		public SingularSerializableParameter(Vector3Int integer3Value)
		{
			type = ParameterType.integer3;
			Integer3Value = integer3Value;
		}

		public SingularSerializableParameter(float float1Value)
		{
			type = ParameterType.float1;
			Float1Value = float1Value;
		}

		public SingularSerializableParameter(Vector2 float2Value)
		{
			type = ParameterType.float2;
			Float2Value = float2Value;
		}

		public SingularSerializableParameter(Vector3 float3Value)
		{
			type = ParameterType.float3;
			Float3Value = float3Value;
		}

		[SerializeField] ParameterType type;
		public ParameterType Type => type;

		[SerializeField] string behaviorActionGuid;
		[NonSerialized] BehaviorAction behaviorAction;

		[SerializeField] int scaler1;
		[SerializeField] int scaler2;
		[SerializeField] int scaler3;

		public virtual BehaviorAction BehaviorActionValue
		{
			get => CheckReturn(behaviorAction);
			set
			{
				CheckReturn(value);
				if (BehaviorActionValue == value) return;

				behaviorAction = value;
				behaviorActionGuid = value?.guid;

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

		public virtual void CopyFrom(SingularSerializableParameter parameter)
		{
			if (parameter.Type != Type) throw ExceptionHelper.Invalid(nameof(parameter), parameter, "has a mismatched parameter type!");

			behaviorActionGuid = parameter.behaviorActionGuid;

			scaler1 = parameter.scaler1;
			scaler2 = parameter.scaler2;
			scaler3 = parameter.scaler3;
		}

		public void LoadBehaviorAction(ActionImportData data)
		{
			CheckReturn<BehaviorAction>(null);

			if (string.IsNullOrEmpty(behaviorActionGuid)) return; //Missing action
			behaviorAction = data.GetActionByGuid(behaviorActionGuid);
		}

		public object GetValue()
		{
			switch (Type)
			{
				case ParameterType.behaviorAction: return BehaviorActionValue;
				case ParameterType.boolean:        return BooleanValue;
				case ParameterType.integer1:       return Integer1Value;
				case ParameterType.integer2:       return Integer2Value;
				case ParameterType.integer3:       return Integer3Value;
				case ParameterType.float1:         return Float1Value;
				case ParameterType.float2:         return Float2Value;
				case ParameterType.float3:         return Float3Value;
			}

			throw ExceptionHelper.Invalid(nameof(Type), Type, InvalidType.unexpected);
		}

		protected T CheckReturn<T>(T value)
		{
			if (typeof(T) == Type.GetParameterType()) return value;
			throw new Exception($"This {nameof(SerializableParameter)} has the type {Type} but you are trying to yse its value as an {typeof(T)}!");
		}

		protected static float BitwiseConvert(int value) => ScalerHelper.Int32BitsToSingle(value);
		protected static int BitwiseConvert(float value) => ScalerHelper.SingleToInt32Bits(value);
	}

	[Serializable]
	public class SerializableParameter : SingularSerializableParameter
	{
		public SerializableParameter(ParameterType type) : base(type) { }
		public SerializableParameter(SerializableParameter source) : base(source) { }
		public SerializableParameter(BehaviorAction behaviorAction) : base(behaviorAction) { }

		public SerializableParameter(bool booleanValue) : base(booleanValue) { }

		//public SerializableParameter(Enum enumerationValue) : base(enumerationValue) { }
		public SerializableParameter(int integer1Value) : base(integer1Value) { }
		public SerializableParameter(Vector2Int integer2Value) : base(integer2Value) { }
		public SerializableParameter(Vector3Int integer3Value) : base(integer3Value) { }
		public SerializableParameter(float float1Value) : base(float1Value) { }
		public SerializableParameter(Vector2 float2Value) : base(float2Value) { }
		public SerializableParameter(Vector3 float3Value) : base(float3Value) { }

		public override BehaviorAction BehaviorActionValue
		{
			set
			{
				CheckReturn(value);
				if (BehaviorActionValue == value) return;

				BehaviorActionParameters = value == null ? null : new BehaviorActionParametersAccessor(value);
				base.BehaviorActionValue = value;
			}
		}

		[SerializeField] BehaviorActionParametersAccessor _behaviorActionParameters;

		public BehaviorActionParametersAccessor BehaviorActionParameters
		{
			get => _behaviorActionParameters;
			private set => _behaviorActionParameters = value;
		}

		public override void CopyFrom(SingularSerializableParameter parameter)
		{
			base.CopyFrom(parameter);

			if (!(parameter is SerializableParameter serializable)) return;
			if (serializable.BehaviorActionParameters != null && serializable.Type == ParameterType.behaviorAction && serializable.BehaviorActionValue != null)
			{
				BehaviorActionParameters = new BehaviorActionParametersAccessor(serializable.BehaviorActionParameters, serializable.BehaviorActionValue);
			}
		}

		[Serializable]
		public class BehaviorActionParametersAccessor
		{
			public BehaviorActionParametersAccessor(BehaviorAction action)
			{
				IReadOnlyList<BehaviorActionParameterInfo> source = action.method.Parameters;
				parameters = new SingularSerializableParameter[source.Count];

				for (int i = 0; i < source.Count; i++) parameters[i] = new SingularSerializableParameter(source[i].type);
			}

			public BehaviorActionParametersAccessor(BehaviorActionParametersAccessor source, BehaviorAction action)
			{
				var actionSource = action.method?.Parameters;

				int sourceLength = source.parameters?.Length ?? 0;
				int actionSourceLength = actionSource?.Count ?? 0;

				//Checks if the parameters mismatch
				bool match = sourceLength == actionSourceLength;

				if (match)
				{
					int min = Math.Min(sourceLength, actionSourceLength);

					for (int i = 0; i < min; i++)
					{
						if (source[i].Type == actionSource[i].type) continue;

						Debug.LogWarning
						(
							$"Mismatching parameters list for {action}! Source: {source.parameters} " +
							$"vs Action: {actionSource}! All parameters are reset to default!"
						);

						match = false;
						break;
					}
				}
				else
					Debug.LogWarning
					(
						$"Mismatching length for parameter list for {action}. Source length: {sourceLength} " +
						$"vs Action length: {actionSourceLength}! All parameters are reset to default!"
					);

				//Actually copy the parameters
				if (match)
				{
					if (sourceLength == 0) return;

					parameters = new SingularSerializableParameter[source.parameters.Length];
					for (int i = 0; i < parameters.Length; i++) parameters[i] = new SingularSerializableParameter(source[i]);
				}
				else
				{
					if (actionSourceLength == 0) return;

					parameters = new SingularSerializableParameter[actionSource.Count];
					for (int i = 0; i < actionSource.Count; i++) parameters[i] = new SingularSerializableParameter(actionSource[i].type);
				}
			}

			[SerializeField] SingularSerializableParameter[] parameters; //Should be readonly

			public SingularSerializableParameter this[int index] => parameters[index];
		}
	}

	public static class ParameterTypeExtensions
	{
		static readonly Dictionary<ParameterType, Type> enumToType =
			new Dictionary<ParameterType, Type>
			{
				{ParameterType.behaviorAction, typeof(BehaviorAction)}, {ParameterType.boolean, typeof(bool)}, {ParameterType.enumeration, typeof(Enum)},
				{ParameterType.integer1, typeof(int)}, {ParameterType.integer2, typeof(Vector2Int)}, {ParameterType.integer3, typeof(Vector3Int)},
				{ParameterType.float1, typeof(float)}, {ParameterType.float2, typeof(Vector2)}, {ParameterType.float3, typeof(Vector3)}
			};

		static readonly Dictionary<Type, ParameterType> typeToEnum = enumToType.ToDictionary(pair => pair.Value, pair => pair.Key);

		public static Type GetParameterType(this ParameterType type)
		{
			if (enumToType.ContainsKey(type)) return enumToType[type];
			throw ExceptionHelper.Invalid(nameof(type), type, InvalidType.unexpected);
		}

		public static ParameterType GetParameterType(this Type type)
		{
			if (typeToEnum.ContainsKey(type)) return typeToEnum[type];
			throw ExceptionHelper.Invalid(nameof(type), type, InvalidType.unexpected);
		}

		public static bool HasParameterType(this Type type) => typeToEnum.ContainsKey(type);
	}

	public enum ParameterType : byte
	{
		behaviorAction,
		boolean,
		enumeration,
		integer1,
		integer2,
		integer3,
		float1,
		float2,
		float3
	}
}