using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor.Editor
{
	public class AssetHandler
	{
		[OnOpenAsset]
		public static bool OpenEditor(int instanceId, int line)
		{
			var data = EditorUtility.InstanceIDToObject(instanceId) as ActionImportData;
			if (data == null) return false;

			ActionImportDataEditorWindow.Open(data);
			return true;
		}
	}


	[CustomEditor(typeof(ActionImportData))]
	public class ActionImportDataCustomEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			if (GUILayout.Button("Open Editor"))
			{
				ActionImportDataEditorWindow.Open((ActionImportData)target);
			}
		}
	}
}