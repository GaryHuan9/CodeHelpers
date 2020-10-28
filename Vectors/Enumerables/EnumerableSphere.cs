using System.Collections;
using System.Collections.Generic;

namespace CodeHelpers.Vectors.Enumerables
{
	public readonly struct EnumerableSphere3D : IEnumerable<Int3>
	{
		/// <summary>
		/// Creates a foreach-loop compatible IEnumerable which yields all position on a 3D sphere.
		/// </summary>
		public EnumerableSphere3D(Int3 center, float radius) => enumerator = new Enumerator(center, radius);

		readonly Enumerator enumerator;

		public Enumerator GetEnumerator() => enumerator;

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		IEnumerator<Int3> IEnumerable<Int3>.GetEnumerator() => GetEnumerator();

		public struct Enumerator : IEnumerator<Int3>
		{
			public Enumerator(Int3 center, float radius) : this() { }

			object IEnumerator.Current => Current;
			public Int3 Current { get; }

			public bool MoveNext() => throw new System.NotImplementedException();

			public void Reset() { }
			public void Dispose() { }
		}
	}

	public readonly struct EnumerableSphere2D : IEnumerable<Int2>
	{
		/// <summary>
		/// Creates a foreach-loop compatible IEnumerable which yields all position in a 2D sphere (aka circle but whatever).
		/// starts at <paramref name="from"/> and ends at <paramref name="to"/> (Both inclusive).
		/// </summary>
		public EnumerableSphere2D(Int2 center, float radius) => enumerator = new Enumerator(center, radius);

		readonly Enumerator enumerator;

		public Enumerator GetEnumerator() => enumerator;

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		IEnumerator<Int2> IEnumerable<Int2>.GetEnumerator() => GetEnumerator();

		public struct Enumerator : IEnumerator<Int2>
		{
			public Enumerator(Int2 center, float radius) : this() { }

			object IEnumerator.Current => Current;
			public Int2 Current { get; }

			public bool MoveNext() => throw new System.NotImplementedException();

			public void Reset() { }
			public void Dispose() { }
		}
	}
}