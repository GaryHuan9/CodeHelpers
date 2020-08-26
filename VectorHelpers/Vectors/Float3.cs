using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CodeHelpers.VectorHelpers
{
	public readonly struct Float3 : IEquatable<Float3>, IFormattable
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public readonly float x;
		public readonly float y;
		public readonly float z;

#region Swizzled3

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXX => new Float3(x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXY => new Float3(x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXZ => new Float3(x, x, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYX => new Float3(x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYY => new Float3(x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYZ => new Float3(x, y, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZX => new Float3(x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZY => new Float3(x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZZ => new Float3(x, z, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXX => new Float3(y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXY => new Float3(y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXZ => new Float3(y, x, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYX => new Float3(y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYY => new Float3(y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYZ => new Float3(y, y, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZX => new Float3(y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZY => new Float3(y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZZ => new Float3(y, z, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXX => new Float3(z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXY => new Float3(z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXZ => new Float3(z, x, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYX => new Float3(z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYY => new Float3(z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYZ => new Float3(z, y, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZX => new Float3(z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZY => new Float3(z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZZ => new Float3(z, z, z);

#endregion

#region Static Properties

		public static readonly Float3 Right = new Float3(1f, 0f, 0f);
		public static readonly Float3 Left = new Float3(-1f, 0f, 0f);

		public static readonly Float3 Up = new Float3(0f, 1f, 0f);
		public static readonly Float3 Down = new Float3(0f, -1f, 0f);

		public static readonly Float3 Forward = new Float3(0f, 0f, 1f);
		public static readonly Float3 Backward = new Float3(0f, 0f, -1f);

		public static readonly Float3 One = new Float3(1f, 1f, 1f);
		public static readonly Float3 Zero = new Float3(0f, 0f, 0f);
		public static readonly Float3 NegativeOne = new Float3(-1f, -1f, -1f);

		public static readonly Float3 MaxValue = new Float3(float.MaxValue, float.MaxValue, float.MaxValue);
		public static readonly Float3 MinValue = new Float3(float.MinValue, float.MinValue, float.MinValue);

		public static readonly Float3 PositiveInfinity = new Float3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
		public static readonly Float3 NegativeInfinity = new Float3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

		public static readonly Float3 Epsilon = new Float3(float.Epsilon, float.Epsilon, float.Epsilon);
		public static readonly Float3 NaN = new Float3(float.NaN, float.NaN, float.NaN);

#endregion

#region Simple Properties

#region Scaler Returns

		public float Magnitude => (float)Math.Sqrt(SquaredMagnitudeDouble);
		public float SquaredMagnitude => (float)SquaredMagnitudeDouble;
		public double SquaredMagnitudeDouble => (double)x * x + (double)y * y + (double)z * z;

#endregion

#region Float3 Returns

		public Float3 Absoluted => new Float3(Math.Abs(x), Math.Abs(y), Math.Abs(z));
		public Float3 Signed => new Float3(x.Signed(), y.Signed(), z.Signed());

		public Float3 Normalized
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

#region Static Operators

#region Two Variables

		public static Float3 Min(Float3 left, Float3 right) => new Float3(Math.Min(left.x, right.x), Math.Min(left.y, right.y), Math.Min(left.z, right.z));
		public static Float3 Max(Float3 left, Float3 right) => new Float3(Math.Max(left.x, right.x), Math.Max(left.y, right.y), Math.Max(left.z, right.z));

#endregion

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator +(in Float3 left, in Float3 right) => new Float3(left.x + right.x, left.y + right.y, left.z + right.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator -(in Float3 left, in Float3 right) => new Float3(left.x - right.x, left.y - right.y, left.z - right.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(in Float3 left, in Float3 right) => new Float3(left.x * right.x, left.y * right.y, left.z * right.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(in Float3 left, in Float3 right) => new Float3(left.x / right.x, left.y / right.y, left.z / right.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(in Float3 left, float right) => new Float3(left.x * right, left.y * right, left.z * right);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(in Float3 left, float right) => new Float3(left.x / right, left.y / right, left.z / right);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(float left, in Float3 right) => new Float3(left * right.x, left * right.y, left * right.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(float left, in Float3 right) => new Float3(left / right.x, left / right.y, left / right.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator -(in Float3 value) => new Float3(-value.x, -value.y, -value.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(in Float3 left, in Float3 right) => left.Equals(right);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(in Float3 left, in Float3 right) => !left.Equals(right);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Float3 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Float3 other) => AlmostEqualsZero((other - this).SquaredMagnitudeDouble);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] static bool AlmostEqualsZero(double squaredMagnitude) => ScalerHelper.AlmostEquals(squaredMagnitude, 0d);

#endregion

		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = x.GetHashCode();
				hashCode = (hashCode * 397) ^ y.GetHashCode();
				hashCode = (hashCode * 397) ^ z.GetHashCode();
				return hashCode;
			}
		}

		public override string ToString() => $"({x}, {y}, {z})";

		public string ToString(string format) => ToString(format, CultureInfo.InvariantCulture);
		public string ToString(string format, IFormatProvider formatProvider) => $"({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
	}
}