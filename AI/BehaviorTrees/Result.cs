namespace CodeHelpers.AI.BehaviorTrees
{
	public delegate Result BehaviorAction<in T>(T context);

	public enum Result : byte
	{
		success,
		failure,
		running,
		enter //Special status used when a parent is entering a child
	}

	public enum SealResult //Seal the blueprint
	{
		success,
		noParent,
		minChildCount
	}

	public static class ResultExtensions
	{
		public static Result Opposite(this Result result)
		{
			switch (result)
			{
				case Result.success: return Result.failure;
				case Result.failure: return Result.success;
			}

			throw ExceptionHelper.Invalid(nameof(result), result, InvalidType.unexpected);
		}

		public static string ToErrorMessage(this SealResult result)
		{
			switch (result)
			{
				case SealResult.success:       return "Success: No error";
				case SealResult.noParent:      return "One or more non-root node has no parent";
				case SealResult.minChildCount: return "One or more node does not have enough children to meet its minimum requirement";
			}

			throw ExceptionHelper.Invalid(nameof(result), result, InvalidType.unexpected);
		}

		public static Result ToResult(this bool value) => value ? Result.success : Result.failure;
	}
}