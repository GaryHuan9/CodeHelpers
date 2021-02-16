using System;
using System.Collections.Generic;
using System.Linq;
using CodeHelpers.Collections;

namespace CodeHelpers.Files
{
	public class VersionedReaders
	{
		public VersionedReaders(int version, DataReader dataReader, CompiledReaders compiledReaders)
		{
			this.version = version;
			this.dataReader = dataReader;

			readers = compiledReaders.SupportedTypes.ToDictionary(type => type, type => compiledReaders.GetReader(version, type));
		}

		public readonly int version;
		public readonly DataReader dataReader;

		readonly Dictionary<Type, ReaderDelegate> readers;

		public T Read<T>()
		{
			ReaderDelegate reader = readers.TryGetValue(typeof(T));

			if (reader != null) return (T)reader(dataReader);
			throw new Exception($"No reader supports reading type {typeof(T)}.");
		}
	}
}