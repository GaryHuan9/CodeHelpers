using System.Collections.Generic;

namespace CodeHelpers.Collections
{
	public class UniqueQueue<T> : Queue<T>
	{
		public UniqueQueue()
		{
			items = new HashSet<T>();
		}

		readonly HashSet<T> items;

		public new bool Contains(T item) => items.Contains(item);

		public new void Enqueue(T item)
		{
			if (items.Add(item)) base.Enqueue(item);
		}

		public new T Dequeue()
		{
			T item = base.Dequeue();
			items.Remove(item);

			return item;
		}
	}
}