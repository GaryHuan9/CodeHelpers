#if CODEHELPERS_UNITY //NOTE: Will be rewritten with CodeHelper vector library

using System;
using UnityEngine;

namespace CodeHelpers.Segment
{
	public readonly struct Segment2 : IEquatable<Segment2>
	{
		public Segment2(Vector2 point1, Vector2 point2)
		{
			this.point1 = point1;
			this.point2 = point2;
		}

		public Segment2(float point1X, float point1Y, float point2X, float point2Y)
		{
			point1 = new Vector2(point1X, point1Y);
			point2 = new Vector2(point2X, point2Y);
		}

		public readonly Vector2 point1;
		public readonly Vector2 point2;

		public Vector2 Min => Vector2.Min(point1, point2);
		public Vector2 Max => Vector2.Max(point1, point2);

		public float Length => LengthVector.magnitude;
		public Vector2 LengthVector => point2 - point1;

		public Vector2 Direction => LengthVector.normalized;

		public float Slope => LengthVector.y / LengthVector.x;
		public float YIntercept => point1.y - point1.x * Slope;

		public Vector2 RandomOnSegment => Lerp((float)RandomHelper.Value);

		public Vector2 Lerp(float value) => Vector2.Lerp(point1, point2, value);
		public Vector2 LerpUnclamped(float value) => Vector2.LerpUnclamped(point1, point2, value);

		public Vector2 GetPointFromX(float x) => GetPointFromXUnclamped(Mathf.Clamp(x, Min.x, Max.x));
		public Vector2 GetPointFromXUnclamped(float x) => new Vector2(x, Slope * x + YIntercept);

		public Vector2 GetPointFromY(float y) => GetPointFromYUnclamped(Mathf.Clamp(y, Min.x, Max.x));
		public Vector2 GetPointFromYUnclamped(float y) => new Vector2((y - YIntercept) / Slope, y);

		/// <summary>
		/// Get a point on this line that is the closest to <paramref name="point"/>. This value is clamped.
		/// </summary>
		public Vector2 GetClosestPoint(Vector2 point)
		{
			Vector2 direction = LengthVector.normalized;
			return point1 + direction * Mathf.Clamp01(Vector2.Dot(point - point1, direction));
		}

		/// <summary>
		/// Get a point on this line that is the closest to <paramref name="point"/>. This point is unclamped.
		/// </summary>
		public Vector2 GetClosestPointUnclamped(Vector2 point)
		{
			Vector2 direction = LengthVector.normalized;
			return point1 + direction * Vector2.Dot(point - point1, direction);
		}

		/// <summary>
		/// Get the unlerp that is the closest to <paramref name="point"/>. This point is clamped.
		/// </summary>
		public float ClosestUnlerp(Vector2 point) => Mathf.Clamp01(ClosestUnlerpUnclamped(point));

		/// <summary>
		/// Get the unlerp that is the closest to <paramref name="point"/>. This point is unclamped.
		/// </summary>
		public float ClosestUnlerpUnclamped(Vector2 point)
		{
			float length = Length; //Use this so we don't need to calculate it twice.
			return Vector2.Dot(point - point1, LengthVector / length) / length;
		}

		/// <summary>
		/// Get the intersection point of the current segment to <paramref name="segment"/>. <paramref name="success"/> will be false and return will be (0,0) if the two segments do not intersect.
		/// </summary>
		public Vector2 GetIntersection(Segment2 segment, out bool success)
		{
			if (Equals(segment))
			{
				success = false;
				return Vector2.zero;
			}

			float x = (segment.YIntercept - YIntercept) / (Slope - segment.Slope);

			success = Min.x <= x && x <= Max.x;
			return success ? GetPointFromX(x) : Vector2.zero;
		}

		/// <summary>
		/// Get the intersection point of the current segment to <paramref name="segment"/>. Return will be (0,0) if the two segments do not intersect.
		/// </summary>
		public Vector2 GetIntersection(Segment2 segment) => GetIntersection(segment, out bool successfulness);

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