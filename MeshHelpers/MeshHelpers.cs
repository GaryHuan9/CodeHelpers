using System;
using System.Collections.Generic;
using System.Linq;
using CodeHelpers.MeshHelpers.Collections;
using CodeHelpers.MeshHelpers.Combinations;
using UnityEngine;
using UnityEngine.Rendering;
using Object = UnityEngine.Object;

namespace CodeHelpers.MeshHelpers
{
	public static class MeshHelper
	{
		const int mesh16BitSize = 65530; //65536, left 6 for safety

		/// <summary>
		/// Combines the meshes given. Contains materials.
		/// </summary>
		public static MeshAndMaterials CombineMeshes(IList<MeshAndMaterials> models, IList<Matrix4x4> matrices, Mesh baseMesh = null)
		{
			if (models.Count != matrices.Count)
			{
				throw new Exception
				(
					"Different length of array for mesh combine.\n" +
					$"models.Length = {models.Count} matrices.Length = {matrices.Count}"
				);
			}

			var meshListDictionary = new Dictionary<Material, ListWithVertexCount>();
			Mesh subMesh;

			for (int i = 0; i < models.Count; i++)
			{
				MeshAndMaterials model = models[i];

				//Loop through all the materials
				for (int j = 0; j < model.Materials.Count; j++)
				{
					subMesh = model.GetSubMesh(j);

					var material = model.Materials[j];
					var meshList = meshListDictionary.ContainsKey(material) ? meshListDictionary[material] : new ListWithVertexCount {list = new List<CombineInstance>()};

					meshList.vertexCount += subMesh.vertexCount;
					meshList.list.Add(new CombineInstance {mesh = subMesh, transform = matrices[i]});

					meshListDictionary[material] = meshList;
				}
			}

			CombineInstance[] instances = new CombineInstance[meshListDictionary.Count];

			int vertexCount = 0;
			int loopIndex = 0;

			foreach (var pair in meshListDictionary)
			{
				subMesh = new Mesh {indexFormat = pair.Value.vertexCount >= mesh16BitSize ? IndexFormat.UInt32 : IndexFormat.UInt16};

				subMesh.CombineMeshes(pair.Value.list.ToArray(), true);
				vertexCount += subMesh.vertexCount;

				instances[loopIndex++] = new CombineInstance
										 {
											 mesh = subMesh,
											 subMeshIndex = 0
										 };
			}

			if (baseMesh == null) baseMesh = new Mesh();

			baseMesh.indexFormat = vertexCount >= mesh16BitSize ? IndexFormat.UInt32 : IndexFormat.UInt16;
			baseMesh.CombineMeshes(instances, false, false);

			return new MeshAndMaterials(baseMesh, meshListDictionary.Keys.ToArray());
		}

		struct ListWithVertexCount
		{
			public List<CombineInstance> list;
			public int vertexCount;
		}

		/// <summary>
		/// Combines the meshes given. Without materials.
		/// </summary>
		public static Mesh CombineMeshes(IList<Mesh> meshes, IList<Matrix4x4> matrices, Mesh baseMesh = null)
		{
			if (meshes.Count != matrices.Count)
			{
				throw new ArgumentOutOfRangeException
				(
					"Different length of array for mesh combine.\n" +
					$"models.Length = {meshes.Count} matrices.Length = {matrices.Count}"
				);
			}

			CombineInstance[] instances = new CombineInstance[meshes.Count];
			uint vertexCount = 0;

			for (int i = 0; i < meshes.Count; i++)
			{
				Mesh mesh = meshes[i];

				vertexCount += (uint)mesh.vertexCount;
				instances[i] = new CombineInstance
							   {
								   mesh = mesh,
								   transform = matrices[i]
							   };
			}

			if (baseMesh == null) baseMesh = new Mesh();

			baseMesh.indexFormat = vertexCount >= mesh16BitSize ? IndexFormat.UInt32 : IndexFormat.UInt16;
			baseMesh.CombineMeshes(instances, true);

			return baseMesh;
		}

		public static MeshThreadedData ThreadedCombineMeshes(IEnumerable<MeshAndMatrix> meshes, bool combineUVs = true, bool combineNormals = false)
		{
			var vertices = new List<Vector3>();
			var triangles = new Dictionary<int, List<int>>();

			var uvs = combineUVs ? new List<Vector2>() : null;
			var normals = combineNormals ? new List<Vector3>() : null;

			//Prevent allocation
			var theseVertices = new List<Vector3>();
			var theseTriangles = new List<int>();

			var theseUVs = combineUVs ? new List<Vector2>() : null;
			var theseNormals = combineNormals ? new List<Vector3>() : null;

			meshes.ForEach(
				(thisMesh, index) =>
				{
					Mesh targetMesh = thisMesh.mesh;
					Matrix4x4 thisMatrix = thisMesh.matrix;

					//Vertices and normals
					int oldVertexCount = vertices.Count;
					int vertexCount = targetMesh.vertexCount;

					vertices.Capacity += vertexCount;

					targetMesh.GetVertices(theseVertices);

					if (combineNormals)
					{
						normals.Capacity += vertexCount;

						targetMesh.GetNormals(theseNormals);

						for (int i = 0; i < vertexCount; i++)
						{
							vertices.Add(thisMatrix.MultiplyPoint3x4(theseVertices[i]));
							normals.Add(thisMatrix.MultiplyVector(theseNormals[i]));
						}
					}
					else
					{
						for (int i = 0; i < vertexCount; i++)
						{
							vertices.Add(thisMatrix.MultiplyPoint3x4(theseVertices[i]));
						}
					}

					//UVs
					if (combineUVs)
					{
						targetMesh.GetUVs(0, theseUVs);
						uvs.AddRange(theseUVs);
					}

					//Triangles
					for (int i = 0; i < targetMesh.subMeshCount; i++)
					{
						int subMeshIndex = i + thisMesh.subMeshOffset;

						if (!triangles.ContainsKey(subMeshIndex)) triangles.Add(subMeshIndex, new List<int>());

						var subMeshTriangles = triangles[subMeshIndex];
						targetMesh.GetTriangles(theseTriangles, i);

						int trianglesCount = theseTriangles.Count;
						subMeshTriangles.Capacity += trianglesCount;

						for (int j = 0; j < trianglesCount; j++)
						{
							subMeshTriangles.Add(theseTriangles[j] + oldVertexCount);
						}
					}
				}
			);

			return new MeshThreadedData(vertices, triangles, uvs, normals);
		}

		/// <summary>This applies a transform (matrix) to a mesh, this does not create a new mesh.</summary>
		public static Mesh ApplyMatrix(Mesh mesh, Matrix4x4 matrix)
		{
			var vertices = new List<Vector3>();
			var normals = new List<Vector3>();

			mesh.GetVertices(vertices);
			mesh.GetNormals(normals);

			for (int i = 0; i < vertices.Count; i++)
			{
				vertices[i] = matrix.MultiplyPoint3x4(vertices[i]);
				normals[i] = matrix.MultiplyVector(normals[i]);
			}

			mesh.SetVertices(vertices);
			mesh.SetNormals(normals);

			mesh.RecalculateBounds();
			mesh.RecalculateTangents();

			return mesh;
		}

		/// <summary>Creates a new mesh with the data of this old mesh.</summary>
		public static Mesh Clone(this Mesh mesh) => Object.Instantiate(mesh);
	}
}