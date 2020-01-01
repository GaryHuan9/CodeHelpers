using System;
using System.Collections.Generic;

namespace CodeHelpers.ObjectPooling
{
	/// <summary>
	/// When the <see cref="PoolerBase{T}.MaxPoolSize"/> is reached, when trying to get a new object,
	/// instead of create a new one, this pool releases the oldest object and returns that one
	/// </summary>
	public abstract class RecyclingPoolBase<T> : PoolerBase<T> where T : class
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

		public override void ReleaseObject(T target) => throw new NotSupportedException($"Cannot manually release an object in {nameof(RecyclingPoolBase<T>)}");
	}
}