#if CODE_HELPERS_UNITY

using CodeHelpers.Mathematics;
using CodeHelpers.Packed;
using UnityEngine;

namespace CodeHelpers.Unity
{
	public static class RandomHelperUnity
	{
		/// <summary>
		/// Tilts the vector <paramref name="direction"/> randomly at an angle of <paramref name="angle"/>.
		/// Imagine a random plane that is created aligned to <paramref name="direction"/>, then this method
		/// will rotate <paramref name="direction"/> by <paramref name="angle"/>.
		/// </summary>
		public static Float3 RandomTilt(Float3 direction, float angle)
		{
			if (angle.AlmostEquals()) return direction;

			var axis = Quaternion.FromToRotation(Float3.Forward, direction) * Float2.Right.Rotate(RandomHelper.Range(360f)).U();
			return Quaternion.AngleAxis(angle, axis) * direction;
		}
	}
}

#endif