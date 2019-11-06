using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeHelpers.Collections
{
	/// <summary>
	/// NOTE: After comparing, the item with the SMALLEST value will be on the top of the heap
	/// NOTE: Please make sure the comparer/comparable ONLY returns 0 if the two sides are identical
	/// (because 0 will be used as the method Equals in Contains)
	/// </summary>
	public class Heap<T> : IEnumerable<T>
	{
		public Heap(IComparer<T> comparer) => this.comparer = comparer;
		public Heap() : this(Comparer<T>.Default) { }

		List<T> items;
		readonly IComparer<T> comparer;

		public int Count => items?.Count ?? 0;

		public void Add(T item)
		{
			if (items == null) items = new List<T>();
			items.Add(item);

			SortUp(Count - 1);
		}

		public T RemoveFirst()
		{
			if (Count == 0) throw new Exception("Cannot remove first item because the heap is empty!");
			T firstItem = items[0];

			Swap(0, Count - 1);
			items.RemoveAt(Count - 1);

			SortDown(0);
			return firstItem;
		}

		public T PeekFirst() => Count > 0 ? items[0] : throw new Exception("Cannot peak first item because the heap is empty!");

		public void Clear() => items.Clear();

		public bool Contains(T item) => GetIndex(item) >= 0;

		public void Recalculate(T item)
		{
			int index = GetIndex(item);
			if (index < 0) throw ExceptionHelper.Invalid(nameof(item), item, "does not exist in this heap!");

			SortDown(index);
			SortUp(index);
		}

		int GetIndex(T item)
		{
			if (Count == 0) return -1;
			return Search(0);

			int Search(int index)
			{
				if (index < 0) return -1;
				int compared = comparer.Compare(items[index], item);

				if (compared == 0) return index;
				if (compared > 0) return -1;

				int search = Search(GetChild1Index(index));
				if (search >= 0) return search;

				return Search(GetChild2Index(index));
			}
		}

		void SortUp(int startingIndex)
		{
			while (true)
			{
				int parentIndex = GetParentIndex(startingIndex);
				if (parentIndex < 0 || comparer.Compare(items[parentIndex], items[startingIndex]) <= 0) break;

				Swap(parentIndex, startingIndex);
				startingIndex = parentIndex;
			}
		}

		void SortDown(int startingIndex)
		{
			while (true)
			{
				int currentIndex = startingIndex;

				int child1Index = GetChild1Index(startingIndex);
				int child2Index = GetChild2Index(startingIndex);

				if (child1Index >= 0 && comparer.Compare(items[child1Index], items[currentIndex]) < 0) currentIndex = child1Index;
				if (child2Index >= 0 && comparer.Compare(items[child2Index], items[currentIndex]) < 0) currentIndex = child2Index;

				if (currentIndex == startingIndex) return;

				Swap(startingIndex, currentIndex);
				startingIndex = currentIndex;
			}
		}

		void Swap(int index1, int index2) => items.Swap(index1, index2);

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

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

		public List<T>.Enumerator GetEnumerator() => items.GetEnumerator();
	}
}