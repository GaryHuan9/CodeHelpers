﻿using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CodeHelpers.DelayedExecution;
using CodeHelpers.ThreadHelpers;
using UnityEngine;
using Object = System.Object;

//REMEMBER that we need to make CodeHelpers.CodeHelperMonoBehaviour execute before other scripts by placing it in the 
//project settings, or some methods in CodeHelpers.InputHelpers and CodeHelpers.CodeHelperMonoBehaviour.PreUpdateMethods
//would not work.

namespace CodeHelpers
{
	public static class CodeHelper
	{

#region Number Helpers

		/// <summary>
		/// Convert <paramref name="value"/> to an angle between -180(Exclusive) and 180 (Inclusive) with the same rotational value as input.
		/// </summary>
		public static float ToSignedAngle(this float value) => -(value + 180f).Repeat(360f) + 180f;

		/// <summary>
		/// Convert <paramref name="value"/> to an angle between -179 and 180 with the same rotational value as input.
		/// </summary>
		public static int ToSignedAngle(this int value) => -(value + 180).Repeat(360) + 180;

		/// <summary>
		/// Convert <paramref name="value"/> to an angle between 0f(Inclusive) and 360f (Exclusive) with the same rotational value as input.
		/// </summary>
		public static float ToUnsignedAngle(this float value) => value.Repeat(360f);

		/// <summary>
		/// Convert <paramref name="value"/> to an angle between 0 and 359 with the same rotational value as input.
		/// </summary>
		public static int ToUnsignedAngle(this int value) => value.Repeat(360);

		public static int CeilDivide(this int value, int divider) => (value - 1) / divider + 1;

		// public static bool AlmostEquals(this float value, float other)
		// {
		// 	if (value == other) return true;
		// 	return Math.Abs(value - other) < Math.Abs(value) / (1 << 20);
		// }
		//
		// public static bool AlmostEquals(this double value, double other)
		// {
		// 	if (value == other) return true;
		// 	return Math.Abs(value - other) < Math.Abs(value) / (1 << 48);
		// }

		public static Vector2Int To2D(this int value, int height) => new Vector2Int(value / height, value % height);

		public static int Normalized(this float value) => Mathf.Approximately(value, 0) ? 0 : value < 0 ? -1 : 1;
		public static int Normalized(this float value, float threshold) => Mathf.Abs(value) <= threshold ? 0 : value < 0 ? -1 : 1;
		public static int Normalized(this int value) => value == 0 ? 0 : value < 0 ? -1 : 1;

		/// <summary>Another implementation of Unity's Mathf.Repeat method. Slightly faster.</summary>
		public static float Repeat(this float value, float length)
		{
			float result = value % length;
			return result < 0f ? result + length : result;
		}

		/// <summary>Another implementation of Unity's Mathf.Repeat method. Slightly faster.</summary>
		public static int Repeat(this int value, int length)
		{
			int result = value % length;
			return result < 0 ? result + length : result;
		}

		/// <summary>Another implementation of Unity's Mathf.Repeat method. Slightly faster.</summary>
		public static long Repeat(this long value, long length)
		{
			long result = value % length;
			return result < 0 ? result + length : result;
		}

		public static void Swap(ref float thisFloat, ref float otherFloat)
		{
			float storageFloat = thisFloat;
			thisFloat = otherFloat;
			otherFloat = storageFloat;
		}

		public static void Swap(ref int thisInt, ref int otherInt)
		{
			int storageInt = thisInt;
			thisInt = otherInt;
			otherInt = storageInt;
		}

		public static int FlooredDivide(this int value, int divisor) => value / divisor - Convert.ToInt32((value < 0) ^ (divisor < 0) && value % divisor != 0);
		public static long FlooredDivide(this long value, long divisor) => value / divisor - Convert.ToInt64((value < 0) ^ (divisor < 0) && value % divisor != 0);

		public static float Remap(this float value, float fromLow, float fromHigh, float toLow, float toHigh) => (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;

#if UNSAFE_CODE_ENABLED
		public static unsafe int SingleToInt32Bits(float value) => *(int*)&value;
		public static unsafe float Int32BitsToSingle(int value) => *(float*)&value;
#endif

		public const float Epsilon = 0.00001f;

#endregion

#region Camera Helpers

		static Camera mainCamera;

		public static Camera MainCamera
		{
			get => mainCamera = mainCamera ? mainCamera : Camera.main;
			set => mainCamera = value;
		}

#endregion

#region Special Method Helpers

		/// <summary>This will generate a method that can be only called once a frame. They will be called at end frame. (Thread safe)</summary>
		public static Action GetOneCallMethod(Action action) => new OneCallMethod(action).CallAction;

		class OneCallMethod
		{
			public OneCallMethod(Action action)
			{
				invokeAction = () =>
				{
					action();
					hasCalled = false;
				};
			}

			readonly Action invokeAction;
			volatile bool hasCalled;

			public void CallAction()
			{
				if (hasCalled) return;

				hasCalled = true;
				InvokeEndFrame(invokeAction);
			}
		}

		/// <summary>This will generate a method that will invoke a method randomly within a period of time. (Not thread safe)</summary>
		public static Action GetRandomInvokeMethod(Action action, float maxDelay = 1f) => new RandomInvokeMethod(maxDelay, action).CallAction;

		class RandomInvokeMethod
		{
			public RandomInvokeMethod(float delay, Action action)
			{
				this.delay = delay;
				this.action = action;
			}

			readonly float delay;
			readonly Action action;

			bool isCalling;

			public void CallAction()
			{
				if (isCalling) return;

				isCalling = true;
				StartCoroutine(RandomInvoke());
			}

			IEnumerator RandomInvoke()
			{
				float thisDelay = (float)RandomHelper.Value * delay;

				yield return new WaitForSeconds(thisDelay);

				action();
				isCalling = false;
			}
		}

#endregion

#region IEnumerable Helpers

		/// <summary>
		/// This is a fast implementation of remove for IList.
		/// But it will mess up the list's order and you should only use
		/// this method if you are sure that you are not caring about the order of this list.
		/// </summary>
		public static bool RemoveIgnoreOrder<T>(this IList<T> list, T item)
		{
			int index = list.IndexOf(item);
			if (index < 0) return false;

			list.RemoveAtIgnoreOrder(index);
			return true;
		}

		/// <summary>
		/// This is an O(1) implementation of remove at for IList.
		/// But it will mess up the list's order and you should only use
		/// this method if you are sure that you are not caring about the order of this list.
		/// </summary>
		public static void RemoveAtIgnoreOrder<T>(this IList<T> list, int index)
		{
			if (index != list.Count - 1) list[index] = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
		}

		public static bool IsIndexValid<T>(this IReadOnlyList<T> array, int index) =>
			array.Count > index && index >= 0;

		public static bool IsIndexValid<T>(this T[,] array, Vector2Int index) =>
			array.GetLength(0) > index.x && index.x >= 0 &&
			array.GetLength(1) > index.y && index.y >= 0;

		public static bool IsIndexValid<T>(this T[,,] array, Vector3Int index) =>
			array.GetLength(0) > index.x && index.x >= 0 &&
			array.GetLength(1) > index.y && index.y >= 0 &&
			array.GetLength(2) > index.z && index.z >= 0;

		public static Vector2Int? IndexOf<T>(this T[,] array, T item) where T : IEquatable<T>
		{
			for (int x = 0; x < array.GetLength(0); x++)
			{
				for (int y = 0; y < array.GetLength(1); y++)
				{
					if (array[x, y].Equals(item)) return new Vector2Int(x, y);
				}
			}

			return null;
		}

		public static Vector3Int? IndexOf<T>(this T[,,] array, T item) where T : IEquatable<T>
		{
			for (int x = 0; x < array.GetLength(0); x++)
			{
				for (int y = 0; y < array.GetLength(1); y++)
				{
					for (int z = 0; z < array.GetLength(2); z++)
					{
						if (array[x, y, z].Equals(item)) return new Vector3Int(x, y, z);
					}
				}
			}

			return null;
		}

		public static Vector2Int Size<T>(this T[,] array) => new Vector2Int(array.GetLength(0), array.GetLength(1));
		public static Vector3Int Size<T>(this T[,,] array) => new Vector3Int(array.GetLength(0), array.GetLength(1), array.GetLength(2));

		public static float[,] CombineFloatArrays(float[,] array1, float[,] array2, float chance1, float chance2)
		{
			float[,] finalArray = new float[array1.GetLength(0), array1.GetLength(1)];

			float totalChance = chance1 + chance2;
			chance1 = chance1 / totalChance;
			chance2 = chance2 / totalChance;

			for (int x = 0; x < array1.GetLength(0); x++)
			{
				for (int y = 0; y < array1.GetLength(1); y++)
				{
					finalArray[x, y] = array1[x, y] * chance1 + array2[x, y] * chance2;
				}
			}

			return finalArray;
		}

		public static T[] Get1D<T>(this T[,] array, int index)
		{
			T[] result = new T[array.GetLength(1)];
			for (int i = 0; i < array.GetLength(1); i++) result[i] = array[index, i];
			return result;
		}

		public static IEnumerable<T> GetAllNonNull<T>(this IEnumerable<T> enumerable) where T : class =>
			from thisT in enumerable
			where thisT != null
			select thisT;

		public static int Count<T>(this IEnumerable<T> iEnumerable, Func<T, int> countSelector)
		{
			int count = 0;
			iEnumerable.ForEach(thisT => count += countSelector(thisT));
			return count;
		}

#region ForEach

		public static void ForEach<T>(this IEnumerable<T> iEnumerable, Action<T> action)
		{
			foreach (T thisT in iEnumerable) action(thisT);
		}

		public static void ForEach<T>(this IEnumerable<T> iEnumerable, Action<T, int> action)
		{
			int index = 0;
			foreach (T thisT in iEnumerable)
			{
				action(thisT, index);
				index++;
			}
		}

		public static void ForEach<T>(this T[] array, Action<T> action)
		{
			if (array == null) return;

			for (int i = 0; i < array.Length; i++)
			{
				action(array[i]);
			}
		}

		public static void ForEach<T>(this T[] array, Action<T, int> action)
		{
			if (array == null) return;

			for (int i = 0; i < array.Length; i++)
			{
				action(array[i], i);
			}
		}

		public static void ForEach<T>(this T[,] array, Action<T> action)
		{
			if (array == null) return;

			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					action(array[i, j]);
				}
			}
		}

		public static void ForEach<T>(this T[,] array, Action<T, int> action)
		{
			if (array == null) return;

			int index = 0;

			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					action(array[i, j], index);
					index++;
				}
			}
		}

		public static void ForEach<T>(this T[,] array, Action<T, Vector2Int> action)
		{
			if (array == null) return;

			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					action(array[i, j], new Vector2Int(i, j));
				}
			}
		}

		public static void ForEach<T>(this T[,] array, Action<T, int, int> action)
		{
			if (array == null) return;

			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					action(array[i, j], i, j);
				}
			}
		}

		public static void ForEach<T>(this T[,,] array, Action<T> action)
		{
			if (array == null) return;

			int length0 = array.GetLength(0);
			int length1 = array.GetLength(1);
			int length2 = array.GetLength(2);

			for (int i = 0; i < length0; i++)
			{
				for (int j = 0; j < length1; j++)
				{
					for (int k = 0; k < length2; k++)
					{
						action(array[i, j, k]);
					}
				}
			}
		}

		public static void ForEach<T>(this T[,,] array, Action<T, int> action)
		{
			if (array == null) return;

			int index = 0;

			int length0 = array.GetLength(0);
			int length1 = array.GetLength(1);
			int length2 = array.GetLength(2);

			for (int i = 0; i < length0; i++)
			{
				for (int j = 0; j < length1; j++)
				{
					for (int k = 0; k < length2; k++)
					{
						action(array[i, j, k], index);
						index++;
					}
				}
			}
		}

		public static void ForEach<T>(this T[,,] array, Action<T, int, int, int> action)
		{
			if (array == null) return;

			int length0 = array.GetLength(0);
			int length1 = array.GetLength(1);
			int length2 = array.GetLength(2);

			for (int i = 0; i < length0; i++)
			{
				for (int j = 0; j < length1; j++)
				{
					for (int k = 0; k < length2; k++)
					{
						action(array[i, j, k], i, j, k);
					}
				}
			}
		}

		public static void ForEach<T>(this IList<T> list, Action<T> action)
		{
			if (list == null) return;

			for (int i = 0; i < list.Count; i++)
			{
				action(list[i]);
			}
		}

		public static void ForEach<T>(this IList<T> list, Action<T, int> action)
		{
			if (list == null) return;

			for (int i = 0; i < list.Count; i++)
			{
				action(list[i], i);
			}
		}

		public static void ForEach<T>(this Queue<T> queue, Action<T> action, bool removeItem = true)
		{
			while (queue.Count > 0)
			{
				T item = queue.Dequeue();
				action(item);
				if (!removeItem) queue.Enqueue(item);
			}
		}

		public static void ForEach<T>(this Queue<T> queue, Action<T, int> action, bool removeItem = true)
		{
			int index = 0;
			while (queue.Count > 0)
			{
				T item = queue.Dequeue();
				action(item, index++);
				if (!removeItem) queue.Enqueue(item);
			}
		}

		public static void ForEach<T>(this ConcurrentQueue<T> queue, Action<T> action, bool removeItem = true)
		{
			while (queue.Count > 0)
			{
				if (queue.TryDequeue(out T item)) action(item);
				if (!removeItem) queue.Enqueue(item);
			}
		}

		public static void ForEach<T>(this ConcurrentQueue<T> queue, Action<T, int> action, bool removeItem = true)
		{
			int index = 0;
			while (queue.Count > 0)
			{
				if (queue.TryDequeue(out T item)) action(item, index++);
				if (!removeItem) queue.Enqueue(item);
			}
		}

		public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Action<TKey> action)
		{
			dictionary.Keys.ForEach(thisKey => action(thisKey));
		}

		public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Action<TKey, int> action)
		{
			dictionary.Keys.ForEach((thisKey, index) => action(thisKey, index));
		}

		public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Action<TValue> action)
		{
			dictionary.Values.ForEach(thisValue => action(thisValue));
		}

		public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Action<TValue, int> action)
		{
			dictionary.Values.ForEach((thisValue, index) => action(thisValue, index));
		}

		//For each specials

		public static void ForEachS<T>(this IDictionary<int, T> dictionary, Action<T> action) //These only work with dictionary indexed like an array
		{
			int count = dictionary.Count;

			for (int i = 0; i < count; i++)
			{
				action(dictionary[i]);
			}
		}

		public static void ForEachS<T>(this IDictionary<int, T> dictionary, Action<T, int> action) //These only work with dictionary indexed like an array
		{
			int count = dictionary.Count;

			for (int i = 0; i < count; i++)
			{
				action(dictionary[i], i);
			}
		}

#endregion

		public static bool AllSameValue<T, TValue>(this IEnumerable<T> enumerable, Func<T, TValue> valueGetter)
		{
			if (!enumerable.Any()) throw new NullReferenceException("enumerable cannot be null!");

			TValue selectedValue = valueGetter(enumerable.First());

			return enumerable.All(thisT => valueGetter(thisT).Equals(selectedValue));
		}

		public static TValue TryGetValue<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key) =>
			dictionary != null && (key is ValueType || key != null) && dictionary.ContainsKey(key) ? dictionary[key] : default;

		public static T TryGetValue<T>(this IReadOnlyList<T> array, int index) =>
			array != null && array.IsIndexValid(index) ? array[index] : default;

		public static void Swap<T>(this T[] array, int index1, int index2)
		{
			T storage = array[index1];
			array[index1] = array[index2];
			array[index2] = storage;
		}

		public static void Swap<T>(this IList<T> list, int index1, int index2)
		{
			T storage = list[index1];
			list[index1] = list[index2];
			list[index2] = storage;
		}

#endregion

#region Color Helpers

		public static Vector3Int ToVector8bit(this Color color) => new Vector3(color.r * 255f, color.g * 255f, color.b * 255f).RoundToInt();
		public static Vector3Int ToVector16bit(this Color color) => new Vector3(color.r * 65535f, color.g * 65535f, color.b * 65535f).RoundToInt();

#endregion

#region Call Events

		internal static readonly InvokeMethod invokeBeforeFrame = new InvokeMethod();
		internal static readonly InvokeMethod invokeNextFrame = new InvokeMethod();
		internal static readonly InvokeMethod invokeEndFrame = new InvokeMethod();

		//These methods does not ensure which frame the action execute, but it will execute them in the correct frame phase

		public static void InvokeBeforeFrame(Action action) => invokeBeforeFrame.Add(action);
		public static void InvokeNextFrame(Action action) => invokeNextFrame.Add(action);
		public static void InvokeEndFrame(Action action) => invokeEndFrame.Add(action);

		public static void InvokeAfter(Action action, float delay) //A great tool for debugging
		{
			if (action == null) throw new NullReferenceException("action cannot be null!!!");
			StartCoroutine(CallMethodAfterCoroutine(action, delay));
		}

		static IEnumerator CallMethodAfterCoroutine(Action action, float delay)
		{
			yield return new WaitForSeconds(delay);
			action();
		}

		internal class InvokeMethod
		{
			readonly Queue<Action> actions = new Queue<Action>();
			readonly ConcurrentQueue<Action> threadedActions = new ConcurrentQueue<Action>();

			public void Add(Action action)
			{
				if (action == null) throw new NullReferenceException("action cannot be null!!!");
				if (ThreadHelper.IsInMainThread) actions.Enqueue(action);
				else threadedActions.Enqueue(action);
			}

			public void InvokeAll()
			{
				actions.ForEach(action => action());
				threadedActions.ForEach(action => action());
			}
		}

#endregion

		public static Coroutine StartCoroutine(IEnumerator coroutine)
		{
			if (CodeHelperMonoBehaviour.instance == null) throw new Exception("You did not add CodeHelper in the scene yet!!!");
			return CodeHelperMonoBehaviour.instance.StartCoroutine(coroutine);
		}

		public static void StopCoroutine(IEnumerator coroutine)
		{
			if (CodeHelperMonoBehaviour.instance == null) throw new Exception("You did not add CodeHelper in the scene yet!!!");
			CodeHelperMonoBehaviour.instance.StopCoroutine(coroutine);
		}

		public static void StopCoroutine(Coroutine coroutine)
		{
			if (CodeHelperMonoBehaviour.instance == null) throw new Exception("You did not add CodeHelper in the scene yet!!!");
			CodeHelperMonoBehaviour.instance.StopCoroutine(coroutine);
		}

		public static T ToNotNullable<T>(this T? nullable, out bool isNull) where T : struct
		{
			isNull = nullable == null;
			return nullable.GetValueOrDefault();
		}

		public static string ToMethodSignature(this MethodInfo method) =>
			$@"{method.ReturnType.Name} {method.Name}({string.Join(", ", from parameter in method.GetParameters()
																		 select $"{parameter.ParameterType.Name} {parameter.Name}")})";

		public static string ToMethodSignatureNoReturnType(this MethodInfo method) =>
			$@"{method.Name}({string.Join(", ", from parameter in method.GetParameters()
												select $"{parameter.ParameterType.Name} {parameter.Name}")})";

		public static readonly object placeholder = new object();
	}
}