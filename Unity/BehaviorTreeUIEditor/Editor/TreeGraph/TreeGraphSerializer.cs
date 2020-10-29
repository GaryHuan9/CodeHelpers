#if CODEHELPERS_UNITY

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CodeHelpers.AI.BehaviorTrees;
using CodeHelpers.Collections;
using CodeHelpers.Unity.Debugs;
using UnityEditor;
using UnityEditor.Experimental.GraphView;

namespace CodeHelpers.Unity.BehaviorTreeUIEditor
{
	public class TreeGraphSerializer
	{
		public TreeGraphSerializer(TreeGraphEditorWindow editorWindow, TreeGraphView graphView)
		{
			this.editorWindow = editorWindow;
			this.graphView = graphView;
		}

		readonly TreeGraphEditorWindow editorWindow;
		readonly TreeGraphView graphView;

		List<TreeNodeData> allData;
		readonly List<int> rootNodesIndexCache = new List<int>();

		readonly Dictionary<string, NodeInfo> serializedNameToInfo = new Dictionary<string, NodeInfo>();
		readonly Stopwatch stopwatch = new Stopwatch();

		public void SerializeCurrent()
		{
			BehaviorTreeBlueprintData mainData = editorWindow.CurrentData;
			if (mainData == null) throw new Exception("No current data to serialize!");

			stopwatch.Restart();

			//Clear
			if (mainData.allNodes == null) mainData.allNodes = new List<TreeNodeData>();
			allData = mainData.allNodes;

			allData.Clear();

			//Start
			foreach (TreeGraphNode rootNode in from nativeNode in graphView.nodes.ToList()
											   let node = (TreeGraphNode)nativeNode
											   where node.ParentPort == null || !node.ParentPort.connected
											   select node)
			{
				int index = SerializeNode(rootNode); //Serialize branch

				if (rootNode is RootNode) mainData.mainRootNode = index;
				rootNodesIndexCache.Add(index);
			}

			mainData.rootNodes = rootNodesIndexCache.ToArray();
			rootNodesIndexCache.Clear();

			EditorUtility.SetDirty(mainData);

			stopwatch.Stop();
			DebugHelperUnity.Log($"Serialized in {stopwatch.Elapsed.TotalMilliseconds} ms.");
		}

		int SerializeNode(TreeGraphNode node)
		{
			var data = new TreeNodeData
					   {
						   position = node.GetPosition().position,              //Position
						   nodeTypeSerializableName = node.Info.serializedName, //Node type name
						   parameters = node.Parameters                         //Parameters
					   };

			//Children
			if (node.ChildrenPort == null || !node.ChildrenPort.connected) data.children = Array.Empty<int>();
			else
			{
				var childIndices = new List<int>();

				foreach (Edge connection in node.ChildrenPort.connections)
				{
					if (!(connection.input.node is TreeGraphNode child)) continue;

					while (child.Order >= childIndices.Count) childIndices.Add(-1);
					childIndices[child.Order] = SerializeNode(child);
				}

				data.children = childIndices.ToArray();
			}

			//Finalize
			data.GUID = allData.Count;

			allData.Add(data);
			return data.GUID;
		}

		public void DeserializeData()
		{
			BehaviorTreeBlueprintData mainData = editorWindow.CurrentData;
			if (mainData == null) throw new Exception("No current data to deserialize!");

			stopwatch.Restart();

			//Clear everything
			BehaviorTreeNodeAttribute.RescanAttributes();
			graphView.DeleteAllElements();
			RecalculateNodeInfo();

			//Setup data
			allData = mainData.allNodes;

			//Start
			for (int i = 0; i < mainData.rootNodes.Length; i++)
			{
				DeserializeNode(allData[mainData.rootNodes[i]]); //Deserialize branch
			}

			stopwatch.Stop();
			DebugHelperUnity.Log($"Deserialized in {stopwatch.Elapsed.TotalMilliseconds} ms.");
		}

		TreeGraphNode DeserializeNode(TreeNodeData data)
		{
			NodeInfo info = serializedNameToInfo.TryGetValue(data.nodeTypeSerializableName) ?? throw new Exception($"Unexpected serialized name {data.nodeTypeSerializableName}");
			TreeGraphNode node = graphView.CreateNewNode(info, data.position, data.parameters);

			node.GUID = data.GUID;

			//Children
			TreeGraphNode child = null;

			for (int i = 0; i < data.children.Length; i++)
			{
				child = DeserializeNode(allData[data.children[i]]);
				graphView.AddElement(child.ParentPort.ConnectTo(node.ChildrenPort));
			}

			child?.RecalculateOrder(); //This will calculate the order of its siblings too
			return node;
		}

		void RecalculateNodeInfo()
		{
			serializedNameToInfo.Clear();
			serializedNameToInfo.Add(NodeInfo.rootInfo.serializedName, NodeInfo.rootInfo);

			foreach (var pair in BehaviorTreeNodeAttribute.SerializedNameToAttribute)
			{
				serializedNameToInfo.Add(pair.Key, new NodeInfo(pair.Value));
			}
		}
	}
}

#endif