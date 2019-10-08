using System;

namespace CodeHelpers.VectorHelpers
{
	/// <summary>
	/// A class that is similar to BitVector32 but with bytes and 8 available bool values
	/// Has slightly different methods than BitVector32
	/// </summary>
	[Serializable]
	public struct BitVector8 : IComparable<BitVector8>, IEquatable<BitVector8>
	{
		public BitVector8(byte data)
		{
			Data = data;
		}

		public byte Data { get; private set; }

		public const int Length = 8;

		/// <summary>
		/// Access and modify only ONE bit of the data.
		/// Access: If the bit is true, else false
		/// Modify: Change the bit to value
		/// </summary>
		public bool this[int bitAt]
		{
			get => GetAllBits(1 << bitAt);
			set => SetAllBits(1 << bitAt, value);
		}

		/// <summary>
		/// Gets if all the <paramref name="bits"/> in this data is true
		/// </summary>
		public bool GetAllBits(int bits) => (Data & bits) == bits;

		/// <summary>
		/// Sets the value of all the <paramref name="bits"/> in this data to <paramref name="value"/>
		/// </summary>
		public void SetAllBits(int bits, bool value)
		{
			if (value) Data |= (byte)bits;
			else Data &= (byte)~bits;
		}

		/// <summary>
		/// Shift all bits a certain <paramref name="amount"/>
		/// </summary>
		public void Shift(int amount)
		{
			Data = (byte)((uint)Data << amount | (uint)Data >> (Length - amount));
		}

		/// <summary>
		/// For every bit in this data, if the input <paramref name="bits"/> is 1, then we add the bit to our result's end.
		/// If input is 0, then we ignore it.
		/// </summary>
		//public byte Extract(byte bits)
		//{
		//	return (byte)(bits & Data);
		//}

		public int CompareTo(BitVector8 other) => Data.CompareTo(other.Data);
		public override int GetHashCode() => Data.GetHashCode();

		public override bool Equals(object obj) => obj is BitVector8 other && Equals(other);
		public bool Equals(BitVector8 other) => Data == other.Data;

		public override string ToString() => $"{nameof(BitVector8)}: {Convert.ToString(Data, 2).PadLeft(Length, '0')}";
	}
}