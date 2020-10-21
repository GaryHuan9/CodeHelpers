using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CodeHelpers.Vectors
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

#region Swizzled3

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXX => new Float3(x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXY => new Float3(x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XX_ => new Float3(x, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYX => new Float3(x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYY => new Float3(x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XY_ => new Float3(x, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X_X => new Float3(x, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X_Y => new Float3(x, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X__ => new Float3(x, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXX => new Float3(y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXY => new Float3(y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YX_ => new Float3(y, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYX => new Float3(y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYY => new Float3(y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YY_ => new Float3(y, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y_X => new Float3(y, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y_Y => new Float3(y, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y__ => new Float3(y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _XX => new Float3(0f, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _XY => new Float3(0f, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _X_ => new Float3(0f, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _YX => new Float3(0f, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _YY => new Float3(0f, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _Y_ => new Float3(0f, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 __X => new Float3(0f, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 __Y => new Float3(0f, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ___ => new Float3(0f, 0f, 0f);

#endregion

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

		public float Magnitude
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (float)MagnitudeDouble;
		}

		public double MagnitudeDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Sqrt(SquaredMagnitudeDouble);
		}

		public float SquaredMagnitude
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x * x + y * y;
		}

		public double SquaredMagnitudeDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)x * x + (double)y * y;
		}

		public float Product
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x * y;
		}

		public double ProductDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)x * y;
		}

		public float Sum
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x + y;
		}

		public double SumDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)x + y;
		}

		public float this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
#if UNSAFE_CODE_ENABLED
				unsafe
				{
					if (index < 0 || 1 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
					fixed (Float2* pointer = &this) return ((float*)pointer)[index];
				}
#else
				switch (index)
				{
					case 0: return x;
					case 1: return y;
				}

				throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
#endif
			}
		}

#endregion

#region Float2 Returns

		public Float2 Absoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float2(Math.Abs(x), Math.Abs(y));
		}

		public Float2 Signed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float2(x.Signed(), y.Signed());
		}

		public Float2 Normalized
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				double squared = SquaredMagnitudeDouble;
				if (AlmostEqualsZero(squared)) return Zero;

				return this / (float)Math.Sqrt(squared);
			}
		}

#endregion

#endregion

#region Methods

#region Instance

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Dot(Float2 other) => x * other.x + y * other.y;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DotDouble(Float2 other) => (double)x * other.x + (double)y * other.y;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Angle(Float2 other) => Math.Abs(SignedAngle(other));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SignedAngle(Float2 other) => (float)Math.Atan2((double)x * other.y - (double)y * other.x, DotDouble(other)) * ScalarHelper.RadianToDegree;

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public UnityEngine.Vector2 U() => new UnityEngine.Vector2(x, y);
#endif

#endregion

#region Static

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Min(Float2 left, Float2 right) => new Float2(Math.Min(left.x, right.x), Math.Min(left.y, right.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Max(Float2 left, Float2 right) => new Float2(Math.Max(left.x, right.x), Math.Max(left.y, right.y));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Lerp(Float2 left, Float2 right, Float2 value) => new Float2(ScalarHelper.Lerp(left.x, right.x, value.x), ScalarHelper.Lerp(left.y, right.y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Lerp(Float2 left, Float2 right, float value) => new Float2(ScalarHelper.Lerp(left.x, right.x, value), ScalarHelper.Lerp(left.y, right.y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 InverseLerp(Float2 left, Float2 right, Float2 value) => new Float2(ScalarHelper.InverseLerp(left.x, right.x, value.x), ScalarHelper.InverseLerp(left.y, right.y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 InverseLerp(Float2 left, Float2 right, float value) => new Float2(ScalarHelper.InverseLerp(left.x, right.x, value), ScalarHelper.InverseLerp(left.y, right.y, value));

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

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(in Float2 left, in Float2 right) => new Float2(left.x % right.x, left.y % right.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(in Float2 left, float right) => new Float2(left.x % right, left.y % right);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(float left, in Float2 right) => new Float2(left % right.x, left % right.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(in Float2 left, in Float2 right) => left.Equals(right);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(in Float2 left, in Float2 right) => !left.Equals(right);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Float2 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Float2 other) => AlmostEqualsZero((other - this).SquaredMagnitudeDouble);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(float value) => new Float2(value, value);

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float2(UnityEngine.Vector2 value) => new Float2(value.x, value.y);
#endif

		[MethodImpl(MethodImplOptions.AggressiveInlining)] static bool AlmostEqualsZero(double squaredMagnitude) => ScalarHelper.AlmostEquals(squaredMagnitude, 0d);

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