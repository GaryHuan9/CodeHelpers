#if CODEHELPERS_UNITY

using CodeHelpers.Mathematics;
using UnityEngine;

namespace CodeHelpers.Unity
{
	public static class NoiseHelper
	{

#region Methods

		public static void NoiseToArray(NoiseInfo info, Vector2 position, float[,] result, int seed)
		{
			NoiseToArray(info, seed, position, result);
		}

		public static float[,] NoiseToArray(NoiseInfo info, Vector2 position, Int2 size, int seed)
		{
			var results = new float[size.x, size.y];
			NoiseToArray(info, seed, position, results);

			return results;
		}

		public static float[] NoiseToArray(NoiseInfo info, Vector2[] positions, Vector2 positionOffset, int seed)
		{
			var results = new float[positions.Length];
			NoiseToArray(info, seed, positions, positionOffset, results);

			return results;
		}

		static void NoiseToArray(NoiseInfo info, int seed, Vector2 positionOffset, float[,] result)
		{
			Int2 size = new Int2(result.GetLength(0), result.GetLength(1));

			float amplitude = 1f;
			float frequency = 1f;

			for (int i = 0; i < info.layerCount; i++)
			{
				for (int x = 0; x < size.x; x++)
				{
					for (int y = 0; y < size.y; y++)
					{
						Vector2 position = (new Vector2(x, y) + positionOffset) / info.spread * frequency + Vector2.one * (seed + i);

						if (i == 0) result[x, y] = 0f;

						result[x, y] += Mathf.PerlinNoise(position.x, position.y) * amplitude;
					}
				}

				amplitude *= info.persistence;
				frequency *= info.lacunarity;
			}

			//Set the noise range from 0 to 1
			result.InverseLerp(0f, NoiseInfo.GetMaxHeight(info.layerCount, info.persistence));
		}

		static void NoiseToArray(NoiseInfo info, int seed, Vector2[] positions, Vector2 positionOffset, float[] result)
		{
			float amplitude = 1f;
			float frequency = 1f;

			for (int i = 0; i < info.layerCount; i++)
			{
				for (int j = 0; j < positions.Length; j++)
				{
					Vector2 position = (positions[j] + positionOffset) / info.spread * frequency + Vector2.one * (seed + i);

					if (i == 0) result[j] = 0f;

					result[j] += Mathf.PerlinNoise(position.x, position.y) * amplitude;
				}

				amplitude *= info.persistence;
				frequency *= info.lacunarity;
			}

			//Set the noise range from 0 to 1
			result.InverseLerp(0f, NoiseInfo.GetMaxHeight(info.layerCount, info.persistence));
		}

		public static float Sample(NoiseInfo info, int seed, Vector2 position)
		{
			float result = 0f;

			float amplitude = 1f;
			float frequency = 1f;

			for (int j = 0; j < info.layerCount; j++)
			{
				Vector2 target = position / info.spread * frequency + Vector2.one * (seed + j);
				result += Mathf.PerlinNoise(target.x, target.y) * amplitude;

				amplitude *= info.persistence;
				frequency *= info.lacunarity;
			}

			return Mathf.InverseLerp(0f, info.MaxHeight, result);
		}

#endregion

#region Extensions

		static void InverseLerp(this float[] array, float a, float b)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Mathf.InverseLerp(a, b, array[i]);
			}
		}

		static void InverseLerp(this float[,] array, float a, float b)
		{
			for (int x = 0; x < array.GetLength(0); x++)
			{
				for (int y = 0; y < array.GetLength(1); y++)
				{
					array[x, y] = Mathf.InverseLerp(a, b, array[x, y]);
				}
			}
		}

#endregion

	}

	[System.Serializable]
	public readonly struct NoiseInfo
	{
		public NoiseInfo(float spread, int layerCount, float persistence = 0.5f, float lacunarity = 2f)
		{
			this.spread = spread;
			this.layerCount = layerCount;
			this.persistence = persistence;
			this.lacunarity = lacunarity;
		}

		public readonly float spread;
		public readonly int layerCount;

		public readonly float persistence;
		public readonly float lacunarity;

		public static readonly NoiseInfo defaultInfo = new NoiseInfo(1f, 1);

		public float MaxHeight => GetMaxHeight(layerCount, persistence);

		public static float GetMaxHeight(int layerCount, float persistence)
		{
			float maxHeight = 0;
			float amplitude = 1;

			for (int i = 0; i < layerCount; i++)
			{
				maxHeight += amplitude;
				amplitude *= persistence;
			}

			return maxHeight;
		}
	}
}

#endif