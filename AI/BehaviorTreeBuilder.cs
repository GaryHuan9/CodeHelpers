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

		public int Count { get; private set; }

		public void Add<TNodeType>(TNodeType nodeType, Direction addDirection) where TNodeType : INodeType<T>
		{
			Node node;

			switch (nodeType)
			{
				case Leaf<T> leaf:
					node = new LeafNode(leaf.action);
					break;

				case Sequencer<T> sequencer:
					node = new SequencerNode();
					break;

				case Selector<T> selector:
					node = new SelectorNode();
					break;

				case Inverter<T> inverter:
					node = new InverterNode();
					break;

				case Repeater<T> repeater:
					node = new RepeaterNode();
					break;

				default: throw ExceptionHelper.Invalid(nameof(nodeType), nodeType, InvalidType.unexpected);
			}

			Add(node, addDirection);
		}

		void Add(Node node, Direction addDirection)
		{
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

			Count++;
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

		public BehaviorTree<T> ConstructNew() => new BehaviorTree<T>(this);

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

		public readonly struct CursorPosition : IEquatable<CursorPosition>
		{
			public CursorPosition(uint level, uint depth)
			{
				this.level = level;
				this.depth = depth;
			}

			public readonly uint level;
			public readonly uint depth;

			public bool Equals(CursorPosition other) => other.level == level && other.depth == depth;
			public override bool Equals(object obj) => obj is CursorPosition other && Equals(other);

			public override int GetHashCode() => base.GetHashCode();
			public override string ToString() => $"Position at level {level} and depth {depth}";
		}
	}

	public delegate Result BehaviorAction<in T>(T context);
}