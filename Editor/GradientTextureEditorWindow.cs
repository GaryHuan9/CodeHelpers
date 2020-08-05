using System.IO;
using CodeHelpers.VectorHelpers;
using UnityEditor;
using UnityEngine;

namespace CodeHelpers.Editors
{
	public class GradientTextureEditorWindow : EditorWindow
	{
		[MenuItem("Window/CodeHelpers/Utilities/Gradient Texture Generator")]
		public static void Open()
		{
			var window = GetWindow<GradientTextureEditorWindow>("Texture Generator");
			window.minSize = new Vector2(100f, 100f);
		}

		Gradient gradient = new Gradient();
		Vector2Int resolution = new Vector2Int(512, 1);

		void OnGUI()
		{
			gradient = EditorGUILayout.GradientField(gradient);

			int width = EditorGUILayout.IntField("Width", resolution.x);
			int height = EditorGUILayout.IntField("Height", resolution.y);

			resolution = Vector2Int.Max(Vector2Int.one, new Vector2Int(width, height));

			if (GUILayout.Button("Generate"))
			{
				string path = EditorUtility.SaveFilePanelInProject("Save Gradient as PNG", "Gradient.png", "png", "");
				if (!string.IsNullOrEmpty(path) && !string.IsNullOrWhiteSpace(path)) SaveGradient(path);
			}
		}

		void SaveGradient(string path)
		{
			Color[] colors = new Color[resolution.Size()];
			Texture2D texture = new Texture2D(resolution.x, resolution.y);

			foreach (Vector2Int pixel in resolution.Loop())
			{
				int index = pixel.y * resolution.x + pixel.x;
				colors[index] = gradient.Evaluate(pixel.x / (resolution.x - 1f));
			}

			texture.SetPixels(colors);
			texture.Apply();

			File.WriteAllBytes(path, texture.EncodeToPNG());
			DestroyImmediate(texture);
		}
	}
}