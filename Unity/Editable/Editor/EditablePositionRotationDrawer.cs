#if CODEHELPERS_UNITY

using UnityEditor;
using UnityEngine;

namespace CodeHelpers.Unity.Editable
{
	[CustomPropertyDrawer(typeof(EditablePositionRotation))]
	public class EditablePositionRotationDrawer : EditableDrawer
	{
		protected override int HeightLaneCount => 3;

		protected override bool DrawInspectorGUI(Rect rect, IEditable target)
		{
			var editable = (EditablePositionRotation)target;

			Rect rect1 = new Rect(rect.x, rect.y + DefaultHeight + HeightPadding, rect.width, DefaultHeight);
			Rect rect2 = new Rect(rect.x, rect.y + DefaultHeight * 2 + HeightPadding, rect.width, DefaultHeight);

			var lastPosition = editable.position;
			var lastRotation = editable.rotation;

			editable.position = EditorGUI.Vector3Field(rect1, GUIContent.none, lastPosition);
			editable.rotation = Vector4ToQuaternion(EditorGUI.Vector4Field(rect2, GUIContent.none, QuaternionToVector4(lastRotation)));

			return editable.position != lastPosition || editable.rotation != lastRotation;
		}

		public static bool CheckEditingTarget(Object target)
		{
			var editable = TryGetEditable<EditablePositionRotationDrawer, EditablePositionRotation>(target);
			if (editable == null) return false;

			var lastPosition = editable.position;
			var lastRotation = editable.rotation;

			editable.position = Handles.PositionHandle(lastPosition, lastRotation);
			editable.rotation = Handles.RotationHandle(lastRotation, lastPosition);

			if (editable.position != lastPosition || editable.rotation != lastRotation) EditorUtility.SetDirty(target);

			return true;
		}

		static Vector4 QuaternionToVector4(Quaternion quaternion) => new Vector4(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
		static Quaternion Vector4ToQuaternion(Vector4 vector) => new Quaternion(vector.x, vector.y, vector.z, vector.w);
	}
}

#endif