using UnityEngine;

namespace CodeHelpers.VectorHelpers
{
	public static class QuaternionHelper
	{
		public static readonly Quaternion x270Rotation = Quaternion.Euler(-90f, 0f, 0f);

		public static bool Approximately(Quaternion quaternion1, Quaternion quaternion2) => Mathf.Approximately(Quaternion.Angle(quaternion1, quaternion2), 0f);
	}
}