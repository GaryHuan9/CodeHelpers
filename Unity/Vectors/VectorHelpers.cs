#if CODEHELPERS_UNITY

using System;
using System.Runtime.CompilerServices;
using CodeHelpers.Vectors;
using UnityEngine;

namespace CodeHelpers.Unity.Vectors
{
	public static class VectorHelper
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 C(this Vector3 value) => new Float3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 C(this Vector3Int value) => new Int3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float2 C(this Vector2 value) => new Float2(value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 C(this Vector2Int value) => new Int2(value.x, value.y);

		public static Vector4 Absoluted(this Vector4 vector) => Vector4.Max(vector, -vector);

		public static float MaxComponent(this Vector4 vector) => Math.Max(Math.Max(vector.x, vector.y), Math.Max(vector.z, vector.w));
		public static float MinComponent(this Vector4 vector) => Math.Min(Math.Min(vector.x, vector.y), Math.Min(vector.z, vector.w));

		public static float Product(this Vector4 vector) => vector.x * vector.y * vector.z * vector.w;
		public static float Sum(this Vector4 vector) => vector.x + vector.y + vector.z + vector.w;

		/// <summary>
		/// Gets the index of the largest element in this vector.
		/// </summary>
		public static int GetMaxIndex(this Vector4 vector)
		{
			if (vector.x > vector.y)
			{
				if (vector.x > vector.z)
				{
					return vector.x > vector.w ? 0 : 3;
				}

				return vector.z > vector.w ? 2 : 3;
			}

			if (vector.y > vector.z)
			{
				return vector.y > vector.w ? 1 : 3;
			}

			return vector.z > vector.w ? 2 : 3;
		}

		/// <summary>
		/// Gets the index of the smallest element in this vector.
		/// </summary>
		public static int GetMinIndex(this Vector4 vector)
		{
			if (vector.x < vector.y)
			{
				if (vector.x < vector.z)
				{
					return vector.x < vector.w ? 0 : 3;
				}

				return vector.z < vector.w ? 2 : 3;
			}

			if (vector.y < vector.z)
			{
				return vector.y < vector.w ? 1 : 3;
			}

			return vector.z < vector.w ? 2 : 3;
		}

		public static void ForEach(this Vector4 vector, Action<float> action)
		{
			for (int i = 0; i < 4; i++)
			{
				action(vector[i]);
			}
		}

		public static void ForEach(this Vector4 vector, Action<float, int> action)
		{
			for (int i = 0; i < 4; i++)
			{
				action(vector[i], i);
			}
		}

		public static void Swap(this ref Vector4 vector, int index1, int index2)
		{
			float storage = vector[index1];
			vector[index1] = vector[index2];
			vector[index2] = storage;
		}

		public static Vector4 Replace(this Vector4 vector, int index, float value)
		{
			vector[index] = value;
			return vector;
		}

		public static Vector4 EpsilonVector4 => Vector4.one * Scalars.Epsilon;

		public static Vector4 MaxVector4 => Vector4.one * float.MaxValue;
		public static Vector4 MinVector4 => Vector4.one * float.MinValue;
	}
}

#endif