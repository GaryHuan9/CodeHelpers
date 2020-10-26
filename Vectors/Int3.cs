using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CodeHelpers.Vectors
{
	public readonly struct Int3 : IEquatable<Int3>, IEnumerable<int>, IFormattable
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Int3(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public readonly int x;
		public readonly int y;
		public readonly int z;

#region Swizzled3

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXX => new Int3(x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXY => new Int3(x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXZ => new Int3(x, x, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYX => new Int3(x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYY => new Int3(x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYZ => new Int3(x, y, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZX => new Int3(x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZY => new Int3(x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZZ => new Int3(x, z, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXX => new Int3(y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXY => new Int3(y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXZ => new Int3(y, x, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYX => new Int3(y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYY => new Int3(y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYZ => new Int3(y, y, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZX => new Int3(y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZY => new Int3(y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZZ => new Int3(y, z, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXX => new Int3(z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXY => new Int3(z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXZ => new Int3(z, x, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYX => new Int3(z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYY => new Int3(z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYZ => new Int3(z, y, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZX => new Int3(z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZY => new Int3(z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZZ => new Int3(z, z, z);

#endregion

#region Swizzled2

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XX => new Int2(x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XY => new Int2(x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XZ => new Int2(x, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YX => new Int2(y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YY => new Int2(y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YZ => new Int2(y, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 ZX => new Int2(z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 ZY => new Int2(z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 ZZ => new Int2(z, z);

#endregion

#region Static Properties

		public static readonly Int3 right = new Int3(1, 0, 0);
		public static readonly Int3 left = new Int3(-1, 0, 0);

		public static readonly Int3 up = new Int3(0, 1, 0);
		public static readonly Int3 down = new Int3(0, -1, 0);

		public static readonly Int3 forward = new Int3(0, 0, 1);
		public static readonly Int3 backward = new Int3(0, 0, -1);

		public static readonly Int3 one = new Int3(1, 1, 1);
		public static readonly Int3 zero = new Int3(0, 0, 0);
		public static readonly Int3 negativeOne = new Int3(-1, -1, -1);

		public static readonly Int3 maxValue = new Int3(int.MaxValue, int.MaxValue, int.MaxValue);
		public static readonly Int3 minValue = new Int3(int.MinValue, int.MinValue, int.MinValue);

#endregion

#region Simple Properties

#region Scaler Returns

		public float Magnitude
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (float)MagnitudeDouble;
		}

		public double MagnitudeDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Sqrt(SquaredMagnitudeLong);
		}

		public int SquaredMagnitude
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x * x + y * y + z * z;
		}

		public long SquaredMagnitudeLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)x * x + (long)y * y + (long)z * z;
		}

		public int Product
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x * y * z;
		}

		public long ProductLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)x * y * z;
		}

		public int ProductAbsoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs(x * y * z);
		}

		public long ProductAbsolutedLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs((long)x * y * z);
		}

		public int Sum
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x + y + z;
		}

		public long SumLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)x + y + z;
		}

		public int this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
#if UNSAFE_CODE_ENABLED
				unsafe
				{
					if (index < 0 || 2 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
					fixed (Int3* pointer = &this) return ((int*)pointer)[index];
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

#region Int3 Returns

		public Int3 Absoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3(Math.Abs(x), Math.Abs(y), Math.Abs(z));
		}

		public Int3 Signed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3(x.Signed(), y.Signed(), z.Signed());
		}

		public Float3 Normalized
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				long squared = SquaredMagnitudeLong;
				if (squared == 0) return Float3.zero;

				return this / (float)Math.Sqrt(squared);
			}
		}

		public Int3 Sorted
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

		public Int3 SortedReversed
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

#endregion

#endregion

#region Methods

#region Instance

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public int Dot(Int3 other) => x * other.x + y * other.y + z * other.z;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public long DotLong(Int3 other) => (long)x * other.x + (long)y * other.y + (long)z * other.z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Cross(Int3 other) => new Int3
		(
			(int)((long)y * other.z - (long)z * other.y),
			(int)((long)z * other.x - (long)x * other.z),
			(int)((long)x * other.y - (long)y * other.x)
		);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Angle(Int3 other)
		{
			double magnitude = Math.Sqrt(SquaredMagnitudeLong * other.SquaredMagnitudeLong);
			return Scalars.AlmostEquals(magnitude, 0d) ? 0f : (float)Math.Acos(DotLong(other) / magnitude) * Scalars.RadianToDegree;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SignedAngle(Int3 other, Int3 normal)
		{
			float angle = Angle(other);
			return Cross(other).Dot(normal) < 0f ? -angle : angle;
		}

#endregion

#region Static

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Min(Int3 first, Int3 second) => new Int3(Math.Min(first.x, second.x), Math.Min(first.y, second.y), Math.Min(first.z, second.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Max(Int3 first, Int3 second) => new Int3(Math.Max(first.x, second.x), Math.Max(first.y, second.y), Math.Max(first.z, second.z));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Lerp(Int3 first, Int3 second, Int3 value) => new Int3(Scalars.Lerp(first.x, second.x, value.x), Scalars.Lerp(first.y, second.y, value.y), Scalars.Lerp(first.z, second.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Lerp(Int3 first, Int3 second, int value) => new Int3(Scalars.Lerp(first.x, second.x, value), Scalars.Lerp(first.y, second.y, value), Scalars.Lerp(first.z, second.z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Lerp(Int3 first, Int3 second, Float3 value) => new Float3(Scalars.Lerp(first.x, second.x, value.x), Scalars.Lerp(first.y, second.y, value.y), Scalars.Lerp(first.z, second.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Lerp(Int3 first, Int3 second, float value) => new Float3(Scalars.Lerp(first.x, second.x, value), Scalars.Lerp(first.y, second.y, value), Scalars.Lerp(first.z, second.z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 InverseLerp(Int3 first, Int3 second, Int3 value) => new Int3(Scalars.InverseLerp(first.x, second.x, value.x), Scalars.InverseLerp(first.y, second.y, value.y), Scalars.InverseLerp(first.z, second.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 InverseLerp(Int3 first, Int3 second, int value) => new Int3(Scalars.InverseLerp(first.x, second.x, value), Scalars.InverseLerp(first.y, second.y, value), Scalars.InverseLerp(first.z, second.z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 InverseLerp(Int3 first, Int3 second, Float3 value) => new Float3(Scalars.InverseLerp(first.x, second.x, value.x), Scalars.InverseLerp(first.y, second.y, value.y), Scalars.InverseLerp(first.z, second.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 InverseLerp(Int3 first, Int3 second, float value) => new Float3(Scalars.InverseLerp(first.x, second.x, value), Scalars.InverseLerp(first.y, second.y, value), Scalars.InverseLerp(first.z, second.z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Repeat(Int3 value, Int3 divisor) => new Int3(value.x.FlooredDivide(divisor.x), value.y.FlooredDivide(divisor.y), value.z.FlooredDivide(divisor.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Repeat(Int3 value, Float3 divisor) => new Int3(value.x.FlooredDivide(divisor.x), value.y.FlooredDivide(divisor.y), value.z.FlooredDivide(divisor.z));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 FlooredDivide(Int3 value, Int3 divisor) => new Int3(value.x.FlooredDivide(divisor.x), value.y.FlooredDivide(divisor.y), value.z.FlooredDivide(divisor.z));

#endregion

#region Create

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int3 Create(int index, int value)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 2 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Int3 result = default;
				((int*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Int3(value, 0, 0);
				case 1:  return new Int3(0, value, 0);
				case 2:  return new Int3(0, 0, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateX(int value) => new Int3(value, 0, 0);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateY(int value) => new Int3(0, value, 0);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateZ(int value) => new Int3(0, 0, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateXY(Int2 value) => new Int3(value.x, value.y, 0);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateYZ(Int2 value) => new Int3(0, value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateXZ(Int2 value) => new Int3(value.x, 0, value.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Int3 Replace(int index, int value)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 2 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Int3 result = this; //Make a copy of this struct
				((int*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Int3(value, y, z);
				case 1:  return new Int3(x, value, z);
				case 2:  return new Int3(x, y, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

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

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int3 ReplaceX(int value) => new Int3(value, y, z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int3 ReplaceY(int value) => new Int3(x, value, z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int3 ReplaceZ(int value) => new Int3(x, y, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceX(float value) => new Float3(value, y, z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceY(float value) => new Float3(x, value, z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceZ(float value) => new Float3(x, y, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int3 ReplaceXY(Int2 value) => new Int3(value.x, value.y, z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int3 ReplaceYZ(Int2 value) => new Int3(x, value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int3 ReplaceXZ(Int2 value) => new Int3(value.x, y, value.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceXY(Float2 value) => new Float3(value.x, value.y, z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceYZ(Float2 value) => new Float3(x, value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceXZ(Float2 value) => new Float3(value.x, y, value.y);

#if CODEHELPERS_UNITY
		public UnityEngine.Vector3Int U() => new UnityEngine.Vector3Int(x, y, z);
#endif

#endregion

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator +(in Int3 first, in Int3 second) => new Int3(first.x + second.x, first.y + second.y, first.z + second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator -(in Int3 first, in Int3 second) => new Int3(first.x - second.x, first.y - second.y, first.z - second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator +(in Int3 first, in Float3 second) => new Float3(first.x + second.x, first.y + second.y, first.z + second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator -(in Int3 first, in Float3 second) => new Float3(first.x - second.x, first.y - second.y, first.z - second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator +(in Float3 first, in Int3 second) => new Float3(first.x + second.x, first.y + second.y, first.z + second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator -(in Float3 first, in Int3 second) => new Float3(first.x - second.x, first.y - second.y, first.z - second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator *(in Int3 first, in Int3 second) => new Int3(first.x * second.x, first.y * second.y, first.z * second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator /(in Int3 first, in Int3 second) => new Int3(first.x / second.x, first.y / second.y, first.z / second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(in Int3 first, in Float3 second) => new Float3(first.x * second.x, first.y * second.y, first.z * second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(in Int3 first, in Float3 second) => new Float3(first.x / second.x, first.y / second.y, first.z / second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(in Float3 first, in Int3 second) => new Float3(first.x * second.x, first.y * second.y, first.z * second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(in Float3 first, in Int3 second) => new Float3(first.x / second.x, first.y / second.y, first.z / second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator *(in Int3 first, int second) => new Int3(first.x * second, first.y * second, first.z * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator /(in Int3 first, int second) => new Int3(first.x / second, first.y / second, first.z / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(in Int3 first, float second) => new Float3(first.x * second, first.y * second, first.z * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(in Int3 first, float second) => new Float3(first.x / second, first.y / second, first.z / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator *(int first, in Int3 second) => new Int3(first * second.x, first * second.y, first * second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator /(int first, in Int3 second) => new Int3(first / second.x, first / second.y, first / second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(float first, in Int3 second) => new Float3(first * second.x, first * second.y, first * second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(float first, in Int3 second) => new Float3(first / second.x, first / second.y, first / second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator -(in Int3 value) => new Int3(-value.x, -value.y, -value.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator %(in Int3 first, in Int3 second) => new Int3(first.x % second.x, first.y % second.y, first.z % second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(in Int3 first, in Float3 second) => new Float3(first.x % second.x, first.y % second.y, first.z % second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(in Float3 first, in Int3 second) => new Float3(first.x % second.x, first.y % second.y, first.z % second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator %(in Int3 first, int second) => new Int3(first.x % second, first.y % second, first.z % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator %(int first, in Int3 second) => new Int3(first % second.x, first % second.y, first % second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(in Int3 first, float second) => new Float3(first.x % second, first.y % second, first.z % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(float first, in Int3 second) => new Float3(first % second.x, first % second.y, first % second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(in Int3 first, in Int3 second) => first.Equals(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(in Int3 first, in Int3 second) => !first.Equals(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Int3 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Int3 other) => x == other.x && y == other.y && z == other.z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(int value) => new Int3(value, value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float3(Int3 value) => new Float3(value.x, value.y, value.z);

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Int3(UnityEngine.Vector3Int value) => new Int3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector3Int(Int3 value) => new UnityEngine.Vector3Int(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator UnityEngine.Vector3(Int3 value) => new UnityEngine.Vector3(value.x, value.y, value.z);
#endif

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

#region Enumerations

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		IEnumerator<int> IEnumerable<int>.GetEnumerator() => GetEnumerator();

		public Enumerator GetEnumerator() => new Enumerator(this);

		/// <summary>
		/// Returns an enumerable that can be put into a foreach loop; from (0,0,0) to (vector.x-1,vector.y-1,vector.z-1)
		/// If <paramref name="zeroAsOne"/> is true then the loop will treat zeros in the vector as ones.
		/// </summary>
		public LoopEnumerable Loop(bool zeroAsOne = false) => new LoopEnumerable(this, zeroAsOne);

		public struct Enumerator : IEnumerator<int>
		{
			public Enumerator(Int3 source)
			{
				this.source = source;
				index = -1;
			}

			readonly Int3 source;
			int index;

			object IEnumerator.Current => Current;
			public int Current => source[index];

			public bool MoveNext()
			{
				if (index == 2) return false;

				index++;
				return true;
			}

			public void Reset() => index = -1;

			public void Dispose() { }
		}

		public readonly struct LoopEnumerable : IEnumerable<Int3>
		{
			public LoopEnumerable(Int3 vector, bool zeroAsOne) => enumerator = new LoopEnumerator(vector, zeroAsOne);

			readonly LoopEnumerator enumerator;

			public LoopEnumerator GetEnumerator() => enumerator;

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			IEnumerator<Int3> IEnumerable<Int3>.GetEnumerator() => GetEnumerator();

			/// <summary>
			/// NOTE: Do NOT use the readonly modifier if you wish the <see cref="MoveNext"/> method would behave correctly
			/// </summary>
			public struct LoopEnumerator : IEnumerator<Int3>
			{
				internal LoopEnumerator(Int3 size, bool zeroAsOne)
				{
					direction = (size.x < 0 ? 0b0001 : 0) | (size.y < 0 ? 0b0010 : 0) | (size.z < 0 ? 0b0100 : 0);

					size = size.Absoluted;

					this.size = zeroAsOne ? Max(one, size) : size;
					product = size.Product;

					current = -1;
				}

				/// <summary>
				/// Bit vector indicating whether an axis should be negated or not.
				/// Using int because byte will be allocated into four bytes anyways
				/// </summary>
				readonly int direction;

				readonly Int3 size;
				readonly int product;

				int current;

				object IEnumerator.Current => Current;

				public Int3 Current => new Int3
				(
					current / (size.y * size.z) * ((direction & 0b0001) == 0 ? 1 : -1),
					current / size.z % size.y * ((direction & 0b0010) == 0 ? 1 : -1),
					current % size.z * ((direction & 0b0100) == 0 ? 1 : -1)
				);

				public bool MoveNext()
				{
					if (current + 1 >= product) return false;
					current++;
					return true;
				}

				public void Reset() => current = -1;

				public void Dispose() { }
			}
		}

#endregion

	}
}