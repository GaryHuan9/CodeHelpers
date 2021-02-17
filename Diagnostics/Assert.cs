using System;
using System.Collections.Generic;
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
			throw new Exception("Target is null!");
		}

		[Conditional("DEBUG"), Conditional("UNITY_ASSERTIONS")]
		public static void IsNull<T>(T target) where T : class
		{
			if (target == null) return;
			throw new Exception("Target is not null!");
		}

		[Conditional("DEBUG"), Conditional("UNITY_ASSERTIONS")]
		public static void IsTrue(bool target)
		{
			if (target) return;
			throw new Exception("Target is not true!");
		}

		[Conditional("DEBUG"), Conditional("UNITY_ASSERTIONS")]
		public static void IsFalse(bool target)
		{
			if (!target) return;
			throw new Exception("Target is not false!");
		}

		[Conditional("DEBUG"), Conditional("UNITY_ASSERTIONS")]
		public static void AreEqual<T>(T target, T other)
		{
			if (EqualityComparer<T>.Default.Equals(target, other)) return;
			throw new Exception("Target and other are not equal!");
		}

		[Conditional("DEBUG"), Conditional("UNITY_ASSERTIONS")]
		public static void AreNotEqual<T>(T target, T other)
		{
			if (!EqualityComparer<T>.Default.Equals(target, other)) return;
			throw new Exception("Target and other are equal!");
		}
	}
}