#if CODEHELPERS_UNITY

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CodeHelpers.Unity.Debugs;
using UnityEngine;

namespace CodeHelpers.CodeCounters
{

#if UNITY_EDITOR

	using UnityEditor;
	using UnityEditor.Callbacks;

	public class ProjectAnalyzer : EditorWindow
	{
		[MenuItem("Window/CodeHelpers/Project Analyzer")]
		static void Init()
		{
			var analyzer = (ProjectAnalyzer)GetWindow(typeof(ProjectAnalyzer));

			analyzer.titleContent = new GUIContent("Project Analyzer");
			analyzer.Show();

			Utility.ReadCurrent();
		}

		static readonly TimeSpan recordGap = new TimeSpan(8, 0, 0);

		bool clearDoubleCheck;
		bool removeCurrentDoubleCheck;

		int graphInfoDisplayCount = 15;

		void OnGUI()
		{
			const float Margin = 25f;

			if (currentIndex == -1) DrawGraph(new Rect(Margin, position.height - Margin, position.width - Margin * 2f, position.height - Margin * 2f));
			else DrawInfo(new Rect(Margin, Margin, (position.width - Margin * 2f) * 0.4f, position.height - Margin * 2f), currentIndex);

			GUI.color = Color.white;

			EditorGUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();

			if (GUILayout.Button("Reload History From File")) Utility.ReadCurrent();
			if (GUILayout.Button("Record Current")) Utility.RecordWrite();

			if (clearDoubleCheck)
			{
				if (GUILayout.Button("Sure?"))
				{
					Utility.CurrentHistory.Clear();
					Utility.WriteCurrent();

					Debug.Log("All project history information cleared.");

					clearDoubleCheck = false;
					return;
				}

				clearDoubleCheck &= !GUILayout.Button("Cancel");
			}
			else clearDoubleCheck |= GUILayout.Button("Clear All History");

			if (GUILayout.Button("Reveal Info File")) EditorUtility.RevealInFinder(Utility.HistoryFullPath);

			GUILayout.FlexibleSpace();
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();

			graphInfoDisplayCount = EditorGUILayout.IntSlider(graphInfoDisplayCount, 1, Utility.CurrentHistory.Count);

			GUILayout.FlexibleSpace();
			EditorGUILayout.EndHorizontal();
		}

		void DrawGraph(Rect target)
		{
			Color backgroundColor = new Color32(45, 45, 45, 255);
			Color textColor = new Color32(185, 185, 185, 255);
			Color highlightColor = new Color32(250, 20, 20, 255);

			EditorGUI.DrawRect(new Rect(target.position, Vector2.Scale(target.size, new Vector2(1f, -1f))), backgroundColor);

			Vector2 sideSpacing = new Vector2(100f, -30f);
			int recordCount = Utility.CurrentHistory.Count;

			if (recordCount == 0) return;

			MinMaxInt yRange = new MinMaxInt(Utility.CurrentHistory.Min(info => info.codeLineCount), Utility.CurrentHistory.Max(info => info.codeLineCount));

			float xSpacing = recordCount == 1 ? 0f : (target.width - sideSpacing.x * 2f) / (recordCount - 1);
			float ySize = target.height + sideSpacing.y * 2f;

			Handles.color = textColor;
			GUI.color = textColor;

			int infoCount = Mathf.Clamp(graphInfoDisplayCount, 1, recordCount - 1);

			for (int i = 0; i < recordCount; i++)
			{
				RecordInfo info = Utility.CurrentHistory[i];
				bool showingInfo = Math.Abs(GetPercent(i) * infoCount % 1f) < Math.Abs(GetPercent(i + 1) * infoCount % 1f) &&
								   Math.Abs(GetPercent(i) * infoCount % 1f) < Math.Abs(GetPercent(i - 1) * infoCount % 1f);

				float GetPercent(int index) => (float)index / (recordCount - 1);

				if (showingInfo)
				{
					GUI.Label(new Rect(target.position + sideSpacing + Vector2.right * xSpacing * i, new Vector2(100f, 100f)), info.RecordTime.ToLocalTime().ToString("MM/dd/yyyy\nH:mm"));

					GUILayout.BeginArea(new Rect(target.position + sideSpacing + Vector2.up * 30f + Vector2.right * xSpacing * i, new Vector2(40f, 20f)));
					GUI.color = Color.white;

					if (GUILayout.Button("Detail"))
					{
						currentIndex = i;
						currentSourceInfo = null;
					}

					GUI.color = textColor;
					GUILayout.EndArea();
				}

				Vector2 position1 = target.position + sideSpacing + new Vector2(xSpacing * i, -yRange.InverseLerp(info.codeLineCount) * ySize);

				//Line
				if (i != recordCount - 1)
				{
					Vector2 position2 = target.position + sideSpacing + new Vector2(xSpacing * (i + 1), -yRange.InverseLerp(Utility.CurrentHistory[i + 1].codeLineCount) * ySize);
					Handles.DrawLine(position1, position2);
				}

				//Point
				if (showingInfo)
				{
					Handles.color = highlightColor;
					Handles.DrawWireDisc(position1, Vector3.back, 2f);
					Handles.color = textColor;
				}
				else
				{
					Handles.DrawWireDisc(position1, Vector3.back, 2f);
				}
			}

			int yLabelCount = Mathf.Clamp(yRange.Range, 2, 10);
			var style = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter, normal = {textColor = Color.white}};

			for (int i = 0; i < yLabelCount; i++)
			{
				float percent = i / (yLabelCount - 1f);
				Vector2 position = target.position + Vector2.Scale(sideSpacing, new Vector2(0.3f, 2f)) - ySize * percent * Vector2.up;

				GUI.Label(new Rect(position, new Vector2(50f, 50f)), Mathf.RoundToInt(yRange.Lerp(percent)).ToString(), style);
			}
		}

		int currentIndex = -1;       //-1 means null, the current info's index we are showing
		int currentSourceIndex = -1; //-1 means null, the current index of the source file info we are viewing

		Vector2 currentScrollPosition;
		List<RecordInfo.SourceFileInfo> currentSourceInfo; //List will be copied

		void DrawInfo(Rect area, int index)
		{
			RecordInfo info = Utility.CurrentHistory[index];

			GUILayout.BeginArea(area);

			EditorGUILayout.Space();
			EditorGUILayout.BeginHorizontal();

			if (removeCurrentDoubleCheck)
			{
				if (GUILayout.Button("Sure?"))
				{
					Utility.CurrentHistory.RemoveAt(index);
					Utility.WriteCurrent();

					Debug.Log("Last selected information removed.");

					CloseCurrent();
					return;
				}

				removeCurrentDoubleCheck &= !GUILayout.Button("Cancel");
			}
			else removeCurrentDoubleCheck |= GUILayout.Button("Remove Current Information");

			GUILayout.FlexibleSpace();

			//Navigation arrows
			MinMaxInt range = new MinMaxInt(0, Utility.CurrentHistory.Count - 1);

			if (GUILayout.Button("<"))
			{
				currentIndex = range.Clamp(currentIndex - 1);
				return;
			}

			if (GUILayout.Button(">"))
			{
				currentIndex = range.Clamp(currentIndex + 1);
				return;
			}

			GUILayout.FlexibleSpace();

			if (GUILayout.Button("Close"))
			{
				CloseCurrent();
				return;
			}

			EditorGUILayout.EndHorizontal();

			GUILayout.Label($"Time : {info.RecordTime.ToLocalTime():MM/dd/yyyy H:mm}");
			GUILayout.Label($"Source File Count : {info.sourceFileCount}");

			EditorGUILayout.Space();

			GUILayout.Label($"Total Line Count : {info.codeLineCount}");
			GUILayout.Label($"Line Count Without CodeHelpers : {info.codeWithoutCodeHelperCount}");

			EditorGUILayout.Space();

			GUILayout.Label($"Class Count (Not Accurate) : {info.classCount}");
			GUILayout.Label($"Struct Count (Not Accurate) : {info.structCount}");

			EditorGUILayout.Space();
			EditorGUILayout.Space();

			//Source files

			if (currentSourceInfo == null) currentSourceInfo = new List<RecordInfo.SourceFileInfo>(info.allSourceFileInfo);

			EditorGUILayout.BeginHorizontal();

			if (GUILayout.Button("Sort By Name") && currentSourceInfo != null)
			{
				currentSourceInfo = currentSourceInfo.OrderBy(thisInfo => thisInfo.name).ToList();
				currentSourceIndex = -1;
			}

			if (GUILayout.Button("Sort By Line Count") && currentSourceInfo != null)
			{
				currentSourceInfo = currentSourceInfo.OrderByDescending(thisInfo => thisInfo.lineCount).ToList();
				currentSourceIndex = -1;
			}

			GUILayout.FlexibleSpace();
			EditorGUILayout.EndHorizontal();

			//Source info

			currentScrollPosition = EditorGUILayout.BeginScrollView(currentScrollPosition);

			for (int i = 0; i < currentSourceInfo.Count; i++)
			{
				EditorGUILayout.BeginHorizontal();

				GUILayout.Label($"{currentSourceInfo[i].name} : {currentSourceInfo[i].lineCount}");
				GUILayout.FlexibleSpace();
				if (GUILayout.Button("Detail")) currentSourceIndex = i;

				EditorGUILayout.EndHorizontal();
			}

			EditorGUILayout.EndScrollView();
			GUILayout.EndArea();

			//Single source file info

			if (currentSourceIndex != -1)
			{
				var source = currentSourceInfo[currentSourceIndex];

				GUILayout.BeginArea(new Rect(area.width + 100f, area.y, position.width - area.width, area.height));
				EditorGUILayout.BeginHorizontal();

				if (GUILayout.Button("Close"))
				{
					currentSourceIndex = -1;
					return;
				}

				GUILayout.FlexibleSpace();
				EditorGUILayout.EndHorizontal();

				GUILayout.Label(source.name);
				EditorGUILayout.Space();

				GUILayout.Label($"Source Line Count : {source.lineCount}");
				GUILayout.Label($"Source Is CodeHelpers : {source.isCodeHelper}");

				EditorGUILayout.Space();

				GUILayout.Label($"Class Contained (Not Accurate) : {source.classContains}");
				GUILayout.Label($"Struct Contained (Not Accurate) : {source.structContains}");

				GUILayout.EndArea();
			}
		}

		void CloseCurrent()
		{
			currentIndex = -1;
			currentSourceIndex = -1;

			removeCurrentDoubleCheck = false;
			currentSourceInfo = null;
		}

		[DidReloadScripts]
		static void TryRecordCurrent()
		{
			if (Utility.ShouldRecord) Utility.RecordWrite();
			DebugHelperUnity.Log(Utility.ShouldRecord, Utility.LastRecordedTime);
		}

		static class Utility
		{
			static ProjectHistory _currentHistory;
			static DateTime? _lastRecordedTime;

			public static ProjectHistory CurrentHistory
			{
				get => _currentHistory ?? (_currentHistory = TryReadHistory() ?? new ProjectHistory());
				private set => _currentHistory = value ?? throw ExceptionHelper.Invalid(nameof(value), InvalidType.isNull);
			}

			public static DateTime LastRecordedTime => _lastRecordedTime ?? (_lastRecordedTime = TryReadLastRecordedTime()).Value;
			public static bool ShouldRecord => DateTime.Compare(DateTime.UtcNow, LastRecordedTime + recordGap) >= 0;

			public static string HistoryFullPath => Path.Combine(Application.dataPath.Remove(Application.dataPath.Length - 7), "ProjectHistory.prjhis");
			public static string SourceFilePath => Path.Combine(Application.dataPath, "Scripts");

			static ProjectHistory TryReadHistory()
			{
				if (!File.Exists(HistoryFullPath)) return null;
				DebugHelperUnity.Log("Reading project history");

				ProjectHistory history;

				using (BinaryReader reader = new BinaryReader(File.Open(HistoryFullPath, FileMode.Open)))
				{
					history = new ProjectHistory(reader);
				}

				return history;
			}

			static DateTime TryReadLastRecordedTime()
			{
				if (!File.Exists(HistoryFullPath)) return default;

				using (BinaryReader reader = new BinaryReader(File.Open(HistoryFullPath, FileMode.Open)))
				{
					return new DateTime(reader.ReadInt64(), DateTimeKind.Utc);
				}
			}

			static void WriteHistory(ProjectHistory history)
			{
				using (BinaryWriter writer = new BinaryWriter(File.Open(HistoryFullPath, FileMode.Create)))
				{
					history.Write(writer);
				}
			}

			/// <summary>
			/// Write the current loaded history into file
			/// </summary>
			public static void WriteCurrent() => WriteHistory(CurrentHistory);

			/// <summary>
			/// Tried to read project history from file
			/// </summary>
			public static void ReadCurrent() => CurrentHistory = TryReadHistory() ?? new ProjectHistory();

			/// <summary>
			/// Record the current status and write history to file
			/// </summary>
			public static void RecordWrite()
			{
				CurrentHistory.AddInfo(Record());
				WriteCurrent();

				Debug.Log("Recorded project analyzed information.");
			}

			public static RecordInfo Record()
			{
				int codeLineCount = 0;
				int codeWithoutCodeHelperCount = 0;

				int classCount = 0;
				int structCount = 0;

				const string ClassString1 = " class ";
				const string ClassString2 = "\tclass ";

				const string StructString1 = " struct ";
				const string StructString2 = "\tstruct ";

				const string CodeHelpersString = "CodeHelpers";

				List<RecordInfo.SourceFileInfo> allInfo = new List<RecordInfo.SourceFileInfo>();

				CodeCounter.Utility.ForEachSourceFile
				(
					SourceFilePath, path =>
									{
										string[] lines = File.ReadAllLines(path);
										bool isCodeHelpers = path.Contains(CodeHelpersString);

										codeLineCount += lines.Length;
										if (!isCodeHelpers) codeWithoutCodeHelperCount += lines.Length;

										int thisClassCount = 0;
										int thisStructCount = 0;

										for (int i = 0; i < lines.Length; i++)
										{
											if (lines[i].Contains(ClassString1) || lines[i].Contains(ClassString2)) thisClassCount++;
											if (lines[i].Contains(StructString1) || lines[i].Contains(StructString2)) thisStructCount++;
										}

										classCount += thisClassCount;
										structCount += thisStructCount;

										allInfo.Add(new RecordInfo.SourceFileInfo(lines.Length, Path.GetFileName(path), isCodeHelpers, thisClassCount, thisStructCount));
									}
				);

				return new RecordInfo(DateTime.UtcNow.Ticks, allInfo.Count, codeLineCount, codeWithoutCodeHelperCount, classCount, structCount, allInfo.ToArray());
			}
		}
	}

	public class RecordInfo
	{
		public RecordInfo(long recordTime, int sourceFileCount, int codeLineCount, int codeWithoutCodeHelperCount, int classCount, int structCount, SourceFileInfo[] allSourceFileInfo)
		{
			this.recordTime = recordTime;

			this.sourceFileCount = sourceFileCount;
			this.codeLineCount = codeLineCount;
			this.codeWithoutCodeHelperCount = codeWithoutCodeHelperCount;

			this.classCount = classCount;
			this.structCount = structCount;

			this.allSourceFileInfo = allSourceFileInfo;
		}

		/// <summary>
		/// Creates an info by reading from the reader
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
			allSourceFileInfo = new SourceFileInfo[length];

			for (int i = 0; i < length; i++) allSourceFileInfo[i] = new SourceFileInfo(reader);
		}

		readonly long recordTime;
		public DateTime RecordTime => new DateTime(recordTime, DateTimeKind.Utc);

		//Info
		public readonly int sourceFileCount;
		public readonly int codeLineCount;
		public readonly int codeWithoutCodeHelperCount;

		public readonly int classCount;
		public readonly int structCount;

		public readonly SourceFileInfo[] allSourceFileInfo;

		public void Write(BinaryWriter writer)
		{
			writer.Write(recordTime);

			writer.Write(sourceFileCount);
			writer.Write(codeLineCount);
			writer.Write(codeWithoutCodeHelperCount);

			writer.Write(classCount);
			writer.Write(structCount);

			writer.Write(allSourceFileInfo.Length);
			for (int i = 0; i < allSourceFileInfo.Length; i++) allSourceFileInfo[i].Write(writer);
		}

		public class SourceFileInfo
		{
			public SourceFileInfo(int lineCount, string name, bool isCodeHelper, int classContains, int structContains)
			{
				this.lineCount = lineCount;
				this.name = name;

				this.isCodeHelper = isCodeHelper;

				this.classContains = classContains;
				this.structContains = structContains;
			}

			/// <summary>
			/// Creates an info by reading from the reader
			/// </summary>
			public SourceFileInfo(BinaryReader reader)
			{
				lineCount = reader.ReadInt32();
				name = reader.ReadString();

				isCodeHelper = reader.ReadBoolean();

				classContains = reader.ReadInt32();
				structContains = reader.ReadInt32();
			}

			public readonly int lineCount;
			public readonly string name;

			public readonly bool isCodeHelper;

			public readonly int classContains; //Lol cant change this typo because of json
			public readonly int structContains;

			public void Write(BinaryWriter writer)
			{
				writer.Write(lineCount);
				writer.Write(name);

				writer.Write(isCodeHelper);

				writer.Write(classContains);
				writer.Write(structContains);
			}
		}
	}

	public class ProjectHistory : IReadOnlyList<RecordInfo>
	{
		/// <summary>
		/// Creates a history by reading from the reader
		/// </summary>
		public ProjectHistory(BinaryReader reader)
		{
			reader.ReadInt64(); //Read out the last recorded time

			int count = reader.ReadInt32();
			infoHistory = new List<RecordInfo>(count);

			for (int i = 0; i < count; i++) infoHistory.Add(new RecordInfo(reader));
		}

		public ProjectHistory() => infoHistory = new List<RecordInfo>();

		readonly List<RecordInfo> infoHistory; //Ordered by time, NOTE: We will try to not load this list when possible

		public DateTime LastRecordTime => Count == 0 ? new DateTime() : this[Count - 1].RecordTime;

		public RecordInfo this[int index] => infoHistory[index];
		public int Count => infoHistory.Count;

		public void AddInfo(RecordInfo info)
		{
			if (info.RecordTime <= LastRecordTime) throw new Exception($"Cannot add {nameof(info)}({info})! Its recorded time is before history's last record time");
			infoHistory.Add(info);
		}

		public void RemoveAt(int index) => infoHistory.RemoveAt(index);

		public void Clear()
		{
			infoHistory.Clear();
		}

		public void Write(BinaryWriter writer)
		{
			writer.Write(LastRecordTime.Ticks);
			writer.Write(infoHistory.Count);

			for (int i = 0; i < infoHistory.Count; i++) infoHistory[i].Write(writer);
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		IEnumerator<RecordInfo> IEnumerable<RecordInfo>.GetEnumerator() => GetEnumerator();

		public List<RecordInfo>.Enumerator GetEnumerator() => infoHistory.GetEnumerator();
	}

#endif

}

#endif