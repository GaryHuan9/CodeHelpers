using System;

namespace CodeHelpers.Mathematics
{
	/// <summary>
	/// A class that is similar to BitVector32 but with bytes and 8 available bool values
	/// Has slightly different methods than BitVector32
	/// </summary>
	[Serializable]
	public struct BitVector8 : IComparable<BitVector8>, IEquatable<BitVector8>
	{
		public BitVector8(byte data) => Data = data;

		public byte Data { get; private set; }

		public const int Length = 8;

		public bool this[int bits]
		{
			get => (Data & bits) == bits;
			set
			{
				if (value) Data |= (byte)bits;
				else Data &= (byte)~bits;
			}
		}

		/// <summary>
		/// Rotate all bits by a certain <paramref name="amount"/>
		/// </summary>
		public void Rotate(int amount)
		{
			uint data = Data;
			Data = (byte)((data << amount) | (data >> (Length - amount)));
		}

		public int CompareTo(BitVector8 other) => Data.CompareTo(other.Data);

		public override int GetHashCode() => Data.GetHashCode();

		public static bool operator ==(BitVector8 value, BitVector8 other) => value.Equals(other);
		public static bool operator !=(BitVector8 value, BitVector8 other) => !value.Equals(other);

		public override bool Equals(object obj) => obj is BitVector8 other && Equals(other);
		public bool Equals(BitVector8 other) => Data == other.Data;

		public override string ToString() => $"{nameof(BitVector8)}: {Convert.ToString(Data, 2).PadLeft(Length, '0')}";
	}
}