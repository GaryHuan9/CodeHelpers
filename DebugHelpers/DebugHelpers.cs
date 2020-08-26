using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using CodeHelpers.ObjectPooling;
using Object = System.Object;

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

		static readonly ThreadLocal<StringBuilderPooler> stringBuilderPooler = new ThreadLocal<StringBuilderPooler>(() => new StringBuilderPooler());
		static readonly ThreadLocal<object[]> paramsArrayCache = new ThreadLocal<object[]>(() => new object[4]);

		const string NullString = "_NULL_";

		/// <summary>
		/// Returns how many time this method has been invoked in this frame
		/// </summary>
		public static int InvokedPerFrame()
		{
			if (CodeHelperMonoBehaviour.FramePhase == FramePhase.Pre) throw new Exception("This method does not work in pre frames!");
			return ++invokedPerFrame;
		}

		/// <summary>Debug.Log the specified objects.</summary>
		public static void Log(params object[] objects) => LogInternal(objects, objects.Length);

#region LogOverloadedMethods

		/// <summary>Debug.Log the specified object.</summary>
		public static void Log(object object0)
		{
			paramsArrayCache.Value[0] = object0;
			LogInternal(paramsArrayCache.Value, 1);
		}

		/// <summary>Debug.Log the specified objects.</summary>
		public static void Log(object object0, object object1)
		{
			paramsArrayCache.Value[0] = object0;
			paramsArrayCache.Value[1] = object1;
			LogInternal(paramsArrayCache.Value, 2);
		}

		/// <summary>Debug.Log the specified objects.</summary>
		public static void Log(object object0, object object1, object object2)
		{
			paramsArrayCache.Value[0] = object0;
			paramsArrayCache.Value[1] = object1;
			paramsArrayCache.Value[2] = object2;
			LogInternal(paramsArrayCache.Value, 3);
		}

		/// <summary>Debug.Log the specified objects.</summary>
		public static void Log(object object0, object object1, object object2, object object3)
		{
			paramsArrayCache.Value[0] = object0;
			paramsArrayCache.Value[1] = object1;
			paramsArrayCache.Value[2] = object2;
			paramsArrayCache.Value[3] = object3;
			LogInternal(paramsArrayCache.Value, 4);
		}

#endregion

		/// <summary>
		/// Logs objects in <paramref name="objects"/>.
		/// Will only process objects from index 0 to <paramref name="length"/> (inclusive,exclusive)
		/// </summary>
		static void LogInternal(IReadOnlyList<object> objects, int length)
		{
			int readTo = Math.Min(objects.Count, length);

			if (readTo == 0)
			{
				Debug.Log("");
				return;
			}

			if (readTo == 1)
			{
				Debug.Log(ToString(objects[0]));
				return;
			}

			StringBuilder builder = stringBuilderPooler.Value.GetObject();

			for (int i = 0; i < readTo; i++)
			{
				builder.AppendFormat($"{ToString(objects[i])}; ");
			}

			Debug.Log(builder.ToString());
			stringBuilderPooler.Value.ReleaseObject(builder);
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
		public static string ToString<T>(IEnumerable<T> target) => $"{target.GetType()} + Count: {target.Count()} [{string.Join(" , ", target.Select(item => ToString(item)))}]";

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
	}
}