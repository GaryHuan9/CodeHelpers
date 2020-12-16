#if CODEHELPERS_UNITY && UNITY_EDITOR

using CodeHelpers.Mathematics;
using UnityEngine;

namespace CodeHelpers.Unity.Diagnostics
{
	public static class GizmosHelper
	{
		public static void DrawArrow(Float3 origin, Float3 end, float angle = 30f) => DrawArrow(origin, end, (origin - end).Magnitude / 10f, angle);

		public static void DrawArrow(Float3 origin, Float3 end, float arrowSize, float angle)
		{
			Gizmos.DrawLine(origin, end);

			var rotation = Quaternion.FromToRotation(Float3.up, origin - end);

			DrawPiece(Float3.right);
			DrawPiece(Float3.forward);
			DrawPiece(Float3.left);
			DrawPiece(Float3.backward);

			void DrawPiece(Float3 perpendicular)
			{
				var localRotation = Quaternion.AngleAxis(angle, Float3.Cross(Float3.up, perpendicular));
				Gizmos.DrawLine(end, (Vector3)end + rotation * localRotation * Float3.up * arrowSize);
			}
		}
	}
}

#endif