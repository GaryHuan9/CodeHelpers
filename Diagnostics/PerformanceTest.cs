using System;
using System.Diagnostics;
using CodeHelpers.Pooling;

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

		public ReleaseHandle Start()
		{
			if (state != State.waiting) throw new Exception($"{nameof(PerformanceTest)} already started!");

			ReleaseHandle handle = new ReleaseHandle(this);
			watch = CommonPooler.stopwatch.GetObject();

			state = State.testing;
			watch.Start();

			return handle;
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
			State.waiting => "Awaiting test ready for measurement",
			State.testing => "Running test collecting time measurements",
			State.tested => $"Completed test measuring {ElapsedMilliseconds}ms",
			_ => throw ExceptionHelper.Invalid(nameof(state), state, InvalidType.unexpected)
		};

		public struct ReleaseHandle : IDisposable
		{
			public ReleaseHandle(PerformanceTest test)
			{
				this.test = test;
				stopped = false;
			}

			readonly PerformanceTest test;
			bool stopped;

			public void Dispose()
			{
				if (stopped) return;

				test.Stop();
				stopped = true;
			}
		}

		enum State : byte
		{
			waiting,
			testing,
			tested
		}
	}
}