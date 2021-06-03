#if CODEHELPERS_UNITY

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using CodeHelpers.Files;

namespace CodeHelpers.Unity.ProjectAnalysis
{
	public class ProjectHistory : IReadOnlyList<ProjectHistory.RecordInfo>
	{
		/// <summary>
		/// Creates a history by reading from the reader
		/// NOTE: Legacy/Obsolete
		/// </summary>
		public ProjectHistory(BinaryReader reader)
		{
			reader.ReadInt64(); //Read out the last recorded time

			int count = reader.ReadInt32();
			infoHistory = new List<RecordInfo>(count);

			for (int i = 0; i < count; i++) infoHistory.Add(new RecordInfo(reader));
		}

		/// <summary>
		/// Creates a <see cref="ProjectHistory"/> by reading from <paramref name="reader"/>.
		/// NOTE: This assumes the new version of the file.
		/// </summary>
		public ProjectHistory(DataReader reader)
		{
			reader.ReadInt64(); //Read out the last recorded time

			int version = reader.ReadInt32Compact();
			int count = reader.ReadInt32Compact();

			var mapper = new SourceNameMapper(reader);
			infoHistory = new List<RecordInfo>(count);

			for (int i = 0; i < count; i++) infoHistory.Add(new RecordInfo(reader, mapper));
		}

		public ProjectHistory() => infoHistory = new List<RecordInfo>();

		readonly List<RecordInfo> infoHistory; //Ordered by time

		public DateTime LastRecordTime => Count == 0 ? new DateTime() : this[Count - 1].RecordTime;

		public RecordInfo this[int index] => infoHistory[index];
		public int Count => infoHistory.Count;

		public void AddInfo(RecordInfo info)
		{
			if (info.RecordTime <= LastRecordTime) throw new Exception($"Cannot add {nameof(info)}({info})! Its recorded time is before history's last record time");
			infoHistory.Add(info);
		}

		public void RemoveAt(int index) => infoHistory.RemoveAt(index);
		public void Clear() => infoHistory.Clear();

		public void Write(DataWriter writer)
		{
			writer.Write(LastRecordTime.Ticks);
			writer.WriteCompact(0); //Write version

			int count = infoHistory.Count;
			writer.WriteCompact(count);

			//Grab all script names and create their respected tokens
			var mapper = new SourceNameMapper();

			for (int i = 0; i < count; i++) infoHistory[i].MarkTokens(mapper);

			mapper.Seal();
			mapper.Write(writer);

			//Actually write the records
			for (int i = 0; i < count; i++) infoHistory[i].Write(writer, mapper);
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		IEnumerator<RecordInfo> IEnumerable<RecordInfo>.GetEnumerator() => GetEnumerator();

		public List<RecordInfo>.Enumerator GetEnumerator() => infoHistory.GetEnumerator();

		public class SourceNameMapper : ISealable
		{
			public SourceNameMapper(DataReader reader)
			{
				int count = reader.ReadInt32Compact();

				names = new List<string>(count);
				tokens = new Dictionary<string, uint>(count);

				for (uint i = 0; i < count; i++)
				{
					string name = reader.ReadString();

					names.Add(name);
					tokens.Add(name, i);
				}

				Seal();
			}

			public SourceNameMapper()
			{
				names = new List<string>();
				tokens = new Dictionary<string, uint>();
			}

			readonly List<string> names;
			readonly Dictionary<string, uint> tokens;

			public bool IsSealed { get; private set; }

			public uint this[string name]
			{
				get
				{
					if (tokens.TryGetValue(name, out uint token)) return token;

					this.AssertNotSealed();

					token = (uint)names.Count;
					tokens.Add(name, token);

					names.Add(name);
					return token;
				}
			}

			public string this[uint token] => names[(int)token];

			public void Write(DataWriter writer)
			{
				this.AssertSealed();

				int count = names.Count;
				writer.WriteCompact(count);

				for (int i = 0; i < count; i++) writer.Write(names[i]);
			}

			public void Seal()
			{
				this.AssertNotSealed();
				IsSealed = true;
			}
		}

		public class RecordInfo
		{
			public RecordInfo(long recordTime, int sourceFileCount, int codeLineCount, int codeWithoutCodeHelperCount, int classCount, int structCount, SourceInfo[] sourceInfos)
			{
				this.recordTime = recordTime;

				this.sourceFileCount = sourceFileCount;
				this.codeLineCount = codeLineCount;
				this.codeWithoutCodeHelperCount = codeWithoutCodeHelperCount;

				this.classCount = classCount;
				this.structCount = structCount;

				this.sourceInfos = new ReadOnlyCollection<SourceInfo>(sourceInfos);
			}

			/// <summary>
			/// Creates an info by reading from the reader
			/// NOTE: Legacy/Obsolete
			/// </summary>
			public RecordInfo(BinaryReader reader)
			{
				recordTime = reader.ReadInt64();

				sourceFileCount = reader.ReadInt32();
				codeLineCount = reader.ReadInt32();
				codeWithoutCodeHelperCount = reader.ReadInt32();

				classCount = reader.ReadInt32();
				structCount = reader.ReadInt32();

				int length = reader.ReadInt32();
				var array = new SourceInfo[length];

				for (int i = 0; i < length; i++) array[i] = new SourceInfo(reader);
				sourceInfos = new ReadOnlyCollection<SourceInfo>(array);
			}

			/// <summary>
			/// Creates a <see cref="DataReader"/> by reading from <paramref name="reader"/>.
			/// NOTE: This assumes the new version of the file.
			/// </summary>
			public RecordInfo(DataReader reader, SourceNameMapper mapper)
			{
				recordTime = reader.ReadInt64();

				sourceFileCount = reader.ReadInt32Compact();
				codeLineCount = reader.ReadInt32Compact();
				codeWithoutCodeHelperCount = reader.ReadInt32Compact();

				classCount = reader.ReadInt32Compact();
				structCount = reader.ReadInt32Compact();

				int length = reader.ReadInt32Compact();
				var array = new SourceInfo[length];

				for (int i = 0; i < length; i++) array[i] = new SourceInfo(reader, mapper);
				sourceInfos = new ReadOnlyCollection<SourceInfo>(array);
			}

			readonly long recordTime;
			public DateTime RecordTime => new DateTime(recordTime, DateTimeKind.Utc);

			//Info
			public readonly int sourceFileCount;
			public readonly int codeLineCount;
			public readonly int codeWithoutCodeHelperCount;

			public readonly int classCount;
			public readonly int structCount;

			public readonly ReadOnlyCollection<SourceInfo> sourceInfos;

			public void Write(DataWriter writer, SourceNameMapper mapper)
			{
				writer.Write(recordTime);

				writer.WriteCompact(sourceFileCount);
				writer.WriteCompact(codeLineCount);
				writer.WriteCompact(codeWithoutCodeHelperCount);

				writer.WriteCompact(classCount);
				writer.WriteCompact(structCount);

				int count = sourceInfos.Count;
				writer.WriteCompact(count);

				for (int i = 0; i < count; i++) sourceInfos[i].Write(writer, mapper);
			}

			public void MarkTokens(SourceNameMapper mapper)
			{
				foreach (SourceInfo info in sourceInfos)
				{
					//Mark the source names
					uint _ = mapper[info.name];
				}
			}
		}

		public class SourceInfo
		{
			public SourceInfo(int lineCount, string name, bool isCodeHelper, int classContains, int structContains)
			{
				this.lineCount = lineCount;
				this.name = name;

				this.isCodeHelper = isCodeHelper;

				this.classContains = classContains;
				this.structContains = structContains;
			}

			/// <summary>
			/// Creates an info by reading from the reader
			/// NOTE: Legacy/obsolete
			/// </summary>
			public SourceInfo(BinaryReader reader)
			{
				lineCount = reader.ReadInt32();
				name = reader.ReadString();

				isCodeHelper = reader.ReadBoolean();

				classContains = reader.ReadInt32();
				structContains = reader.ReadInt32();
			}

			/// <summary>
			/// Creates a <see cref="SourceInfo"/> by reading from <paramref name="reader"/>.
			/// NOTE: This assumes the new version of the file.
			/// </summary>
			public SourceInfo(DataReader reader, SourceNameMapper mapper)
			{
				lineCount = reader.ReadInt32Compact();
				isCodeHelper = reader.ReadBoolean();

				classContains = reader.ReadInt32Compact();
				structContains = reader.ReadInt32Compact();

				name = mapper[reader.ReadUInt32Compact()];
			}

			public readonly int lineCount;
			public readonly string name;

			public readonly bool isCodeHelper;

			public readonly int classContains;
			public readonly int structContains;

			public void Write(DataWriter writer, SourceNameMapper mapper)
			{
				writer.WriteCompact(lineCount);
				writer.Write(isCodeHelper);

				writer.WriteCompact(classContains);
				writer.WriteCompact(structContains);

				writer.WriteCompact(mapper[name]);
			}
		}
	}
}

#endif