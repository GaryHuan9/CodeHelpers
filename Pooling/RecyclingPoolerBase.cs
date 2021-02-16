using System;
using System.Collections.Generic;

namespace CodeHelpers.ObjectPooling
{
	/// <summary>
	/// Objects in this pooler never needs to be manually released. When trying to get a new object and there are
	/// less than <see cref="PoolerBase{T}.MaxPoolSize"/> objects, new object are created. But if that limit is reached,
	/// instead of creating new objects the pooler will recycle the roaming objects by releasing and reuse them.
	/// </summary>
	public abstract class RecyclingPoolerBase<T> : PoolerBase<T> where T : class
	{
		protected readonly Queue<T> roaming = new Queue<T>();

		public override T GetObject()
		{
			while (pool.Count == 0)
			{
				if (roaming.Count < MaxPoolSize) pool.Push(GetNewObject());
				else ReleaseObject(roaming.Dequeue()); //Release the oldest item
			}

			T item = base.GetObject();
			roaming.Enqueue(item);

			return item;
		}
	}
}