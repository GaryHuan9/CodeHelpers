using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	[CreateAssetMenu(fileName = "Behavior Tree Blueprint", menuName = "CodeHelpers/Behavior Trees/Blueprint")]
	public class BehaviorTreeBlueprintData : ScriptableObject
	{
		public ActionImportData importData;
		public SerializableMethod targetContextTypeMethod; //The serializable method used to store our target context

		public List<TreeNodeData> allNodes;
		public int mainRootNode;
		public int[] rootNodes;
	}

	[Serializable]
	public class TreeNodeData
	{
		public Vector2 position;
		public int GUID;
		public string nodeTypeSerializableName;

		public int[] children; //NOTE: These children indices are stored respecting to their priorities.
		public SerializableParameter[] parameters;
	}
}