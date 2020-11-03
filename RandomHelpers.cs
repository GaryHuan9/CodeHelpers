using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace CodeHelpers
{
	public static partial class RandomHelper
	{
		static RandomHelper() => Seed = Environment.TickCount;

#region Seeds

		static readonly Dictionary<SeedType, int> seeds = new Dictionary<SeedType, int>();
		static int currentThreadedSeed;

		/// <summary>
		/// Sets every type of seed.
		/// Gets the normal seed.
		/// </summary>
		public static int Seed
		{
			get
			{
				ExceptionHelper.InvalidIfNotMainThread();
				return seeds[SeedType.normal];
			}
			set
			{
				ExceptionHelper.InvalidIfNotMainThread();
				foreach (SeedType type in EnumHelper<SeedType>.enumValues) SetSeed(type, value);
			}
		}

		/// <summary>The thread independent seed.</summary>
		public static int ThreadSeed
		{
			set => threadRandom.Value = new Random(value);
		}

		public static int GetSeed(SeedType type) => seeds[type];

		public static void SetSeed(SeedType type, int seed)
		{
			if (seeds.ContainsKey(type) && seed == GetSeed(type)) return;

			seeds[type] = seed;

			switch (type)
			{
				case SeedType.noise:

					NoiseController.NoiseSeed = seed;
					break;

				case SeedType.threaded:

					Interlocked.Exchange(ref currentThreadedSeed, seed);
					int threadSeed = Interlocked.Increment(ref currentThreadedSeed);

					threadRandom = new ThreadLocal<Random>(() => new Random(threadSeed));
					break;
			}
		}

#endregion

		static ThreadLocal<Random> threadRandom;
		public static Random CurrentRandom => threadRandom.Value;

		/// <summary>
		/// Returns a double between 0d to 1d
		/// </summary>
		public static double Value => CurrentRandom.NextDouble();

		/// <summary>
		/// Returns a value between -1f to 1f
		/// </summary>
		public static float Value1To1 => (float)Value * 2f - 1f;

		/// <summary>
		/// Returns a random int inside (min inclusive, max exclusive)
		/// </summary>
		public static int Range(int min, int max) => CurrentRandom.Next(min, max);

		/// <summary>
		/// Returns a random int inside (0 inclusive, max exclusive)
		/// </summary>
		public static int Range(int max) => CurrentRandom.Next(max);

		/// <summary>
		/// Returns a random float inside [min,max)
		/// </summary>
		public static float Range(float min, float max)
		{
			if (min > max) throw ExceptionHelper.Invalid(nameof(min), min, InvalidType.minLargerThanMax);
			return (float)CurrentRandom.NextDouble() * (max - min) + min;
		}

		/// <summary>
		/// Returns a random float inside [0f,max)
		/// </summary>
		public static float Range(float max) => Range(0f, max);

		/// <summary>
		/// Returns a random double inside [min,max)
		/// </summary>
		public static double Range(double min, double max)
		{
			if (min > max) throw ExceptionHelper.Invalid(nameof(min), min, InvalidType.minLargerThanMax);
			return CurrentRandom.NextDouble() * (max - min) + min;
		}

		/// <summary>
		/// Returns a random double inside [0d,max)
		/// </summary>
		public static double Range(double max) => Range(0d, max);

		public static float RangeEpsilon(float min, float max, float epsilon = float.Epsilon) => Range(min + epsilon, max - epsilon);
		public static double RangeEpsilon(double min, double max, double epsilon = double.Epsilon) => Range(min + epsilon, max - epsilon);

		/// <summary>Gets random index based on their percentage of chosen.</summary>
		/// <param name="percentage">The array of percentages.</param>
		public static int EvaluatePercentage(int[] percentage)
		{
			if (percentage.Length == 0) throw ExceptionHelper.Invalid(nameof(percentage), InvalidType.collectionCountIs0);

			int sum = 0;

			for (int i = 0; i < percentage.Length; i++) sum += percentage[i];

			int random = Range(0, sum);
			int current = 0;

			for (int i = 0; i < percentage.Length; i++)
			{
				current += percentage[i];
				if (current > random) return i;
			}

			throw ExceptionHelper.NotPossible;
		}

		/// <summary>Gets random index based on their percentage of chosen.</summary>
		/// <param name="source">The array ValueTuples.</param>
		public static int EvaluatePercentage((int index, int percentage)[] source)
		{
			if (source.Length == 0) throw ExceptionHelper.Invalid(nameof(source), InvalidType.collectionCountIs0);

			int sum = 0;

			for (int i = 0; i < source.Length; i++) sum += source[i].percentage;

			int random = Range(0, sum);
			int current = 0;

			for (int i = 0; i < source.Length; i++)
			{
				current += source[i].percentage;
				if (current > random) return source[i].index;
			}

			throw ExceptionHelper.NotPossible;
		}

		public static T GetRandomFromCollection<T>(T[] array) => array[Range(0, array.Length)];
		public static T GetRandomFromCollection<T>(IList<T> list) => list[Range(0, list.Count)];
		public static T GetRandomFromCollection<T>(IReadOnlyList<T> list) => list[Range(0, list.Count)];

		/// <summary>
		/// Returns a random item from the dictionary.
		/// Assign the range of the indices of the dictionary to <paramref name="indexRange"/> if the dictionary is continuous.
		/// Continuous = no empty index between min and max (however there can be nulls). Passing in this parameter will significantly boost the performance.
		/// NOTE: <paramref name="indexRange"/> is [inclusive, exclusive)
		/// </summary>
		public static T GetRandomFromDictionary<T>(IDictionary<int, T> dictionary, MinMaxInt? indexRange = null)
		{
			int targetIndex = Range(0, dictionary.Count);
			if (indexRange == null) return dictionary.ElementAt(targetIndex).Value;

			if (dictionary.Count != indexRange.Value.Range) throw ExceptionHelper.Invalid(nameof(indexRange), indexRange, "the dictionary is not continuous or the range parameter is wrong!");
			int index = targetIndex + indexRange.Value.min;

			return dictionary[index];
		}

		/// <summary>
		/// Returns a random index based on their float value percentages.
		/// </summary>
		public static int GetRandomIndex(params float[] floats)
		{
			float randomNumber = 0;

			for (int i = 0; i < floats.Length; i++) randomNumber += floats[i];

			randomNumber *= (float)Value;

			for (int i = 0; i < floats.Length; i++)
			{
				float value = floats[i];
				if (randomNumber <= value) return i;
				randomNumber -= value;
			}

			throw ExceptionHelper.NotPossible;
		}

		[Flags]
		public enum SeedType
		{
			normal = 1,
			noise = 2,
			threaded = 4
			//Should be binary numbers continuing
		}

		public static int NoiseSize
		{
			get => NoiseController.Size;
			set => NoiseController.Size = value;
		}

		/// <summary>
		/// A class that will generate values based on your input. Same output gurarnteed if the input is identical.
		/// </summary>
		static class NoiseController
		{
			static float[] noiseSource;
			static object sourceLocker = new object();

			static int _seed;
			static int _size = 613; //NOTE: We do not want a number that 2^n because it will be easy to have repeated values
			//A prime number will be the best

			public static int NoiseSeed
			{
				get => _seed;
				set
				{
					if (_seed != value)
					{
						lock (sourceLocker)
						{
							_seed = value;
							RepopulateNoise();
						}
					}
				}
			}

			public static int Size
			{
				get => _size;
				set
				{
					if (_size == value) return;

					lock (sourceLocker)
					{
						_size = value;
						RepopulateNoise();
					}
				}
			}

			public static float GetSource(uint value)
			{
				lock (sourceLocker)
				{
					if (noiseSource == null) RepopulateNoise();
					return noiseSource[value % noiseSource.Length];
				}
			}

			static void RepopulateNoise()
			{
				lock (sourceLocker)
				{
					noiseSource = new float[Size];
					Random random = new Random(NoiseSeed);

					for (int i = 0; i < noiseSource.Length; i++)
					{
						noiseSource[i] = (float)random.NextDouble();
					}
				}
			}
		}

		/// <summary>
		/// A class that is mainly used for generating random numbers based on another value.
		/// </summary>
		public static class NoiseEvaluator
		{
			/// Returns a random number based on <paramref name="value"/> between 0f (inclusive) and 1f (exclusive).
			/// The number returned will only change if <paramref name="value"/> is different.
			public static float Evaluate<T>(T value) => unchecked(NoiseController.GetSource((uint)value.GetHashCode()));
		}
	}
}