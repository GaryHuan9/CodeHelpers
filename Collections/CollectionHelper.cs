using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeHelpers.Collections
{
	public static class CollectionHelper
	{
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
		/// Inserts an item at <paramref name="index"/>; pushes everything back by one.
		/// NOTE: The last item in the array will get removed/replaced!
		/// </summary>
		public static void Insert<T>(this T[] array, int index, T item)
		{
			if (!array.IsIndexValid(index)) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

			for (int i = array.Length - 1; i > index; i--) array[i] = array[i - 1];
			array[index] = item;
		}
	}

	public interface IDoubleComparer<in T1, in T2>
	{
		int CompareTo(T1 first, T2 second);
	}
}