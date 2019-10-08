using System.Collections.Generic;
using UnityEngine;

namespace CodeHelpers.MeshHelpers
{
	public static class Utility
	{
		static readonly List<Vector3> vertexCache   = new List<Vector3>();
		static readonly List<int>     triangleCache = new List<int>();

		/// <summary>
		/// Returns what separated part each triangle is in.
		/// The returning array's index will be the triangle index
		/// (one index identifying 3 indices in triangles)
		/// and its values identify the separated parts
		/// </summary>
		// public int[] GetMeshTriangleIndexPart(Mesh mesh, float epsilon = CodeHelper.epsilon)
		// {
		// 	mesh.GetVertices(vertexCache);
		// 	mesh.GetTriangles(triangleCache, 0); //TODO Worry about other sub meshes
		//
		// 	//Preprocess data
		// 	HashSet<>
		//
		// 	int[] result = new int[triangleCache.Count / 3]; //Triangle indices
		// }

		class VertexComparer : IEqualityComparer<Vector3>
		{
			public VertexComparer(float epsilon) => epsilonSquared = epsilon * epsilon;

			readonly float epsilonSquared;

			public bool Equals(Vector3 x, Vector3 y) => (x - y).sqrMagnitude <= epsilonSquared;
			public int GetHashCode(Vector3 obj) => obj.GetHashCode();
		}
	}
}