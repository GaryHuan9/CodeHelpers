#if CODE_HELPERS_UNITY

using CodeHelpers.Mathematics;
using UnityEngine;

namespace CodeHelpers.Unity.Mathematics
{
	public readonly struct PositionRotation
	{
		public PositionRotation(Float3 position, Quaternion rotation)
		{
			this.position = position;
			this.rotation = rotation;
		}

		public readonly Float3 position;
		public readonly Quaternion rotation;

		/// <summary>
		/// Returns the mirrored version of this PositionRotation by <paramref name="direction"/>
		/// </summary>
		public PositionRotation GetMirror(Direction direction)
		{
			Int3 mirror = direction.ToInt3().Absoluted * -2 + Int3.one;
			rotation.ToAngleAxis(out float angle, out Vector3 axis);

			return new PositionRotation(position * mirror, Quaternion.AngleAxis(-angle, axis.C() * mirror));
		}
	}
}

#endif