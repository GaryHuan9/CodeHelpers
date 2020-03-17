using System;
using System.Collections.Generic;
using System.Linq;
using CodeHelpers.DebugHelpers;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	public class TreeGraphView : GraphView
	{
		public TreeGraphView(TreeGraphEditorWindow editorWindow)
		{
			this.editorWindow = editorWindow;

			styleSheets.Add(TreeGraphEditorWindow.MainStyleSheet);
			SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

			this.AddManipulator(new ContentDragger());
			this.AddManipulator(new SelectionDragger());
			this.AddManipulator(new RectangleSelector());
			this.AddManipulator(new ClickSelector());

			var grid = new GridBackground();
			nodeSearcher = ScriptableObject.CreateInstance<NodeSearcher>();

			grid.StretchToParentSize();
			Insert(0, grid);

			AddElement(CreateRootNode());
			nodeCreationRequest = OnNodeCreationRequest;
		}

		readonly TreeGraphEditorWindow editorWindow;
		readonly NodeSearcher nodeSearcher;

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

		Port GeneratePort(TreeGraphNode node, Direction portDirection, Port.Capacity capacity)
		{
			var port = node.InstantiatePort(Orientation.Horizontal, portDirection, capacity, typeof(int));

			switch (portDirection)
			{
				case Direction.Input:
					node.inputContainer.Add(port);
					break;
				case Direction.Output:
					node.outputContainer.Add(port);
					break;

				default: throw new ArgumentOutOfRangeException(nameof(portDirection), portDirection, null);
			}

			return port;
		}

		public void CreateNode(string nodeName) => AddElement(CreateTreeNode(nodeName));

		TreeGraphNode CreateRootNode()
		{
			var node = new TreeGraphNode(true) {title = "Root"};
			var port = GeneratePort(node, Direction.Output, Port.Capacity.Multi);

			port.portName = "Children";
			node.SetPosition(new Rect(200f, 200f, 100f, 100f)); //Size actually does not do anything

			node.RefreshExpandedState();
			node.RefreshPorts();

			return node;
		}

		TreeGraphNode CreateTreeNode(string nodeName)
		{
			var node = new TreeGraphNode {title = nodeName};
			var port = GeneratePort(node, Direction.Input, Port.Capacity.Single);

			port.portName = "Input";
			node.SetPosition(new Rect(Vector2.zero, defaultNodeSize));

			node.RefreshExpandedState();
			node.RefreshPorts();

			return node;
		}

		void OnNodeCreationRequest(NodeCreationContext context)
		{
			SearchWindow.Open(new SearchWindowContext(context.screenMousePosition), nodeSearcher);
		}
	}
}