using System;
using System.Collections.Generic;
using CodeHelpers.MeshHelpers.Collections;
using CodeHelpers.MeshHelpers.Combinations;
using CodeHelpers.ObjectPooling;
using UnityEngine;
using UnityEngine.Rendering;

namespace CodeHelpers.MeshHelpers
{
	public static class MeshHelper
	{
		const uint Mesh16BitSize = 65530; //65536, left 6 for safety

		/// <summary>
		/// Combines the meshes given. Contains materials.
		/// </summary>
		public static MeshMaterials CombineMeshes(IList<MeshMaterials> models, IList<Matrix4x4> matrices, Mesh baseMesh = null)
		{
			if (models.Count != matrices.Count) throw new Exception($"Different length of array for mesh combine. {nameof(models)} Length = {models.Count} {nameof(matrices)} Length = {matrices.Count}");

			var dictionary = CollectionPooler<Material, List<CombineInstance>>.dictionary.GetObject();
			uint totalVertexCount = 0;

			for (int i = 0; i < models.Count; i++)
			{
				MeshMaterials model = models[i];

				//Loop through all the materials
				for (int j = 0; j < model.Materials.Count; j++)
				{
					Mesh subMesh = model.GetSubMesh(j);

					Material material = model.Materials[j];
					List<CombineInstance> list;

					if (!dictionary.ContainsKey(material))
					{
						list = CollectionPooler<CombineInstance>.list.GetObject();
						dictionary.Add(material, list);
					}
					else list = dictionary[material];

					list.Add(new CombineInstance {mesh = subMesh, transform = matrices[i]});
					totalVertexCount += (uint)subMesh.vertexCount;
				}
			}

			CombineInstance[] instances = new CombineInstance[dictionary.Count];
			Material[] materials = new Material[dictionary.Count];

			int loopIndex = 0;

			//Combine first pass, material sub meshes
			foreach (KeyValuePair<Material, List<CombineInstance>> pair in dictionary)
			{
				Mesh subMesh = CommonPooler.mesh.GetObject();
				if (totalVertexCount >= Mesh16BitSize) subMesh.indexFormat = IndexFormat.UInt32;

				subMesh.CombineMeshes(pair.Value.ToArray(), true, true, false);
				CollectionPooler<CombineInstance>.list.ReleaseObject(pair.Value); //Clean list

				instances[loopIndex] = new CombineInstance {mesh = subMesh, subMeshIndex = 0};
				materials[loopIndex] = pair.Key;

				loopIndex++;
			}

			//Combine second pass
			if (baseMesh == null) baseMesh = new Mesh();
			else baseMesh.Clear();

			baseMesh.indexFormat = totalVertexCount < Mesh16BitSize ? IndexFormat.UInt16 : IndexFormat.UInt32;
			baseMesh.CombineMeshes(instances, false, false, false);

			CollectionPooler<Material, List<CombineInstance>>.dictionary.ReleaseObject(dictionary);        //Release pooled dictionary
			for (int i = 0; i < instances.Length; i++) CommonPooler.mesh.ReleaseObject(instances[i].mesh); //Release pooled submeshes

			return new MeshMaterials(baseMesh, materials);
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

			baseMesh.indexFormat = vertexCount >= Mesh16BitSize ? IndexFormat.UInt32 : IndexFormat.UInt16;
			baseMesh.CombineMeshes(instances, true);

			return baseMesh;
		}

		public static MeshThreadedData ThreadedCombineMeshes(IEnumerable<MeshMatrix> meshes, bool combineUVs = true, bool combineNormals = false)
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
				(mesh, index) =>
				{
					Mesh targetMesh = mesh.mesh;
					Matrix4x4 thisMatrix = mesh.matrix;

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
						int subMeshIndex = i + mesh.subMeshOffset;

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

		/// <summary>This applies a transform (matrix) to a mesh. NOTE: this does not create a new mesh.</summary>
		public static Mesh ApplyMatrix(Mesh mesh, Matrix4x4 matrix)
		{
			var vertices = CollectionPooler<Vector3>.list.GetObject();
			var normals = CollectionPooler<Vector3>.list.GetObject();

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

			CollectionPooler<Vector3>.list.ReleaseObject(vertices);
			CollectionPooler<Vector3>.list.ReleaseObject(normals);

			return mesh;
		}

		/// <summary>Creates a new mesh with the data of this old mesh.</summary>
		public static Mesh Clone(this Mesh mesh) => UnityEngine.Object.Instantiate(mesh);

		/// <summary>
		/// Returns the interior volume of this <paramref name="mesh"/>.
		/// NOTE: The mesh should be closed, but it does not have to be convex.
		/// </summary>
		public static float GetVolume(Mesh mesh)
		{
			//References:
			//Paper - http://chenlab.ece.cornell.edu/Publication/Cha/icip01_Cha.pdf
			//Stack Overflow answer - https://stackoverflow.com/a/1568551/9196958

			float totalVolume = 0f;
			var vertices = CollectionPooler<Vector3>.list.GetObject();

			mesh.GetVertices(vertices);

			for (int i = 0; i < mesh.subMeshCount; i++)
			{
				var triangles = CollectionPooler<int>.list.GetObject();
				mesh.GetTriangles(triangles, i);

				for (int j = 0; j < triangles.Count; j += 3)
				{
					totalVolume += GetSignedVolumeOfTriangle
					(
						vertices[triangles[j]],
						vertices[triangles[j + 1]],
						vertices[triangles[j + 2]]
					);
				}

				CollectionPooler<int>.list.ReleaseObject(triangles);
			}

			CollectionPooler<Vector3>.list.ReleaseObject(vertices);
			return totalVolume;

			float GetSignedVolumeOfTriangle(Vector3 point1, Vector3 point2, Vector3 point3)
			{
				//Returns the signed volume of a tetrahedral formed with the 3 points and the origin

				float v321 = point3.x * point2.y * point1.z;
				float v231 = point2.x * point3.y * point1.z;
				float v312 = point3.x * point1.y * point2.z;
				float v132 = point1.x * point3.y * point2.z;
				float v213 = point2.x * point1.y * point3.z;
				float v123 = point1.x * point2.y * point3.z;

				return (-v321 + v231 + v312 - v132 - v213 + v123) / 6f;
			}
		}
	}
}