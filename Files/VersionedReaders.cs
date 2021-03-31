using System;
using System.Collections.Generic;
using CodeHelpers.Collections;

namespace CodeHelpers.Files
{
	public class VersionedReaders
	{
		public VersionedReaders(int version, DataReader dataReader, CompiledReaders compiledReaders)
		{
			this.version = version;
			this.dataReader = dataReader;

			compiledReaders.FillStaticReaders(version, staticReaders);
			compiledReaders.FillInstanceReaders(version, instanceReaders);
		}

		public readonly int version;
		public readonly DataReader dataReader;

		readonly Dictionary<Type, object> staticReaders = new Dictionary<Type, object>();
		readonly Dictionary<Type, object> instanceReaders = new Dictionary<Type, object>();

		public T Read<T>()
		{
			object reader = staticReaders.TryGetValue(typeof(T));

			if (reader != null) return ((Func<DataReader, T>)reader)(dataReader);
			throw new Exception($"No reader supports reading type {typeof(T)}.");
		}

		public void Read<T>(T value)
		{
			object reader = staticReaders.TryGetValue(typeof(T));

			if (reader != null) ((Action<DataReader, T>)reader)(dataReader, value);
			else throw new Exception($"No reader supports reading type {typeof(T)}.");
		}
	}
}