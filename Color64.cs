using System;
using CodeHelpers.Vectors;

namespace CodeHelpers
{
	public readonly struct Color64 : IEquatable<Color64>
	{
		public Color64(ushort r, ushort g, ushort b, ushort a = ushort.MaxValue)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}

		public Color64(float r, float g, float b, float a = 1f) : this(ToInteger(r), ToInteger(g), ToInteger(b), ToInteger(a)) { }

		public readonly ushort r;
		public readonly ushort g;
		public readonly ushort b;
		public readonly ushort a;

		public float RFloat => ToDecimal(r);
		public float GFloat => ToDecimal(g);
		public float BFloat => ToDecimal(b);
		public float AFloat => ToDecimal(a);

		public ushort this[int index]
		{
			get
			{
#if UNSAFE_CODE_ENABLED
				unsafe
				{
					if (index < 0 || 3 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
					fixed (Color64* pointer = &this) return ((ushort*)pointer)[index];
				}
#else
				switch (index)
				{
					case 0: return r;
					case 1: return g;
					case 2: return b;
					case 3: return a;
				}

				throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
#endif
			}
		}

		public static readonly Color64 black = new Color64(0, 0, 0);

		static float ToDecimal(ushort value) => (float)value / ushort.MaxValue;
		static ushort ToInteger(float value) => (ushort)(value.Clamp(0f, 1f) * ushort.MaxValue);

		public static explicit operator Color64(Float3 value) => new Color64(value.x, value.y, value.z);
		public static explicit operator Color64(Int3 value) => new Color64(value.x, value.y, value.z);

		public static explicit operator Float3(Color64 value) => new Float3(value.RFloat, value.GFloat, value.BFloat);
		public static explicit operator Int3(Color64 value) => new Int3(value.r, value.g, value.b);

		public static bool operator ==(Color64 first, Color64 second) => first.Equals(second);
		public static bool operator !=(Color64 first, Color64 second) => !first.Equals(second);

		public bool Equals(Color64 other) => r == other.r && g == other.g && b == other.b && a == other.a;
		public override bool Equals(object obj) => obj is Color64 other && Equals(other);

		public override int GetHashCode() => HashCode.Combine(r, g, b, a);
		public override string ToString() => $"{nameof(r)}: {r}, {nameof(g)}: {g}, {nameof(b)}: {b}, {nameof(a)}: {a}";
	}
}