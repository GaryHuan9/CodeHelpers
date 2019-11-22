using System;
using UnityEngine;

namespace CodeHelpers.AI
{
	public partial class BehaviorTreeBuilder<T>
	{
		class LeafNode : Node
		{
			public LeafNode(BehaviorAction<T> action) => this.action = action;

			public readonly BehaviorAction<T> action;

			public override int MaxChildCount => 0;
			public override int ChildCount => 0;

			public override Node this[int index]
			{
				get => throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
				set => throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}

			public override void Insert(int index, Node node) => throw new NotSupportedException();
		}

		class SequencerNode : Node
		{

			public override int MaxChildCount => throw new NotImplementedException();

			public override int ChildCount => throw new NotImplementedException();

			public override Node this[int index]
			{
				get => throw new NotImplementedException();
				set => throw new NotImplementedException();
			}

			public override void Insert(int index, Node node)
			{
				throw new NotImplementedException();
			}
		}
		
		class SelectorNode : Node
		{
			public override int MaxChildCount => throw new NotImplementedException();

			public override int ChildCount => throw new NotImplementedException();

			public override Node this[int index]
			{
				get => throw new NotImplementedException();
				set => throw new NotImplementedException();
			}

			public override void Insert(int index, Node node)
			{
				throw new NotImplementedException();
			}
		}
		
		class InverterNode : Node
		{

			public override int MaxChildCount => throw new NotImplementedException();

			public override int ChildCount => throw new NotImplementedException();

			public override Node this[int index]
			{
				get => throw new NotImplementedException();
				set => throw new NotImplementedException();
			}

			public override void Insert(int index, Node node)
			{
				throw new NotImplementedException();
			}
		}
		
		class RepeaterNode : Node
		{

			public override int MaxChildCount => throw new NotImplementedException();

			public override int ChildCount => throw new NotImplementedException();

			public override Node this[int index]
			{
				get => throw new NotImplementedException();
				set => throw new NotImplementedException();
			}

			public override void Insert(int index, Node node)
			{
				throw new NotImplementedException();
			}
		}
	}
}