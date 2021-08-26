#if !CODEHELPERS_UNITY

using System;
using System.Collections.Generic;
using CodeHelpers.Mathematics;

namespace CodeHelpers.Collections
{
	/// <summary>
	/// A radix sorter. NOTE: The thread safe property is like <see cref="System.Random"/>, a single
	/// instance is not thread safe, however you can create one sorter for each thread to ensure safety.
	/// </summary>
	public class RadixSorter
	{
		public RadixSorter()
		{
			buckets = new List<uint>[16];
			for (int i = 0; i < buckets.Length; i++) buckets[i] = new List<uint>();
		}

		readonly List<uint>[] buckets;

		static readonly Func<uint, uint> uintToUIntConverter = value => value;
		static readonly Func<uint, int> uintToIntConverter = Scalars.UInt32ToInt32Bits;
		static readonly Func<uint, float> uintToFloatConverter = Scalars.UInt32ToSingleBits;

		/// <summary>
		/// Sorts the input uint array using radix sort.
		/// </summary>
		public void Sort(Span<uint> span)
		{
			for (int i = 0; i < 32; i += 4)
			{
				bool hasRemain = false;

				for (int j = 0; j < span.Length; j++)
				{
					uint number = span[j];
					uint remain = number >> i;
					uint digit = remain & 0b1111;

					buckets[digit].Add(number);
					hasRemain |= remain != 0;
				}

				Copy(span, uintToUIntConverter);
				Clear();

				if (!hasRemain) break;
			}
		}

		/// <summary>
		/// Sorts the input array based on each element's two's complement bitwise representation.
		/// </summary>
		public void Sort(Span<int> span)
		{
			for (int i = 0; i < 32; i += 4)
			{
				bool hasRemain = false;

				for (int j = 0; j < span.Length; j++)
				{
					uint number = Scalars.Int32ToUInt32Bits(span[j]);

					uint remain = number >> i;
					uint digit = remain & 0b1111;

					if (i == 28) digit ^= 0b1000;

					buckets[digit].Add(number);
					hasRemain |= remain != 0;
				}

				Copy(span, uintToIntConverter);
				Clear();

				if (!hasRemain) break;
			}
		}

		/// <summary>
		/// Sorts the input float array based on each element's IEEE 754 bit representation.
		/// </summary>
		public void Sort(Span<float> span)
		{
			for (int i = 0; i < 32; i += 4)
			{
				bool hasRemain = false;

				for (int j = 0; j < span.Length; j++)
				{
					uint number = Scalars.SingleToUInt32Bits(span[j]);

					uint remain = number >> i;
					uint digit = remain & 0b1111;

					buckets[digit].Add(number);
					hasRemain |= remain != 0;
				}

				if (i == 28) //The last pass requires a special copy to support negative numbers
				{
					int index = 0; //The filling index targeting array
					int half = buckets.Length / 2;

					for (int j = buckets.Length - 1; j >= half; j--)
					{
						List<uint> bucket = buckets[j];

						for (int k = bucket.Count - 1; k >= 0; k--)
						{
							span[index++] = Scalars.UInt32ToSingleBits(bucket[k]);
						}
					}

					for (int j = 0; j < half; j++)
					{
						List<uint> bucket = buckets[j];

						for (int k = 0; k < bucket.Count; k++)
						{
							span[index++] = Scalars.UInt32ToSingleBits(bucket[k]);
						}
					}
				}
				else Copy(span, uintToFloatConverter);

				Clear();

				if (!hasRemain) break;
			}
		}

		void Copy<T>(Span<T> span, Func<uint, T> converter) where T : struct
		{
			int bucketIndex = 0;
			int numberIndex = 0;

			for (int j = 0; j < span.Length; j++)
			{
				while (numberIndex == buckets[bucketIndex].Count)
				{
					bucketIndex++;
					numberIndex = 0;
				}

				span[j] = converter(buckets[bucketIndex][numberIndex]);
				numberIndex++;
			}
		}

		void Clear()
		{
			foreach (var bucket in buckets) bucket.Clear();
		}
	}
}

#endif