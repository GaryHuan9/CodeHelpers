using System;
using System.Collections.Generic;
using CodeHelpers.Collections;

namespace CodeHelpers.Files
{
	public class VersionedReaders
	{
		public VersionedReaders(int version, CompiledReaders compiledReaders)
		{
			this.version = version;

			staticReaders = compiledReaders.GetStaticReaders(version);
			instanceReaders = compiledReaders.GetInstanceReaders(version);
			readTypes = compiledReaders.GetReadTypes(version);
		}

		public readonly int version;

		readonly Dictionary<Type, object> staticReaders;
		readonly Dictionary<Type, object> instanceReaders;
		readonly HashSet<Type> readTypes;

		public object Read(Type type, DataReader dataReader)
		{
			object reader = staticReaders.TryGetValue(type);

			if (reader != null) return ((Func<DataReader, object>)reader)(dataReader);
			throw new Exception($"No reader supports type {type} on version {version}.");
		}

		public void Read(Type type, DataReader dataReader, object value)
		{
			object reader = instanceReaders.TryGetValue(type);

			if (reader != null) ((Action<DataReader, object>)reader)(dataReader, value);
			else throw new Exception($"No reader supports type {type} on version {version}.");
		}

		/// <summary>
		/// Returns whether the reader for <paramref name="type"/> is marked with <see cref="ReaderAttribute.ReadType"/>.
		/// </summary>
		public bool ReadType(Type type) => readTypes.Contains(type);
	}
}