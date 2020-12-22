#if CODEHELPERS_UNITY

using CodeHelpers.Mathematics;
using UnityEngine;

namespace CodeHelpers.Unity.Mathematics
{
	public static class QuaternionHelper
	{
		public static readonly Quaternion x270Rotation = Quaternion.Euler(-90f, 0f, 0f);

		public static bool AlmostEquals(Quaternion quaternion1, Quaternion quaternion2) => Scalars.AlmostEquals(Quaternion.Angle(quaternion1, quaternion2), 0f);
	}
}

#endif