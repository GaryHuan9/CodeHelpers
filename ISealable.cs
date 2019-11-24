using System;

namespace CodeHelpers
{
	public interface ISealable
	{
		/// <summary>
		/// A semi readonly property; can only be assigned to true by invoking <see cref="Seal"/>.
		/// </summary>
		bool IsSealed { get; }

		/// <summary>
		/// Seals this item. NOTE: If item is already sealed (<see cref="IsSealed"/> == true), this method will/should throw an exception.
		/// </summary>
		void Seal();
	}

	public static class SealableExtensions
	{
		/// <summary>
		/// Throws exception when the sealable is already sealed.
		/// </summary>
		public static void CheckSealed<T>(this T sealable) where T : ISealable
		{
			if (sealable.IsSealed) throw new Exception("Invalid access after the object has been sealed!");
		}

		/// <summary>
		/// Throws exception when the sealable is still not sealed.
		/// </summary>
		public static void CheckNotSealed<T>(this T sealable) where T : ISealable
		{
			if (!sealable.IsSealed) throw new Exception("Invalid access before sealing the object!");
		}
	}
}