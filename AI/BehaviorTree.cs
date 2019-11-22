using System;
using System.Collections.Generic;
using System.Text;

namespace CodeHelpers.AI
{
	public class BehaviorTree<T>
	{
		public BehaviorTreeBlueprint<T> Blueprint => blueprint;

		public T Context => context;

		public readonly BehaviorTreeBlueprint<T> blueprint;
		public readonly T context;

		public Result Tick()
		{
			
			throw new NotImplementedException();
		}
	}

	public enum Result : byte
	{
		success,
		failure,
		running
	}
}