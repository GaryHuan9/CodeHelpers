using System;
using System.Runtime.CompilerServices;

namespace CodeHelpers.Mathematics
{
	/// <summary>
	/// Standard simplex gradient noise generator
	/// </summary>
	public class Simplex
	{
		/// <summary>
		/// Creates a standard simplex gradient noise generator
		/// </summary>
		/// <param name="seed">Generators with the same seed will generate the same value at the same location.</param>
		/// <param name="directionCount">The amount of directions used for generation. Does not majorly affect quality.</param>
		public Simplex(int seed, int directionCount = 256)
		{
			Random random = new Random(seed);

			this.directionCount = directionCount;
			directions = new Float2[directionCount];

			for (int i = 0; i < directionCount; i++)
			{
				float angle = (float)random.NextDouble() * 360f;
				directions[i] = Float2.right.Rotate(angle);
			}
		}

		readonly Float2[] directions;
		readonly int directionCount;

		const float SimplexScale = 2916f * Scalars.Sqrt2 / 125f;

		const float SquareToTriangle = (3f - Scalars.Sqrt3) / 6f;
		const float TriangleToSquare = (Scalars.Sqrt3 - 1f) / 2f;

		/// <summary>
		/// Retrieves the value of the noise at <paramref name="position"/>.
		/// </summary>
		public float Sample(Float2 position)
		{
			Float2 skewed = position + (Float2)(position.Sum * TriangleToSquare);

			Int2 cell = skewed.Floored;
			Float2 part = skewed - cell;

			float value = SamplePoint(position, cell) + SamplePoint(position, cell + Int2.one);
			value += SamplePoint(position, cell + (part.x >= part.y ? Int2.right : Int2.up));

			return value * SimplexScale / 2f + 0.5f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		float SamplePoint(Float2 point, Int2 cell)
		{
			Float2 part = point - cell + (Float2)(cell.Sum * SquareToTriangle);
			float weight = 0.5f - part.SquaredMagnitude;

			if (weight <= 0f) return 0f;
			weight *= weight * weight;

			return weight * directions[cell.GetHashCode() & (directionCount - 1)].Dot(part);
		}
	}
}