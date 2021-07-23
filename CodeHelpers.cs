using System.Linq;
using System.Reflection;
using CodeHelpers.Mathematics;

namespace CodeHelpers
{
	public static class CodeHelper
	{
		public static void Swap<T>(ref T first, ref T second)
		{
			T storage = first;
			first = second;
			second = storage;
		}

		public static T ToNotNullable<T>(this T? nullable, out bool isNull) where T : struct
		{
			isNull = nullable == null;
			return nullable.GetValueOrDefault();
		}

		public static string ToMethodSignature(this MethodInfo method) =>
			$@"{method.ReturnType.Name} {method.Name}({string.Join(", ", from parameter in method.GetParameters()
																		 select $"{parameter.ParameterType.Name} {parameter.Name}")})";

		public static string ToMethodSignatureNoReturnType(this MethodInfo method) =>
			$@"{method.Name}({string.Join(", ", from parameter in method.GetParameters()
												select $"{parameter.ParameterType.Name} {parameter.Name}")})";

		/// <summary>
		/// Damped interpolation of a quaternion. Code based on: https://gist.github.com/maxattack/4c7b4de00f5c1b95a33b
		/// </summary>
		public static Float4 Damp(Float4 current, Float4 target, ref Float4 velocity, float smoothTime, float deltaTime)
		{
			if (deltaTime < Scalars.Epsilon) return current;
			if (current.Dot(target) < 0f) target = -target;

			Float4 result = current.Damp(target, ref velocity, smoothTime, deltaTime).Normalized;
			velocity -= velocity.Project(result);

			return result;
		}
	}
}