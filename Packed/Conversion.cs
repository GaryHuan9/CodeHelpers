using System.Runtime.CompilerServices;

namespace CodeHelpers.Packed
{
	public partial struct Float2
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(Float2 value) => new Int2((int)value.X, (int)value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(Float2 value) => new Int3((int)value.X, (int)value.Y, 0);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(Float2 value) => new Int4((int)value.X, (int)value.Y, 0, 0);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(float value) => new Float2(value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(Float2 value) => value.XY_;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(Float2 value) => new Float4(value.X, value.Y, 0f, 0f);

#if CODE_HELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float2(UnityEngine.Vector2 value) => new Float2(value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector2(Float2 value) => new UnityEngine.Vector2(value.X, value.Y);
#endif
	}

	public partial struct Float3
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(in Float3 value) => new Int2((int)value.X, (int)value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(in Float3 value) => new Int3((int)value.X, (int)value.Y, (int)value.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(in Float3 value) => new Int4((int)value.X, (int)value.Y, (int)value.Z, 0);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(in Float3 value) => value.XY;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(float value) => new Float3(value, value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(in Float3 value) => new Float4(value.X, value.Y, value.Z, 0f);

#if CODE_HELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float3(UnityEngine.Vector3 value) => new Float3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector3(in Float3 value) => new UnityEngine.Vector3(value.X, value.Y, value.Z);
#endif
	}

	public partial struct Float4
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(in Float4 value) => new Int2((int)value.X, (int)value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(in Float4 value) => new Int3((int)value.X, (int)value.Y, (int)value.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(in Float4 value) => new Int4((int)value.X, (int)value.Y, (int)value.Z, (int)value.W);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(in Float4 value) => value.XY;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(in Float4 value) => value.XYZ;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(float value) => new Float4(value, value, value, value);

#if CODE_HELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float4(UnityEngine.Vector4 value) => new Float4(value.x, value.y, value.z, value.w);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector4(in Float4 value) => new UnityEngine.Vector4(value.X, value.Y, value.Z, value.W);
#endif
	}

	public partial struct Int2
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(int value) => new Int2(value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(Int2 value) => value.XY_;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(Int2 value) => new Int4(value.X, value.Y, 0, 0);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float2(Int2 value) => new Float2(value.X, value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(Int2 value) => new Float3(value.X, value.Y, 0f);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(Int2 value) => new Float4(value.X, value.Y, 0f, 0f);

#if CODE_HELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Int2(UnityEngine.Vector2Int value) => new Int2(value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector2Int(Int2 value) => new UnityEngine.Vector2Int(value.X, value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector2(Int2 value) => new UnityEngine.Vector2(value.X, value.Y);
#endif
	}

	public partial struct Int3
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(in Int3 value) => value.XY;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(int value) => new Int3(value, value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(in Int3 value) => new Int4(value.X, value.Y, value.Z, 0);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(in Int3 value) => new Float2(value.X, value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float3(in Int3 value) => new Float3(value.X, value.Y, value.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(in Int3 value) => new Float4(value.X, value.Y, value.Z, 0f);

#if CODE_HELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Int3(UnityEngine.Vector3Int value) => new Int3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector3Int(in Int3 value) => new UnityEngine.Vector3Int(value.X, value.Y, value.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector3(in Int3 value) => new UnityEngine.Vector3(value.X, value.Y, value.Z);
#endif
	}

	public partial struct Int4
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(in Int4 value) => value.XY;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(in Int4 value) => value.XYZ;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(int value) => new Int4(value, value, value, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(in Int4 value) => new Float2(value.X, value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(in Int4 value) => new Float3(value.X, value.Y, value.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float4(in Int4 value) => new Float4(value.X, value.Y, value.Z, value.W);

#if CODE_HELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector4(in Int4 value) => new UnityEngine.Vector4(value.X, value.Y, value.Z, value.W);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Quaternion(in Int4 value) => new UnityEngine.Quaternion(value.X, value.Y, value.Z, value.W);
#endif
	}
}