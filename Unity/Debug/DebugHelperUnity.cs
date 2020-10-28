#if CODEHELPERS_UNITY

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using CodeHelpers.ObjectPooling;
using UnityEngine;

namespace CodeHelpers.Unity.Debugs
{
	public static class DebugHelperUnity
	{
		static DebugHelperUnity() => CodeHelperMonoBehavior.UnityPreUpdateMethods += ConstantUpdate;

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

		/// <summary>
		/// Returns how many time this method has been invoked in this frame
		/// </summary>
		public static int InvokedPerFrame()
		{
			if (CodeHelperMonoBehavior.FramePhase == FramePhase.Pre) throw new Exception("This method does not work in pre frames!");
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

			for (int i = 0; i < length; i++)
			{
				builder.Append(DebugHelper.ToString(buffer[i]));
				builder.Append("; ");
			}

			logActions[buffer.logType](builder.ToString());
			stringBuilderPoolerLocal.Value.ReleaseObject(builder);
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

#endif