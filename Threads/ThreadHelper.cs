using System;
using System.Threading;
using CodeHelpers.Diagnostics;

namespace CodeHelpers.Threads
{
	public static class ThreadHelper
	{
		static Thread _mainThread;

		public static Thread MainThread
		{
			get => _mainThread;
			set
			{
				if (_mainThread == null || _mainThread == value) _mainThread = value;
				else throw ExceptionHelper.Invalid(nameof(MainThread), MainThread, InvalidType.readonlyAssignment);
			}
		}

		public static bool IsOnMainThread => MainThread == null || MainThread == Thread.CurrentThread;

		/// <summary>This returns a new thread that will make sure to print out exceptions.</summary>
		public static Thread NewThread(Action action, bool throwThreadAbortException = false, Action abortAction = null)
		{
			return new Thread(() =>
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
			});

			static void LogException(Exception exception) => DebugHelper.LogError($"Exception thrown in thread! {exception.Message}\n{exception.StackTrace}");
		}
	}
}