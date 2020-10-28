using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CodeHelpers.Vectors
{
	[Serializable]
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

		public static readonly Float2 right = new Float2(1f, 0f);
		public static readonly Float2 left = new Float2(-1f, 0f);

		public static readonly Float2 up = new Float2(0f, 1f);
		public static readonly Float2 down = new Float2(0f, -1f);

		public static readonly Float2 zero = new Float2(0f, 0f);

		public static readonly Float2 one = new Float2(1f, 1f);
		public static readonly Float2 negativeOne = new Float2(-1f, -1f);

		public static readonly Float2 half = new Float2(0.5f, 0.5f);
		public static readonly Float2 negativeHalf = new Float2(-0.5f, -0.5f);

		public static readonly Float2 maxValue = new Float2(float.MaxValue, float.MaxValue);
		public static readonly Float2 minValue = new Float2(float.MinValue, float.MinValue);

		public static readonly Float2 positiveInfinity = new Float2(float.PositiveInfinity, float.PositiveInfinity);
		public static readonly Float2 negativeInfinity = new Float2(float.NegativeInfinity, float.NegativeInfinity);

		public static readonly Float2 epsilon = new Float2(Scalars.Epsilon, Scalars.Epsilon);
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

		public float ProductAbsoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs(x * y);
		}

		public double ProductAbsolutedDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs((double)x * y);
		}

		public float Sum
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x + y;
		}

		public double SumDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)x + y;
		}

		public float MinComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x < y ? x : y;
		}

		public int MinIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x < y ? 0 : 1;
		}

		public float MaxComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x > y ? x : y;
		}

		public int MaxIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x > y ? 0 : 1;
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

		public Int2 Signed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int2(x.Sign(), y.Sign());
		}

		public Float2 Normalized
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				double squared = SquaredMagnitudeDouble;
				if (AlmostEqualsZero(squared)) return zero;

				return this / (float)Math.Sqrt(squared);
			}
		}

		public Float2 Perpendicular
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float2(-y, x);
		}

		public Float2 Sorted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x < y ? XY : YX;
		}

		public Float2 SortedReversed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x > y ? XY : YX;
		}

		public Int2 Floored
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int2((int)Math.Floor(x), (int)Math.Floor(y));
		}

		public Float2 FlooredFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float2((float)Math.Floor(x), (float)Math.Floor(y));
		}

		public Int2 Ceiled
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int2((int)Math.Ceiling(x), (int)Math.Ceiling(y));
		}

		public Float2 CeiledFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float2((float)Math.Ceiling(x), (float)Math.Ceiling(y));
		}

		public Int2 Rounded
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int2((int)Math.Round(x), (int)Math.Round(y));
		}

		public Float2 RoundedFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float2((float)Math.Round(x), (float)Math.Round(y));
		}

#endregion

#endregion

#region Methods

#region Instance

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Dot(Float2 other) => x * other.x + y * other.y;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DotDouble(Float2 other) => (double)x * other.x + (double)y * other.y;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Angle(Float2 other) => Math.Abs(SignedAngle(other));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SignedAngle(Float2 other) => (float)Math.Atan2((double)x * other.y - (double)y * other.x, DotDouble(other)) * Scalars.RadianToDegree;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Min(Float2 other) => new Float2(Math.Min(x, other.x), Math.Min(y, other.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Max(Float2 other) => new Float2(Math.Max(x, other.x), Math.Max(y, other.y));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Clamp(Float2 min, Float2 max) => new Float2(x.Clamp(min.x, max.x), y.Clamp(min.y, max.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Clamp(float min, float max) => new Float2(x.Clamp(min, max), y.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2 ClampMagnitude(float max)
		{
			double squared = SquaredMagnitudeDouble;
			if (squared <= (double)max * max) return this;

			float scale = max / (float)Math.Sqrt(squared);
			return new Float2(x * scale, y * scale);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Lerp(Float2 other, Float2 value) => new Float2(Scalars.Lerp(x, other.x, value.x), Scalars.Lerp(y, other.y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Lerp(Float2 other, float value) => new Float2(Scalars.Lerp(x, other.x, value), Scalars.Lerp(y, other.y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 InverseLerp(Float2 other, Float2 value) => new Float2(Scalars.InverseLerp(x, other.x, value.x), Scalars.InverseLerp(y, other.y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 InverseLerp(Float2 other, float value) => new Float2(Scalars.InverseLerp(x, other.x, value), Scalars.InverseLerp(y, other.y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Repeat(Float2 length) => new Float2(x.Repeat(length.x), y.Repeat(length.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Repeat(float length) => new Float2(x.Repeat(length), y.Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2 Rotate(float degree)
		{
			float angle = degree * Scalars.DegreeToRadian;

			float sin = (float)Math.Sin(angle);
			float cos = (float)Math.Cos(angle);

			return new Float2(cos * x - sin * y, sin * x + cos * y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2 Rotate(float degree, Float2 pivot)
		{
			float angle = degree * Scalars.DegreeToRadian;

			float sin = (float)Math.Sin(angle);
			float cos = (float)Math.Cos(angle);

			float offsetX = x - pivot.x;
			float offsetY = y - pivot.y;

			return new Float2(cos * offsetX - sin * offsetY + pivot.x, sin * offsetX + cos * offsetY + pivot.y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2 Damp(Float2 target, ref Float2 velocity, Float2 smoothTime, float deltaTime)
		{
			float velocityX = velocity.x;
			float velocityY = velocity.y;

			Float2 result = new Float2
			(
				Scalars.Damp(x, target.x, ref velocityX, smoothTime.x, deltaTime),
				Scalars.Damp(y, target.y, ref velocityY, smoothTime.y, deltaTime)
			);

			velocity = new Float2(velocityX, velocityY);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2 Damp(Float2 target, ref Float2 velocity, float smoothTime, float deltaTime)
		{
			float velocityX = velocity.x;
			float velocityY = velocity.y;

			Float2 result = new Float2
			(
				Scalars.Damp(x, target.x, ref velocityX, smoothTime, deltaTime),
				Scalars.Damp(y, target.y, ref velocityY, smoothTime, deltaTime)
			);

			velocity = new Float2(velocityX, velocityY);
			return result;
		}

#endregion

#region Static

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Dot(Float2 first, Float2 second) => first.Dot(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double DotDouble(Float2 first, Float2 second) => first.DotDouble(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Angle(Float2 first, Float2 second) => first.Angle(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float SignedAngle(Float2 first, Float2 second) => first.SignedAngle(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Min(Float2 first, Float2 second) => first.Min(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Max(Float2 first, Float2 second) => first.Max(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Clamp(Float2 value, Float2 min, Float2 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Clamp(Float2 value, float min, float max) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 ClampMagnitude(Float2 value, float max) => value.ClampMagnitude(max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Lerp(Float2 first, Float2 second, Float2 value) => first.Lerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Lerp(Float2 first, Float2 second, float value) => first.Lerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 InverseLerp(Float2 first, Float2 second, Float2 value) => first.InverseLerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 InverseLerp(Float2 first, Float2 second, float value) => first.InverseLerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Repeat(Float2 value, Float2 length) => value.Repeat(length);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Repeat(Float2 value, float length) => value.Repeat(length);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Rotate(Float2 value, float degree) => value.Rotate(degree);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Rotate(Float2 value, float degree, Float2 pivot) => value.Rotate(degree, pivot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Damp(Float2 current, Float2 target, ref Float2 velocity, Float2 smoothTime, float deltaTime) => current.Damp(target, ref velocity, smoothTime, deltaTime);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Damp(Float2 current, Float2 target, ref Float2 velocity, float smoothTime, float deltaTime) => current.Damp(target, ref velocity, smoothTime, deltaTime);

#endregion

#region Create

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Float2 Create(int index, float value)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 1 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Float2 result = default;
				((float*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Float2(value, 0f);
				case 1:  return new Float2(0f, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Float2 Create(int index, float value, float other)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 1 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Float2 result = new Float2(other, other);
				((float*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Float2(value, other);
				case 1:  return new Float2(other, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float2 CreateX(float value, float other = 0f) => new Float2(value, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float2 CreateY(float value, float other = 0f) => new Float2(other, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 CreateXY(float other = 0f) => Float3.CreateXY(this, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 CreateYZ(float other = 0f) => Float3.CreateYZ(this, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 CreateXZ(float other = 0f) => Float3.CreateXZ(this, other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2 Replace(int index, float value)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 1 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Float2 result = this; //Make a copy of this struct
				((float*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Float2(value, y);
				case 1:  return new Float2(x, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float2 ReplaceX(float value) => new Float2(value, y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float2 ReplaceY(float value) => new Float2(x, value);

#if CODEHELPERS_UNITY
		public UnityEngine.Vector2 U() => new UnityEngine.Vector2(x, y);
#endif

#endregion

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator +(in Float2 first, in Float2 second) => new Float2(first.x + second.x, first.y + second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator -(in Float2 first, in Float2 second) => new Float2(first.x - second.x, first.y - second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(in Float2 first, in Float2 second) => new Float2(first.x * second.x, first.y * second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(in Float2 first, in Float2 second) => new Float2(first.x / second.x, first.y / second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(in Float2 first, float second) => new Float2(first.x * second, first.y * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(in Float2 first, float second) => new Float2(first.x / second, first.y / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(float first, in Float2 second) => new Float2(first * second.x, first * second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(float first, in Float2 second) => new Float2(first / second.x, first / second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator -(in Float2 value) => new Float2(-value.x, -value.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(in Float2 first, in Float2 second) => new Float2(first.x % second.x, first.y % second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(in Float2 first, float second) => new Float2(first.x % second, first.y % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(float first, in Float2 second) => new Float2(first % second.x, first % second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(in Float2 first, in Float2 second) => first.Equals(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(in Float2 first, in Float2 second) => !first.Equals(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Float2 other && Equals(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Float2 other)
		{
			double dx = x - other.x;
			double dy = y - other.y;
			return AlmostEqualsZero(dx * dx + dy * dy);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(float value) => new Float2(value, value);

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float2(UnityEngine.Vector2 value) => new Float2(value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector2(Float2 value) => new UnityEngine.Vector2(value.x, value.y);
#endif

		[MethodImpl(MethodImplOptions.AggressiveInlining)] static bool AlmostEqualsZero(double squaredMagnitude) => Scalars.AlmostEquals(squaredMagnitude, 0d);

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