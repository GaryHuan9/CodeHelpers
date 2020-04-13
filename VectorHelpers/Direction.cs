using System;
using System.Collections.Generic;
using CodeHelpers.DebugHelpers;
using UnityEngine;

namespace CodeHelpers.VectorHelpers
{
	public enum Direction : byte //DO NOT CHANGE THE VALUE OF THESE ENUMS
	{
		right = 0,
		left = 1,
		up = 2,
		down = 3,
		forward = 4,
		backward = 5
	}

	public static class DirectionExtensions
	{
		static DirectionExtensions() => RefreshCrossCache();

		/// <summary>
		/// Remaps the sign of Direction (0 or 1) to 1 or -1
		/// </summary>
		static int RemapSign(int sign) => sign * -2 + 1;

		public static Direction ToDirection(this Vector3Int vector) => ToDirection(vector.ToFloat());
		public static Direction ToDirection(this Vector2Int vector) => ToDirection(vector.ToFloat());

		public static Direction ToDirection(this Vector3 vector)
		{
			if (vector == Vector3.zero) throw ExceptionHelper.NotConvertible;

			int maxIndex = vector.Abs().GetMaxIndex();
			return (Direction)(maxIndex * 2 + (vector[maxIndex] < 0f ? 1 : 0));
		}

		public static Vector3Int ToVector3(this Direction direction)
		{
			int value = (int)direction;
			return new Vector3Int {[value / 2] = RemapSign(value % 2)};
		}

		public static Vector2Int ToVector2(this Direction direction)
		{
			switch (direction)
			{
				case Direction.right: return Vector2Int.right;
				case Direction.left:  return Vector2Int.left;
				case Direction.up:    return Vector2Int.up;
				case Direction.down:  return Vector2Int.down;

				case Direction.forward:
				case Direction.backward: throw ExceptionHelper.NotConvertible;
			}

			throw ExceptionHelper.NotPossible;
		}

		/// <summary>
		/// Returns one of the component of <paramref name="vector"/> times direction.
		/// A faster way to calculate Vector3Int.Scale(direction.ToVector3(), vector).magnitude
		/// </summary>
		public static int ExtractComponent(this Direction direction, Vector3Int vector)
		{
			int value = (int)direction;
			return vector[value / 2] * RemapSign(value % 2);
		}

		/// <inheritdoc cref="ExtractComponent(CodeHelpers.VectorHelpers.Direction,UnityEngine.Vector3Int)"/>
		public static float ExtractComponent(this Direction direction, Vector3 vector)
		{
			int value = (int)direction;
			return vector[value / 2] * RemapSign(value % 2);
		}

		/// <summary>
		/// Gets the string version of <paramref name="direction"/>.
		/// <paramref name="useXYZ"/> if you want strings like "x" "y" or "z" instead of the default ones.
		/// </summary>
		public static string ToString(this Direction direction, bool useXYZ)
		{
			if (!useXYZ) return direction.ToString();

			switch (direction)
			{
				case Direction.right:    return "x";
				case Direction.left:     return "-x";
				case Direction.up:       return "y";
				case Direction.down:     return "-y";
				case Direction.forward:  return "z";
				case Direction.backward: return "-z";
			}

			throw ExceptionHelper.NotPossible;
		}

		/// <summary>
		/// Gets the opposite of this <paramref name="direction"/>
		/// </summary>
		public static Direction Opposite(this Direction direction)
		{
			int value = (int)direction;
			return (Direction)(value / 2 * 2 + (1 - value % 2));
		}

		/// <summary>
		/// Returns this <paramref name="direction"/> but it points in the positive direction
		/// </summary>
		public static Direction Abs(this Direction direction) => (Direction)((int)direction / 2 * 2);

		/// <summary>
		/// Returns if the direction is a negative axis (left, down, or backward)
		/// </summary>
		public static bool IsNegative(this Direction direction) => (int)direction % 2 == 1;

		/// <summary>
		/// Gets a direction which is perpendicular to this <paramref name="direction"/>.
		/// The returned direction is the 2d right/positive x direction if you projected the direction onto 2d (using the <see cref="Project"/> method)
		/// </summary>
		public static Direction Perpendicular(this Direction direction) => (Direction)((int)direction - 2).Repeat((int)EnumHelper<Direction>.EnumLength);

		/// <summary>
		/// Projects <paramref name="point"/> onto the plane located at origin and has this <paramref name="direction"/> as its normal.
		/// NOTE: this returns a vector2, because it project as an orthographic camera looking down at the plane and the point, where
		/// the normal is pointing at the camera.
		/// </summary>
		public static Vector2 Project(this Direction direction, Vector3 point)
		{
			switch (direction)
			{
				case Direction.right:    return new Vector2(point.z, point.y);
				case Direction.left:     return new Vector2(-point.z, point.y);
				case Direction.up:       return new Vector2(point.x, point.z);
				case Direction.down:     return new Vector2(-point.x, point.z);
				case Direction.forward:  return new Vector2(point.y, point.x);
				case Direction.backward: return new Vector2(-point.y, point.x);
			}

			throw ExceptionHelper.NotPossible;
		}

#region Cross

		static bool _cacheCross = true;

		public static bool CacheCross
		{
			get => _cacheCross;
			set
			{
				if (CacheCross == value) return;

				_cacheCross = value;
				RefreshCrossCache();
			}
		}

		static IReadOnlyList<IReadOnlyList<Direction>> crossCache;

		static void RefreshCrossCache()
		{
			if (CacheCross) GenerateCrossCache();
			else RemoveCrossCache();
		}

		static void GenerateCrossCache()
		{
			var crosses = new IReadOnlyList<Direction>[EnumHelper<Direction>.EnumLength];

			for (int i = 0; i < crosses.Length; i++)
			{
				var temporaryCrosses = new Direction[EnumHelper<Direction>.EnumLength];

				for (int j = 0; j < temporaryCrosses.Length; j++)
				{
					if (i != j && ((Direction)i).Opposite() != (Direction)j) //If the cross is available
					{
						temporaryCrosses[j] = GetCross((Direction)i, (Direction)j);
					}
				}

				crosses[i] = Array.AsReadOnly(temporaryCrosses); //NOTE: This only creats a wrapper! It still keeps the reference to the array, but NOT a deep copy of the array!
			}

			crossCache = Array.AsReadOnly(crosses);
		}

		static void RemoveCrossCache()
		{
			crossCache = null;
		}

		//Why write your own when you can use the library?
		static Direction GetCross(Direction from, Direction to) => Vector3.Cross(from.ToVector3(), to.ToVector3()).ToDirection();

		/// <summary>
		/// Gets the cross value of <paramref name="from"/> and <paramref name="to"/>.
		/// </summary>
		public static Direction Cross(this Direction from, Direction to)
		{
			if (from == to || from.Opposite() == to) throw new Exception($"Cross from {from} to {to} unavailable!");
			return CacheCross ? crossCache[(int)from][(int)to] : GetCross(from, to);
		}

#endregion

	}
}