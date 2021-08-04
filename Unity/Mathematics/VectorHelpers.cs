#if CODEHELPERS_UNITY

using System;
using System.Runtime.CompilerServices;
using CodeHelpers.Mathematics;
using UnityEngine;

namespace CodeHelpers.Unity.Mathematics
{
	public static class VectorHelper
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 C(this Vector4 value) => value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 C(this Vector3 value) => value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 C(this Vector2 value) => value;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 C(this Vector3Int value) => value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 C(this Vector2Int value) => value;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Versor C(this Quaternion value) => value;
	}
}

#endif