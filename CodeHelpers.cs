using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using CodeHelpers.Collections;
using CodeHelpers.ThreadHelpers;
using UnityEngine;

//REMEMBER that we need to make CodeHelpers.CodeHelperMonoBehaviour execute before other scripts by placing it in the 
//project settings, or some methods in CodeHelpers.InputHelpers and CodeHelpers.CodeHelperMonoBehaviour.PreUpdateMethods
//would not work.

namespace CodeHelpers
{
	public static class CodeHelper
	{
		public const float Epsilon = 0.00001f;

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
								   Interlocked.Exchange(ref hasCalled, 0);
							   };
			}

			readonly Action invokeAction;
			int hasCalled;

			public void CallAction()
			{
				if (Interlocked.Exchange(ref hasCalled, 1) == 1) return;
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
			dictionary.ContainsKey(key) ? dictionary[key] : default;

		public static T TryGetValue<T>(this IReadOnlyList<T> list, int index) =>
			list.IsIndexValid(index) ? list[index] : default;

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
				if (action == null) throw new NullReferenceException("action cannot be null!");

				if (ThreadHelper.IsOnMainThread) actions.Enqueue(action);
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

		public static void Swap<T>(ref T first, ref T second)
		{
			T storage = first;
			first = second;
			second = storage;
		}

		public static T ToNotNullable<T>(this T? nullable, out bool isNull) where T : struct
		{
			isNull = nullable == null;
			return nullable.GetValueOrDefault();
		}

		public static T GetComponent<T>(this Behaviour behaviour, ref T cache)
		{
			if (cache != null) return cache;
			return cache = behaviour.GetComponent<T>();
		}

		public static T GetComponentInChildren<T>(this Behaviour behaviour, ref T cache)
		{
			if (cache != null) return cache;
			return cache = behaviour.GetComponentInChildren<T>();
		}

		public static T GetComponentInParent<T>(this Behaviour behaviour, ref T cache)
		{
			if (cache != null) return cache;
			return cache = behaviour.GetComponentInParent<T>();
		}

		public static float GetHorizontalFieldOfView(this Camera camera)
		{
			var tan = Mathf.Tan(camera.fieldOfView * Mathf.Deg2Rad / 2f);
			return Mathf.Rad2Deg * 2f * Mathf.Atan(tan * camera.aspect);
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