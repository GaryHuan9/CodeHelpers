#if CODEHELPERS_UNITY

using System.Collections.Generic;
using UnityEngine;

namespace CodeHelpers.Unity.Meshes.Collections
{
	/// <summary> This is just a struct that stores variables of a mesh, used for threading </summary>
	public readonly struct MeshThreadedData
	{
		public MeshThreadedData(List<Vector3> vertices, Dictionary<int, List<int>> triangles, List<Vector2> uvs = null, List<Vector3> normals = null)
		{
			this.vertices = vertices;
			this.triangles = triangles;
			this.uvs = uvs;
			this.normals = normals;
		}

		//Info
		readonly List<Vector3> vertices;
		readonly Dictionary<int, List<int>> triangles;

		readonly List<Vector2> uvs;
		readonly List<Vector3> normals;

		public void Apply(Mesh mesh, bool betterRecalculateNormals = true)
		{
			mesh.Clear();

			mesh.SetVertices(vertices);
			foreach (var pair in triangles) mesh.SetTriangles(pair.Value, pair.Key);

			if (uvs != null) mesh.SetUVs(0, uvs);

			if (normals != null) mesh.SetNormals(normals);                   //Not that fast but not slow
			else if (betterRecalculateNormals) mesh.RecalculateNormals(30f); //Slowest
			else mesh.RecalculateNormals();                                  //Fastest

			mesh.RecalculateBounds();
		}
	}
}

#endif