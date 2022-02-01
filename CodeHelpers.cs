﻿using System.Linq;
using System.Reflection;

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
	}
}