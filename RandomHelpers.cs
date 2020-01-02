using System;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using RandomS = System.Random;
using CodeHelpers.ThreadHelpers;

namespace CodeHelpers
{
	public static class RandomHelper
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
				if (!ThreadHelper.IsInMainThread) throw new Exception("Please only invoke this in the main thread.");
				return seeds[SeedType.normal];
			}

			set
			{
				if (!ThreadHelper.IsInMainThread) throw new Exception("Please only invoke this in the main thread.");

				var typeValues = (int[])Enum.GetValues(typeof(SeedType));

				for (int i = 0; i < typeValues.Length; i++)
				{
					SetSeed((SeedType)typeValues[i], value);
				}
			}
		}

		/// <summary>The thread independnent seed.</summary>
		public static int ThreadSeed
		{
			set => threadRandom.Value = new RandomS(value);
		}

		public static int GetSeed(SeedType type) => seeds[type];

		public static void SetSeed(SeedType type, int seed)
		{
			if (!seeds.ContainsKey(type) || seed != GetSeed(type))
			{
				seeds[type] = seed;

				switch (type)
				{
					case SeedType.noise:

						NoiseController.NoiseSeed = seed;
						break;

					case SeedType.threaded:

						Interlocked.Exchange(ref currentThreadedSeed, seed);
						threadRandom = new ThreadLocal<RandomS>(() => new RandomS(Interlocked.Increment(ref currentThreadedSeed)));

						break;
				}
			}
		}

#endregion

		static ThreadLocal<RandomS> threadRandom;
		public static RandomS CurrentRandom => threadRandom.Value;

		/// <summary>
		/// Returns a double between 0d to 1d
		/// </summary>
		public static double Value => CurrentRandom.NextDouble();

		/// <summary>
		/// Returns a value between -1f to 1f
		/// </summary>
		public static float Value1To1 => (float)Value * 2f - 1f;

		/// <summary>
		/// Returns a random int inside [min,max) 
		/// </summary>
		public static int Range(int min, int max) => CurrentRandom.Next(min, max);

		/// <summary>
		/// Returns a random int inside [0,max) 
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

		/// <summary>
		/// Tilts the vector <paramref name="direction"/> randomly at an angle of <paramref name="angle"/>.
		/// Imagine a random plane that is created aligned to <paramref name="direction"/>, then this method
		/// will rotate <paramref name="direction"/> by <paramref name="angle"/>.
		/// </summary>
		public static Vector3 Tilt(Vector3 direction, float angle)
		{
			var axis = Quaternion.FromToRotation(Vector3.forward, direction) * Vector2.right.Rotate(Range(360f));
			return Quaternion.AngleAxis(angle, axis) * direction;
		}

		public static Color GetRandomColorBetweenColors(Color color1, Color color2) => Color.Lerp(color1, color2, (float)Value);

		public static T GetRandomFromCollection<T>(T[] array) => array[Range(0, array.Length)];
		public static T GetRandomFromCollection<T>(IList<T> list) => list[Range(0, list.Count)];
		public static T GetRandomFromCollection<T>(IReadOnlyList<T> list) => list[Range(0, list.Count)];

		/// <summary>Fast random will only work if you are sure the dictionary can be indexed like an array!</summary>
		public static T GetRandomFromDictionary<T>(IDictionary<int, T> dictionary, bool fastRandom = false)
		{
			int targetIndex = Range(0, dictionary.Count);
			if (fastRandom) return dictionary[targetIndex];

			int index = 0;

			foreach (var pair in dictionary)
			{
				if (index++ == targetIndex) return pair.Value;
			}

			throw ExceptionHelper.NotPossible;
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

			static int _seed;
			static int _size = 127; //NOTE: We do not want a number that 2^n because it will be easy to have repeated values
			//A prime number will be the best

			public static int NoiseSeed
			{
				get => _seed;
				set
				{
					if (_seed != value)
					{
						_seed = value;
						RepopulateNoise();
					}
				}
			}

			public static int Size
			{
				get => _size;
				set
				{
					if (_size == value) return;

					_size = value;
					RepopulateNoise();
				}
			}

			public static float GetSource(uint value)
			{
				if (noiseSource == null) RepopulateNoise();
				return noiseSource[value % noiseSource.Length];
			}

			static void RepopulateNoise()
			{
				noiseSource = new float[Size];
				RandomS random = new RandomS(NoiseSeed);

				for (int i = 0; i < noiseSource.Length; i++)
				{
					noiseSource[i] = (float)random.NextDouble();
				}
			}
		}

		/// <summary>
		/// A class that is mainly used for generating random numbers based on another value.
		/// </summary>
		public static class NoiseEvaluator
		{
			const int BigPrime1 = 105691;
			const int BigPrime2 = 104827;
			const int BigPrime3 = 105167;
			const int BigPrime4 = 105407;

			static int GetInt(float value)
			{
#if UNSAFE_CODE_ENABLED
				return CodeHelper.SingleToInt32Bits(value);
#else
				return value.GetHashCode();
#endif
			}

			//NOTE: The conversion from int to uint is unchecked, which means if the int value is negative, it will get warped to a large positive number
			static float GetSource(float value) => unchecked(NoiseController.GetSource((uint)GetInt(value * BigPrime4)));
			static float GetSource(int value) => unchecked(NoiseController.GetSource((uint)value));

			/// <summary>
			/// Returns a random number based on <paramref name="value"/> between 0f (inclusive) and 1f (exclusive).
			/// The number returned will only change if <paramref name="value"/> is different.
			/// </summary>
			public static float Evaluate(int value) => GetSource(value);

			/// <summary>
			/// Returns a random number based on <paramref name="value"/> between 0f (inclusive) and 1f (exclusive).
			/// The number returned will only change if <paramref name="value"/> is different.
			/// </summary>
			public static float Evaluate(float value) => GetSource(value);

			/// <summary>
			/// Returns a random number based on <paramref name="value"/> between 0f (inclusive) and 1f (exclusive).
			/// The number returned will only change if <paramref name="value"/> is different.
			/// </summary>
			public static float Evaluate(Vector3Int value)
			{
				unchecked
				{
					int result = BigPrime1;

					result = result * BigPrime2 + value.x;
					result = result * BigPrime2 + value.y;
					result = result * BigPrime2 + value.z;

					return GetSource(result);
				}
			}

			/// <summary>
			/// Returns a random number based on <paramref name="value"/> between 0f (inclusive) and 1f (exclusive).
			/// The number returned will only change if <paramref name="value"/> is different.
			/// </summary>
			public static float Evaluate(Vector3 value)
			{
				unchecked
				{
					int result = BigPrime1;

					result = result * BigPrime2 + GetInt(value.x);
					result = result * BigPrime2 + GetInt(value.y);
					result = result * BigPrime2 + GetInt(value.z);

					return GetSource(result);
				}
			}

			/// <summary>
			/// Returns a random number based on <paramref name="value"/> between 0f (inclusive) and 1f (exclusive).
			/// The number returned will only change if <paramref name="value"/> is different.
			/// </summary>
			public static float Evaluate(Vector2Int value)
			{
				unchecked
				{
					int result = BigPrime1;

					result = result * BigPrime2 + value.x;
					result = result * BigPrime2 + value.y;

					return GetSource(result);
				}
			}

			/// <summary>
			/// Returns a random number based on <paramref name="value"/> between 0f (inclusive) and 1f (exclusive).
			/// The number returned will only change if <paramref name="value"/> is different.
			/// </summary>
			public static float Evaluate(Vector2 value)
			{
				unchecked
				{
					int result = BigPrime1;

					result = result * BigPrime2 + GetInt(value.x);
					result = result * BigPrime2 + GetInt(value.y);

					return GetSource(result);
				}
			}

			/// <summary>
			/// Returns a random number based on <paramref name="value"/> between 0f (inclusive) and 1f (exclusive).
			/// The number returned will only change if <paramref name="value"/> is different.
			/// </summary>
			public static float Evaluate(object value)
			{
				return GetSource(value.GetHashCode());
			}
		}
	}
}