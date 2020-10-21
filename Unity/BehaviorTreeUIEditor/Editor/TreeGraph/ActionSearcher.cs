#if CODEHELPERS_UNITY

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace CodeHelpers.Unity.BehaviorTreeUIEditor
{
	public class ActionSearcher : ScriptableObject, ISearchWindowProvider
	{
		public void Initialize(TreeGraphView graphView)
		{
			this.graphView = graphView;
			RecreateSearchTree();

			graphView.editorWindow.OnTargetContextChangedMethods += RecreateSearchTree;
		}

		TreeGraphView graphView;
		List<SearchTreeEntry> searchTree;

		public SingularSerializableParameter TargetParameter { private get; set; }

		void RecreateSearchTree()
		{
			if (searchTree != null) searchTree.Clear();
			else searchTree = new List<SearchTreeEntry>();

			searchTree.Add(new SearchTreeGroupEntry(new GUIContent("Select Action"))); //First item in tree is the title

			if (graphView.editorWindow.ImportData == null || graphView.editorWindow.ImportData.actions == null) return;
			Type targetContextType = graphView.editorWindow.TargetContextType;

			foreach (BehaviorAction action in from action in graphView.editorWindow.ImportData.actions
											  where action.method != null && action.method.Method != null &&
													action.method.TargetContextType.IsAssignableFrom(targetContextType)
											  select action)
			{
				searchTree.Add(new SearchTreeEntry(new GUIContent(action.ToString())) {level = 1, userData = action});
			}
		}

		public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context) => searchTree;

		public bool OnSelectEntry(SearchTreeEntry entry, SearchWindowContext context)
		{
			TargetParameter.BehaviorActionValue = (BehaviorAction)entry.userData;
			TargetParameter = null;

			return true;
		}
	}
}

#endif