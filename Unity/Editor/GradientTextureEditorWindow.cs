#if CODE_HELPERS_UNITY && UNITY_EDITOR

using System.IO;
using CodeHelpers.Packed;
using UnityEditor;
using UnityEngine;

namespace CodeHelpers.Unity.Editors
{
	public class GradientTextureEditorWindow : EditorWindow
	{
		[MenuItem("Window/CodeHelpers/Utilities/Gradient Texture Generator")]
		public static void Open()
		{
			var window = GetWindow<GradientTextureEditorWindow>("Texture Generator");
			window.minSize = new Float2(100f, 100f);
		}

		Gradient gradient = new Gradient();
		Int2 resolution = new Int2(512, 1);

		void OnGUI()
		{
			gradient = EditorGUILayout.GradientField(gradient);

			int width = EditorGUILayout.IntField("Width", resolution.X);
			int height = EditorGUILayout.IntField("Height", resolution.Y);

			resolution = Int2.Max(Int2.One, new Int2(width, height));

			if (GUILayout.Button("Generate"))
			{
				string path = EditorUtility.SaveFilePanelInProject("Save Gradient as PNG", "Gradient.png", "png", "");
				if (!string.IsNullOrEmpty(path) && !string.IsNullOrWhiteSpace(path)) SaveGradient(path);
			}
		}

		void SaveGradient(string path)
		{
			Color[] colors = new Color[resolution.ProductAbsoluted];
			Texture2D texture = new Texture2D(resolution.X, resolution.Y);

			foreach (Int2 pixel in resolution.Loop())
			{
				int index = pixel.Y * resolution.X + pixel.X;
				colors[index] = gradient.Evaluate(pixel.X / (resolution.X - 1f));
			}

			texture.SetPixels(colors);
			texture.Apply();

			File.WriteAllBytes(path, texture.EncodeToPNG());
			DestroyImmediate(texture);
		}
	}
}

#endif