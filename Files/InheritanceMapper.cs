using System;
using System.Collections.Generic;
using System.Threading;
using CodeHelpers.Collections;
using CodeHelpers.Diagnostics;

namespace CodeHelpers.Files
{
	/// <summary>
	/// NOTE: This class is thread safe
	/// </summary>
	public class InheritanceMapper : IDisposable
	{
		readonly Dictionary<Type, Mapper> mappers = new Dictionary<Type, Mapper>();
		readonly ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

		/// <summary>
		/// Returns a unique token that indicates an inheritance from <paramref name="derivedType"/> to <paramref name="baseType"/>.
		/// If a token did not exist before, a new one will be created and returned. NOTE: The same <paramref name="derivedType"/> can
		/// map to different <paramref name="baseType"/> with a separate set of tokens.
		/// </summary>
		public uint GetToken(Type derivedType, Type baseType)
		{
			Assert.IsTrue(baseType.IsAssignableFrom(derivedType));

			//The way we are locking this method might make the lock inside Mapper redundant
			//However, I am too tired to think about the logic of improving this lock

			locker.EnterWriteLock();
			try
			{
				if (!mappers.TryGetValue(baseType, out Mapper mapper))
				{
					mapper = new Mapper();
					mappers.Add(baseType, mapper);
				}

				return mapper[derivedType];
			}
			finally { locker.ExitWriteLock(); }
		}

		/// <summary>
		/// Returns the derived type from a specific <paramref name="baseType"/> and a <paramref name="token"/> generated from <see cref="GetToken"/>.
		/// NOTE: An exception will be thrown if the <paramref name="token"/> and the <paramref name="baseType"/> pair is not recognized!
		/// </summary>
		public Type GetDerivedType(uint token, Type baseType)
		{
			locker.EnterReadLock();
			try
			{
				if (mappers.TryGetValue(baseType, out Mapper mapper))
				{
					Type type = mapper[token];
					if (type != null) return type;

					throw ExceptionHelper.Invalid(nameof(token), token, InvalidType.unexpectedIdentification);
				}

				throw ExceptionHelper.Invalid(nameof(baseType), baseType, InvalidType.unexpected);
			}
			finally { locker.ExitReadLock(); }
		}

		public void Dispose()
		{
			locker.Dispose();
			foreach (var pair in mappers) pair.Value.Dispose();
		}

		public void Write(DataWriter writer, ITypeSerializer serializer)
		{
			locker.EnterReadLock();
			try
			{
				writer.WriteCompact(0); //Version
				writer.WriteCompact(mappers.Count);

				foreach (var pair in mappers)
				{
					serializer.Write(writer, pair.Key);
					pair.Value.Write(writer, serializer);
				}
			}
			finally { locker.ExitReadLock(); }
		}

		/// <summary>
		/// Replaces the old data and recreates the <see cref="InheritanceMapper"/> from the read in data.
		/// </summary>
		public void Read(DataReader reader, ITypeSerializer serializer)
		{
			locker.EnterWriteLock();
			try
			{
				mappers.Clear();

				int version = reader.ReadInt32Compact();
				int count = reader.ReadInt32Compact();

				for (int i = 0; i < count; i++)
				{
					Type baseType = serializer.Read(reader);
					Mapper mapper = Mapper.Read(reader, serializer);

					mappers.Add(baseType, mapper);
				}
			}
			finally { locker.ExitWriteLock(); }
		}

		class Mapper : IDisposable
		{
			readonly List<Type> derivedTypes = new List<Type>(); //The type at index i have token of i
			readonly Dictionary<Type, uint> tokens = new Dictionary<Type, uint>();

			readonly ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

			public Type this[uint token]
			{
				get
				{
					locker.EnterReadLock();
					try { return derivedTypes.TryGetValue((int)token); }
					finally { locker.ExitReadLock(); }
				}
			}

			public uint this[Type type]
			{
				get
				{
					locker.EnterUpgradeableReadLock();
					try
					{
						if (tokens.TryGetValue(type, out uint token)) return token;

						token = (uint)derivedTypes.Count;

						locker.EnterWriteLock();
						try
						{
							tokens.Add(type, token);
							derivedTypes.Add(type);

							return token;
						}
						finally { locker.ExitWriteLock(); }
					}
					finally { locker.ExitUpgradeableReadLock(); }
				}
			}

			public void Dispose() => locker.Dispose();

			public void Write(DataWriter writer, ITypeSerializer serializer)
			{
				locker.EnterReadLock();
				try
				{
					int count = derivedTypes.Count;
					writer.WriteCompact(count);

					for (int i = 0; i < count; i++) serializer.Write(writer, derivedTypes[i]);
				}
				finally { locker.ExitReadLock(); }
			}

			public static Mapper Read(DataReader reader, ITypeSerializer serializer)
			{
				Mapper mapper = new Mapper();

				int count = reader.ReadInt32Compact();
				mapper.derivedTypes.Capacity = count;

				for (uint i = 0; i < count; i++)
				{
					Type type = serializer.Read(reader);

					mapper.tokens.Add(type, i);
					mapper.derivedTypes.Add(type);
				}

				return mapper;
			}
		}
	}
}