using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeHelpers
{
	public static class DebugHelper
	{
		internal const string NullString = "_NULL_";

		public static string ToString(object target)
		{
			string customToString = GetCustomToString(target);
			if (customToString != null) return customToString;

			switch (target)
			{
				case null:                   return NullString;
				case string stringTarget:    return ToString(stringTarget);
				case IEnumerable enumerable: return ToString(enumerable.Cast<object>());
			}

			return $"{target} (HCode: {target.GetHashCode()})";
		}

		public static string ToString(string target) => target;

		public static string ToString<T>(IEnumerable<T> target)
		{
			var array = target.Select(item => ToString(item)).ToArray();
			return $"{target.GetType()} + Count: {array.Length} [{string.Join(", ", array)}]";
		}

		/// <summary>
		/// Does <paramref name="target"/> has a custom to string method?
		/// Returns the custom to string if it has one, or null if is default.
		/// </summary>
		static string GetCustomToString(object target)
		{
			if (target is null) return null;
			string toString = target.ToString();
			return toString == target.GetType().ToString() ? null : toString;
		}
	}
}