using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeHelpers.Collections
{
	/// <summary>
	/// This is a factory class which produces classes that can replace Dictionaries mapping from a Type to some kind of T.
	/// The class will greatly reduce memory and improve speed since it uses an array instead of a dictionary.
	/// Also, the produced class can be inherited to further expand its feature.
	/// NOTE: The magic of this class is that you should store the tokens into static generic classes as a public static int field.
	/// This approach allows us to reduce invocation time to <see cref="Collection.GetObject{T}()"/> approximately in half.
	/// </summary>
	public abstract class TypeCollectionFactory<TBase> : ISealable where TBase : class
	{
		readonly List<IGenerator<TBase>> generators = new List<IGenerator<TBase>>(); //Indexed by type token

		public int Count => generators.Count;

		public bool    IsFactorySealed { get; private set; }
		bool ISealable.IsSealed        => IsFactorySealed;

		public void AddInstantiableType<T>() where T : TBase, new() => AddInstantiableType(() => new T());

		public void AddInstantiableType<T>(Func<T> generator) where T : TBase => AddInstantiableType(new DelegateGenerator<T>(generator));

		public void AddInstantiableType<T>(IGenerator<T> generator) where T : TBase
		{
			int token = GetToken<T>();
			this.AssertNotSealed();

			if (token >= 0) throw ExceptionHelper.Invalid(nameof(T), typeof(T), "has already been added!");

			SetToken<T>(Count);
			generators.Add((IGenerator<TBase>)generator);
		}

		public void AddType<T>() where T : TBase => AddInstantiableType((IGenerator<T>)null);

		/// <summary>
		/// Should return the stored token for given type, <typeparamref name="T"/>.
		/// Returns a negative number if no token was stored for <typeparamref name="T"/>.
		/// </summary>
		protected abstract int GetToken<T>() where T : TBase;

		/// <summary>
		/// Should assign <paramref name="token"/> as the unique identification for type <typeparamref name="T"/>.
		/// This stored value should not be changed through other manners other than this method.
		/// </summary>
		protected abstract void SetToken<T>(int token) where T : TBase;

		public void Seal()
		{
			this.AssertNotSealed();
			IsFactorySealed = true;

			generators.TrimExcess();
		}

		public Collection GetNewCollection()
		{
			this.AssertSealed();
			return new Collection(this);
		}

		public interface IGenerator<out T> where T : TBase
		{
			T Generate();
		}

		public class DelegateGenerator<T> : IGenerator<T> where T : TBase
		{
			public DelegateGenerator(Func<T> generator) => this.generator = generator;

			readonly Func<T> generator;

			public T Generate() => generator();
		}

		//NOTE: We can/should inherit this class!
		public class Collection : IEnumerable<TBase>
		{
			public Collection(TypeCollectionFactory<TBase> factory)
			{
				factory.AssertSealed();
				this.factory = factory;
			}

			readonly TypeCollectionFactory<TBase> factory;

			TBase[] objectsArray; //Initialize as null so no extra allocation

			public int Count => factory.Count;

			protected TBase this[int token]
			{
				get => objectsArray?[token];
				set
				{
					if (objectsArray == null)
					{
						if (value == null) return;
						objectsArray = new TBase[Count];
					}

					objectsArray[token] = value;
				}
			}

			public virtual T GetObject<T>() where T : TBase => (T)this[factory.GetToken<T>()];

			public bool Contains<T>() where T : TBase
			{
				int token = factory.GetToken<T>();
				return token > 0 && this[token] != null;
			}

			public bool TryGetObject<T>(out T value) where T : TBase
			{
				int token = factory.GetToken<T>();
				if (token <= 0)
				{
					value = default;
					return false;
				}

				value = (T)this[token];
				return value != null;
			}

			public void Add<T>(T value) where T : class, TBase
			{
				if (typeof(T) != value.GetType()) throw ExceptionHelper.Invalid(nameof(value), value, "is not passed as the most derived type in its class hierarchy");
				int token = factory.GetToken<T>();

				if (token < 0) throw ExceptionHelper.Invalid(nameof(T), typeof(T), "is not a registered type!");
				if (this[token] != null) throw ExceptionHelper.Invalid(nameof(T), typeof(T), "already exists!");

				this[token] = value;
			}

			/// <summary>
			/// Generate and assign all missing objects into the collection.
			/// NOTE: Only objects with types added through <see cref="AddInstantiableType{T}(System.Func{T})"/>
			/// or <see cref="AddInstantiableType{T}()"/> will be generated. No modification will be done to other objects.
			/// </summary>
			public void InstantiateAll(Action<TBase> action = null)
			{
				for (int i = 0; i < Count; i++)
				{
					IGenerator<TBase> generator = factory.generators[i];
					if (this[i] != null || generator == null) continue;

					TBase newObject = generator.Generate();

					this[i] = newObject;
					action?.Invoke(newObject);
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
				int token = factory.GetToken<T>();

				if (token < 0) throw ExceptionHelper.Invalid(nameof(T), typeof(T), "is not a registered type!");
				if (this[token] != null) throw ExceptionHelper.Invalid(nameof(T), typeof(T), "already exists!");

				IGenerator<TBase> generator = factory.generators[token];

				if (generator == null) throw ExceptionHelper.Invalid(nameof(T), typeof(T), "does not have a generator!");
				if (!(generator is IGenerator<T> castedGenerator)) throw ExceptionHelper.NotPossible;

				return (T)(this[token] = castedGenerator.Generate());
			}

			public bool Remove<T>() where T : TBase
			{
				int token = factory.GetToken<T>();
				if (this[token] == null) return false;

				this[token] = null;
				return true;
			}

			public void Clear() => Array.Clear(objectsArray, 0, Count);

			public IEnumerator<TBase> GetEnumerator()
			{
				for (int i = 0; i < Count; i++)
				{
					TBase value = this[i];
					if (value != null) yield return value;
				}
			}

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}
	}
}