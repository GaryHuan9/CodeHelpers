#if CODEHELPERS_UNITY

using CodeHelpers.Mathematics;
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
			if (Mathf.Approximately(angle, 0f)) return direction;

			var axis = Quaternion.FromToRotation(Float3.forward, direction) * Float2.right.Rotate(RandomHelper.Range(360f)).U();
			return Quaternion.AngleAxis(angle, axis) * direction;
		}
	}
}

#endif