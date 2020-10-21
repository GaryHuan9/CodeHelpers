#if CODEHELPERS_UNITY

using UnityEngine;

namespace CodeHelpers.Unity.Meshes.Combinations
{
	public readonly struct MeshMatrix
	{
		public MeshMatrix(Mesh mesh, Matrix4x4 matrix, byte subMeshOffset = 0)
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

#endif