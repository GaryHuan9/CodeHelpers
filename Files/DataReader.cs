using System;
using System.Collections.Generic;
using System.IO;
using CodeHelpers.Diagnostics;
using CodeHelpers.Mathematics;
using CodeHelpers.RotationHelpers;

namespace CodeHelpers.Files
{
	public class DataReader : BinaryReader
	{
		public DataReader(Stream output) : base(output) { }

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

		public void CreateVersionedReaders(int version, CompiledReaders compiledReaders) => versionedReaders = new VersionedReaders(version, this, compiledReaders);
		public void ClearVersionedReaders() => versionedReaders = null;

		public T Read<T>()
		{
			if (versionedReaders != null) return versionedReaders.Read<T>();
			throw ExceptionHelper.Invalid(nameof(versionedReaders), InvalidType.isNull);
		}

		public BitVector8 ReadBitVector8() => new BitVector8(ReadByte());

		public Color32 ReadColor32()
		{
			int data = ReadInt32();
			return new Color32
			(
				(byte)(data >> 0),
				(byte)(data >> 8),
				(byte)(data >> 16),
				(byte)(data >> 24)
			);
		}

		public Color64 ReadColor64()
		{
			long data = ReadInt64();
			return new Color64
			(
				(ushort)(data >> 0),
				(ushort)(data >> 16),
				(ushort)(data >> 32),
				(ushort)(data >> 48)
			);
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
	}
}