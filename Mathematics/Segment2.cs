using System;

namespace CodeHelpers.Mathematics
{
	public readonly struct Segment2 : IEquatable<Segment2>
	{
		public Segment2(Float2 point0, Float2 point1)
		{
			this.point0 = point0;
			this.point1 = point1;
		}

		public readonly Float2 point0;
		public readonly Float2 point1;

		public Float2 Min => Float2.Min(point0, point1);
		public Float2 Max => Float2.Max(point0, point1);

		public float Length => Float2.Distance(point0, point1);
		public double LengthDouble => Float2.DistanceDouble(point0, point1);

		public float SquaredLength => Float2.SquaredDistance(point0, point1);
		public double SquaredLengthDouble => Float2.SquaredDistance(point0, point1);

		public Float2 LengthVector => point1 - point0;
		public Float2 Direction => LengthVector.Normalized;

		public float Slope => LengthVector.y / LengthVector.x;
		public float YIntercept => point0.y - point0.x * Slope;

		public Float2 RandomOnSegment => Lerp((float)RandomHelper.Value);

		public Float2 Lerp(float value) => Float2.Lerp(point0, point1, value);
		public Float2 LerpUnclamped(float value) => Float2.Lerp(point0, point1, value);

		public Float2 GetPointFromX(float x) => GetPointFromXUnclamped(x.Clamp(Math.Min(point0.x, point1.x), Math.Max(point0.x, point1.x)));
		public Float2 GetPointFromXUnclamped(float x) => new Float2(x, Slope * x + YIntercept);

		public Float2 GetPointFromY(float y) => GetPointFromYUnclamped(y.Clamp(Math.Min(point0.y, point1.y), Math.Max(point0.y, point1.y)));
		public Float2 GetPointFromYUnclamped(float y) => new Float2((y - YIntercept) / Slope, y);

		/// <summary>
		/// Get a point on this line that is the closest to <paramref name="point"/>. This value is clamped.
		/// </summary>
		public Float2 GetClosestPoint(Float2 point)
		{
			Float2 direction = LengthVector.Normalized;
			return point0 + direction * Float2.Dot(point - point0, direction).Clamp();
		}

		/// <summary>
		/// Get a point on this line that is the closest to <paramref name="point"/>. This point is unclamped.
		/// </summary>
		public Float2 GetClosestPointUnclamped(Float2 point)
		{
			Float2 direction = LengthVector.Normalized;
			return point0 + direction * Float2.Dot(point - point0, direction);
		}

		/// <summary>
		/// Get the inverse lerp point that is the closest to <paramref name="point"/>. This point is clamped.
		/// </summary>
		public float ClosestInverseLerp(Float2 point) => ClosestInverseLerpUnclamped(point).Clamp();

		/// <summary>
		/// Get the inverse lerp point that is the closest to <paramref name="point"/>. This point is unclamped.
		/// </summary>
		public float ClosestInverseLerpUnclamped(Float2 point)
		{
			float length = Length; //Use this so we don't need to calculate it twice.
			return Float2.Dot(point - point0, LengthVector / length) / length;
		}

		/// <summary>
		/// Tries to intersect <paramref name="other"/> with this.
		/// Returns true if intersection found, otherwise false.
		/// </summary>
		public bool TryIntersect(Segment2 other, out Float2 intersection)
		{
			if (Equals(other))
			{
				intersection = default;
				return false;
			}

			float x = (other.YIntercept - YIntercept) / (Slope - other.Slope);
			bool successful = Math.Min(point0.x, point1.x) <= x && x <= Math.Max(point0.x, point1.x);

			intersection = successful ? GetPointFromX(x) : default;
			return successful;
		}

		/// <summary>
		/// Intersects <paramref name="other"/> with this.
		/// Throws exception if no intersection found.
		/// </summary>
		public Float2 Intersect(Segment2 other) => TryIntersect(other, out Float2 intersection) ? intersection : throw ExceptionHelper.Invalid(nameof(other), other, "does not intersect with this!");

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

		public override bool Equals(object obj) => obj is Segment2 segment && Equals(segment);
		public bool Equals(Segment2 other) => point0.Equals(other.point0) && point1.Equals(other.point1);

		public override string ToString() => $"(Point1: {point0}, Point2: {point1})";
	}
}