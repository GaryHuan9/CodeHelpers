using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CodeHelpers.Vectors
{
	public readonly struct Int2 : IEquatable<Int2>, IFormattable
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

		public int Sum
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x + y;
		}

		public long SumLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)x + y;
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
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int2(x.Signed(), y.Signed());
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

#endregion

#endregion

#region Methods

#region Instance

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public int Dot(Int2 other) => x * other.x + y * other.y;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public long DotLong(Int2 other) => (long)x * other.x + (long)y * other.y;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Angle(Int2 other) => Math.Abs(SignedAngle(other));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SignedAngle(Int2 other) => (float)Math.Atan2((long)x * other.y - (long)y * other.x, DotLong(other)) * Scalars.RadianToDegree;

#endregion

#region Static

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Min(Int2 first, Int2 second) => new Int2(Math.Min(first.x, second.x), Math.Min(first.y, second.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Max(Int2 first, Int2 second) => new Int2(Math.Max(first.x, second.x), Math.Max(first.y, second.y));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Lerp(Int2 first, Int2 second, Int2 value) => new Int2(Scalars.Lerp(first.x, second.x, value.x), Scalars.Lerp(first.y, second.y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Lerp(Int2 first, Int2 second, int value) => new Int2(Scalars.Lerp(first.x, second.x, value), Scalars.Lerp(first.y, second.y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Lerp(Int2 first, Int2 second, Float2 value) => new Float2(Scalars.Lerp(first.x, second.x, value.x), Scalars.Lerp(first.y, second.y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Lerp(Int2 first, Int2 second, float value) => new Float2(Scalars.Lerp(first.x, second.x, value), Scalars.Lerp(first.y, second.y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 InverseLerp(Int2 first, Int2 second, Int2 value) => new Int2(Scalars.InverseLerp(first.x, second.x, value.x), Scalars.InverseLerp(first.y, second.y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 InverseLerp(Int2 first, Int2 second, int value) => new Int2(Scalars.InverseLerp(first.x, second.x, value), Scalars.InverseLerp(first.y, second.y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 InverseLerp(Int2 first, Int2 second, Float2 value) => new Float2(Scalars.InverseLerp(first.x, second.x, value.x), Scalars.InverseLerp(first.y, second.y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 InverseLerp(Int2 first, Int2 second, float value) => new Float2(Scalars.InverseLerp(first.x, second.x, value), Scalars.InverseLerp(first.y, second.y, value));

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
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator UnityEngine.Vector2(Int2 value) => new UnityEngine.Vector2(value.x, value.y);
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
	}
}