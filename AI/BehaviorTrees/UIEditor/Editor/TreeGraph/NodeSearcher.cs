using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CodeHelpers.DebugHelpers;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
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

				searchTree.AddRange
				(
					from assembly in AppDomain.CurrentDomain.GetAssemblies()
					from type in assembly.GetTypes()
					where type.IsValueType
					let attribute = type.GetCustomAttribute<BehaviorTreeNodeAttribute>()
					where attribute != null
					let entry = new NodeEntry(type, attribute)
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
					if (other.capacity == Port.Capacity.Single && other.connected) { other.DisconnectAll(); DebugHelper.Log("Ye");}
					if (ConnectedPort.capacity == Port.Capacity.Single && ConnectedPort.connected) { ConnectedPort.DisconnectAll(); DebugHelper.Log("ya");}

					graphView.AddElement(ConnectedPort.ConnectTo(other)); //Connect
				}

				ConnectedPort = null;
			}

			return true;
		}
	}
}