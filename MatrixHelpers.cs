using System;
using UnityEngine;

namespace CodeHelpers
{
	public static class MatrixHelper
	{
		/// <summary>
		/// Returns the position.
		/// </summary>
		public static Vector3 GetPosition(this Matrix4x4 matrix) => matrix.GetColumn(3);

		/// <summary>
		/// Returns the rotation.
		/// </summary>
		public static Quaternion GetRotation(this Matrix4x4 matrix) => Quaternion.LookRotation(matrix.GetColumn(2), matrix.GetColumn(1));

		/// <summary>
		/// Returns the scale. NOTE: This does not work with negative scales.
		/// </summary>
		public static Vector3 GetScale(this Matrix4x4 matrix) => new Vector3(matrix.GetColumn(0).magnitude, matrix.GetColumn(1).magnitude, matrix.GetColumn(2).magnitude);
	}
}