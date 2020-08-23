using System;
using CodeHelpers.Collections;
using CodeHelpers.ObjectPooling;
using UnityEngine;

namespace CodeHelpers.MeshHelpers.Combinations
{
	public readonly struct RendererFilter
	{
		public RendererFilter(MeshRenderer renderer, MeshFilter filter)
		{
			this.renderer = renderer;
			this.filter = filter;
		}

		public RendererFilter(Component behaviour)
		{
			var renderers = CollectionPooler<MeshRenderer>.list.GetObject();
			var filters = CollectionPooler<MeshFilter>.list.GetObject();

			behaviour.GetComponentsInChildren(renderers);
			behaviour.GetComponentsInChildren(filters);

			renderer = renderers.TryGetValue(0);
			filter = filters.TryGetValue(0);

			CollectionPooler<MeshRenderer>.list.ReleaseObject(renderers);
			CollectionPooler<MeshFilter>.list.ReleaseObject(filters);
		}

		public RendererFilter(GameObject gameObject) : this(gameObject.transform) { }

		public readonly MeshRenderer renderer;
		public readonly MeshFilter filter;

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

		public void Apply(MeshMaterials model)
		{
			model.Materials.AssignToRenderer(renderer);
			filter.sharedMesh = model.Mesh;
		}
	}
}