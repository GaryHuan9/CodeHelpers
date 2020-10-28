using System;
using System.Collections.Generic;
using CodeHelpers.Vectors;

namespace CodeHelpers
{
	public readonly struct MinMax : IEquatable<MinMax>
	{
		public MinMax(float min, float max)
		{
			this.min = Math.Min(min, max);
			this.max = Math.Max(min, max);
		}

		public MinMax(float value) => min = max = value;

		public MinMax(params float[] values)
		{
			min = float.MaxValue;
			max = float.MinValue;

			for (int i = 0; i < values.Length; i++)
			{
				float value = values[i];

				min = Math.Min(min, value);
				max = Math.Max(max, value);
			}
		}

		public MinMax(Float3 vector)
		{
			min = vector.MinComponent;
			max = vector.MaxComponent;
		}

		public MinMax(Float2 vector)
		{
			min = vector.MinComponent;
			max = vector.MaxComponent;
		}

		public readonly float min;
		public readonly float max;

		public float RandomValue => RandomHelper.Range(min, max);
		public float Middle => (max + min) / 2f;
		public float Range => max - min;

		public float Clamp(float value) => value.Clamp(min, max);
		public float Repeat(float value) => (value - min).Repeat(max - min) + min;
		public bool Contains(float value) => min <= value && value <= max;

		public float Lerp(float value) => Scalars.Lerp(min, max, value);
		public float InverseLerp(float value) => Scalars.InverseLerp(min, max, value);

		/// <summary>
		/// Is the magnitude of <paramref name="vector"/> contains in this <see cref="MinMax"/>?
		/// </summary>
		public bool ContainsMagnitude(Float3 vector)
		{
			float squared = vector.SquaredMagnitude;
			return min * min <= squared && squared <= max * max;
		}

		/// <summary>
		/// Is the magnitude of <paramref name="vector"/> contains in this <see cref="MinMax"/>?
		/// </summary>
		public bool ContainsMagnitude(Float2 vector)
		{
			float squared = vector.SquaredMagnitude;
			return min * min <= squared && squared <= max * max;
		}

		public MinMax GetEncapsulated(float value) => new MinMax(Math.Min(min, value), Math.Max(max, value));
		public MinMax GetEncapsulated(MinMax minMax) => new MinMax(Math.Min(min, minMax.min), Math.Max(max, minMax.max));
		public MinMax GetScaled(float value) => new MinMax((min - Middle) * value + Middle, (max - Middle) * value + Middle);

		public MinMax ToSignedAngles() => new MinMax(min.ToSignedAngle(), max.ToSignedAngle());
		public MinMax ToUnsignedAngles() => new MinMax(min.ToUnsignedAngle(), max.ToUnsignedAngle());

		public void Deconstruct(out float min, out float max)
		{
			min = this.min;
			max = this.max;
		}

		public static MinMax Zero => new MinMax(0f, 0f);
		public static MinMax One => new MinMax(1f, 1f);
		public static MinMax ZeroToOne => new MinMax(0f, 1f);
		public static MinMax OneToOne => new MinMax(-1f, 1f);
		public static MinMax MinToMax => new MinMax(float.MinValue, float.MaxValue);

		public static List<MinMax> GetRangesFromValue(MinMax[] minMaxes, float value)
		{
			List<MinMax> result = new List<MinMax>();

			for (int i = 0; i < minMaxes.Length; i++)
			{
				if (minMaxes[i].Contains(value)) result.Add(minMaxes[i]);
			}

			return result;
		}

		public static MinMax operator +(MinMax value, MinMax other) => new MinMax(value.min + other.min, value.max + other.max);
		public static MinMax operator -(MinMax value, MinMax other) => new MinMax(value.min - other.min, value.max - other.max);
		public static MinMax operator +(MinMax value, float other) => new MinMax(value.min + other, value.max + other);
		public static MinMax operator -(MinMax value, float other) => new MinMax(value.min - other, value.max - other);

		public static MinMax operator *(MinMax value, MinMax other) => new MinMax(value.min * other.min, value.max * other.max);
		public static MinMax operator /(MinMax value, MinMax other) => new MinMax(value.min / other.min, value.max / other.max);
		public static MinMax operator *(MinMax value, float other) => new MinMax(value.min * other, value.max * other);
		public static MinMax operator /(MinMax value, float other) => new MinMax(value.min / other, value.max / other);

		public static bool operator ==(MinMax value, MinMax other) => value.Equals(other);
		public static bool operator !=(MinMax value, MinMax other) => !value.Equals(other);

		public static implicit operator Float2(MinMax minMax) => new Float2(minMax.min, minMax.max);

		public override string ToString() => $"min : {min} max : {max}";

		public override bool Equals(object obj) => obj is MinMax minMax && Equals(minMax);
		public bool Equals(MinMax other) => Scalars.AlmostEquals(min, other.min) && Scalars.AlmostEquals(max, other.max);

		public override int GetHashCode()
		{
			unchecked
			{
				return (min.GetHashCode() * 397) ^ max.GetHashCode();
			}
		}
	}
}