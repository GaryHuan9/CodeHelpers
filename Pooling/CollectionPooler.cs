using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeHelpers.ObjectPooling
{
	public static class CollectionPooler<T>
	{
		public static readonly CollectionPoolerBase<List<T>, T> list = new CollectionPoolerBase<List<T>, T>();
	}

	public class CollectionPoolerBase<T, TObject> : PoolerBase<T> where T : class, ICollection<TObject>, new()
	{
		protected override int MaxPoolSize => 6;

		protected override T GetNewObject() => new T();
		protected override void Reset(T target) => target.Clear();
	}
}