using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	[CreateAssetMenu(fileName = "Behavior Action Imports", menuName = "CodeHelpers/Behavior Trees/Action Imports")]
	public class ActionImportData : ScriptableObject
	{
		[SerializeField] public List<BehaviorAction> actions = new List<BehaviorAction>();
	}

	[Serializable]
	public class BehaviorAction
	{
		public string name = "Untitled";
		public string guid = Guid.NewGuid().ToString();
		public SerializableMethod method;

		public override string ToString() => method == null ? "Missing Action" : name;
	}
}