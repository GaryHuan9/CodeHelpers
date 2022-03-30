using System.Collections.ObjectModel;
using System.Linq;
using CodeHelpers.Mathematics;

namespace CodeHelpers.Packed
{
	public partial struct Float2
	{
		public static Float2 Right => new Float2(1f, 0f);
		public static Float2 Left => new Float2(-1f, 0f);

		public static Float2 Up => new Float2(0f, 1f);
		public static Float2 Down => new Float2(0f, -1f);

		public static Float2 Zero => new Float2(0f, 0f);

		public static Float2 One => new Float2(1f, 1f);
		public static Float2 NegativeOne => new Float2(-1f, -1f);

		public static Float2 Half => new Float2(0.5f, 0.5f);
		public static Float2 NegativeHalf => new Float2(-0.5f, -0.5f);

		public static Float2 MaxValue => new Float2(float.MaxValue, float.MaxValue);
		public static Float2 MinValue => new Float2(float.MinValue, float.MinValue);

		public static Float2 PositiveInfinity => new Float2(float.PositiveInfinity, float.PositiveInfinity);
		public static Float2 NegativeInfinity => new Float2(float.NegativeInfinity, float.NegativeInfinity);

		public static Float2 Epsilon => new Float2(Scalars.Epsilon, Scalars.Epsilon);
		public static Float2 NaN => new Float2(float.NaN, float.NaN);
	}

	public partial struct Float3
	{
		public static Float3 Right => new Float3(1f, 0f, 0f);
		public static Float3 Left => new Float3(-1f, 0f, 0f);

		public static Float3 Up => new Float3(0f, 1f, 0f);
		public static Float3 Down => new Float3(0f, -1f, 0f);

		public static Float3 Forward => new Float3(0f, 0f, 1f);
		public static Float3 Backward => new Float3(0f, 0f, -1f);

		public static Float3 Zero => new Float3(0f, 0f, 0f);

		public static Float3 One => new Float3(1f, 1f, 1f);
		public static Float3 NegativeOne => new Float3(-1f, -1f, -1f);

		public static Float3 Half => new Float3(0.5f, 0.5f, 0.5f);
		public static Float3 NegativeHalf => new Float3(-0.5f, -0.5f, -0.5f);

		public static Float3 MaxValue => new Float3(float.MaxValue, float.MaxValue, float.MaxValue);
		public static Float3 MinValue => new Float3(float.MinValue, float.MinValue, float.MinValue);

		public static Float3 PositiveInfinity => new Float3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
		public static Float3 NegativeInfinity => new Float3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

		public static Float3 Epsilon => new Float3(Scalars.Epsilon, Scalars.Epsilon, Scalars.Epsilon);
		public static Float3 NaN => new Float3(float.NaN, float.NaN, float.NaN);
	}

	public partial struct Float4
	{
		public static Float4 Right => new Float4(1f, 0f, 0f, 0f);
		public static Float4 Left => new Float4(-1f, 0f, 0f, 0f);

		public static Float4 Up => new Float4(0f, 1f, 0f, 0f);
		public static Float4 Down => new Float4(0f, -1f, 0f, 0f);

		public static Float4 Forward => new Float4(0f, 0f, 1f, 0f);
		public static Float4 Backward => new Float4(0f, 0f, -1f, 0f);

		public static Float4 Ana => new Float4(0f, 0f, 0f, 1f);
		public static Float4 Kata => new Float4(0f, 0f, 0f, -1f);

		public static Float4 Zero => new Float4(0f, 0f, 0f, 0f);

		public static Float4 One => new Float4(1f, 1f, 1f, 1f);
		public static Float4 NegativeOne => new Float4(-1f, -1f, -1f, 1f);

		public static Float4 Half => new Float4(0.5f, 0.5f, 0.5f, 0f);
		public static Float4 NegativeHalf => new Float4(-0.5f, -0.5f, -0.5f, 0f);

		public static Float4 MaxValue => new Float4(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
		public static Float4 MinValue => new Float4(float.MinValue, float.MinValue, float.MinValue, float.MinValue);

		public static Float4 PositiveInfinity => new Float4(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
		public static Float4 NegativeInfinity => new Float4(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

		public static Float4 Epsilon => new Float4(Scalars.Epsilon, Scalars.Epsilon, Scalars.Epsilon, Scalars.Epsilon);
		public static Float4 NaN => new Float4(float.NaN, float.NaN, float.NaN, float.NaN);
	}

	public partial struct Int2
	{
		public static Int2 Right => new Int2(1, 0);
		public static Int2 Left => new Int2(-1, 0);

		public static Int2 Up => new Int2(0, 1);
		public static Int2 Down => new Int2(0, -1);

		public static Int2 One => new Int2(1, 1);
		public static Int2 Zero => new Int2(0, 0);
		public static Int2 NegativeOne => new Int2(-1, -1);

		public static Int2 MaxValue => new Int2(int.MaxValue, int.MaxValue);
		public static Int2 MinValue => new Int2(int.MinValue, int.MinValue);

		public static readonly ReadOnlyCollection<Int2> units4 = new ReadOnlyCollection<Int2>
		(
			new[]
			{
				new Int2(0, 0), new Int2(1, 0),
				new Int2(0, 1), new Int2(1, 1)
			}
		);

		public static readonly ReadOnlyCollection<Int2> edges4 = new ReadOnlyCollection<Int2>
		(
			new[]
			{
				new Int2(1, 0), new Int2(0, 1),
				new Int2(-1, 0), new Int2(0, -1)
			}
		);

		public static readonly ReadOnlyCollection<Int2> vertices4 = new ReadOnlyCollection<Int2>
		(
			new[]
			{
				new Int2(1, 1), new Int2(-1, 1),
				new Int2(-1, -1), new Int2(1, -1)
			}
		);

		public static readonly ReadOnlyCollection<Int2> edgesVertices8 = new ReadOnlyCollection<Int2>(edges4.Concat(vertices4).ToArray());
	}

	public partial struct Int3
	{
		public static Int3 Right => new Int3(1, 0, 0);
		public static Int3 Left => new Int3(-1, 0, 0);

		public static Int3 Up => new Int3(0, 1, 0);
		public static Int3 Down => new Int3(0, -1, 0);

		public static Int3 Forward => new Int3(0, 0, 1);
		public static Int3 Backward => new Int3(0, 0, -1);

		public static Int3 One => new Int3(1, 1, 1);
		public static Int3 Zero => new Int3(0, 0, 0);
		public static Int3 NegativeOne => new Int3(-1, -1, -1);

		public static Int3 MaxValue => new Int3(int.MaxValue, int.MaxValue, int.MaxValue);
		public static Int3 MinValue => new Int3(int.MinValue, int.MinValue, int.MinValue);

		public static readonly ReadOnlyCollection<Int3> units8 = new ReadOnlyCollection<Int3>
		(
			new[]
			{
				new Int3(0, 0, 0), new Int3(1, 0, 0), new Int3(0, 0, 1), new Int3(1, 0, 1),
				new Int3(0, 1, 0), new Int3(1, 1, 0), new Int3(0, 1, 1), new Int3(1, 1, 1)
			}
		);

		public static readonly ReadOnlyCollection<Int3> faces6 = new ReadOnlyCollection<Int3>
		(
			new[]
			{
				new Int3(1, 0, 0), new Int3(-1, 0, 0),
				new Int3(0, 1, 0), new Int3(0, -1, 0),
				new Int3(0, 0, 1), new Int3(0, 0, -1)
			}
		);

		public static readonly ReadOnlyCollection<Int3> vertices8 = new ReadOnlyCollection<Int3>
		(
			new[]
			{
				new Int3(1, 1, 1), new Int3(-1, 1, 1), new Int3(1, 1, -1), new Int3(-1, 1, -1),
				new Int3(1, -1, 1), new Int3(-1, -1, 1), new Int3(1, -1, -1), new Int3(-1, -1, -1)
			}
		);

		public static readonly ReadOnlyCollection<Int3> edges12 = new ReadOnlyCollection<Int3>
		(
			new[]
			{
				new Int3(1, 1, 0), new Int3(0, 1, 1), new Int3(-1, 1, 0), new Int3(0, 1, -1),
				new Int3(1, 0, 1), new Int3(-1, 0, 1), new Int3(-1, 0, -1), new Int3(1, 0, -1),
				new Int3(1, -1, 0), new Int3(0, -1, 1), new Int3(-1, -1, 0), new Int3(0, -1, -1)
			}
		);

		public static readonly ReadOnlyCollection<Int3> facesVertices14 = new ReadOnlyCollection<Int3>(faces6.Concat(vertices8).ToArray());
		public static readonly ReadOnlyCollection<Int3> facesEdges18 = new ReadOnlyCollection<Int3>(faces6.Concat(edges12).ToArray());
		public static readonly ReadOnlyCollection<Int3> verticesEdges20 = new ReadOnlyCollection<Int3>(vertices8.Concat(edges12).ToArray());

		public static readonly ReadOnlyCollection<Int3> facesVerticesEdges26 = new ReadOnlyCollection<Int3>(faces6.Concat(vertices8).Concat(edges12).ToArray());
	}

	public partial struct Int4
	{
		public static Int4 Right { get; } = new Int4(1, 0, 0, 0);
		public static Int4 Left { get; } = new Int4(-1, 0, 0, 0);

		public static Int4 Up { get; } = new Int4(0, 1, 0, 0);
		public static Int4 Down { get; } = new Int4(0, -1, 0, 0);

		public static Int4 Forward { get; } = new Int4(0, 0, 1, 0);
		public static Int4 Backward { get; } = new Int4(0, 0, -1, 0);

		public static Int4 Ana { get; } = new Int4(0, 0, 0, 1);
		public static Int4 Kata { get; } = new Int4(0, 0, 0, -1);

		public static Int4 Zero { get; } = new Int4(0, 0, 0, 0);
		public static Int4 One { get; } = new Int4(1, 1, 1, 1);
		public static Int4 NegativeOne { get; } = new Int4(-1, -1, -1, 1);

		public static Int4 MaxValue { get; } = new Int4(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);
		public static Int4 MinValue { get; } = new Int4(int.MinValue, int.MinValue, int.MinValue, int.MinValue);
	}
}