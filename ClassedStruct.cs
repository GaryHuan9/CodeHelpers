using System;
using UnityEngine;

namespace CodeHelpers.Classed
{
	public class ClassedStruct<T> where T : struct
	{
		public T Value { get; set; }

		public override bool Equals(object obj) => obj is ClassedStruct<T> value && value == this;
		public bool Equals(ClassedStruct<T> other) => other == this;

		public static bool operator ==(ClassedStruct<T> classed1, ClassedStruct<T> classed2) => ReferenceEquals(classed1, classed2) || (!ReferenceEquals(classed1, null) && !ReferenceEquals(classed2, null) && classed1.Value.Equals(classed2.Value));
		public static bool operator !=(ClassedStruct<T> classed1, ClassedStruct<T> classed2) => !(classed1 == classed2);

		public override int GetHashCode() => Value.GetHashCode();
		public override string ToString() => Value.ToString();

		public static implicit operator ClassedStruct<T>(T value) => new ClassedStruct<T> {Value = value};
		public static implicit operator T(ClassedStruct<T> value) => value.Value;
	}

	public class ClassedInt : ClassedStruct<int> { };
	public class ClassedLong : ClassedStruct<long> { };
	public class ClassedShort : ClassedStruct<short> { };
	public class ClassedBool : ClassedStruct<bool> { };
	public class ClassedFloat : ClassedStruct<float> { };
	public class ClassedDouble : ClassedStruct<double> { };
	public class ClassedDecimal : ClassedStruct<decimal> { };

	public class ClassedVector3 : ClassedStruct<Vector3> { };
	public class ClassedVector2 : ClassedStruct<Vector2> { };
	public class ClassedVector4 : ClassedStruct<Vector4> { };
	public class ClassedVector3Int : ClassedStruct<Vector3Int> { };
	public class ClassedVector2Int : ClassedStruct<Vector2Int> { };

	public class ClassedMinMax : ClassedStruct<MinMax> { };
	public class ClassedMinMaxInt : ClassedStruct<MinMaxInt> { };

	public class ClassedBounds : ClassedStruct<Bounds> { };
	public class ClassedBoundsInt : ClassedStruct<BoundsInt> { };
	public class ClassedBoundingSphere : ClassedStruct<BoundingSphere> { };

	public class ClassedRect : ClassedStruct<Rect> { };
	public class ClassedRectInt : ClassedStruct<RectInt> { };
}