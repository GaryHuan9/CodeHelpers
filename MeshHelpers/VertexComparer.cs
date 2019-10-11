using System.Collections.Generic;
using UnityEngine;

namespace CodeHelpers.MeshHelpers
{
	public class VertexComparer : IEqualityComparer<Vector3>
	{
		public VertexComparer(float epsilon = CodeHelper.Epsilon) => this.epsilon = epsilon;

		readonly float epsilon;

		public static readonly VertexComparer Instance = new VertexComparer();

		public bool Equals(Vector3 x, Vector3 y) => GetRoundedCoordinate(x) == GetRoundedCoordinate(y);
		public int GetHashCode(Vector3 obj) => GetRoundedCoordinate(obj).GetHashCode();

		Vector3Int GetRoundedCoordinate(Vector3 vector) => (vector / epsilon).Floor();
	}
}