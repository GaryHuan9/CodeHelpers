using System;
using UnityEngine;

namespace CodeHelpers.MeshHelpers.Combinations
{
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
}