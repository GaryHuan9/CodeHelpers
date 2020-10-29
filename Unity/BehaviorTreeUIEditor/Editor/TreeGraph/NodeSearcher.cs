#if CODEHELPERS_UNITY

using System.Collections.Generic;
using System.Linq;
using CodeHelpers.AI.BehaviorTrees;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeHelpers.Unity.BehaviorTreeUIEditor
{
	public class NodeSearcher : ScriptableObject, ISearchWindowProvider
	{
		public void Initialize(TreeGraphView graphView) => this.graphView = graphView;

		TreeGraphView graphView;
		List<SearchTreeEntry> searchTree;

		public Port ConnectedPort { private get; set; }

		public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
		{
			if (searchTree == null)
			{
				searchTree = new List<SearchTreeEntry>
							 {
								 new SearchTreeGroupEntry(new GUIContent("Create Node")) //First item in tree is the title
							 };

				BehaviorTreeNodeAttribute.RescanAttributes();
				searchTree.AddRange
				(
					from pair in BehaviorTreeNodeAttribute.SerializedNameToAttribute
					let entry = new NodeEntry(pair.Value)
					select new SearchTreeEntry(new GUIContent(entry.displayedName)) {level = 1, userData = entry}
				);
			}

			return searchTree;
		}

		public bool OnSelectEntry(SearchTreeEntry entry, SearchWindowContext context)
		{
			var rootElement = graphView.editorWindow.rootVisualElement;
			var worldPosition = rootElement.ChangeCoordinatesTo(rootElement.parent, context.screenMousePosition - graphView.editorWindow.position.position);

			var node = graphView.CreateNewNode((NodeEntry)entry.userData, graphView.contentViewContainer.WorldToLocal(worldPosition));

			if (ConnectedPort != null)
			{
				Port other = ConnectedPort.direction == Direction.Input ? node.ChildrenPort : node.ParentPort;
				if (other != null)
				{
					//Disconnect old ports if necessary
					if (other.capacity == Port.Capacity.Single && other.connected) graphView.DeleteElements(other.connections);
					if (ConnectedPort.capacity == Port.Capacity.Single && ConnectedPort.connected) graphView.DeleteElements(ConnectedPort.connections);

					graphView.AddElement(ConnectedPort.ConnectTo(other)); //Connect
					((TreeGraphNode)(ConnectedPort.direction == Direction.Input ? ConnectedPort : other).node).RecalculateOrder();
				}

				ConnectedPort = null;
			}

			return true;
		}
	}
}

#endif