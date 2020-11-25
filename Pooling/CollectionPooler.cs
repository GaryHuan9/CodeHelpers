using System.Collections.Generic;

namespace CodeHelpers.ObjectPooling
{
	public static class CollectionPooler<T>
	{
		public static readonly CollectionPoolerBase<List<T>, T> list = new CollectionPoolerBase<List<T>, T>();
		public static readonly CollectionPoolerBase<HashSet<T>, T> hashSet = new CollectionPoolerBase<HashSet<T>, T>();

		public static readonly QueuePoolerBase<Queue<T>, T> queue = new QueuePoolerBase<Queue<T>, T>();
		public static readonly StackPoolerBase<Stack<T>, T> stack = new StackPoolerBase<Stack<T>, T>();
	}

	public static class CollectionPooler<TKey, TValue>
	{
		public static readonly CollectionPoolerBase<Dictionary<TKey, TValue>, KeyValuePair<TKey, TValue>> dictionary = new CollectionPoolerBase<Dictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>();
	}

	public class CollectionPoolerBase<T, TObject> : PoolerBase<T> where T : class, ICollection<TObject>, new()
	{
		public CollectionPoolerBase(int maxPoolSize = 6) => MaxPoolSize = maxPoolSize;

		protected override int MaxPoolSize { get; }

		protected override T GetNewObject() => new T();
		protected override void Reset(T target) => target.Clear();
	}

	public class QueuePoolerBase<T, TObject> : PoolerBase<T> where T : Queue<TObject>, new()
	{
		public QueuePoolerBase(int maxPoolSize = 6) => MaxPoolSize = maxPoolSize;

		protected override int MaxPoolSize { get; }

		protected override T GetNewObject() => new T();
		protected override void Reset(T target) => target.Clear();
	}

	public class StackPoolerBase<T, TObject> : PoolerBase<T> where T : Stack<TObject>, new()
	{
		public StackPoolerBase(int maxPoolSize = 6) => MaxPoolSize = maxPoolSize;

		protected override int MaxPoolSize { get; }

		protected override T GetNewObject() => new T();
		protected override void Reset(T target) => target.Clear();
	}
}