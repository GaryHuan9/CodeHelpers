using System.Collections.ObjectModel;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	public class NodeAdder : IMGUIContainer
	{
		public NodeAdder(Vector2 position)
		{
			screenPosition = new Rect(position, new Vector2(200f, 300f));
			onGUIHandler += OnGUI;
		}

		readonly Rect screenPosition;
		Vector2 scrollPosition;

		string searchingKeyword = "";
		string sortedKeyword; //The keyword that we used to sort the nodes

		NodePair[] sortedNodes;
		static readonly ReadOnlyCollection<NodePair> allNodes = new ReadOnlyCollection<NodePair>(
			new[]
			{
				new NodePair("Leaf"), new NodePair("Sequencer"), new NodePair("Selector"),
				new NodePair("Inverter"), new NodePair("Repeater"), new NodePair("Blocker"),
				new NodePair("Conditioner")
			}
		);

		void OnGUI()
		{
			GUILayout.BeginArea(screenPosition, EditorStyles.helpBox);
			GUILayout.BeginHorizontal(EditorStyles.helpBox);

			EditorGUIUtility.SetIconSize(Vector2.one * EditorGUIUtility.singleLineHeight);
			GUILayout.Label(EditorGUIUtility.IconContent("Search Icon"));

			var keyword = GUILayout.TextField(searchingKeyword);
			if (keyword != searchingKeyword)
			{
				searchingKeyword = keyword;
				SortNodes();
			}

			GUILayout.EndHorizontal();

			scrollPosition = GUILayout.BeginScrollView(scrollPosition);
			if (sortedNodes == null || sortedNodes.Length != allNodes.Count) SortNodes();

			for (int i = 0; i < sortedNodes.Length; i++)
			{
				NodePair node = sortedNodes[i];
				GUILayout.BeginHorizontal(EditorStyles.helpBox);

				GUILayout.Label(node.name);
				GUILayout.FlexibleSpace();

				if (GUILayout.Button("Add")) { } //TODO: add node

				GUILayout.EndHorizontal();
			}

			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}

		void SortNodes()
		{
			sortedNodes = allNodes.OrderByDescending(pair => pair.CompareToKeyword(searchingKeyword)).ToArray();
			sortedKeyword = searchingKeyword;
		}

		class NodePair
		{
			public NodePair(string name)
			{
				this.name = name;
			}

			public readonly string name;

			public float CompareToKeyword(string keyword) => StringHelper.CalculateSimilarity(keyword, name);
		}
	}
}