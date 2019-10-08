using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace CodeHelpers.Editable.Editor
{
	[CustomPropertyDrawer(typeof(EditablePosition))]
	public class EditablePositionDrawer : EditableDrawer
	{
		protected override int HeightLaneCount => 2;

		protected override bool DrawInspectorGUI(Rect rect, IEditable target)
		{
			var editable = (EditablePosition)target;
			Rect lowerRect = new Rect(rect.x, rect.y + rect.height / 2f, rect.width, DefaultHeight);

			var lastPosition = editable.position;
			editable.position = EditorGUI.Vector3Field(lowerRect, GUIContent.none, lastPosition);

			return lastPosition != editable.position;
		}

		public static bool CheckEditingTarget(Object target)
		{
			var editable = TryGetEditable<EditablePositionDrawer, EditablePosition>(target);
			if (editable == null) return false;

			var lastPosition = editable.position;
			editable.position = Handles.PositionHandle(lastPosition, Quaternion.identity);

			if (editable.position != lastPosition) EditorUtility.SetDirty(target);

			return true;
		}
	}
}