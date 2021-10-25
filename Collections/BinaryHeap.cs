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
		public BinaryHeap(int capacity)
		{
			items = new List<T>(capacity);
			priorities = new List<int>(capacity);
		}

		public BinaryHeap() { }

		List<T> items;
		List<int> priorities;

		public IEqualityComparer<T> EqualityComparer { get; set; } = EqualityComparer<T>.Default;

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
		/// <inheritdoc cref="TryPeek(out T)"/>
		/// Throws an exception if this <see cref="BinaryHeap{T}"/> is empty.
		/// </summary>
		public T Peek()
		{
			if (Count > 0) return TryPeek(out T item) ? item : default;
			throw new Exception("Cannot peak the first item because the collection is empty!");
		}

		/// <summary>
		/// <inheritdoc cref="TryPeek(out T, out int)"/>
		/// Throws an exception if this <see cref="BinaryHeap{T}"/> is empty.
		/// </summary>
		public T Peek(out int priority)
		{
			if (Count > 0) return TryPeek(out T item, out priority) ? item : default;
			throw new Exception("Cannot peak the first item because the collection is empty!");
		}

		/// <summary>
		/// Tries to peek at the first item in this <see cref="BinaryHeap{T}"/>, which is the
		/// item with the smallest assigned priority, and output it to <paramref name="item"/>.
		/// </summary>
		public bool TryPeek(out T item)
		{
			if (Count == 0)
			{
				item = default;
				return false;
			}

			item = items[0];
			return true;
		}

		/// <summary>
		/// <inheritdoc cref="TryPeek(out T)"/>
		/// <paramref name="priority"/> will be assigned the priority of the peeked item.
		/// </summary>
		public bool TryPeek(out T item, out int priority)
		{
			if (Count == 0)
			{
				item = default;
				priority = default;

				return false;
			}

			item = items[0];
			priority = priorities[0];

			return true;
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

		/// <summary>
		/// Tries to find the first item with <paramref name="priority"/> outputs it to <paramref name="item"/>.
		/// NOTE: the order of the items are not guaranteed! The first item this method finds is returned.
		/// </summary>
		public bool TryFind(int priority, out T item)
		{
			int index = GetIndex(priority);

			if (index < 0)
			{
				item = default;
				return false;
			}

			item = items[index];
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

		void Recalculate(int index, int newPriority)
		{
			priorities[index] = newPriority;

			SortUp(index);
			SortDown(index);
		}

		/// <summary>
		/// Returns the index of the parent of the child at <paramref name="index"/>.
		/// Returns negative number if the requested parent index is out of bounds.
		/// </summary>
		static int GetParentIndex(int index) => index == 0 ? -1 : (index - 1) / 2;

		/// <summary>
		/// Returns the index of the left child of the parent at <paramref name="index"/>.
		/// Returns negative number if the requested child index is out of bounds.
		/// </summary>
		int GetChildLeftIndex(int index)
		{
			int result = index * 2 + 1;
			return result >= Count ? -1 : result;
		}

		/// <summary>
		/// Returns the index of the right child of the parent at <paramref name="index"/>.
		/// Returns negative number if the requested child index is out of bounds.
		/// </summary>
		int GetChildRightIndex(int index)
		{
			int result = index * 2 + 2;
			return result >= Count ? -1 : result;
		}

		/// <summary>
		/// Returns the index of <paramref name="item"/> with <paramref name="priority"/> in O(log n) time.
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

				int search = Search(GetChildLeftIndex(index));
				if (search >= 0) return search;

				return Search(GetChildRightIndex(index));
			}
		}

		/// <summary>
		/// Returns the index of the first <see cref="T"/> with <paramref name="priority"/> in O(log n) time.
		/// </summary>
		int GetIndex(int priority)
		{
			if (Count == 0) return -1;
			return Search(0);

			int Search(int index)
			{
				if (index < 0) return -1;
				int compared = priorities[index].CompareTo(priority);

				if (compared == 0) return index;
				if (compared > 0) return -1;

				int search = Search(GetChildLeftIndex(index));
				if (search >= 0) return search;

				return Search(GetChildRightIndex(index));
			}
		}

		/// <summary>
		/// Returns the index of the first <paramref name="item"/> in O(n) time.
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

			int child1Index = GetChildLeftIndex(startingIndex);
			int child2Index = GetChildRightIndex(startingIndex);

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

		IEnumerator IEnumerable.      GetEnumerator() => GetEnumerator();
		IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

		static readonly List<T>.Enumerator emptyEnumerator = new List<T>().GetEnumerator(); //Because this is a struct, every time accessing it creates a defensive copy
		public List<T>.Enumerator GetEnumerator() => items?.GetEnumerator() ?? emptyEnumerator;
	}
}