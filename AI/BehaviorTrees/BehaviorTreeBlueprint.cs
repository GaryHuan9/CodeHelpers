using System;
using System.Collections;
using System.Collections.Generic;
using CodeHelpers.Collections;

namespace CodeHelpers.AI.BehaviorTrees
{
	public partial class BehaviorTreeBlueprint<T> : ISealable
	{
		public BehaviorTreeBlueprint()
		{
			nodes.Add(new Root(this));
		}

		readonly List<Node> nodes = new List<Node>();
		public int NodeCount => nodes.Count;

		public bool IsSealed { get; private set; }

		internal StatusToken OriginToken => new StatusToken(0);
		internal Root OriginNode => (Root)this[0];

		public Location<T> RootLocation => new Location<T>(0);

		Node this[int index] => nodes[index];
		Node this[Location<T> location] => nodes[location.index];

		public SealResult CanSeal(out Location<T> location)
		{
			foreach (Node node in nodes)
			{
				var result = node.CanSeal();
				if (result == SealResult.success) continue;

				location = new Location<T>(node.selfIndex);
				return result;
			}

			location = default;
			return SealResult.success;
		}

		public void Seal()
		{
			this.CheckSealed();

			for (int i = 0; i < NodeCount; i++) nodes[i].Seal();
			nodes.TrimExcess();

			IsSealed = true;
		}

		/// <summary>
		/// Returns the location of the parent of the node at <paramref name="location"/>
		/// </summary>
		public Location<T> GetParent(Location<T> location)
		{
			var parent = this[location].Parent;

			if (parent != null) return new Location<T>(parent.selfIndex);
			throw new Exception("Node at location does not have a parent!");
		}

		/// <summary>
		/// Returns a struct enumerable to enumerate through all of the Location of this node's child
		/// </summary>
		public ChildEnumerable GetChild(Location<T> location) => new ChildEnumerable(this, location);

		public Location<T> Add<TNode>(Location<T> parentLocation, TNode nodeType, out bool success) where TNode : INodeType
		{
			Node parent = this[parentLocation];

			if (parent.ChildCount == parent.MaxChildCount)
			{
				success = false;
				return default;
			}

			Node node = GenerateNewNode(nodeType);
			parent.InsertChild(parent.ChildCount, node.selfIndex);

			success = true;
			return new Location<T>(node.selfIndex);
		}

		public bool Add<TNode>(Location<T> parentLocation, TNode nodeType) where TNode : INodeType
		{
			Add(parentLocation, nodeType, out bool success);
			return success;
		}

		/// <summary>
		/// Constructs a new Node then assign it to our internal list at the correct index
		/// </summary>
		Node GenerateNewNode<TNode>(TNode nodeType) where TNode : INodeType
		{
			Node node = TypeToNewNode(nodeType, nodes.Count);

			nodes.Add(node);
			return node;
		}

		Node TypeToNewNode<TNode>(TNode nodeType, int index) where TNode : INodeType
		{
			switch (nodeType)
			{
				case Leaf<T> leaf:               return new LeafNode(this, index, leaf.action);
				case Sequencer sequencer:        return new SequencerNode(this, index);
				case Selector selector:          return new SelectorNode(this, index);
				case Inverter inverter:          return new InverterNode(this, index);
				case Repeater repeater:          return new RepeaterNode(this, index);
				case Blocker blocker:            return new BlockerNode(this, index, blocker.chance);
				case Conditioner<T> conditioner: return new ConditionerNode(this, index, conditioner.condition);
				case Constant constant: return new ConstantNode(this, index, constant.success);
			}

			throw ExceptionHelper.Invalid(nameof(nodeType), nodeType, InvalidType.unexpected);
		}

		internal abstract class Node : ISealable
		{
			protected Node(BehaviorTreeBlueprint<T> blueprint, int selfIndex)
			{
				this.blueprint = blueprint;
				this.selfIndex = selfIndex;
			}

			int _parentIndex = -1;
			int _indexInParent = -1;

			public int? ParentIndex => _parentIndex < 0 ? (int?)null : _parentIndex;
			public int? IndexInParent => _indexInParent < 0 ? (int?)null : _indexInParent;

			public readonly BehaviorTreeBlueprint<T> blueprint;
			public readonly int selfIndex;

			protected List<int> Children { get; private set; }
			public bool IsSealed { get; private set; }

			public abstract byte MaxChildCount { get; }
			public virtual byte MinChildCount => 1; //The minimum number of child for this node to be successfully sealed

			public byte ChildCount => (byte?)Children?.Count ?? 0;
			public Node Parent => ParentIndex == null ? null : blueprint[ParentIndex.Value];

			/// <summary>
			/// Returns children with that local index
			/// </summary>
			public Node this[int index] => blueprint[Children[index]];

			public SealResult CanSeal()
			{
				if (ParentIndex == null && !(this is Root)) return SealResult.noParent;
				if (ChildCount < MinChildCount) return SealResult.minChildCount;

				return SealResult.success;
			}

			public void Seal()
			{
				this.CheckSealed();

				var sealResult = CanSeal();
				if (sealResult != SealResult.success) throw new Exception(sealResult.ToErrorMessage());

				if (Children?.Count == 0) Children = null;
				else Children?.TrimExcess();

				IsSealed = true;
			}

			public StatusToken Next(StatusToken from, T context)
			{
				this.CheckNotSealed();
				if (from.result == Result.running) throw ExceptionHelper.Invalid(nameof(from), from, "is running, which indicates the tree should stop and cache but not try to get the next token.");

				return GetNext(from, context);
			}

			/// <summary>
			/// Should return the token that will lead us to the next node
			/// NOTE: result passed in as token will not be running.
			/// </summary>
			protected abstract StatusToken GetNext(StatusToken from, T context);

			void SetParent()
			{
				this.CheckSealed();

				_parentIndex = -1;
				_indexInParent = -1;
			}

			protected virtual void SetParent(int parentIndex, int indexInParent)
			{
				this.CheckSealed();
				if (blueprint[parentIndex]?[indexInParent] != this) throw new Exception($"Invalid {nameof(parentIndex)} ({parentIndex}) or {nameof(indexInParent)} ({indexInParent})! The indices does not point to this node.");

				_parentIndex = parentIndex;
				_indexInParent = indexInParent;
			}

			public void InsertChild(int positionIndex, int childIndex)
			{
				this.CheckSealed();
				if (ChildCount >= MaxChildCount) throw new Exception($"Cannot add more children because {nameof(ChildCount)} ({ChildCount}) is already equals {nameof(MaxChildCount)} ({ChildCount})!");

				Children = Children ?? new List<int>(); //Create list if null
				var child = blueprint[childIndex];

				Children.Insert(positionIndex, childIndex);
				child.SetParent(selfIndex, positionIndex);
			}

			public Node RemoveChild(int positionIndex)
			{
				this.CheckSealed();
				if (Children == null || !Children.IsIndexValid(positionIndex)) throw new Exception($"No child at {nameof(positionIndex)} ({positionIndex})");

				var child = this[positionIndex];
				child.SetParent();

				Children.RemoveAt(positionIndex);
				return child;
			}
		}

		/// <summary>
		/// Result should be enter if you want to go down to a child
		///
		/// If ToChild is true, then we are going down the tree, from a parent to its child at local index of index.
		/// If ToParent is true, then we are going up the tree, from a child back to its parent. The children's index in parent would be index.
		/// </summary>
		internal readonly struct StatusToken : IEquatable<StatusToken>
		{
			public StatusToken(byte index, Result result = Result.enter)
			{
				this.index = index;
				this.result = result;
			}

			/// <summary>
			/// Creates a return token from <paramref name="node"/> to its parent.
			/// NOTE: <paramref name="result"/> cannot be enter
			/// </summary>
			public StatusToken(Node node, Result result)
			{
				if (result == Result.enter) throw ExceptionHelper.Invalid(nameof(result), result, "is enter, which cannot be used when creating return tokens!");

				index = (byte)(node.IndexInParent ?? throw new Exception("Cannot create a return token from a node with no parent!"));
				this.result = result;
			}

			public readonly byte index;
			public readonly Result result;

			public bool ToChild => result == Result.enter;
			public bool ToParent => !ToChild;

			public bool Equals(StatusToken other) => index == other.index && result == other.result;
			public override bool Equals(object obj) => obj is StatusToken other && Equals(other);

			public override int GetHashCode()
			{
				unchecked
				{
					return (index.GetHashCode() * 397) ^ (int)result;
				}
			}
		}

		public readonly struct ChildEnumerable : IEnumerable<Location<T>>
		{
			internal ChildEnumerable(BehaviorTreeBlueprint<T> blueprint, Location<T> parentLocation) => enumerator = new Enumerator(blueprint, parentLocation);

			readonly Enumerator enumerator;

			public Enumerator GetEnumerator() => enumerator;

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			IEnumerator<Location<T>> IEnumerable<Location<T>>.GetEnumerator() => GetEnumerator();

			public struct Enumerator : IEnumerator<Location<T>>
			{
				public Enumerator(BehaviorTreeBlueprint<T> blueprint, Location<T> parentLocation)
				{
					this.blueprint = blueprint;
					this.parentLocation = parentLocation;

					index = -1;
				}

				readonly BehaviorTreeBlueprint<T> blueprint;
				readonly Location<T> parentLocation;

				int index;

				object IEnumerator.Current => Current;
				public Location<T> Current => new Location<T>(blueprint[parentLocation][index].selfIndex);

				public bool MoveNext()
				{
					index++;
					return index < blueprint[parentLocation].ChildCount;
				}

				public void Reset() => index = -1;
				public void Dispose() { }
			}
		}
	}

	public readonly struct Location<T> : IEquatable<Location<T>>
	{
		internal Location(int index) => this.index = index;

		internal readonly int index;

		static BehaviorTreeBlueprint<T> GlobalBlueprint => GlobalLocationBlueprint<T>.blueprint ?? throw new Exception("You did not set a global blueprint for the Location struct so you have to specify a blueprint to use!");

		/// <summary>
		/// Returns the parent of this location using the globally set blueprint
		/// </summary>
		public Location<T> GetParent() => GetParent(GlobalBlueprint);

		/// <summary>
		/// Returns the parent of this location
		/// </summary>
		public Location<T> GetParent(BehaviorTreeBlueprint<T> blueprint) => blueprint.GetParent(this);

		/// <summary>
		/// Adds a node as a child to the globally set blueprint
		/// </summary>
		public Location<T> AddChild<TNode>(TNode nodeType) where TNode : INodeType => AddChild(GlobalBlueprint, nodeType);

		/// <summary>
		/// Adds a node as a child to a blueprint
		/// </summary>
		public Location<T> AddChild<TNode>(BehaviorTreeBlueprint<T> blueprint, TNode nodeType) where TNode : INodeType
		{
			var nextLocation = blueprint.Add(this, nodeType, out bool success);
			if (!success) throw new Exception("Addition unsuccessful!");

			return nextLocation;
		}

		/// <summary>
		/// Adds a node as a sibling to the globally set blueprint
		/// </summary>
		public Location<T> AddSibling<TNode>(TNode nodeType) where TNode : INodeType =>
			AddSibling(GlobalBlueprint, nodeType);

		/// <summary>
		/// Adds a node as a sibling to a blueprint
		/// </summary>
		public Location<T> AddSibling<TNode>(BehaviorTreeBlueprint<T> blueprint, TNode nodeType) where TNode : INodeType =>
			GetParent(blueprint).AddChild(blueprint, nodeType);

		public bool Equals(Location<T> other) => index == other.index;
		public override bool Equals(object obj) => obj is Location<T> other && Equals(other);

		public override int GetHashCode() => index;
	}

	/// <summary>
	/// Use a using statement with this struct to set a global blueprint the Location struct is going to use inside that using statement
	/// </summary>
	public readonly struct GlobalLocationBlueprint<T> : IDisposable
	{
		public GlobalLocationBlueprint(BehaviorTreeBlueprint<T> globalBlueprint) => blueprint = globalBlueprint;

		internal static BehaviorTreeBlueprint<T> blueprint;

		public void Dispose() => blueprint = null;
	}
}