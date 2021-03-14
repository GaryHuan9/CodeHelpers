using System;
using System.Threading;

namespace CodeHelpers.Threads
{
	public static class InterlockedHelper
	{
		public static int Read(ref int location) => Interlocked.CompareExchange(ref location, default, default);
		public static T Read<T>(ref T location) where T : class => Interlocked.CompareExchange(ref location, default, default);

		public static float Read(ref float location) => Interlocked.CompareExchange(ref location, default, default);
		public static double Read(ref double location) => Interlocked.CompareExchange(ref location, default, default);

		public static float Add(ref float location, float value)
		{
			float nextValue = location;

			while (true)
			{
				float currentValue = nextValue;
				float newValue = currentValue + value;

				nextValue = Interlocked.CompareExchange(ref location, newValue, currentValue);
				if (nextValue == currentValue) return newValue;
			}
		}

		public static double Add(ref double location, double value) //NOTE: currently does not correctly handle NaNs
		{
			double nextValue = location;

			while (true)
			{
				double currentValue = nextValue;        //The potential initial value if no other thread changed location
				double newValue = currentValue + value; //The potential result after the addition if no other thread changes location

				nextValue = Interlocked.CompareExchange(ref location, newValue, currentValue); //Only change location if it is unchanged
				if (nextValue == currentValue) return newValue;                                //If exchange was successful, addition finished
			}
		}

		public static int Max(ref int location, int other)
		{
			int nextValue = location;

			while (true)
			{
				int currentValue = nextValue;
				int newValue = Math.Max(currentValue, other);

				nextValue = Interlocked.CompareExchange(ref location, newValue, currentValue);
				if (nextValue == currentValue) return newValue;
			}
		}

		public static float Max(ref float location, float other)
		{
			float nextValue = location;

			while (true)
			{
				float currentValue = nextValue;
				float newValue = Math.Max(currentValue, other);

				nextValue = Interlocked.CompareExchange(ref location, newValue, currentValue);
				if (nextValue == currentValue) return newValue;
			}
		}

		public static long Max(ref long location, long other)
		{
			long nextValue = location;

			while (true)
			{
				long currentValue = nextValue;
				long newValue = Math.Max(currentValue, other);

				nextValue = Interlocked.CompareExchange(ref location, newValue, currentValue);
				if (nextValue == currentValue) return newValue;
			}
		}

		public static double Max(ref double location, double other)
		{
			double nextValue = location;

			while (true)
			{
				double currentValue = nextValue;
				double newValue = Math.Max(currentValue, other);

				nextValue = Interlocked.CompareExchange(ref location, newValue, currentValue);
				if (nextValue == currentValue) return newValue;
			}
		}

		public static int Min(ref int location, int other)
		{
			int nextValue = location;

			while (true)
			{
				int currentValue = nextValue;
				int newValue = Math.Min(currentValue, other);

				nextValue = Interlocked.CompareExchange(ref location, newValue, currentValue);
				if (nextValue == currentValue) return newValue;
			}
		}

		public static float Min(ref float location, float other)
		{
			float nextValue = location;

			while (true)
			{
				float currentValue = nextValue;
				float newValue = Math.Min(currentValue, other);

				nextValue = Interlocked.CompareExchange(ref location, newValue, currentValue);
				if (nextValue == currentValue) return newValue;
			}
		}

		public static long Min(ref long location, long other)
		{
			long nextValue = location;

			while (true)
			{
				long currentValue = nextValue;
				long newValue = Math.Min(currentValue, other);

				nextValue = Interlocked.CompareExchange(ref location, newValue, currentValue);
				if (nextValue == currentValue) return newValue;
			}
		}

		public static double Min(ref double location, double other)
		{
			double nextValue = location;

			while (true)
			{
				double currentValue = nextValue;
				double newValue = Math.Min(currentValue, other);

				nextValue = Interlocked.CompareExchange(ref location, newValue, currentValue);
				if (nextValue == currentValue) return newValue;
			}
		}
	}
}