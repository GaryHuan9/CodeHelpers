using UnityEditor;
using UnityEngine;

namespace CodeHelpers.Editable.Editor
{
	//NOTE: Remember to enable EditableEditor if you want the UI editor to work!

	public abstract class EditableDrawer : PropertyDrawer
	{
		static void TryInitialize()
		{
			if (toggleStyleToggled != null) return;

			toggleStyleToggled = new GUIStyle(GUI.skin.button);
			toggleStyleToggled.normal.background = toggleStyleToggled.active.background;
		}

		protected abstract int HeightLaneCount { get; }

		protected bool IsEditing => Current == this;
		protected static EditableDrawer Current { get; private set; }

		protected const float HeightPadding = 1.2f;
		protected static float DefaultHeight => EditorGUIUtility.singleLineHeight;

		static GUIStyle toggleStyleToggled; //Semi-readonly

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => HeightPadding * 2f + DefaultHeight * HeightLaneCount;

		public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
		{
			TryInitialize();

			var editable = (IEditable)fieldInfo.GetValue(property.serializedObject.targetObject);
			Rect topRect = new Rect(rect.x, rect.y + HeightPadding, rect.width, DefaultHeight);

			GUI.Label(topRect, label.text);

			float labelWidth = GUI.skin.label.CalcSize(label).x + 5;
			Rect buttonRect = new Rect(topRect.x + labelWidth, topRect.y, topRect.width - labelWidth, topRect.height);

			if (GUI.Button(buttonRect, "Edit", IsEditing ? toggleStyleToggled : GUI.skin.button))
			{
				Current = IsEditing ? null : this;
				SceneView.RepaintAll();
			}

			//Draw the inspector GUI for specific type of editable
			//Must be after the drawing of the button, or the button will break (probably a Unity bug)
			EditorGUI.BeginDisabledGroup(IsEditing);

			if (DrawInspectorGUI(rect, editable)) EditorUtility.SetDirty(property.serializedObject.targetObject); //Mark dirty if modified

			EditorGUI.EndDisabledGroup();
		}

		/// <summary>
		/// Returns if the data has been modified.
		/// </summary>
		protected abstract bool DrawInspectorGUI(Rect rect, IEditable target);

		protected static TEditable TryGetEditable<TDrawer, TEditable>(Object target)
			where TEditable : class, IEditable
			where TDrawer : EditableDrawer
		{
			if (!(Current is TDrawer drawer)) return null;
			if (!(drawer.fieldInfo.GetValue(target) is TEditable editable)) return null;

			return editable;
		}
	}
}