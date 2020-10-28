using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CodeHelpers.Vectors
{
	[Serializable]
	public readonly struct Int2 : IEquatable<Int2>, IEnumerable<int>, IFormattable
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Int2(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public readonly int x;
		public readonly int y;

#region Swizzled3

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXX => new Int3(x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXY => new Int3(x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XX_ => new Int3(x, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYX => new Int3(x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYY => new Int3(x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XY_ => new Int3(x, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X_X => new Int3(x, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X_Y => new Int3(x, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X__ => new Int3(x, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXX => new Int3(y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXY => new Int3(y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YX_ => new Int3(y, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYX => new Int3(y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYY => new Int3(y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YY_ => new Int3(y, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y_X => new Int3(y, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y_Y => new Int3(y, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y__ => new Int3(y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _XX => new Int3(0, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _XY => new Int3(0, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _X_ => new Int3(0, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _YX => new Int3(0, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _YY => new Int3(0, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _Y_ => new Int3(0, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 __X => new Int3(0, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 __Y => new Int3(0, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ___ => new Int3(0, 0, 0);

#endregion

#region Swizzled2

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XX => new Int2(x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XY => new Int2(x, y);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YX => new Int2(y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YY => new Int2(y, y);

#endregion

#region Static Properties

		public static readonly Int2 right = new Int2(1, 0);
		public static readonly Int2 left = new Int2(-1, 0);

		public static readonly Int2 up = new Int2(0, 1);
		public static readonly Int2 down = new Int2(0, -1);

		public static readonly Int2 one = new Int2(1, 1);
		public static readonly Int2 zero = new Int2(0, 0);
		public static readonly Int2 negativeOne = new Int2(-1, -1);

		public static readonly Int2 mxxValue = new Int2(int.MaxValue, int.MaxValue);
		public static readonly Int2 minValue = new Int2(int.MinValue, int.MinValue);

		//NOTE: These collections are not in any guaranteed order!

		public static readonly ReadOnlyCollection<Int2> units4 = new ReadOnlyCollection<Int2>
		(
			new[]
			{
				new Int2(0, 0), new Int2(1, 0),
				new Int2(0, 1), new Int2(1, 1)
			}
		);

		public static readonly ReadOnlyCollection<Int2> edges4 = new ReadOnlyCollection<Int2>
		(
			new[]
			{
				new Int2(1, 0), new Int2(0, 1),
				new Int2(-1, 0), new Int2(0, -1)
			}
		);

		public static readonly ReadOnlyCollection<Int2> vertices4 = new ReadOnlyCollection<Int2>
		(
			new[]
			{
				new Int2(1, 1), new Int2(-1, 1),
				new Int2(-1, -1), new Int2(1, -1)
			}
		);

		public static readonly ReadOnlyCollection<Int2> edgesVertices8 = new ReadOnlyCollection<Int2>(edges4.Concat(vertices4).ToArray());

#endregion

#region Simple Properties

#region Scaler Returns

		public float Magnitude
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (float)MagnitudeLong;
		}

		public double MagnitudeLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Sqrt(SquaredMagnitudeLong);
		}

		public int SquaredMagnitude
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x * x + y * y;
		}

		public long SquaredMagnitudeLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)x * x + (long)y * y;
		}

		public int Product
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x * y;
		}

		public long ProductLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)x * y;
		}

		public int ProductAbsoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs(x * y);
		}

		public long ProductAbsolutedLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs((long)x * y);
		}

		public int Sum
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x + y;
		}

		public long SumLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)x + y;
		}

		public int MinComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x < y ? x : y;
		}

		public int MinIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x < y ? 0 : 1;
		}

		public int MaxComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x > y ? x : y;
		}

		public int MaxIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x > y ? 0 : 1;
		}

		public int this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
#if UNSAFE_CODE_ENABLED
				unsafe
				{
					if (index < 0 || 1 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
					fixed (Int2* pointer = &this) return ((int*)pointer)[index];
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

#region Int2 Returns

		public Int2 Absoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int2(Math.Abs(x), Math.Abs(y));
		}

		public Int2 Signed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int2(x.Sign(), y.Sign());
		}

		public Float2 Normalized
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				long squared = SquaredMagnitudeLong;
				if (squared == 0) return Float2.zero;

				return this / (float)Math.Sqrt(squared);
			}
		}

		public Int2 Perpendicular
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int2(-y, x);
		}

		public Int2 Sorted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x < y ? XY : YX;
		}

		public Int2 SortedReversed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x > y ? XY : YX;
		}

#endregion

#endregion

#region Methods

#region Instance

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public int Dot(Int2 other) => x * other.x + y * other.y;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public long DotLong(Int2 other) => (long)x * other.x + (long)y * other.y;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Angle(Int2 other) => Math.Abs(SignedAngle(other));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SignedAngle(Int2 other) => (float)Math.Atan2((long)x * other.y - (long)y * other.x, DotLong(other)) * Scalars.RadianToDegree;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Min(Int2 other) => new Int2(Math.Min(x, other.x), Math.Min(y, other.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Max(Int2 other) => new Int2(Math.Max(x, other.x), Math.Max(y, other.y));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Clamp(Int2 min, Int2 max) => new Int2(x.Clamp(min.x, max.x), y.Clamp(min.y, max.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Clamp(int min, int max) => new Int2(x.Clamp(min, max), y.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Clamp(Float2 min, Float2 max) => new Float2(x.Clamp(min.x, max.x), y.Clamp(min.y, max.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Clamp(float min, float max) => new Float2(x.Clamp(min, max), y.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2 ClampMagnitude(float max)
		{
			double squared = SquaredMagnitudeLong;
			if (squared <= (double)max * max) return this;

			float scale = max / (float)Math.Sqrt(squared);
			return new Float2(x * scale, y * scale);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Lerp(Int2 other, Int2 value) => new Int2(Scalars.Lerp(x, other.x, value.x), Scalars.Lerp(y, other.y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Lerp(Int2 other, int value) => new Int2(Scalars.Lerp(x, other.x, value), Scalars.Lerp(y, other.y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Lerp(Int2 other, Float2 value) => new Float2(Scalars.Lerp(x, other.x, value.x), Scalars.Lerp(y, other.y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Lerp(Int2 other, float value) => new Float2(Scalars.Lerp(x, other.x, value), Scalars.Lerp(y, other.y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 InverseLerp(Int2 other, Int2 value) => new Int2(Scalars.InverseLerp(x, other.x, value.x), Scalars.InverseLerp(y, other.y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 InverseLerp(Int2 other, int value) => new Int2(Scalars.InverseLerp(x, other.x, value), Scalars.InverseLerp(y, other.y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 InverseLerp(Int2 other, Float2 value) => new Float2(Scalars.InverseLerp(x, other.x, value.x), Scalars.InverseLerp(y, other.y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 InverseLerp(Int2 other, float value) => new Float2(Scalars.InverseLerp(x, other.x, value), Scalars.InverseLerp(y, other.y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Repeat(Int2 length) => new Int2(x.Repeat(length.x), y.Repeat(length.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Repeat(int length) => new Int2(x.Repeat(length), y.Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Repeat(Float2 length) => new Float2(((float)x).Repeat(length.x), ((float)y).Repeat(length.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Repeat(float length) => new Float2(((float)x).Repeat(length), ((float)y).Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 FlooredDivide(Int2 divisor) => new Int2(x.FlooredDivide(divisor.x), y.FlooredDivide(divisor.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 FlooredDivide(int divisor) => new Int2(x.FlooredDivide(divisor), y.FlooredDivide(divisor));

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

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Damp(Float2 target, ref Float2 velocity, Float2 smoothTime, float deltaTime) => Float2.Damp(this, target, ref velocity, smoothTime, deltaTime);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Damp(Float2 target, ref Float2 velocity, float smoothTime, float deltaTime) => Float2.Damp(this, target, ref velocity, smoothTime, deltaTime);

#endregion

#region Static

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static int Dot(Int2 first, Int2 second) => first.Dot(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static long DotLong(Int2 first, Int2 second) => first.DotLong(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Angle(Int2 first, Int2 second) => first.Angle(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float SignedAngle(Int2 first, Int2 second) => first.SignedAngle(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Min(Int2 first, Int2 second) => first.Min(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Max(Int2 first, Int2 second) => first.Max(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Clamp(Int2 value, Int2 min, Int2 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Clamp(Int2 value, int min, int max) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Clamp(Int2 value, Float2 min, Float2 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Clamp(Int2 value, float min, float max) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 ClampMagnitude(Int2 value, float max) => value.ClampMagnitude(max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Lerp(Int2 first, Int2 second, Int2 value) => first.Lerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Lerp(Int2 first, Int2 second, int value) => first.Lerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Lerp(Int2 first, Int2 second, Float2 value) => first.Lerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Lerp(Int2 first, Int2 second, float value) => first.Lerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 InverseLerp(Int2 first, Int2 second, Int2 value) => first.InverseLerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 InverseLerp(Int2 first, Int2 second, int value) => first.InverseLerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 InverseLerp(Int2 first, Int2 second, Float2 value) => first.InverseLerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 InverseLerp(Int2 first, Int2 second, float value) => first.InverseLerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Repeat(Int2 value, Int2 length) => value.Repeat(length);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Repeat(Int2 value, int length) => value.Repeat(length);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Repeat(Int2 value, Float2 length) => value.Repeat(length);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Repeat(Int2 value, float length) => value.Repeat(length);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 FlooredDivide(Int2 value, Int2 divisor) => value.FlooredDivide(divisor);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 FlooredDivide(Int2 value, int divisor) => value.FlooredDivide(divisor);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Rotate(Int2 value, float degree) => value.Rotate(degree);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Rotate(Int2 value, float degree, Float2 pivot) => value.Rotate(degree, pivot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Damp(Int2 current, Float2 target, ref Float2 velocity, Float2 smoothTime, float deltaTime) => Float2.Damp(current, target, ref velocity, smoothTime, deltaTime);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Damp(Int2 current, Float2 target, ref Float2 velocity, float smoothTime, float deltaTime) => Float2.Damp(current, target, ref velocity, smoothTime, deltaTime);

#endregion

#region Create

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int2 Create(int index, int value)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 1 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Int2 result = default;
				((int*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Int2(value, 0);
				case 1:  return new Int2(0, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int2 Create(int index, int value, int other)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 1 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Int2 result = new Int2(other, other);
				((int*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Int2(value, other);
				case 1:  return new Int2(other, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int2 CreateX(int value, int other = 0) => new Int2(value, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int2 CreateY(int value, int other = 0) => new Int2(other, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int3 CreateXY(int other = 0) => Int3.CreateXY(this, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int3 CreateYZ(int other = 0) => Int3.CreateYZ(this, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int3 CreateXZ(int other = 0) => Int3.CreateXZ(this, other);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 CreateXY(float other) => Float3.CreateXY(this, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 CreateYZ(float other) => Float3.CreateYZ(this, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 CreateXZ(float other) => Float3.CreateXZ(this, other);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Int2 Replace(int index, int value)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 1 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Int2 result = this; //Make a copy of this struct
				((int*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Int2(value, y);
				case 1:  return new Int2(x, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

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
				case 0:  return new Float3(value, y);
				case 1:  return new Float3(x, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int2 ReplaceX(int value) => new Int2(value, y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int2 ReplaceY(int value) => new Int2(x, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float2 ReplaceX(float value) => new Float2(value, y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float2 ReplaceY(float value) => new Float2(x, value);

#if CODEHELPERS_UNITY
		public UnityEngine.Vector2Int U() => new UnityEngine.Vector2Int(x, y);
#endif

#endregion

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator +(in Int2 first, in Int2 second) => new Int2(first.x + second.x, first.y + second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator -(in Int2 first, in Int2 second) => new Int2(first.x - second.x, first.y - second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator +(in Int2 first, in Float2 second) => new Float2(first.x + second.x, first.y + second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator -(in Int2 first, in Float2 second) => new Float2(first.x - second.x, first.y - second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator +(in Float2 first, in Int2 second) => new Float2(first.x + second.x, first.y + second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator -(in Float2 first, in Int2 second) => new Float2(first.x - second.x, first.y - second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator *(in Int2 first, in Int2 second) => new Int2(first.x * second.x, first.y * second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator /(in Int2 first, in Int2 second) => new Int2(first.x / second.x, first.y / second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(in Int2 first, in Float2 second) => new Float2(first.x * second.x, first.y * second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(in Int2 first, in Float2 second) => new Float2(first.x / second.x, first.y / second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(in Float2 first, in Int2 second) => new Float2(first.x * second.x, first.y * second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(in Float2 first, in Int2 second) => new Float2(first.x / second.x, first.y / second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator *(in Int2 first, int second) => new Int2(first.x * second, first.y * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator /(in Int2 first, int second) => new Int2(first.x / second, first.y / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(in Int2 first, float second) => new Float2(first.x * second, first.y * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(in Int2 first, float second) => new Float2(first.x / second, first.y / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator *(int first, in Int2 second) => new Int2(first * second.x, first * second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator /(int first, in Int2 second) => new Int2(first / second.x, first / second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(float first, in Int2 second) => new Float2(first * second.x, first * second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(float first, in Int2 second) => new Float2(first / second.x, first / second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator -(in Int2 value) => new Int2(-value.x, -value.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator %(in Int2 first, in Int2 second) => new Int2(first.x % second.x, first.y % second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(in Int2 first, in Float2 second) => new Float2(first.x % second.x, first.y % second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(in Float2 first, in Int2 second) => new Float2(first.x % second.x, first.y % second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator %(in Int2 first, int second) => new Int2(first.x % second, first.y % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator %(int first, in Int2 second) => new Int2(first % second.x, first % second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(in Int2 first, float second) => new Float2(first.x % second, first.y % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(float first, in Int2 second) => new Float2(first % second.x, first % second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(in Int2 first, in Int2 second) => first.Equals(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(in Int2 first, in Int2 second) => !first.Equals(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Int2 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Int2 other) => x == other.x && y == other.y;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(int value) => new Int2(value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float2(Int2 value) => new Float2(value.x, value.y);

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Int2(UnityEngine.Vector2Int value) => new Int2(value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector2Int(Int2 value) => new UnityEngine.Vector2Int(value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector2(Int2 value) => new UnityEngine.Vector2(value.x, value.y);
#endif

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
			public Enumerator(Int2 source)
			{
				this.source = source;
				index = -1;
			}

			readonly Int2 source;
			int index;

			object IEnumerator.Current => Current;
			public int Current => source[index];

			public bool MoveNext()
			{
				if (index == 1) return false;

				index++;
				return true;
			}

			public void Reset() => index = -1;

			public void Dispose() { }
		}

		public readonly struct LoopEnumerable : IEnumerable<Int2>
		{
			public LoopEnumerable(Int2 value, bool zeroAsOne) => enumerator = new LoopEnumerator(value, zeroAsOne);

			readonly LoopEnumerator enumerator;

			public LoopEnumerator GetEnumerator() => enumerator;

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			IEnumerator<Int2> IEnumerable<Int2>.GetEnumerator() => GetEnumerator();

			/// <summary>
			/// NOTE: Do NOT use the readonly modifier if you wish the <see cref="MoveNext"/> method would behave correctly
			/// </summary>
			public struct LoopEnumerator : IEnumerator<Int2>
			{
				internal LoopEnumerator(Int2 size, bool zeroAsOne)
				{
					direction = size.Absoluted;
					size = size.Absoluted;

					sizeY = zeroAsOne && size.y == 0 ? 1 : size.y;
					product = size.Product;

					current = -1;
				}

				readonly Int2 direction;
				readonly int sizeY;

				readonly int product;
				int current;

				object IEnumerator.Current => Current;

				public Int2 Current => new Int2
				(
					current / sizeY * direction.x,
					current % sizeY * direction.y
				);

				public bool MoveNext() => ++current < product;

				public void Reset() => current = -1;
				public void Dispose() { }
			}
		}

#endregion

	}
}