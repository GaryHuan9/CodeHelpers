#if CODEHELPERS_UNITY

using System;
using System.Collections.Concurrent;

namespace CodeHelpers.Unity
{
	public static class ThreadHelperUnity
	{
		static ThreadHelperUnity()
		{
			CodeHelperMonoBehavior.UnityPreUpdateMethods += () =>
															{
																while (!mainThreadActions.IsEmpty)
																{
																	if (mainThreadActions.TryDequeue(out Action action)) action.Invoke();
																}
															};
		}

		static readonly ConcurrentQueue<Action> mainThreadActions = new ConcurrentQueue<Action>();

		/// <summary>
		/// Invoked action in main thread before every update loop
		/// </summary>
		public static void InvokeInMainThread(Action action) => mainThreadActions.Enqueue(action);

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

#endif