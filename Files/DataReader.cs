using System;
using System.Collections.Generic;
using System.IO;
using CodeHelpers.Mathematics;
using CodeHelpers.RotationHelpers;

namespace CodeHelpers.Files
{
	public class DataReader : BinaryReader
	{
		public DataReader(Stream input) : base(input) { }

		VersionedReaders versionedReaders;
		Stack<object> contexts;

		/// <summary>
		/// Assigns or retrieves the context of the current read operation. This property is implemented using a
		/// stack that dynamically grows and shrinks. The idea is that the parent read operation should control
		/// the context of the children read operations. After the children are finished, the parent should assign
		/// the context to null which will pop the stack and revert it back to the state for the parent.
		/// </summary>
		public object Context
		{
			set
			{
				if (value == null)
				{
					if (contexts != null && contexts.Count > 0) contexts.Pop();
					else throw new Exception($"Cannot remove {nameof(Context)} when the stack is empty!");
				}
				else
				{
					contexts ??= new Stack<object>();
					contexts.Push(value);
				}
			}
			get
			{
				if (contexts != null && contexts.Count > 0) return contexts.Peek();
				throw new Exception($"Attempting to retrieve {nameof(Context)} before assigning any!");
			}
		}

		public int Version => versionedReaders?.version ?? 0;

		public void CreateVersionedReaders(int version, CompiledReaders compiledReaders)
		{
			versionedReaders = new VersionedReaders(this, version, compiledReaders);
		}

		public void ClearVersionedReaders() => versionedReaders = null;

		/// <summary>
		/// Reads information to create an object of type <typeparamref name="T"/> through
		/// <see cref="versionedReaders"/> created from <see cref="CreateVersionedReaders"/>.
		/// </summary>
		public T Read<T>()
		{
			if (versionedReaders != null) return versionedReaders.Read<T>();
			throw ExceptionHelper.Invalid(nameof(versionedReaders), InvalidType.isNull);
		}

		/// <summary>
		/// Reads information directly into instanced object <paramref name="value"/> through
		/// <see cref="versionedReaders"/> created from <see cref="CreateVersionedReaders"/>.
		/// </summary>
		public void Read<T>(T value)
		{
			if (versionedReaders != null) versionedReaders.Read(value);
			else throw ExceptionHelper.Invalid(nameof(versionedReaders), InvalidType.isNull);
		}

		public BitVector8 ReadBitVector8() => new BitVector8(ReadByte());

		public Color32 ReadColor32()
		{
			byte r = ReadByte();
			byte g = ReadByte();
			byte b = ReadByte();
			byte a = ReadByte();

			return new Color32(r, g, b, a);
		}

		public Color64 ReadColor64()
		{
			ushort r = ReadUInt16();
			ushort g = ReadUInt16();
			ushort b = ReadUInt16();
			ushort a = ReadUInt16();

			return new Color64(r, g, b, a);
		}

		public Float2 ReadFloat2() => new Float2(ReadSingle(), ReadSingle());
		public Float3 ReadFloat3() => new Float3(ReadSingle(), ReadSingle(), ReadSingle());
		public Float4 ReadFloat4() => new Float4(ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle());

		public Float4x4 ReadFloat4x4() => new Float4x4
		(
			ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle(),
			ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle(),
			ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle(),
			ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle()
		);

		public Int2 ReadInt2() => new Int2(ReadInt32(), ReadInt32());
		public Int3 ReadInt3() => new Int3(ReadInt32(), ReadInt32(), ReadInt32());

		public LimitedRotation ReadLimitedRotation() => new LimitedRotation(ReadByte());

		public MinMax ReadMinMax() => new MinMax(ReadSingle(), ReadSingle());

		public MinMaxInt ReadMinMaxInt()
		{
			int min = ReadInt32();
			int max = ReadInt32();

			return new MinMaxInt(min, max);
		}

		public Segment2 ReadSegment2() => new Segment2(ReadFloat2(), ReadFloat2());
		public Segment3 ReadSegment3() => new Segment3(ReadFloat3(), ReadFloat3());

		/// <summary>
		/// Reads in a compact Int32 encoded with <see cref="DataWriter.WriteCompact(int)"/>
		/// </summary>
		public int ReadInt32Compact()
		{
			ulong value = ReadUInt64Compact();
			bool negative = (value & 0b1) == 1;

			value >>= 1;

			return negative ? (int)-(long)value : (int)value;
		}

		/// <summary>
		/// Reads in a compact UInt32 encoded with <see cref="DataWriter.WriteCompact(uint)"/>
		/// </summary>
		public uint ReadUInt32Compact()
		{
			uint value = 0u;

			const byte Mask = 0b0111_1111;

			for (int i = 0;; i += 7)
			{
				byte part = ReadByte();

				value |= (uint)(part & Mask) << i;
				if ((part & ~Mask) == 0) break;
			}

			return value;
		}

		/// <summary>
		/// Reads in a compact UInt64 encoded with <see cref="DataWriter.WriteCompact(ulong)"/>
		/// </summary>
		public ulong ReadUInt64Compact()
		{
			ulong value = 0u;

			const byte Mask = 0b0111_1111;

			for (int i = 0;; i += 7)
			{
				byte part = ReadByte();

				value |= (ulong)(part & Mask) << i;
				if ((part & ~Mask) == 0) break;
			}

			return value;
		}

		public Int2 ReadInt2Compact() => new Int2(ReadInt32Compact(), ReadInt32Compact());
		public Int3 ReadInt3Compact() => new Int3(ReadInt32Compact(), ReadInt32Compact(), ReadInt32Compact());

		public MinMaxInt ReadMinMaxIntCompact()
		{
			int min = ReadInt32Compact();
			int max = ReadInt32Compact();

			return new MinMaxInt(min, max);
		}
	}
}