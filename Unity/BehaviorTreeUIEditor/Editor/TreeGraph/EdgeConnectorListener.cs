#if CODEHELPERS_UNITY

using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace CodeHelpers.Unity.BehaviorTreeUIEditor
{
	public class EdgeConnectorListener : IEdgeConnectorListener
	{
		public EdgeConnectorListener(TreeGraphView graphView) => this.graphView = graphView;

		public readonly TreeGraphView graphView;

		public void OnDropOutsidePort(Edge edge, Vector2 position)
		{
			graphView.nodeSearcher.ConnectedPort = edge.input ?? edge.output;
			SearchWindow.Open(new SearchWindowContext(position + graphView.editorWindow.position.position), graphView.nodeSearcher);
		}

		public void OnDrop(GraphView graphView, Edge edge)
		{
			if (!(edge.input.node is TreeGraphNode node)) return;
			node.RecalculateOrder();
		}
	}
}

#endif