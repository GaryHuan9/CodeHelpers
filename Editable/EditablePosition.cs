using System;
using UnityEngine;

namespace CodeHelpers.Editable
{
	[Serializable]
	public class EditablePosition : IEditable
	{
		public EditablePosition(Vector3 position = default) => this.position = position;

		public Vector3 position;

		public Vector3 GetAppliedPosition(Transform transform) => transform.TransformPoint(position);
	}
}