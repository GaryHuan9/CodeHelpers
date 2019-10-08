using System;
using UnityEngine;

namespace CodeHelpers.Classed
{
	[Serializable]
	public class ClassedStruct<T> where T : struct
	{
		[SerializeField] T value;

		public T Value { get { return value; } set { this.value = value; } }

		public override bool Equals(object obj) => obj is ClassedStruct<T> && ((ClassedStruct<T>)obj) == this;
		public bool Equals(ClassedStruct<T> other) => other == this;

		public static bool operator ==(ClassedStruct<T> nullable1, ClassedStruct<T> nullable2) => ReferenceEquals(nullable1, nullable2) || (!ReferenceEquals(nullable1, null) && !ReferenceEquals(nullable2, null) && nullable1.Value.Equals(nullable2.Value));
		public static bool operator !=(ClassedStruct<T> nullable1, ClassedStruct<T> nullable2) => !(nullable1 == nullable2);

		public override int GetHashCode() => Value.GetHashCode();
		public override string ToString() => Value.ToString();

		public static implicit operator ClassedStruct<T>(T value) => new ClassedStruct<T> { value = value };
		public static implicit operator T(ClassedStruct<T> value) => value.Value;
	}

	[Serializable] public class ClassedInt : ClassedStruct<int> { };
	[Serializable] public class ClassedLong : ClassedStruct<long> { };
	[Serializable] public class ClassedShort : ClassedStruct<short> { };
	[Serializable] public class ClassedBool : ClassedStruct<bool> { };
	[Serializable] public class ClassedFloat : ClassedStruct<float> { };
	[Serializable] public class ClassedDouble : ClassedStruct<double> { };
	[Serializable] public class ClassedDecimal : ClassedStruct<decimal> { };

	[Serializable] public class ClassedVector3 : ClassedStruct<Vector3> { };
	[Serializable] public class ClassedVector2 : ClassedStruct<Vector2> { };
	[Serializable] public class ClassedVector4 : ClassedStruct<Vector4> { };
	[Serializable] public class ClassedVector3Int : ClassedStruct<Vector3Int> { };
	[Serializable] public class ClassedVector2Int : ClassedStruct<Vector2Int> { };

	[Serializable] public class ClassedMinMax : ClassedStruct<MinMax> { };
	[Serializable] public class ClassedMinMaxInt : ClassedStruct<MinMaxInt> { };

	[Serializable] public class ClassedBounds : ClassedStruct<Bounds> { };
	[Serializable] public class ClassedBoundsInt : ClassedStruct<BoundsInt> { };
	[Serializable] public class ClassedBoundingSphere : ClassedStruct<BoundingSphere> { };

	[Serializable] public class ClassedRect : ClassedStruct<Rect> { };
	[Serializable] public class ClassedRectInt : ClassedStruct<RectInt> { };
}
