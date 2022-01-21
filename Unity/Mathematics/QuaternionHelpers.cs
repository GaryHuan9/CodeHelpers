#if CODE_HELPERS_UNITY

using System.Runtime.CompilerServices;
using CodeHelpers.Mathematics;
using UnityEngine;

namespace CodeHelpers.Unity.Mathematics
{
	public static class QuaternionHelper
	{
		public static readonly Quaternion x270Rotation = Quaternion.Euler(-90f, 0f, 0f);
	}
}

#endif