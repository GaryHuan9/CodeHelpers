using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CodeHelpers.VectorHelpers
{
	public readonly struct Float2 : IEquatable<Float2>, IFormattable
	{

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		public readonly float x;
		public readonly float y;

#region Swizzled2

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XX => new Float2(x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XY => new Float2(x, y);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YX => new Float2(y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YY => new Float2(y, y);

#endregion

#region Static Properties

		public static readonly Float2 Right = new Float2(1f, 0f);
		public static readonly Float2 Left = new Float2(-1f, 0f);

		public static readonly Float2 Up = new Float2(0f, 1f);
		public static readonly Float2 Down = new Float2(0f, -1f);

		public static readonly Float2 One = new Float2(1f, 1f);
		public static readonly Float2 Zero = new Float2(0f, 0f);
		public static readonly Float2 NegativeOne = new Float2(-1f, -1f);

		public static readonly Float2 MaxValue = new Float2(float.MaxValue, float.MaxValue);
		public static readonly Float2 MinValue = new Float2(float.MinValue, float.MinValue);

		public static readonly Float2 PositiveInfinity = new Float2(float.PositiveInfinity, float.PositiveInfinity);
		public static readonly Float2 NegativeInfinity = new Float2(float.NegativeInfinity, float.NegativeInfinity);

		public static readonly Float2 Epsilon = new Float2(float.Epsilon, float.Epsilon);
		public static readonly Float2 NaN = new Float2(float.NaN, float.NaN);

#endregion

#region Simple Properties

#region Scaler Returns

		public float Magnitude => (float)Math.Sqrt(SquaredMagnitudeDouble);
		public float SquaredMagnitude => (float)SquaredMagnitudeDouble;
		public double SquaredMagnitudeDouble => (double)x * x + (double)y * y;

#endregion

#region Float2 Returns

		public Float2 Absoluted => new Float2(Math.Abs(x), Math.Abs(y));
		public Float2 Signed => new Float2(x.Signed(), y.Signed());

		public Float2 Normalized
		{
			get
			{
				double squared = SquaredMagnitudeDouble;
				if (AlmostEqualsZero(squared)) return Zero;

				return this / (float)Math.Sqrt(squared);
			}
		}

#endregion

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator +(in Float2 left, in Float2 right) => new Float2(left.x + right.x, left.y + right.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator -(in Float2 left, in Float2 right) => new Float2(left.x - right.x, left.y - right.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(in Float2 left, in Float2 right) => new Float2(left.x * right.x, left.y * right.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(in Float2 left, in Float2 right) => new Float2(left.x / right.x, left.y / right.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(in Float2 left, float right) => new Float2(left.x * right, left.y * right);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(in Float2 left, float right) => new Float2(left.x / right, left.y / right);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(float left, in Float2 right) => new Float2(left * right.x, left * right.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(float left, in Float2 right) => new Float2(left / right.x, left / right.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator -(in Float2 value) => new Float2(-value.x, -value.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(in Float2 left, in Float2 right) => left.Equals(right);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(in Float2 left, in Float2 right) => !left.Equals(right);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Float2 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Float2 other) => AlmostEqualsZero((other - this).SquaredMagnitudeDouble);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] static bool AlmostEqualsZero(double squaredMagnitude) => ScalerHelper.AlmostEquals(squaredMagnitude, 0d);

#endregion

		public override int GetHashCode()
		{
			unchecked
			{
				return (x.GetHashCode() * 397) ^ y.GetHashCode();
			}
		}

		public override string ToString() => $"({x}, {y})";

		public string ToString(string format) => ToString(format, CultureInfo.InvariantCulture);
		public string ToString(string format, IFormatProvider formatProvider) => $"({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
	}
}