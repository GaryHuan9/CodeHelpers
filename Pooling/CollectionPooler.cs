using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeHelpers.ObjectPooling
{
	public static class CollectionPooler
	{
		
	}

	public class CollectionPoolerBase<T, TObject> : PoolerBase<T> where T : class, ICollection<TObject>, new()
	{
		protected override int MaxPoolSize => 16;
		protected override void Reset(T target) => target.Clear();
	}
}
