using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CodeHelpers.Collections;
using CodeHelpers.Diagnostics;

namespace CodeHelpers.Files
{
	public class CompiledReaders
	{
		public CompiledReaders(Assembly assembly)
		{
			foreach (MethodInfo method in from type in assembly.GetTypes()
										  from method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
										  where method.GetCustomAttribute<ReaderAttribute>() != null
										  select method)
			{
				var attribute = method.GetCustomAttribute<ReaderAttribute>();
				Type readType = ReaderAttribute.CheckMethod(method);

				var compiledReaders = method.IsStatic ? staticReaders : instanceReaders;
				List<ReaderPair> readerList = compiledReaders.TryGetValue(readType);

				if (readerList == null)
				{
					readerList = new List<ReaderPair>();
					compiledReaders.Add(readType, readerList);
				}

				//Find location
				int index = readerList.BinarySearch(attribute.version, PairComparer.comparer);

				if (index < 0) readerList.Insert(~index, new ReaderPair(attribute.version, CreateReader(method)));
				else throw ExceptionHelper.Invalid(nameof(method), method, InvalidType.foundDuplicate);
			}

			//Finalize
			foreach (var pair in staticReaders) pair.Value.TrimExcess();
			foreach (var pair in instanceReaders) pair.Value.TrimExcess();
		}

		readonly Dictionary<Type, List<ReaderPair>> staticReaders = new Dictionary<Type, List<ReaderPair>>();
		readonly Dictionary<Type, List<ReaderPair>> instanceReaders = new Dictionary<Type, List<ReaderPair>>();

		public void FillStaticReaders(int version, Dictionary<Type, object> target) => FillReaders(version, staticReaders, target);
		public void FillInstanceReaders(int version, Dictionary<Type, object> target) => FillReaders(version, instanceReaders, target);

		public static object CreateReader(MethodInfo method)
		{
			if (method.IsStatic)
			{
				Type funcType = Expression.GetFuncType(typeof(DataReader), method.ReturnType);
				return Delegate.CreateDelegate(funcType, method);
			}

			//Build instance reader using expression trees
			Type readType = method.DeclaringType ?? throw ExceptionHelper.NotPossible;

			ParameterExpression dataReader = Expression.Parameter(typeof(DataReader));
			ParameterExpression readInstance = Expression.Parameter(readType);

			MethodCallExpression call = Expression.Call(readInstance, method, dataReader);
			LambdaExpression lambda = Expression.Lambda(call, dataReader, readInstance);

			return lambda.Compile();
		}

		static void FillReaders(int version, IReadOnlyDictionary<Type, List<ReaderPair>> source, Dictionary<Type, object> target)
		{
			foreach (KeyValuePair<Type, List<ReaderPair>> pair in source)
			{
				Type type = pair.Key;
				var list = source[type];

				target.Add(type, GetReader(version, type, list));
			}
		}

		static object GetReader(int version, Type type, List<ReaderPair> list)
		{
			//Reader versions are forward compatible until the next version
			int index = list.BinarySearch(version, PairComparer.comparer);

			if (index != ~0) return list[index < 0 ? ~index - 1 : index].reader;
			throw new Exception($"No reader supported for {type} on version '{version}'.");
		}

		readonly struct ReaderPair
		{
			public ReaderPair(int version, object reader)
			{
				this.version = version;
				this.reader = reader;
			}

			public readonly int version;
			public readonly object reader;
		}

		class PairComparer : IDoubleComparer<ReaderPair, int>
		{
			public static readonly PairComparer comparer = new PairComparer();
			public int CompareTo(ReaderPair first, int second) => first.version.CompareTo(second);
		}
	}
}