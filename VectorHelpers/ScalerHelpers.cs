using System;
using System.Text;
using UnityEngine;

namespace CodeHelpers.VectorHelpers
{
	public static class ScalerHelper
	{
		/// <summary>
		/// Convert <paramref name="value"/> to an angle between -180f (Exclusive) and 180f (Inclusive) with the same rotational value as input.
		/// </summary>
		public static float ToSignedAngle(this float value) => -(180f - value).Repeat(360f) + 180f;

		/// <summary>
		/// Convert <paramref name="value"/> to an angle between -179 and 180 with the same rotational value as input.
		/// </summary>
		public static int ToSignedAngle(this int value) => -(180 - value).Repeat(360) + 180;

		/// <summary>
		/// Convert <paramref name="value"/> to an angle between 0f (Inclusive) and 360f (Exclusive) with the same rotational value as input.
		/// </summary>
		public static float ToUnsignedAngle(this float value) => value.Repeat(360f);

		/// <summary>
		/// Convert <paramref name="value"/> to an angle between 0 and 359 with the same rotational value as input.
		/// </summary>
		public static int ToUnsignedAngle(this int value) => value.Repeat(360);

		/// <summary>
		/// Converts <paramref name="value"/>, a number from zero to positive one. Into a range from negative one to positive one.
		/// </summary>
		public static float To1To1(this float value) => value * 2f - 1f;

		/// <summary>
		/// Converts <paramref name="value"/>, a number from negative one to positive one. Into a range from zero to positive one.
		/// </summary>
		public static float To0To1(this float value) => (value + 1f) / 2f;

		public static int CeilDivide(this int value, int divider) => (value - 1) / divider + 1;

		// public static bool AlmostEquals(this float value, float other)
		// {
		// 	if (value == other) return true;
		// 	return Math.Abs(value - other) < Math.Abs(value) / (1 << 20);
		// }
		//
		// public static bool AlmostEquals(this double value, double other)
		// {
		// 	if (value == other) return true;
		// 	return Math.Abs(value - other) < Math.Abs(value) / (1 << 48);
		// }

		public static Vector2Int To2D(this int value, int height) => new Vector2Int(value / height, value % height);

		public static int Normalized(this float value) => Mathf.Approximately(value, 0) ? 0 : value < 0 ? -1 : 1;
		public static int Normalized(this float value, float threshold) => Mathf.Abs(value) <= threshold ? 0 : value < 0 ? -1 : 1;
		public static int Normalized(this int value) => value == 0 ? 0 : value < 0 ? -1 : 1;

		/// <summary>Another implementation of Unity's Mathf.Repeat method. Slightly faster.</summary>
		public static float Repeat(this float value, float length)
		{
			float result = value % length;
			return result < 0f ? result + length : result;
		}

		/// <summary>Another implementation of Unity's Mathf.Repeat method. Slightly faster.</summary>
		public static int Repeat(this int value, int length)
		{
			int result = value % length;
			return result < 0 ? result + length : result;
		}

		/// <summary>Another implementation of Unity's Mathf.Repeat method. Slightly faster.</summary>
		public static long Repeat(this long value, long length)
		{
			long result = value % length;
			return result < 0 ? result + length : result;
		}

		public static int FlooredDivide(this int value, int divisor) => value / divisor - Convert.ToInt32((value < 0) ^ (divisor < 0) && value % divisor != 0);
		public static long FlooredDivide(this long value, long divisor) => value / divisor - Convert.ToInt64((value < 0) ^ (divisor < 0) && value % divisor != 0);

		public static float Remap(this float value, float fromLow, float fromHigh, float toLow, float toHigh) => (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;

#if UNSAFE_CODE_ENABLED
		public static unsafe int SingleToInt32Bits(float value) => *(int*)&value;
		public static unsafe float Int32BitsToSingle(int value) => *(float*)&value;
#else
		public static int SingleToInt32Bits(float value) => new FloatIntConverter(value).intValue;
		public static float Int32BitsToSingle(int value) => new FloatIntConverter(value).floatValue;

		[StructLayout(LayoutKind.Explicit)]
		struct FloatIntConverter
		{
			public FloatIntConverter(float floatValue) : this() => this.floatValue = floatValue;
			public FloatIntConverter(int intValue) : this() => this.intValue = intValue;

			[FieldOffset(0)] public readonly float floatValue;
			[FieldOffset(0)] public readonly int intValue;
		}
#endif

		/// <summary>
		/// Format the integer to their abbreviations using metric suffixes
		/// The returned string will always be shorter or equals to 4 characters
		/// </summary>
		public static string ToKiloFormatString(this int value)
		{
			if (value < 0) throw ExceptionHelper.Invalid(nameof(value), value, "cannot be negative.");

			const int MaxLength = 4;

			if (value >= 1000000000) return Format(1000000000, 'B');
			if (value >= 1000000) return Format(1000000, 'M');
			if (value >= 1000) return Format(1000, 'K');

			return value.ToString();

			string Format(int level, char suffix)
			{
				int integer = value / level;
				int floating = value / (level / 1000) - integer * 1000;

				var builder = new StringBuilder();

				builder.Append(integer);
				builder.Append('.');
				builder.Append(floating.ToString("D3"));

				bool hasDot = true;

				while (builder.Length > MaxLength - 1) RemoveLast();
				while (hasDot && builder[builder.Length - 1] == '0') RemoveLast();
				while (hasDot && builder[builder.Length - 1] == '.') RemoveLast();

				builder.Append(suffix);
				return builder.ToString();

				void RemoveLast()
				{
					if (builder[builder.Length - 1] == '.') hasDot = false;
					builder.Remove(builder.Length - 1, 1);
				}
			}
		}
	}
}