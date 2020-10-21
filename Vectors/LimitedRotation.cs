using System;
using CodeHelpers.Vectors;

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
			int Transform(int angle) => (angle + 45).ToUnsignedAngle() / 90;
		}

		LimitedRotation(byte data) => this.data = (byte)(data & 0b00111111); //Must mask out the unnecessary bits

		public LimitedRotation(float x, float y, float z) : this((int)x.ToUnsignedAngle(), (int)y.ToUnsignedAngle(), (int)z.ToUnsignedAngle()) { }

		public LimitedRotation(Int3 eulerAngles) : this(eulerAngles.x, eulerAngles.y, eulerAngles.z) { }
		public LimitedRotation(Float3 eulerAngles) : this(eulerAngles.x, eulerAngles.y, eulerAngles.z) { }

#if CODEHELPERS_UNITY
		public LimitedRotation(UnityEngine.Quaternion quaternion) : this(quaternion.eulerAngles) { }

		public LimitedRotation(Direction direction, int angle) : this(direction.ToVector3() * angle) { }
		public LimitedRotation(Direction direction, float angle) : this(direction.ToVector3().ToFloat() * angle) { }
#endif

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

		public Int3 EulerAngles => new Int3(X, Y, Z);

#if CODEHELPERS_UNITY
		public UnityEngine.Quaternion Quaternion => UnityEngine.Quaternion.Euler(X, Y, Z);
#endif

		/// <summary>
		/// Returns the inverse of this rotation
		/// </summary>
		public LimitedRotation Inverted
		{
			get
			{
				const int RightMask = 0b00010101; //Mask to extract the 0X0X0X bits
				const int LeftMask = 0b00101010;  //Mask to extract the X0X0X0 bits

				//All bit configurations (to needed bits for inverting):
				// 00 => 00
				// 01 => 11
				// 10 => 10
				// 11 => 01

				int rightBits = data & RightMask; //The rights bits stay same after inverting
				int leftBits = data & LeftMask;   //Some left bits need to be flipped to invert

				leftBits ^= rightBits << 1; //The XOR result of the left and right bits is the result of the left bits

				return new LimitedRotation((byte)((leftBits & LeftMask) | (rightBits & RightMask)));
			}
		}

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
				return from == Direction.up || from == Direction.down ? new LimitedRotation(0b000010) /*180, 0, 0*/ : new LimitedRotation(0b001000) /*0, 180, 0*/;
			}

			return new LimitedRotation(from.Cross(to).ToVector3() * 90);
		}

		public static LimitedRotation Identity => new LimitedRotation();

		public static bool operator ==(LimitedRotation first, LimitedRotation second) => first.Equals(second);
		public static bool operator !=(LimitedRotation first, LimitedRotation second) => !first.Equals(second);

#if CODEHELPERS_UNITY
		// NOTE: Cannot just add/subtract the two euler angles because gimbal lock might occur
		public static LimitedRotation operator *(LimitedRotation first, LimitedRotation second) => new LimitedRotation(second.Quaternion * first.Quaternion);
		public static LimitedRotation operator /(LimitedRotation first, LimitedRotation second) => new LimitedRotation(second.Quaternion * first.Inverted.Quaternion);

		public static UnityEngine.Vector3 operator *(LimitedRotation rotation, UnityEngine.Vector3 vector) => rotation.Quaternion * vector;
		public static UnityEngine.Vector3Int operator *(LimitedRotation rotation, UnityEngine.Vector3Int vector) => (rotation * vector.ToFloat()).RoundToInt();
		public static Direction operator *(LimitedRotation rotation, Direction direction) => ((Float3)(rotation * (UnityEngine.Vector3)direction.ToVector3().U())).ToDirection();
#endif

		public static LimitedRotation operator -(LimitedRotation rotation) => rotation.Inverted;

		public bool Equals(LimitedRotation other) => data.Equals(other.data);
		public override bool Equals(object obj) => obj is LimitedRotation rotation && Equals(rotation);

		public int CompareTo(LimitedRotation other) => data.CompareTo(other.data);
		public override int GetHashCode() => data;

		public override string ToString() => $"{nameof(LimitedRotation)}: {nameof(X)}: {X}, {nameof(Y)}: {Y}, {nameof(Z)}: {Z}";
	}
}