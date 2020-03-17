using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CodeHelpers.DebugHelpers;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	public class NodeSearcher : ScriptableObject, ISearchWindowProvider
	{
		List<SearchTreeEntry> searchTree;

		static readonly ReadOnlyCollection<NodePair> allNodes = new ReadOnlyCollection<NodePair>
		(
			new[]
			{
				new NodePair("Leaf"), new NodePair("Sequencer"), new NodePair("Selector"),
				new NodePair("Inverter"), new NodePair("Repeater"), new NodePair("Blocker"),
				new NodePair("Conditioner")
			}
		);

		public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
		{
			if (searchTree == null)
			{
				searchTree = new List<SearchTreeEntry>
							 {
								 new SearchTreeGroupEntry(new GUIContent("Create Node")) //First item in tree is the title
							 };

				searchTree.AddRange(allNodes.Select(node => new SearchTreeEntry(new GUIContent(node.name)) {level = 1}));
				DebugHelper.Log(searchTree);
			}

			return searchTree;
		}

		public bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
		{
			DebugHelper.Log(searchTreeEntry.content.text);

			return true;
		}

		class NodePair
		{
			public NodePair(string name)
			{
				this.name = name;
			}

			public readonly string name;
		}
	}
}