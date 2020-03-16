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
		public TreeGraphView()
		{
			styleSheets.Add(TreeGraphEditorWindow.MainStyleSheet);
			SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

			this.AddManipulator(new ContentDragger());
			this.AddManipulator(new SelectionDragger());
			this.AddManipulator(new RectangleSelector());

			var grid = new GridBackground();
			Insert(0, grid);
			grid.StretchToParentSize();

			AddElement(CreateRootNode());
		}

		/// <summary>
		/// Use the <see cref="SetNodeAdder"/> method to set this property
		/// </summary>
		public bool NodeAdderActive => nodeAdder != null;

		NodeAdder nodeAdder;

		static readonly Vector2 defaultNodeSize = new Vector2(150f, 200f);

		public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
		{
			var compatiblePorts = new List<Port>();
			ports.ForEach(
				port =>
				{
					if (startPort == port || startPort.node == port.node) return;
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

		public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
		{
			base.BuildContextualMenu(evt);
			if (evt.target != this) return;

			evt.menu.InsertAction(0, "Create Node", _ => EnableNodeAdder(evt.mousePosition));
			evt.menu.InsertSeparator("", 1);
		}

		public void EnableNodeAdder(Vector2 position)
		{
			if (NodeAdderActive) return;

			nodeAdder = new NodeAdder(position);
			Add(nodeAdder);
		}

		public void DisableNodeAdder()
		{
			Remove(nodeAdder);
			nodeAdder = null;
		}
	}
}