using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CodeHelpers.Vectors
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

#region Swizzled2

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XX => new Float2(x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XY => new Float2(x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XZ => new Float2(x, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YX => new Float2(y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YY => new Float2(y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YZ => new Float2(y, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZX => new Float2(z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZY => new Float2(z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZZ => new Float2(z, z);

#endregion

#region Static Properties

		public static readonly Float3 right = new Float3(1f, 0f, 0f);
		public static readonly Float3 left = new Float3(-1f, 0f, 0f);

		public static readonly Float3 up = new Float3(0f, 1f, 0f);
		public static readonly Float3 down = new Float3(0f, -1f, 0f);

		public static readonly Float3 forward = new Float3(0f, 0f, 1f);
		public static readonly Float3 backward = new Float3(0f, 0f, -1f);

		public static readonly Float3 zero = new Float3(0f, 0f, 0f);

		public static readonly Float3 one = new Float3(1f, 1f, 1f);
		public static readonly Float3 negativeOne = new Float3(-1f, -1f, -1f);

		public static readonly Float3 half = new Float3(0.5f, 0.5f, 0.5f);
		public static readonly Float3 negativeHalf = new Float3(-0.5f, -0.5f, -0.5f);

		public static readonly Float3 maxValue = new Float3(float.MaxValue, float.MaxValue, float.MaxValue);
		public static readonly Float3 minValue = new Float3(float.MinValue, float.MinValue, float.MinValue);

		public static readonly Float3 positiveInfinity = new Float3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
		public static readonly Float3 negativeInfinity = new Float3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

		public static readonly Float3 epsilon = new Float3(Scalars.Epsilon, Scalars.Epsilon, Scalars.Epsilon);
		public static readonly Float3 NaN = new Float3(float.NaN, float.NaN, float.NaN);

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
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x * x + y * y + z * z;
		}

		public double SquaredMagnitudeDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)x * x + (double)y * y + (double)z * z;
		}

		public float Product
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x * y * z;
		}

		public double ProductDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)x * y * z;
		}

		public float ProductAbsoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs(x * y * z);
		}

		public double ProductAbsolutedDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs((double)x * y * z);
		}

		public float Sum
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x + y + z;
		}

		public double SumDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)x + y + z;
		}

		public float MinComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x < y) return x < z ? x : z;
				return y < z ? y : z;
			}
		}

		public int MinIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x < y) return x < z ? 0 : 2;
				return y < z ? 1 : 2;
			}
		}

		public float MaxComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x > y) return x > z ? x : z;
				return y > z ? y : z;
			}
		}

		public int MaxIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x > y) return x > z ? 0 : 2;
				return y > z ? 1 : 2;
			}
		}

		public float this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
#if UNSAFE_CODE_ENABLED
				unsafe
				{
					if (index < 0 || 2 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
					fixed (Float3* pointer = &this) return ((float*)pointer)[index];
				}
#else
				switch (index)
				{
					case 0: return x;
					case 1: return y;
					case 2: return z;
				}

				throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
#endif
			}
		}

#endregion

#region Float3 Returns

		public Float3 Absoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float3(Math.Abs(x), Math.Abs(y), Math.Abs(z));
		}

		public Int3 Signed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3(x.Sign(), y.Sign(), z.Sign());
		}

		public Float3 Normalized
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				double squared = SquaredMagnitudeDouble;
				if (AlmostEqualsZero(squared)) return zero;

				return this / (float)Math.Sqrt(squared);
			}
		}

		public Float3 Sorted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x < y)
				{
					if (y < z) return XYZ;
					if (x < z) return XZY;

					return ZXY;
				}

				if (x < z) return YXZ;
				if (y < z) return YZX;

				return ZYX;
			}
		}

		public Float3 SortedReversed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x > y)
				{
					if (y > z) return XYZ;
					if (x > z) return XZY;

					return ZXY;
				}

				if (x > z) return YXZ;
				if (y > z) return YZX;

				return ZYX;
			}
		}

		public Int3 Floored
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3((int)Math.Floor(x), (int)Math.Floor(y), (int)Math.Floor(z));
		}

		public Float3 FlooredFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float3((float)Math.Floor(x), (float)Math.Floor(y), (float)Math.Floor(z));
		}

		public Int3 Ceiled
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3((int)Math.Ceiling(x), (int)Math.Ceiling(y), (int)Math.Ceiling(z));
		}

		public Float3 CeiledFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float3((float)Math.Ceiling(x), (float)Math.Ceiling(y), (float)Math.Ceiling(z));
		}

		public Int3 Rounded
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3((int)Math.Round(x), (int)Math.Round(y), (int)Math.Round(z));
		}

		public Float3 RoundedFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float3((float)Math.Round(x), (float)Math.Round(y), (float)Math.Round(z));
		}

#endregion

#endregion

#region Methods

#region Instance

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Dot(Float3 other) => x * other.x + y * other.y + z * other.z;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DotDouble(Float3 other) => (double)x * other.x + (double)y * other.y + (double)z * other.z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Cross(Float3 other) => new Float3
		(
			(float)((double)y * other.z - (double)z * other.y),
			(float)((double)z * other.x - (double)x * other.z),
			(float)((double)x * other.y - (double)y * other.x)
		);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Angle(Float3 other)
		{
			double magnitude = Math.Sqrt(SquaredMagnitudeDouble * other.SquaredMagnitudeDouble);
			return AlmostEqualsZero(magnitude) ? 0f : (float)Math.Acos(DotDouble(other) / magnitude) * Scalars.RadianToDegree;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SignedAngle(Float3 other, Float3 normal)
		{
			float angle = Angle(other);
			return Cross(other).Dot(normal) < 0f ? -angle : angle;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Min(Float3 other) => new Float3(Math.Min(x, other.x), Math.Min(y, other.y), Math.Min(z, other.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Max(Float3 other) => new Float3(Math.Max(x, other.x), Math.Max(y, other.y), Math.Max(z, other.z));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Clamp(Float3 min, Float3 max) => new Float3(x.Clamp(min.x, max.x), y.Clamp(min.y, max.y), z.Clamp(min.z, max.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Clamp(float min, float max) => new Float3(x.Clamp(min, max), y.Clamp(min, max), z.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3 ClampMagnitude(float max)
		{
			double squared = SquaredMagnitudeDouble;
			if (squared <= (double)max * max) return this;

			float scale = max / (float)Math.Sqrt(squared);
			return new Float3(x * scale, y * scale, z * scale);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Lerp(Float3 other, Float3 value) => new Float3(Scalars.Lerp(x, other.x, value.x), Scalars.Lerp(y, other.y, value.y), Scalars.Lerp(z, other.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Lerp(Float3 other, float value) => new Float3(Scalars.Lerp(x, other.x, value), Scalars.Lerp(y, other.y, value), Scalars.Lerp(z, other.z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 InverseLerp(Float3 other, Float3 value) => new Float3(Scalars.InverseLerp(x, other.x, value.x), Scalars.InverseLerp(y, other.y, value.y), Scalars.InverseLerp(z, other.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 InverseLerp(Float3 other, float value) => new Float3(Scalars.InverseLerp(x, other.x, value), Scalars.InverseLerp(y, other.y, value), Scalars.InverseLerp(z, other.z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Repeat(Float3 length) => new Float3(x.Repeat(length.x), y.Repeat(length.y), z.Repeat(length.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Repeat(float length) => new Float3(x.Repeat(length), y.Repeat(length), z.Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXY(float degree) => CreateXY(XY.Rotate(degree), z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXY(float degree, Float2 pivot) => CreateXY(XY.Rotate(degree, pivot), z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXY(float degree, Float3 pivot) => CreateXY(XY.Rotate(degree, pivot.XY), z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXZ(float degree) => CreateXZ(XZ.Rotate(degree), y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXZ(float degree, Float2 pivot) => CreateXZ(XZ.Rotate(degree, pivot), y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXZ(float degree, Float3 pivot) => CreateXZ(XZ.Rotate(degree, pivot.XZ), y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateYZ(float degree) => CreateYZ(YZ.Rotate(degree), x);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateYZ(float degree, Float2 pivot) => CreateYZ(YZ.Rotate(degree, pivot), x);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateYZ(float degree, Float3 pivot) => CreateYZ(YZ.Rotate(degree, pivot.YZ), x);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3 Damp(Float3 target, ref Float3 velocity, Float3 smoothTime, float deltaTime)
		{
			float velocityX = velocity.x;
			float velocityY = velocity.y;
			float velocityZ = velocity.z;

			Float3 result = new Float3
			(
				Scalars.Damp(x, target.x, ref velocityX, smoothTime.x, deltaTime),
				Scalars.Damp(y, target.y, ref velocityY, smoothTime.y, deltaTime),
				Scalars.Damp(z, target.z, ref velocityZ, smoothTime.z, deltaTime)
			);

			velocity = new Float3(velocityX, velocityY, velocityZ);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3 Damp(Float3 target, ref Float3 velocity, float smoothTime, float deltaTime)
		{
			float velocityX = velocity.x;
			float velocityY = velocity.y;
			float velocityZ = velocity.z;

			Float3 result = new Float3
			(
				Scalars.Damp(x, target.x, ref velocityX, smoothTime, deltaTime),
				Scalars.Damp(y, target.y, ref velocityY, smoothTime, deltaTime),
				Scalars.Damp(z, target.z, ref velocityZ, smoothTime, deltaTime)
			);

			velocity = new Float3(velocityX, velocityY, velocityZ);
			return result;
		}

		//Although this looks heavy, compared to unpacked. After the compiler's release mode optimizations there is basically no difference.
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Reflect(Float3 normal) => -2f * Dot(normal) * normal + this;

#endregion

#region Static

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Dot(Float3 first, Float3 second) => first.Dot(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double DotDouble(Float3 first, Float3 second) => first.DotDouble(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Cross(Float3 first, Float3 second) => first.Cross(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Angle(Float3 first, Float3 second) => first.Angle(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float SignedAngle(Float3 first, Float3 second, Float3 normal) => first.SignedAngle(second, normal);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Min(Float3 first, Float3 second) => first.Min(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Max(Float3 first, Float3 second) => first.Max(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Clamp(Float3 value, Float3 min, Float3 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Clamp(Float3 value, float min, float max) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 ClampMagnitude(Float3 value, float max) => value.ClampMagnitude(max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Lerp(Float3 first, Float3 second, Float3 value) => first.Lerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Lerp(Float3 first, Float3 second, float value) => first.Lerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 InverseLerp(Float3 first, Float3 second, Float3 value) => first.InverseLerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 InverseLerp(Float3 first, Float3 second, float value) => first.InverseLerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Repeat(Float3 value, Float3 length) => value.Repeat(length);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Repeat(Float3 value, float length) => value.Repeat(length);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXY(Float3 value, float degree) => value.RotateXY(degree);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXY(Float3 value, float degree, Float2 pivot) => value.RotateXY(degree, pivot);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXY(Float3 value, float degree, Float3 pivot) => value.RotateXY(degree, pivot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXZ(Float3 value, float degree) => value.RotateXZ(degree);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXZ(Float3 value, float degree, Float2 pivot) => value.RotateXZ(degree, pivot);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXZ(Float3 value, float degree, Float3 pivot) => value.RotateXZ(degree, pivot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateYZ(Float3 value, float degree) => value.RotateYZ(degree);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateYZ(Float3 value, float degree, Float2 pivot) => value.RotateYZ(degree, pivot);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateYZ(Float3 value, float degree, Float3 pivot) => value.RotateYZ(degree, pivot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Damp(Float3 current, Float3 target, ref Float3 velocity, Float3 smoothTime, float deltaTime) => current.Damp(target, ref velocity, smoothTime, deltaTime);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Damp(Float3 current, Float3 target, ref Float3 velocity, float smoothTime, float deltaTime) => current.Damp(target, ref velocity, smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Reflect(Float3 value, Float3 normal) => value.Reflect(normal);

#endregion

#region Create

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Float3 Create(int index, float value)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 2 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Float3 result = default;
				((float*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Float3(value, 0f, 0f);
				case 1:  return new Float3(0f, value, 0f);
				case 2:  return new Float3(0f, 0f, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Float3 Create(int index, float value, float other)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 2 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Float3 result = new Float3(other, other, other);
				((float*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Float3(value, other, other);
				case 1:  return new Float3(other, value, other);
				case 2:  return new Float3(other, other, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float3 CreateX(float value, float other = 0f) => new Float3(value, other, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float3 CreateY(float value, float other = 0f) => new Float3(other, value, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float3 CreateZ(float value, float other = 0f) => new Float3(other, other, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float3 CreateXY(Float2 value, float other = 0f) => new Float3(value.x, value.y, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float3 CreateYZ(Float2 value, float other = 0f) => new Float3(other, value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float3 CreateXZ(Float2 value, float other = 0f) => new Float3(value.x, other, value.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3 Replace(int index, float value)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 2 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Float3 result = this; //Make a copy of this struct
				((float*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Float3(value, y, z);
				case 1:  return new Float3(x, value, z);
				case 2:  return new Float3(x, y, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceX(float value) => new Float3(value, y, z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceY(float value) => new Float3(x, value, z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceZ(float value) => new Float3(x, y, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceXY(Float2 value) => new Float3(value.x, value.y, z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceYZ(Float2 value) => new Float3(x, value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceXZ(Float2 value) => new Float3(value.x, y, value.y);

#if CODEHELPERS_UNITY
		public UnityEngine.Vector3 U() => new UnityEngine.Vector3(x, y, z);
#endif

#endregion

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator +(in Float3 first, in Float3 second) => new Float3(first.x + second.x, first.y + second.y, first.z + second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator -(in Float3 first, in Float3 second) => new Float3(first.x - second.x, first.y - second.y, first.z - second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(in Float3 first, in Float3 second) => new Float3(first.x * second.x, first.y * second.y, first.z * second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(in Float3 first, in Float3 second) => new Float3(first.x / second.x, first.y / second.y, first.z / second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(in Float3 first, float second) => new Float3(first.x * second, first.y * second, first.z * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(in Float3 first, float second) => new Float3(first.x / second, first.y / second, first.z / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(float first, in Float3 second) => new Float3(first * second.x, first * second.y, first * second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(float first, in Float3 second) => new Float3(first / second.x, first / second.y, first / second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator -(in Float3 value) => new Float3(-value.x, -value.y, -value.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(in Float3 first, in Float3 second) => new Float3(first.x % second.x, first.y % second.y, first.z % second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(in Float3 first, float second) => new Float3(first.x % second, first.y % second, first.z % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(float first, in Float3 second) => new Float3(first % second.x, first % second.y, first % second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(in Float3 first, in Float3 second) => first.Equals(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(in Float3 first, in Float3 second) => !first.Equals(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool EqualsExact(Float3 other) => x == other.x && y == other.y && z == other.z;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Float3 other && Equals(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Float3 other)
		{
			double dx = x - other.x;
			double dy = y - other.y;
			double dz = z - other.z;
			return AlmostEqualsZero(dx * dx + dy * dy + dz * dz);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(float value) => new Float3(value, value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(Float3 value) => new Int3((int)value.x, (int)value.y, (int)value.z);

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float3(UnityEngine.Vector3 value) => new Float3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector3(Float3 value) => new UnityEngine.Vector3(value.x, value.y, value.z);
#endif

		[MethodImpl(MethodImplOptions.AggressiveInlining)] static bool AlmostEqualsZero(double squaredMagnitude) => Scalars.AlmostEquals(squaredMagnitude, 0d);

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