using System;
using CodeHelpers.Vectors;

namespace CodeHelpers
{
	public static class EnumHelper
	{

	}

	public static class EnumHelper<T> where T : Enum
	{
		static EnumHelper()
		{
			var names = Enum.GetNames(typeof(T));

			EnumLength = names.LongLength;
			LastEnum = (T)Enum.Parse(typeof(T), names[names.Length - 1]);
		}

		public static long EnumLength { get; }
		public static T LastEnum { get; }
	}
}
