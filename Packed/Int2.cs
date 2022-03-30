using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeHelpers.Mathematics;

namespace CodeHelpers.Packed
{
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Int2 : IEquatable<Int2>, IFormattable
	{

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Int2(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; }
		public int Y { get; }

#region Properties

#region Static

		public static Int2 Right => new Int2(1, 0);
		public static Int2 Left => new Int2(-1, 0);

		public static Int2 Up => new Int2(0, 1);
		public static Int2 Down => new Int2(0, -1);

		public static Int2 One => new Int2(1, 1);
		public static Int2 Zero => new Int2(0, 0);
		public static Int2 NegativeOne => new Int2(-1, -1);

		public static Int2 MaxValue => new Int2(int.MaxValue, int.MaxValue);
		public static Int2 MinValue => new Int2(int.MinValue, int.MinValue);

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

#region Instance

#region Swizzled

#region Four

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXXX => new Int4(X, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXXY => new Int4(X, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXX_ => new Int4(X, X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXYX => new Int4(X, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXYY => new Int4(X, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXY_ => new Int4(X, X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX_X => new Int4(X, X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX_Y => new Int4(X, X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX__ => new Int4(X, X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYXX => new Int4(X, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYXY => new Int4(X, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYX_ => new Int4(X, Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYYX => new Int4(X, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYYY => new Int4(X, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYY_ => new Int4(X, Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY_X => new Int4(X, Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY_Y => new Int4(X, Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY__ => new Int4(X, Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_XX => new Int4(X, 0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_XY => new Int4(X, 0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_X_ => new Int4(X, 0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_YX => new Int4(X, 0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_YY => new Int4(X, 0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_Y_ => new Int4(X, 0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X__X => new Int4(X, 0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X__Y => new Int4(X, 0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X___ => new Int4(X, 0, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXXX => new Int4(Y, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXXY => new Int4(Y, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXX_ => new Int4(Y, X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXYX => new Int4(Y, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXYY => new Int4(Y, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXY_ => new Int4(Y, X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX_X => new Int4(Y, X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX_Y => new Int4(Y, X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX__ => new Int4(Y, X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYXX => new Int4(Y, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYXY => new Int4(Y, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYX_ => new Int4(Y, Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYYX => new Int4(Y, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYYY => new Int4(Y, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYY_ => new Int4(Y, Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY_X => new Int4(Y, Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY_Y => new Int4(Y, Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY__ => new Int4(Y, Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_XX => new Int4(Y, 0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_XY => new Int4(Y, 0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_X_ => new Int4(Y, 0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_YX => new Int4(Y, 0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_YY => new Int4(Y, 0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_Y_ => new Int4(Y, 0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y__X => new Int4(Y, 0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y__Y => new Int4(Y, 0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y___ => new Int4(Y, 0, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XXX => new Int4(0, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XXY => new Int4(0, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XX_ => new Int4(0, X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XYX => new Int4(0, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XYY => new Int4(0, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XY_ => new Int4(0, X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X_X => new Int4(0, X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X_Y => new Int4(0, X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X__ => new Int4(0, X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YXX => new Int4(0, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YXY => new Int4(0, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YX_ => new Int4(0, Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YYX => new Int4(0, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YYY => new Int4(0, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YY_ => new Int4(0, Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y_X => new Int4(0, Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y_Y => new Int4(0, Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y__ => new Int4(0, Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __XX => new Int4(0, 0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __XY => new Int4(0, 0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __X_ => new Int4(0, 0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __YX => new Int4(0, 0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __YY => new Int4(0, 0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __Y_ => new Int4(0, 0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ___X => new Int4(0, 0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ___Y => new Int4(0, 0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ____ => new Int4(0, 0, 0, 0);

#endregion

#region Three

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXX => new Int3(X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXY => new Int3(X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XX_ => new Int3(X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYX => new Int3(X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYY => new Int3(X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XY_ => new Int3(X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X_X => new Int3(X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X_Y => new Int3(X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X__ => new Int3(X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXX => new Int3(Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXY => new Int3(Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YX_ => new Int3(Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYX => new Int3(Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYY => new Int3(Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YY_ => new Int3(Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y_X => new Int3(Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y_Y => new Int3(Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y__ => new Int3(Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _XX => new Int3(0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _XY => new Int3(0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _X_ => new Int3(0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _YX => new Int3(0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _YY => new Int3(0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _Y_ => new Int3(0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 __X => new Int3(0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 __Y => new Int3(0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ___ => new Int3(0, 0, 0);

#endregion

#region Two

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XX => new Int2(X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XY => new Int2(X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 X_ => new Int2(X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YX => new Int2(Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YY => new Int2(Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 Y_ => new Int2(Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 _X => new Int2(0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 _Y => new Int2(0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 __ => new Int2(0, 0);

#endregion

#endregion

#region Scalar Returns

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
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X * X + Y * Y;
		}

		public long SquaredMagnitudeLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)X * X + (long)Y * Y;
		}

		public int Product
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X * Y;
		}

		public long ProductLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)X * Y;
		}

		public int ProductAbsoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs(X * Y);
		}

		public long ProductAbsolutedLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs((long)X * Y);
		}

		public int Sum
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X + Y;
		}

		public long SumLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)X + Y;
		}

		public float Average
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (float)AverageDouble;
		}

		public double AverageDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => ((double)X + Y) / 3d;
		}

		public int MinComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X < Y ? X : Y;
		}

		public int MinIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X < Y ? 0 : 1;
		}

		public int MaxComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X > Y ? X : Y;
		}

		public int MaxIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X > Y ? 0 : 1;
		}

		public int this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
#if CODE_HELPERS_UNSAFE
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
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int2(Math.Abs(X), Math.Abs(Y));
		}

		public Int2 Signed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int2(X.Sign(), Y.Sign());
		}

		public Float2 Normalized
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				long squared = SquaredMagnitudeLong;
				if (squared == 0) return Float2.Zero;

				return 1f / (float)Math.Sqrt(squared) * this;
			}
		}

		public Int2 Squared
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int2(X * X, Y * Y);
		}

		public Int2 Perpendicular
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int2(-Y, X);
		}

		public Int2 Sorted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X < Y ? XY : YX;
		}

		public Int2 SortedReversed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X > Y ? XY : YX;
		}

#endregion

#endregion

#endregion

#region Methods

#region Instance

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public int Dot(Int2 other) => X * other.X + Y * other.Y;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public long DotLong(Int2 other) => (long)X * other.X + (long)Y * other.Y;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Angle(Int2 other) => Math.Abs(SignedAngle(other));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SignedAngle(Int2 other) => (float)Math.Atan2((long)X * other.Y - (long)Y * other.X, DotLong(other)) * Scalars.RadianToDegree;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Distance(Int2 other) => (other - this).Magnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DistanceDouble(Int2 other) => (other - this).MagnitudeDouble;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public int SquaredDistance(Int2 other) => (other - this).SquaredMagnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public long SquaredDistanceLong(Int2 other) => (other - this).SquaredMagnitudeLong;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Min(Int2 other) => new Int2(Math.Min(X, other.X), Math.Min(Y, other.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Max(Int2 other) => new Int2(Math.Max(X, other.X), Math.Max(Y, other.Y));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Clamp(Int2 min, Int2 max) => new Int2(X.Clamp(min.X, max.X), Y.Clamp(min.Y, max.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Clamp(int min = 0, int max = 1) => new Int2(X.Clamp(min, max), Y.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Clamp(Float2 min, Float2 max) => new Float2(X.Clamp(min.X, max.X), Y.Clamp(min.Y, max.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Clamp(float min, float max = 1f) => new Float2(X.Clamp(min, max), Y.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float2 ClampMagnitude(float max)
		{
			double squared = SquaredMagnitudeLong;
			if (squared <= (double)max * max) return this;

			float scale = max / (float)Math.Sqrt(squared);
			return new Float2(X * scale, Y * scale);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Power(Float2 value) => new Float2((float)Math.Pow(X, value.X), (float)Math.Pow(Y, value.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Power(float value) => new Float2((float)Math.Pow(X, value), (float)Math.Pow(Y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Lerp(Int2 other, Int2 value) => new Int2(Scalars.Lerp(X, other.X, value.X), Scalars.Lerp(Y, other.Y, value.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Lerp(Int2 other, int value) => new Int2(Scalars.Lerp(X, other.X, value), Scalars.Lerp(Y, other.Y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Lerp(Int2 other, Float2 value) => new Float2(Scalars.Lerp(X, other.X, value.X), Scalars.Lerp(Y, other.Y, value.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Lerp(Int2 other, float value) => new Float2(Scalars.Lerp(X, other.X, value), Scalars.Lerp(Y, other.Y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 InverseLerp(Int2 other, Int2 value) => new Int2(Scalars.InverseLerp(X, other.X, value.X), Scalars.InverseLerp(Y, other.Y, value.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 InverseLerp(Int2 other, int value) => new Int2(Scalars.InverseLerp(X, other.X, value), Scalars.InverseLerp(Y, other.Y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 InverseLerp(Int2 other, Float2 value) => new Float2(Scalars.InverseLerp(X, other.X, value.X), Scalars.InverseLerp(Y, other.Y, value.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 InverseLerp(Int2 other, float value) => new Float2(Scalars.InverseLerp(X, other.X, value), Scalars.InverseLerp(Y, other.Y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Repeat(Int2 length) => new Int2(X.Repeat(length.X), Y.Repeat(length.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Repeat(int length) => new Int2(X.Repeat(length), Y.Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Repeat(Float2 length) => new Float2(((float)X).Repeat(length.X), ((float)Y).Repeat(length.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Repeat(float length) => new Float2(((float)X).Repeat(length), ((float)Y).Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 FlooredDivide(Int2 divisor) => new Int2(X.FlooredDivide(divisor.X), Y.FlooredDivide(divisor.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 FlooredDivide(int divisor) => new Int2(X.FlooredDivide(divisor), Y.FlooredDivide(divisor));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 CeiledDivide(Int2 divisor) => new Int2(X.CeiledDivide(divisor.X), Y.CeiledDivide(divisor.Y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 CeiledDivide(int divisor) => new Int2(X.CeiledDivide(divisor), Y.CeiledDivide(divisor));

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

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Damp(Float2 target, ref Float2 velocity, Float2 smoothTime, float deltaTime) => Float2.Damp(this, target, ref velocity, smoothTime, deltaTime);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Damp(Float2 target, ref Float2 velocity, float smoothTime, float deltaTime) => Float2.Damp(this, target, ref velocity, smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 Reflect(Int2 normal) => -2 * Dot(normal) * normal + this;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float2 Project(Float2 normal) => normal * (normal.Dot(this) / normal.SquaredMagnitude);

		public override string ToString() => ToString(string.Empty);

		public string ToString(string format) => ToString(format, CultureInfo.InvariantCulture);
		public string ToString(string format, IFormatProvider provider) => $"({X.ToString(format, provider)}, {Y.ToString(format, provider)})";

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Int2 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Int2 other) => X == other.X && Y == other.Y;

		public override int GetHashCode()
		{
			unchecked
			{
				return (X.GetHashCode() * 397) ^ Y.GetHashCode();
			}
		}

#endregion

#region Static

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static int Dot(Int2 value, Int2 other) => value.Dot(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static long DotLong(Int2 value, Int2 other) => value.DotLong(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Angle(Int2 first, Int2 second) => first.Angle(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float SignedAngle(Int2 first, Int2 second) => first.SignedAngle(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Distance(Int2 value, Int2 other) => value.Distance(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double DistanceDouble(Int2 value, Int2 other) => value.DistanceDouble(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static int SquaredDistance(Int2 value, Int2 other) => value.SquaredDistance(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static long SquaredDistanceDouble(Int2 value, Int2 other) => value.SquaredDistanceLong(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Min(Int2 value, Int2 other) => value.Min(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Max(Int2 value, Int2 other) => value.Max(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Clamp(Int2 value, Int2 min, Int2 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Clamp(Int2 value, int min = 0, int max = 1) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Clamp(Int2 value, Float2 min, Float2 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Clamp(Int2 value, float min, float max = 1f) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 ClampMagnitude(Int2 value, float max) => value.ClampMagnitude(max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Power(Float2 value, Float2 power) => value.Power(power);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Power(Float2 value, float power) => value.Power(power);

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

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 CeiledDivide(Int2 value, Int2 divisor) => value.CeiledDivide(divisor);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 CeiledDivide(Int2 value, int divisor) => value.CeiledDivide(divisor);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Rotate(Int2 value, float degree) => value.Rotate(degree);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Rotate(Int2 value, float degree, Float2 pivot) => value.Rotate(degree, pivot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Damp(Int2 current, Float2 target, ref Float2 velocity, Float2 smoothTime, float deltaTime) => Float2.Damp(current, target, ref velocity, smoothTime, deltaTime);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Damp(Int2 current, Float2 target, ref Float2 velocity, float smoothTime, float deltaTime) => Float2.Damp(current, target, ref velocity, smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Reflect(Int2 value, Int2 normal) => value.Reflect(normal);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Project(Int2 value, Float2 normal) => value.Project(normal);

#endregion

#region Create

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int2 Create(int index, int value)
		{
#if CODE_HELPERS_UNSAFE
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
#if CODE_HELPERS_UNSAFE
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
#if CODE_HELPERS_UNSAFE
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

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int2 ReplaceX(int value) => new Int2(value, Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int2 ReplaceY(int value) => new Int2(X, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float2 ReplaceX(float value) => new Float2(value, Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float2 ReplaceY(float value) => new Float2(X, value);

#if CODE_HELPERS_UNITY
		public UnityEngine.Vector2Int U() => this;
#endif

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator +(Int2 first, Int2 second) => new Int2(first.X + second.X, first.Y + second.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator -(Int2 first, Int2 second) => new Int2(first.X - second.X, first.Y - second.Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator *(Int2 first, Int2 second) => new Int2(first.X * second.X, first.Y * second.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator /(Int2 first, Int2 second) => new Int2(first.X / second.X, first.Y / second.Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator *(Int2 first, int second) => new Int2(first.X * second, first.Y * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator /(Int2 first, int second) => new Int2(first.X / second, first.Y / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(Int2 first, float second) => new Float2(first.X * second, first.Y * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(Int2 first, float second) => new Float2(first.X / second, first.Y / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator *(int first, Int2 second) => new Int2(first * second.X, first * second.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator /(int first, Int2 second) => new Int2(first / second.X, first / second.Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(float first, Int2 second) => new Float2(first * second.X, first * second.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(float first, Int2 second) => new Float2(first / second.X, first / second.Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator +(Int2 value) => value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator -(Int2 value) => new Int2(-value.X, -value.Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator %(Int2 first, Int2 second) => new Int2(first.X % second.X, first.Y % second.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator %(Int2 first, int second) => new Int2(first.X % second, first.Y % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator %(int first, Int2 second) => new Int2(first % second.X, first % second.Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(Int2 first, float second) => new Float2(first.X % second, first.Y % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(float first, Int2 second) => new Float2(first % second.X, first % second.Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Int2 first, Int2 second) => first.Equals(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Int2 first, Int2 second) => !first.Equals(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(Int2 first, Int2 second) => first.X < second.X && first.Y < second.Y;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(Int2 first, Int2 second) => first.X > second.X && first.Y > second.Y;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(Int2 first, Int2 second) => first.X <= second.X && first.Y <= second.Y;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(Int2 first, Int2 second) => first.X >= second.X && first.Y >= second.Y;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(int value) => new Int2(value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(Int2 value) => value.XY_;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(Int2 value) => new Int4(value.X, value.Y, 0, 0);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float2(Int2 value) => new Float2(value.X, value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(Int2 value) => new Float3(value.X, value.Y, 0f);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(Int2 value) => new Float4(value.X, value.Y, 0f, 0f);

#if CODE_HELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Int2(UnityEngine.Vector2Int value) => new Int2(value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector2Int(Int2 value) => new UnityEngine.Vector2Int(value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector2(Int2 value) => new UnityEngine.Vector2(value.x, value.y);
#endif

#endregion

#endregion

#region Enumerations

		/// <summary>
		/// Returns an enumerable that can be put into a foreach loop.
		/// Yields the two components of this vector in a series.
		/// </summary>
		public SeriesEnumerable Series() => new SeriesEnumerable(this);

		/// <summary>
		/// Returns an enumerable that can be put into a foreach loop; from (0,0,0) to (vector.x-1,vector.y-1,vector.z-1)
		/// If <paramref name="zeroAsOne"/> is true then the loop will treat zeros in the vector as ones.
		/// </summary>
		public LoopEnumerable Loop(bool zeroAsOne = false) => new LoopEnumerable(this, zeroAsOne);

		public readonly struct SeriesEnumerable : IEnumerable<int>
		{
			public SeriesEnumerable(Int2 value) => enumerator = new Enumerator(value);

			readonly Enumerator enumerator;

			public Enumerator GetEnumerator() => enumerator;

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			IEnumerator<int> IEnumerable<int>.GetEnumerator() => GetEnumerator();

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

				public bool MoveNext() => index++ < 1;
				public void Reset() => index = -1;

				public void Dispose() { }
			}
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
					direction = size.Signed;
					size = size.Absoluted;

					if (zeroAsOne) size = size.Max(One);

					sizeX = size.X;
					product = size.Product;

					current = -1;
				}

				readonly Int2 direction;
				readonly int sizeX;

				readonly int product;
				int current;

				object IEnumerator.Current => Current;

				public Int2 Current => new Int2
				(
					current % sizeX * direction.X,
					current / sizeX * direction.Y
				);

				public bool MoveNext() => ++current < product;

				public void Reset() => current = -1;
				public void Dispose() { }
			}
		}

#endregion

	}
}