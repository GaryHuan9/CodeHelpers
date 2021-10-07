using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using CodeHelpers.Diagnostics;
using CodeHelpers.Threads;

namespace CodeHelpers.Collections
{
	/// <summary>
	/// A lockless <see cref="List{T}"/> that supports semi-concurrent read and add operations.
	/// To start adding items to this list, invoke <see cref="BeginAdd"/> first, then invoke
	/// <see cref="Add"/> to append new items to the end of the list. Remember to invoke
	/// <see cref="EndAdd"/> after the adding operations are finished. The state of the list is kept
	/// constant while adding, before <see cref="EndAdd"/> is invoked. Removing is not supported.
	/// </summary>
	public class ConcurrentList<T> : IReadOnlyList<T>
	{
		public ConcurrentList() => arrays = new T[31][];

		readonly T[][] arrays;

		int adding; //Whether we are currently adding; this value indicates the number of layers of begin add that has been invoked
		int next;   //The next index to be added, this is updated after begin add is invoked
		int count;  //The current count of added items, this is updated after end add is invoked

		/// <summary>
		/// Returns the current number of items in this <see cref="ConcurrentList{T}"/>.
		/// </summary>
		public int Count => InterlockedHelper.Read(ref count);

		/// <summary>
		/// Returns a reference to the item at <paramref name="index"/>.
		/// NOTE that you can modify the item through the reference.
		/// </summary>
		public ref T this[int index]
		{
			get
			{
				if ((uint)index < Count) return ref arrays[GetIndex(index, out int offset)][offset];
				throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
		}

		/// <summary>
		/// Adds <paramref name="item"/> to this <see cref="ConcurrentList{T}"/>. This method must only be invoked after
		/// <see cref="BeginAdd"/> is invoked once and before the equivalent amount of <see cref="EndAdd"/> is invoked.
		/// </summary>
		public void Add(T item)
		{
			if (InterlockedHelper.Read(ref adding) <= 0) throw new Exception($"Cannot invoke {nameof(Add)} before invoking {nameof(BeginAdd)}!");

			int target = Interlocked.Increment(ref next) - 1;
			int index = GetIndex(target, out int offset);

			ref T[] array = ref arrays[index];

			if (array == null) Interlocked.CompareExchange(ref array, new T [1 << index], null);

			Assert.IsFalse(array == null);
			array[offset] = item;
		}

		/// <summary>
		/// Invokes <see cref="Add"/> on every item in <paramref name="items"/>.
		/// </summary>
		public void AddRange(IEnumerable<T> items)
		{
			foreach (T item in items) Add(item);
		}

		/// <summary>
		/// Begins allowing invocations to the <see cref="Add"/> method. This method returns a <see cref="AddHandle"/>,
		/// which allows you to use using statements or expressions to automatically invoke <see cref="EndAdd"/>
		/// after the scope exits. NOTE: supports nested invocations.
		/// </summary>
		public AddHandle BeginAdd()
		{
			Interlocked.Increment(ref adding);
			return new AddHandle(this);
		}

		/// <summary>
		/// Concludes allowing invocations to the <see cref="Add"/> method. NOTE: supports nested invocations.
		/// </summary>
		public void EndAdd()
		{
			int value = Interlocked.Decrement(ref adding);

			if (value < 0) throw new Exception($"Cannot invoke {nameof(EndAdd)} before invoking {nameof(BeginAdd)}!");
			if (value == 0) Interlocked.Exchange(ref count, InterlockedHelper.Read(ref next));
		}

		public Enumerator GetEnumerator() => new Enumerator(this);

		T IReadOnlyList<T>.this[int index] => this[index];

		IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public static int GetIndex(int index, out int offset)
		{
			++index;
#if !NET5_0 || NETCOREAPP3_0
			int log = BitOperations.Log2((uint)index);
#else
			const double InverseLn2 = 1d / 0.69314718056d;
			int log = (int)(Math.Log(index) * InverseLn2);
#endif
			offset = index & ~(1 << log);
			return log;
		}

		public struct AddHandle : IDisposable
		{
			public AddHandle(ConcurrentList<T> list)
			{
				this.list = list;
				disposed = false;
			}

			readonly ConcurrentList<T> list;

			bool disposed;

			public void Dispose()
			{
				if (disposed) return;

				list.EndAdd();
				disposed = true;
			}
		}

		public struct Enumerator : IEnumerator<T>
		{
			public Enumerator(ConcurrentList<T> list)
			{
				Current = default;
				this.list = list;
				index = -1;
			}

			public T Current { get; private set; }
			readonly ConcurrentList<T> list;
			int index;

			object IEnumerator.Current => Current;

			public bool MoveNext()
			{
				int count = list.Count;

				if (index < count) Current = ++index == count ? default : list[index];

				return index < count;
			}

			public void Reset()
			{
				Current = default;
				index = -1;
			}

			public void Dispose() { }
		}
	}
}