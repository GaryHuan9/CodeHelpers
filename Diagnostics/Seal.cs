using System.Diagnostics;

namespace CodeHelpers.Diagnostics
{
	/// <summary>
	/// A mutable struct that defines a one-time seal to be used for debugging, which is mostly used to indicate the semi-readonly-ness of
	/// certain objects (i.e. a particular set of operations is available prior to sealing, while another set is available after sealing).
	/// </summary>
	public struct Seal
	{
#if DEBUG
		internal volatile bool applied;
#endif

		/// <summary>
		/// Makes sure that the <see cref="Seal"/> is not <see cref="applied"/>.
		/// </summary>
		[Conditional(Assert.DebugSymbol)]
		public readonly void AssertNotApplied()
		{
#if DEBUG
			if (applied) throw new System.Exception($"Invalid operation after the {nameof(Seal)} has been applied.");
#endif
		}

		/// <summary>
		/// Makes sure that the <see cref="Seal"/> is <see cref="applied"/>.
		/// </summary>
		[Conditional(Assert.DebugSymbol)]
		public readonly void AssertApplied()
		{
#if DEBUG
			if (!applied) throw new System.Exception($"Invalid operation before the {nameof(Seal)} has been applied.");
#endif
		}
	}

	public static class SealExtensions
	{
		//NOTE: the reason that the apply methods are defined as extension methods is to use the ref keyword,
		//which disallows potential accidental readonly declarations of the struct from invoking this method.

		/// <summary>
		/// Applies this seal; note that this is a one time operation.
		/// </summary>
		[Conditional(Assert.DebugSymbol)]
		public static void Apply(ref this Seal seal)
		{
#if DEBUG
			seal.AssertNotApplied();
			TryApply(ref seal);
#endif
		}

		/// <summary>
		/// Applies this seal; note that this is a one time operation.
		/// </summary>
		[Conditional(Assert.DebugSymbol)]
		public static void TryApply(ref this Seal seal)
		{
#if DEBUG
			seal.applied = true;
#endif
		}
	}
}