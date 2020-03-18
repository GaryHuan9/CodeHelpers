using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		public bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
		{
			var rootElement = graphView.editorWindow.rootVisualElement;
			var worldPosition = rootElement.ChangeCoordinatesTo(rootElement.parent, context.screenMousePosition - graphView.editorWindow.position.position);

			graphView.CreateNewNode((NodeEntry)searchTreeEntry.userData, graphView.contentViewContainer.WorldToLocal(worldPosition));
			return true;
		}
	}
}