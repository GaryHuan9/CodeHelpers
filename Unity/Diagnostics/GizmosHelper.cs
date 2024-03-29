#if CODE_HELPERS_UNITY

using CodeHelpers.Packed;
using UnityEngine;

namespace CodeHelpers.Unity.Diagnostics
{
	public static class GizmosHelper
	{
		public static void DrawArrow(Float3 origin, Float3 end) => DrawArrow(origin, end, (origin - end).Magnitude / 10f);

		public static void DrawArrow(Float3 origin, Float3 end, float length)
		{
			Gizmos.DrawLine(origin, end);

			var rotation = Quaternion.FromToRotation(Float3.Up, origin - end);

			DrawPiece(Float3.Right);
			DrawPiece(Float3.Forward);
			DrawPiece(Float3.Left);
			DrawPiece(Float3.Backward);

			void DrawPiece(Float3 perpendicular)
			{
				const float Angle = 30f;

				var localRotation = Quaternion.AngleAxis(Angle, Float3.Cross(Float3.Up, perpendicular));
				Gizmos.DrawLine(end, (Vector3)end + rotation * localRotation * Float3.Up * length);
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