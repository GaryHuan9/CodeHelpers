using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CodeHelpers.Mathematics
{
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct Float2 : IEquatable<Float2>, IFormattable
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		[FieldOffset(0)] public readonly float x;
		[FieldOffset(4)] public readonly float y;

#region Properties

#region Static

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

#region Instance

#region Swizzled

#region Four

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXX => new Float4(x, x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXY => new Float4(x, x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXX_ => new Float4(x, x, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYX => new Float4(x, x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYY => new Float4(x, x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXY_ => new Float4(x, x, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX_X => new Float4(x, x, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX_Y => new Float4(x, x, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX__ => new Float4(x, x, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXX => new Float4(x, y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXY => new Float4(x, y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYX_ => new Float4(x, y, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYX => new Float4(x, y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYY => new Float4(x, y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYY_ => new Float4(x, y, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY_X => new Float4(x, y, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY_Y => new Float4(x, y, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY__ => new Float4(x, y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_XX => new Float4(x, 0f, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_XY => new Float4(x, 0f, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_X_ => new Float4(x, 0f, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_YX => new Float4(x, 0f, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_YY => new Float4(x, 0f, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_Y_ => new Float4(x, 0f, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X__X => new Float4(x, 0f, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X__Y => new Float4(x, 0f, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X___ => new Float4(x, 0f, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXX => new Float4(y, x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXY => new Float4(y, x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXX_ => new Float4(y, x, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYX => new Float4(y, x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYY => new Float4(y, x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXY_ => new Float4(y, x, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX_X => new Float4(y, x, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX_Y => new Float4(y, x, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX__ => new Float4(y, x, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXX => new Float4(y, y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXY => new Float4(y, y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYX_ => new Float4(y, y, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYX => new Float4(y, y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYY => new Float4(y, y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYY_ => new Float4(y, y, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY_X => new Float4(y, y, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY_Y => new Float4(y, y, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY__ => new Float4(y, y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_XX => new Float4(y, 0f, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_XY => new Float4(y, 0f, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_X_ => new Float4(y, 0f, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_YX => new Float4(y, 0f, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_YY => new Float4(y, 0f, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_Y_ => new Float4(y, 0f, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y__X => new Float4(y, 0f, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y__Y => new Float4(y, 0f, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y___ => new Float4(y, 0f, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XXX => new Float4(0f, x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XXY => new Float4(0f, x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XX_ => new Float4(0f, x, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XYX => new Float4(0f, x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XYY => new Float4(0f, x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XY_ => new Float4(0f, x, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X_X => new Float4(0f, x, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X_Y => new Float4(0f, x, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X__ => new Float4(0f, x, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YXX => new Float4(0f, y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YXY => new Float4(0f, y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YX_ => new Float4(0f, y, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YYX => new Float4(0f, y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YYY => new Float4(0f, y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YY_ => new Float4(0f, y, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y_X => new Float4(0f, y, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y_Y => new Float4(0f, y, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y__ => new Float4(0f, y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __XX => new Float4(0f, 0f, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __XY => new Float4(0f, 0f, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __X_ => new Float4(0f, 0f, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __YX => new Float4(0f, 0f, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __YY => new Float4(0f, 0f, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __Y_ => new Float4(0f, 0f, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ___X => new Float4(0f, 0f, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ___Y => new Float4(0f, 0f, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ____ => new Float4(0f, 0f, 0f, 0f);

#endregion

#region Three

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

#region Two

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XX => new Float2(x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XY => new Float2(x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 X_ => new Float2(x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YX => new Float2(y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YY => new Float2(y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 Y_ => new Float2(y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 _X => new Float2(0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 _Y => new Float2(0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 __ => new Float2(0f, 0f);

#endregion

#endregion

#region Scalar Returns

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

		public float Average
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (float)AverageDouble;
		}

		public double AverageDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => ((double)x + y) / 3d;
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
				if (squared.AlmostEquals()) return zero;

				return 1f / (float)Math.Sqrt(squared) * this;
			}
		}

		public Float2 Squared
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float2(x * x, y * y);
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

#endregion

#region Methods

#region Instance

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Dot(Float2 other) => x * other.x + y * other.y;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DotDouble(Float2 other) => (double)x * other.x + (double)y * other.y;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Angle(Float2 other) => Math.Abs(SignedAngle(other));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SignedAngle(Float2 other) => (float)Math.Atan2((double)x * other.y - (double)y * other.x, DotDouble(other)) * Scalars.RadianToDegree;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Distance(Float2 other) => (other - this).Magnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DistanceDouble(Float2 other) => (other - this).MagnitudeDouble;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SquaredDistance(Float2 other) => (other - this).SquaredMagnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double SquaredDistanceDouble(Float2 other) => (other - this).SquaredMagnitudeDouble;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Min(Float2 other) => new Float2(Math.Min(x, other.x), Math.Min(y, other.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Max(Float2 other) => new Float2(Math.Max(x, other.x), Math.Max(y, other.y));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Clamp(Float2 min, Float2 max) => new Float2(x.Clamp(min.x, max.x), y.Clamp(min.y, max.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Clamp(float min = 0f, float max = 1f) => new Float2(x.Clamp(min, max), y.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2 ClampMagnitude(float max)
		{
			double squared = SquaredMagnitudeDouble;
			if (squared <= (double)max * max) return this;

			float scale = max / (float)Math.Sqrt(squared);
			return new Float2(x * scale, y * scale);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Power(Float2 value) => new Float2((float)Math.Pow(x, value.x), (float)Math.Pow(y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Power(float value) => new Float2((float)Math.Pow(x, value), (float)Math.Pow(y, value));

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
				x.Damp(target.x, ref velocityX, smoothTime.x, deltaTime),
				y.Damp(target.y, ref velocityY, smoothTime.y, deltaTime)
			);

			velocity = new Float2(velocityX, velocityY);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2 Damp(Float2 target, ref Float2 velocity, float smoothTime, float deltaTime) => Damp(target, ref velocity, (Float2)smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Reflect(Float2 normal) => -2f * Dot(normal) * normal + this;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Project(Float2 normal) => normal * (Dot(normal) / normal.SquaredMagnitude);

		public override string ToString() => ToString(string.Empty);

		public string ToString(string format) => ToString(format, CultureInfo.InvariantCulture);
		public string ToString(string format, IFormatProvider provider) => $"({x.ToString(format, provider)}, {y.ToString(format, provider)})";

		// ReSharper disable CompareOfFloatsByEqualityOperator
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool EqualsExact(Float2 other) => x == other.x && y == other.y;
		// ReSharper restore CompareOfFloatsByEqualityOperator

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Float2 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Float2 other) => x.AlmostEquals(other.x) && y.AlmostEquals(other.y);

		public override int GetHashCode()
		{
			unchecked
			{
				return (x.GetHashCode() * 397) ^ y.GetHashCode();
			}
		}

#endregion

#region Static

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Dot(Float2 value, Float2 other) => value.Dot(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double DotDouble(Float2 value, Float2 other) => value.DotDouble(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Angle(Float2 first, Float2 second) => first.Angle(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float SignedAngle(Float2 first, Float2 second) => first.SignedAngle(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Distance(Float2 value, Float2 other) => value.Distance(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double DistanceDouble(Float2 value, Float2 other) => value.DistanceDouble(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float SquaredDistance(Float2 value, Float2 other) => value.SquaredDistance(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double SquaredDistanceDouble(Float2 value, Float2 other) => value.SquaredDistanceDouble(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Min(Float2 value, Float2 other) => value.Min(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Max(Float2 value, Float2 other) => value.Max(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Clamp(Float2 value, Float2 min, Float2 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Clamp(Float2 value, float min = 0f, float max = 1f) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 ClampMagnitude(Float2 value, float max) => value.ClampMagnitude(max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Power(Float2 value, Float2 power) => value.Power(power);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Power(Float2 value, float power) => value.Power(power);

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

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Reflect(Float2 value, Float2 normal) => value.Reflect(normal);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Project(Float2 value, Float2 normal) => value.Project(normal);

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
		public UnityEngine.Vector2 U() => this;
#endif

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator +(Float2 first, Float2 second) => new Float2(first.x + second.x, first.y + second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator -(Float2 first, Float2 second) => new Float2(first.x - second.x, first.y - second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(Float2 first, Float2 second) => new Float2(first.x * second.x, first.y * second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(Float2 first, Float2 second) => new Float2(first.x / second.x, first.y / second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(Float2 first, float second) => new Float2(first.x * second, first.y * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(Float2 first, float second) => new Float2(first.x / second, first.y / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(float first, Float2 second) => new Float2(first * second.x, first * second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(float first, Float2 second) => new Float2(first / second.x, first / second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator +(Float2 value) => value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator -(Float2 value) => new Float2(-value.x, -value.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(Float2 first, Float2 second) => new Float2(first.x % second.x, first.y % second.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(Float2 first, float second) => new Float2(first.x % second, first.y % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(float first, Float2 second) => new Float2(first % second.x, first % second.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Float2 first, Float2 second) => first.Equals(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Float2 first, Float2 second) => !first.Equals(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(Float2 first, Float2 second) => first.x < second.x && first.y < second.y;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(Float2 first, Float2 second) => first.x > second.x && first.y > second.y;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(Float2 first, Float2 second) => first.x <= second.x && first.y <= second.y;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(Float2 first, Float2 second) => first.x >= second.x && first.y >= second.y;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(Float2 value) => new Int2((int)value.x, (int)value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(Float2 value) => new Int3((int)value.x, (int)value.y, 0);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(Float2 value) => new Int4((int)value.x, (int)value.y, 0, 0);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(float value) => new Float2(value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(Float2 value) => value.XY_;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(Float2 value) => new Float4(value.x, value.y, 0f, 0f);

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float2(UnityEngine.Vector2 value) => new Float2(value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector2(Float2 value) => new UnityEngine.Vector2(value.x, value.y);
#endif

#endregion

#endregion

#region Enumerations

		/// <summary>
		/// Returns an enumerable that can be put into a foreach loop.
		/// Yields the two components of this vector in a series.
		/// </summary>
		public SeriesEnumerable Series() => new SeriesEnumerable(this);

		public readonly struct SeriesEnumerable : IEnumerable<float>
		{
			public SeriesEnumerable(Float2 value) => enumerator = new Enumerator(value);

			readonly Enumerator enumerator;

			public Enumerator GetEnumerator() => enumerator;

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			IEnumerator<float> IEnumerable<float>.GetEnumerator() => GetEnumerator();

			public struct Enumerator : IEnumerator<float>
			{
				public Enumerator(Float2 source)
				{
					this.source = source;
					index = -1;
				}

				readonly Float2 source;
				int index;

				object IEnumerator.Current => Current;
				public float Current => source[index];

				public bool MoveNext() => index++ < 1;
				public void Reset() => index = -1;

				public void Dispose() { }
			}
		}

#endregion

	}
}