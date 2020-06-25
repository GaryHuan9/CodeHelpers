using UnityEngine;
using System.Diagnostics.Contracts;
using System;
using System.Collections.Generic;
using CodeHelpers.ThreadHelpers;

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

		public MinMax(Vector4 vector)
		{
			min = vector.MinValue();
			max = vector.MaxValue();
		}

		public MinMax(Vector3 vector)
		{
			min = vector.MinValue();
			max = vector.MaxValue();
		}

		public MinMax(Vector2 vector)
		{
			min = vector.MinValue();
			max = vector.MaxValue();
		}

		public readonly float min;
		public readonly float max;

		public float RandomValue => RandomHelper.Range(min, max);
		public float Middle => (max + min) / 2f;
		public float Range => max - min;

		public float Clamp(float value) => Mathf.Clamp(value, min, max);
		public float Repeat(float value) => (value - min).Repeat(max - min) + min;
		public bool Contains(float value) => min <= value && value <= max;

		public float Lerp(float value) => Mathf.Lerp(min, max, value);
		public float InverseLerp(float value) => Mathf.InverseLerp(min, max, value);

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

		public static MinMax operator +(MinMax minMax, MinMax other) => new MinMax(minMax.min + other.min, minMax.max + other.max);
		public static MinMax operator -(MinMax minMax, MinMax other) => new MinMax(minMax.min - other.min, minMax.max - other.max);
		public static MinMax operator +(MinMax minMax, float value) => new MinMax(minMax.min + value, minMax.max + value);
		public static MinMax operator -(MinMax minMax, float value) => new MinMax(minMax.min - value, minMax.max - value);

		public static MinMax operator *(MinMax minMax, MinMax other) => new MinMax(minMax.min * other.min, minMax.max * other.max);
		public static MinMax operator /(MinMax minMax, MinMax other) => new MinMax(minMax.min / other.min, minMax.max / other.max);
		public static MinMax operator *(MinMax minMax, float multiplier) => new MinMax(minMax.min * multiplier, minMax.max * multiplier);
		public static MinMax operator /(MinMax minMax, float divider) => new MinMax(minMax.min / divider, minMax.max / divider);

		public static bool operator ==(MinMax minMax1, MinMax minMax2) => Mathf.Approximately(minMax1.min, minMax2.min) && Mathf.Approximately(minMax1.max, minMax2.max);
		public static bool operator !=(MinMax minMax1, MinMax minMax2) => !(minMax1 == minMax2);

		public static implicit operator MinMax(Vector2 vector) => new MinMax(vector);
		public static implicit operator MinMax(Vector3 vector) => new MinMax(vector);
		public static implicit operator MinMax(Vector4 vector) => new MinMax(vector);

		public static implicit operator Vector2(MinMax minMax) => new Vector2(minMax.min, minMax.max);

		public override string ToString() => $"min : {min} max : {max}";

		public override bool Equals(object obj) => obj is MinMax minMax && Equals(minMax);
		public bool Equals(MinMax other) => other == this;

		public override int GetHashCode() => ((Vector2)this).GetHashCode();
	}
}