#if CODEHELPERS_UNITY && UNITY_EDITOR

using CodeHelpers.Vectors;
using UnityEditor;
using UnityEngine;

namespace CodeHelpers.Editors.VectorDrawers
{
	[CustomPropertyDrawer(typeof(Float3))]
	public class Float3Drawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);


			EditorGUI.EndProperty();
		}
	}
}

#endif