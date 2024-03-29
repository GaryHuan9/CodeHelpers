﻿using System;
using System.IO;
using CodeHelpers.Mathematics;
using CodeHelpers.Packed;

namespace CodeHelpers.Files
{
	public class DataWriter : BinaryWriter
	{
		public DataWriter(Stream output) : base(output) { }

		public TypeMapper TypeMapper { get; set; }

		public void Write(BitVector8 value) => Write(value.Data);

		public void Write(Color32 value)
		{
			Write(value.r);
			Write(value.g);
			Write(value.b);
			Write(value.a);
		}

		public void Write(Color64 value)
		{
			Write(value.r);
			Write(value.g);
			Write(value.b);
			Write(value.a);
		}

		public void Write(Direction value) => Write(value.data);

		public void Write(Float2 value)
		{
			Write(value.X);
			Write(value.Y);
		}

		public void Write(in Float3 value)
		{
			Write(value.X);
			Write(value.Y);
			Write(value.Z);
		}

		public void Write(in Float4 value)
		{
			Write(value.X);
			Write(value.Y);
			Write(value.Z);
			Write(value.W);
		}

		public void Write(in Float4x4 value)
		{
			Write(value.f00);
			Write(value.f01);
			Write(value.f02);
			Write(value.f03);

			Write(value.f10);
			Write(value.f11);
			Write(value.f12);
			Write(value.f13);

			Write(value.f20);
			Write(value.f21);
			Write(value.f22);
			Write(value.f23);

			Write(value.f30);
			Write(value.f31);
			Write(value.f32);
			Write(value.f33);
		}

		public void Write(Int2 value)
		{
			Write(value.X);
			Write(value.Y);
		}

		public void Write(in Int3 value)
		{
			Write(value.X);
			Write(value.Y);
			Write(value.Z);
		}

		public void Write(in Int4 value)
		{
			Write(value.X);
			Write(value.Y);
			Write(value.Z);
			Write(value.W);
		}

		public void Write(LimitedRotation value) => Write(value.data);

		public void Write(MinMax value)
		{
			Write(value.min);
			Write(value.max);
		}

		public void Write(MinMaxInt value)
		{
			Write(value.min);
			Write(value.max);
		}

		public void Write(in Segment2 value)
		{
			Write(value.point0);
			Write(value.point1);
		}

		public void Write(in Segment3 value)
		{
			Write(value.point0);
			Write(value.point1);
		}

		public void Write(in Versor value) => Write(value.d);

		public void Write(in Guid value)
		{
#if CODE_HELPERS_UNSAFE
			unsafe
			{
				Guid copy = value;
				byte* pointer = (byte*)&copy;

				for (int i = 0; i < 16; i++) Write(pointer[i]);
			}
#else
			Write(value.ToByteArray());
#endif
		}

		public void WriteArray(byte[] array)
		{
			uint length = (uint)array.Length;

			WriteCompact(length);
			WriteArray(array, length);
		}

		public void WriteArray(byte[] array, uint length) => Write(array, 0, (int)length);

		/// <summary>
		/// Writes <paramref name="value"/> as a variable length quantity with the following rules:
		/// The first byte: 0bNVVV_VVVS (N: true if have next byte, V: actual value, S: sign)
		/// 2nd to 5th bytes: 0bNVVV_VVVV (N: true if have next byte, V: actual value)
		/// NOTE: Negative numbers are negated to their positive counterparts
		/// </summary>
		public void WriteCompact(int value)
		{
			ulong write;

			if (value < 0)
			{
				long longer = -(long)value << 1;
				write = (ulong)longer | 0b1ul;
			}
			else write = (ulong)value << 1;

			WriteCompact(write);
		}

		/// <summary>
		/// Writes <paramref name="value"/> as a variable length quantity
		/// with the most significant bit indicating for the next block
		/// </summary>
		public void WriteCompact(uint value)
		{
			const uint Mask = 0b0111_1111u;

			while (value > Mask)
			{
				Write((byte)(value | ~Mask));
				value >>= 7;
			}

			Write((byte)value);
		}

		/// <summary>
		/// Writes <paramref name="value"/> as a variable length quantity
		/// with the most significant bit indicating for the next block
		/// </summary>
		public void WriteCompact(ulong value)
		{
			const ulong Mask = 0b0111_1111ul;

			while (value > Mask)
			{
				Write((byte)(value | ~Mask));
				value >>= 7;
			}

			Write((byte)value);
		}

		public void WriteCompact(Int2 int2)
		{
			WriteCompact(int2.X);
			WriteCompact(int2.Y);
		}

		public void WriteCompact(in Int3 int3)
		{
			WriteCompact(int3.X);
			WriteCompact(int3.Y);
			WriteCompact(int3.Z);
		}

		public void WriteCompact(in Int4 int4)
		{
			WriteCompact(int4.X);
			WriteCompact(int4.Y);
			WriteCompact(int4.Z);
			WriteCompact(int4.W);
		}

		public void WriteCompact(MinMaxInt minMax)
		{
			WriteCompact(minMax.min);
			WriteCompact(minMax.max);
		}

		public void WriteTypeMapper(ITypeSerializer serializer)
		{
			if (TypeMapper != null) TypeMapper.Write(this, serializer);
			else throw ExceptionHelper.Invalid(nameof(TypeMapper), InvalidType.isNull);
		}

		/// <summary>
		/// Writes <paramref name="type"/> using the <see cref="TypeMapper"/>. This type could be read using <see cref="DataReader.ReadType"/>.
		/// Alternatively, this type will be implicitly read when you want to use a reader marked with <see cref="ReaderAttribute.ReadType"/>.
		/// </summary>
		public void Write(Type type)
		{
			if (TypeMapper != null) WriteCompact(TypeMapper[type]);
			else throw ExceptionHelper.Invalid(nameof(TypeMapper), InvalidType.isNull);
		}
	}
}