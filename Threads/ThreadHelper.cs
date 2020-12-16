using System;
using System.Threading;

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
				if (_mainThread == null) _mainThread = value;
				else throw ExceptionHelper.Invalid(nameof(MainThread), MainThread, InvalidType.semiReadonlyAssignment);
			}
		}

		public static bool IsOnMainThread => MainThread == null || MainThread == Thread.CurrentThread;

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
#if CODEHELPERS_UNITY
				Unity.Debugs.DebugHelperUnity.LogError($"{exception.Message}\n{exception.StackTrace}");
#else
				Console.WriteLine($"Exception thrown in thread! {exception.Message}\n{exception.StackTrace}");
#endif
			}
		}
	}
}