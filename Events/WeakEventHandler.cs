using System;

namespace CodeHelpers.Events
{
	public class WeakEventHandler<TListener> where TListener : class
	{
		/// <summary>
		/// <paramref name="invocationAction"/> should invoke the method on <paramref name="listener"/> that you want to get invoked when the event is raised.
		/// NOTE: Remember to subscribe <see cref="OnEvent"/> to the event after you created this handler.
		/// </summary>
		public WeakEventHandler(TListener listener, Action<TListener> invocationAction)
		{
			listenerReference = new WeakReference<TListener>(listener);
			this.invocationAction = invocationAction;
		}

		readonly WeakReference<TListener> listenerReference;
		readonly Action<TListener> invocationAction;

		Action unsubscribeAction;
		bool unsubscribed;
		
		/// <summary>
		/// You should never invoke this method yourself.
		/// Instead, register/subscribe this method to the event.
		/// </summary>
		public void OnEvent()
		{
			if (unsubscribeAction == null) throw new Exception($"You must set an {nameof(unsubscribeAction)} when initializing this handler.");
			if (unsubscribed) throw new Exception($"The handler should already be unsubscribed but the event is still reaching it! You did not properly define the {nameof(unsubscribeAction)}");

			if (listenerReference.TryGetTarget(out TListener listener))
			{
				invocationAction(listener);
			}
			else
			{
				unsubscribeAction();
				unsubscribed = true;
			}
		}

		/// <summary>
		/// Register an action that will be invoked sometime after the listener got garbage collected.
		/// This action must unsubscribe this handler's <see cref="OnEvent"/> method from the event so it is never invoked again.
		/// </summary>
		public void SetUnsubscribeAction(Action action)
		{
			unsubscribeAction = action;
		}
	}
}