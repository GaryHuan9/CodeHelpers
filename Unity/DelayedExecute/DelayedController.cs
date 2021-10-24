﻿#if CODEHELPERS_UNITY

using System;
using System.Collections.Generic;
using CodeHelpers.Pooling;

namespace CodeHelpers.Unity.DelayedExecute
{
	public static class DelayedController
	{
		static DelayedController() => CodeHelperMonoBehavior.UnityUpdateMethods += ConstantUpdate;
		static readonly Dictionary<DelayedJob, JobInfo> allJobs = new Dictionary<DelayedJob, JobInfo>();

		/// <summary>
		/// Starts a job.
		/// </summary>
		/// <param name="onFinished">An event that will be invoked when this job is done</param>
		/// <param name="removeAfterFinished">If set to <c>true</c> remove after the job is finished.</param>
		public static void Start(DelayedJob job, Action<DelayedJob> onFinished = null, bool removeAfterFinished = true)
		{
			if (IsJobExecuting(job)) throw new Exception("Job already executing!");
			allJobs.Add(job, new JobInfo(removeAfterFinished, onFinished));
		}

		/// <summary>
		/// Stops and removes a job.
		/// </summary>
		public static void Remove(DelayedJob job)
		{
			if (IsJobExecuting(job)) allJobs.Remove(job);
			else throw new Exception("Job is not executing!");
		}

		public static bool IsJobExecuting(DelayedJob job) => allJobs.ContainsKey(job);

		static void ConstantUpdate()
		{
			var finished = CollectionPooler<DelayedJob>.list.GetObject();

			foreach (var pair in allJobs)
			{
				JobInfo info = pair.Value;
				DelayedJob job = pair.Key;

				job.Execute();
				if (!job.Finished) continue;

				info.onFinished?.Invoke(job);
				if (!info.removeAfterFinished) continue;

				finished.Add(job);
			}

			foreach (DelayedJob job in finished) Remove(job);
			CollectionPooler<DelayedJob>.list.ReleaseObject(finished);
		}

		readonly struct JobInfo
		{
			public JobInfo(bool removeAfterFinished, Action<DelayedJob> onFinished)
			{
				this.removeAfterFinished = removeAfterFinished;
				this.onFinished = onFinished;
			}

			public readonly bool removeAfterFinished;
			public readonly Action<DelayedJob> onFinished;
		}
	}
}

#endif