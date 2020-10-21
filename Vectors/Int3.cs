using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CodeHelpers.Vectors
{
	public readonly struct Int3 : IEquatable<Int3>, IFormattable
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

		public static readonly Int3 Right = new Int3(1, 0, 0);
		public static readonly Int3 Left = new Int3(-1, 0, 0);

		public static readonly Int3 Up = new Int3(0, 1, 0);
		public static readonly Int3 Down = new Int3(0, -1, 0);

		public static readonly Int3 Forward = new Int3(0, 0, 1);
		public static readonly Int3 Backward = new Int3(0, 0, -1);

		public static readonly Int3 One = new Int3(1, 1, 1);
		public static readonly Int3 Zero = new Int3(0, 0, 0);
		public static readonly Int3 NegativeOne = new Int3(-1, -1, -1);

		public static readonly Int3 MaxValue = new Int3(int.MaxValue, int.MaxValue, int.MaxValue);
		public static readonly Int3 MinValue = new Int3(int.MinValue, int.MinValue, int.MinValue);

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
				if (squared == 0) return Float3.Zero;

				return this / (float)Math.Sqrt(squared);
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
			return ScalarHelper.AlmostEquals(magnitude, 0d) ? 0f : (float)Math.Acos(DotLong(other) / magnitude) * ScalarHelper.RadianToDegree;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SignedAngle(Int3 other, Int3 normal)
		{
			float angle = Angle(other);
			return Cross(other).Dot(normal) < 0f ? -angle : angle;
		}

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public UnityEngine.Vector3Int U() => new UnityEngine.Vector3Int(x, y, z);
#endif

#endregion

#region Static

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Min(Int3 left, Int3 right) => new Int3(Math.Min(left.x, right.x), Math.Min(left.y, right.y), Math.Min(left.z, right.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Max(Int3 left, Int3 right) => new Int3(Math.Max(left.x, right.x), Math.Max(left.y, right.y), Math.Max(left.z, right.z));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Lerp(Int3 left, Int3 right, Int3 value) => new Int3(ScalarHelper.Lerp(left.x, right.x, value.x), ScalarHelper.Lerp(left.y, right.y, value.y), ScalarHelper.Lerp(left.z, right.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Lerp(Int3 left, Int3 right, int value) => new Int3(ScalarHelper.Lerp(left.x, right.x, value), ScalarHelper.Lerp(left.y, right.y, value), ScalarHelper.Lerp(left.z, right.z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Lerp(Int3 left, Int3 right, Float3 value) => new Float3(ScalarHelper.Lerp(left.x, right.x, value.x), ScalarHelper.Lerp(left.y, right.y, value.y), ScalarHelper.Lerp(left.z, right.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Lerp(Int3 left, Int3 right, float value) => new Float3(ScalarHelper.Lerp(left.x, right.x, value), ScalarHelper.Lerp(left.y, right.y, value), ScalarHelper.Lerp(left.z, right.z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 InverseLerp(Int3 left, Int3 right, Int3 value) => new Int3(ScalarHelper.InverseLerp(left.x, right.x, value.x), ScalarHelper.InverseLerp(left.y, right.y, value.y), ScalarHelper.InverseLerp(left.z, right.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 InverseLerp(Int3 left, Int3 right, int value) => new Int3(ScalarHelper.InverseLerp(left.x, right.x, value), ScalarHelper.InverseLerp(left.y, right.y, value), ScalarHelper.InverseLerp(left.z, right.z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 InverseLerp(Int3 left, Int3 right, Float3 value) => new Float3(ScalarHelper.InverseLerp(left.x, right.x, value.x), ScalarHelper.InverseLerp(left.y, right.y, value.y), ScalarHelper.InverseLerp(left.z, right.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 InverseLerp(Int3 left, Int3 right, float value) => new Float3(ScalarHelper.InverseLerp(left.x, right.x, value), ScalarHelper.InverseLerp(left.y, right.y, value), ScalarHelper.InverseLerp(left.z, right.z, value));

#endregion

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator +(in Int3 left, in Int3 right) => new Int3(left.x + right.x, left.y + right.y, left.z + right.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator -(in Int3 left, in Int3 right) => new Int3(left.x - right.x, left.y - right.y, left.z - right.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator +(in Int3 left, in Float3 right) => new Float3(left.x + right.x, left.y + right.y, left.z + right.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator -(in Int3 left, in Float3 right) => new Float3(left.x - right.x, left.y - right.y, left.z - right.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator +(in Float3 left, in Int3 right) => new Float3(left.x + right.x, left.y + right.y, left.z + right.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator -(in Float3 left, in Int3 right) => new Float3(left.x - right.x, left.y - right.y, left.z - right.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator *(in Int3 left, in Int3 right) => new Int3(left.x * right.x, left.y * right.y, left.z * right.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator /(in Int3 left, in Int3 right) => new Int3(left.x / right.x, left.y / right.y, left.z / right.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(in Int3 left, in Float3 right) => new Float3(left.x * right.x, left.y * right.y, left.z * right.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(in Int3 left, in Float3 right) => new Float3(left.x / right.x, left.y / right.y, left.z / right.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(in Float3 left, in Int3 right) => new Float3(left.x * right.x, left.y * right.y, left.z * right.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(in Float3 left, in Int3 right) => new Float3(left.x / right.x, left.y / right.y, left.z / right.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator *(in Int3 left, int right) => new Int3(left.x * right, left.y * right, left.z * right);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator /(in Int3 left, int right) => new Int3(left.x / right, left.y / right, left.z / right);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(in Int3 left, float right) => new Float3(left.x * right, left.y * right, left.z * right);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(in Int3 left, float right) => new Float3(left.x / right, left.y / right, left.z / right);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator *(int left, in Int3 right) => new Int3(left * right.x, left * right.y, left * right.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator /(int left, in Int3 right) => new Int3(left / right.x, left / right.y, left / right.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(float left, in Int3 right) => new Float3(left * right.x, left * right.y, left * right.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(float left, in Int3 right) => new Float3(left / right.x, left / right.y, left / right.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator -(in Int3 value) => new Int3(-value.x, -value.y, -value.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator %(in Int3 left, in Int3 right) => new Int3(left.x % right.x, left.y % right.y, left.z % right.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(in Int3 left, in Float3 right) => new Float3(left.x % right.x, left.y % right.y, left.z % right.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(in Float3 left, in Int3 right) => new Float3(left.x % right.x, left.y % right.y, left.z % right.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator %(in Int3 left, int right) => new Int3(left.x % right, left.y % right, left.z % right);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator %(int left, in Int3 right) => new Int3(left % right.x, left % right.y, left % right.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(in Int3 left, float right) => new Float3(left.x % right, left.y % right, left.z % right);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(float left, in Int3 right) => new Float3(left % right.x, left % right.y, left % right.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(in Int3 left, in Int3 right) => left.Equals(right);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(in Int3 left, in Int3 right) => !left.Equals(right);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Int3 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Int3 other) => x == other.x && y == other.y && z == other.z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(int value) => new Int3(value, value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float3(Int3 value) => new Float3(value.x, value.y, value.z);

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Int3(UnityEngine.Vector3Int value) => new Int3(value.x, value.y, value.z);
#endif

#endregion

		public override int GetHashCode()
		{
			var a = this / (int)2f;

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