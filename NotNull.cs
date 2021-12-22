namespace CodeHelpers
{
	/// <summary>
	/// A simple struct wrapper that helps making a property not null.
	/// </summary>
	public readonly struct NotNull<T> where T : class
	{
		public NotNull(T storage) => this.storage = storage ?? throw ExceptionHelper.Invalid(nameof(storage), InvalidType.isNull);

		readonly T storage;

		public static implicit operator NotNull<T>(T target) => new(target);
		public static implicit operator T(NotNull<T> target) => target.storage ?? throw ExceptionHelper.Invalid(nameof(storage), InvalidType.isNull);
	}
}