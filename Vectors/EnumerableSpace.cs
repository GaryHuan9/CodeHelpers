using System.Collections;
using System.Collections.Generic;
using CodeHelpers;
using CodeHelpers.Vectors;
using UnityEngine;

namespace CodeHelpers.Vectors
{
	public readonly struct EnumerableSpace3D : IEnumerable<Vector3Int>
	{
		/// <summary>
		/// Creates a foreach-loop compatible IEnumerable which yields all position/vector inside a 3D rectangular space
		/// starts at <paramref name="from"/> and ends at <paramref name="to"/> (Both inclusive). 
		/// </summary>
		public EnumerableSpace3D(Vector3Int from, Vector3Int to) => enumerator = new Enumerator(from, to);

		readonly Enumerator enumerator;

		public Enumerator GetEnumerator() => enumerator;

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		IEnumerator<Vector3Int> IEnumerable<Vector3Int>.GetEnumerator() => GetEnumerator();

		public struct Enumerator : IEnumerator<Vector3Int>
		{
			internal Enumerator(Vector3Int from, Vector3Int to)
			{
				offset = from;

				var difference = to - from; //Make inclusive
				difference += difference.IndividualNormalized();

				enumerator = new VectorEnumerable.Vector3Enumerable.Enumerator(difference, true);
			}

			readonly Vector3Int offset;
			VectorEnumerable.Vector3Enumerable.Enumerator enumerator;

			object IEnumerator.Current => Current;
			public Vector3Int Current => enumerator.Current + offset;

			public bool MoveNext() => enumerator.MoveNext();

			public void Reset() => enumerator.Reset();
			public void Dispose() => enumerator.Dispose();
		}
	}

	public readonly struct EnumerableSpace2D : IEnumerable<Vector2Int>
	{
		/// <summary>
		/// Creates a foreach-loop compatible IEnumerable which yields all position/vector inside a 2D rectangular space
		/// starts at <paramref name="from"/> and ends at <paramref name="to"/> (Both inclusive). 
		/// </summary>
		public EnumerableSpace2D(Vector2Int from, Vector2Int to) => enumerator = new Enumerator(from, to);

		readonly Enumerator enumerator;

		public Enumerator GetEnumerator() => enumerator;

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		IEnumerator<Vector2Int> IEnumerable<Vector2Int>.GetEnumerator() => GetEnumerator();

		public struct Enumerator : IEnumerator<Vector2Int>
		{
			internal Enumerator(Vector2Int from, Vector2Int to)
			{
				offset = from;

				var difference = to - from; //Make inclusive
				difference += difference.IndividualNormalized();

				enumerator = new VectorEnumerable.Vector2Enumerable.Enumerator(difference, true);
			}

			readonly Vector2Int offset;
			VectorEnumerable.Vector2Enumerable.Enumerator enumerator;

			object IEnumerator.Current => Current;
			public Vector2Int Current => enumerator.Current + offset;

			public bool MoveNext() => enumerator.MoveNext();

			public void Reset() => enumerator.Reset();
			public void Dispose() => enumerator.Dispose();
		}
	}
}