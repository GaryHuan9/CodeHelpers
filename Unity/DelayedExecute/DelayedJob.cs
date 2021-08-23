#if CODEHELPERS_UNITY

using System;
using System.Collections.Generic;
using CodeHelpers.Mathematics;

namespace CodeHelpers.Unity.DelayedExecute
{
	public class DelayedJob
	{
		/// <param name="jobs">Jobs; each separated with a yield return 0. You can return the current job tag and retrieve it with <see cref="ExecutingTag"/>. NOTE: Tags cannot be negative.</param>
		/// <param name="maxExecutionMillisecond">The maximum time for each execution in milliseconds.</param>
		public DelayedJob(IEnumerable<int> jobs, float maxExecutionMillisecond = 5f)
		{
			this.jobs = jobs.GetEnumerator();
			MaxExecutionMillisecond = maxExecutionMillisecond;
		}

		readonly IEnumerator<int> jobs;
		float _maxExecutionMillisecond;

		readonly System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
		public bool Finished { get; private set; }

		/// <summary>
		/// The maximum time for each execution.
		/// </summary>
		public float MaxExecutionMillisecond
		{
			get => _maxExecutionMillisecond;
			set
			{
				if (value <= 0f || value.AlmostEquals()) throw ExceptionHelper.Invalid(nameof(value), value, InvalidType.outOfBounds);
				_maxExecutionMillisecond = value;
			}
		}

		public bool IsJobExecuting => DelayedController.IsJobExecuting(this);
		public int ExecutingTag { get; private set; }

		public static int ExitExecutionMark => -123;

		public void Execute()
		{
			stopwatch.Reset();
			stopwatch.Start();

			int count = 0;

			while (count++ != -1 && jobs.MoveNext())
			{
				int currentTag = jobs.Current;

				if (currentTag == ExitExecutionMark) goto outBreak;
				if (currentTag < 0) throw new Exception("Job tags cannot be negative!");

				ExecutingTag = currentTag;

				if (stopwatch.Elapsed.TotalMilliseconds >= MaxExecutionMillisecond) goto outBreak;
			}

			Finished = true;

			outBreak:
			{ }
		}

		public void Restart()
		{
			try
			{
				jobs.Reset();
			}
			catch (NotSupportedException)
			{
				throw new NotSupportedException("Job is a compiler-generated (yield) enumerator and does not support restart!");
			}

			Finished = false;
		}
	}
}

#endif