#if CODEHELPERS_UNITY

using System.Runtime.CompilerServices;
using CodeHelpers.Vectors;

namespace CodeHelpers.Unity
{
	public static class VectorHelper
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 C(this UnityEngine.Vector3 value) => new Float3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 C(this UnityEngine.Vector3Int value) => new Int3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 C(this UnityEngine.Vector2 value) => new Float2(value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 C(this UnityEngine.Vector2Int value) => new Int2(value.x, value.y);
	}
}

#endif