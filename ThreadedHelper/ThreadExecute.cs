using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Concurrent;
using System;

namespace CodeHelpers.ThreadHelpers
{
	public class ThreadExecute : IDisposable
	{
		/// <summary>Create a new instance</summary>
		/// <param name="checkDelay">If this value is below 0, then we check it right after the executions. Otherwise we delay it by checkDelay seconds.</param>
		public ThreadExecute(float checkDelay = -1f)
		{
			ExecutionThread = ThreadHelper.NewThread(ExecuteQueueingExecutions);
			delay = checkDelay;

			CodeHelperMonoBehaviour.OnApplicationQuitMethods += ExecutionThread.Abort;
		}

		public Thread ExecutionThread { get; private set; }

		volatile int _executingId;

		public int ExecutingId
		{
			get => _executingId;
			private set => _executingId = value;
		}

		readonly ConcurrentQueue<Execution> executionQueue = new ConcurrentQueue<Execution>();
		readonly float delay;

		long killingId = long.MaxValue;          //If this long is larger than int.MaxValue then we count it as null
		const long DefaultValue = long.MaxValue; //This is the value when we are not killing any execution

		void ExecuteQueueingExecutions()
		{
			while (true)
			{
				while (!executionQueue.IsEmpty)
				{
					if (executionQueue.TryDequeue(out Execution execution) && (!execution.useId || killingId != execution.id))
					{
						while (killingId != DefaultValue) { } //Wait until they equal

						ExecutingId = execution.id;

						execution.action();
						ExecutingId = 0;
					}
				}

				if (delay > 0f) Thread.Sleep((int)Math.Round(delay * 1000f));
			}
		}

		public void AddExecution(Action action)
		{
			if (!ThreadHelper.IsInMainThread) throw new Exception("You only call this in the main thread.");

			executionQueue.Enqueue(new Execution(action));
			if (ExecutionThread.ThreadState == ThreadState.Unstarted) ExecutionThread.Start();
		}

		public void AddExecution(Action action, int id)
		{
			if (!ThreadHelper.IsInMainThread) throw new Exception("You only call this in the main thread.");

			executionQueue.Enqueue(new Execution(action, id));
			if (ExecutionThread.ThreadState == ThreadState.Unstarted) ExecutionThread.Start();
		}

		/// <summary>This method kills the current execution if it has the same id, and deletes all executions with this id in the queue</summary>
		public bool KillAllExecutions(int id)
		{
			if (!ThreadHelper.IsInMainThread) throw new Exception("You only call this in the main thread because it contains enumeration of the queue.");

			bool successful = false;
			Interlocked.Exchange(ref killingId, id);

			if (ExecutingId == id)
			{
				ExecutionThread.Abort();
				ExecutionThread = ThreadHelper.NewThread(ExecuteQueueingExecutions);

				successful = true;
			}

			executionQueue.ForEach(
				thisExecution =>
				{
					if (thisExecution.id != id) executionQueue.Enqueue(thisExecution);
					else successful = true;
				}
			);
			Interlocked.Exchange(ref killingId, DefaultValue);

			return successful;
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		readonly struct Execution
		{
			public Execution(Action action)
			{
				this.action = action;
				id = 0;
				useId = false;
			}

			public Execution(Action action, int id)
			{
				this.action = action;
				this.id = id;
				useId = true;
			}

			public readonly Action action;

			public readonly bool useId;
			public readonly int id;
		}
	}
}