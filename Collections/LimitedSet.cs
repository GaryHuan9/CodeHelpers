using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeHelpers.Collections
{
	//A 256 (byte.MaxCapacity) long collection with O(1) get and set
	//Optimized for enumeration, get and set
	//Use foreach on this collection instead of for and indexing.
	//Its enumerator is highly optimized and enumerates in ascending order.
	public class LimitedSet<T> : IDictionary<byte, T>, IReadOnlyDictionary<byte, T> where T : class
	{
		public LimitedSet()
		{
			items = new T[Capacity];
			startIndex = MaxIndex;
		}

		readonly T[] items;

		byte startIndex;
		byte _count;

		int version;

		const int MaxIndex = byte.MaxValue;
		const int Capacity = MaxIndex + 1;

		public T this[byte key]
		{
			get => items[key] ?? throw new KeyNotFoundException($"Key {key} does not exist!");
			set
			{
				if (value == default) Remove(key);
				else
				{
					if (ContainsKey(key)) Replace(key, value);
					else Add(key, value);
				}
			}
		}

		public int Count
		{
			get => _count;
			set => _count = (byte)value;
		}

		public bool IsReadOnly => false;

		public void Add(KeyValuePair<byte, T> item) => Add(item.Key, item.Value);

		public void Add(byte key, T value)
		{
			if (ContainsKey(key)) throw new ArgumentNullException(nameof(value), "The value/input cannot be default/null!");
			if (value == default) throw new ArgumentNullException($"The value {value} cannot be default/null!");

			Count++;
			Replace(key, value);
		}

		void Replace(byte key, T value)
		{
			IncreaseVersion();

			items[key] = value;
			startIndex = Math.Min(key, startIndex);
		}

		public void Clear()
		{
			startIndex = MaxIndex;

			Count = 0;
			IncreaseVersion();

			Array.Clear(items, 0, Capacity);
		}

		public bool Contains(KeyValuePair<byte, T> item) => ContainsKey(item.Key) && this[item.Key] == item.Value;
		public bool ContainsKey(byte key) => items[key] != default;

		public bool Remove(KeyValuePair<byte, T> item) => Remove(item.Key);

		public bool Remove(byte key)
		{
			if (!ContainsKey(key)) return false;

			if (startIndex == key)
			{
				startIndex = Count != 1 ? FindNextNotNull(startIndex) : (byte)MaxIndex;
			}

			Count--;
			IncreaseVersion();

			items[key] = default;
			return true;
		}

		public bool TryGetValue(byte key, out T value)
		{
			if (ContainsKey(key))
			{
				value = this[key];
				return true;
			}

			value = default;
			return false;
		}

		void IncreaseVersion() => version = unchecked(version + 1);

		public void CopyTo(KeyValuePair<byte, T>[] array, int arrayIndex)
		{
			if (arrayIndex + Count > array.Length) throw new ArgumentException($"The size of {nameof(array)} is smaller than {nameof(arrayIndex)} + this set's size");

			int index = arrayIndex;
			foreach (var pair in this) array[index++] = pair;
		}

		public Enumerator GetEnumerator() => new Enumerator(this);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		IEnumerator<KeyValuePair<byte, T>> IEnumerable<KeyValuePair<byte, T>>.GetEnumerator() => GetEnumerator();

		ICollection<byte> IDictionary<byte, T>.Keys => throw new NotSupportedException("Enumerate the whole collection instead!");
		ICollection<T> IDictionary<byte, T>.Values => throw new NotSupportedException("Enumerate the whole collection instead!");

		IEnumerable<byte> IReadOnlyDictionary<byte, T>.Keys => throw new NotSupportedException("Enumerate the whole collection instead!");
		IEnumerable<T> IReadOnlyDictionary<byte, T>.Values => throw new NotSupportedException("Enumerate the whole collection instead!");

		byte FindNextNotNull(byte current)
		{
			for (int i = current + 1; i < Capacity; i++)
			{
				if (ContainsKey((byte)i)) return (byte)i;
			}

			throw ExceptionHelper.FoundNon;
		}

		public struct Enumerator : IEnumerator<KeyValuePair<byte, T>>
		{
			internal Enumerator(LimitedSet<T> collection)
			{
				this.collection = collection;

				count = 0;
				index = -1;

				version = collection.version;
			}

			readonly LimitedSet<T> collection;

			byte count;
			short index; //AKA key

			readonly int version; //Started version

			object IEnumerator.Current => Current;

			public KeyValuePair<byte, T> Current
			{
				get
				{
					if (index == -1) throw new Exception($"You must invoke MoveNext before getting {nameof(Current)}");
					return new KeyValuePair<byte, T>((byte)index, collection[(byte)index]);
				}
			}

			public bool MoveNext()
			{
				if (version != collection.version) throw new Exception("You should not modify the collection while enumerating it!");
				if (count >= collection.Count) return false;

				index = index == -1 ? collection.startIndex : collection.FindNextNotNull((byte)index);

				count++;
				return true;
			}

			public void Reset()
			{
				count = 0;
				index = -1;
			}

			public void Dispose() { }
		}
	}
}