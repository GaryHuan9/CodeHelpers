using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CodeHelpers.Collections;
using CodeHelpers.Diagnostics;

namespace CodeHelpers.Events
{
	public abstract class EventListBase<T> where T : Delegate
	{
		protected Invoker invoker;

		List<T> primaryActions;
		List<T> regularActions;
		List<T> delayedActions;

		public int Count => (primaryActions?.Count ?? 0) + (regularActions?.Count ?? 0) + (delayedActions?.Count ?? 0);

		protected void Clear()
		{
			primaryActions?.Clear();
			regularActions?.Clear();
			delayedActions?.Clear();
		}

		public void Add(T action, ActionPriority priority = ActionPriority.regular)
		{
			if (action != null) GetDelegatesList(priority, true).Add(action);
			else throw ExceptionHelper.Invalid(nameof(action), null, InvalidType.isNull);
		}

		public bool Remove(T action, ActionPriority priority = ActionPriority.regular)
		{
			if (action == null) throw ExceptionHelper.Invalid(nameof(action), null, InvalidType.isNull);
			return GetDelegatesList(priority, false)?.RemoveIgnoreOrder(action) == true;
		}

		protected List<T> GetDelegatesList(ActionPriority priority, bool generate)
		{
			switch (priority)
			{
				case ActionPriority.primary: return GetList(ref primaryActions);
				case ActionPriority.regular: return GetList(ref regularActions);
				case ActionPriority.delayed: return GetList(ref delayedActions);
			}

			throw ExceptionHelper.Invalid(nameof(priority), priority, InvalidType.unexpected);
			List<T> GetList(ref List<T> list) => generate && list == null ? list = new List<T>() : list;
		}

		public override string ToString() => $"{nameof(primaryActions)}: {DebugHelper.ToString(primaryActions)}, " +
											 $"{nameof(regularActions)}: {DebugHelper.ToString(regularActions)}, " +
											 $"{nameof(delayedActions)}: {DebugHelper.ToString(delayedActions)}";

		public abstract class Invoker
		{
			protected Invoker(EventListBase<T> eventList)
			{
				if (eventList.invoker == null) this.eventList = eventList;
				else throw new Exception($"Cannot create two invoker for one {nameof(EventListBase<T>)}");
			}

			readonly EventListBase<T> eventList;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			protected abstract void InvokeAction(T action);

			protected void Invoke()
			{
				InvokeList(eventList.primaryActions);
				InvokeList(eventList.regularActions);
				InvokeList(eventList.delayedActions);

				void InvokeList(List<T> list)
				{
					if (list == null) return;
					int count = list.Count;

					for (int i = 0; i < count; i++) InvokeAction(list[i]);
				}
			}

			public void Clear() => eventList.Clear();
		}
	}

	public class EventList : EventListBase<Action>
	{
		public EventList(out Invoker invoker) => this.invoker = invoker = new Invoker(this);

		new public class Invoker : EventListBase<Action>.Invoker
		{
			public Invoker(EventListBase<Action> eventList) : base(eventList) { }

			new public void Invoke() => base.Invoke();
			protected override void InvokeAction(Action action) => action();
		}
	}

	public class EventList<T0> : EventListBase<Action<T0>>
	{
		public EventList(out Invoker invoker) => this.invoker = invoker = new Invoker(this);

		new public class Invoker : EventListBase<Action<T0>>.Invoker
		{
			public Invoker(EventListBase<Action<T0>> eventList) : base(eventList) { }

			T0 item0;

			protected override void InvokeAction(Action<T0> action) => action(item0);

			public void Invoke(T0 parameter0)
			{
				item0 = parameter0;
				base.Invoke();
			}
		}
	}

	public class EventList<T0, T1> : EventListBase<Action<T0, T1>>
	{
		public EventList(out Invoker invoker) => this.invoker = invoker = new Invoker(this);

		new public class Invoker : EventListBase<Action<T0, T1>>.Invoker
		{
			public Invoker(EventListBase<Action<T0, T1>> eventList) : base(eventList) { }

			T0 item1;
			T1 item2;

			protected override void InvokeAction(Action<T0, T1> action) => action(item1, item2);

			public void Invoke(T0 parameter1, T1 parameter2)
			{
				item1 = parameter1;
				item2 = parameter2;

				base.Invoke();
			}
		}
	}

	public class EventList<T0, T1, T2> : EventListBase<Action<T0, T1, T2>>
	{
		public EventList(out Invoker invoker) => this.invoker = invoker = new Invoker(this);

		new public class Invoker : EventListBase<Action<T0, T1, T2>>.Invoker
		{
			public Invoker(EventListBase<Action<T0, T1, T2>> eventList) : base(eventList) { }

			T0 item0;
			T1 item1;
			T2 item2;

			protected override void InvokeAction(Action<T0, T1, T2> action) => action(item0, item1, item2);

			public void Invoke(T0 parameter0, T1 parameter1, T2 parameter2)
			{
				item0 = parameter0;
				item1 = parameter1;
				item2 = parameter2;

				base.Invoke();
			}
		}
	}

	public class EventList<T0, T1, T2, T3> : EventListBase<Action<T0, T1, T2, T3>>
	{
		public EventList(out Invoker invoker) => this.invoker = invoker = new Invoker(this);

		new public class Invoker : EventListBase<Action<T0, T1, T2, T3>>.Invoker
		{
			public Invoker(EventListBase<Action<T0, T1, T2, T3>> eventList) : base(eventList) { }

			T0 item1;
			T1 item2;
			T2 item3;
			T3 item4;

			protected override void InvokeAction(Action<T0, T1, T2, T3> action) => action(item1, item2, item3, item4);

			public void Invoke(T0 parameter0, T1 parameter1, T2 parameter2, T3 parameter3)
			{
				item1 = parameter0;
				item2 = parameter1;
				item3 = parameter2;
				item4 = parameter3;

				base.Invoke();
			}
		}
	}

	public enum ActionPriority : byte
	{
		primary,
		regular,
		delayed
	}
}