#if CODEHELPERS_UNITY && UNITY_EDITOR

using UnityEngine;

namespace CodeHelpers.Unity.Debugs
{
	public static class GizmosHelper
	{
		public static void DrawArrow(Vector3 origin, Vector3 end, float angle = 30f) => DrawArrow(origin, end, (origin - end).magnitude / 10f, angle);

		public static void DrawArrow(Vector3 origin, Vector3 end, float arrowSize, float angle)
		{
			Gizmos.DrawLine(origin, end);

			var rotation = Quaternion.FromToRotation(Vector3.up, origin - end);

			DrawPiece(Vector3.right);
			DrawPiece(Vector3.forward);
			DrawPiece(Vector3.left);
			DrawPiece(Vector3.back);

			void DrawPiece(Vector3 perpendicular)
			{
				var localRotation = Quaternion.AngleAxis(angle, Vector3.Cross(Vector3.up, perpendicular));
				Gizmos.DrawLine(end, end + rotation * localRotation * Vector3.up * arrowSize);
			}
		}
	}
}

#endif