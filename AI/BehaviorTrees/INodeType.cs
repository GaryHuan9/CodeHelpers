using CodeHelpers.Unity.BehaviorTreeUIEditor;

namespace CodeHelpers.AI.BehaviorTrees
{
	public interface INodeType { }

	[BehaviorTreeNode("Internal_Leaf", "CodeHelpers.Unity.BehaviorTreeUIEditor.LeafNode")]
	public readonly struct Leaf<T> : INodeType
	{
		public Leaf(BehaviorAction<T> action) => this.action = action;

		public readonly BehaviorAction<T> action;
	}

	/// <summary>
	/// Similar to AND; execute child nodes in order until the executed child returned failure
	/// </summary>
	[BehaviorTreeNode("Internal_Sequencer", "CodeHelpers.Unity.BehaviorTreeUIEditor.SequencerNode")]
	public readonly struct Sequencer : INodeType { }

	/// <summary>
	/// Similar to OR; execute child nodes in order until the executed child returned success
	/// </summary>
	[BehaviorTreeNode("Internal_Selector", "CodeHelpers.Unity.BehaviorTreeUIEditor.SelectorNode")]
	public readonly struct Selector : INodeType { }

	/// <summary>
	/// Similar to NOT; execute the single child node and return its result in reverse
	/// </summary>
	[BehaviorTreeNode("Internal_Inverter", "CodeHelpers.Unity.BehaviorTreeUIEditor.InverterNode")]
	public readonly struct Inverter : INodeType { }

	/// <summary>
	/// Execute all children in order repeatedly until the executed child returned failure.
	/// NOTE: This may easily result in infinite loops if the tree is not defined carefully
	/// </summary>
	[BehaviorTreeNode("Internal_Repeater", "CodeHelpers.Unity.BehaviorTreeUIEditor.RepeaterNode")]
	public readonly struct Repeater : INodeType { }

	/// <summary>
	/// Only execute child if a number randomly generated between 0 to 1 is lower than chance.
	/// When the child is not executed, a result of success is returned.
	/// </summary>
	[BehaviorTreeNode("Internal_Blocker", "CodeHelpers.Unity.BehaviorTreeUIEditor.BlockerNode")]
	public readonly struct Blocker : INodeType
	{
		public Blocker(float chance) => this.chance = chance;

		public readonly float chance;
	}

	/// <summary>
	/// Only execute child if the <see cref="condition"/> returned success.
	/// If it returned failure, this conditioner will also return failure.
	/// </summary>
	[BehaviorTreeNode("Internal_Conditioner", "CodeHelpers.Unity.BehaviorTreeUIEditor.ConditionerNode")]
	public readonly struct Conditioner<T> : INodeType
	{
		public Conditioner(BehaviorAction<T> condition) => this.condition = condition;

		public readonly BehaviorAction<T> condition;
	}

	/// <summary>
	/// Always return success or failure no matter what the child returns.
	/// Still will be blocked by a result of <see cref="Result.running"/>
	/// </summary>
	[BehaviorTreeNode("Internal_Constant", "CodeHelpers.Unity.BehaviorTreeUIEditor.ConstantNode")]
	public readonly struct Constant : INodeType
	{
		public Constant(bool success) => this.success = success;

		public readonly bool success;
	}
}