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
	}
}