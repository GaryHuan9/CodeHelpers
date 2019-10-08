using UnityEngine;

namespace CodeHelpers.MeshHelpers
{
	public readonly struct Triangle
	{
		public Triangle(Vector3 point1, Vector3 point2, Vector3 point3)
		{
			this.point1 = point1;
			this.point2 = point2;
			this.point3 = point3;
		}

		public readonly Vector3 point1;
		public readonly Vector3 point2;
		public readonly Vector3 point3;

		public Plane Plane => new Plane(point1,point2,point3);

		// public bool Split(Plane split, out )
		// {
		//
		// }
	}
}