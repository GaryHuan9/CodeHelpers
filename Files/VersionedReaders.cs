using System;
using System.Collections.Generic;
using CodeHelpers.Collections;

namespace CodeHelpers.Files
{
	public class VersionedReaders
	{
		public VersionedReaders(DataReader dataReader, int version, CompiledReaders compiledReaders)
		{
			this.dataReader = dataReader;
			this.version = version;

			compiledReaders.FillStaticReaders(version, staticReaders);
			compiledReaders.FillInstanceReaders(version, instanceReaders);
		}

		readonly DataReader dataReader;
		public readonly int version;

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