#if CODEHELPERS_UNITY

using System;
using CodeHelpers.Vectors;
using UnityEngine;

namespace CodeHelpers.Unity.Vectors
{
	[Serializable]
	public class Float3Unity : IEquatable<Float3Unity>
	{
		public Float3Unity(Float3 value) => Value = value;

		[SerializeField] float x;
		[SerializeField] float y;
		[SerializeField] float z;

		public Float3 Value
		{
			get => new Float3(x, y, z);
			set
			{
				x = value.x;
				y = value.y;
				z = value.z;
			}
		}

		public static implicit operator Float3(Float3Unity value) => value.Value;
		public static explicit operator Float3Unity(Float3 value) => new Float3Unity(value);

		public override bool Equals(object obj) => obj is Float3Unity value && Equals(value);
		public bool Equals(Float3Unity value) => value != null && value.Value == Value;

		public override int GetHashCode() => Value.GetHashCode();
		public override string ToString() => Value.ToString();
	}

	[Serializable]
	public class Int3Unity : IEquatable<Int3Unity>
	{
		public Int3Unity(Int3 value) => Value = value;

		[SerializeField] int x;
		[SerializeField] int y;
		[SerializeField] int z;

		public Int3 Value
		{
			get => new Int3(x, y, z);
			set
			{
				x = value.x;
				y = value.y;
				z = value.z;
			}
		}

		public static implicit operator Int3(Int3Unity value) => value.Value;
		public static explicit operator Int3Unity(Int3 value) => new Int3Unity(value);

		public override bool Equals(object obj) => obj is Int3Unity value && Equals(value);
		public bool Equals(Int3Unity value) => value != null && value.Value == Value;

		public override int GetHashCode() => Value.GetHashCode();
		public override string ToString() => Value.ToString();
	}

	[Serializable]
	public class Float2Unity : IEquatable<Float2Unity>
	{
		public Float2Unity(Float2 value) => Value = value;

		[SerializeField] float x;
		[SerializeField] float y;

		public Float2 Value
		{
			get => new Float2(x, y);
			set
			{
				x = value.x;
				y = value.y;
			}
		}

		public static implicit operator Float2(Float2Unity value) => value.Value;
		public static explicit operator Float2Unity(Float2 value) => new Float2Unity(value);

		public override bool Equals(object obj) => obj is Float2Unity value && Equals(value);
		public bool Equals(Float2Unity value) => value != null && value.Value == Value;

		public override int GetHashCode() => Value.GetHashCode();
		public override string ToString() => Value.ToString();
	}

	[Serializable]
	public class Int2Unity : IEquatable<Int2Unity>
	{
		public Int2Unity(Int2 value) => Value = value;

		[SerializeField] int x;
		[SerializeField] int y;

		public Int2 Value
		{
			get => new Int2(x, y);
			set
			{
				x = value.x;
				y = value.y;
			}
		}

		public static implicit operator Int2(Int2Unity value) => value.Value;
		public static explicit operator Int2Unity(Int2 value) => new Int2Unity(value);

		public override bool Equals(object obj) => obj is Int2Unity value && Equals(value);
		public bool Equals(Int2Unity value) => value != null && value.Value == Value;

		public override int GetHashCode() => Value.GetHashCode();
		public override string ToString() => Value.ToString();
	}
}

#endif