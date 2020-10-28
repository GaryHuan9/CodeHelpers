using System;
using System.Collections.ObjectModel;
using CodeHelpers.Vectors;

namespace CodeHelpers
{
	public static class EnumHelper<T> where T : Enum
	{
		static EnumHelper()
		{
			string[] names = Enum.GetNames(typeof(T));
			T[] values = (T[])Enum.GetValues(typeof(T));

			enumNames = new ReadOnlyCollection<string>(names);
			enumValues = new ReadOnlyCollection<T>(values);

			enumLength = names.Length;
		}

		public static readonly int enumLength;

		public static readonly ReadOnlyCollection<string> enumNames;
		public static readonly ReadOnlyCollection<T> enumValues;
	}
}
