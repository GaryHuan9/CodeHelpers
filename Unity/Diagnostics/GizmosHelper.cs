#if CODE_HELPERS_UNITY

using CodeHelpers.Mathematics;
using UnityEngine;

namespace CodeHelpers.Unity.Diagnostics
{
	public static class GizmosHelper
	{
		public static void DrawArrow(Float3 origin, Float3 end) => DrawArrow(origin, end, (origin - end).Magnitude / 10f);

		public static void DrawArrow(Float3 origin, Float3 end, float length)
		{
			Gizmos.DrawLine(origin, end);

			var rotation = Quaternion.FromToRotation(Float3.up, origin - end);

			DrawPiece(Float3.right);
			DrawPiece(Float3.forward);
			DrawPiece(Float3.left);
			DrawPiece(Float3.backward);

			void DrawPiece(Float3 perpendicular)
			{
				const float Angle = 30f;

				var localRotation = Quaternion.AngleAxis(Angle, Float3.Cross(Float3.up, perpendicular));
				Gizmos.DrawLine(end, (Vector3)end + rotation * localRotation * Float3.up * length);
			}
		}

		public static void DrawAnchor(Transform transform) => DrawAnchor(transform.position, transform.up, transform.forward);

		public static void DrawAnchor(Float3 origin, Float3 up, Float3 forward)
		{
			up = up.Normalized;
			forward = forward.Normalized;
			Float3 right = up.Cross(forward);

			Gizmos.color = Color.red;
			DrawArrow(origin, origin + right);

			Gizmos.color = Color.green;
			DrawArrow(origin, origin + up);

			Gizmos.color = Color.blue;
			DrawArrow(origin, origin + forward);
		}
	}
}

#endif