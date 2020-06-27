using System.Linq;
using UnityEngine;

namespace CodeHelpers
{
	public static class UIHelper
	{
		public static RectTransform RectTransform(this Component component) => (RectTransform)component.transform;

		public static RectTransform RectTransform(this Transform transform) => (RectTransform)transform;
		// public static UITransformHelper Helper(this        Component component) => new UITransformHelper(component);

		static Canvas mainCanvas;
		const string mainCanvasTag = "MainCanvas";
		public static Canvas MainCanvas => mainCanvas == null ? mainCanvas = GetMainCanvas() : mainCanvas;

		static Canvas GetMainCanvas()
		{
			var allMainCanvas = (from canvas in Object.FindObjectsOfType<Canvas>()
								 where canvas.isRootCanvas
								 select canvas).ToArray();

			if (allMainCanvas.Length == 0) return null; //Maybe change something or throw a warning?
			if (allMainCanvas.Length == 1) return allMainCanvas[0];

			var allTaggedCanvas = (from canvas in allMainCanvas
								   where canvas.CompareTag(mainCanvasTag)
								   select canvas).ToArray();

			if (allTaggedCanvas.Length == 1) return allTaggedCanvas[0];
			if (allTaggedCanvas.Length == 0)
			{
				Debug.LogWarning(
					"There are multiple root canvas, but none of them are tagged \"" + mainCanvasTag + "\"." +
					"\n UIHelper cannot determine which one is the main canvas. Please tag the main canvas with \"" + mainCanvasTag + "\"."
				);
				return null;
			}

			Debug.LogWarning("There are multiple canvas tagged \"" + mainCanvasTag + "\". UIHelper cannot determine which one is the main canvas. Please tag only one canvas with \"" + mainCanvasTag + "\".");
			return null;
		}

		// public static Vector2 MainCanvasWorldSize => new UITransformHelper(MainCanvas).WorldSize;

		public static Vector2 MainCanvasWorldSize => MainCanvas.WorldSize();
		public static Vector2 WorldSize(this Canvas canvas) => Vector2.Scale(canvas.RectTransform().sizeDelta, canvas.RectTransform().localScale);
	}

	// public struct UITransformHelper
	// {
	// 	public UITransformHelper(RectTransform target) => this.target = target;
	// 	public UITransformHelper(Component     target) => this.target = target.RectTransform();
	//
	// 	readonly RectTransform target;
	//
	// 	public Vector2 CenterWorldPosition
	// 	{
	// 		get => (Vector2)target.position + PivotOffset;
	// 		set
	// 		{
	// 			Vector3 position = value - PivotOffset;
	// 			position.z      = target.position.z;
	// 			target.position = position;
	// 		}
	// 	}
	//
	// 	public Vector2 CenterLocalPosition
	// 	{
	// 		get => (Vector2)target.localPosition + PivotOffset;
	// 		set
	// 		{
	// 			Vector3 position = value - PivotOffset;
	// 			position.z           = target.localPosition.z;
	// 			target.localPosition = position;
	// 		}
	// 	}
	//
	// 	Vector2 PivotOffset => Vector2.Scale(Vector2.one * 0.5f - target.pivot, WorldSize);
	//
	// 	public Vector2 WorldSize
	// 	{
	// 		get => Vector2.Scale(target.sizeDelta, target.localScale);
	// 		set => target.sizeDelta = value.Divide(target.localScale);
	// 	}
	// }
}