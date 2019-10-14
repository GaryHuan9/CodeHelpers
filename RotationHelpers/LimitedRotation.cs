using System;
using CodeHelpers.DebugHelpers;
using CodeHelpers.VectorHelpers;
using UnityEngine;

namespace CodeHelpers.RotationHelpers
{
	/// <summary>
	/// A rotation struct that only exists in 90-degree increments.
	/// </summary>
	[Serializable]
	public readonly struct LimitedRotation : IEquatable<LimitedRotation>, IComparable<LimitedRotation> //Immutable
	{
		//NOTE: We maybe should remove some of the implementation using unity's quaternion

		public LimitedRotation(int x, int y, int z)
		{
			data = (byte)((Transform(x) << 0) | (Transform(y) << 2) | (Transform(z) << 4));

			int Transform(int angle)
			{
				angle = (angle + 45).ToUnsignedAngle();
				return angle / 90;
			}
		}

		LimitedRotation(byte data) => this.data = data;

		public LimitedRotation(float x, float y, float z) : this((int)x.ToUnsignedAngle(), (int)y.ToUnsignedAngle(), (int)z.ToUnsignedAngle()) { }

		public LimitedRotation(Vector3Int eulerAngles) : this(eulerAngles.x, eulerAngles.y, eulerAngles.z) { }
		public LimitedRotation(Vector3 eulerAngles) : this(eulerAngles.x, eulerAngles.y, eulerAngles.z) { }

		public LimitedRotation(Quaternion quaternion) : this(quaternion.eulerAngles) { }

		public LimitedRotation(Direction direction, int angle) : this(direction.ToVector3() * angle) { }
		public LimitedRotation(Direction direction, float angle) : this(direction.ToVector3().ToFloat() * angle) { }

		/// <summary>
		/// Bit representation: 0000 0000
		/// Only uses the first 6 bits
		/// X axis (roll) uses the first and second bits: 	0000 00XX
		/// Y axis (pitch) uses the third and fourth bits: 	0000 YY00
		/// Y axis (yaw) uses the fifth and sixth bits:  	00ZZ 0000
		///
		/// rotation applied in world space as ZXY
		/// </summary>
		readonly byte data;

		public int X => ((data & 0b00000011) >> 0) * 90;
		public int Y => ((data & 0b00001100) >> 2) * 90;
		public int Z => ((data & 0b00110000) >> 4) * 90;

		public Vector3Int EulerAngles => new Vector3Int(X, Y, Z);
		public Quaternion Quaternion => Quaternion.Euler(X, Y, Z);

		/// <summary>
		/// Returns the inverse of this rotation
		/// </summary>
		public LimitedRotation Inverted => new LimitedRotation(EulerAngles * -1);

		/// <summary>
		/// Gets the rotation needed to go from the first input to the second one.
		/// </summary>
		public static LimitedRotation GetRotationBetween(Direction from, Direction to)
		{
			//These two to avoid exceptions from the cross method
			if (from == to) return new LimitedRotation(); //No rotation
			if (from.Opposite() == to)
			{
				//Returns a rotation with 180 degrees
				return from == Direction.up || from == Direction.down ? new LimitedRotation(180, 0, 0) : new LimitedRotation(0, 180, 0);
			}

			return new LimitedRotation(from.Cross(to).ToVector3() * 90);
		}

		public static LimitedRotation Identity => new LimitedRotation();

		public static bool operator ==(LimitedRotation first, LimitedRotation second) => first.Equals(second);
		public static bool operator !=(LimitedRotation first, LimitedRotation second) => !first.Equals(second);

		// NOTE: Cannot just add/subtract the two euler angles because gimbal lock might occur
		public static LimitedRotation operator *(LimitedRotation first, LimitedRotation second) => new LimitedRotation(second.Quaternion * first.Quaternion);
		public static LimitedRotation operator /(LimitedRotation first, LimitedRotation second) => new LimitedRotation(second.Quaternion * first.Inverted.Quaternion);

		public static Vector3 operator *(LimitedRotation rotation, Vector3 vector) => rotation.Quaternion * vector;
		public static Direction operator *(LimitedRotation rotation, Direction direction) => (rotation * direction.ToVector3()).ToDirection();

		public bool Equals(LimitedRotation other) => data.Equals(other.data);
		public override bool Equals(object obj) => obj is LimitedRotation rotation && Equals(rotation);

		public int CompareTo(LimitedRotation other) => data.CompareTo(other.data);
		public override int GetHashCode() => data;

		public override string ToString() => $"{nameof(LimitedRotation)}: {nameof(X)}: {X}, {nameof(Y)}: {Y}, {nameof(Z)}: {Z}";
	}
}