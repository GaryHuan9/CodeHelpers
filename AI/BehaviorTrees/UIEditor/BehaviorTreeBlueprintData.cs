using UnityEngine;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	[CreateAssetMenu(fileName = "Behavior Tree Blueprint", menuName = "CodeHelpers/Behavior Trees/Blueprint")]
	public class BehaviorTreeBlueprintData : ScriptableObject
	{
		public SerializableType TargetType;
	}
}