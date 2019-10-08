using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

	public struct MeshAndMaterials
	{

#region Constructors

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

#endregion

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
			foreach (var thisPair in triangles) mesh.SetTriangles(thisPair.Value, thisPair.Key);

			if (uvs != null) mesh.SetUVs(0, uvs);

			if (normals != null) mesh.SetNormals(normals);                   //Not that fast but not slow
			else if (betterRecalculateNormals) mesh.RecalculateNormals(30f); //Slowest
			else mesh.RecalculateNormals();                                  //Fastest

			mesh.RecalculateBounds();
		}
	}

	[Serializable]
	public struct RendererAndFilter
	{
		public RendererAndFilter(MeshRenderer renderer, MeshFilter filter)
		{
			this.renderer = renderer;
			this.filter = filter;
		}

		public RendererAndFilter(Component behaviour)
		{
			renderer = behaviour.GetComponentsInChildren<MeshRenderer>().TryGetValue(0);
			filter = behaviour.GetComponentsInChildren<MeshFilter>().TryGetValue(0);
		}

		public RendererAndFilter(GameObject gameObject)
		{
			renderer = gameObject.GetComponentsInChildren<MeshRenderer>().TryGetValue(0);
			filter = gameObject.GetComponentsInChildren<MeshFilter>().TryGetValue(0);
		}

		public MeshRenderer renderer;
		public MeshFilter filter;

		public Mesh Mesh
		{
			get => filter == null ? null : filter.mesh;
			set
			{
				if (filter != null) filter.mesh = value;
			}
		}

		public Mesh SharedMesh
		{
			get => filter == null ? null : filter.sharedMesh;
			set
			{
				if (filter != null) filter.sharedMesh = value;
			}
		}

		public Material Material
		{
			get => renderer == null ? null : renderer.material;
			set
			{
				if (renderer != null) renderer.material = value;
			}
		}

		public Material SharedMaterial
		{
			get => renderer == null ? null : renderer.sharedMaterial;
			set
			{
				if (renderer != null) renderer.sharedMaterial = value;
			}
		}

		public Material[] Materials
		{
			get => renderer == null ? null : renderer.materials;
			set
			{
				if (renderer != null) renderer.materials = value;
			}
		}

		public Material[] SharedMaterials
		{
			get => renderer == null ? null : renderer.sharedMaterials;
			set
			{
				if (renderer != null) renderer.sharedMaterials = value;
			}
		}

		public bool Enabled
		{
			get => renderer == null ? throw ExceptionHelper.Invalid(nameof(renderer), InvalidType.isNull) : renderer.enabled;
			set
			{
				if (renderer != null) renderer.enabled = value;
			}
		}

		public Vector3 Position
		{
			get => renderer.transform.position;
			set => renderer.transform.position = value;
		}

		public Quaternion Rotation
		{
			get => renderer.transform.rotation;
			set => renderer.transform.rotation = value;
		}

		public Vector3 Scale
		{
			get => renderer.transform.localScale;
			set => renderer.transform.localScale = value;
		}

		public void Apply(MeshAndMaterials model)
		{
			model.Materials.AssignToRenderer(renderer);
			filter.sharedMesh = model.Mesh;
		}
	}

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