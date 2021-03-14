using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeHelpers.Collections
{
	/// <summary>
	/// Priority queue implemented using binary heap
	/// </summary>
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

		public int Capacity
		{
			get => items?.Capacity ?? 0;
			set
			{
				if (value < Count) throw ExceptionHelper.Invalid(nameof(Capacity), value, $"is smaller than {nameof(Count)}, {Count}.");

				if (value == 0)
				{
					items = null;
					priorities = null;
				}
				else
				{
					if (items == null)
					{
						items = new List<T>(value);
						priorities = new List<int>(value);
					}
					else
					{
						items.Capacity = Capacity;
						priorities.Capacity = Capacity;
					}
				}
			}
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
		/// Returns the item with the smallest priority and remove it from the collection.
		/// </summary>
		public T Dequeue() => Dequeue(out int _);

		/// <summary>
		/// <inheritdoc cref="Dequeue()"/>
		/// <paramref name="priority"/> will be assigned the priority of the dequeued item.
		/// </summary>
		public T Dequeue(out int priority)
		{
			if (Count == 0) throw new Exception("Cannot remove the first item because the collection is empty!");

			T firstItem = items[0];
			priority = priorities[0];

			int count = Count - 1; //Need to cache because Count will change when we modify the lists
			Swap(0, count);

			items.RemoveAt(count);
			priorities.RemoveAt(count);

			SortDown(0);
			return firstItem;
		}

		public void Clear()
		{
			if (items == null) return;

			items.Clear();
			priorities.Clear();
		}

		public void TrimExcess()
		{
			items.TrimExcess();
			priorities.TrimExcess();
		}

		/// <summary>
		/// Returns the item with the smallest priority without removing it from the collection.
		/// </summary>
		public T Peek() => Peek(out int _);

		/// <summary>
		/// <inheritdoc cref="Peek()"/>
		/// <paramref name="priority"/> will be assigned the priority of the peeked item.
		/// </summary>
		public T Peek(out int priority)
		{
			if (Count == 0) throw new Exception("Cannot peak the first item because the collection is empty!");

			priority = priorities[0];
			return items[0];
		}

		/// <summary>
		/// Removes an arbitrary <paramref name="item"/> in the heap. Returns whether the operation was successful.
		/// This overload requires more information than <see cref="Remove(T)"/> but is much faster.
		/// </summary>
		public bool Remove(T item, int priority)
		{
			int index = GetIndex(item, priority);
			if (index < 0) return false;

			Remove(index);
			return true;
		}

		/// <summary>
		/// Removes an arbitrary <paramref name="item"/> in the heap. Returns whether the operation was successful.
		/// This overload requires less information than <see cref="Remove(T)"/> but is much slower.
		/// </summary>
		public bool Remove(T item)
		{
			int index = GetIndex(item);
			if (index < 0) return false;

			Remove(index);
			return true;
		}

		void Remove(int index)
		{
			int count = Count - 1; //Need to cache because Count will change when we modify the lists

			if (count == index)
			{
				items.RemoveAt(count);
				priorities.RemoveAt(count);
			}
			else
			{
				Swap(index, count);

				items.RemoveAt(count);
				priorities.RemoveAt(count);

				SortUp(index);
				SortDown(index);
			}
		}

		/// <summary>
		/// Returns if <see cref="item"/> exists in the collection.
		/// This overload requires more information than <see cref="Contains(T)"/> but is much faster.
		/// </summary>
		public bool Contains(T item, int priority) => GetIndex(item, priority) >= 0;

		/// <summary>
		/// Returns if <see cref="item"/> exists in the collection.
		/// This overload requires less information than <see cref="Contains(T,int)"/> but is much slower.
		/// </summary>
		public bool Contains(T item) => GetIndex(item) >= 0;

		/// <summary>
		/// Reassigns <paramref name="item"/> to a new priority.
		/// This overload requires more information than <see cref="Recalculate(T,int)"/> but is much faster.
		/// </summary>
		public void Recalculate(T item, int oldPriority, int newPriority)
		{
			int index = GetIndex(item, oldPriority);
			if (index < 0) throw ExceptionHelper.Invalid(nameof(item), item, "does not exist in this collection!");

			Recalculate(index, newPriority);
		}

		/// <summary>
		/// Reassigns <paramref name="item"/> to a new priority.
		/// This overload requires less information than <see cref="Recalculate(T,int,int)"/> but is much slower.
		/// </summary>
		public void Recalculate(T item, int newPriority)
		{
			int index = GetIndex(item);
			if (index < 0) throw ExceptionHelper.Invalid(nameof(item), item, "does not exist in this collection!");

			Recalculate(index, newPriority);
		}

		void Recalculate(int index, int newPriority)
		{
			priorities[index] = newPriority;

			SortUp(index);
			SortDown(index);
		}

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


		/// <summary>
		/// Faster implementation
		/// </summary>
		int GetIndex(T item, int priority)
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

		static readonly List<T>.Enumerator emptyEnumerator = new List<T>().GetEnumerator(); //Because this is a struct, every time accessing it creates a defensive copy
		public List<T>.Enumerator GetEnumerator() => items?.GetEnumerator() ?? emptyEnumerator;
	}
}