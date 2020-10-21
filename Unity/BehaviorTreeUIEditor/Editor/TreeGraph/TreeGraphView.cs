#if CODEHELPERS_UNITY

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using Edge = UnityEditor.Experimental.GraphView.Edge;

namespace CodeHelpers.Unity.BehaviorTreeUIEditor
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
			CreateRootNode();

			nodeCreationRequest = OnNodeCreationRequest;
			graphViewChanged = OnGraphViewChanged;
		}

		public readonly TreeGraphEditorWindow editorWindow;
		public RootNode RootNode { get; private set; }

		public readonly NodeSearcher nodeSearcher;
		public readonly ActionSearcher actionSearcher;

		readonly EdgeConnectorListener edgeConnectorListener;
		readonly HashSet<GraphElement> removingElement = new HashSet<GraphElement>();

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

		public void DeleteAllElements() => DeleteElements(graphElements.ToList());
		public void CreateRootNode() => CreateNewNode(NodeInfo.rootInfo, new Vector2(100f, 200f));

		public TreeGraphNode CreateNewNode(NodeInfo info, Vector2 position, SerializableParameter[] parameterSource = null)
		{
			var node = (TreeGraphNode)Activator.CreateInstance(info.graphNodeType);

			if (parameterSource != null && parameterSource.Length > 0)
			{
				if (node.Parameters.Length != parameterSource.Length) throw new Exception($"Parameter length mismatch! {node.Parameters} v. {parameterSource}");

				for (int i = 0; i < node.Parameters.Length; i++)
				{
					var parameter = parameterSource[i];

					if (parameter.Type == ParameterType.behaviorAction) parameter.LoadBehaviorAction(editorWindow.ImportData);
					node.Parameters[i].CopyFrom(parameter);
				}
			}

			node.SetPosition(new Rect(position, defaultNodeSize));
			node.Initialize(this, info);

			node.RefreshExpandedState();
			node.RefreshPorts();

			if (node is RootNode rootNode)
			{
				RootNode = rootNode;
				RootNode.capabilities &= ~(Capabilities.Collapsible | Capabilities.Deletable);
			}

			AddElement(node);
			return node;
		}

		public EdgeConnector<Edge> GetNewEdgeConnector() => new EdgeConnector<Edge>(edgeConnectorListener);

		public bool IsRemovingElement(GraphElement element) => removingElement.Contains(element);

		void OnNodeCreationRequest(NodeCreationContext context)
		{
			SearchWindow.Open(new SearchWindowContext(context.screenMousePosition), nodeSearcher);
		}

		GraphViewChange OnGraphViewChanged(GraphViewChange change)
		{
			removingElement.Clear();
			if (change.elementsToRemove != null) removingElement.UnionWith(change.elementsToRemove);

			foreach (GraphElement element in change.movedElements ?? Enumerable.Empty<GraphElement>())
			{
				if (!(element is TreeGraphNode node)) continue;
				node.RecalculateOrder();
			}

			foreach (GraphElement element in change.elementsToRemove ?? Enumerable.Empty<GraphElement>())
			{
				var port = (element as Edge)?.input;
				var node = (port == null ? element : port.node) as TreeGraphNode;

				if (port != null) removingElement.Add(node);
				node?.RecalculateOrder();
			}

			return change;
		}
	}
}

#endif