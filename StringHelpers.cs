using System;
using System.Numerics;
using System.Text;
using CodeHelpers.Mathematics;

namespace CodeHelpers
{
	public static class StringHelper
	{
		public static StringBuilder TrimEnd(this StringBuilder builder)
		{
			if (builder == null || builder.Length == 0) return builder;

			int index = builder.Length - 1;
			for (; index >= 0; index--)
			{
				if (!char.IsWhiteSpace(builder[index])) break;
			}

			if (index < builder.Length - 1) builder.Length = index + 1;

			return builder;
		}

		public static string ToStringBinary(this int number) => ToStringBinary((uint)number);

		public static string ToStringBinary(this uint number) => ToStringBinary(number, sizeof(uint) * 8);

		public static string ToStringBinary(this long number) => ToStringBinary((ulong)number);

		public static string ToStringBinary(this ulong number) => ToStringBinary(number, sizeof(ulong) * 8);

		static string ToStringBinary(this ulong number, int length)
		{
			//Total allocated: bits length + bits length / 4 - 1 division characters
			int total = length * 8 + length * 8 / 4 - 1;

#if CODEHELPERS_UNITY
			char[] chars = new char[total];
#else
			Span<char> chars = stackalloc char[total];
#endif

			int index = 0;
			int bit = 0;

			while (number != 0)
			{
				chars[total - ++index] = (number & 1) == 0 ? '0' : '1';

				number >>= 1;

				if (++bit < length && number != 0)
				{
					if (bit % 8 == 0) chars[total - ++index] = ' ';
					else if (bit % 4 == 0) chars[total - ++index] = '_';
				}
			}

#if CODEHELPERS_UNITY
			return new string(chars, total - index, index);
#else
			return new string(chars[^index..]);
#endif
		}

	}
}