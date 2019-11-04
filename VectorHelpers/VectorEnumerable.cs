using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeHelpers.VectorHelpers
{
	public static class VectorEnumerable
	{
		/// <summary>
		/// Returns an enumerable that can be put into a foreach loop; from (0,0) to (vector.x-1,vector.y-1)
		/// If <paramref name="zeroAsOne"/> is true then the loop will treat zeros in the vector as ones.
		/// </summary>
		public static Vector2Enumerable Loop(this Vector2Int vector, bool zeroAsOne = false) => new Vector2Enumerable(vector, zeroAsOne);

		/// <summary>
		/// Returns an enumerable that can be put into a foreach loop; from (0,0,0) to (vector.x-1,vector.y-1,vector.z-1)
		/// If <paramref name="zeroAsOne"/> is true then the loop will treat zeros in the vector as ones.
		/// </summary>
		public static Vector3Enumerable Loop(this Vector3Int vector, bool zeroAsOne = false) => new Vector3Enumerable(vector, zeroAsOne);

		public readonly struct Vector2Enumerable : IEnumerable<Vector2Int>
		{
			internal Vector2Enumerable(Vector2Int vector, bool zeroAsOne) => enumerator = new Enumerator(vector, zeroAsOne);

			readonly Enumerator enumerator;

			public Enumerator GetEnumerator() => enumerator;

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			IEnumerator<Vector2Int> IEnumerable<Vector2Int>.GetEnumerator() => GetEnumerator();

			public struct Enumerator : IEnumerator<Vector2Int>
			{
				internal Enumerator(Vector2Int size, bool zeroAsOne)
				{
					this.size = zeroAsOne ? Vector2Int.Max(Vector2Int.one, size.Abs()) : size.Abs();
					direction = size.IndividualNormalize();
					current = -1;
				}

				readonly Vector2Int size;
				readonly Vector2Int direction;

				int current;

				object IEnumerator.Current => Current;
				public Vector2Int Current => Vector2Int.Scale(new Vector2Int(current / size.y, current % size.y), direction);

				public bool MoveNext()
				{
					if (current + 1 >= size.Size()) return false;
					current++;
					return true;
				}

				public void Reset() => current = -1;

				public void Dispose() { }
			}
		}

		public readonly struct Vector3Enumerable : IEnumerable<Vector3Int>
		{
			internal Vector3Enumerable(Vector3Int vector, bool zeroAsOne) => enumerator = new Enumerator(vector, zeroAsOne);

			readonly Enumerator enumerator;

			public Enumerator GetEnumerator() => enumerator;

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			IEnumerator<Vector3Int> IEnumerable<Vector3Int>.GetEnumerator() => GetEnumerator();

			public struct Enumerator : IEnumerator<Vector3Int>
			{
				internal Enumerator(Vector3Int size, bool zeroAsOne)
				{
					this.size = zeroAsOne ? Vector3Int.Max(Vector3Int.one, size.Abs()) : size.Abs();
					direction = size.IndividualNormalize();
					current = -1;
				}

				readonly Vector3Int size;
				readonly Vector3Int direction;

				int current;

				object IEnumerator.Current => Current;
				public Vector3Int Current => Vector3Int.Scale(new Vector3Int(current / (size.y * size.z), current / size.z % size.y, current % size.z), direction);

				public bool MoveNext()
				{
					if (current + 1 >= size.Size()) return false;
					current++;
					return true;
				}

				public void Reset() => current = -1;

				public void Dispose() { }
			}
		}

	}
}