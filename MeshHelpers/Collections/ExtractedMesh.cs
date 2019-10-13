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

			submeshCount = source.subMeshCount;
		}

		readonly List<Vector3> vertices;
		readonly List<Vector2> uvs;
		readonly List<Triangle> triangles;

		int submeshCount;

		/// <summary>
		/// Combine this mesh with the content of <paramref name="mesh"/>, and store it into this mesh
		/// <paramref name="combineIndexedSubmeshes"/> should be true when you want to use the submesh indices from <paramref name="mesh"/>
		/// and use it directly in this mesh. If it set to false, submesh indices will be shifted to create new submeshes
		/// </summary>
		public void Combine(ExtractedMesh mesh, bool combineIndexedSubmeshes = true)
		{
			int vertexShift = vertices.Count;
			int submeshShift = combineIndexedSubmeshes ? 0 : submeshCount;

			vertices.AddRange(mesh.vertices);
			uvs.AddRange(mesh.uvs);

			triangles.Capacity += mesh.triangles.Count;
			submeshCount += submeshShift;

			for (int i = 0; i < mesh.triangles.Count; i++)
			{
				var triangle = mesh.triangles[i];
				triangles.Add
				(
					new Triangle
					(
						triangle.vertex1 + vertexShift, triangle.vertex2 + vertexShift,
						triangle.vertex3 + vertexShift, triangle.submeshIndex + submeshShift
					)
				);
			}
		}

		/**
		 * Returns all of the unique/non-connected meshes in this mesh
		 * This value is not cached, so it will generate every time you invoke the method
		 */
		public List<ExtractedMesh> Unique()
		{
			var results = new List<ExtractedMesh>();
			var uniqueVertices = new Dictionary<Vector3, int>(); //Hashing floating point values is fine, because we are kinda sure that they will have the exact values

			for (int i = 0; i < vertices.Count; i++)
			{
				var vertex = vertices[i];
				if (uniqueVertices.ContainsKey(vertex)) continue;

				uniqueVertices.Add(vertex, i);
			}

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

			public readonly int vertex1;
			public readonly int vertex2;
			public readonly int vertex3;

			public readonly int submeshIndex;
		}
	}
}