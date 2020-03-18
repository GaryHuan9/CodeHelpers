using System;
using System.Collections.Generic;
using System.Linq;
using CodeHelpers.DebugHelpers;
using ICSharpCode.NRefactory.Ast;
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
			SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

			this.AddManipulator(new ContentDragger());
			this.AddManipulator(new SelectionDragger());
			this.AddManipulator(new RectangleSelector());
			this.AddManipulator(new ClickSelector());

			var grid = new GridBackground();
			grid.StretchToParentSize();
			Insert(0, grid);

			nodeSearcher = ScriptableObject.CreateInstance<NodeSearcher>();
			nodeSearcher.Initialize(this);

			CreateRootNode();
			nodeCreationRequest = OnNodeCreationRequest;
		}

		public readonly TreeGraphEditorWindow editorWindow;
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

		void CreateRootNode()
		{
			var node = new TreeGraphNode(new NodeInfo("Internal_Root", "Root", 1, null, false));
			node.SetPosition(new Rect(editorWindow.position.size / 2f, Vector2.one * 100f)); //Size actually does not effect anything
			InitializeNode(node);
		}

		public void CreateNewNode(NodeEntry entry, Vector2 position)
		{
			var node = new FunctionalNode(entry);
			node.SetPosition(new Rect(position, defaultNodeSize));
			InitializeNode(node);
		}

		void InitializeNode(TreeGraphNode node)
		{
			node.RefreshExpandedState();
			node.RefreshPorts();

			AddElement(node);
		}

		void OnNodeCreationRequest(NodeCreationContext context)
		{
			SearchWindow.Open(new SearchWindowContext(context.screenMousePosition), nodeSearcher);
		}
	}
}