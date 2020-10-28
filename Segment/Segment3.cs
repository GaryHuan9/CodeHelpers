#if CODEHELPERS_UNITY

using UnityEngine;

namespace CodeHelpers.Segment
{
	public readonly struct Segment3
	{
		public Segment3(Vector3 point1, Vector3 point2)
		{
			this.point1 = point1;
			this.point2 = point2;
		}

		public Segment3(float point1X, float point1Y, float point1Z, float point2X, float point2Y, float point2Z)
		{
			point1 = new Vector3(point1X, point1Y, point1Z);
			point2 = new Vector3(point2X, point2Y, point2Z);
		}

		public readonly Vector3 point1;
		public readonly Vector3 point2;

		public Vector3 Min => Vector3.Min(point1, point2);
		public Vector3 Max => Vector3.Max(point1, point2);

		public float Length => LengthVector.magnitude;
		public Vector3 LengthVector => point2 - point1;

		public Vector3 Direction => LengthVector.Normalized;

		public Vector3 RandomOnSegment => Lerp((float)RandomHelper.Value);

		public Vector3 Lerp(float value) => Vector3.Lerp(point1, point2, value);
		public Vector3 LerpUnclamped(float value) => Vector3.LerpUnclamped(point1, point2, value);

		/// <summary>
		/// Get a point on this line that is the closest to <paramref name="point"/>. This value is clamped.
		/// </summary>
		public Vector3 GetClosestPoint(Vector3 point)
		{
			Vector3 direction = LengthVector.Normalized;
			return point1 + direction * Mathf.Clamp01(Vector3.Dot(point - point1, direction));
		}

		/// <summary>
		/// Get a point on this line that is the closest to <paramref name="point"/>. This point is unclamped.
		/// </summary>
		public Vector3 GetClosestPointUnclamped(Vector3 point)
		{
			Vector3 direction = LengthVector.Normalized;
			return point1 + direction * Vector3.Dot(point - point1, direction);
		}

		/// <summary>
		/// Get the unlerp that is the closest to <paramref name="point"/>. This point is clamped.
		/// </summary>
		public float ClosestUnlerp(Vector3 point) => Mathf.Clamp01(ClosestUnlerpUnclamped(point));

		/// <summary>
		/// Get the unlerp that is the closest to <paramref name="point"/>. This point is unclamped.
		/// </summary>
		public float ClosestUnlerpUnclamped(Vector3 point)
		{
			float length = Length; //Use this so we don't need to calculate it twice.
			return Vector3.Dot(point - point1, LengthVector / length) / length;
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

		public override bool Equals(object obj) => obj is Segment2 segment && Equals(segment);
		public bool Equals(Segment2 other) => point1.Equals(other.point1) && point2.Equals(other.point2);

		public override string ToString() => $"(Point1: {point1}, Point2: {point2})";
	}
}

#endif