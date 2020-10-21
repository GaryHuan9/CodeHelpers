using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CodeHelpers.Vectors
{
	public struct Int3 : IEquatable<Int3>, IFormattable
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

#region Methods

#region Instance

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public UnityEngine.Vector3Int U() => new UnityEngine.Vector3Int(x, y, z);
#endif

#endregion

#endregion

#region Operators

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