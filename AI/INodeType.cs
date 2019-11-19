namespace CodeHelpers.AI
{
	public interface INodeType <T>
	{

	}

	public readonly struct Leaf<T> : INodeType<T>
	{
		public Leaf(BehaviorAction<T> action) => this.action = action;

		public readonly BehaviorAction<T> action;
	}

	/// <summary>
	/// Similar to AND; execute child nodes in order until the executed child returned failure
	/// </summary>
	public readonly struct Sequencer<T> : INodeType<T>
	{

	}

	/// <summary>
	/// Similar to OR; execute child nodes in order until the executed child returned success
	/// </summary>
	public readonly struct Selector<T> : INodeType<T>
	{

	}

	/// <summary>
	/// Similar to NOT; execute the single child node and return its result in reverse
	/// </summary>
	public readonly struct Inverter<T> : INodeType<T>
	{

	}

	/// <summary>
	/// Execute all children in order repeatedly until the executed child returned failure
	/// NOTE: This may result in infinite loops easily if the tree is not planed carefully
	/// </summary>
	public readonly struct Repeater<T> : INodeType<T>
	{

	}
}