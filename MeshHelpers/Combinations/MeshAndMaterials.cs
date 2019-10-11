using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeHelpers.MeshHelpers.Combinations
{
	public struct MeshAndMaterials
	{
		public MeshAndMaterials(Mesh mesh, Material material)
		{
			Mesh = mesh;
			Materials = new MaterialCollection(material);

			subMeshes = null;
		}

		public MeshAndMaterials(Mesh mesh, Material[] materials)
		{
			Mesh = mesh;
			Materials = materials.Length == 1 ? new MaterialCollection(materials[0]) : new MaterialCollection(materials);

			subMeshes = null;
		}

		public MeshAndMaterials(Mesh mesh, MaterialCollection materials)
		{
			Mesh = mesh;
			Materials = materials;

			subMeshes = null;
		}

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

		static readonly List<Vector3> verticesCache = new List<Vector3>();
		static readonly List<int> trianglesCache = new List<int>();
		static readonly List<Vector2> uvsCache = new List<Vector2>();

		static readonly Dictionary<int, int> changeTrianglesCache = new Dictionary<int, int>(); //Key: old vertex index, Value: new vertex index

		Mesh[] subMeshes;

		public Mesh GetSubMesh(int subMeshIndex)
		{
			//Create the subMeshes array if hasn't
			if (subMeshes == null) subMeshes = new Mesh[Mesh.subMeshCount];
			else if (subMeshes[subMeshIndex] != null) return subMeshes[subMeshIndex];

			//Get info
			Mesh.GetVertices(verticesCache);
			Mesh.GetUVs(0, uvsCache);
			Mesh.GetTriangles(trianglesCache, subMeshIndex);

			//Get all the useful vertices
			for (int i = 0; i < trianglesCache.Count; i++)
			{
				int index = trianglesCache[i];

				if (!changeTrianglesCache.ContainsKey(index)) changeTrianglesCache[index] = changeTrianglesCache.Count;

				trianglesCache[i] = changeTrianglesCache[index];
			}

			//Remove all the useless vertices and uvs (TODO: Maybe we can reduce these array allocations?)
			var usefulVertices = new Vector3[changeTrianglesCache.Count];
			var usefulUVs = new Vector2[changeTrianglesCache.Count];

			foreach (var pair in changeTrianglesCache)
			{
				usefulVertices[pair.Value] = verticesCache[pair.Key];
				usefulUVs[pair.Value] = uvsCache[pair.Key];
			}

			//Create a new mesh
			Mesh mesh = new Mesh {vertices = usefulVertices, uv = usefulUVs};
			mesh.SetTriangles(trianglesCache, 0);

			changeTrianglesCache.Clear();

			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			mesh.RecalculateTangents();

			return subMeshes[subMeshIndex] = mesh;
		}

		public static implicit operator Mesh(MeshAndMaterials value) => value.Mesh;
		public static implicit operator Material(MeshAndMaterials value) => value.Material;
		public static implicit operator MaterialCollection(MeshAndMaterials value) => value.Materials;

		public struct MaterialCollection : IReadOnlyList<Material>
		{
			public MaterialCollection(Material material)
			{
				this.material = material;
				materials = null;
			}

			public MaterialCollection(Material[] materials)
			{
				material = null;
				this.materials = materials;
			}

			Material material;             //Semi-Readonly
			readonly Material[] materials; //Readonly

			public int Count => material == null ? materials?.Length ?? 0 : 1;

			public Material Material
			{
				get => this[0];
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

			public void AssignToRenderer(MeshRenderer renderer)
			{
				if (Count > 1) renderer.sharedMaterials = materials;
				else
				{
					renderer.sharedMaterials = Array.Empty<Material>();
					renderer.sharedMaterial = Count == 0 ? null : material;
				}
			}
		}
	}
}