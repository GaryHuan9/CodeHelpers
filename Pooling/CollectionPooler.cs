using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeHelpers.ObjectPooling
{
	public static class CollectionPooler<T>
	{
		public static readonly CollectionPoolerBase<List<T>, T> list = new CollectionPoolerBase<List<T>, T>();
		public static readonly CollectionPoolerBase<HashSet<T>, T> hashSet = new CollectionPoolerBase<HashSet<T>, T>();
	}

	public static class CollectionPooler<TKey, TValue>
	{
		public static readonly CollectionPoolerBase<Dictionary<TKey, TValue>, KeyValuePair<TKey, TValue>> dictionary = new CollectionPoolerBase<Dictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>();
	}

	public class CollectionPoolerBase<T, TObject> : PoolerBase<T> where T : class, ICollection<TObject>, new()
	{
		protected override int MaxPoolSize => 6;

		protected override T GetNewObject() => new T();
		protected override void Reset(T target) => target.Clear();
	}
}