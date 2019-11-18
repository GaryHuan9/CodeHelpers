using System;

namespace CodeHelpers.AI
{
	public class BehaviorTree<T>
	{
		readonly Node nodes;

		public Result Tick()
		{
			throw new NotImplementedException();
		}

		class Node { }
	}

	public enum Result : byte
	{
		success,
		failure,
		running
	}
}