using System;
using CodeHelpers.VectorHelpers;

namespace CodeHelpers.AI
{
	/// <summary>
	/// NOTE: Behavior trees go top to bottom, left to right
	/// </summary>
	public partial class BehaviorTreeBuilder<T>
	{
		Node topNode;
		Node currentNode;

		public void Add(BehaviorAction<T> action, Direction addDirection)
		{
			Node node = new LeafNode(action);

			if (currentNode != null)
			{
				AddDirectionCheck(currentNode, addDirection);

				var parent = currentNode.Parent; //The parent would not be null because AddDirectionCheck makes sure either it has a value or addDirection is down
				int index;

				if (addDirection == Direction.down)
				{
					parent = currentNode;
					index = parent.ChildCount;
				}
				else index = currentNode.IndexInParent.Value;

				parent.Insert(index, node);
				currentNode.SetParent(parent, index);
			}

			currentNode = node;
			if (topNode == null) topNode = currentNode;
		}

		public void Add(NodeType type, Direction addDirection)
		{
			//TODO
		}

		static void AddDirectionCheck(Node origin, Direction addDirection)
		{
			switch (addDirection)
			{
				case Direction.right:
				case Direction.left:

					origin = origin.Parent;

					if (origin != null) goto case Direction.down;
					throw new Exception($"Cannot add node to the {addDirection} because the current node does not have a parent!");

				case Direction.down:

					if (origin.MaxChildCount < origin.ChildCount) return;
					throw new Exception($"Cannot add more children to the {addDirection}! That level already reached its maximum child count of {origin.MaxChildCount}");

				case Direction.up: throw new Exception("Cannot add upward!");
			}

			throw ExceptionHelper.Invalid(nameof(addDirection), addDirection, "is an invalid 2d direction for trees!");
		}

		public BehaviorTree<T> ConstructNew()
		{
			throw new NotImplementedException();
		}

		abstract class Node
		{
			/// <summary>
			/// The maximum number of children this node can have
			/// </summary>
			public abstract int MaxChildCount { get; }

			/// <summary>
			/// The current child count connected to this node
			/// </summary>
			public abstract int ChildCount { get; }

			/// <summary>
			/// Returns the children at index. Throws exception if index is out of bounds
			/// </summary>
			public abstract Node this[int index] { get; set; }

			public Node Parent { get; private set; }

			int _indexInParent;

			public int? IndexInParent
			{
				get => Parent == null ? (int?)null : _indexInParent;
				private set => _indexInParent = value.Value;
			}

			/// <summary>
			/// Inserts a children at <paramref name="index"/>. Throws exception if index out of bounds.
			/// </summary>
			public abstract void Insert(int index, Node node);

			public void SetParent(Node parent, int? indexInParent = null)
			{
				if (indexInParent == null)
				{
					for (int i = 0; i < parent.ChildCount; i++)
					{
						if (parent[i] == this)
						{
							indexInParent = i;
							goto end;
						}
					}
				}
				else
				{
					if (parent[indexInParent.Value] == this) goto end;
				}

				//Throw invalid index
				throw new Exception("Cannot set parent; either you did not specify an index and the method cannot find one or the specified index is not this node. You need to assign this node to the parent first before setting the parent.");

				end:

				Parent = parent;
				IndexInParent = indexInParent.Value;
			}
		}
	}

	public delegate Result BehaviorAction<in T>(T context);

	public enum NodeType
	{
		/// <summary>
		/// Similar to AND; execute child nodes in order until the executed child returned failure
		/// </summary>
		sequencer,

		/// <summary>
		/// Similar to OR; execute child nodes in order until the executed child returned success
		/// </summary>
		selector,

		/// <summary>
		/// Similar to NOT; execute the single child node and return its result in reverse
		/// </summary>
		inverter,

		/// <summary>
		/// Execute all children in order repeatedly until the executed child returned failure
		/// NOTE: This may result in infinite loops easily if the tree is not planed carefully
		/// </summary>
		repeator
	}
}