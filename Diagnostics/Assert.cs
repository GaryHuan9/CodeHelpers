using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace CodeHelpers.Diagnostics
{
	public static class Assert
	{
		[Conditional("DEBUG"), Conditional("UNITY_ASSERTIONS")]
		public static void IsNotNull<T>(T target) where T : class
		{
			if (target != null) return;
			throw ExceptionHelper.Invalid(nameof(target), InvalidType.isNull);
		}
	}
}