using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace CodeHelpers.Packed
{
	partial struct Float2
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(Float2 value) => new Int2((int)value.X, (int)value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(Float2 value) => (Int3)(Int2)value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(Float2 value) => (Int4)(Int2)value;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(float value) => new Float2(value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(Float2 value) => new Float3(value.X, value.Y, 0f);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(Float2 value) => new Float4(value.X, value.Y, 0f, 0f);

#if CODE_HELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float2(UnityEngine.Vector2 value) => new Float2(value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector2(Float2 value) => new UnityEngine.Vector2(value.X, value.Y);
#endif
	}

	partial struct Float3
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(in Float3 value) => (Int2)(Int3)value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(in Float3 value) => new Int3((int)value.X, (int)value.Y, (int)value.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(in Float3 value) => (Int4)(Int3)value;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator Float2(in Float3 value)
		{
#if NET5_0
			return Unsafe.As<Float3, Float2>(ref Unsafe.AsRef(in value));
#else
			return new Float2(value.X, value.Y);
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(float value) => new Float3(value, value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(in Float3 value) => new Float4(value.X, value.Y, value.Z, 0f);

#if CODE_HELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float3(UnityEngine.Vector3 value) => new Float3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector3(in Float3 value) => new UnityEngine.Vector3(value.X, value.Y, value.Z);
#endif
	}

	partial struct Float4
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(in Float4 value) => (Int2)(Int4)value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(in Float4 value) => (Int3)(Int4)value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(in Float4 value) => new Int4((int)value.X, (int)value.Y, (int)value.Z, (int)value.W);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator Float2(in Float4 value)
		{
#if NET5_0
			return Unsafe.As<Float4, Float2>(ref Unsafe.AsRef(in value));
#else
			return new Float2(value.X, value.Y);
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator Float3(in Float4 value)
		{
#if NET5_0
			return Unsafe.As<Float4, Float3>(ref Unsafe.AsRef(in value));
#else
			return new Float3(value.X, value.Y, value.Z);
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(float value) => new Float4(Vector128.Create(value));

#if CODE_HELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float4(UnityEngine.Vector4 value) => new Float4(value.x, value.y, value.z, value.w);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector4(in Float4 value) => new UnityEngine.Vector4(value.X, value.Y, value.Z, value.W);
#endif
	}

	partial struct Int2
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(int value) => new Int2(value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(Int2 value) => new Int3(value.X, value.Y, 0);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(Int2 value) => new Int4(value.X, value.Y, 0, 0);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float2(Int2 value) => new Float2(value.X, value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(Int2 value) => (Float3)(Float2)value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(Int2 value) => (Float4)(Float2)value;

#if CODE_HELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Int2(UnityEngine.Vector2Int value) => new Int2(value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector2Int(Int2 value) => new UnityEngine.Vector2Int(value.X, value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector2(Int2 value) => new UnityEngine.Vector2(value.X, value.Y);
#endif
	}

	partial struct Int3
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator Int2(in Int3 value)
		{
#if NET5_0
			return Unsafe.As<Int3, Int2>(ref Unsafe.AsRef(in value));
#else
			return new Int2(value.X, value.Y);
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(int value) => new Int3(value, value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(in Int3 value) => new Int4(value.X, value.Y, value.Z, 0);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(in Int3 value) => (Float2)(Float3)value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float3(in Int3 value) => new Float3(value.X, value.Y, value.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(in Int3 value) => (Float4)(Float3)value;

#if CODE_HELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Int3(UnityEngine.Vector3Int value) => new Int3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector3Int(in Int3 value) => new UnityEngine.Vector3Int(value.X, value.Y, value.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector3(in Int3 value) => new UnityEngine.Vector3(value.X, value.Y, value.Z);
#endif
	}

	partial struct Int4
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator Int2(in Int4 value)
		{
#if NET5_0
			return Unsafe.As<Int4, Int2>(ref Unsafe.AsRef(in value));
#else
			return new Int2(value.X, value.Y);
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator Int3(in Int4 value)
		{
#if NET5_0
			return Unsafe.As<Int4, Int3>(ref Unsafe.AsRef(in value));
#else
			return new Int3(value.X, value.Y, value.Z);
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(int value) => new Int4(value, value, value, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(in Int4 value) => (Float2)(Float4)value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(in Int4 value) => (Float3)(Float4)value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float4(in Int4 value) => new Float4(value.X, value.Y, value.Z, value.W);

#if CODE_HELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector4(in Int4 value) => new UnityEngine.Vector4(value.X, value.Y, value.Z, value.W);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Quaternion(in Int4 value) => new UnityEngine.Quaternion(value.X, value.Y, value.Z, value.W);
#endif
	}
}