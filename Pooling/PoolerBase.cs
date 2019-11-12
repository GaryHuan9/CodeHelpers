using System;
using System.Collections.Generic;

namespace CodeHelpers.ObjectPooling
{
	public abstract class PoolerBase<T> where T : class, new()
	{
		/// <summary>
		/// Gets the maximum size of the pool/cache.
		/// </summary>
		protected abstract int MaxPoolSize { get; }

		protected readonly Stack<T> pool = new Stack<T>();

		public T GetObject()
		{
			T target = pool.Count == 0 ? GetNewObject() : pool.Pop();
			Reset(target);
			return target;
		}

		/// <summary>
		/// The method used to get a new/fresh object
		/// </summary>
		/// <returns>The new object.</returns>
		protected virtual T GetNewObject() => new T();

		/// <summary>
		/// The method that will be resetting the objects.
		/// Invoked BEFORE each GetObject returns.
		/// </summary>
		protected abstract void Reset(T target);

		public virtual void ReleaseObject(T target)
		{
			if (pool.Count < MaxPoolSize) pool.Push(target);
			if (target is IDisposable disposable) disposable.Dispose();
		}
	}
}
