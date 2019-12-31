using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeHelpers.Collections
{
	/// <summary>
	/// Priority implemented using binary tree
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class BinaryHeap<T> : IEnumerable<T>
	{
		public BinaryHeap() => EqualityComparer = EqualityComparer<T>.Default;

		public BinaryHeap(int capacity) : this()
		{
			items = new List<T>(capacity);
			priorities = new List<int>(capacity);
		}

		List<T> items;
		List<int> priorities;

		public IEqualityComparer<T> EqualityComparer { get; set; }

		public int Count => items?.Count ?? 0;

		//NOTE: Returns negative number if index out of bounds
		static int GetParentIndex(int index) => index == 0 ? -1 : (index - 1) / 2;

		//NOTE: Returns negative number if index out of bounds
		int GetChild1Index(int index)
		{
			int result = index * 2 + 1;
			return result >= Count ? -1 : result;
		}

		//NOTE: Returns negative number if index out of bounds
		int GetChild2Index(int index)
		{
			int result = index * 2 + 2;
			return result >= Count ? -1 : result;
		}

		public void Enqueue(T item, int priority)
		{
			if (items == null)
			{
				items = new List<T>();
				priorities = new List<int>();
			}

			items.Add(item);
			priorities.Add(priority);

			SortUp(Count - 1);
		}

		/// <summary>
		/// Returns the item with the smallest priority and remove it from the heap
		/// </summary>
		public T Dequeue()
		{
			if (Count == 0) throw new Exception("Cannot remove the first item because the heap is empty!");
			T firstItem = items[0];

			int count = Count - 1; //Need to cache because Count will change when we modify the lists
			Swap(0, count);

			items.RemoveAt(count);
			priorities.RemoveAt(count);

			SortDown(0);
			return firstItem;
		}

		public void Clear()
		{
			items.Clear();
			priorities.Clear();
		}

		public void TrimExcess()
		{
			items.TrimExcess();
			priorities.TrimExcess();
		}

		/// <summary>
		/// Returns the item with the smallest priority without removing it from the heap
		/// </summary>
		public T Peek() => Count > 0 ? items[0] : throw new Exception("Cannot peak the first item because the heap is empty!");

		public bool Contains(int priority, T item) => GetIndex(priority, item) >= 0;
		public bool Contains(T item) => GetIndex(item) >= 0;

		public void Recalculate(int oldPriority, T item, int newPriority)
		{
			int index = GetIndex(oldPriority, item);
			if (index < 0) throw ExceptionHelper.Invalid(nameof(item), item, "does not exist in this heap!");

			Recalculate(index, newPriority);
		}

		public void Recalculate(T item, int newPriority)
		{
			int index = GetIndex(item);
			if (index < 0) throw ExceptionHelper.Invalid(nameof(item), item, "does not exist in this heap!");

			Recalculate(index, newPriority);
		}

		void Recalculate(int index, int newPriority)
		{
			priorities[index] = newPriority;

			SortUp(index);
			SortDown(index);
		}

		/// <summary>
		/// Faster implementation
		/// </summary>
		int GetIndex(int priority, T item)
		{
			if (Count == 0) return -1;
			return Search(0);

			int Search(int index)
			{
				if (index < 0) return -1;
				int compared = priorities[index].CompareTo(priority);

				if (compared == 0 && EqualityComparer.Equals(items[index], item)) return index;
				if (compared > 0) return -1;

				int search = Search(GetChild1Index(index));
				if (search >= 0) return search;

				return Search(GetChild2Index(index));
			}
		}

		/// <summary>
		/// O(n) implementation
		/// </summary>
		int GetIndex(T item) //The slow version
		{
			for (int i = 0; i < Count; i++)
			{
				if (EqualityComparer.Equals(items[i], item)) return i;
			}

			return -1;
		}

		void SortUp(int startingIndex)
		{
			int parentIndex = GetParentIndex(startingIndex);
			if (parentIndex < 0 || priorities[parentIndex].CompareTo(priorities[startingIndex]) <= 0) return;

			Swap(parentIndex, startingIndex);
			SortUp(parentIndex);
		}

		void SortDown(int startingIndex)
		{
			int currentIndex = startingIndex;

			int child1Index = GetChild1Index(startingIndex);
			int child2Index = GetChild2Index(startingIndex);

			if (child1Index >= 0 && priorities[child1Index].CompareTo(priorities[currentIndex]) < 0) currentIndex = child1Index;
			if (child2Index >= 0 && priorities[child2Index].CompareTo(priorities[currentIndex]) < 0) currentIndex = child2Index;

			if (currentIndex == startingIndex) return;

			Swap(startingIndex, currentIndex);
			SortDown(currentIndex);
		}

		void Swap(int index1, int index2)
		{
			items.Swap(index1, index2);
			priorities.Swap(index1, index2);
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

		static readonly List<T>.Enumerator emptyEnumerator = new List<T>().GetEnumerator(); //Because this is a struct, every time accessing creates a defensive copy
		public List<T>.Enumerator GetEnumerator() => items?.GetEnumerator() ?? emptyEnumerator;

		public readonly struct Pair : IComparable<Pair>
		{
			public Pair(int priority, T item)
			{
				this.priority = priority;
				this.item = item;
			}

			public readonly int priority;
			public readonly T item;

			public int CompareTo(Pair other) => priority.CompareTo(other.priority);

			public static implicit operator KeyValuePair<int, T>(Pair pair) => new KeyValuePair<int, T>(pair.priority, pair.item);
			public static explicit operator Pair(KeyValuePair<int, T> pair) => new Pair(pair.Key, pair.Value);
		}
	}
}