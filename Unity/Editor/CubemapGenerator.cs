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
			window.minSize = new Float2(100f, 100f);
		}

		readonly Texture2D[] textures = new Texture2D[EnumHelper<Direction>.enumLength];
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
				Int2 singleSize = new Int2(first.width, first.height);

				for (int i = 0; i < textures.Length; i++)
				{
					Texture2D texture = textures[i];
					if (texture == null) continue;

					Int2 size = new Int2(texture.width, texture.height);

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

			Int2 singleSize = new Int2(first.width, first.height);
			Int2 resolution = GetCubemapSize(singleSize);

			Color[] colors = new Color[resolution.ProductAbsoluted];
			Texture2D result = new Texture2D(resolution.x, resolution.y);

			Color[][] sourceColors = new Color[textures.Length][];

			for (int i = 0; i < textures.Length; i++)
			{
				if (textures[i] == null) continue;
				sourceColors[i] = textures[i].GetPixels();
			}

			foreach (Int2 pixel in resolution.Loop())
			{
				int regionIndex = GetPixelTextureIndex(pixel, singleSize);
				Color color;

				if (regionIndex >= 0)
				{
					Color[] source = sourceColors[regionIndex];

					if (source == null) color = new Color(0f, 0f, 0f, 1f); //Black for missing texture
					else
					{
						Int2 region = GetPixelTextureOffset(pixel, singleSize);
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
		static int GetPixelTextureIndex(Int2 pixel, Int2 singleSize)
		{
			Int2 region = pixel / singleSize;
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
		static Int2 GetPixelTextureOffset(Int2 pixel, Int2 singleSize) => pixel % singleSize;

		static Int2 GetCubemapSize(Int2 sourceSize) => new Int2(sourceSize.x * 4, sourceSize.y * 3);

		static string GetName(int index) => ((Direction)index).ToString().ToUpperInvariant();
	}
}

#endif