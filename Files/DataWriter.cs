using System;
using System.IO;
using CodeHelpers.Mathematics;
using CodeHelpers.RotationHelpers;

namespace CodeHelpers.Files
{
	public class DataWriter : BinaryWriter
	{
		public DataWriter(Stream output) : base(output) { }

		public TypeMapper TypeMapper { get; set; }

		public void Write(BitVector8 bitVector8) => Write(bitVector8.Data);

		public void Write(Color32 color32)
		{
			Write(color32.r);
			Write(color32.g);
			Write(color32.b);
			Write(color32.a);
		}

		public void Write(Color64 color64)
		{
			Write(color64.r);
			Write(color64.g);
			Write(color64.b);
			Write(color64.a);
		}

		public void Write(Float2 float2)
		{
			Write(float2.x);
			Write(float2.y);
		}

		public void Write(in Float3 float3)
		{
			Write(float3.x);
			Write(float3.y);
			Write(float3.z);
		}

		public void Write(in Float4 float4)
		{
			Write(float4.x);
			Write(float4.y);
			Write(float4.z);
			Write(float4.w);
		}

		public void Write(in Float4x4 float4x4)
		{
			Write(float4x4.f00);
			Write(float4x4.f01);
			Write(float4x4.f02);
			Write(float4x4.f03);

			Write(float4x4.f10);
			Write(float4x4.f11);
			Write(float4x4.f12);
			Write(float4x4.f13);

			Write(float4x4.f20);
			Write(float4x4.f21);
			Write(float4x4.f22);
			Write(float4x4.f23);

			Write(float4x4.f30);
			Write(float4x4.f31);
			Write(float4x4.f32);
			Write(float4x4.f33);
		}

		public void Write(Int2 int2)
		{
			Write(int2.x);
			Write(int2.y);
		}

		public void Write(in Int3 int3)
		{
			Write(int3.x);
			Write(int3.y);
			Write(int3.z);
		}

		public void Write(in Int4 int4)
		{
			Write(int4.x);
			Write(int4.y);
			Write(int4.z);
			Write(int4.w);
		}

		public void Write(LimitedRotation limitedRotation) => Write(limitedRotation.data);

		public void Write(MinMax minMax)
		{
			Write(minMax.min);
			Write(minMax.max);
		}

		public void Write(MinMaxInt minMax)
		{
			Write(minMax.min);
			Write(minMax.max);
		}

		public void Write(in Segment2 segment2)
		{
			Write(segment2.point0);
			Write(segment2.point1);
		}

		public void Write(in Segment3 segment3)
		{
			Write(segment3.point0);
			Write(segment3.point1);
		}

		public void Write(in Guid guid)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				Guid copy = guid;
				byte* pointer = (byte*)&copy;

				for (int i = 0; i < 16; i++) Write(pointer[i]);
			}
#else
			Write(guid.ToByteArray());
#endif
		}

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
			WriteCompact(int2.x);
			WriteCompact(int2.y);
		}

		public void WriteCompact(in Int3 int3)
		{
			WriteCompact(int3.x);
			WriteCompact(int3.y);
			WriteCompact(int3.z);
		}

		public void WriteCompact(in Int4 int4)
		{
			WriteCompact(int4.x);
			WriteCompact(int4.y);
			WriteCompact(int4.z);
			WriteCompact(int4.w);
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