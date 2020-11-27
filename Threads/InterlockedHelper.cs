using System.Threading;

namespace CodeHelpers.Threads
{
	public static class InterlockedHelper
	{
		public static int Read(ref int location) => Interlocked.CompareExchange(ref location, 0, 0);

		public static float Read(ref float location) => Interlocked.CompareExchange(ref location, 0f, 0f);
		public static double Read(ref double location) => Interlocked.CompareExchange(ref location, 0d, 0d);

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

		public static double Add(ref double location, double value)
		{
			double newCurrentValue = location;

			while (true)
			{
				double currentValue = newCurrentValue;  //The potential value if no other thread changed location
				double newValue = currentValue + value; //The potential result after the addition if location is unchanged

				newCurrentValue = Interlocked.CompareExchange(ref location, newValue, currentValue); //Only change location is it is unchanged
				if (newCurrentValue == currentValue) return newValue;                                //If exchange was successful, addition finished
			}
		}
	}
}