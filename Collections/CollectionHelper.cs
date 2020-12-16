using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CodeHelpers.Mathematics;

namespace CodeHelpers.Collections
{
	public static class CollectionHelper
	{
		/// <summary>
		/// Binary search the <paramref name="list"/>. Returns the positive index if an item according to the <paramref name="comparer"/> is found.
		/// If no matching items can be found, returns a negative number. You can get where the item is suppose to be located by using the bit invert operator on that number.
		/// NOTE: Must use an ordered list. None ordered lists will yield incorrect results.
		/// </summary>
		public static int BinarySearch<TItem, TKey>(this IList<TItem> list, TKey key, IDoubleComparer<TItem, TKey> comparer)
		{
			if (list.Count == 0) return ~0;

			int minIndex = 0;
			int maxIndex = list.Count - 1;

			int index = (minIndex + maxIndex) / 2;
			var current = list[index];

			while (true)
			{
				int compared = comparer.CompareTo(current, key);
				if (compared == 0) return index;

				if (compared > 0) maxIndex = index - 1;
				else minIndex = index + 1;

				index = (minIndex + maxIndex) / 2;
				if (minIndex > maxIndex) return ~minIndex;

				current = list[index];
			}
		}


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

		public static bool IsIndexValid<T>(this T[,] array, Int2 index) =>
			array.GetLength(0) > index.x && index.x >= 0 &&
			array.GetLength(1) > index.y && index.y >= 0;

		public static bool IsIndexValid<T>(this T[,,] array, Int3 index) =>
			array.GetLength(0) > index.x && index.x >= 0 &&
			array.GetLength(1) > index.y && index.y >= 0 &&
			array.GetLength(2) > index.z && index.z >= 0;

		public static int IndexOf<T>(this IEnumerable<T> enumerable, T item)
		{
			if (enumerable is IList<T> list) return list.IndexOf(item);
			EqualityComparer<T> comparer = EqualityComparer<T>.Default;

			int index = 0;

			foreach (T value in enumerable)
			{
				if (comparer.Equals(value, item)) return index;
				index++;
			}

			return -1;
		}

		public static Int2? IndexOf<T>(this T[,] array, T item) where T : IEquatable<T>
		{
			Int2 size = array.Size();

			for (int x = 0; x < size.x; x++)
			{
				for (int y = 0; y < size.y; y++)
				{
					if (array[x, y].Equals(item)) return new Int2(x, y);
				}
			}

			return null;
		}

		public static Int3? IndexOf<T>(this T[,,] array, T item) where T : IEquatable<T>
		{
			Int3 size = array.Size();

			for (int x = 0; x < size.x; x++)
			{
				for (int y = 0; y < size.y; y++)
				{
					for (int z = 0; z < size.z; z++)
					{
						if (array[x, y, z].Equals(item)) return new Int3(x, y, z);
					}
				}
			}

			return null;
		}

		public static Int2 Size<T>(this T[,] array) => new Int2(array.GetLength(0), array.GetLength(1));
		public static Int3 Size<T>(this T[,,] array) => new Int3(array.GetLength(0), array.GetLength(1), array.GetLength(2));

		public static float[,] CombineFloatArrays(float[,] array1, float[,] array2, float chance1, float chance2)
		{
			float[,] finalArray = new float[array1.GetLength(0), array1.GetLength(1)];

			float totalChance = chance1 + chance2;
			chance1 /= totalChance;
			chance2 /= totalChance;

			for (int x = 0; x < array1.GetLength(0); x++)
			{
				for (int y = 0; y < array1.GetLength(1); y++)
				{
					finalArray[x, y] = array1[x, y] * chance1 + array2[x, y] * chance2;
				}
			}

			return finalArray;
		}

		/// <summary>
		/// Inserts <paramref name="item"/> at <paramref name="index"/>; pushes everything back by one.
		/// NOTE: The last item in the array will get removed/replaced!
		/// </summary>
		public static void Insert<T>(this T[] array, int index, T item = default) => array.Shift(index, 1, item);

		/// <summary>
		/// Shifts everything at and behind <paramref name="index"/> back by <paramref name="space"/>.
		/// <paramref name="item"/> will be used to fill in the gap in the middle.
		/// NOTE: items that will be moved out of the range of <paramref name="array"/> will be dereferenced!
		/// </summary>
		public static void Shift<T>(this T[] array, int index, int space, T item = default)
		{
			if (!array.IsIndexValid(index)) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

			int max = space + index;

			for (int i = array.Length - 1; i >= max; i--) array[i] = array[i - space];
			for (int i = index; i < max; i++) array[i] = item;
		}

		public static TValue TryGetValue<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key)
		{
			bool hasValue = dictionary.TryGetValue(key, out TValue value);
			return hasValue ? value : default; //Using the native TryGetValue method is much more efficient than using ContainsKey and the indexer
		}

		public static T TryGetValue<T>(this IReadOnlyList<T> list, int index) => list.IsIndexValid(index) ? list[index] : default;

		public static void Shuffle<T>(this IList<T> list)
		{
			Random random = RandomHelper.CurrentRandom;
			for (int i = list.Count - 1; i > 0; i--) list.Swap(i, random.Next(i + 1));
		}

		public static void Checkerboard<T>(this IList<T> list)
		{
			int half = list.Count / 2;
			for (int i = 0; i < half; i += 2) list.Swap(i, half + i);
		}

		public static void ForEach<T>(this IReadOnlyList<T> array, Action<T> action)
		{
			if (array == null) return;

			for (int i = 0; i < array.Count; i++)
			{
				action(array[i]);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Swap<T>(this IList<T> list, int index1, int index2)
		{
			T storage = list[index1];
			list[index1] = list[index2];
			list[index2] = storage;
		}
	}

	public interface IDoubleComparer<in T1, in T2>
	{
		int CompareTo(T1 first, T2 second);
	}

	public struct SingleEnumerator<T> : IEnumerator<T>
	{
		public SingleEnumerator(T value)
		{
			this.value = value;
			state = -1;
		}

		readonly T value;
		int state;

		public bool MoveNext() => ++state < 1;

		public T Current => state == 0 ? value : default;
		object IEnumerator.Current => Current;

		public void Reset() => state = -1;
		public void Dispose() { }
	}
}