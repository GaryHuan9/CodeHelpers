#if CODEHELPERS_UNITY

using System;
using System.Runtime.CompilerServices;
using CodeHelpers.Mathematics;
using UnityEngine;

namespace CodeHelpers.Unity.Mathematics
{
	public static class VectorHelper
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 C(this Vector4 value) => new Float4(value.x, value.y, value.z, value.w);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 C(this Vector3 value) => new Float3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 C(this Vector2 value) => new Float2(value.x, value.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 C(this Vector3Int value) => new Int3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 C(this Vector2Int value) => new Int2(value.x, value.y);
	}
}

#endif