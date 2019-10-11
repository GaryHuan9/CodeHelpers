using UnityEngine;

namespace CodeHelpers.MeshHelpers.Combinations
{
	public readonly struct MeshAndMatrix
	{
		public MeshAndMatrix(Mesh mesh, Matrix4x4 matrix, byte subMeshOffset = 0)
		{
			this.mesh = mesh;
			this.matrix = matrix;

			this.subMeshOffset = subMeshOffset;
		}

		public readonly Mesh mesh;
		public readonly Matrix4x4 matrix;

		public readonly byte subMeshOffset;
	}
}