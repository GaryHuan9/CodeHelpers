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
			if (pool.Count != 0) return base.GetObject();

			if (roaming.Count < MaxPoolSize)
			{
				T target = GetNewObject();
				roaming.Enqueue(target);

				return target;
			}

			base.ReleaseObject(roaming.Dequeue());
			return base.GetObject();
		}

		public override void ReleaseObject(T target) => throw new NotSupportedException($"Cannot manually release an object in {nameof(RecyclingPoolBase<T>)}");
	}
}