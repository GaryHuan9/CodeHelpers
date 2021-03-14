using System;
using System.Collections.Generic;
using CodeHelpers.Mathematics;

namespace CodeHelpers.Collections
{
	/// <summary>
	/// A radix sorter. NOTE: The thread safe property is like <see cref="System.Random"/>, a single
	/// instance is not thread safe, however you can create one sorter for each thread to ensure safety.
	/// </summary>
	public class RadixSort
	{
		public RadixSort()
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
		public void Sort(uint[] array)
		{
			for (int i = 0; i < 32; i += 4)
			{
				bool hasRemain = false;

				for (int j = 0; j < array.Length; j++)
				{
					uint number = array[j];
					uint remain = number >> i;
					uint digit = remain & 0b1111;

					buckets[digit].Add(number);
					hasRemain |= remain != 0;
				}

				Copy(array, uintToUIntConverter);
				Clear();

				if (!hasRemain) break;
			}
		}

		/// <summary>
		/// Sorts the input array based on each element's two's complement bitwise representation.
		/// </summary>
		public void Sort(int[] array)
		{
			for (int i = 0; i < 32; i += 4)
			{
				bool hasRemain = false;

				for (int j = 0; j < array.Length; j++)
				{
					uint number = Scalars.Int32ToUInt32Bits(array[j]);

					uint remain = number >> i;
					uint digit = remain & 0b1111;

					if (i == 28) digit ^= 0b1000;

					buckets[digit].Add(number);
					hasRemain |= remain != 0;
				}

				Copy(array, uintToIntConverter);
				Clear();

				if (!hasRemain) break;
			}
		}

		/// <summary>
		/// Sorts the input float array based on each element's IEEE 754 bit representation.
		/// </summary>
		public void Sort(float[] array)
		{
			for (int i = 0; i < 32; i += 4)
			{
				bool hasRemain = false;

				for (int j = 0; j < array.Length; j++)
				{
					uint number = Scalars.SingleToUInt32Bits(array[j]);

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
							array[index++] = Scalars.UInt32ToSingleBits(bucket[k]);
						}
					}

					for (int j = 0; j < half; j++)
					{
						List<uint> bucket = buckets[j];

						for (int k = 0; k < bucket.Count; k++)
						{
							array[index++] = Scalars.UInt32ToSingleBits(bucket[k]);
						}
					}
				}
				else Copy(array, uintToFloatConverter);

				Clear();

				if (!hasRemain) break;
			}
		}

		void Copy<T>(IList<T> array, Func<uint, T> converter) where T : struct
		{
			int bucketIndex = 0;
			int numberIndex = 0;

			for (int j = 0; j < array.Count; j++)
			{
				while (numberIndex == buckets[bucketIndex].Count)
				{
					bucketIndex++;
					numberIndex = 0;
				}

				array[j] = converter(buckets[bucketIndex][numberIndex]);
				numberIndex++;
			}
		}

		void Clear()
		{
			for (int j = 0; j < buckets.Length; j++) buckets[j].Clear();
		}
	}
}