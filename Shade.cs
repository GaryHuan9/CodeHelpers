using System;
using CodeHelpers.Vectors;

namespace CodeHelpers
{
	public readonly struct Shade : IEquatable<Shade>
	{
		public Shade(byte r, byte g, byte b, byte a = byte.MaxValue) => data = (r << 0) | (g << 8) | (b << 16) | (a << 24);
		public Shade(float r, float g, float b, float a = 1f) : this(ToInteger(r), ToInteger(g), ToInteger(b), ToInteger(a)) { }

		/// <summary>
		/// Raw data, stores in chunks of 8: AABBGGRR
		/// </summary>
		readonly int data;

		public byte R => (byte)((data >> 0) & 0xFF);
		public byte G => (byte)((data >> 8) & 0xFF);
		public byte B => (byte)((data >> 16) & 0xFF);
		public byte A => (byte)((data >> 24) & 0xFF);

		public float RFloat => ToDecimal(R);
		public float GFloat => ToDecimal(G);
		public float BFloat => ToDecimal(B);
		public float AFloat => ToDecimal(A);

		public byte this[int index]
		{
			get
			{
				if (index >= 0 && 3 >= index) return (byte)((data >> (index * 8)) & 0xFF);
				throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
		}

		public static readonly Shade black = new Shade(0, 0, 0);

		static float ToDecimal(byte value) => (float)value / byte.MaxValue;
		static byte ToInteger(float value) => (byte)(value.Clamp(0f, 1f) * byte.MaxValue);

		public static explicit operator Shade(Float3 value) => new Shade(value.x, value.y, value.z);
		public static explicit operator Shade(Int3 value) => new Shade(value.x, value.y, value.z);

		public static explicit operator Float3(Shade value) => new Float3(value.RFloat, value.GFloat, value.BFloat);
		public static explicit operator Int3(Shade value) => new Int3(value.R, value.G, value.B);

		public static bool operator ==(Shade first, Shade second) => first.Equals(second);
		public static bool operator !=(Shade first, Shade second) => !first.Equals(second);

		public bool Equals(Shade other) => data == other.data;
		public override bool Equals(object obj) => obj is Shade other && Equals(other);

		public override int GetHashCode() => data;
		public override string ToString() => $"{nameof(R)}: {R}, {nameof(G)}: {G}, {nameof(B)}: {B}, {nameof(A)}: {A}";
	}
}