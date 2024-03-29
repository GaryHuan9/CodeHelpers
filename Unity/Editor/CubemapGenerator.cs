﻿#if CODE_HELPERS_UNITY

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodeHelpers.Mathematics;
using CodeHelpers.Packed;
using UnityEditor;
using UnityEngine;

namespace CodeHelpers.Unity.Editors
{
	public class CubemapGenerator : EditorWindow
	{
		[MenuItem("Window/CodeHelpers/Utilities/Cubemap Generator")]
		public static void Open()
		{
			var window = GetWindow<CubemapGenerator>("Cubemap Generator");
			window.minSize = new Float2(100f, 100f);
		}

		readonly Texture2D[] textures = new Texture2D[Direction.All.Length];
		Texture2D FirstTexture => textures.FirstOrDefault(texture => texture != null);

		TextureType extension = TextureType.exrHalf;

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

					if (size.X != size.Y)
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

			extension = (TextureType)EditorGUILayout.EnumPopup("File Extension", extension);

			if (GUILayout.Button("Generate") && canGenerate)
			{
				string ext;
				switch (extension)
				{
					case TextureType.pngHalf:
					case TextureType.pngFull:
					{
						ext = "png";
						break;
					}
					case TextureType.exrHalf:
					case TextureType.exrFull:
					{
						ext = "exr";
						break;
					}
					default: throw ExceptionHelper.Invalid(nameof(extension), extension, InvalidType.unexpected);
				}

				string path = EditorUtility.SaveFilePanelInProject($"Save Cubemap as {ext.ToUpper()}", $"Cubemap.{ext}", ext, "");
				if (!string.IsNullOrEmpty(path) && !string.IsNullOrWhiteSpace(path)) SaveCubemap(path);
			}

			EditorGUI.EndDisabledGroup();
		}

		void SaveCubemap(string path)
		{
			Texture2D first = FirstTexture;

			Int2 singleSize = new Int2(first.width, first.height);
			Int2 resolution = GetCubemapSize(singleSize);

			TextureFormat format;
			switch (extension)
			{
				case TextureType.pngHalf:
				{
					format = TextureFormat.RGBA32;
					break;
				}
				case TextureType.pngFull:
				{
					format = TextureFormat.RGBA64;
					break;
				}
				case TextureType.exrHalf:
				{
					format = TextureFormat.RGBAHalf;
					break;
				}
				case TextureType.exrFull:
					format = TextureFormat.RGBAFloat;
				{
					break;
				}
				default: throw ExceptionHelper.Invalid(nameof(extension), extension, InvalidType.unexpected);
			}

			Color[] colors = new Color[resolution.ProductAbsoluted];
			Color[][] sourceColors = new Color[textures.Length][];

			for (int i = 0; i < textures.Length; i++)
			{
				if (textures[i] == null) continue;
				sourceColors[i] = textures[i].GetPixels();
			}

			Parallel.ForEach
			(
				resolution.Loop(), pixel =>
				{
					Direction direction = GetPixelTextureDirection(pixel, singleSize);
					Color color;

					if (!direction.IsZero)
					{
						Color[] source = sourceColors[direction.Index];

						if (source == null) color = Color.black; //Black for missing texture
						else
						{
							Int2 region = GetPixelTextureOffset(pixel, singleSize);
							color = source[region.Y * singleSize.X + region.X];
						}
					}
					else color = Color.clear;

					colors[pixel.Y * resolution.X + pixel.X] = color;
				}
			);

			Release(ref sourceColors);

			Texture2D result = new Texture2D(resolution.X, resolution.Y, format, false);

			result.SetPixels(colors);
			result.Apply();

			Release(ref colors);

			byte[] bytes;

			switch (extension)
			{
				case TextureType.pngHalf:
				case TextureType.pngFull:
				{
					bytes = result.EncodeToPNG();
					break;
				}
				case TextureType.exrHalf:
				{
					bytes = result.EncodeToEXR(Texture2D.EXRFlags.CompressZIP);
					break;
				}
				case TextureType.exrFull:
				{
					bytes = result.EncodeToEXR(Texture2D.EXRFlags.OutputAsFloat);
					break;
				}
				default: throw ExceptionHelper.Invalid(nameof(extension), extension, InvalidType.unexpected);
			}

			DestroyImmediate(result);
			Release(ref result);

			File.WriteAllBytes(path, bytes);
		}

		static void Release<T>(ref T location) where T : class
		{
			location = null;
			GC.Collect();
		}

		/// <summary>
		/// Returns the region local direction index for the global <paramref name="pixel"/>.
		/// </summary>
		static Direction GetPixelTextureDirection(Int2 pixel, Int2 singleSize)
		{
			Int2 region = pixel / singleSize;

			return (region.X * 3 + region.Y) switch
			{
				1 => Direction.left,
				3 => Direction.down,
				4 => Direction.forward,
				5 => Direction.up,
				7 => Direction.right,
				10 => Direction.backward,
				_ => default
			};
		}

		/// <summary>
		/// Returns the region local offset for the global <paramref name="pixel"/>.
		/// </summary>
		static Int2 GetPixelTextureOffset(Int2 pixel, Int2 singleSize) => pixel % singleSize;

		static Int2 GetCubemapSize(Int2 sourceSize) => sourceSize * new Int2(4, 3);

		static string GetName(int index) => Direction.All[index].ToString().ToUpperInvariant();

		enum TextureType
		{
			pngHalf,
			pngFull,
			exrHalf,
			exrFull
		}
	}
}

#endif