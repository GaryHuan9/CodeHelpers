using System;
using CodeHelpers.Packed;

namespace CodeHelpers.Mathematics
{
	/// <summary>
	/// A rotation struct that only exists in 90-degree increments.
	/// </summary>
	public readonly struct LimitedRotation : IEquatable<LimitedRotation>
	{
		public LimitedRotation(int x, int y, int z)
		{
			data = (byte)((Transform(x) << 0) | (Transform(y) << 2) | (Transform(z) << 4));
			static int Transform(int angle) => (angle + 45).ToUnsignedAngle() / 90;
		}

		internal LimitedRotation(byte data) => this.data = (byte)(data & 0b00111111); //Must mask out the unnecessary bits

		public LimitedRotation(float x, float y, float z) : this((int)x.ToUnsignedAngle(), (int)y.ToUnsignedAngle(), (int)z.ToUnsignedAngle()) { }

		public LimitedRotation(Int3 angles) : this(angles.X, angles.Y, angles.Z) { }
		public LimitedRotation(Float3 angles) : this(angles.X, angles.Y, angles.Z) { }

		public LimitedRotation(Direction direction, int angle) : this((Int3)direction * angle) { }
		public LimitedRotation(Direction direction, float angle) : this((Float3)direction * angle) { }

		public LimitedRotation(Versor rotation) : this(rotation.Angles) { }

		/// <summary>
		/// Bit representation: 0000 0000
		/// Only uses the first 6 bits
		/// X axis (roll) uses the first and second bits: 	0000 00XX
		/// Y axis (pitch) uses the third and fourth bits: 	0000 YY00
		/// Z axis (yaw) uses the fifth and sixth bits:  	00ZZ 0000
		///
		/// rotation applied in world space as ZXY
		/// </summary>
		internal readonly byte data;

		int RawX => (data & 0b00000011) >> 0;
		int RawY => (data & 0b00001100) >> 2;
		int RawZ => (data & 0b00110000) >> 4;

		public int X => RawX * 90;
		public int Y => RawY * 90;
		public int Z => RawZ * 90;

		public Int3 Angles => new Int3(X, Y, Z);

		public static readonly LimitedRotation identity = default;

		static readonly float[] sinValues = {0f, Scalars.Root2 / 2f, 1f, Scalars.Root2 / 2f};
		static readonly float[] cosValues = {1f, Scalars.Root2 / 2f, 0f, Scalars.Root2 / -2f};

		public Versor Versor
		{
			get
			{
				Int3 raw = new Int3(RawX, RawY, RawZ);

				return new Versor
				(
					new Float3(GetSin(raw.X), GetSin(raw.Y), GetSin(raw.Z)),
					new Float3(GetCos(raw.X), GetCos(raw.Y), GetCos(raw.Z))
				);

				static float GetSin(int raw) => sinValues[raw];
				static float GetCos(int raw) => cosValues[raw];
			}
		}

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
			if (from == -to)
			{
				//Returns a rotation with 180 degrees, making sure that the axis is not the same as our two directions
				return from.Y != 0 ? new LimitedRotation(0b000010) /*180, 0, 0*/ : new LimitedRotation(0b001000) /*0, 180, 0*/;
			}

			return new LimitedRotation((Int3)from.Cross(to) * 90);
		}

		public static bool operator ==(LimitedRotation first, LimitedRotation second) => first.Equals(second);
		public static bool operator !=(LimitedRotation first, LimitedRotation second) => !first.Equals(second);

		// NOTE: Cannot just add/subtract the two euler angles because gimbal lock might occur
		public static LimitedRotation operator *(LimitedRotation first, LimitedRotation second) => new LimitedRotation(first.Versor * second.Versor);
		public static LimitedRotation operator /(LimitedRotation first, LimitedRotation second) => new LimitedRotation(first.Versor / second.Versor);

		public static Float3 operator *(LimitedRotation rotation, Float3 value) => rotation.Versor * value;
		public static Float3 operator /(LimitedRotation rotation, Float3 value) => rotation.Versor / value;

		public static Int3 operator *(LimitedRotation rotation, Int3 value) => (rotation.Versor * value).Rounded;
		public static Int3 operator /(LimitedRotation rotation, Int3 value) => (rotation.Versor / value).Rounded;

		public static Direction operator *(LimitedRotation rotation, Direction direction) => (Direction)(rotation * (Int3)direction);
		public static Direction operator /(LimitedRotation rotation, Direction direction) => (Direction)(rotation / (Int3)direction);

		public static LimitedRotation operator -(LimitedRotation rotation) => rotation.Inverted;

		public bool Equals(LimitedRotation other) => Versor.Equals(other.Versor);
		public override bool Equals(object obj) => obj is LimitedRotation rotation && Equals(rotation);

		public override int GetHashCode() => data;

		public override string ToString() => $"{nameof(LimitedRotation)}: {nameof(X)}: {X}, {nameof(Y)}: {Y}, {nameof(Z)}: {Z}";
	}
}