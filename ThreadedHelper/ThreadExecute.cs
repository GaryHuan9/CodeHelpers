using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Concurrent;
using System;

namespace CodeHelpers.ThreadHelpers
{
	public class ThreadExecute : IDisposable
	{
		public ThreadExecute()
		{
			ExecutionThread = ThreadHelper.NewThread(ExecuteQueueingExecutions);
			CodeHelperMonoBehavior.OnApplicationQuitMethods += Dispose;
		}

		~ThreadExecute() => Dispose();

		public Thread ExecutionThread { get; private set; }

		readonly ConcurrentQueue<Execution> executionQueue = new ConcurrentQueue<Execution>();
		readonly AutoResetEvent resetEvent = new AutoResetEvent(false);

		int _executingId;

		public int ExecutingId
		{
			get => _executingId;
			private set => Interlocked.Exchange(ref _executingId, value);
		}

		bool disposed;

		long killingId = long.MaxValue;          //If this long is larger than int.MaxValue then we count it as null
		const long DefaultValue = long.MaxValue; //This is the value when we are not killing any execution

		void ExecuteQueueingExecutions()
		{
			while (true)
			{
				resetEvent.WaitOne();

				while (!executionQueue.IsEmpty)
				{
					if (!executionQueue.TryDequeue(out Execution execution) || (execution.useId && killingId == execution.id)) continue;

					while (killingId != DefaultValue) { } //Wait until they equal

					ExecutingId = execution.id;

					execution.action();
					ExecutingId = 0;
				}
			}
		}

		public void AddExecution(Action action, int id = 0)
		{
			if (!ThreadHelper.IsOnMainThread) throw new Exception("You only call this in the main thread.");
			executionQueue.Enqueue(new Execution(action, id));

			resetEvent.Set();
			if (ExecutionThread.ThreadState == ThreadState.Unstarted) ExecutionThread.Start();
		}

		/// <summary>This method kills the current execution if it has the same id, and deletes all executions with this id in the queue</summary>
		public bool KillAllExecutions(int id)
		{
			if (!ThreadHelper.IsOnMainThread) throw new Exception("You only call this in the main thread because it contains enumeration of the queue.");

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
			if (disposed) return;

			ExecutionThread.Abort();
			resetEvent.Dispose();

			disposed = true;
		}

		readonly struct Execution
		{
			public Execution(Action action, int id = 0)
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