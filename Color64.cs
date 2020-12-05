using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeHelpers.Vectors;

namespace CodeHelpers
{
	[StructLayout(LayoutKind.Sequential)]
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
		public static readonly Color64 white = new Color64(ushort.MaxValue, ushort.MaxValue, ushort.MaxValue);

		static float ToDecimal(ushort value) => (float)value / ushort.MaxValue;
		static ushort ToInteger(float value) => (ushort)(value.Clamp(0f, 1f) * ushort.MaxValue);

		public static explicit operator Color64(Float3 value) => new Color64(value.x, value.y, value.z);
		public static explicit operator Color64(Int3 value) => new Color64(value.x, value.y, value.z);

		public static explicit operator Float3(Color64 value) => new Float3(value.RFloat, value.GFloat, value.BFloat);
		public static explicit operator Int3(Color64 value) => new Int3(value.r, value.g, value.b);

		public static explicit operator Float4(Color64 value) => new Float4(value.RFloat, value.GFloat, value.BFloat, value.AFloat);
		public static explicit operator Color32(Color64 value) => new Color32(value.RFloat, value.GFloat, value.BFloat, value.AFloat);

#if CODEHELPERS_UNITY
		public static explicit operator UnityEngine.Color32(Color64 value) => new Color32(value.RFloat, value.GFloat, value.BFloat, value.AFloat); //There is an implicit cast here
		public static implicit operator UnityEngine.Color(Color64 value) => new UnityEngine.Color(value.RFloat, value.GFloat, value.BFloat, value.AFloat);

		public static implicit operator Color64(UnityEngine.Color32 value) => (Color64)(Color32)value;
		public static explicit operator Color64(UnityEngine.Color value) => new Color64(value.r, value.g, value.b, value.a);
#endif

		public static bool operator ==(Color64 first, Color64 second) => first.Equals(second);
		public static bool operator !=(Color64 first, Color64 second) => !first.Equals(second);

		public bool Equals(Color64 other) => r == other.r && g == other.g && b == other.b && a == other.a;
		public override bool Equals(object obj) => obj is Color64 other && Equals(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = r.GetHashCode();
				hashCode = (hashCode * 397) ^ g.GetHashCode();
				hashCode = (hashCode * 397) ^ b.GetHashCode();
				hashCode = (hashCode * 397) ^ a.GetHashCode();
				return hashCode;
			}
		}

		public override string ToString() => $"{nameof(r)}: {r}, {nameof(g)}: {g}, {nameof(b)}: {b}, {nameof(a)}: {a}";
	}
}