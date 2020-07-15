using System.Collections.Generic;
using System;
using System.Threading;
using System.Collections.Concurrent;
using UnityEngine;

namespace CodeHelpers.ThreadHelpers
{
	public static class ThreadHelper
	{
		static ThreadHelper()
		{
			CodeHelperMonoBehaviour.UnityPreUpdateMethods += () =>
			{
				while (!mainThreadActions.IsEmpty)
				{
					if (mainThreadActions.TryDequeue(out Action action)) action.Invoke();
				}
			};
		}

		static readonly ConcurrentQueue<Action> mainThreadActions = new ConcurrentQueue<Action>();

		static Thread _mainThread;

		internal static Thread MainThread
		{
			get => _mainThread ?? throw ExceptionHelper.Invalid(nameof(MainThread), null, InvalidType.semiReadonlyNoData);
			set
			{
				if (_mainThread == null) _mainThread = value;
				else throw ExceptionHelper.Invalid(nameof(MainThread), MainThread, InvalidType.semiReadonlyAssignment);
			}
		}

		/// <summary>
		/// Invoked action in main thread before every update loop
		/// </summary>
		public static void InvokeInMainThread(Action action) => mainThreadActions.Enqueue(action);

		/// <summary>This returns a new thread that will make sure to print out exceptions.</summary>
		public static Thread NewThread(Action action, bool throwThreadAbortException = false, Action abortAction = null)
		{
			return new Thread
				   (
					   () =>
					   {
						   try
						   {
							   action();
						   }
						   catch (ThreadAbortException exception)
						   {
							   if (throwThreadAbortException) LogException(exception);
							   abortAction?.Invoke();
						   }
						   catch (Exception exception)
						   {
							   LogException(exception);
						   }
					   }
				   );

			void LogException(Exception exception)
			{
				Debug.LogError($"{exception.Message}\n{exception.StackTrace}");
			}
		}

		public static bool IsOnMainThread => MainThread == null || Thread.CurrentThread == MainThread;

		/// <summary>
		/// This returns a method that can only be executing by one thread.
		/// If it is already being executed by thread A, then if thread B tries to execute it the current
		/// executing invoked by thread A will keep going but the one invoked by B will be returned.
		/// </summary>
		public static Action GetOneCallMethod(Action action) => new OneCallMethod(action).Execute;

		class OneCallMethod
		{
			public OneCallMethod(Action action) => this.action = action;

			readonly Action action;
			volatile bool executing;

			readonly object objectLock = new object();

			public void Execute()
			{
				lock (objectLock)
				{
					if (executing) return;
					executing = true;
				}

				action();
				executing = false;
			}
		}
	}
}