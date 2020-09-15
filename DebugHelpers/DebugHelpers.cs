using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using CodeHelpers.ObjectPooling;

namespace CodeHelpers.DebugHelpers
{
	public static class DebugHelper
	{
		static DebugHelper() => CodeHelperMonoBehaviour.UnityPreUpdateMethods += ConstantUpdate;

		static void ConstantUpdate()
		{
			invokedPerFrame = 0;
		}

		static int invokedPerFrame;

		static readonly ThreadLocal<StringBuilderPooler> stringBuilderPoolerLocal = new ThreadLocal<StringBuilderPooler>(() => new StringBuilderPooler());
		static readonly ThreadLocal<ObjectsBuffer> objectsBufferLocal = new ThreadLocal<ObjectsBuffer>(() => new ObjectsBuffer(4, DebugLogType.normal));

		static readonly ReadOnlyDictionary<DebugLogType, Action<string>> logActions = new ReadOnlyDictionary<DebugLogType, Action<string>>
		(
			new Dictionary<DebugLogType, Action<string>>
			{
				{DebugLogType.normal, Debug.Log},
				{DebugLogType.warning, Debug.LogWarning},
				{DebugLogType.error, Debug.LogError}
			}
		);

		const string NullString = "_NULL_";

		/// <summary>
		/// Returns how many time this method has been invoked in this frame
		/// </summary>
		public static int InvokedPerFrame()
		{
			if (CodeHelperMonoBehaviour.FramePhase == FramePhase.Pre) throw new Exception("This method does not work in pre frames!");
			return ++invokedPerFrame;
		}

#region LogOverloads

		public static void Log(DebugLogType type, params object[] objects) => LogInternal(new ObjectsBuffer(objects, type), objects.Length);

		public static void Log(DebugLogType type, object object0)
		{
			var buffer = new ObjectsBuffer(objectsBufferLocal.Value, type)
						 {
							 [0] = object0
						 };
			LogInternal(buffer, 1);
		}

		public static void Log(DebugLogType type, object object0, object object1)
		{
			var buffer = new ObjectsBuffer(objectsBufferLocal.Value, type)
						 {
							 [0] = object0,
							 [1] = object1
						 };
			LogInternal(buffer, 2);
		}

		public static void Log(DebugLogType type, object object0, object object1, object object2)
		{
			var buffer = new ObjectsBuffer(objectsBufferLocal.Value, type)
						 {
							 [0] = object0,
							 [1] = object1,
							 [2] = object2
						 };
			LogInternal(buffer, 3);
		}

		public static void Log(DebugLogType type, object object0, object object1, object object2, object object3)
		{
			var buffer = new ObjectsBuffer(objectsBufferLocal.Value, type)
						 {
							 [0] = object0,
							 [1] = object1,
							 [2] = object2,
							 [3] = object3
						 };
			LogInternal(buffer, 4);
		}

		public static void Log(params object[] objects) => Log(DebugLogType.normal, objects);

		public static void Log(object object0) => Log(DebugLogType.normal, object0);
		public static void Log(object object0, object object1) => Log(DebugLogType.normal, object0, object1);
		public static void Log(object object0, object object1, object object2) => Log(DebugLogType.normal, object0, object1, object2);
		public static void Log(object object0, object object1, object object2, object object3) => Log(DebugLogType.normal, object0, object1, object2, object3);

		public static void LogWarning(object object0) => Log(DebugLogType.warning, object0);
		public static void LogWarning(object object0, object object1) => Log(DebugLogType.warning, object0, object1);
		public static void LogWarning(object object0, object object1, object object2) => Log(DebugLogType.warning, object0, object1, object2);
		public static void LogWarning(object object0, object object1, object object2, object object3) => Log(DebugLogType.warning, object0, object1, object2, object3);

		public static void LogError(object object0) => Log(DebugLogType.error, object0);
		public static void LogError(object object0, object object1) => Log(DebugLogType.error, object0, object1);
		public static void LogError(object object0, object object1, object object2) => Log(DebugLogType.error, object0, object1, object2);
		public static void LogError(object object0, object object1, object object2, object object3) => Log(DebugLogType.error, object0, object1, object2, object3);

#endregion

		/// <summary>
		/// Logs objects buffered in <paramref name="buffer"/>.
		/// Will only process objects from index 0 to <paramref name="length"/> [inclusive, exclusive)
		/// </summary>
		static void LogInternal(ObjectsBuffer buffer, int length)
		{
			if (length == 0) //Handles degenerate input
			{
				Debug.Log("");
				return;
			}

			StringBuilder builder = stringBuilderPoolerLocal.Value.GetObject();
			for (int i = 0; i < length; i++) builder.AppendFormat($"{ToString(buffer[i])}; ");

			logActions[buffer.logType](builder.ToString());
			stringBuilderPoolerLocal.Value.ReleaseObject(builder);
		}

		public static string ToDebugString(this object target) => ToString(target);

		public static string ToString(object target)
		{
			switch (target)
			{
				case Vector3 vector:    return vector.ToString("F3");
				case Vector2 vector:    return vector.ToString("F3");
				case Vector4 vector:    return vector.ToString("F3");
				case Vector3Int vector: return vector.ToString();
				case Vector2Int vector: return vector.ToString();
			}

			string customToString = GetCustomToString(target);
			if (customToString != null) return customToString;

			switch (target)
			{
				case null:                   return NullString;
				case string stringTarget:    return ToString(stringTarget);
				case IEnumerable enumerable: return ToString(enumerable.Cast<object>());
			}

			return $"{target} (HCode: {target.GetHashCode()})";
		}

		public static string ToString(string target) => target;

		public static string ToString<T>(IEnumerable<T> target)
		{
			var array = target.Select(item => ToString(item)).ToArray();
			return $"{target.GetType()} + Count: {array.Length} [{string.Join(", ", array)}]";
		}

		/// <summary>
		/// Does <paramref name="target"/> has a custom to string method?
		/// Returns the custom to string if it has one, or null if is default.
		/// </summary>
		static string GetCustomToString(object target)
		{
			if (target is null) return null;
			string toString = target.ToString();
			return toString == target.GetType().ToString() ? null : toString;
		}

		readonly struct ObjectsBuffer
		{
			public ObjectsBuffer(object[] objects, DebugLogType logType)
			{
				this.objects = objects;
				this.logType = logType;
			}

			public ObjectsBuffer(int bufferSize, DebugLogType logType) : this(new object[bufferSize], logType) { }
			public ObjectsBuffer(ObjectsBuffer buffer, DebugLogType logType) : this(buffer.objects, logType) { }

			readonly object[] objects;
			public readonly DebugLogType logType;

			public object this[int index]
			{
				get => objects[index];
				set => objects[index] = value;
			}

			public int Length => objects.Length;
		}
	}

	public enum DebugLogType
	{
		normal,
		warning,
		error
	}
}