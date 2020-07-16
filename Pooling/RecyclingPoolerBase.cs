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
		readonly Queue<T> roaming = new Queue<T>();

		public override T GetObject()
		{
			T item;
			start:

			if (pool.Count == 0)
			{
				if (roaming.Count < MaxPoolSize) item = GetNewObject();
				else
				{
					base.ReleaseObject(roaming.Dequeue()); //Release the oldest item
					goto start;
				}
			}
			else item = base.GetObject();

			roaming.Enqueue(item);
			return item;
		}

		public override void ReleaseObject(T target) => throw new NotSupportedException($"Cannot manually release an object in {nameof(RecyclingPoolerBase<T>)}");
	}
}