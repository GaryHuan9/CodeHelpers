using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	[CreateAssetMenu(fileName = "Behavior Action Imports", menuName = "CodeHelpers/Behavior Trees/Action Imports")]
	public class ActionImportData : ScriptableObject, ISerializationCallbackReceiver
	{
		[SerializeField] public List<BehaviorAction> actions = new List<BehaviorAction>();
		[NonSerialized] Dictionary<string, int> guidToActionIndex;

		public void RecalculateGuidMapping()
		{
			if (guidToActionIndex != null) guidToActionIndex.Clear();
			else guidToActionIndex = new Dictionary<string, int>();

			for (int i = 0; i < actions.Count; i++) guidToActionIndex.Add(actions[i].guid, i);
		}

		public BehaviorAction GetActionByGuid(string guid)
		{
			if (!guidToActionIndex.ContainsKey(guid)) return null;
			return actions[guidToActionIndex[guid]];
		}

		public void OnBeforeSerialize() { }
		public void OnAfterDeserialize() => RecalculateGuidMapping();
	}

	[Serializable]
	public class BehaviorAction : IEquatable<BehaviorAction>
	{
		public BehaviorAction(string name)
		{
			this.name = name;
			guid = Guid.NewGuid().ToString();
		}

		public string name;
		public string guid;
		public SerializableMethod method;

		public override string ToString() => method == null ? "Missing Action" : name;

		public bool Equals(BehaviorAction other) => guid == other?.guid;
		public override bool Equals(object obj) => obj is BehaviorAction other && Equals(other);

		public static bool operator ==(BehaviorAction action, object other) => action?.Equals(other) ?? other is null;
		public static bool operator !=(BehaviorAction action, object other) => !(action == other);

		public override int GetHashCode() => guid?.GetHashCode() ?? 0;
	}
}