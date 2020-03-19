using System;
using System.Linq;
using System.Reflection;
using CodeHelpers.DebugHelpers;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	public abstract class TreeGraphNode : Node
	{
		public TreeGraphNode() => Guid = System.Guid.NewGuid();

		public virtual void Initialize(TreeGraphView graphView, NodeInfo info)
		{
			Info = info;
			GraphView = graphView;

			title = Info.displayedName;

			//Generate parent port
			if (HasParent)
			{
				ParentPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));

				ParentPort.portName = "Parent";
				ParentPort.AddManipulator(GraphView.GetNewEdgeConnector());

				inputContainer.Add(ParentPort);
			}

			//Generate child port
			if (MaxChildCount > 0)
			{
				if (MaxChildCount == 1)
				{
					ChildrenPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(int));
					ChildrenPort.portName = "Child";
				}
				else
				{
					ChildrenPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(float));
					ChildrenPort.portName = "Children";
				}

				ChildrenPort.AddManipulator(GraphView.GetNewEdgeConnector());
				outputContainer.Add(ChildrenPort);
			}

			//Generate order display
			if (HasParent)
			{
				orderLabel = new Label {name = "title-label"}; //Use the same style as the title
				orderLabel.AddToClassList("unity-text-element");
				orderLabel.AddToClassList("unity-label");

				titleContainer.Insert(1, orderLabel); //The first position is the title, the second is the button, so we insert the label in between
				RecalculateOrder();
			}
		}

		public readonly SerializableGuid Guid;
		public TreeGraphView GraphView { get; private set; }
		public NodeInfo Info { get; private set; }

		protected virtual bool HasParent => true;
		protected abstract int MaxChildCount { get; }

		protected virtual SerializableParameter[] Parameters => Array.Empty<SerializableParameter>();
		public int Order { get; private set; }

		public Port ParentPort { get; private set; }
		public Port ChildrenPort { get; private set; }

		VisualElement parameterContainer;
		Label orderLabel;

		protected void GenerateParameterControl(int parameterIndex, string controlName, Action<SerializableParameter> clampAction = null)
		{
			SerializableParameter parameter = Parameters[parameterIndex];
			VisualElement control;

			switch (parameter.Type)
			{
				case ParameterType.behaviorAction:

					control = new VisualElement();
					var buttons = new VisualElement {style = {flexDirection = FlexDirection.Row}};

					var actionLabel = new Label(GetBehaviorActionString()) {style = {paddingLeft = 6f, paddingRight = 6f}};
					parameter.OnValueChangedMethods += () => actionLabel.text = GetBehaviorActionString();

					var configureButton = new Button {text = "Configure"};
					configureButton.clickable.clickedWithEventInfo +=
						clickEvent =>
						{
							var worldPosition = clickEvent.originalMousePosition + GraphView.editorWindow.position.position;

							GraphView.actionSearcher.TargetParameter = parameter;
							SearchWindow.Open(new SearchWindowContext(worldPosition), GraphView.actionSearcher);
						};

					var removeButton = new Button(() => parameter.BehaviorActionValue = null) {text = "Remove"};

					buttons.Add(configureButton);
					buttons.Add(removeButton);

					control.Add(actionLabel);
					control.Add(buttons);

					string GetBehaviorActionString() => parameter.BehaviorActionValue == null ? "No Action" : parameter.BehaviorActionValue.ToString();

					break;

				case ParameterType.boolean:

					var toggle = new Toggle(controlName) {value = parameter.BooleanValue};
					toggle.RegisterValueChangedCallback(
						changeEvent =>
						{
							parameter.BooleanValue = changeEvent.newValue;
							clampAction?.Invoke(parameter);
							toggle.SetValueWithoutNotify(parameter.BooleanValue);
						}
					);

					control = toggle;
					break;

				case ParameterType.integer1:

					var integerField = new IntegerField(controlName) {value = parameter.Integer1Value};
					integerField.RegisterValueChangedCallback(
						changeEvent =>
						{
							parameter.Integer1Value = changeEvent.newValue;
							clampAction?.Invoke(parameter);
							integerField.SetValueWithoutNotify(parameter.Integer1Value);
						}
					);

					control = integerField;
					break;

				case ParameterType.integer2:

					var vector2IntField = new Vector2IntField(controlName) {value = parameter.Integer2Value};
					vector2IntField.RegisterValueChangedCallback(
						changeEvent =>
						{
							parameter.Integer2Value = changeEvent.newValue;
							clampAction?.Invoke(parameter);
							vector2IntField.SetValueWithoutNotify(parameter.Integer2Value);
						}
					);

					control = vector2IntField;
					break;

				case ParameterType.integer3:

					var vector3IntField = new Vector3IntField(controlName) {value = parameter.Integer3Value};
					vector3IntField.RegisterValueChangedCallback(
						changeEvent =>
						{
							parameter.Integer3Value = changeEvent.newValue;
							clampAction?.Invoke(parameter);
							vector3IntField.SetValueWithoutNotify(parameter.Integer3Value);
						}
					);

					control = vector3IntField;
					break;

				case ParameterType.float1:

					var floatField = new FloatField(controlName) {value = parameter.Float1Value};
					floatField.RegisterValueChangedCallback(
						changeEvent =>
						{
							parameter.Float1Value = changeEvent.newValue;
							clampAction?.Invoke(parameter);
							floatField.SetValueWithoutNotify(parameter.Float1Value);
						}
					);

					control = floatField;
					break;

				case ParameterType.float2:

					var vector2Field = new Vector2Field(controlName) {value = parameter.Float2Value};
					vector2Field.RegisterValueChangedCallback(
						changeEvent =>
						{
							parameter.Float2Value = changeEvent.newValue;
							clampAction?.Invoke(parameter);
							vector2Field.SetValueWithoutNotify(parameter.Float2Value);
						}
					);

					control = vector2Field;
					break;

				case ParameterType.float3:

					var vector3Field = new Vector3Field(controlName) {value = parameter.Float3Value};
					vector3Field.RegisterValueChangedCallback(
						changeEvent =>
						{
							parameter.Float3Value = changeEvent.newValue;
							clampAction?.Invoke(parameter);
							vector3Field.SetValueWithoutNotify(parameter.Float3Value);
						}
					);

					control = vector3Field;
					break;

				default: throw ExceptionHelper.Invalid(nameof(parameter.Type), parameter.Type, InvalidType.unexpected);
			}

			var label = control.Q<Label>();
			if (label != null) label.style.minWidth = 64f;

			if (parameterContainer == null)
			{
				VisualElement contents = this.Q("contents");
				VisualElement divider = new VisualElement {name = "divider"}; //Name added to copy styles from existing elements
				parameterContainer = new VisualElement();

				divider.AddToClassList("horizontal");
				parameterContainer.style.backgroundColor = new StyleColor(new Color32(46, 46, 46, 205));
				parameterContainer.style.paddingBottom = parameterContainer.style.paddingTop = 4;

				contents.Add(divider);
				contents.Add(parameterContainer);
			}

			parameterContainer.Add(control);

			void CopyStyles(VisualElement source, VisualElement target)
			{
				//Reflection give me power!!
				DebugHelper.Log(source.style, source.style.color);

				foreach (PropertyInfo property in from property in typeof(IStyle).GetProperties(BindingFlags.Public | BindingFlags.Instance)
												  where property.GetSetMethod(false) != null && property.GetGetMethod(false) != null
												  select property)
				{
					var value = property.GetValue(source.style, BindingFlags.Public | BindingFlags.Instance, null, null, null);
					property.SetValue(target.style, value, BindingFlags.Public | BindingFlags.Instance, null, null, null);

					DebugHelper.Log(value, property, source.style.color);
				}
			}
		}

		/// <summary>
		/// Recalculate this node's order in parent.
		/// If <paramref name="propagateToSiblings"/> is true, then the order of all its siblings will be recalculated too
		/// </summary>
		public void RecalculateOrder(bool propagateToSiblings = true)
		{
			if (ParentPort == null || !ParentPort.connected || ParentPort.connections.First().output.capacity == Port.Capacity.Single)
			{
				if (orderLabel != null) orderLabel.text = "";
				Order = 0;
			}
			else
			{
				TreeGraphNode parentNode = (TreeGraphNode)ParentPort.connections.First().output.node;

				int order = 0;
				float y = GetPosition().y;

				//Loop through all parent's children connections
				foreach (Edge edge in parentNode.ChildrenPort.connections)
				{
					if (!(edge.input.node is TreeGraphNode node)) continue;
					if (node.GetPosition().y < y) order++;

					if (propagateToSiblings) node.RecalculateOrder(false); //NOTE: This false is really important to avoid infinite recursions!
				}

				orderLabel.text = order.ToString(); //This looks better than "Order 1", however if it gets too difficult to understand we can change it back
				Order = order;
			}
		}
	}

	public class RootNode : TreeGraphNode
	{
		protected override bool HasParent => false;
		protected override int MaxChildCount => 1;
	}

	public class LeafNode : TreeGraphNode
	{
		public override void Initialize(TreeGraphView graphView, NodeInfo info)
		{
			base.Initialize(graphView, info);

			Parameters[0] = new SerializableParameter(null); //Set action to null behavior action
			GenerateParameterControl(0, "Action");
		}

		protected override int MaxChildCount => 0;
		protected override SerializableParameter[] Parameters { get; } = new SerializableParameter[1];
	}

	public class SequencerNode : TreeGraphNode
	{
		protected override int MaxChildCount => int.MaxValue;
	}

	public class SelectorNode : TreeGraphNode
	{
		protected override int MaxChildCount => int.MaxValue;
	}

	public class InverterNode : TreeGraphNode
	{
		protected override int MaxChildCount => 1;
	}

	public class RepeaterNode : TreeGraphNode
	{
		public override void Initialize(TreeGraphView graphView, NodeInfo info)
		{
			base.Initialize(graphView, info);

			Parameters[0] = new SerializableParameter(1); //Set amount to 1
			GenerateParameterControl(0, "Amount", parameter => parameter.Integer1Value = Math.Max(parameter.Integer1Value, 0));
		}

		protected override int MaxChildCount => int.MaxValue;
		protected override SerializableParameter[] Parameters { get; } = new SerializableParameter[1];
	}

	public class BlockerNode : TreeGraphNode
	{
		public override void Initialize(TreeGraphView graphView, NodeInfo info)
		{
			base.Initialize(graphView, info);

			Parameters[0] = new SerializableParameter(1f); //Set chance to 1f
			GenerateParameterControl(0, "Chance", parameter => parameter.Float1Value = Mathf.Clamp01(parameter.Float1Value));
		}

		protected override int MaxChildCount => 1;
		protected override SerializableParameter[] Parameters { get; } = new SerializableParameter[1];
	}

	public class ConditionerNode : TreeGraphNode
	{
		public override void Initialize(TreeGraphView graphView, NodeInfo info)
		{
			base.Initialize(graphView, info);

			Parameters[0] = new SerializableParameter(null); //Set condition to null
			GenerateParameterControl(0, "Condition");
		}

		protected override int MaxChildCount => 1;
		protected override SerializableParameter[] Parameters { get; } = new SerializableParameter[1];
	}
}