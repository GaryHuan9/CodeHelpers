using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Text;

namespace CodeHelpers.CodeCounters
{

#if UNITY_EDITOR

	using UnityEditor;
	using UnityEditor.Callbacks;

	public class CodeCounter : EditorWindow
	{
		[MenuItem("Window/CodeHelpers/Code Counter")]
		static void Init()
		{
			CodeCounter thisCounter = GetWindow<CodeCounter>();

			thisCounter.titleContent = new GUIContent("Code Counter");

			thisCounter.Show();
			thisCounter.Refresh();
		}

		string scriptsPath = "/Scripts";
		string infoText = "";

		int totalCount;
		List<ScriptInfo> theseInfo;

		Vector2 scrollPosition;

		bool countCodeHelpers;

		void OnGUI()
		{
			if (GUILayout.Button("Refresh")) Refresh();
			scriptsPath = GUILayout.TextField(scriptsPath);

			EditorGUILayout.Space();

			EditorGUILayout.BeginHorizontal();

			if (GUILayout.Button("Sort By Name") && theseInfo != null)
			{
				theseInfo = theseInfo.OrderBy(thisInfo => thisInfo.name).ToList();
				RefreshGUI();
			}

			if (GUILayout.Button("Sort By Line Count") && theseInfo != null)
			{
				theseInfo = theseInfo.OrderByDescending(thisInfo => thisInfo.lineCount).ToList();
				RefreshGUI();
			}

			EditorGUILayout.EndHorizontal();

			countCodeHelpers = GUILayout.Toggle(countCodeHelpers, "Count CodeHelpers Lines");

			EditorGUILayout.Space();

			scrollPosition = GUILayout.BeginScrollView(scrollPosition);
			GUILayout.Label(infoText, GUI.skin.label);
			GUILayout.EndScrollView();
		}

		void Refresh()
		{
			if (theseInfo == null) theseInfo = new List<ScriptInfo>();
			else theseInfo.Clear();

			totalCount = 0;
			Utility.ForEachSourceFile(Application.dataPath + scriptsPath, path =>
			{
				if (!countCodeHelpers && path.Contains("CodeHelpers")) return;

				int lineCount = File.ReadAllLines(path).Length;
				totalCount += lineCount;
				theseInfo.Add(new ScriptInfo(Path.GetFileName(path), lineCount));
			});

			theseInfo = theseInfo.OrderBy(thisInfo => thisInfo.name).ToList();

			RefreshGUI();
		}

		void RefreshGUI()
		{
			StringBuilder builder = new StringBuilder();

			builder.AppendFormat("Total Count : {0}\n\n", totalCount);

			for (int i = 0; i < theseInfo.Count; i++)
			{
				ScriptInfo info = theseInfo[i];
				builder.AppendFormat("{0} : {1}\n", info.name, info.lineCount);
			}

			infoText = builder.ToString();

			Repaint();
		}

		public static class Utility
		{
			public static void ForEachSourceFile(string startPath, Action<string> pathAction)
			{
				string[] directories = Directory.GetDirectories(startPath);
				string[] files = Directory.GetFiles(startPath);

				for (int i = 0; i < directories.Length; i++) ForEachSourceFile(directories[i], pathAction);
				for (int i = 0; i < files.Length; i++)
				{
					string path = files[i];
					if (path.EndsWith(".cs", StringComparison.Ordinal)) pathAction(path);
				}
			}
		}
	}

#endif

	struct ScriptInfo
	{
		public ScriptInfo(string name, int lineCount)
		{
			this.name = name;
			this.lineCount = lineCount;
		}

		public readonly string name;
		public int lineCount;

		public override int GetHashCode() => name.GetHashCode();
	}

}