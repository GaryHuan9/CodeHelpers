namespace CodeHelpers.AI.BehaviorTrees
{
	public class BehaviorTree<T>
	{
		public BehaviorTree(BehaviorTreeBlueprint<T> blueprint, T context)
		{
			this.blueprint = blueprint;
			this.context = context;

			SetOrigin();
		}

		public readonly BehaviorTreeBlueprint<T> blueprint;
		public readonly T context;

		BehaviorTreeBlueprint<T>.Node runningNode; //The node that was cached as running
		BehaviorTreeBlueprint<T>.StatusToken runningToken; //The token that was used to enter the running node

		public Result Tick()
		{
			var currentNode = runningNode;
			var currentToken = runningToken;

			do
			{
				var nextToken = currentNode.Next(currentToken, context);
				var nextNode = nextToken.ToChild ? currentNode[nextToken.index] : currentNode.Parent;

				if (nextToken.result == Result.running)
				{
					runningNode = currentNode;
					runningToken = currentToken;

					return Result.running;
				}

				currentNode = nextNode;
				currentToken = nextToken;
			}
			while (!(currentNode is BehaviorTreeBlueprint<T>.Root));

			SetOrigin();
			return currentToken.result;
		}

		void SetOrigin()
		{
			runningNode = blueprint.OriginNode;
			runningToken = blueprint.OriginToken;
		}
	}
}