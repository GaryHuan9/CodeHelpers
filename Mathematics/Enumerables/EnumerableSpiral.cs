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
		/// <param name="initial">The starting direction of the spiral, defaults to right.</param>
		public EnumerableSpiral2D(int radius, Direction initial = Direction.right) => enumerator = new Enumerator(radius, initial);

		readonly Enumerator enumerator;

		public Enumerator GetEnumerator() => enumerator;

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		IEnumerator<Int2> IEnumerable<Int2>.GetEnumerator() => GetEnumerator();

		public struct Enumerator : IEnumerator<Int2>
		{
			public Enumerator(int radius, Direction initial = Direction.right) : this()
			{
				size = radius * 2 + 1;
				this.initial = initial;

				Reset();
			}

			readonly int size;
			readonly Direction initial;

			Int2 direction; //The current direction, rotates as we move
			int step;       //The current step in this direction
			int length;     //The length we step until a corner is reached

			object IEnumerator.Current => Current;
			public Int2 Current { get; private set; }

			public bool MoveNext()
			{
				Current += direction;
				step++;

				if (step == length)
				{
					Rotate();

					if (length == size) direction = Int2.zero;
				}

				if (step == length * 2)
				{
					Rotate();

					length++;
					step = 0;
				}

				return direction != Int2.zero;
			}

			void Rotate() => direction = direction.Perpendicular;

			public void Reset()
			{
				direction = initial.ToInt2();
				Current = -direction;

				step = -1;
				length = 1;
			}

			public void Dispose() { }
		}
	}

	// Testing code:
	// var dictionary = new EnumerableSpiral2D(10).Select((position, index) => (position, index)).ToDictionary(pair => pair.position, pair => pair.index);
	//
	// Int2 min = dictionary.Keys.Aggregate(Int2.maxValue, (current, position) => current.Min(position));
	// Int2 max = dictionary.Keys.Aggregate(Int2.minValue, (current, position) => current.Max(position));
	//
	// Int2 size = max - min + Int2.one;
	// int[,] grid = new int[size.x, size.y];
	//
	// foreach (Int2 position in size.Loop())
	// {
	// 	if (!dictionary.TryGetValue(position + min, out int index)) continue;
	// 	grid[position.x, position.y] = index;
	// }
	//
	// for (int y = size.x - 1; y >= 0; y--)
	// {
	// 	for (int x = 0; x < size.y; x++)
	// 	{
	// 		Console.Write(grid[x, y]);
	// 		Console.Write('\t');
	// 	}
	//
	// 	Console.WriteLine();
	// }
}