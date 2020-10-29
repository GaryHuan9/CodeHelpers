#if CODEHELPERS_UNITY && UNITY_EDITOR

using System.Collections.ObjectModel;
using System.Reflection;
using CodeHelpers.Unity.Vectors;
using CodeHelpers.Vectors;
using UnityEditor;
using UnityEngine;

namespace CodeHelpers.Editors
{
	public abstract class DrawerBase : PropertyDrawer
	{
		protected abstract ReadOnlyCollection<string> ComponentLabels { get; }
		protected virtual float Gap => 4f;

		public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(rect, label, property);
			ReadOnlyCollection<string> components = ComponentLabels;

			rect = EditorGUI.PrefixLabel(rect, GUIUtility.GetControlID(FocusType.Passive), label);

			Float2 position = rect.min;
			int count = components.Count;

			Float2 size = new Float2((rect.width - count * Gap + Gap) / count, rect.height);
			Float2 interval = new Float2(size.x + Gap, 0f);

			for (int i = 0; i < count; i++)
			{
				Rect componentArea = new Rect(position + interval * i, size);
				SerializedProperty componentProperty = property.FindPropertyRelative(components[i]);

				EditorGUI.PropertyField(componentArea, componentProperty, GUIContent.none);
			}

			EditorGUI.EndProperty();
		}
	}

	[CustomPropertyDrawer(typeof(Float3Unity))]
	public class Float3Drawer : DrawerBase
	{
		protected override ReadOnlyCollection<string> ComponentLabels { get; } = new ReadOnlyCollection<string>(new[] {"x", "y", "z"});
	}

	[CustomPropertyDrawer(typeof(Int3Unity))]
	public class Int3Drawer : DrawerBase
	{
		protected override ReadOnlyCollection<string> ComponentLabels { get; } = new ReadOnlyCollection<string>(new[] {"x", "y", "z"});
	}

	[CustomPropertyDrawer(typeof(Float2Unity))]
	public class Float2Drawer : DrawerBase
	{
		protected override ReadOnlyCollection<string> ComponentLabels { get; } = new ReadOnlyCollection<string>(new[] {"x", "y"});
	}

	[CustomPropertyDrawer(typeof(Int2Unity))]
	public class Int2Drawer : DrawerBase
	{
		protected override ReadOnlyCollection<string> ComponentLabels { get; } = new ReadOnlyCollection<string>(new[] {"x", "y"});
	}
}

#endif