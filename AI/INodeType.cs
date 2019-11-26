namespace CodeHelpers.AI
{
	public interface INodeType<T> { }

	public readonly struct Leaf<T> : INodeType<T>
	{
		public Leaf(BehaviorAction<T> action) => this.action = action;

		public readonly BehaviorAction<T> action;
	}

	/// <summary>
	/// Similar to AND; execute child nodes in order until the executed child returned failure
	/// </summary>
	public readonly struct Sequencer<T> : INodeType<T> { }

	/// <summary>
	/// TODO: ???????
	/// Similar to OR; execute child nodes in order until the executed child returned success
	/// ???????
	/// </summary>
	public readonly struct Selector<T> : INodeType<T> { }

	/// <summary>
	/// Similar to NOT; execute the single child node and return its result in reverse
	/// </summary>
	public readonly struct Inverter<T> : INodeType<T> { }

	/// <summary>
	/// Execute all children in order repeatedly until the executed child returned failure.
	/// NOTE: This may easily result in infinite loops if the tree is not defined carefully
	/// </summary>
	public readonly struct Repeater<T> : INodeType<T>
	{
		public Repeater(int amount) => this.amount = amount;

		public readonly int amount;
	}

	/// <summary>
	/// Only execute child if a number randomly generated between 0 to 1 is lower than chance.
	/// When the child is not executed, a result of success is returned.
	/// </summary>
	public readonly struct Blocker<T> : INodeType<T>
	{
		public Blocker(float chance) => this.chance = chance;

		public readonly float chance;
	}
}