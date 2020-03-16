using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	[CreateAssetMenu(fileName = "Behavior Action Imports", menuName = "CodeHelpers/Behavior Trees/Action Imports")]
	public class ActionImportData : ScriptableObject
	{
		[HideInInspector] public List<ActionImport> imports = new List<ActionImport>();
	}

	[Serializable]
	public class ActionImport
	{
		public string name = "Untitled";
		public SerializableMethod method;
	}
}