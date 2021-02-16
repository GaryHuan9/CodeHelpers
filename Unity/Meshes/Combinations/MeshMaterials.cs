#if CODEHELPERS_UNITY

using System;
using System.Collections;
using System.Collections.Generic;
using CodeHelpers.ObjectPooling;
using UnityEngine;

namespace CodeHelpers.Unity.Meshes.Combinations
{
	public struct MeshMaterials
	{
		public MeshMaterials(Mesh mesh, Material material) : this(mesh, new MaterialCollection(material)) { }
		public MeshMaterials(Mesh mesh) : this(mesh, new MaterialCollection()) { }

		public MeshMaterials(Mesh mesh, Material[] materials)
		{
			Mesh = mesh;
			Materials = materials.Length == 1 ? new MaterialCollection(materials[0]) : new MaterialCollection(materials);

			subMeshes = null;
		}

		public MeshMaterials(Mesh mesh, MaterialCollection materials)
		{
			Mesh = mesh;
			Materials = materials;

			subMeshes = null;
		}

		public MeshMaterials(MeshMaterials source, Mesh mesh) : this(mesh, source.Materials) { }

		public MeshMaterials(MeshMaterials source, Material material) : this(source.Mesh, material) => subMeshes = source.subMeshes;
		public MeshMaterials(MeshMaterials source, Material[] materials) : this(source.Mesh, materials) => subMeshes = source.subMeshes;
		public MeshMaterials(MeshMaterials source, MaterialCollection materials) : this(source.Mesh, materials) => subMeshes = source.subMeshes;

		public Mesh Mesh { get; }
		public MaterialCollection Materials { get; private set; }

		public Material Material
		{
			get => Materials.Material;
			set
			{
				var materials = Materials;
				materials.Material = value;
				Materials = materials;
			}
		}

		public void CalculateAllSubMeshes()
		{
			if (Mesh == null) return;
			for (int i = 0; i < Mesh.subMeshCount; i++) GetSubMesh(i);
		}

		Mesh[] subMeshes;

		public Mesh GetSubMesh(int subMeshIndex)
		{
			//Create the subMeshes array if necessary
			if (subMeshes == null) subMeshes = new Mesh[Mesh.subMeshCount];
			else if (subMeshes[subMeshIndex] != null) return subMeshes[subMeshIndex];

			//Get data
			using var verticesHandle = CollectionPooler<Vector3>.list.Fetch();
			using var trianglesHandle = CollectionPooler<int>.list.Fetch();
			using var uvsHandle = CollectionPooler<Vector2>.list.Fetch();

			List<Vector3> vertices = verticesHandle.Target;
			List<int> triangles = trianglesHandle.Target;
			List<Vector2> uvs = uvsHandle.Target;

			Mesh.GetVertices(vertices);
			Mesh.GetTriangles(triangles, subMeshIndex);
			Mesh.GetUVs(0, uvs);

			//Get all the useful vertices
			using var verticesMapHandle = CollectionPooler<int, int>.dictionary.Fetch();
			using var verticesFinalHandle = CollectionPooler<Vector3>.list.Fetch();
			using var uvsFinalHandle = CollectionPooler<Vector2>.list.Fetch();

			Dictionary<int, int> verticesMap = verticesMapHandle.Target;
			List<Vector3> verticesFinal = verticesFinalHandle.Target;
			List<Vector2> uvsFinal = uvsFinalHandle.Target;

			if (uvs.Count == 0) uvsFinal = null;

			for (int i = 0; i < triangles.Count; i++)
			{
				int oldIndex = triangles[i];

				if (!verticesMap.TryGetValue(oldIndex, out int newIndex))
				{
					newIndex = verticesFinal.Count;
					verticesMap[oldIndex] = newIndex;

					verticesFinal.Add(vertices[oldIndex]);
					uvsFinal?.Add(uvs[oldIndex]);
				}

				triangles[i] = newIndex;
			}

			//Create a new mesh
			Mesh mesh = new Mesh();

			mesh.SetVertices(verticesFinal);
			mesh.SetTriangles(triangles, 0);
			if (uvsFinal != null) mesh.SetUVs(0, uvsFinal);

			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			mesh.RecalculateTangents();

			return subMeshes[subMeshIndex] = mesh;
		}

		public static implicit operator Mesh(MeshMaterials value) => value.Mesh;
		public static implicit operator Material(MeshMaterials value) => value.Material;
		public static implicit operator MaterialCollection(MeshMaterials value) => value.Materials;

		public struct MaterialCollection : IReadOnlyList<Material>
		{
			internal MaterialCollection(Material material)
			{
				this.material = material;
				materials = null;
			}

			internal MaterialCollection(Material[] materials)
			{
				material = null;
				this.materials = materials;
			}

			Material material;             //Semi-Readonly
			readonly Material[] materials; //Readonly

			public int Count => material == null ? materials?.Length ?? 0 : 1;

			public Material Material
			{
				get => Count == 0 ? null : this[0];
				set
				{
					if (material == null) throw new Exception("The MaterialCollection with multi-material cannot be changed!");
					material = value;
				}
			}

			public Material this[int index]
			{
				get
				{
					if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

					if (index == 0) return material != null ? material : materials[0];
					return materials[index];
				}
			}

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

			public IEnumerator<Material> GetEnumerator()
			{
				for (int i = 0; i < Count; i++)
				{
					yield return this[i];
				}
			}

			public void AssignToRenderer(MeshRenderer renderer, bool shared)
			{
				if (shared)
				{
					if (Count > 1) renderer.sharedMaterials = materials;
					else
					{
						renderer.sharedMaterials = Array.Empty<Material>();
						renderer.sharedMaterial = Count == 0 ? null : material;
					}
				}
				else
				{
					if (Count > 1) renderer.materials = materials;
					else
					{
						renderer.materials = Array.Empty<Material>();
						renderer.material = Count == 0 ? null : material;
					}
				}
			}
		}
	}
}

#endif