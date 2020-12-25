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
			float newCurrentValue = location;

			while (true)
			{
				float currentValue = newCurrentValue;
				float newValue = currentValue + value;

				newCurrentValue = Interlocked.CompareExchange(ref location, newValue, currentValue);
				if (newCurrentValue == currentValue) return newValue;
			}
		}

		public static double Add(ref double location, double value) //NOTE: currently does not correctly handle NaNs
		{
			double newCurrentValue = location;

			while (true)
			{
				double currentValue = newCurrentValue;  //The potential value if no other thread changed location
				double newValue = currentValue + value; //The potential result after the addition if location is unchanged

				newCurrentValue = Interlocked.CompareExchange(ref location, newValue, currentValue); //Only change location if it is unchanged
				if (newCurrentValue == currentValue) return newValue;                                //If exchange was successful, addition finished
			}
		}
	}
}