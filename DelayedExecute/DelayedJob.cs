using System;
using System.Collections;
using UnityEngine;

namespace CodeHelpers.DelayedExecution
{
	public class DelayedJob
	{
		/// <param name="jobs">Jobs; each separated with a yield return null</param>
		/// <param name="maxExecutionMillisecond">The maximum time for each execution.</param>
		public DelayedJob(IEnumerator jobs, float maxExecutionMillisecond = 5f)
		{
			this.jobs = jobs ?? throw new NullReferenceException(nameof(jobs));
			MaxExecutionMillisecond = maxExecutionMillisecond;
		}

		readonly IEnumerator jobs;
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
				if (value <= 0f || Mathf.Approximately(value, 0f)) throw ExceptionHelper.Invalid(nameof(value), value, InvalidType.outOfBounds);
				_maxExecutionMillisecond = value;
			}
		}

		public bool IsJobExecuting => DelayedController.IsJobExecuting(this);

		public static Mark ExitExecutionMark => Mark.exitExecutionMark;

		public void Execute()
		{
			stopwatch.Restart();
			int count = 0;

			while (count++ != -1 && jobs.MoveNext())
			{
				if (jobs.Current == ExitExecutionMark) goto outBreak;
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
			catch (NotSupportedException notSupportedException)
			{
				throw new NotSupportedException("Job is a compiler-generated (yield) enumerator and does not support restart!");
			}

			Finished = false;
		}

		public class Mark
		{
			Mark() { }

			public static readonly Mark exitExecutionMark = new Mark();
		}
	}
}