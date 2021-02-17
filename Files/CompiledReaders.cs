using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CodeHelpers.Collections;

namespace CodeHelpers.Files
{
	public class CompiledReaders
	{
		public CompiledReaders(Assembly assembly)
		{
			compiledReaders = new Dictionary<Type, List<ReaderPair>>();

			foreach (MethodInfo method in from type in assembly.GetTypes()
										  from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
										  where method.GetCustomAttribute<ReaderAttribute>() != null
										  select method)
			{
				Type returnType = ReaderAttribute.CheckMethod(method);
				var attribute = method.GetCustomAttribute<ReaderAttribute>();

				if (!compiledReaders.TryGetValue(returnType, out List<ReaderPair> list))
				{
					list = new List<ReaderPair>();
					compiledReaders.Add(returnType, list);
				}

				//Find location
				int index = list.BinarySearch(attribute.version, PairComparer.comparer);

				if (index < 0)
				{
					Delegate reader = Delegate.CreateDelegate(typeof(ReaderDelegate), method);
					ReaderPair pair = new ReaderPair(attribute.version, (ReaderDelegate)reader);

					list.Insert(~index, pair);
				}
				else throw ExceptionHelper.Invalid(nameof(method), method, InvalidType.foundDuplicate);
			}

			//Finalize
			foreach (var pair in compiledReaders) pair.Value.TrimExcess();
		}

		readonly Dictionary<Type, List<ReaderPair>> compiledReaders;
		public IEnumerable<Type> SupportedTypes => compiledReaders.Keys;

		public ReaderDelegate GetReader(int version, Type type)
		{
			List<ReaderPair> list = compiledReaders.TryGetValue(type);
			if (list == null) throw ExceptionHelper.Invalid(nameof(type), type, "has no supporting compiled reader");

			//Reader versions are forward compatible until the next version
			int index = list.BinarySearch(version, PairComparer.comparer);

			if (index != ~0) return list[index < 0 ? ~index - 1 : index].dataReader;
			throw new Exception($"No reader supported for {type} on version '{version}'.");
		}

		readonly struct ReaderPair
		{
			public ReaderPair(int version, ReaderDelegate dataReader)
			{
				this.version = version;
				this.dataReader = dataReader;
			}

			public readonly int version;
			public readonly ReaderDelegate dataReader;
		}

		class PairComparer : IDoubleComparer<ReaderPair, int>
		{
			public static readonly PairComparer comparer = new PairComparer();
			public int CompareTo(ReaderPair first, int second) => first.version.CompareTo(second);
		}
	}
}