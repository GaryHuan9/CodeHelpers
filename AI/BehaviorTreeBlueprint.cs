using System;
using System.Collections.Generic;

namespace CodeHelpers.AI
{
	public class BehaviorTreeBlueprint<T>
	{
		readonly List<Node> nodes = new List<Node>();
		int firstEmptyIndex = 0; //The first index that is null in the nodes List

		public bool IsSealed { get; private set; }

		internal Node this[int index] => nodes[index];

		/// <summary>
		/// Returns the index of the next node to execute with the index of the node we just executed and its result
		/// </summary>
		public int GetDestination(int executed, Result result)
		{
			throw new NotImplementedException();
		}

		public void Seal()
		{
			if (IsSealed) throw new Exception("Behavior tree already sealed!");
			IsSealed = true;
		}

		internal class Node
		{

		}
	}
}