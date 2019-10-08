using System;
using System.Collections.Generic;

namespace CodeHelpers.DelayedExecution
{
	public static class DelayedController
	{
		static DelayedController() => CodeHelperMonoBehaviour.UnityUpdateMethods += ConstantUpdate;

		static readonly List<JobInfo>               allJobs    = new List<JobInfo>();
		static readonly Dictionary<DelayedJob, int> jobToIndex = new Dictionary<DelayedJob, int>();

		/// <summary>
		/// Starts a job.
		/// </summary>
		/// <param name="onFinished">An event that will be invoked when this job is done</param>
		/// <param name="removeAfterFinished">If set to <c>true</c> remove after the job is finished.</param>
		public static void StartJob(DelayedJob job, Action<DelayedJob> onFinished = null, bool removeAfterFinished = true)
		{
			if (IsJobExecuting(job)) throw new Exception("Job already executing!");

			jobToIndex.Add(job, allJobs.Count);
			allJobs.Add(new JobInfo(job, removeAfterFinished, onFinished));
		}

		/// <summary>
		/// Stops and removes a job.
		/// </summary>
		public static void RemoveJob(DelayedJob job)
		{
			if (!IsJobExecuting(job)) throw new Exception("Job is not executing!");

			int index = jobToIndex[job];

			jobToIndex.Remove(job);
			allJobs.RemoveAt(index);
		}

		public static bool IsJobExecuting(DelayedJob job) => jobToIndex.ContainsKey(job);

		static void ConstantUpdate()
		{
			for (int i = 0; i < allJobs.Count; i++)
			{
				JobInfo info = allJobs[i];
				info.job.Execute();

				if (!info.job.Finished) continue;

				info.onFinished?.Invoke(info.job);

				if (!info.removeAfterFinished) continue;

				RemoveJob(info.job);
				i--;
			}
		}

		readonly struct JobInfo
		{
			public JobInfo(DelayedJob job, bool removeAfterFinished, Action<DelayedJob> onFinished)
			{
				this.job                 = job;
				this.removeAfterFinished = removeAfterFinished;
				this.onFinished          = onFinished;
			}

			public readonly DelayedJob         job;
			public readonly bool               removeAfterFinished;
			public readonly Action<DelayedJob> onFinished;
		}
	}
}