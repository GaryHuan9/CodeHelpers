using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CodeHelpers.VectorHelpers;
using UnityEngine;

namespace CodeHelpers
{
	public static class VectorHelper
	{

#region Vector3 Helpers

		public static Vector3 ToXZ3(this Vector2 vector, float y = 0) => new Vector3(vector.x, y, vector.y);
		public static Vector3 ToXZ3(this Vector2Int vector, float y) => new Vector3(vector.x, y, vector.y);
		public static Vector3Int ToXZ3(this Vector2Int vector, int y = 0) => new Vector3Int(vector.x, y, vector.y);

		public static Vector3 ToVectorWithY(this Vector3 vector, float y) => new Vector3(vector.x, y, vector.z);
		public static Vector3Int ToVectorWithY(this Vector3Int vector, int y) => new Vector3Int(vector.x, y, vector.z);

		public static void SetXZ(this ref Vector3 vector, Vector2 xz) => vector = new Vector3(xz.x, vector.y, xz.y);
		public static void SetXZ(this ref Vector3Int vector, Vector2Int xz) => vector = new Vector3Int(xz.x, vector.y, xz.y);

		public static Vector3Int Floor(this Vector3 vector) => new Vector3Int(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y), Mathf.FloorToInt(vector.z));
		public static Vector3Int FloorEpsilon(this Vector3 vector) => new Vector3Int(Mathf.FloorToInt(vector.x + CodeHelper.Epsilon), Mathf.FloorToInt(vector.y + CodeHelper.Epsilon), Mathf.FloorToInt(vector.z + CodeHelper.Epsilon));

		public static Vector3Int Ceil(this Vector3 vector) => new Vector3Int(Mathf.CeilToInt(vector.x), Mathf.CeilToInt(vector.y), Mathf.CeilToInt(vector.z));
		public static Vector3Int CeilEpsilon(this Vector3 vector) => new Vector3Int(Mathf.CeilToInt(vector.x - CodeHelper.Epsilon), Mathf.CeilToInt(vector.y - CodeHelper.Epsilon), Mathf.CeilToInt(vector.z - CodeHelper.Epsilon));

		public static Vector3 Round(this Vector3 vector) => new Vector3(Mathf.Round(vector.x), Mathf.Round(vector.y), Mathf.Round(vector.z));
		public static Vector3Int RoundToInt(this Vector3 vector) => new Vector3Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y), Mathf.RoundToInt(vector.z));

		// NOTE: TODO: The current implementation of rounding by increment will destroy the floating-point accuracy when increment is too small or too large! Fix that!
		public static Vector3 Round(this Vector3 vector, float increment) => new Vector3(Mathf.Round(vector.x / increment) * increment, Mathf.Round(vector.y / increment) * increment, Mathf.Round(vector.z / increment) * increment);
		public static Vector3Int Round(this Vector3 vector, int increment) => new Vector3Int(Mathf.RoundToInt(vector.x / increment) * increment, Mathf.RoundToInt(vector.y / increment) * increment, Mathf.RoundToInt(vector.z / increment) * increment);

		public static Vector3 ToFloat(this Vector3Int vector) => new Vector3(vector.x, vector.y, vector.z);
		public static Vector3Int ToInt(this Vector3 vector) => new Vector3Int((int)vector.x, (int)vector.y, (int)vector.z);

		public static Vector3 RotateXZ(this Vector3 vector, float degree) => vector.ToXZ2().Rotate(degree).ToXZ3(vector.y);
		public static Vector3 RotateXZ(this Vector3 vector, float degree, Vector2 xzPivot) => vector.ToXZ2().Rotate(degree, xzPivot).ToXZ3(vector.y);
		public static Vector3 RotateXZ(this Vector3Int vector, float degree) => vector.ToFloat().RotateXZ(degree);
		public static Vector3 RotateXZ(this Vector3Int vector, float degree, Vector2 xzPivot) => vector.ToFloat().RotateXZ(degree, xzPivot);

		public static Vector3 Mod(this Vector3 vector, float modValue) => new Vector3(vector.x % modValue, vector.y % modValue, vector.z % modValue);
		public static Vector3 Mod(this Vector3Int vector, float modValue) => new Vector3(vector.x % modValue, vector.y % modValue, vector.z % modValue);
		public static Vector3 Mod(this Vector3 vector, Vector3 modValue) => new Vector3(vector.x % modValue.x, vector.y % modValue.y, vector.z % modValue.z);
		public static Vector3Int Mod(this Vector3Int vector, Vector3Int modValue) => new Vector3Int(vector.x % modValue.x, vector.y % modValue.y, vector.z % modValue.z);

		public static Vector3 Repeat(this Vector3 vector, Vector3 length) => new Vector3(vector.x.Repeat(length.x), vector.y.Repeat(length.y), vector.z.Repeat(length.z));
		public static Vector3 Repeat(this Vector3 vector, float length) => new Vector3(vector.x.Repeat(length), vector.y.Repeat(length), vector.z.Repeat(length));
		public static Vector3Int Repeat(this Vector3Int vector, Vector3Int length) => new Vector3Int(vector.x.Repeat(length.x), vector.y.Repeat(length.y), vector.z.Repeat(length.z));
		public static Vector3Int Repeat(this Vector3Int vector, int length) => new Vector3Int(vector.x.Repeat(length), vector.y.Repeat(length), vector.z.Repeat(length));

		public static Vector3 Abs(this Vector3 vector) => new Vector3(Math.Abs(vector.x), Math.Abs(vector.y), Math.Abs(vector.z));
		public static Vector3Int Abs(this Vector3Int vector) => new Vector3Int(Math.Abs(vector.x), Math.Abs(vector.y), Math.Abs(vector.z));

		public static Vector3 AddEpsilon(this Vector3 vector, int scale = 1) => vector + Vector3.one * CodeHelper.Epsilon * scale;

		public static Vector3 Divide(this Vector3 vector, Vector3 otherVector) => new Vector3(vector.x / otherVector.x, vector.y / otherVector.y, vector.z / otherVector.z);
		public static Vector3Int Divide(this Vector3Int vector, Vector3Int otherVector) => new Vector3Int(vector.x / otherVector.x, vector.y / otherVector.y, vector.z / otherVector.z);
		public static Vector3Int Divide(this Vector3Int vector, int value) => new Vector3Int(vector.x / value, vector.y / value, vector.z / value);

		public static Vector3Int FlooredDivide(this Vector3Int vector, Vector3Int otherVector) => new Vector3Int(vector.x.FlooredDivide(otherVector.x), vector.y.FlooredDivide(otherVector.y), vector.z.FlooredDivide(otherVector.z));
		public static Vector3Int FlooredDivide(this Vector3Int vector, int value) => new Vector3Int(vector.x.FlooredDivide(value), vector.y.FlooredDivide(value), vector.z.FlooredDivide(value));

		public static float MaxValue(this Vector3 vector) => Math.Max(vector.x, Math.Max(vector.y, vector.z));
		public static float MinValue(this Vector3 vector) => Math.Min(vector.x, Math.Min(vector.y, vector.z));

		public static int MaxValue(this Vector3Int vector) => Math.Max(vector.x, Math.Max(vector.y, vector.z));
		public static int MinValue(this Vector3Int vector) => Math.Min(vector.x, Math.Min(vector.y, vector.z));

		public static float Size(this Vector3 vector) => Math.Abs(vector.x * vector.y * vector.z);
		public static int Size(this Vector3Int vector) => Math.Abs(vector.x * vector.y * vector.z);

		public static Vector3Int IndividualNormalize(this Vector3 vector) => new Vector3Int(vector.x.Normalized(), vector.y.Normalized(), vector.z.Normalized());
		public static Vector3Int IndividualNormalize(this Vector3Int vector) => new Vector3Int(vector.x.Normalized(), vector.y.Normalized(), vector.z.Normalized());

		/// <summary>
		/// Gets the index of the largest element in this vector.
		/// </summary>
		public static int GetMaxIndex(this Vector3 vector) => vector.x > vector.y ? (vector.x > vector.z ? 0 : 2) : (vector.y > vector.z ? 1 : 2);

		/// <summary>
		/// Gets the index of the largest element in this vector.
		/// </summary>
		public static int GetMaxIndex(this Vector3Int vector) => vector.x > vector.y ? (vector.x > vector.z ? 0 : 2) : (vector.y > vector.z ? 1 : 2);

		/// <summary>
		/// Gets the index of the smallest element in this vector.
		/// </summary>
		public static int GetMinIndex(this Vector3 vector) => vector.x < vector.y ? (vector.x < vector.z ? 0 : 2) : (vector.y < vector.z ? 1 : 2);

		/// <summary>
		/// Gets the index of the smallest element in this vector.
		/// </summary>
		public static int GetMinIndex(this Vector3Int vector) => vector.x < vector.y ? (vector.x < vector.z ? 0 : 2) : (vector.y < vector.z ? 1 : 2);

		public static bool LessThan(this Vector3 vector, Vector3 otherVector) => vector.x < otherVector.x && vector.y < otherVector.y && vector.z < otherVector.z;
		public static bool GreaterThan(this Vector3 vector, Vector3 otherVector) => vector.x > otherVector.x && vector.y > otherVector.y && vector.z > otherVector.z;
		public static bool LessThanOrEquals(this Vector3 vector, Vector3 otherVector) => vector.x <= otherVector.x && vector.y <= otherVector.y && vector.z <= otherVector.z;
		public static bool GreaterThanOrEquals(this Vector3 vector, Vector3 otherVector) => vector.x >= otherVector.x && vector.y >= otherVector.y && vector.z >= otherVector.z;

		public static bool LessThan(this Vector3Int vector, Vector3Int otherVector) => vector.x < otherVector.x && vector.y < otherVector.y && vector.z < otherVector.z;
		public static bool GreaterThan(this Vector3Int vector, Vector3Int otherVector) => vector.x > otherVector.x && vector.y > otherVector.y && vector.z > otherVector.z;
		public static bool LessThanOrEquals(this Vector3Int vector, Vector3Int otherVector) => vector.x <= otherVector.x && vector.y <= otherVector.y && vector.z <= otherVector.z;
		public static bool GreaterThanOrEquals(this Vector3Int vector, Vector3Int otherVector) => vector.x >= otherVector.x && vector.y >= otherVector.y && vector.z >= otherVector.z;

		public static void Swap(this ref Vector3 vector, int index1, int index2)
		{
			float storage = vector[index1];
			vector[index1] = vector[index2];
			vector[index2] = storage;
		}

		public static void Swap(this ref Vector3Int vector, int index1, int index2)
		{
			int storage = vector[index1];
			vector[index1] = vector[index2];
			vector[index2] = storage;
		}

		public static Vector3 EpsilonVector3 => Vector3.one * CodeHelper.Epsilon;

		public static Vector3 MaxVector3 => Vector3.one * float.MaxValue;
		public static Vector3 MinVector3 => Vector3.one * float.MinValue;

		/// <summary>
		/// Gets an IEnumerable which will yield all the positions of a sphere located at (0,0,0) with a <paramref name="radius"/>.
		/// </summary>
		public static IEnumerable<Vector3Int> GetPointsFromSphere(float radius)
		{
			int radiusInt = Mathf.CeilToInt(radius - CodeHelper.Epsilon);
			float radiusSquared = radius * radius;

			for (int x = -radiusInt; x <= radiusInt; x++)
			{
				for (int y = -radiusInt; y <= radiusInt; y++)
				{
					for (int z = -radiusInt; z <= radiusInt; z++)
					{
						if (x * x + y * y + z * z <= radiusSquared)
						{
							yield return new Vector3Int(x, y, z);
						}
					}
				}
			}
		}

		static readonly Dictionary<int, IReadOnlyList<Vector3Int>> pointsFromSphereCache = new Dictionary<int, IReadOnlyList<Vector3Int>>();

		/// <summary>
		/// Gets all the position inside a sphere whose origin is at (0,0,0).
		/// </summary>
		public static IReadOnlyList<Vector3Int> GetPointsFromSphere(int radius, bool cache = true)
		{
			if (pointsFromSphereCache.ContainsKey(radius)) return pointsFromSphereCache[radius]; //Get from cache

			List<Vector3Int> result = new List<Vector3Int>();
			int radiusSquared = radius * radius;

			for (int x = -radius; x <= radius; x++)
			{
				for (int y = -radius; y <= radius; y++)
				{
					for (int z = -radius; z <= radius; z++)
					{
						if (x * x + y * y + z * z <= radiusSquared) result.Add(new Vector3Int(x, y, z));
					}
				}
			}

			var resultArray = Array.AsReadOnly(result.ToArray());
			if (cache) pointsFromSphereCache.Add(radius, resultArray);
			return resultArray;
		}

		/// <summary>
		/// Returns an IEnumerable which will yield all the positives contained in a line whose two end points are <paramref name="position1"/> and <paramref name="position2"/>.
		/// (All position inclusive)
		/// </summary>
		public static IEnumerable<Vector3Int> GetPositionsFromLine(Vector3Int position1, Vector3Int position2)
		{
			int sampleCount = Mathf.RoundToInt(new MinMax((position1 - position2).Abs()).max);

			for (int i = 0; i <= sampleCount; i++)
			{
				yield return Vector3.Lerp(position1, position2, (float)i / sampleCount).RoundToInt();
			}
		}

		public static readonly IReadOnlyList<Direction> neighbor6Directions = Array.AsReadOnly(Enum.GetValues(typeof(Direction)).Cast<Direction>().ToArray());

		/// <summary>
		/// Neighbor faces (6)
		/// </summary>
		public static readonly IReadOnlyList<Vector3Int> neighbor6Positions = Array.AsReadOnly(
			(from Direction direction in neighbor6Directions
			 select direction.ToVector3()).ToArray()
		);

		/// <summary>
		/// Neighbor faces (6), and edges (12)
		/// </summary>
		public static readonly IReadOnlyList<Vector3Int> neighbor18Positions = new ReadOnlyCollection<Vector3Int>(
			(
				from Vector3Int position in new Vector3Int(3, 3, 3).Loop()
				where position != Vector3Int.one && position.sqrMagnitude % 4 != 0
				select position - Vector3Int.one
			).ToList()
		);

		/// <summary>
		/// Neighbor faces (6), edges (12), and vertices (8)
		/// </summary>
		public static readonly IReadOnlyList<Vector3Int> neighbor26Positions = new ReadOnlyCollection<Vector3Int>(
			(
				from Vector3Int position in new Vector3Int(3, 3, 3).Loop()
				where position != Vector3Int.one
				select position - Vector3Int.one
			).ToList()
		);

#endregion

#region Vector2 Helpers

		public static Vector2 ToXZ2(this Vector3 vector) => new Vector2(vector.x, vector.z);
		public static Vector2Int ToXZ2(this Vector3Int vector) => new Vector2Int(vector.x, vector.z);

		public static Vector2Int Floor(this Vector2 vector) => new Vector2Int(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y));
		public static Vector2Int FloorEpsilon(this Vector2 vector) => new Vector2Int(Mathf.FloorToInt(vector.x + CodeHelper.Epsilon), Mathf.FloorToInt(vector.y + CodeHelper.Epsilon));

		public static Vector2Int Ceil(this Vector2 vector) => new Vector2Int(Mathf.CeilToInt(vector.x), Mathf.CeilToInt(vector.y));
		public static Vector2Int CeilEpsilon(this Vector2 vector) => new Vector2Int(Mathf.CeilToInt(vector.x - CodeHelper.Epsilon), Mathf.CeilToInt(vector.y - CodeHelper.Epsilon));

		public static Vector2 Round(this Vector2 vector) => new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
		public static Vector2Int RoundToInt(this Vector2 vector) => new Vector2Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y));

		// NOTE: TODO: The current implementation of rounding by increment will destroy the floating-point accuracy when increment is too small or too large! Fix that!
		public static Vector2 Round(this Vector2 vector, float increment) => new Vector2(Mathf.Round(vector.x / increment) * increment, Mathf.Round(vector.y / increment) * increment);
		public static Vector2Int Round(this Vector2 vector, int increment) => new Vector2Int(Mathf.RoundToInt(vector.x / increment) * increment, Mathf.RoundToInt(vector.y / increment) * increment);

		public static Vector2 ToFloat(this Vector2Int vector) => new Vector2(vector.x, vector.y);
		public static Vector2Int ToInt(this Vector2 vector) => new Vector2Int((int)vector.x, (int)vector.y);

		public static int To1D(this Vector2Int vector, int height) => vector.y + vector.x * height;

		public static Vector2 Rotate(this Vector2 vector, float angle)
		{
			angle *= Mathf.Deg2Rad;
			float sin = Mathf.Sin(angle);
			float cos = Mathf.Cos(angle);

			return new Vector2(cos * vector.x - sin * vector.y, sin * vector.x + cos * vector.y);
		}

		public static Vector2 Rotate(this Vector2 vector, float angle, Vector2 pivot) => (vector - pivot).Rotate(angle) + pivot;
		public static Vector2 Rotate(this Vector2Int vector, float angle) => Rotate(vector.ToFloat(), angle);
		public static Vector2 Rotate(this Vector2Int vector, float angle, Vector2 pivot) => (vector - pivot).Rotate(angle) + pivot;

		public static Vector2 Mod(this Vector2 vector, float modValue) => new Vector2(vector.x % modValue, vector.y % modValue);
		public static Vector2 Mod(this Vector2Int vector, float modValue) => new Vector2(vector.x % modValue, vector.y % modValue);
		public static Vector2 Mod(this Vector2 vector, Vector2 modValue) => new Vector2(vector.x % modValue.x, vector.y % modValue.y);
		public static Vector2Int Mod(this Vector2Int vector, Vector2Int modValue) => new Vector2Int(vector.x % modValue.x, vector.y % modValue.y);

		public static Vector2 Repeat(this Vector2 vector, Vector2 length) => new Vector2(vector.x.Repeat(length.x), vector.y.Repeat(length.y));
		public static Vector2 Repeat(this Vector2 vector, float length) => new Vector2(vector.x.Repeat(length), vector.y.Repeat(length));
		public static Vector2Int Repeat(this Vector2Int vector, Vector2Int length) => new Vector2Int(vector.x.Repeat(length.x), vector.y.Repeat(length.y));
		public static Vector2Int Repeat(this Vector2Int vector, int length) => new Vector2Int(vector.x.Repeat(length), vector.y.Repeat(length));

		public static Vector2 Clamp(this Vector2 vector, Vector2 minVector, Vector2 maxVector) => new Vector2(Mathf.Clamp(vector.x, minVector.x, maxVector.x), Mathf.Clamp(vector.y, minVector.y, maxVector.y));
		public static Vector2Int Clamp(this Vector2Int vector, Vector2Int minVector, Vector2Int maxVector) => new Vector2Int(Mathf.Clamp(vector.x, minVector.x, maxVector.x), Mathf.Clamp(vector.y, minVector.y, maxVector.y));

		public static Vector2 InverseLerp(this Vector2 vector, Vector2 vector1, Vector2 vector2) => new Vector2(Mathf.InverseLerp(vector.x, vector1.x, vector2.x), Mathf.InverseLerp(vector.y, vector1.y, vector2.y));

		public static Vector2 Abs(this Vector2 vector) => new Vector2(Math.Abs(vector.x), Math.Abs(vector.y));
		public static Vector2Int Abs(this Vector2Int vector) => new Vector2Int(Math.Abs(vector.x), Math.Abs(vector.y));

		public static Vector2 AddEpsilon(this Vector2 vector, int scale = 1) => vector + Vector2.one * Mathf.Epsilon * scale;

		public static Vector2 Divide(this Vector2 vector, Vector2 otherVector) => new Vector2(vector.x / otherVector.x, vector.y / otherVector.y);
		public static Vector2Int Divide(this Vector2Int vector, Vector2Int otherVector) => new Vector2Int(vector.x / otherVector.x, vector.y / otherVector.y);
		public static Vector2Int Divide(this Vector2Int vector, int value) => new Vector2Int(vector.x / value, vector.y / value);

		public static Vector2Int FlooredDivide(this Vector2Int vector, Vector2Int otherVector) => new Vector2Int(vector.x.FlooredDivide(otherVector.x), vector.y.FlooredDivide(otherVector.y));
		public static Vector2Int FlooredDivide(this Vector2Int vector, int value) => new Vector2Int(vector.x.FlooredDivide(value), vector.y.FlooredDivide(value));

		public static void SwapXY(this ref Vector2 vector)
		{
			float storage = vector.x;
			vector.x = vector.y;
			vector.y = storage;
		}

		public static void SwapXY(this ref Vector2Int vector)
		{
			int storage = vector.x;
			vector.x = vector.y;
			vector.y = storage;
		}

		public static float MaxValue(this Vector2 vector) => Math.Max(vector.x, vector.y);
		public static float MinValue(this Vector2 vector) => Math.Min(vector.x, vector.y);

		public static int MaxValue(this Vector2Int vector) => Math.Max(vector.x, vector.y);
		public static int MinValue(this Vector2Int vector) => Math.Min(vector.x, vector.y);

		public static float Size(this Vector2 vector) => Math.Abs(vector.x * vector.y);
		public static int Size(this Vector2Int vector) => Math.Abs(vector.x * vector.y);

		public static Vector2Int IndividualNormalize(this Vector2 vector) => new Vector2Int(vector.x.Normalized(), vector.y.Normalized());
		public static Vector2Int IndividualNormalize(this Vector2Int vector) => new Vector2Int(vector.x.Normalized(), vector.y.Normalized());

		/// <summary>
		/// Gets the index of the largest element in this vector.
		/// </summary>
		public static int GetMaxIndex(this Vector2 vector) => vector.x > vector.y ? 0 : 1;

		/// <summary>
		/// Gets the index of the largest element in this vector.
		/// </summary>
		public static int GetMaxIndex(this Vector2Int vector) => vector.x > vector.y ? 0 : 1;

		/// <summary>
		/// Gets the index of the smallest element in this vector.
		/// </summary>
		public static int GetMinIndex(this Vector2 vector) => vector.x < vector.y ? 0 : 1;

		/// <summary>
		/// Gets the index of the smallest element in this vector.
		/// </summary>
		public static int GetMinIndex(this Vector2Int vector) => vector.x < vector.y ? 0 : 1;

		public static bool LessThan(this Vector2 vector, Vector2 otherVector) => vector.x < otherVector.x && vector.y < otherVector.y;
		public static bool GreaterThan(this Vector2 vector, Vector2 otherVector) => vector.x > otherVector.x && vector.y > otherVector.y;
		public static bool LessThanOrEquals(this Vector2 vector, Vector2 otherVector) => vector.x <= otherVector.x && vector.y <= otherVector.y;
		public static bool GreaterThanOrEquals(this Vector2 vector, Vector2 otherVector) => vector.x >= otherVector.x && vector.y >= otherVector.y;

		public static bool LessThan(this Vector2Int vector, Vector2Int otherVector) => vector.x < otherVector.x && vector.y < otherVector.y;
		public static bool GreaterThan(this Vector2Int vector, Vector2Int otherVector) => vector.x > otherVector.x && vector.y > otherVector.y;
		public static bool LessThanOrEquals(this Vector2Int vector, Vector2Int otherVector) => vector.x <= otherVector.x && vector.y <= otherVector.y;
		public static bool GreaterThanOrEquals(this Vector2Int vector, Vector2Int otherVector) => vector.x >= otherVector.x && vector.y >= otherVector.y;

		public static Vector3 Set(this Vector3 vector, int index, float value)
		{
			vector[index] = value;
			return vector;
		}

		public static Vector3Int Set(this Vector3Int vector, int index, int value)
		{
			vector[index] = value;
			return vector;
		}

		public static Vector2 EpsilonVector2 => Vector2.one * CodeHelper.Epsilon;

		public static Vector2 MaxVector2 => Vector2.one * float.MaxValue;
		public static Vector2 MinVector2 => Vector2.one * float.MinValue;

		/// <summary>
		/// Gets an IEnumerable which will yield all the positions of a circle located at (0,0,0) with a <paramref name="radius"/>.
		/// </summary>
		public static IEnumerable<Vector2Int> GetPointsFromCircle(float radius)
		{
			int radiusInt = Mathf.CeilToInt(radius - CodeHelper.Epsilon);
			float radiusSquared = radius * radius;

			for (int x = -radiusInt; x <= radiusInt; x++)
			{
				for (int y = -radiusInt; y <= radiusInt; y++)
				{
					if (x * x + y * y <= radiusSquared) yield return new Vector2Int(x, y);
				}
			}
		}

		static readonly Dictionary<int, IReadOnlyList<Vector2Int>> pointsFromCircleCache = new Dictionary<int, IReadOnlyList<Vector2Int>>();

		/// <summary>
		/// Gets all the points inside a circle whose origin is at (0,0).
		/// </summary>
		public static IReadOnlyList<Vector2Int> GetPointsFromCircle(int radius, bool cache = true)
		{
			if (pointsFromCircleCache.ContainsKey(radius)) return pointsFromCircleCache[radius]; //Get from cache

			List<Vector2Int> result = new List<Vector2Int>();
			int radiusSquared = radius * radius;

			for (int x = -radius; x <= radius; x++)
			{
				for (int y = -radius; y <= radius; y++)
				{
					if (x * x + y * y <= radiusSquared) result.Add(new Vector2Int(x, y));
				}
			}

			if (!cache) return result;

			var readonlyResult = Array.AsReadOnly(result.ToArray());
			pointsFromCircleCache.Add(radius, readonlyResult);

			return readonlyResult;
		}

		/// <summary>
		/// Returns an IEnumerable which will yield all the positives contained in a line whose two end points are <paramref name="position1"/> and <paramref name="position2"/>.
		/// (All position inclusive)
		/// </summary>
		public static IEnumerable<Vector2Int> GetPositionsFromLine(Vector2Int position1, Vector2Int position2)
		{
			int sampleCount = Mathf.RoundToInt(new MinMax((position1 - position2).Abs()).max);

			for (int i = 0; i <= sampleCount; i++)
			{
				yield return Vector2.Lerp(position1, position2, (float)i / sampleCount).RoundToInt();
			}
		}

		/// <summary>
		/// Returns an IEnumerable which will yield all the positions placed in a spiral order.
		/// Start direction: Right
		/// Will generate something like this (One layer):
		///
		///  567
		///  4 0
		///  321
		///
		/// </summary>
		/// <returns>The spiral positions.</returns>
		/// <param name="center">The center of the spiral.</param>
		/// <param name="layerCount">How many layers do you want the spiral to be?</param>
		public static IEnumerable<Vector2Int> GetSpiralPoints(Vector2Int center, int layerCount) => GetSpiralPoints(center, layerCount, Vector2Int.right);

		/// <inheritdoc cref="GetSpiralPoints(Vector2Int,int)"/>
		/// <param name="startDirection">The direction where the spiral will start.</param>
		public static IEnumerable<Vector2Int> GetSpiralPoints(Vector2Int center, int layerCount, Vector2Int startDirection)
		{
			int index = 0;

			for (int i = 0; i < 4; i++)
			{
				if (startDirection == neighbor4Positions[index]) goto outBreak;
				index++;
			}

			throw new ArgumentException(nameof(startDirection) + " is invalid!\nIt can only be a direction inside " + nameof(neighbor4Positions));

			outBreak:

			Vector2Int position = center;
			Vector2Int direction;

			for (int size = 1; size <= layerCount; size++)
			{
				direction = neighbor4Positions[index];
				position += direction;

				RotateDirection();

				for (int j = 0; j < size; j++)
				{
					yield return position;
					position += direction;
				}

				RotateDirection();

				for (int j = 0; j < 3; j++) //For the 3 other directions
				{
					for (int k = 0; k < size * 2; k++)
					{
						yield return position;
						position += direction;
					}

					RotateDirection();
				}

				for (int j = 0; j < size; j++)
				{
					yield return position;
					position += direction;
				}

				index = (index - 1).Repeat(4);
			}

			void RotateDirection() => direction = neighbor4Positions[(++index).Repeat(4)];
		}

		public static Vector2 Set(this Vector2 vector, int index, float value)
		{
			vector[index] = value;
			return vector;
		}

		public static Vector2Int Set(this Vector2Int vector, int index, int value)
		{
			vector[index] = value;
			return vector;
		}

		public static readonly IReadOnlyList<Vector2Int> neighbor4Positions = Array.AsReadOnly(new Vector2Int[] {Vector2Int.right, Vector2Int.down, Vector2Int.left, Vector2Int.up});
		public static readonly IReadOnlyList<Vector2Int> neighbor8Positions = Array.AsReadOnly(new Vector2Int[] {Vector2Int.right, new Vector2Int(1, -1), Vector2Int.down, new Vector2Int(-1, -1), Vector2Int.left, new Vector2Int(-1, 1), Vector2Int.up, new Vector2Int(1, 1)});
		public static readonly IReadOnlyList<Vector2Int> corner4Positions = Array.AsReadOnly(new Vector2Int[] {new Vector2Int(1, -1), new Vector2Int(-1, -1), new Vector2Int(-1, 1), new Vector2Int(1, 1)});
		public static readonly IReadOnlyList<Vector2Int> corner4Positions01 = Array.AsReadOnly(new Vector2Int[] {Vector2Int.zero, Vector2Int.right, Vector2Int.up, Vector2Int.one});

#endregion

#region Vector4 Helpers

		public static Vector4 Abs(this Vector4 vector) => Vector4.Max(vector, -vector);

		public static float MaxValue(this Vector4 vector) => Math.Max(Math.Max(vector.x, vector.y), Math.Max(vector.z, vector.w));
		public static float MinValue(this Vector4 vector) => Math.Min(Math.Min(vector.x, vector.y), Math.Min(vector.z, vector.w));

		public static float Size(this Vector4 vector) => Math.Abs(vector.x * vector.y * vector.z * vector.w);

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

		public static Vector4 Set(this Vector4 vector, int index, float value)
		{
			vector[index] = value;
			return vector;
		}

		public static Vector4 EpsilonVector4 => Vector4.one * CodeHelper.Epsilon;

		public static Vector4 MaxVector4 => Vector4.one * float.MaxValue;
		public static Vector4 MinVector4 => Vector4.one * float.MinValue;

#endregion

	}
}