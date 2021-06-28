using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CodeHelpers.Mathematics
{
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct Int3 : IEquatable<Int3>, IFormattable
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Int3(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		[FieldOffset(0)] public readonly int x;
		[FieldOffset(4)] public readonly int y;
		[FieldOffset(8)] public readonly int z;

#region Swizzled3

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXX => new Int3(x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXY => new Int3(x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXZ => new Int3(x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XX_ => new Int3(x, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYX => new Int3(x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYY => new Int3(x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYZ => new Int3(x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XY_ => new Int3(x, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZX => new Int3(x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZY => new Int3(x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZZ => new Int3(x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZ_ => new Int3(x, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X_X => new Int3(x, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X_Y => new Int3(x, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X_Z => new Int3(x, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X__ => new Int3(x, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXX => new Int3(y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXY => new Int3(y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXZ => new Int3(y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YX_ => new Int3(y, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYX => new Int3(y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYY => new Int3(y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYZ => new Int3(y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YY_ => new Int3(y, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZX => new Int3(y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZY => new Int3(y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZZ => new Int3(y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZ_ => new Int3(y, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y_X => new Int3(y, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y_Y => new Int3(y, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y_Z => new Int3(y, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y__ => new Int3(y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXX => new Int3(z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXY => new Int3(z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXZ => new Int3(z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZX_ => new Int3(z, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYX => new Int3(z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYY => new Int3(z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYZ => new Int3(z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZY_ => new Int3(z, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZX => new Int3(z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZY => new Int3(z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZZ => new Int3(z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZ_ => new Int3(z, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Z_X => new Int3(z, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Z_Y => new Int3(z, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Z_Z => new Int3(z, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Z__ => new Int3(z, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _XX => new Int3(0, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _XY => new Int3(0, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _XZ => new Int3(0, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _X_ => new Int3(0, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _YX => new Int3(0, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _YY => new Int3(0, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _YZ => new Int3(0, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _Y_ => new Int3(0, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _ZX => new Int3(0, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _ZY => new Int3(0, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _ZZ => new Int3(0, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _Z_ => new Int3(0, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 __X => new Int3(0, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 __Y => new Int3(0, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 __Z => new Int3(0, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ___ => new Int3(0, 0, 0);

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

		public static readonly ReadOnlyCollection<Int3> units8 = new ReadOnlyCollection<Int3>
		(
			new[]
			{
				new Int3(0, 0, 0), new Int3(1, 0, 0), new Int3(0, 0, 1), new Int3(1, 0, 1),
				new Int3(0, 1, 0), new Int3(1, 1, 0), new Int3(0, 1, 1), new Int3(1, 1, 1)
			}
		);

		public static readonly ReadOnlyCollection<Int3> faces6 = new ReadOnlyCollection<Int3>
		(
			new[]
			{
				new Int3(1, 0, 0), new Int3(-1, 0, 0),
				new Int3(0, 1, 0), new Int3(0, -1, 0),
				new Int3(0, 0, 1), new Int3(0, 0, -1)
			}
		);

		public static readonly ReadOnlyCollection<Int3> vertices8 = new ReadOnlyCollection<Int3>
		(
			new[]
			{
				new Int3(1, 1, 1), new Int3(-1, 1, 1), new Int3(1, 1, -1), new Int3(-1, 1, -1),
				new Int3(1, -1, 1), new Int3(-1, -1, 1), new Int3(1, -1, -1), new Int3(-1, -1, -1)
			}
		);

		public static readonly ReadOnlyCollection<Int3> edges12 = new ReadOnlyCollection<Int3>
		(
			new[]
			{
				new Int3(1, 1, 0), new Int3(0, 1, 1), new Int3(-1, 1, 0), new Int3(0, 1, -1),
				new Int3(1, 0, 1), new Int3(-1, 0, 1), new Int3(-1, 0, -1), new Int3(1, 0, -1),
				new Int3(1, -1, 0), new Int3(0, -1, 1), new Int3(-1, -1, 0), new Int3(0, -1, -1)
			}
		);

		public static readonly ReadOnlyCollection<Int3> facesVertices14 = new ReadOnlyCollection<Int3>(faces6.Concat(vertices8).ToArray());
		public static readonly ReadOnlyCollection<Int3> facesEdges18 = new ReadOnlyCollection<Int3>(faces6.Concat(edges12).ToArray());
		public static readonly ReadOnlyCollection<Int3> verticesEdges20 = new ReadOnlyCollection<Int3>(vertices8.Concat(edges12).ToArray());

		public static readonly ReadOnlyCollection<Int3> facesVerticesEdges26 = new ReadOnlyCollection<Int3>(faces6.Concat(vertices8).Concat(edges12).ToArray());

#endregion

#region Instance Properties

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

		public float Average
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (float)AverageDouble;
		}

		public double AverageDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => ((double)x + y + z) / 3d;
		}

		public int MinComponent
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

		public int MaxComponent
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
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3(x.Sign(), y.Sign(), z.Sign());
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

		public Int3 Squared
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3(x * x, y * y, z * z);
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

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Cross(in Int3 other) => new Int3
		(
			(int)((long)y * other.z - (long)z * other.y),
			(int)((long)z * other.x - (long)x * other.z),
			(int)((long)x * other.y - (long)y * other.x)
		);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public int Dot(in Int3 other) => x * other.x + y * other.y + z * other.z;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public long DotLong(in Int3 other) => (long)x * other.x + (long)y * other.y + (long)z * other.z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Angle(in Int3 other)
		{
			double magnitude = Math.Sqrt(SquaredMagnitudeLong * other.SquaredMagnitudeLong);
			return magnitude.AlmostEquals(0d) ? 0f : (float)Math.Acos(DotLong(other) / magnitude) * Scalars.RadianToDegree;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SignedAngle(in Int3 other, in Int3 normal)
		{
			float angle = Angle(other);
			return Cross(other).Dot(normal) < 0f ? -angle : angle;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Distance(in Int3 other) => (other - this).Magnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DistanceDouble(in Int3 other) => (other - this).MagnitudeDouble;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public int SquaredDistance(in Int3 other) => (other - this).SquaredMagnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public long SquaredDistanceLong(in Int3 other) => (other - this).SquaredMagnitudeLong;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Min(in Int3 other) => new Int3(Math.Min(x, other.x), Math.Min(y, other.y), Math.Min(z, other.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Max(in Int3 other) => new Int3(Math.Max(x, other.x), Math.Max(y, other.y), Math.Max(z, other.z));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Clamp(in Int3 min, in Int3 max) => new Int3(x.Clamp(min.x, max.x), y.Clamp(min.y, max.y), z.Clamp(min.z, max.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Clamp(int min = 0, int max = 1) => new Int3(x.Clamp(min, max), y.Clamp(min, max), z.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Clamp(in Float3 min, in Float3 max) => new Float3(x.Clamp(min.x, max.x), y.Clamp(min.y, max.y), z.Clamp(min.z, max.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Clamp(float min, float max = 1f) => new Float3(x.Clamp(min, max), y.Clamp(min, max), z.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3 ClampMagnitude(float max)
		{
			double squared = SquaredMagnitudeLong;
			if (squared <= (double)max * max) return this;

			float scale = max / (float)Math.Sqrt(squared);
			return new Float3(x * scale, y * scale, z * scale);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Power(in Float3 value) => new Float3((float)Math.Pow(x, value.x), (float)Math.Pow(y, value.y), (float)Math.Pow(z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Power(float value) => new Float3((float)Math.Pow(x, value), (float)Math.Pow(y, value), (float)Math.Pow(z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Lerp(in Int3 other, in Int3 value) => new Int3(Scalars.Lerp(x, other.x, value.x), Scalars.Lerp(y, other.y, value.y), Scalars.Lerp(z, other.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Lerp(in Int3 other, int value) => new Int3(Scalars.Lerp(x, other.x, value), Scalars.Lerp(y, other.y, value), Scalars.Lerp(z, other.z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Lerp(in Int3 other, in Float3 value) => new Float3(Scalars.Lerp(x, other.x, value.x), Scalars.Lerp(y, other.y, value.y), Scalars.Lerp(z, other.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Lerp(in Int3 other, float value) => new Float3(Scalars.Lerp(x, other.x, value), Scalars.Lerp(y, other.y, value), Scalars.Lerp(z, other.z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 InverseLerp(in Int3 other, in Int3 value) => new Int3(Scalars.InverseLerp(x, other.x, value.x), Scalars.InverseLerp(y, other.y, value.y), Scalars.InverseLerp(z, other.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 InverseLerp(in Int3 other, int value) => new Int3(Scalars.InverseLerp(x, other.x, value), Scalars.InverseLerp(y, other.y, value), Scalars.InverseLerp(z, other.z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 InverseLerp(in Int3 other, in Float3 value) => new Float3(Scalars.InverseLerp(x, other.x, value.x), Scalars.InverseLerp(y, other.y, value.y), Scalars.InverseLerp(z, other.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 InverseLerp(in Int3 other, float value) => new Float3(Scalars.InverseLerp(x, other.x, value), Scalars.InverseLerp(y, other.y, value), Scalars.InverseLerp(z, other.z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Repeat(in Int3 length) => new Int3(x.Repeat(length.x), y.Repeat(length.y), z.Repeat(length.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Repeat(int length) => new Int3(x.Repeat(length), y.Repeat(length), z.Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Repeat(in Float3 length) => new Float3(((float)x).Repeat(length.x), ((float)y).Repeat(length.y), ((float)z).Repeat(length.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Repeat(float length) => new Float3(((float)x).Repeat(length), ((float)y).Repeat(length), ((float)z).Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 FlooredDivide(in Int3 divisor) => new Int3(x.FlooredDivide(divisor.x), y.FlooredDivide(divisor.y), z.FlooredDivide(divisor.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 FlooredDivide(int divisor) => new Int3(x.FlooredDivide(divisor), y.FlooredDivide(divisor), z.FlooredDivide(divisor));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 CeiledDivide(in Int3 divisor) => new Int3(x.CeiledDivide(divisor.x), y.CeiledDivide(divisor.y), z.CeiledDivide(divisor.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 CeiledDivide(int divisor) => new Int3(x.CeiledDivide(divisor), y.CeiledDivide(divisor), z.CeiledDivide(divisor));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXY(float degree) => Float3.CreateXY(XY.Rotate(degree), z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXY(float degree, Float2 pivot) => Float3.CreateXY(XY.Rotate(degree, pivot), z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXY(float degree, in Float3 pivot) => Float3.CreateXY(XY.Rotate(degree, pivot.XY), z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXZ(float degree) => Float3.CreateXZ(XZ.Rotate(degree), y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXZ(float degree, Float2 pivot) => Float3.CreateXZ(XZ.Rotate(degree, pivot), y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXZ(float degree, in Float3 pivot) => Float3.CreateXZ(XZ.Rotate(degree, pivot.XZ), y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateYZ(float degree) => Float3.CreateYZ(YZ.Rotate(degree), x);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateYZ(float degree, Float2 pivot) => Float3.CreateYZ(YZ.Rotate(degree, pivot), x);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateYZ(float degree, in Float3 pivot) => Float3.CreateYZ(YZ.Rotate(degree, pivot.YZ), x);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Damp(in Float3 target, ref Float3 velocity, in Float3 smoothTime, float deltaTime) => Float3.Damp(this, target, ref velocity, smoothTime, deltaTime);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Damp(in Float3 target, ref Float3 velocity, float smoothTime, float deltaTime) => Float3.Damp(this, target, ref velocity, smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Reflect(in Int3 normal) => -2 * Dot(normal) * normal + this;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Project(in Float3 normal) => normal * (normal.Dot(this) / normal.SquaredMagnitude);

#endregion

#region Static

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Cross(in Int3 first, in Int3 second) => first.Cross(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static int Dot(in Int3 value, in Int3 other) => value.Dot(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static long DotLong(in Int3 value, in Int3 other) => value.DotLong(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Angle(in Int3 first, in Int3 second) => first.Angle(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float SignedAngle(in Int3 first, in Int3 second, in Int3 normal) => first.SignedAngle(second, normal);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Distance(in Int3 value, in Int3 other) => value.Distance(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double DistanceDouble(in Int3 value, in Int3 other) => value.DistanceDouble(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static int SquaredDistance(in Int3 value, in Int3 other) => value.SquaredDistance(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static long SquaredDistanceLong(in Int3 value, in Int3 other) => value.SquaredDistanceLong(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Min(in Int3 value, in Int3 other) => value.Min(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Max(in Int3 value, in Int3 other) => value.Max(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Clamp(in Int3 value, in Int3 min, in Int3 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Clamp(in Int3 value, int min = 0, int max = 1) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Clamp(in Int3 value, in Float3 min, in Float3 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Clamp(in Int3 value, float min, float max = 1f) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 ClampMagnitude(in Int3 value, float max) => value.ClampMagnitude(max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Power(in Float3 value, in Float3 power) => value.Power(power);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Power(in Float3 value, float power) => value.Power(power);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Lerp(in Int3 first, in Int3 second, in Int3 value) => first.Lerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Lerp(in Int3 first, in Int3 second, int value) => first.Lerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Lerp(in Int3 first, in Int3 second, in Float3 value) => first.Lerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Lerp(in Int3 first, in Int3 second, float value) => first.Lerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 InverseLerp(in Int3 first, in Int3 second, in Int3 value) => first.InverseLerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 InverseLerp(in Int3 first, in Int3 second, int value) => first.InverseLerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 InverseLerp(in Int3 first, in Int3 second, in Float3 value) => first.InverseLerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 InverseLerp(in Int3 first, in Int3 second, float value) => first.InverseLerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Repeat(in Int3 value, in Int3 length) => value.Repeat(length);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Repeat(in Int3 value, int length) => value.Repeat(length);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Repeat(in Int3 value, in Float3 length) => value.Repeat(length);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Repeat(in Int3 value, float length) => value.Repeat(length);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 FlooredDivide(in Int3 value, in Int3 divisor) => value.FlooredDivide(divisor);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 FlooredDivide(in Int3 value, int divisor) => value.FlooredDivide(divisor);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 CeiledDivide(in Int3 value, in Int3 divisor) => value.CeiledDivide(divisor);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 CeiledDivide(in Int3 value, int divisor) => value.CeiledDivide(divisor);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXY(in Int3 value, float degree) => value.RotateXY(degree);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXY(in Int3 value, float degree, Float2 pivot) => value.RotateXY(degree, pivot);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXY(in Int3 value, float degree, in Float3 pivot) => value.RotateXY(degree, pivot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXZ(in Int3 value, float degree) => value.RotateXZ(degree);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXZ(in Int3 value, float degree, Float2 pivot) => value.RotateXZ(degree, pivot);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXZ(in Int3 value, float degree, in Float3 pivot) => value.RotateXZ(degree, pivot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateYZ(in Int3 value, float degree) => value.RotateYZ(degree);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateYZ(in Int3 value, float degree, Float2 pivot) => value.RotateYZ(degree, pivot);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateYZ(in Int3 value, float degree, in Float3 pivot) => value.RotateYZ(degree, pivot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Damp(in Int3 current, in Float3 target, ref Float3 velocity, in Float3 smoothTime, float deltaTime) => Float3.Damp(current, target, ref velocity, smoothTime, deltaTime);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Damp(in Int3 current, in Float3 target, ref Float3 velocity, float smoothTime, float deltaTime) => Float3.Damp(current, target, ref velocity, smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Reflect(in Int3 value, in Int3 normal) => value.Reflect(normal);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Project(in Int3 value, in Float3 normal) => value.Project(normal);

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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int3 Create(int index, int value, int other)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 2 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Int3 result = new Int3(other, other, other);
				((int*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Int3(value, other, other);
				case 1:  return new Int3(other, value, other);
				case 2:  return new Int3(other, other, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateX(int value, int other = 0) => new Int3(value, other, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateY(int value, int other = 0) => new Int3(other, value, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateZ(int value, int other = 0) => new Int3(other, other, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateXY(Int2 value, int other = 0) => new Int3(value.x, value.y, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateYZ(Int2 value, int other = 0) => new Int3(other, value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateXZ(Int2 value, int other = 0) => new Int3(value.x, other, value.y);

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

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator *(in Int3 first, in Int3 second) => new Int3(first.x * second.x, first.y * second.y, first.z * second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator /(in Int3 first, in Int3 second) => new Int3(first.x / second.x, first.y / second.y, first.z / second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator *(in Int3 first, int second) => new Int3(first.x * second, first.y * second, first.z * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator /(in Int3 first, int second) => new Int3(first.x / second, first.y / second, first.z / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(in Int3 first, float second) => new Float3(first.x * second, first.y * second, first.z * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(in Int3 first, float second) => new Float3(first.x / second, first.y / second, first.z / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator *(int first, in Int3 second) => new Int3(first * second.x, first * second.y, first * second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator /(int first, in Int3 second) => new Int3(first / second.x, first / second.y, first / second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(float first, in Int3 second) => new Float3(first * second.x, first * second.y, first * second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(float first, in Int3 second) => new Float3(first / second.x, first / second.y, first / second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator +(in Int3 value) => value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator -(in Int3 value) => new Int3(-value.x, -value.y, -value.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator %(in Int3 first, in Int3 second) => new Int3(first.x % second.x, first.y % second.y, first.z % second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator %(in Int3 first, int second) => new Int3(first.x % second, first.y % second, first.z % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator %(int first, in Int3 second) => new Int3(first % second.x, first % second.y, first % second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(in Int3 first, float second) => new Float3(first.x % second, first.y % second, first.z % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(float first, in Int3 second) => new Float3(first % second.x, first % second.y, first % second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(in Int3 first, in Int3 second) => first.Equals(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(in Int3 first, in Int3 second) => !first.Equals(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(in Int3 first, in Int3 second) => first.x < second.x && first.y < second.y && first.z < second.z;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(in Int3 first, in Int3 second) => first.x > second.x && first.y > second.y && first.z > second.z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(in Int3 first, in Int3 second) => first.x <= second.x && first.y <= second.y && first.z <= second.z;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(in Int3 first, in Int3 second) => first.x >= second.x && first.y >= second.y && first.z >= second.z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Int3 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Int3 other) => EqualsFast(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool EqualsFast(in Int3 other) => x == other.x && y == other.y && z == other.z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(in Int3 value) => value.XY;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(int value) => new Int3(value, value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(in Int3 value) => new Int4(value.x, value.y, value.z, 0);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(in Int3 value) => new Float2(value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float3(in Int3 value) => new Float3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(in Int3 value) => new Float4(value.x, value.y, value.z, 0f);

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Int3(UnityEngine.Vector3Int value) => new Int3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector3Int(in Int3 value) => new UnityEngine.Vector3Int(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector3(in Int3 value) => new UnityEngine.Vector3(value.x, value.y, value.z);
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

		/// <summary>
		/// Returns an enumerable that can be put into a foreach loop.
		/// Yields the three components of this vector in a series.
		/// </summary>
		public SeriesEnumerable Series() => new SeriesEnumerable(this);

		/// <summary>
		/// Returns an enumerable that can be put into a foreach loop; from (0,0,0) to (vector.x-1,vector.y-1,vector.z-1)
		/// If <paramref name="zeroAsOne"/> is true then the loop will treat zeros in the vector as ones.
		/// </summary>
		public LoopEnumerable Loop(bool zeroAsOne = false) => new LoopEnumerable(this, zeroAsOne);

		public readonly struct SeriesEnumerable : IEnumerable<int>
		{
			public SeriesEnumerable(in Int3 value) => enumerator = new Enumerator(value);

			readonly Enumerator enumerator;

			public Enumerator GetEnumerator() => enumerator;

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			IEnumerator<int> IEnumerable<int>.GetEnumerator() => GetEnumerator();

			public struct Enumerator : IEnumerator<int>
			{
				public Enumerator(in Int3 source)
				{
					this.source = source;
					index = -1;
				}

				readonly Int3 source;
				int index;

				object IEnumerator.Current => Current;
				public int Current => source[index];

				public bool MoveNext() => index++ < 2;
				public void Reset() => index = -1;

				public void Dispose() { }
			}
		}

		public readonly struct LoopEnumerable : IEnumerable<Int3>
		{
			public LoopEnumerable(in Int3 vector, bool zeroAsOne) => enumerator = new Enumerator(vector, zeroAsOne);

			readonly Enumerator enumerator;

			public Enumerator GetEnumerator() => enumerator;

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			IEnumerator<Int3> IEnumerable<Int3>.GetEnumerator() => GetEnumerator();

			public struct Enumerator : IEnumerator<Int3>
			{
				internal Enumerator(Int3 size, bool zeroAsOne)
				{
					direction = size.Signed;
					size = size.Absoluted;

					if (zeroAsOne) size = one.Max(size);
					this.size = size;

					product = size.Product;
					current = -1;
				}

				readonly Int3 direction;
				readonly Int3 size;

				readonly int product;
				int current;

				object IEnumerator.Current => Current;

				public Int3 Current => new Int3
				(
					current / (size.y * size.z) * direction.x,
					current / size.z % size.y * direction.y,
					current % size.z * direction.z
				);

				public bool MoveNext() => ++current < product;

				public void Reset() => current = -1;
				public void Dispose() { }
			}
		}

#endregion

	}
}