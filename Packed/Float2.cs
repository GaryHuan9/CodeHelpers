using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeHelpers.Mathematics;

namespace CodeHelpers.Packed
{
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Float2 : IEquatable<Float2>, IFormattable
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2(float x, float y)
		{
			X = x;
			Y = y;
		}

		public float X { get; }
		public float Y { get; }

#region Properties

#region Static

		public static Float2 Right => new Float2(1f, 0f);
		public static Float2 Left => new Float2(-1f, 0f);

		public static Float2 Up => new Float2(0f, 1f);
		public static Float2 Down => new Float2(0f, -1f);

		public static Float2 Zero => new Float2(0f, 0f);

		public static Float2 One => new Float2(1f, 1f);
		public static Float2 NegativeOne => new Float2(-1f, -1f);

		public static Float2 Half => new Float2(0.5f, 0.5f);
		public static Float2 NegativeHalf => new Float2(-0.5f, -0.5f);

		public static Float2 MaxValue => new Float2(float.MaxValue, float.MaxValue);
		public static Float2 MinValue => new Float2(float.MinValue, float.MinValue);

		public static Float2 PositiveInfinity => new Float2(float.PositiveInfinity, float.PositiveInfinity);
		public static Float2 NegativeInfinity => new Float2(float.NegativeInfinity, float.NegativeInfinity);

		public static Float2 Epsilon => new Float2(Scalars.Epsilon, Scalars.Epsilon);
		public static Float2 NaN => new Float2(float.NaN, float.NaN);

#endregion

#region Instance

#region Swizzled

#region Four

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXX => new Float4(X, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXY => new Float4(X, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXX_ => new Float4(X, X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYX => new Float4(X, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYY => new Float4(X, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXY_ => new Float4(X, X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX_X => new Float4(X, X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX_Y => new Float4(X, X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX__ => new Float4(X, X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXX => new Float4(X, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXY => new Float4(X, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYX_ => new Float4(X, Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYX => new Float4(X, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYY => new Float4(X, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYY_ => new Float4(X, Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY_X => new Float4(X, Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY_Y => new Float4(X, Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY__ => new Float4(X, Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_XX => new Float4(X, 0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_XY => new Float4(X, 0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_X_ => new Float4(X, 0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_YX => new Float4(X, 0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_YY => new Float4(X, 0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_Y_ => new Float4(X, 0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X__X => new Float4(X, 0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X__Y => new Float4(X, 0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X___ => new Float4(X, 0f, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXX => new Float4(Y, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXY => new Float4(Y, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXX_ => new Float4(Y, X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYX => new Float4(Y, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYY => new Float4(Y, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXY_ => new Float4(Y, X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX_X => new Float4(Y, X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX_Y => new Float4(Y, X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX__ => new Float4(Y, X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXX => new Float4(Y, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXY => new Float4(Y, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYX_ => new Float4(Y, Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYX => new Float4(Y, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYY => new Float4(Y, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYY_ => new Float4(Y, Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY_X => new Float4(Y, Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY_Y => new Float4(Y, Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY__ => new Float4(Y, Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_XX => new Float4(Y, 0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_XY => new Float4(Y, 0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_X_ => new Float4(Y, 0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_YX => new Float4(Y, 0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_YY => new Float4(Y, 0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_Y_ => new Float4(Y, 0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y__X => new Float4(Y, 0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y__Y => new Float4(Y, 0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y___ => new Float4(Y, 0f, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XXX => new Float4(0f, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XXY => new Float4(0f, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XX_ => new Float4(0f, X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XYX => new Float4(0f, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XYY => new Float4(0f, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XY_ => new Float4(0f, X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X_X => new Float4(0f, X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X_Y => new Float4(0f, X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X__ => new Float4(0f, X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YXX => new Float4(0f, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YXY => new Float4(0f, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YX_ => new Float4(0f, Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YYX => new Float4(0f, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YYY => new Float4(0f, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YY_ => new Float4(0f, Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y_X => new Float4(0f, Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y_Y => new Float4(0f, Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y__ => new Float4(0f, Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __XX => new Float4(0f, 0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __XY => new Float4(0f, 0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __X_ => new Float4(0f, 0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __YX => new Float4(0f, 0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __YY => new Float4(0f, 0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __Y_ => new Float4(0f, 0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ___X => new Float4(0f, 0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ___Y => new Float4(0f, 0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ____ => new Float4(0f, 0f, 0f, 0f);

#endregion

#region Three

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXX => new Float3(X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXY => new Float3(X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XX_ => new Float3(X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYX => new Float3(X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYY => new Float3(X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XY_ => new Float3(X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X_X => new Float3(X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X_Y => new Float3(X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X__ => new Float3(X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXX => new Float3(Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXY => new Float3(Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YX_ => new Float3(Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYX => new Float3(Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYY => new Float3(Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YY_ => new Float3(Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y_X => new Float3(Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y_Y => new Float3(Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y__ => new Float3(Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _XX => new Float3(0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _XY => new Float3(0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _X_ => new Float3(0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _YX => new Float3(0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _YY => new Float3(0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _Y_ => new Float3(0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 __X => new Float3(0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 __Y => new Float3(0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ___ => new Float3(0f, 0f, 0f);

#endregion

#region Two

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XX => new Float2(X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XY => new Float2(X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 X_ => new Float2(X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YX => new Float2(Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YY => new Float2(Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 Y_ => new Float2(Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 _X => new Float2(0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 _Y => new Float2(0f, Y);
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
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X * X + Y * Y;
		}

		public double SquaredMagnitudeDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)X * X + (double)Y * Y;
		}

		public float Product
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X * Y;
		}

		public double ProductDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)X * Y;
		}

		public float ProductAbsoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs(X * Y);
		}

		public double ProductAbsolutedDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs((double)X * Y);
		}

		public float Sum
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X + Y;
		}

		public double SumDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)X + Y;
		}

		public float Average
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (float)AverageDouble;
		}

		public double AverageDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => ((double)X + Y) / 3d;
		}

		public float MinComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X < Y ? X : Y;
		}

		public int MinIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X < Y ? 0 : 1;
		}

		public float MaxComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X > Y ? X : Y;
		}

		public int MaxIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X > Y ? 0 : 1;
		}

		public float this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
#if CODE_HELPERS_UNSAFE
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
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float2(Math.Abs(X), Math.Abs(Y));
		}

		public Int2 Signed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int2(X.Sign(), Y.Sign());
		}

		public Float2 Normalized
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				double squared = SquaredMagnitudeDouble;
				if (squared.AlmostEquals()) return Zero;

				return 1f / (float)Math.Sqrt(squared) * this;
			}
		}

		public Float2 Squared
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float2(X * X, Y * Y);
		}

		public Float2 Perpendicular
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float2(-Y, X);
		}

		public Float2 Sorted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X < Y ? XY : YX;
		}

		public Float2 SortedReversed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X > Y ? XY : YX;
		}

		public Int2 Floored
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int2((int)Math.Floor(X), (int)Math.Floor(Y));
		}

		public Float2 FlooredFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float2((float)Math.Floor(X), (float)Math.Floor(Y));
		}

		public Int2 Ceiled
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int2((int)Math.Ceiling(X), (int)Math.Ceiling(Y));
		}

		public Float2 CeiledFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float2((float)Math.Ceiling(X), (float)Math.Ceiling(Y));
		}

		public Int2 Rounded
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int2((int)Math.Round(X), (int)Math.Round(Y));
		}

		public Float2 RoundedFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float2((float)Math.Round(X), (float)Math.Round(Y));
		}

#endregion

#endregion

#endregion

#region Methods

#region Instance

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Dot(Float2 other) => X * other.X + Y * other.Y;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DotDouble(Float2 other) => (double)X * other.X + (double)Y * other.Y;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Angle(Float2 other) => Math.Abs(SignedAngle(other));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SignedAngle(Float2 other) => (float)Math.Atan2((double)X * other.Y - (double)Y * other.X, DotDouble(other)) * Scalars.RadianToDegree;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Distance(Float2 other) => (other - this).Magnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DistanceDouble(Float2 other) => (other - this).MagnitudeDouble;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SquaredDistance(Float2 other) => (other - this).SquaredMagnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double SquaredDistanceDouble(Float2 other) => (other - this).SquaredMagnitudeDouble;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Min(Float2 other) => new Float2(Math.Min(X, other.X), Math.Min(Y, other.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Max(Float2 other) => new Float2(Math.Max(X, other.X), Math.Max(Y, other.Y));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Clamp(Float2 min, Float2 max) => new Float2(X.Clamp(min.X, max.X), Y.Clamp(min.Y, max.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Clamp(float min = 0f, float max = 1f) => new Float2(X.Clamp(min, max), Y.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2 ClampMagnitude(float max)
		{
			double squared = SquaredMagnitudeDouble;
			if (squared <= (double)max * max) return this;

			float scale = max / (float)Math.Sqrt(squared);
			return new Float2(X * scale, Y * scale);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Power(Float2 value) => new Float2((float)Math.Pow(X, value.X), (float)Math.Pow(Y, value.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Power(float value) => new Float2((float)Math.Pow(X, value), (float)Math.Pow(Y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Lerp(Float2 other, Float2 value) => new Float2(Scalars.Lerp(X, other.X, value.X), Scalars.Lerp(Y, other.Y, value.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Lerp(Float2 other, float value) => new Float2(Scalars.Lerp(X, other.X, value), Scalars.Lerp(Y, other.Y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 InverseLerp(Float2 other, Float2 value) => new Float2(Scalars.InverseLerp(X, other.X, value.X), Scalars.InverseLerp(Y, other.Y, value.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 InverseLerp(Float2 other, float value) => new Float2(Scalars.InverseLerp(X, other.X, value), Scalars.InverseLerp(Y, other.Y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Repeat(Float2 length) => new Float2(X.Repeat(length.X), Y.Repeat(length.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Repeat(float length) => new Float2(X.Repeat(length), Y.Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2 Rotate(float degree)
		{
			float angle = degree * Scalars.DegreeToRadian;

			float sin = (float)Math.Sin(angle);
			float cos = (float)Math.Cos(angle);

			return new Float2(cos * X - sin * Y, sin * X + cos * Y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2 Rotate(float degree, Float2 pivot)
		{
			float angle = degree * Scalars.DegreeToRadian;

			float sin = (float)Math.Sin(angle);
			float cos = (float)Math.Cos(angle);

			float offsetX = X - pivot.X;
			float offsetY = Y - pivot.Y;

			return new Float2(cos * offsetX - sin * offsetY + pivot.X, sin * offsetX + cos * offsetY + pivot.Y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2 Damp(Float2 target, ref Float2 velocity, Float2 smoothTime, float deltaTime)
		{
			float velocityX = velocity.X;
			float velocityY = velocity.Y;

			Float2 result = new Float2
			(
				X.Damp(target.X, ref velocityX, smoothTime.X, deltaTime),
				Y.Damp(target.Y, ref velocityY, smoothTime.Y, deltaTime)
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
		public string ToString(string format, IFormatProvider provider) => $"({X.ToString(format, provider)}, {Y.ToString(format, provider)})";

		// ReSharper disable CompareOfFloatsByEqualityOperator
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool EqualsExact(Float2 other) => X == other.X && Y == other.Y;
		// ReSharper restore CompareOfFloatsByEqualityOperator

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Float2 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Float2 other) => X.AlmostEquals(other.X) && Y.AlmostEquals(other.Y);

		public override int GetHashCode()
		{
			unchecked
			{
				return (X.GetHashCode() * 397) ^ Y.GetHashCode();
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
#if CODE_HELPERS_UNSAFE
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
#if CODE_HELPERS_UNSAFE
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
#if CODE_HELPERS_UNSAFE
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

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float2 ReplaceX(float value) => new Float2(value, Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float2 ReplaceY(float value) => new Float2(X, value);

#if CODE_HELPERS_UNITY
		public UnityEngine.Vector2 U() => this;
#endif

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator +(Float2 first, Float2 second) => new Float2(first.X + second.X, first.Y + second.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator -(Float2 first, Float2 second) => new Float2(first.X - second.X, first.Y - second.Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(Float2 first, Float2 second) => new Float2(first.X * second.X, first.Y * second.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(Float2 first, Float2 second) => new Float2(first.X / second.X, first.Y / second.Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(Float2 first, float second) => new Float2(first.X * second, first.Y * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(Float2 first, float second) => new Float2(first.X / second, first.Y / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(float first, Float2 second) => new Float2(first * second.X, first * second.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(float first, Float2 second) => new Float2(first / second.X, first / second.Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator +(Float2 value) => value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator -(Float2 value) => new Float2(-value.X, -value.Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(Float2 first, Float2 second) => new Float2(first.X % second.X, first.Y % second.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(Float2 first, float second) => new Float2(first.X % second, first.Y % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(float first, Float2 second) => new Float2(first % second.X, first % second.Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Float2 first, Float2 second) => first.Equals(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Float2 first, Float2 second) => !first.Equals(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(Float2 first, Float2 second) => first.X < second.X && first.Y < second.Y;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(Float2 first, Float2 second) => first.X > second.X && first.Y > second.Y;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(Float2 first, Float2 second) => first.X <= second.X && first.Y <= second.Y;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(Float2 first, Float2 second) => first.X >= second.X && first.Y >= second.Y;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(Float2 value) => new Int2((int)value.X, (int)value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(Float2 value) => new Int3((int)value.X, (int)value.Y, 0);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(Float2 value) => new Int4((int)value.X, (int)value.Y, 0, 0);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(float value) => new Float2(value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(Float2 value) => value.XY_;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(Float2 value) => new Float4(value.X, value.Y, 0f, 0f);

#if CODE_HELPERS_UNITY
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