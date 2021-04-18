using System;
using System.Diagnostics;
using CodeHelpers.ObjectPooling;

namespace CodeHelpers.Diagnostics
{
	public class PerformanceTest
	{
		Stopwatch watch;
		State state;
		TimeSpan span;

		public TimeSpan ElapsedSpan => span;

		public double ElapsedMilliseconds => span.TotalMilliseconds;
		public double ElapsedMinutes => span.TotalMinutes;

		public Interval Start()
		{
			if (state != State.waiting) throw new Exception($"{nameof(PerformanceTest)} already started!");

			Interval interval = new Interval(this);
			watch = CommonPooler.stopwatch.GetObject();

			state = State.testing;
			watch.Start();

			return interval;
		}

		void Stop()
		{
			watch.Stop();

			if (state == State.testing) state = State.tested;
			else throw new Exception($"{nameof(PerformanceTest)} is not running!");

			span = watch.Elapsed;
			CommonPooler.stopwatch.ReleaseObject(watch);
		}

		public override string ToString() => state switch
											 {
												 State.waiting => "Unstarted test waiting for measurement",
												 State.testing => "Running test collecting time measurements",
												 State.tested => $"Completed test measuring {ElapsedMilliseconds}ms",
												 _ => throw ExceptionHelper.Invalid(nameof(state), state, InvalidType.unexpected)
											 };

		public readonly struct Interval : IDisposable
		{
			public Interval(PerformanceTest test) => this.test = test;

			readonly PerformanceTest test;

			public void Dispose() => test.Stop();
		}

		enum State : byte
		{
			waiting,
			testing,
			tested
		}
	}
}