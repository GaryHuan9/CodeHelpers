using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace CodeHelpers.Collections
{
	//NOTE: static

	public static class TypeDictionary<TValue>
	{
		public static TValue Get<TKey>() => Container<TKey>.value;
		public static void Set<TKey>(TValue value) => Container<TKey>.value = value;

		static class Container<TKey>
		{
			public static TValue value;
		}
	}

	public static class TypeDictionary<TValue, TUnique>
	{
		public static TValue Get<TKey>() => Container<TKey>.value;
		public static void Set<TKey>(TValue value) => Container<TKey>.value = value;

		static class Container<TKey>
		{
			public static TValue value;
		}
	}
}
