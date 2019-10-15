using UnityEditor;
using UnityEngine;

namespace CodeHelpers.Editable.Editor
{
	//NOTE: This causes NaughtAttributes to malfunction!

	// [CustomEditor(typeof(MonoBehaviour), true)]
	// public class EditableEditor : UnityEditor.Editor
	// {
	// 	public void OnSceneGUI()
	// 	{
	// 		Tools.hidden = EditablePositionDrawer.CheckEditingTarget(target) || EditablePositionRotationDrawer.CheckEditingTarget(target);
	// 	}
	// }
}