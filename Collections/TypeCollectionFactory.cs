using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace CodeHelpers.Collections
{
	/// <summary>
	/// This is a factory class which produces classes that can replace Dictionaries mapping from a Type to some kind of T.
	/// The class will greatly reduce memory since it uses an array instead of a dictionary.
	/// Also, the produced class can be inherited to further expand its feature.
	/// </summary>
	public class TypeCollectionFactory<TBase> where TBase : class
	{
		//Maps a type object to an id. This id should be from 0 to count, with no empty ids in between.
		readonly Dictionary<Type, int> typeToId = new Dictionary<Type, int>();
		readonly List<Func<TBase>> idToFactory = new List<Func<TBase>>(); //Factory for different kinds of objects
		Type[] idToType;

		public bool IsFactorySealed { get; private set; }

		static readonly Exception alreadySealedException = new Exception("Factory already sealed!");
		static readonly Exception sealBeforeCollectionException = new Exception("Need to seal the factory before getting new collection!");

		void AddType(Type type)
		{
			CheckSealed();
			typeToId.Add(type, typeToId.Count);
		}

		public void AddInstantiableType<T>(Func<T> factory) where T : class, TBase
		{
			AddType(typeof(T));
			idToFactory.Add(factory);
		}

		public void AddInstantiableType<T>() where T : class, TBase, new() => AddInstantiableType(() => new T());

		public void AddType<T>() where T : TBase
		{
			AddType(typeof(T));
			idToFactory.Add(null); //Add null to keep the match between id and factory
		}

		public void Seal()
		{
			CheckSealed();
			IsFactorySealed = true;

			idToType = new Type[typeToId.Count];
			foreach (var pair in typeToId) idToType[pair.Value] = pair.Key;

			Assert.AreEqual(typeToId.Count, idToType.Length);
			idToFactory.TrimExcess();
		}

		public Collection GetNewCollection()
		{
			if (IsFactorySealed) return new Collection(this);
			throw sealBeforeCollectionException;
		}

		int GetId(Type type)
		{
			if (typeToId.TryGetValue(type, out int id)) return id;
			throw ExceptionHelper.Invalid(nameof(type), type, InvalidType.unexpected);
		}

		void CheckSealed()
		{
			if (IsFactorySealed) throw alreadySealedException;
		}

		//NOTE: We can/should inherit this class!
		public class Collection : IDictionary<Type, TBase>
		{
			public Collection(TypeCollectionFactory<TBase> factory)
			{
				if (!factory.IsFactorySealed) throw sealBeforeCollectionException;
				this.factory = factory;
			}

			readonly TypeCollectionFactory<TBase> factory;
			TBase[] typeObjects; //Initialize as null so no extra allocation

			public int Count => factory.typeToId.Count;
			public bool IsReadOnly => false;

			public TBase this[Type type]
			{
				get => this[factory.GetId(type)];
				set => this[factory.GetId(type)] = value;
			}

			protected TBase this[int id]
			{
				get => typeObjects?[id];
				set
				{
					if (typeObjects == null && value == null) return;
					(typeObjects ?? (typeObjects = new TBase[Count]))[id] = value;
				}
			}

			public T GetObject<T>() where T : TBase => (T)GetObject(typeof(T));
			public TBase GetObject(Type type) => this[type];

			public void Add(Type key, TBase value)
			{
				if (this[key] == null) this[key] = value;
				else throw ExceptionHelper.Invalid(nameof(key), key, "already exists!");
			}

			public void Add<T>(T item) where T : class, TBase => Add(item.GetType(), item);
			public void Add(KeyValuePair<Type, TBase> item) => Add(item.Key, item.Value);

			/// <summary>
			/// Create and assign all missing objects into the collection.
			/// NOTE: Only creates object types added through <see cref="TypeCollectionFactory{TBase}.AddInstantiableType{T}(System.Func{T})"/> or <see cref="TypeCollectionFactory{TBase}.AddInstantiableType{T}()"/>
			/// The method will invoke <paramref name="action"/> when a new object gets created, but you can leave at null.
			/// </summary>
			public void InstantiatedAll(Action<TBase> action = null)
			{
				for (int i = 0; i < Count; i++)
				{
					if (this[i] != null || factory.idToFactory[i] == null) continue;

					var newObject = factory.idToFactory[i]();
					action?.Invoke(newObject);

					this[i] = newObject;
				}
			}

			/// <summary>
			/// Instantiate a new <typeparam name="T"></typeparam> using the factories while also adding it to the collection.
			/// If an object is already occupying the space, we will simply return that object.
			/// If did not specify a factory for <typeparam name="T"></typeparam>, exception is raised.
			/// Returns the instantiated object.
			/// </summary>
			public T InstantiateNew<T>() where T : class, TBase
			{
				int id = factory.GetId(typeof(T));
				var newObject = this[id];

				if (newObject == null)
				{
					if (factory.idToFactory[id] == null) throw new Exception($"Did not specify factory for {typeof(T)}");

					newObject = factory.idToFactory[id]();
					Add(newObject);
				}

				return (T)newObject;
			}

			public bool ContainsKey(Type key) => this[key] != null;
			public bool Contains(KeyValuePair<Type, TBase> item) => ContainsKey(item.Key);

			public bool Remove(Type key)
			{
				if (this[key] == null) return false;

				this[key] = null;
				return true;
			}

			public bool Remove<T>() where T : TBase => Remove(typeof(T));
			public bool Remove(KeyValuePair<Type, TBase> item) => Remove(item.Key);

			public void Clear() => Array.Clear(typeObjects, 0, Count);

			public bool TryGetValue(Type key, out TBase value)
			{
				value = this[key];
				return ContainsKey(key);
			}

			IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<KeyValuePair<Type, TBase>>)this).GetEnumerator();

			IEnumerator<KeyValuePair<Type, TBase>> IEnumerable<KeyValuePair<Type, TBase>>.GetEnumerator()
			{
				for (int i = 0; i < Count; i++)
				{
					Type type = factory.idToType[i];
					yield return new KeyValuePair<Type, TBase>(type, this[type]);
				}
			}

			void ICollection<KeyValuePair<Type, TBase>>.CopyTo(KeyValuePair<Type, TBase>[] array, int arrayIndex) => throw new NotSupportedException();

			ICollection<Type> IDictionary<Type, TBase>.Keys => throw new NotSupportedException();
			ICollection<TBase> IDictionary<Type, TBase>.Values => throw new NotSupportedException();
		}
	}
}