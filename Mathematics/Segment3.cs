namespace CodeHelpers.Mathematics
{
	public readonly struct Segment3
	{
		public Segment3(Float3 point0, Float3 point1)
		{
			this.point0 = point0;
			this.point1 = point1;
		}

		public readonly Float3 point0;
		public readonly Float3 point1;

		public Float3 Min => Float3.Min(point0, point1);
		public Float3 Max => Float3.Max(point0, point1);

		public float Length => Float3.Distance(point0, point1);
		public double LengthDouble => Float3.DistanceDouble(point0, point1);

		public float SquaredLength => Float3.SquaredDistance(point0, point1);
		public double SquaredLengthDouble => Float3.SquaredDistance(point0, point1);

		public Float3 LengthVector => point1 - point0;
		public Float3 Direction => LengthVector.Normalized;

		public Float3 RandomOnSegment => Lerp((float)RandomHelper.Value);

		public Float3 Lerp(float value) => Float3.Lerp(point0, point1, value);
		public Float3 LerpUnclamped(float value) => Float3.Lerp(point0, point1, value);

		/// <summary>
		/// Get a point on this line that is the closest to <paramref name="point"/>. This value is clamped.
		/// </summary>
		public Float3 GetClosestPoint(Float3 point)
		{
			Float3 direction = LengthVector.Normalized;
			return point0 + direction * Float3.Dot(point - point0, direction).Clamp(0f, 1f);
		}

		/// <summary>
		/// Get a point on this line that is the closest to <paramref name="point"/>. This point is unclamped.
		/// </summary>
		public Float3 GetClosestPointUnclamped(Float3 point)
		{
			Float3 direction = LengthVector.Normalized;
			return point0 + direction * Float3.Dot(point - point0, direction);
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
			return Float3.Dot(point - point0, LengthVector / length) / length;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 17;

				hash = hash * 31 + point0.GetHashCode();
				hash = hash * 31 + point1.GetHashCode();

				return hash;
			}
		}

		public override bool Equals(object obj) => obj is Segment3 segment && Equals(segment);
		public bool Equals(in Segment3 other) => point0.Equals(other.point0) && point1.Equals(other.point1);

		public override string ToString() => $"(Point1: {point0}, Point2: {point1})";
	}
}