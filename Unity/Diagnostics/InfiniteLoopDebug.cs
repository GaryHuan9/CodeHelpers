#if CODE_HELPERS_UNITY

using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CodeHelpers.Unity.Diagnostics
{
	public static class InfiniteLoopDebug
	{
		static InfiniteLoopDebug()
		{
			CodeHelperMonoBehavior.UnityPreUpdateMethods += PreUpdate;
			frameWatch.Restart();
		}

		static readonly Stopwatch frameWatch = new Stopwatch(); //A stopwatch resets at the start of every frame

		/// <summary>
		/// The time in milliseconds allowed for our game to freeze.
		/// </summary>
		public static float FreezeTime { get; set; } = 1000f;

		/// <summary>
		/// During debugging for infinite loops, this method should be invoked for loops that you may consider as
		/// infinite loops. It will allow execution until the game has been freezing for FreezeTime and throw an exception
		/// to break the loop.
		/// </summary>
		[Conditional("UNITY_EDITOR")]
		public static void InterceptFreeze()
		{
			if (frameWatch.Elapsed.TotalMilliseconds < FreezeTime) return;
			throw new InfiniteLoopException(frameWatch.Elapsed);
		}

		static void PreUpdate()
		{
			frameWatch.Restart();
		}

		public class InfiniteLoopException : Exception
		{
			public InfiniteLoopException(TimeSpan freezingTimeSpan) : base($"The app has been freezing in an infinite loop for {freezingTimeSpan}") { }
		}
	}

}

#endif