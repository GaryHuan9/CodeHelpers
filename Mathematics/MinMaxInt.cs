using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeHelpers.Mathematics
{
	public readonly struct MinMaxInt : IEquatable<MinMaxInt>
	{
		public MinMaxInt(int min, int max)
		{
			this.min = Math.Min(min, max);
			this.max = Math.Max(min, max);
		}

		//Not exposing this to outside since it may be confusing
		MinMaxInt(float min, float max) : this(min.Round(), max.Round()) { }

		public MinMaxInt(int value) => min = max = value;

		public MinMaxInt(params int[] values)
		{
			min = int.MaxValue;
			max = int.MinValue;

			for (int i = 0; i < values.Length; i++)
			{
				int value = values[i];

				min = Math.Min(min, value);
				max = Math.Max(max, value);
			}
		}

		public MinMaxInt(Int3 vector)
		{
			min = vector.MinComponent;
			max = vector.MaxComponent;
		}

		public MinMaxInt(Int2 vector)
		{
			min = vector.MinComponent;
			max = vector.MaxComponent;
		}

		public readonly int min;
		public readonly int max;

		public int RandomValue => RandomHelper.Range(min, max + 1);
		public float Middle => (max + min) / 2f;
		public int Range => max - min;

		public float Clamp(float value) => value.Clamp(min, max);
		public int Clamp(int value) => value.Clamp(min, max);

		public float Repeat(float value) => value.Repeat(min, max);
		public int Repeat(int value) => value.Repeat(min, max);

		public bool Contains(int value) => min <= value && value <= max;
		public bool Contains(float value) => min <= value && value <= max;

		public bool Contains(MinMaxInt value) => min <= value.min && value.max <= max;
		public bool Contains(MinMax value) => min <= value.min && value.max <= max;

		public bool Overlaps(MinMax value) => min <= value.max && value.min <= max;

		public float Lerp(float value) => Scalars.Lerp(min, max, value);
		public float InverseLerp(float value) => Scalars.InverseLerp(min, max, value);

		/// <summary>
		/// Is the magnitude of <paramref name="value"/> contains in this <see cref="MinMax"/>?
		/// </summary>
		public bool ContainsMagnitude(Float3 value)
		{
			float squared = value.SquaredMagnitude;
			return min * min <= squared && squared <= max * max;
		}

		/// <summary>
		/// Is the magnitude of <paramref name="value"/> contains in this <see cref="MinMax"/>?
		/// </summary>
		public bool ContainsMagnitude(Float2 value)
		{
			float squared = value.SquaredMagnitude;
			return min * min <= squared && squared <= max * max;
		}

		public MinMaxInt GetEncapsulated(int value) => new MinMaxInt(Math.Min(min, value), Math.Max(max, value));
		public MinMaxInt GetEncapsulated(MinMaxInt minMax) => new MinMaxInt(Math.Min(min, minMax.min), Math.Max(max, minMax.max));
		public MinMaxInt GetScaled(float value) => new MinMaxInt((min - Middle) * value + Middle, (max - Middle) * value + Middle);

		public MinMaxInt ToSignedAngles() => new MinMaxInt(min.ToSignedAngle(), max.ToSignedAngle());
		public MinMaxInt ToUnsignedAngles() => new MinMaxInt(min.ToUnsignedAngle(), max.ToUnsignedAngle());

		public LoopEnumerable Loop() => new LoopEnumerable(this);

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

		public static List<MinMaxInt> GetRangesFromValue(IEnumerable<MinMaxInt> ranges, float value) => ranges.Where(range => range.Contains(value)).ToList();

		public static MinMaxInt operator +(MinMaxInt value, MinMaxInt other) => new MinMaxInt(value.min + other.min, value.max + other.max);
		public static MinMaxInt operator -(MinMaxInt value, MinMaxInt other) => new MinMaxInt(value.min - other.min, value.max - other.max);
		public static MinMaxInt operator +(MinMaxInt value, int other) => new MinMaxInt(value.min + other, value.max + other);
		public static MinMaxInt operator -(MinMaxInt value, int other) => new MinMaxInt(value.min - other, value.max - other);

		public static MinMaxInt operator *(MinMaxInt value, MinMaxInt other) => new MinMaxInt(value.min * other.min, value.max * other.max);
		public static MinMaxInt operator /(MinMaxInt value, MinMaxInt other) => new MinMaxInt(value.min / other.min, value.max / other.max);
		public static MinMaxInt operator *(MinMaxInt value, int other) => new MinMaxInt(value.min * other, value.max * other);
		public static MinMaxInt operator /(MinMaxInt value, int other) => new MinMaxInt(value.min / other, value.max / other);

		public static bool operator ==(MinMaxInt value, MinMaxInt other) => value.Equals(other);
		public static bool operator !=(MinMaxInt value, MinMaxInt other) => !value.Equals(other);

		public static explicit operator Int2(MinMaxInt minMax) => new Int2(minMax.min, minMax.max);

		public override string ToString() => $"min : {min} max : {max}";

		public override bool Equals(object obj) => obj is MinMaxInt minMax && Equals(minMax);
		public bool Equals(MinMaxInt other) => min == other.min && max == other.max;

		public override int GetHashCode()
		{
			unchecked
			{
				return (min.GetHashCode() * 397) ^ max.GetHashCode();
			}
		}

		public readonly struct LoopEnumerable : IEnumerable<int>
		{
			public LoopEnumerable(MinMaxInt minMax) => enumerator = new Enumerator(minMax);

			readonly Enumerator enumerator;
			public Enumerator GetEnumerator() => enumerator;

			IEnumerator<int> IEnumerable<int>.GetEnumerator() => enumerator;
			IEnumerator IEnumerable.GetEnumerator() => enumerator;

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

				public bool MoveNext() => Current++ < minMax.max;

				public void Reset() => Current = minMax.min - 1;

				public void Dispose() { }
			}
		}
	}
}