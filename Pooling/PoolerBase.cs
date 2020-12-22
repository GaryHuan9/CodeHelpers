using System;
using System.Collections.Generic;

namespace CodeHelpers.ObjectPooling
{
	public abstract class PoolerBase<T> where T : class
	{
		/// <summary>
		/// Gets the maximum size of the pool/cache.
		/// </summary>
		protected abstract int MaxPoolSize { get; }

		protected readonly Stack<T> pool = new Stack<T>();

		public virtual T GetObject() => pool.Count == 0 ? GetNewObject() : pool.Pop();

		public virtual void ReleaseObject(T target)
		{
			if (pool.Count >= MaxPoolSize) Clear(target);
			else
			{
				Reset(target);
				pool.Push(target);
			}
		}

		/// <summary>
		/// The method is used to get a new object
		/// </summary>
		/// <returns>The new object.</returns>
		protected abstract T GetNewObject();

		/// <summary>
		/// The method that will be resetting the objects.
		/// Invoked right when <see cref="ReleaseObject"/> is invoked.
		/// </summary>
		protected abstract void Reset(T target);

		/// <summary>
		/// Removes the object; clears its memory
		/// </summary>
		protected virtual void Clear(T target)
		{
			if (target is IDisposable disposable) disposable.Dispose();
		}

		public ReleaseHandle<T> Fetch() => new ReleaseHandle<T>(this);
	}

	public struct ReleaseHandle<T> : IDisposable where T : class
	{
		public ReleaseHandle(PoolerBase<T> pooler)
		{
			this.pooler = pooler;
			target = pooler.GetObject();

			disposed = false;
		}

		readonly PoolerBase<T> pooler;
		readonly T target;

		bool disposed;

		public T Target => !disposed ? target : throw new Exception("Pooled object already released!");

		public void Dispose()
		{
			if (disposed) return;

			pooler.ReleaseObject(target);
			disposed = true;
		}

		public static implicit operator T(ReleaseHandle<T> handle) => handle.Target;
	}
}