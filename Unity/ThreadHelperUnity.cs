#if CODEHELPERS_UNITY

using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace CodeHelpers.Unity
{
	public static class ThreadHelperUnity
	{
		static ThreadHelperUnity() => CodeHelperMonoBehavior.UnityPreUpdateMethods += ExecuteQueuedActions;

		static readonly ConcurrentQueue<StrongBox<Action>> mainThreadActions = new ConcurrentQueue<StrongBox<Action>>();

		/// <summary>
		/// Invoked action in main thread before every update loop
		/// </summary>
		public static void InvokeInMainThread(Action action)
		{
			if (action != null) mainThreadActions.Enqueue(new StrongBox<Action>(action));
			else throw ExceptionHelper.Invalid(nameof(action), InvalidType.isNull);
		}

		/// <summary>
		/// This returns a method that can only be executing by one thread.
		/// If it is already being executed by thread A, then if thread B tries to execute it the current
		/// executing invoked by thread A will keep going but the one invoked by B will be returned.
		/// </summary>
		public static Action GetOneCallMethod(Action action)
		{
			if (action != null) return new OneCallMethod(action).Execute;
			throw ExceptionHelper.Invalid(nameof(action), InvalidType.isNull);
		}

		static void ExecuteQueuedActions()
		{
			while (!mainThreadActions.IsEmpty)
			{
				if (!mainThreadActions.TryDequeue(out StrongBox<Action> box)) continue;

				//Because the implementation of c#'s concurrent queue can reference its contents even after
				//they are dequeued, we have to store the actions inside strong boxes to avoid memory leak

				box.Value();
				box.Value = null;
			}
		}

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