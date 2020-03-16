using System;
using UnityEngine;

namespace CodeHelpers.Manager
{

#if UNITY_EDITOR

	using UnityEditor;

	public class ManagerWindow : EditorWindow
	{
		[MenuItem("Window/CodeHelpers/Manager")]
		static void Init()
		{
			ManagerWindow analyzer = (ManagerWindow)GetWindow(typeof(ManagerWindow));

			analyzer.titleContent = new GUIContent("Code Helpers Manager");
			analyzer.Show();
		}

		string codeHelpersPath = "/Scripts/CodeHelpers"; //Local, path from the asset folder

		void OnGUI()
		{
			codeHelpersPath = GUILayout.TextField(codeHelpersPath);
		}
	}

#endif

}
