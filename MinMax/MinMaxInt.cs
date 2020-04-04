using UnityEngine;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CodeHelpers.ThreadHelpers;

namespace CodeHelpers
{
	[Serializable]
	public readonly struct MinMaxInt : IEquatable<MinMaxInt>, IEnumerable<int>
	{
		public MinMaxInt(int min, int max)
		{
			this.min = Math.Min(min, max);
			this.max = Math.Max(min, max);
		}

		//Not exposing this to outside since it may be confusing
		MinMaxInt(float min, float max) : this(Mathf.RoundToInt(min), Mathf.RoundToInt(max)) { }

		public MinMaxInt(int value) => min = max = value;

		public MinMaxInt(params int[] values)
		{
			min = Mathf.Min(values);
			max = Mathf.Max(values);
		}

		public MinMaxInt(Vector4 vector)
		{
			min = Mathf.RoundToInt(vector.MinValue());
			max = Mathf.RoundToInt(vector.MaxValue());
		}

		public MinMaxInt(Vector3Int vector)
		{
			min = vector.MinValue();
			max = vector.MaxValue();
		}

		public MinMaxInt(Vector2Int vector)
		{
			min = vector.MinValue();
			max = vector.MaxValue();
		}

		public readonly int min;
		public readonly int max;

		public int RandomValue => RandomHelper.Range(min, max);
		public float Middle => (max + min) / 2f;
		public int Range => max - min;

		public float Clamp(float value) => Mathf.Clamp(value, min, max);
		public int Clamp(int value) => Mathf.Clamp(value, min, max);

		public float Repeat(float value) => (value - min).Repeat(max - min) + min;
		public int Repeat(int value) => (value - min).Repeat(max - min) + min;

		[Pure] public bool Contains(int value) => min <= value && value <= max;
		[Pure] public bool Contains(float value) => min <= value && value <= max;

		[Pure] public bool Contains(MinMaxInt minMax) => Contains(minMax.min) && Contains(minMax.max);
		[Pure] public bool Contains(MinMax minMax) => Contains(minMax.min) && Contains(minMax.max);

		[Pure] public float Lerp(float value) => Mathf.Lerp(min, max, value);
		[Pure] public float InverseLerp(float value) => Mathf.InverseLerp(min, max, value);

		public MinMaxInt GetEncapsulated(int value) => new MinMaxInt(Math.Min(min, value), Math.Max(max, value));
		public MinMaxInt GetEncapsulated(MinMaxInt minMax) => new MinMaxInt(Math.Min(min, minMax.min), Math.Max(max, minMax.max));
		public MinMaxInt GetScaled(float value) => new MinMaxInt((min - Middle) * value + Middle, (max - Middle) * value + Middle);

		public MinMaxInt ToSignedAngles() => new MinMaxInt(min.ToSignedAngle(), max.ToSignedAngle());
		public MinMaxInt ToUnsignedAngles() => new MinMaxInt(min.ToUnsignedAngle(), max.ToUnsignedAngle());

		public void Deconstruct(out int min, out int max)
		{
			min = this.min;
			max = this.max;
		}

		public static MinMaxInt Zero => new MinMaxInt(0, 0);
		public static MinMaxInt One => new MinMaxInt(1, 1);
		public static MinMaxInt ZeroToOne => new MinMaxInt(0, 1);
		public static MinMaxInt OneToOne => new MinMaxInt(-1, 1);
		public static MinMaxInt MinToMax => new MinMaxInt(int.MinValue, int.MaxValue);

		public static List<MinMaxInt> GetRangesFromValue(IEnumerable<MinMaxInt> minMaxes, float value) =>
			minMaxes.Where(t => t.Contains(value)).ToList();

		public static MinMaxInt operator +(MinMaxInt minMax, MinMaxInt other) => new MinMaxInt(minMax.min + other.min, minMax.max + other.max);
		public static MinMaxInt operator -(MinMaxInt minMax, MinMaxInt other) => new MinMaxInt(minMax.min - other.min, minMax.max - other.max);
		public static MinMaxInt operator +(MinMaxInt minMax, int value) => new MinMaxInt(minMax.min + value, minMax.max + value);
		public static MinMaxInt operator -(MinMaxInt minMax, int value) => new MinMaxInt(minMax.min - value, minMax.max - value);

		public static MinMaxInt operator *(MinMaxInt minMax, MinMaxInt other) => new MinMaxInt(minMax.min * other.min, minMax.max * other.max);
		public static MinMaxInt operator /(MinMaxInt minMax, MinMaxInt other) => new MinMaxInt(minMax.min / other.min, minMax.max / other.max);
		public static MinMaxInt operator *(MinMaxInt minMax, int multiplier) => new MinMaxInt(minMax.min * multiplier, minMax.max * multiplier);
		public static MinMaxInt operator /(MinMaxInt minMax, int divider) => new MinMaxInt(minMax.min / divider, minMax.max / divider);

		public static bool operator ==(MinMaxInt minMax1, MinMaxInt minMax2) => minMax1.min == minMax2.min && minMax1.max == minMax2.max;
		public static bool operator !=(MinMaxInt minMax1, MinMaxInt minMax2) => !(minMax1 == minMax2);

		public static implicit operator MinMaxInt(Vector2 vector) => new MinMaxInt(vector);
		public static implicit operator MinMaxInt(Vector3 vector) => new MinMaxInt(vector);
		public static implicit operator MinMaxInt(Vector4 vector) => new MinMaxInt(vector);

		public static explicit operator Vector2Int(MinMaxInt minMax) => new Vector2Int(minMax.min, minMax.max);

		public override string ToString() => $"min : {min} max : {max}";

		public override bool Equals(object obj) => obj is MinMaxInt minMax && Equals(minMax);
		public bool Equals(MinMaxInt other) => other == this;

		public override int GetHashCode() => ((Vector2Int)this).GetHashCode();

		public Enumerator GetEnumerator() => new Enumerator(this);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		IEnumerator<int> IEnumerable<int>.GetEnumerator() => GetEnumerator();

		public struct Enumerator : IEnumerator<int>
		{
			public Enumerator(MinMaxInt minMax)
			{
				this.minMax = minMax;
				Current = minMax.min - 1;
			}

			readonly MinMaxInt minMax;

			object IEnumerator.Current => Current;
			public int Current { get; private set; }

			public bool MoveNext()
			{
				Current++;
				return Current >= minMax.max;
			}

			public void Reset() => Current = minMax.min - 1;

			public void Dispose() { }
		}
	}
}