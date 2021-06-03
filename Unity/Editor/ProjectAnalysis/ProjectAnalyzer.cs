#if CODEHELPERS_UNITY

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CodeHelpers.Diagnostics;
using CodeHelpers.Files;
using CodeHelpers.Mathematics;
using UnityEngine;
using Color32 = CodeHelpers.Mathematics.Color32;

namespace CodeHelpers.Unity.ProjectAnalysis
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

					DebugHelper.Log("All project history information cleared.");

					clearDoubleCheck = false;
					return;
				}

				clearDoubleCheck &= !GUILayout.Button("Cancel");
			}
			else clearDoubleCheck |= GUILayout.Button("Clear All History");

			if (GUILayout.Button("Reveal Info File")) EditorUtility.RevealInFinder(Utility.HistoryPathNew);

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
			Color32 backgroundColor = new Color32(45, 45, 45);
			Color32 textColor = new Color32(185, 185, 185);
			Color32 highlightColor = new Color32(250, 20, 20);

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
				ProjectHistory.RecordInfo info = Utility.CurrentHistory[i];
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
		List<ProjectHistory.SourceInfo> currentSourceInfo; //List will be copied

		void DrawInfo(Rect area, int index)
		{
			ProjectHistory.RecordInfo info = Utility.CurrentHistory[index];

			GUILayout.BeginArea(area);

			EditorGUILayout.Space();
			EditorGUILayout.BeginHorizontal();

			if (removeCurrentDoubleCheck)
			{
				if (GUILayout.Button("Sure?"))
				{
					Utility.CurrentHistory.RemoveAt(index);
					Utility.WriteCurrent();

					DebugHelper.Log("Last selected information removed.");

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
				currentSourceInfo = null;
				return;
			}

			if (GUILayout.Button(">"))
			{
				currentIndex = range.Clamp(currentIndex + 1);
				currentSourceInfo = null;
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

			currentSourceInfo ??= new List<ProjectHistory.SourceInfo>(info.sourceInfos);

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
			DebugHelper.Log(Utility.ShouldRecord, Utility.LastRecordedTime);
		}

		static class Utility
		{
			static ProjectHistory _currentHistory;
			static DateTime? _lastRecordedTime;

			public static ProjectHistory CurrentHistory
			{
				get => _currentHistory ??= TryReadHistory() ?? new ProjectHistory();
				private set => _currentHistory = value ?? throw ExceptionHelper.Invalid(nameof(value), InvalidType.isNull);
			}

			public static DateTime LastRecordedTime => _lastRecordedTime ?? (_lastRecordedTime = TryReadLastRecordedTime()).Value;
			public static bool ShouldRecord => DateTime.Compare(DateTime.UtcNow, LastRecordedTime + recordGap) >= 0;

			static string AssetPath => Application.dataPath;
			static string ProjectPath => Directory.GetParent(AssetPath).FullName;

			public static string HistoryPathNew => Path.Combine(ProjectPath, "ProjectHistory");
			public static string HistoryPathLegacy => Path.Combine(ProjectPath, "ProjectHistory.prjhis");
			public static string SourceFilePath => Path.Combine(AssetPath, "Scripts");

			static DateTime TryReadLastRecordedTime()
			{
				string path;

				if (File.Exists(HistoryPathNew)) path = HistoryPathNew;
				else if (File.Exists(HistoryPathLegacy)) path = HistoryPathLegacy;
				else return default;

				using DataReader reader = new DataReader(File.OpenRead(path));
				return new DateTime(reader.ReadInt64(), DateTimeKind.Utc);
			}

			static ProjectHistory TryReadHistory()
			{
				DebugHelper.Log("Reading project history");

				if (File.Exists(HistoryPathNew))
				{
					using DataReader reader = new DataReader(File.OpenRead(HistoryPathNew));
					return new ProjectHistory(reader);
				}

				if (File.Exists(HistoryPathLegacy))
				{
					using DataReader reader = new DataReader(File.OpenRead(HistoryPathLegacy));
					return new ProjectHistory((BinaryReader)reader);
				}

				return null;
			}

			static void WriteHistory(ProjectHistory history)
			{
				using DataWriter writer = new DataWriter(File.Open(HistoryPathNew, FileMode.Create));
				history.Write(writer);
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

				DebugHelper.Log("Recorded project analyzed information.");
			}

			public static ProjectHistory.RecordInfo Record()
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

				List<ProjectHistory.SourceInfo> allInfo = new List<ProjectHistory.SourceInfo>();

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

										allInfo.Add(new ProjectHistory.SourceInfo(lines.Length, Path.GetFileName(path), isCodeHelpers, thisClassCount, thisStructCount));
									}
				);

				return new ProjectHistory.RecordInfo(DateTime.UtcNow.Ticks, allInfo.Count, codeLineCount, codeWithoutCodeHelperCount, classCount, structCount, allInfo.ToArray());
			}
		}
	}

#endif

}

#endif