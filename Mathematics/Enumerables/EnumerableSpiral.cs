using System.Collections;
using System.Collections.Generic;

namespace CodeHelpers.Mathematics.Enumerables
{
	public readonly struct EnumerableSpiral2D : IEnumerable<Int2>
	{
		/// <summary>
		/// Creates a foreach-loop compatible IEnumerable which yields positions in a spiral.
		/// The positions form a square centered at (0, 0), meaning the first position will be (0, 0)
		/// </summary>
		/// <param name="radius">The radius (half size) of the position square returned. Radius of 1 returns square of size 3x3.</param>
		public EnumerableSpiral2D(int radius) => enumerator = new Enumerator(from, to);

		readonly Enumerator enumerator;

		public Enumerator GetEnumerator() => enumerator;

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		IEnumerator<Int2> IEnumerable<Int2>.GetEnumerator() => GetEnumerator();

		public struct Enumerator : IEnumerator<Int2>
		{
			public Enumerator(Int2 from, Int2 to)
			{
				this.from = from;
				this.to = to;

				current = -1;
				sample = (from - to).Absoluted.MaxComponent;
			}

			readonly Int2 from;
			readonly Int2 to;

			int current;         //Current point being sampled
			readonly int sample; //Number of points need to be sampled

			object IEnumerator.Current => Current;
			public Int2 Current => sample == 0 ? from : from.Lerp(to, (float)current / sample).Rounded;

			public bool MoveNext() => ++current <= sample;

			public void Reset() => current = -1;
			public void Dispose() { }
		}

		// /// <summary>
		// /// Returns an IEnumerable which will yield all the positions placed in a spiral order.
		// /// Start direction: Right
		// /// Will generate something like this (One layer):
		// ///
		// ///  567
		// ///  4 0
		// ///  321
		// ///
		// /// </summary>
		// /// <returns>The spiral positions.</returns>
		// /// <param name="center">The center of the spiral.</param>
		// /// <param name="layerCount">How many layers do you want the spiral to be?</param>
		// public static IEnumerable<Vector2Int> GetSpiralPoints(Vector2Int center, int layerCount) => GetSpiralPoints(center, layerCount, Vector2Int.right);
		//
		// /// <inheritdoc cref="GetSpiralPoints(Vector2Int,int)"/>
		// /// <param name="startDirection">The direction where the spiral will start.</param>
		// public static IEnumerable<Vector2Int> GetSpiralPoints(Vector2Int center, int layerCount, Vector2Int startDirection)
		// {
		// 	int index = 0;
		//
		// 	for (int i = 0; i < 4; i++)
		// 	{
		// 		if (startDirection == neighbor4Positions[index]) goto outBreak;
		// 		index++;
		// 	}
		//
		// 	throw new ArgumentException(nameof(startDirection) + " is invalid!\nIt can only be a direction inside " + nameof(neighbor4Positions));
		//
		// 	outBreak:
		//
		// 	Vector2Int position = center;
		// 	Vector2Int direction;
		//
		// 	for (int size = 1; size <= layerCount; size++)
		// 	{
		// 		direction = neighbor4Positions[index];
		// 		position += direction;
		//
		// 		RotateDirection();
		//
		// 		for (int j = 0; j < size; j++)
		// 		{
		// 			yield return position;
		// 			position += direction;
		// 		}
		//
		// 		RotateDirection();
		//
		// 		for (int j = 0; j < 3; j++) //For the 3 other directions
		// 		{
		// 			for (int k = 0; k < size * 2; k++)
		// 			{
		// 				yield return position;
		// 				position += direction;
		// 			}
		//
		// 			RotateDirection();
		// 		}
		//
		// 		for (int j = 0; j < size; j++)
		// 		{
		// 			yield return position;
		// 			position += direction;
		// 		}
		//
		// 		index = (index - 1).Repeat(4);
		// 	}
		//
		// 	void RotateDirection() => direction = neighbor4Positions[(++index).Repeat(4)];
		// }
	}
}