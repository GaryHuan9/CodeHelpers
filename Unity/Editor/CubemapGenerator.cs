#if CODEHELPERS_UNITY

using System.IO;
using System.Linq;
using CodeHelpers.Vectors;
using UnityEditor;
using UnityEngine;

namespace CodeHelpers.Editors
{
	public class CubemapGenerator : EditorWindow
	{
		[MenuItem("Window/CodeHelpers/Utilities/Cubemap Generator")]
		public static void Open()
		{
			var window = GetWindow<CubemapGenerator>("Cubemap Generator");
			window.minSize = new Vector2(100f, 100f);
		}

		readonly Texture2D[] textures = new Texture2D[EnumHelper<Direction>.EnumLength];
		Texture2D FirstTexture => textures.FirstOrDefault(texture => texture != null);

		void OnGUI()
		{
			GUILayout.BeginVertical(EditorStyles.helpBox);

			for (int i = 0; i < textures.Length; i++)
			{
				string field = GetName(i);
				textures[i] = (Texture2D)EditorGUILayout.ObjectField(field, textures[i], typeof(Texture2D), false);
			}

			GUILayout.EndVertical();
			EditorGUILayout.Space();
			GUILayout.BeginHorizontal(EditorStyles.helpBox);

			Texture2D first = FirstTexture;
			bool canGenerate = true;

			if (first == null)
			{
				GUILayout.Label(EditorGUIUtility.IconContent("console.warnicon.sml"));
				GUILayout.FlexibleSpace();
				GUILayout.Label("No source texture");

				canGenerate = false;
			}
			else
			{
				string invalidMessage = null;
				Vector2Int singleSize = new Vector2Int(first.width, first.height);

				for (int i = 0; i < textures.Length; i++)
				{
					Texture2D texture = textures[i];
					if (texture == null) continue;

					Vector2Int size = new Vector2Int(texture.width, texture.height);

					if (size.x != size.y)
					{
						invalidMessage = $"Texture \"{GetName(i)}\" is not a square! Size: {size}";
						break;
					}

					if (size != singleSize)
					{
						invalidMessage = $"Texture \"{GetName(i)}\" does not have matching size! \n Size: {size}; Match: {singleSize}";
						break;
					}
				}

				if (invalidMessage == null) //If no invalid texture
				{
					GUILayout.BeginVertical();

					GUILayout.Label($"Source textures size: {singleSize}");
					GUILayout.Label($"Cubemap texture size: {GetCubemapSize(singleSize)}");

					GUILayout.EndVertical();
				}
				else
				{
					GUILayout.Label(EditorGUIUtility.IconContent("console.erroricon.sml"));
					GUILayout.FlexibleSpace();
					GUILayout.Label(invalidMessage);

					canGenerate = false;
				}
			}

			GUILayout.EndHorizontal();

			EditorGUILayout.Space();
			EditorGUI.BeginDisabledGroup(!canGenerate);

			if (GUILayout.Button("Generate") && canGenerate)
			{
				string path = EditorUtility.SaveFilePanelInProject("Save Cubemap as PNG", "Cubemap.png", "png", "");
				if (!string.IsNullOrEmpty(path) && !string.IsNullOrWhiteSpace(path)) SaveCubemap(path);
			}

			EditorGUI.EndDisabledGroup();
		}

		void SaveCubemap(string path)
		{
			Texture2D first = FirstTexture;

			Vector2Int singleSize = new Vector2Int(first.width, first.height);
			Vector2Int resolution = GetCubemapSize(singleSize);

			Color[] colors = new Color[resolution.Size()];
			Texture2D result = new Texture2D(resolution.x, resolution.y);

			Color[][] sourceColors = new Color[textures.Length][];

			for (int i = 0; i < textures.Length; i++)
			{
				if (textures[i] == null) continue;
				sourceColors[i] = textures[i].GetPixels();
			}

			foreach (Vector2Int pixel in resolution.Loop())
			{
				int regionIndex = GetPixelTextureIndex(pixel, singleSize);
				Color color;

				if (regionIndex >= 0)
				{
					Color[] source = sourceColors[regionIndex];

					if (source == null) color = new Color(0f, 0f, 0f, 1f); //Black for missing texture
					else
					{
						Vector2Int region = GetPixelTextureOffset(pixel, singleSize);
						color = source[region.y * singleSize.x + region.x];
					}
				}
				else color = new Color(0f, 0f, 0f, 0f); //Transparent 

				colors[pixel.y * resolution.x + pixel.x] = color;
			}

			result.SetPixels(colors);
			result.Apply();

			File.WriteAllBytes(path, result.EncodeToPNG());
			DestroyImmediate(result);
		}

		/// <summary>
		/// Returns the region local direction index for the global <paramref name="pixel"/>.
		/// </summary>
		static int GetPixelTextureIndex(Vector2Int pixel, Vector2Int singleSize)
		{
			Vector2Int region = pixel.Divide(singleSize);
			int regionId = region.x * 3 + region.y;

			switch (regionId)
			{
				case 1:  return (int)Direction.left;
				case 3:  return (int)Direction.down;
				case 4:  return (int)Direction.forward;
				case 5:  return (int)Direction.up;
				case 7:  return (int)Direction.right;
				case 10: return (int)Direction.backward;
			}

			return -1;
		}

		/// <summary>
		/// Returns the region local offset for the global <paramref name="pixel"/>.
		/// </summary>
		static Vector2Int GetPixelTextureOffset(Vector2Int pixel, Vector2Int singleSize) => pixel.Mod(singleSize);

		static Vector2Int GetCubemapSize(Vector2Int sourceSize) => new Vector2Int(sourceSize.x * 4, sourceSize.y * 3);

		static string GetName(int index) => ((Direction)index).ToString().ToUpperInvariant();
	}
}

#endif