using System.IO;
using CodeHelpers.Mathematics;
using CodeHelpers.RotationHelpers;

namespace CodeHelpers.Files
{
	public class FileWriter : BinaryWriter
	{
		public FileWriter(string filePath) : base(File.Open(filePath, FileMode.Create)) => this.filePath = filePath;

		readonly string filePath;

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

		public void Write(Float3 float3)
		{
			Write(float3.x);
			Write(float3.y);
			Write(float3.z);
		}

		public void Write(Float4 float4)
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

		public void Write(Int3 int3)
		{
			Write(int3.x);
			Write(int3.y);
			Write(int3.z);
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
			Write7BitEncodedInt(minMax.Range);
		}

		public void Write(Segment2 segment2)
		{
			Write(segment2.point1);
			Write(segment2.point2);
		}

		public void Write(Segment3 segment3)
		{
			Write(segment3.point1);
			Write(segment3.point2);
		}
	}
}