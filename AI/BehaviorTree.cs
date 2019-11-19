using System;
using System.Collections.Generic;
using System.Text;

namespace CodeHelpers.AI
{
	public class BehaviorTree<T>
	{
		readonly Node[] nodes;

		public bool IsSealed { get; private set; }

		public void Seal()
		{
			if (IsSealed) throw new Exception("Behavior tree already sealed!");
			IsSealed = true;
		}

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