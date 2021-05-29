using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CodeHelpers.Collections;

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
				Type type = ReaderAttribute.CheckMethod(method);

				var compiledReaders = method.IsStatic ? staticReaders : instanceReaders;
				List<ReaderGroup> readerList = compiledReaders.TryGetValue(type);

				if (readerList == null)
				{
					readerList = new List<ReaderGroup>();
					compiledReaders.Add(type, readerList);
				}

				//Find location
				int index = readerList.BinarySearch(attribute.version, GroupComparer.comparer);

				if (index < 0)
				{
					object reader = CreateReader(method);
					readerList.Insert(~index, new ReaderGroup(attribute, reader, type));
				}
				else throw ExceptionHelper.Invalid(nameof(method), method, InvalidType.foundDuplicate);
			}

			//Finalize
			foreach (var pair in staticReaders) pair.Value.TrimExcess();
			foreach (var pair in instanceReaders) pair.Value.TrimExcess();
		}

		public CompiledReaders() : this(Assembly.GetCallingAssembly()) { }

		readonly Dictionary<Type, List<ReaderGroup>> staticReaders = new Dictionary<Type, List<ReaderGroup>>();
		readonly Dictionary<Type, List<ReaderGroup>> instanceReaders = new Dictionary<Type, List<ReaderGroup>>();

		public Dictionary<Type, object> GetStaticReaders(int version) => GetGroups(version, staticReaders).ToDictionary(group => group.type, group => group.reader);
		public Dictionary<Type, object> GetInstanceReaders(int version) => GetGroups(version, instanceReaders).ToDictionary(group => group.type, group => group.reader);

		/// <summary>
		/// Returns all of the types that are marked with <see cref="ReaderAttribute.ReadType"/>.
		/// </summary>
		public HashSet<Type> GetReadTypes(int version) => new HashSet<Type>
		(
			from @group in GetGroups(version, staticReaders).Concat(GetGroups(version, instanceReaders))
			where @group.readType
			select @group.type
		);

		static object CreateReader(MethodInfo method)
		{
			if (method.IsStatic)
			{
				Type funcType = Expression.GetFuncType(typeof(DataReader), method.ReturnType);
				return Delegate.CreateDelegate(funcType, method); //Compiles into Func<DataReader, object>
			}

			//Build instance reader using expression trees
			Type readType = method.DeclaringType ?? throw ExceptionHelper.NotPossible;

			ParameterExpression readerParameter = Expression.Parameter(typeof(DataReader));
			ParameterExpression objectParameter = Expression.Parameter(typeof(object));
			UnaryExpression castExpression = Expression.Convert(objectParameter, readType);

			MethodCallExpression call = Expression.Call(castExpression, method, readerParameter);
			LambdaExpression lambda = Expression.Lambda(call, readerParameter, objectParameter);

			return lambda.Compile(); //Compiles into Action<DataReader, object>
		}

		static IEnumerable<ReaderGroup> GetGroups(int version, IReadOnlyDictionary<Type, List<ReaderGroup>> source)
		{
			foreach (KeyValuePair<Type, List<ReaderGroup>> pair in source)
			{
				Type type = pair.Key;
				var list = source[type];

				yield return GetGroup(version, type, list);
			}
		}

		static ReaderGroup GetGroup(int version, Type type, IList<ReaderGroup> list)
		{
			//Reader versions are forward compatible until the next version
			int index = list.BinarySearch(version, GroupComparer.comparer);
			if (index != ~0) return list[index < 0 ? ~index - 1 : index];

			throw new Exception($"No reader supported for {type} on version '{version}'.");
		}

		class ReaderGroup
		{
			public ReaderGroup(ReaderAttribute attribute, object reader, Type type)
			{
				version = attribute.version;
				readType = attribute.ReadType;

				this.reader = reader;
				this.type = type;
			}

			public readonly int version;
			public readonly bool readType;

			public readonly Type type;
			public readonly object reader;
		}

		class GroupComparer : IDoubleComparer<ReaderGroup, int>
		{
			public static readonly GroupComparer comparer = new GroupComparer();
			public int CompareTo(ReaderGroup first, int second) => first.version.CompareTo(second);
		}
	}
}