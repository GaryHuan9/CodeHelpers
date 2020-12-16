using System;
using System.Collections.Generic;

namespace CodeHelpers.Mathematics
{
	public readonly struct DirectionStruct
	{
		public DirectionStruct(Int3 vector) => data = (byte)((GetSign(vector.z) << 4) | (GetSign(vector.y) << 2) | GetSign(vector.x));

		DirectionStruct(byte data) => this.data = data;

		/// <summary>
		/// Only 6 bits out of the 8 bits available from a byte is used.
		/// 00ZZ YYXX, each axis uses two bits to represent -1, 0, and 1
		/// 00 equals 0, 01 equals 1, and 11 equals -1
		/// </summary>
		readonly byte data;

		static int GetSign(int value)
		{
			if (value > 0) return 0b01;
			return value < 0 ? 0b11 : 0b00;
		}

		static int GetSign(float value)
		{
			if (Scalars.AlmostEquals(value, 0f)) return 0b00;
			return value < 0f ? 0b11 : 0b01;
		}
	}

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

		public static Direction ToDirection(this Int3 vector) => ToDirection((Float3)vector.XYZ);
		public static Direction ToDirection(this Int2 vector) => ToDirection(vector.XY_);

		public static Direction ToDirection(this Float3 vector)
		{
			if (vector == Float3.zero) throw ExceptionHelper.NotConvertible;

			int maxIndex = vector.Absoluted.MaxIndex;
			return (Direction)(maxIndex * 2 + (vector[maxIndex] < 0f ? 1 : 0));
		}

		public static Int3 ToVector3(this Direction direction)
		{
			int value = (int)direction;
			return Int3.Create(value / 2, RemapSign(value % 2));
		}

		public static Int2 ToVector2(this Direction direction)
		{
			switch (direction)
			{
				case Direction.right: return Int2.right;
				case Direction.left:  return Int2.left;
				case Direction.up:    return Int2.up;
				case Direction.down:  return Int2.down;

				case Direction.forward:
				case Direction.backward: throw ExceptionHelper.NotConvertible;
			}

			throw ExceptionHelper.NotPossible;
		}

		/// <summary>
		/// If this direction is in the y axis, convert it into a direction in the z axis
		/// </summary>
		public static Direction FromYToZ(this Direction direction) => direction == Direction.up || direction == Direction.down ? direction + 2 : direction;

		/// <summary>
		/// If this direction is in the z axis, convert it into a direction in the y axis
		/// </summary>
		public static Direction FromZToY(this Direction direction) => direction == Direction.forward || direction == Direction.backward ? direction - 2 : direction;

		/// <summary>
		/// Returns one of the component of <paramref name="vector"/> times direction.
		/// A faster way to calculate (direction.ToVector3() * vector).Magnitude
		/// </summary>
		public static int ExtractComponent(this Direction direction, Int3 vector)
		{
			int value = (int)direction;
			return vector[value / 2] * RemapSign(value % 2);
		}

		/// <inheritdoc cref="ExtractComponent(Direction,Int3)"/>
		public static float ExtractComponent(this Direction direction, Float3 vector)
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
		public static Direction Absoluted(this Direction direction) => (Direction)((int)direction / 2 * 2);

		/// <summary>
		/// Returns if the direction is a negative axis (left, down, or backward)
		/// </summary>
		public static bool IsNegative(this Direction direction) => (int)direction % 2 == 1;

		/// <summary>
		/// Gets a direction which is perpendicular to this <paramref name="direction"/>.
		/// The returned direction is the 2d right/positive x direction if you projected the direction onto 2d (using the <see cref="Project"/> method)
		/// </summary>
		public static Direction Perpendicular(this Direction direction) => (Direction)((int)direction - 2).Repeat((int)EnumHelper<Direction>.enumLength);

		/// <summary>
		/// Projects <paramref name="point"/> onto the plane located at origin and has this <paramref name="direction"/> as its normal.
		/// NOTE: this returns a vector2, because it project as an orthographic camera looking down at the plane and the point, where
		/// the normal is pointing at the camera.
		/// </summary>
		public static Float2 Project(this Direction direction, Float3 point)
		{
			switch (direction)
			{
				case Direction.right:    return new Float2(point.z, point.y);
				case Direction.left:     return new Float2(-point.z, point.y);
				case Direction.up:       return new Float2(point.x, point.z);
				case Direction.down:     return new Float2(-point.x, point.z);
				case Direction.forward:  return new Float2(point.y, point.x);
				case Direction.backward: return new Float2(-point.y, point.x);
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
			var crosses = new IReadOnlyList<Direction>[EnumHelper<Direction>.enumLength];

			for (int i = 0; i < crosses.Length; i++)
			{
				var temporaryCrosses = new Direction[EnumHelper<Direction>.enumLength];

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
		static Direction GetCross(Direction from, Direction to) => from.ToVector3().Cross(to.ToVector3()).ToDirection();

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