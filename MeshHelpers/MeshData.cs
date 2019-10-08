using System.Collections.Generic;
using UnityEngine;

namespace CodeHelpers.MeshHelpers
{
	public class MeshData
	{
		public MeshData(Mesh source)
		{
			vertices = new List<Vector3>(source.vertices);
			triangles = new List<int>(source.triangles);
			uv = new List<Vector2>(source.uv);
		}

		readonly List<Vector3> vertices;
		readonly List<int> triangles;
		readonly List<Vector2> uv;


	}
}