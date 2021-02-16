using System;
using System.Reflection;

namespace CodeHelpers.Files
{
	[AttributeUsage(AttributeTargets.Method)]
	public class ReaderAttribute : Attribute
	{
		public ReaderAttribute(int version) => this.version = version;

		public readonly int version;

		/// <summary>
		/// Checks whether <paramref name="info"/> is a valid method for <see cref="ReaderAttribute"/>.
		/// If so, returns the type that is can read. Otherwise exceptions are thrown.
		/// </summary>
		public static Type CheckMethod(MethodInfo info)
		{
			Type returnType = info.ReturnType;

			if (returnType == typeof(void)) throw new Exception($"Method '{info}' must return something to use {nameof(ReaderAttribute)}.");
			if (returnType.IsValueType) throw new Exception($"Method '{info}' must return a reference type to use {nameof(ReaderAttribute)}.");

			ParameterInfo[] parameters = info.GetParameters();

			if (parameters.Length != 1) throw new Exception($"Method '{info}' must contain exactly one parameter to use {nameof(ReaderAttribute)}.");
			if (parameters[0].ParameterType != typeof(DataReader)) throw new Exception($"Method '{info}' must have a {nameof(DataReader)} parameter to use {nameof(ReaderAttribute)}.");

			return returnType;
		}
	}

	public delegate object ReaderDelegate(DataReader dataReader);
}