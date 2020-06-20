using System;

namespace CodeHelpers.AI.BehaviorTrees
{
	public partial class BehaviorTreeBlueprint<T>
	{
		internal class Root : Node
		{
			public Root(BehaviorTreeBlueprint<T> blueprint) : base(blueprint, 0) { }

			public override byte MaxChildCount => 1;

			protected override StatusToken GetNext(StatusToken from, T context)
			{
				if (from.ToParent) throw new Exception("Already finished traversing the tree! Should exit the tree before invoking Next on Root a second time!");
				return new StatusToken(0);
			}

			protected override void SetParent(int parentIndex, int indexInParent) => throw new Exception("Cannot set the parent of a Root node.");
		}

		class LeafNode : Node
		{
			public LeafNode(BehaviorTreeBlueprint<T> blueprint, int selfIndex, BehaviorAction<T> action) : base(blueprint, selfIndex) => this.action = action;

			readonly BehaviorAction<T> action;
			public override byte MaxChildCount => 0;
			public override byte MinChildCount => 0;

			protected override StatusToken GetNext(StatusToken from, T context)
			{
				if (from.ToParent) throw ExceptionHelper.NotPossible; //Leaf nodes have no child

				var result = action(context); //Execute behavior/action
				return new StatusToken(this, result);
			}
		}

		class SequencerNode : Node
		{
			public SequencerNode(BehaviorTreeBlueprint<T> blueprint, int selfIndex) : base(blueprint, selfIndex) { }

			public override byte MaxChildCount => byte.MaxValue;

			protected override StatusToken GetNext(StatusToken from, T context)
			{
				if (from.ToChild) return new StatusToken(0);                                     //If we just entered the sequence from a parent, start the sequence at 0
				if (from.result == Result.failure) return new StatusToken(this, Result.failure); //Returns failure when any of the nodes in this sequence returns failure

				int next = from.index + 1;
				if (next >= Children.Count) return new StatusToken(this, Result.success); //Finished running all of the nodes in this sequence
				return new StatusToken((byte)next);                                       //Go to next node in the sequence
			}
		}

		class SelectorNode : Node
		{
			public SelectorNode(BehaviorTreeBlueprint<T> blueprint, int selfIndex) : base(blueprint, selfIndex) { }

			public override byte MaxChildCount => byte.MaxValue;

			protected override StatusToken GetNext(StatusToken from, T context)
			{
				if (from.ToChild) return new StatusToken(0);                                     //If we just entered the node from a parent, start at 0
				if (from.result == Result.success) return new StatusToken(this, Result.success); //Returns success when any of the child node returns success

				int next = from.index + 1;
				if (next >= Children.Count) return new StatusToken(this, Result.failure); //Finished running all of the nodes
				return new StatusToken((byte)next);                                       //Go to next node
			}
		}

		class InverterNode : Node
		{
			public InverterNode(BehaviorTreeBlueprint<T> blueprint, int selfIndex) : base(blueprint, selfIndex) { }

			public override byte MaxChildCount => 1;

			protected override StatusToken GetNext(StatusToken from, T context)
			{
				if (from.ToChild) return new StatusToken(0); //Continue to child
				return new StatusToken(this, from.result.Opposite());
			}
		}

		class RepeaterNode : SequencerNode
		{
			public RepeaterNode(BehaviorTreeBlueprint<T> blueprint, int selfIndex) : base(blueprint, selfIndex) { }

			protected override StatusToken GetNext(StatusToken from, T context)
			{
				var token = base.GetNext(from, context);
				if (token.result != Result.success) return token; //If not going to continue the loop

				//Restart sequence from the beginning
				return base.GetNext(new StatusToken((byte)IndexInParent.Value), context);
			}
		}

		class BlockerNode : Node
		{
			public BlockerNode(BehaviorTreeBlueprint<T> blueprint, int selfIndex, float chance) : base(blueprint, selfIndex) => this.chance = chance;

			readonly float chance;
			public override byte MaxChildCount => 1;

			protected override StatusToken GetNext(StatusToken from, T context)
			{
				if (from.ToParent) return new StatusToken(this, from.result); //Exited from child

				if (RandomHelper.Value <= chance) return new StatusToken(0); //Execute child when RNG number is lower than chance
				return new StatusToken(this, Result.success);                //Return success when execution was bypassed by RNG
			}
		}

		class ConditionerNode : Node
		{
			public ConditionerNode(BehaviorTreeBlueprint<T> blueprint, int selfIndex, BehaviorAction<T> condition) : base(blueprint, selfIndex) => this.condition = condition;

			readonly BehaviorAction<T> condition;
			public override byte MaxChildCount => 1;

			protected override StatusToken GetNext(StatusToken from, T context)
			{
				if (from.ToParent) return new StatusToken(this, from.result); //Exited from child

				if (condition(context) == Result.success) return new StatusToken(0); //Execute child when condition returned success
				return new StatusToken(this, Result.failure);                        //Return failure when condition failed
			}
		}

		class ConstantNode : Node
		{
			public ConstantNode(BehaviorTreeBlueprint<T> blueprint, int selfIndex, bool success) : base(blueprint, selfIndex) => this.success = success;

			readonly bool success;
			public override byte MaxChildCount => 1;

			protected override StatusToken GetNext(StatusToken from, T context)
			{
				if (from.ToChild) return new StatusToken(0); //Continue to child
				return new StatusToken(this, success ? Result.success : Result.failure);
			}
		}
	}
}