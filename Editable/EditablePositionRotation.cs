using System;
using UnityEngine;

namespace CodeHelpers.Editable
{
	[Serializable]
	public class EditablePositionRotation : IEditable
	{
		public EditablePositionRotation(Vector3 position, Quaternion rotation)
		{
			this.position = position;
			this.rotation = rotation;
		}

		public EditablePositionRotation(Vector3 position) => this.position = position;

		public Vector3 position;
		public Quaternion rotation = Quaternion.identity;

		public Vector3 GetAppliedPosition(Transform transform) => transform.TransformPoint(position);
		public Quaternion GetAppliedRotation(Transform transform) => transform.rotation * rotation;
	}
}