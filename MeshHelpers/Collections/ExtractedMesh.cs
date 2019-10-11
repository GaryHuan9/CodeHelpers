using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeHelpers.MeshHelpers.Collections
{
	public class ExtractedMesh
	{
		public ExtractedMesh(Mesh source)
		{
			vertices = new List<Vector3>(source.vertexCount);
			uvs = new List<Vector2>(source.vertexCount);

			source.GetVertices(vertices);
			source.GetUVs(0, uvs);

			triangles = new List<Triangle>();
			var submeshTriangles = new List<int>();

			for (int i = 0; i < source.subMeshCount; i++)
			{
				source.GetTriangles(submeshTriangles, i);

				for (int j = 0; j < submeshTriangles.Count; j += 3)
				{
					triangles.Add
					(
						new Triangle
						(
							submeshTriangles[j],
							submeshTriangles[j + 1],
							submeshTriangles[j + 2], i
						)
					);
				}

				submeshTriangles.Clear();
			}
		}

		readonly List<Vector3> vertices;
		readonly List<Triangle> triangles;
		readonly List<Vector2> uvs;

		/**
		 * Returns all of the unique/non-connected meshes in this mesh
		 * This value is not cached, so it will generate every time you invoke the method
		 */
		public List<ExtractedMesh> Unique()
		{
			var results = new List<ExtractedMesh>();
			var uniqueVertices = new Dictionary<Vector3, int>(VertexComparer.Instance);

			throw new NotImplementedException();
		}

		public readonly struct Triangle
		{
			public Triangle(int vertex1, int vertex2, int vertex3, int submeshIndex)
			{
				this.vertex1 = vertex1;
				this.vertex2 = vertex2;
				this.vertex3 = vertex3;

				this.submeshIndex = submeshIndex;
			}

			readonly int vertex1;
			readonly int vertex2;
			readonly int vertex3;

			readonly int submeshIndex;
		}
	}
}