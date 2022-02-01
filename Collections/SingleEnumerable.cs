using System.Collections;
using System.Collections.Generic;

namespace CodeHelpers.Collections
{
	/// <summary>
	/// An <see cref="IEnumerable{T}"/> that only returns one item.
	/// </summary>
	public readonly struct SingleEnumerable<T> : IEnumerable<T>
	{
		public SingleEnumerable(T item) => this.item = item;

		readonly T item;

		public Enumerator GetEnumerator() => new Enumerator(item);

		IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public struct Enumerator : IEnumerator<T>
		{
			public Enumerator(T item)
			{
				this.item = item;
				state = 0;
			}

			readonly T item;
			uint state;

			public bool MoveNext() => ++state < 2;

			public T Current => state == 1 ? item : default;
			object IEnumerator.Current => Current;

			public void Reset() => state = 0;
			public void Dispose() { }
		}
	}
}