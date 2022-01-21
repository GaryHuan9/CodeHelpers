#if CODE_HELPERS_UNITY

using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace CodeHelpers.Unity.BehaviorTreeUIEditor
{
	[CustomEditor(typeof(ActionImportData))]
	public class ActionImportDataCustomEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			if (!GUILayout.Button("Open Editor")) return;
			ActionImportDataEditorWindow.Open((ActionImportData)target);
		}

		[OnOpenAsset]
		public static bool OpenEditor(int instanceId, int line)
		{
			var data = EditorUtility.InstanceIDToObject(instanceId) as ActionImportData;
			if (data == null) return false;

			ActionImportDataEditorWindow.Open(data);
			return true;
		}
	}
}

#endif