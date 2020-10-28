using CodeHelpers.Vectors;

namespace CodeHelpers.Segment
{
	public readonly struct Segment3
	{
		public Segment3(Float3 point1, Float3 point2)
		{
			this.point1 = point1;
			this.point2 = point2;
		}

		public readonly Float3 point1;
		public readonly Float3 point2;

		public Float3 Min => Float3.Min(point1, point2);
		public Float3 Max => Float3.Max(point1, point2);

		public float Length => LengthVector.Magnitude;
		public Float3 LengthVector => point2 - point1;

		public Float3 Direction => LengthVector.Normalized;

		public Float3 RandomOnSegment => Lerp((float)RandomHelper.Value);

		public Float3 Lerp(float value) => Float3.Lerp(point1, point2, value);
		public Float3 LerpUnclamped(float value) => Float3.Lerp(point1, point2, value);

		/// <summary>
		/// Get a point on this line that is the closest to <paramref name="point"/>. This value is clamped.
		/// </summary>
		public Float3 GetClosestPoint(Float3 point)
		{
			Float3 direction = LengthVector.Normalized;
			return point1 + direction * Float3.Dot(point - point1, direction).Clamp(0f, 1f);
		}

		/// <summary>
		/// Get a point on this line that is the closest to <paramref name="point"/>. This point is unclamped.
		/// </summary>
		public Float3 GetClosestPointUnclamped(Float3 point)
		{
			Float3 direction = LengthVector.Normalized;
			return point1 + direction * Float3.Dot(point - point1, direction);
		}

		/// <summary>
		/// Get the inverse lerp point that is the closest to <paramref name="point"/>. This point is clamped.
		/// </summary>
		public float ClosestInverseLerp(Float3 point) => ClosestInverseLerpUnclamped(point).Clamp(0f, 1f);

		/// <summary>
		/// Get the inverse lerp point that is the closest to <paramref name="point"/>. This point is unclamped.
		/// </summary>
		public float ClosestInverseLerpUnclamped(Float3 point)
		{
			float length = Length; //Use this so we don't need to calculate it twice.
			return Float3.Dot(point - point1, LengthVector / length) / length;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 17;

				hash = hash * 31 + point1.GetHashCode();
				hash = hash * 31 + point2.GetHashCode();

				return hash;
			}
		}

		public override bool Equals(object obj) => obj is Segment3 segment && Equals(segment);
		public bool Equals(in Segment3 other) => point1.Equals(other.point1) && point2.Equals(other.point2);

		public override string ToString() => $"(Point1: {point1}, Point2: {point2})";
	}
}