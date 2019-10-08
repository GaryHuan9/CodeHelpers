using System;
using UnityEngine;

namespace CodeHelpers.ColorHelpers
{
	public static class SharedColorController
	{
		internal class ColorClass
		{
			public ColorClass(byte r, byte g, byte b, byte a = 255)
			{
				this.r = r;
				this.g = g;
				this.b = b;
				this.a = a;
			}

			public ColorClass(float r, float g, float b, float a = 1f)
			{
				R = r;
				G = g;
				B = b;
				A = a;
			}

			public ColorClass(Color32 color) : this(color.r, color.g, color.b, color.a) { }
			public ColorClass(Color color) : this(color.r, color.g, color.b, color.a) { }

			byte r;
			byte g;
			byte b;
			byte a;

			public float R { get => (float)r / byte.MaxValue; set => r = FloatToByte(value); }
			public float G { get => (float)g / byte.MaxValue; set => g = FloatToByte(value); }
			public float B { get => (float)b / byte.MaxValue; set => b = FloatToByte(value); }
			public float A { get => (float)a / byte.MaxValue; set => a = FloatToByte(value); }

			byte FloatToByte(float value)
			{
				value = Mathf.Clamp01(value);
				return (byte)Math.Round(value * byte.MaxValue);
			}

			public static implicit operator Color32(ColorClass color) => new Color32(color.r, color.g, color.b, color.a);
			public static implicit operator Color(ColorClass color) => new Color(color.R, color.G, color.B, color.A);

			public static explicit operator ColorClass(Color32 color) => new ColorClass(color);
			public static explicit operator ColorClass(Color color) => new ColorClass(color);
		}
	}
}
