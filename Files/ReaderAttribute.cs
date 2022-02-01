using System;
using System.Reflection;

namespace CodeHelpers.Files
{
	/// <summary>
	/// An attribute that tags a method the ability to read/deserialize a type from a <see cref="DataReader"/>.
	/// A reader method can either be instanced or static:
	/// Static methods must return the targeting type and accept <see cref="DataReader"/> as its only parameter. The deserialized type should be returned from the method.
	/// Instance methods must return type void and accept <see cref="DataReader"/> as its only parameter. The method should deserialize the information directly into the instance.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class ReaderAttribute : Attribute
	{
		public ReaderAttribute(int version) => this.version = version;

		/// <summary>
		/// This reader supports all versions above or equals this number.
		/// </summary>
		public readonly int version;

		/// <summary>
		/// If this value is true, before trying to use this reader, <see cref="DataReader"/> will first try to read the type written by <see cref="DataWriter.Write(System.Type)"/>.
		/// After then, the reader for that specified type that we just read will be invoked and used, which may or may not be this reader.
		/// NOTE: This value must be enabled if you write the type through <see cref="DataWriter.Write(System.Type)"/> or the bytes will not line up!
		/// </summary>
		public bool ReadType { get; set; }

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