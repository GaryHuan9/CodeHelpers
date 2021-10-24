#if CODEHELPERS_UNITY

using System.Collections.Generic;
using CodeHelpers.Collections;
using CodeHelpers.Pooling;
using UnityEngine;

namespace CodeHelpers.Unity.Meshes.Combinations
{
	public readonly struct RendererFilter
	{
		public RendererFilter(MeshRenderer renderer, MeshFilter filter)
		{
			this.renderer = renderer;
			this.filter = filter;
		}

		public RendererFilter(Component behaviour, bool searchChild = true)
		{
			using var renderersHandle = CollectionPooler<MeshRenderer>.list.Fetch();
			using var filtersHandle = CollectionPooler<MeshFilter>.list.Fetch();

			List<MeshRenderer> renderers = renderersHandle.Target;
			List<MeshFilter> filters = filtersHandle.Target;

			if (searchChild)
			{
				behaviour.GetComponentsInChildren(renderers);
				behaviour.GetComponentsInChildren(filters);
			}
			else
			{
				behaviour.GetComponents(renderers);
				behaviour.GetComponents(filters);
			}

			renderer = renderers.TryGetValue(0);
			filter = filters.TryGetValue(0);
		}

		public RendererFilter(GameObject gameObject, bool searchChild = true) : this(gameObject.transform, searchChild) { }

		public readonly MeshRenderer renderer;
		public readonly MeshFilter filter;

		public bool BothPresent => renderer != null && filter != null;

		public Mesh Mesh
		{
			get => filter == null ? null : filter.mesh;
			set
			{
				if (filter != null) filter.mesh = value;
				else throw ExceptionHelper.Invalid(nameof(filter), InvalidType.isNull);
			}
		}

		public Mesh SharedMesh
		{
			get => filter == null ? null : filter.sharedMesh;
			set
			{
				if (filter != null) filter.sharedMesh = value;
				else throw ExceptionHelper.Invalid(nameof(filter), InvalidType.isNull);
			}
		}

		public Material Material
		{
			get => renderer == null ? null : renderer.material;
			set
			{
				if (renderer != null) renderer.material = value;
				else throw ExceptionHelper.Invalid(nameof(renderer), InvalidType.isNull);
			}
		}

		public Material SharedMaterial
		{
			get => renderer == null ? null : renderer.sharedMaterial;
			set
			{
				if (renderer != null) renderer.sharedMaterial = value;
				else throw ExceptionHelper.Invalid(nameof(renderer), InvalidType.isNull);
			}
		}

		public Material[] Materials
		{
			get => renderer == null ? null : renderer.materials;
			set
			{
				if (renderer != null) renderer.materials = value;
				else throw ExceptionHelper.Invalid(nameof(renderer), InvalidType.isNull);
			}
		}

		public Material[] SharedMaterials
		{
			get => renderer == null ? null : renderer.sharedMaterials;
			set
			{
				if (renderer != null) renderer.sharedMaterials = value;
				else throw ExceptionHelper.Invalid(nameof(renderer), InvalidType.isNull);
			}
		}

		public MeshMaterials MeshMaterials
		{
			get => new MeshMaterials(Mesh, Materials);
			set
			{
				Mesh = value.Mesh;

				if (renderer != null) value.Materials.AssignToRenderer(renderer, false);
				else throw ExceptionHelper.Invalid(nameof(renderer), InvalidType.isNull);
			}
		}

		public MeshMaterials SharedMeshMaterials
		{
			get => new MeshMaterials(SharedMesh, SharedMaterials);
			set
			{
				SharedMesh = value.Mesh;

				if (renderer != null) value.Materials.AssignToRenderer(renderer, true);
				else throw ExceptionHelper.Invalid(nameof(renderer), InvalidType.isNull);
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

		public static RendererFilter AddNew(GameObject gameObject)
		{
			MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
			MeshFilter filter = gameObject.AddComponent<MeshFilter>();

			return new RendererFilter(renderer, filter);
		}
	}
}

#endif