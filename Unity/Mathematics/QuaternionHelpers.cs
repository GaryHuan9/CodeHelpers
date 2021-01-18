#if CODEHELPERS_UNITY

using System.Runtime.CompilerServices;
using CodeHelpers.Mathematics;
using UnityEngine;

namespace CodeHelpers.Unity.Mathematics
{
	public static class QuaternionHelper
	{
		public static readonly Quaternion x270Rotation = Quaternion.Euler(-90f, 0f, 0f);

		public static bool AlmostEquals(this Quaternion value, Quaternion other) => Scalars.AlmostEquals(Quaternion.Angle(value, other), 0f);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 C(this Quaternion value) => new Float4(value.x, value.y, value.z, value.w);
	}
}

#endif