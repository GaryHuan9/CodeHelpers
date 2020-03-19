using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Graphs;
using UnityEngine;
using UnityEngine.UIElements;
using Edge = UnityEditor.Experimental.GraphView.Edge;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	public class TreeGraphView : GraphView
	{
		public TreeGraphView(TreeGraphEditorWindow editorWindow)
		{
			this.editorWindow = editorWindow;
			SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

			this.AddManipulator(new ContentDragger());
			this.AddManipulator(new SelectionDragger());
			this.AddManipulator(new RectangleSelector());
			this.AddManipulator(new ClickSelector());

			var grid = new GridBackground();
			grid.StretchToParentSize();
			Insert(0, grid);

			nodeSearcher = ScriptableObject.CreateInstance<NodeSearcher>();
			actionSearcher = ScriptableObject.CreateInstance<ActionSearcher>();

			nodeSearcher.Initialize(this);
			actionSearcher.Initialize(this);

			edgeConnectorListener = new EdgeConnectorListener(this);

			nodeCreationRequest = OnNodeCreationRequest;
			graphViewChanged = OnGraphViewChanged;

			CreateNewNode(new NodeInfo("Internal_Root", "Root", typeof(RootNode)), Vector2.one * 200f);
		}

		public readonly TreeGraphEditorWindow editorWindow;

		public readonly NodeSearcher nodeSearcher;
		public readonly ActionSearcher actionSearcher;

		readonly EdgeConnectorListener edgeConnectorListener;
		static readonly Vector2 defaultNodeSize = new Vector2(150f, 200f);

		public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
		{
			var compatiblePorts = new List<Port>();
			ports.ForEach(
				port =>
				{
					if (startPort == port || startPort.node == port.node || startPort.direction == port.direction) return;
					compatiblePorts.Add(port);
				}
			);

			return compatiblePorts;
		}

		public TreeGraphNode CreateNewNode(NodeInfo info, Vector2 position)
		{
			var node = (TreeGraphNode)Activator.CreateInstance(info.graphNodeType);

			node.SetPosition(new Rect(position, defaultNodeSize));
			node.Initialize(this, info);

			node.RefreshExpandedState();
			node.RefreshPorts();

			AddElement(node);
			return node;
		}

		public EdgeConnector<Edge> GetNewEdgeConnector() => new EdgeConnector<Edge>(edgeConnectorListener);

		void OnNodeCreationRequest(NodeCreationContext context)
		{
			SearchWindow.Open(new SearchWindowContext(context.screenMousePosition), nodeSearcher);
		}

		GraphViewChange OnGraphViewChanged(GraphViewChange change)
		{
			if (change.moveDelta == Vector2.zero) return change; //We currently only care about moving nodes
			var movedElements = change.movedElements;

			for (int i = 0; i < movedElements.Count; i++)
			{
				if (!(movedElements[i] is TreeGraphNode node)) continue;
				node.RecalculateOrder();
			}

			return change;
		}
	}
}