using System;
using System.Collections.Generic;
using CodeHelpers.Collections;

namespace CodeHelpers.Events
{
	public class WeakEvent<T> where T : class, IWeakEventListener
	{
		public WeakEvent(Action<T> invocationAction) => InvocationAction = invocationAction;
		public WeakEvent(Action<T> invocationAction, int capacity) : this(invocationAction) => delegates.Capacity = capacity;

		public Action<T> InvocationAction { get; set; }

		readonly List<WeakReference<T>> delegates = new List<WeakReference<T>>();

		public void Invoke()
		{
			Action<T> action = InvocationAction;
			if (action == null) throw new Exception($"Cannot {nameof(Invoke)} before assigning an {nameof(InvocationAction)}!");

			for (int i = 0; i < delegates.Count; i++)
			{
				WeakReference<T> reference = delegates[i];
				T target = CheckReference(reference, ref i);

				if (target == null) continue;
				action.Invoke(target);
			}
		}

		public void AddListener(T listener) => delegates.Add(new WeakReference<T>(listener));

		public void RemoveListener(T listener)
		{
			int index = -1;

			for (int i = 0; i < delegates.Count; i++)
			{
				WeakReference<T> reference = delegates[i];
				T target = CheckReference(reference, ref i);

				if (target != listener) continue;

				index = i;
				break;
			}

			if (index < 0) return;
			delegates.RemoveAtIgnoreOrder(index);
		}

		T CheckReference(WeakReference<T> reference, ref int index)
		{
			if (reference.TryGetTarget(out T target)) return target;

			//Reference unlinked
			delegates.RemoveAtIgnoreOrder(index--);
			return null;
		}
	}

	public interface IWeakEventListener { }
}