using System;
using System.Collections.Generic;
using System.Threading;
using CodeHelpers.Collections;

namespace CodeHelpers.Files
{
	public class TypeMapper : IDisposable
	{
		readonly List<Type> types = new List<Type>(); //The token of the type is the same as its index
		readonly Dictionary<Type, uint> tokens = new Dictionary<Type, uint>();

		readonly ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

		public Type this[uint token]
		{
			get
			{
				locker.EnterReadLock();
				try { return types.TryGetValue((int)token); }
				finally { locker.ExitReadLock(); }
			}
		}

		public uint this[Type type]
		{
			get
			{
				locker.EnterReadLock();
				try
				{
					if (tokens.TryGetValue(type, out uint token)) return token;
				}
				finally { locker.ExitReadLock(); }

				//We use a read and a write lock instead of an upgradable lock here because only one upgradable
				//lock can be entered, however simultaneous reads are really common for our operations.

				locker.EnterWriteLock();
				try
				{
					uint token = (uint)types.Count;

					tokens.Add(type, token);
					types.Add(type);

					return token;
				}
				finally { locker.ExitWriteLock(); }
			}
		}

		public void Dispose() => locker.Dispose();

		public void Write(DataWriter writer, ITypeSerializer serializer)
		{
			locker.EnterReadLock();
			try
			{
				int count = types.Count;
				writer.WriteCompact(count);

				for (int i = 0; i < count; i++) serializer.Write(writer, types[i]);
			}
			finally { locker.ExitReadLock(); }
		}

		public void Read(DataReader reader, ITypeSerializer serializer)
		{
			locker.EnterWriteLock();
			try
			{
				int count = reader.ReadInt32Compact();

				types.Clear();
				tokens.Clear();

				types.Capacity = count;

				for (uint i = 0; i < count; i++)
				{
					Type type = serializer.Read(reader);

					tokens.Add(type, i);
					types.Add(type);
				}
			}
			finally { locker.ExitWriteLock(); }
		}
	}
}