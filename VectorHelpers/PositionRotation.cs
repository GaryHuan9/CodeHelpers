using UnityEngine;

namespace CodeHelpers.VectorHelpers
{
	public readonly struct PositionRotation
	{
		public PositionRotation(Vector3 position, Quaternion rotation)
		{
			this.position = position;
			this.rotation = rotation;
		}

		public readonly Vector3 position;
		public readonly Quaternion rotation;

		/// <summary>
		/// Returns the mirrored version of this PositionRotation by <paramref name="direction"/>
		/// </summary>
		public PositionRotation GetMirror(Direction direction)
		{
			Vector3Int mirror = direction.ToVector3().Abs() * -2 + Vector3Int.one;
			rotation.ToAngleAxis(out float angle, out Vector3 axis);

			return new PositionRotation(Vector3.Scale(position, mirror), Quaternion.AngleAxis(-angle, Vector3.Scale(axis, mirror)));
		}
	}
}