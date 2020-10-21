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

		public static readonly Int2 Right = new Int2(1, 0);
		public static readonly Int2 Left = new Int2(-1, 0);

		public static readonly Int2 Up = new Int2(0, 1);
		public static readonly Int2 Down = new Int2(0, -1);

		public static readonly Int2 One = new Int2(1, 1);
		public static readonly Int2 Zero = new Int2(0, 0);
		public static readonly Int2 NegativeOne = new Int2(-1, -1);

		public static readonly Int2 MaxValue = new Int2(int.MaxValue, int.MaxValue);
		public static readonly Int2 MinValue = new Int2(int.MinValue, int.MinValue);

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
				if (squared == 0) return Float2.Zero;

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
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SignedAngle(Int2 other) => (float)Math.Atan2((long)x * other.y - (long)y * other.x, DotLong(other)) * ScalarHelper.RadianToDegree;

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public UnityEngine.Vector2Int U() => new UnityEngine.Vector2Int(x, y);
#endif

#endregion

#region Static

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Min(Int2 left, Int2 right) => new Int2(Math.Min(left.x, right.x), Math.Min(left.y, right.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Max(Int2 left, Int2 right) => new Int2(Math.Max(left.x, right.x), Math.Max(left.y, right.y));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Lerp(Int2 left, Int2 right, Int2 value) => new Int2(ScalarHelper.Lerp(left.x, right.x, value.x), ScalarHelper.Lerp(left.y, right.y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Lerp(Int2 left, Int2 right, int value) => new Int2(ScalarHelper.Lerp(left.x, right.x, value), ScalarHelper.Lerp(left.y, right.y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Lerp(Int2 left, Int2 right, Float2 value) => new Float2(ScalarHelper.Lerp(left.x, right.x, value.x), ScalarHelper.Lerp(left.y, right.y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 Lerp(Int2 left, Int2 right, float value) => new Float2(ScalarHelper.Lerp(left.x, right.x, value), ScalarHelper.Lerp(left.y, right.y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 InverseLerp(Int2 left, Int2 right, Int2 value) => new Int2(ScalarHelper.InverseLerp(left.x, right.x, value.x), ScalarHelper.InverseLerp(left.y, right.y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 InverseLerp(Int2 left, Int2 right, int value) => new Int2(ScalarHelper.InverseLerp(left.x, right.x, value), ScalarHelper.InverseLerp(left.y, right.y, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 InverseLerp(Int2 left, Int2 right, Float2 value) => new Float2(ScalarHelper.InverseLerp(left.x, right.x, value.x), ScalarHelper.InverseLerp(left.y, right.y, value.y));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 InverseLerp(Int2 left, Int2 right, float value) => new Float2(ScalarHelper.InverseLerp(left.x, right.x, value), ScalarHelper.InverseLerp(left.y, right.y, value));

#endregion

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator +(in Int2 left, in Int2 right) => new Int2(left.x + right.x, left.y + right.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator -(in Int2 left, in Int2 right) => new Int2(left.x - right.x, left.y - right.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator +(in Int2 left, in Float2 right) => new Float2(left.x + right.x, left.y + right.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator -(in Int2 left, in Float2 right) => new Float2(left.x - right.x, left.y - right.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator +(in Float2 left, in Int2 right) => new Float2(left.x + right.x, left.y + right.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator -(in Float2 left, in Int2 right) => new Float2(left.x - right.x, left.y - right.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator *(in Int2 left, in Int2 right) => new Int2(left.x * right.x, left.y * right.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator /(in Int2 left, in Int2 right) => new Int2(left.x / right.x, left.y / right.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(in Int2 left, in Float2 right) => new Float2(left.x * right.x, left.y * right.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(in Int2 left, in Float2 right) => new Float2(left.x / right.x, left.y / right.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(in Float2 left, in Int2 right) => new Float2(left.x * right.x, left.y * right.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(in Float2 left, in Int2 right) => new Float2(left.x / right.x, left.y / right.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator *(in Int2 left, int right) => new Int2(left.x * right, left.y * right);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator /(in Int2 left, int right) => new Int2(left.x / right, left.y / right);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(in Int2 left, float right) => new Float2(left.x * right, left.y * right);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(in Int2 left, float right) => new Float2(left.x / right, left.y / right);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator *(int left, in Int2 right) => new Int2(left * right.x, left * right.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator /(int left, in Int2 right) => new Int2(left / right.x, left / right.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator *(float left, in Int2 right) => new Float2(left * right.x, left * right.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator /(float left, in Int2 right) => new Float2(left / right.x, left / right.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator -(in Int2 value) => new Int2(-value.x, -value.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator %(in Int2 left, in Int2 right) => new Int2(left.x % right.x, left.y % right.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(in Int2 left, in Float2 right) => new Float2(left.x % right.x, left.y % right.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(in Float2 left, in Int2 right) => new Float2(left.x % right.x, left.y % right.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator %(in Int2 left, int right) => new Int2(left.x % right, left.y % right);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator %(int left, in Int2 right) => new Int2(left % right.x, left % right.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(in Int2 left, float right) => new Float2(left.x % right, left.y % right);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 operator %(float left, in Int2 right) => new Float2(left % right.x, left % right.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(in Int2 left, in Int2 right) => left.Equals(right);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(in Int2 left, in Int2 right) => !left.Equals(right);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Int2 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Int2 other) => x == other.x && y == other.y;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(int value) => new Int2(value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float2(Int2 value) => new Float2(value.x, value.y);

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Int2(UnityEngine.Vector2Int value) => new Int2(value.x, value.y);
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