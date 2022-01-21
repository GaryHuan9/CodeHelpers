using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using CodeHelpers.Mathematics;

namespace CodeHelpers.Diagnostics
{
	public static class Assert
	{
		[Conditional("DEBUG")]
		public static void IsNotNull<T>(T target) where T : class
		{
			if (target != null) return;
			throw new Exception("Target is null!");
		}

		[Conditional("DEBUG")]
		public static void IsNull<T>(T target) where T : class
		{
			if (target == null) return;
			throw new Exception("Target is not null!");
		}

		[Conditional("DEBUG")]
		public static void IsTrue([DoesNotReturnIf(false)] bool target)
		{
			if (target) return;
			throw new Exception("Target is not true!");
		}

		[Conditional("DEBUG")]
		public static void IsFalse([DoesNotReturnIf(true)] bool target)
		{
			if (!target) return;
			throw new Exception("Target is not false!");
		}

		[Conditional("DEBUG")]
		public static void AreEqual<T>(T target, T other)
		{
			if (AreEqualInternal(target, other)) return;
			throw new Exception("Target and other are not equal!");
		}

		[Conditional("DEBUG")]
		public static void AreNotEqual<T>(T target, T other)
		{
			if (!AreEqualInternal(target, other)) return;
			throw new Exception("Target and other are equal!");
		}

		static bool AreEqualInternal<T>(T target, T other) => target switch
		{
			float value => value.AlmostEquals((float)(object)other),
			double value => value.AlmostEquals((double)(object)other),
			_ => EqualityComparer<T>.Default.Equals(target, other)
		};
	}
}