using System;
using System.Reflection;
using CodeHelpers.Diagnostics;

namespace CodeHelpers.Files
{
	[AttributeUsage(AttributeTargets.Method)]
	public class ReaderAttribute : Attribute
	{
		public ReaderAttribute(int version) => this.version = version;

		/// <summary>
		/// This reader supports all versions above or equals this number.
		/// </summary>
		public readonly int version;

		/// <summary>
		/// Checks whether <paramref name="method"/> is a valid method for <see cref="ReaderAttribute"/>.
		/// If so, returns the type that it can read. Otherwise exceptions are thrown.
		/// </summary>
		public static Type CheckMethod(MethodInfo method)
		{
			Type readType = method.IsStatic ? method.ReturnType : method.DeclaringType ?? throw ExceptionHelper.NotPossible;

			if (readType == typeof(void)) throw new Exception($"Method '{method}' must target something to use {nameof(ReaderAttribute)}.");
			if (readType.IsValueType) throw new Exception($"Method '{method}' must target a reference type to use {nameof(ReaderAttribute)}.");

			ParameterInfo[] parameters = method.GetParameters();

			if (parameters.Length != 1) throw new Exception($"Method '{method}' must contain exactly one parameter to use {nameof(ReaderAttribute)}.");
			if (parameters[0].ParameterType != typeof(DataReader)) throw new Exception($"Method '{method}' must have a {nameof(DataReader)} parameter to use {nameof(ReaderAttribute)}.");

			return readType;
		}
	}
}