using System;

namespace CodeHelpers.Mathematics
{
	public readonly struct Segment3 : IEquatable<Segment3>
	{
		public Segment3(in Float3 point0, in Float3 point1)
		{
			this.point0 = point0;
			this.point1 = point1;
		}

		public readonly Float3 point0;
		public readonly Float3 point1;

		public Float3 LengthVector => point1 - point0;
		public Float3 Direction => LengthVector.Normalized;

		public float Length => LengthVector.Magnitude;
		public double LengthDouble => LengthVector.MagnitudeDouble;

		public float SquaredLength => LengthVector.SquaredMagnitude;
		public double SquaredLengthDouble => LengthVector.SquaredMagnitudeDouble;

		/// <summary>
		/// Linearly interpolates between <see cref="point0"/> and <see cref="point1"/> based on <paramref name="value"/>.
		/// NOTE: <paramref name="value"/> has a normal scale of between zero and one and does not need to be clamped.
		/// </summary>
		public Float3 Lerp(float value) => Float3.Lerp(point0, point1, value);

		/// <summary>
		/// Get the inverse lerp value to a point that is the closest to <paramref name="point"/>.
		/// NOTE: this value is not clamped; if needed you can clamp the value between 0 and 1.
		/// </summary>
		public float InverseLerp(in Float3 point)
		{
			Float3 length = LengthVector;
			float lengthR = 1f / length.Magnitude;
			return Float3.Dot(point - point0, length * lengthR) * lengthR;
		}

		/// <summary>
		/// Get the unclamped inverse lerp to the point on this <see cref="Segment3"/> that is the closest to <paramref name="point"/>.
		/// </summary>
		public float ClosestInverseLerp(in Float3 point)
		{
			Float3 length = LengthVector;
			float lengthR = 1f / length.Magnitude;
			return Float3.Dot(point - point0, length * lengthR) * lengthR;
		}

		public bool Equals(in Segment3 other) => point0 == other.point0 && point1 == other.point1;
		public override bool Equals(object obj) => obj is Segment3 other && Equals(other);

		bool IEquatable<Segment3>.Equals(Segment3 other) => Equals(other);

		public override int GetHashCode()
		{
			unchecked
			{
				return (point0.GetHashCode() * 397) ^ point1.GetHashCode();
			}
		}

		public override string ToString() => $"{point0} - {point1}";
	}
}