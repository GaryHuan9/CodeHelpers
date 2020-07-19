using System;
using System.Collections.Generic;
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

		public int GUID = -1; //Do not change this if you are not the serializer
		public TreeGraphView GraphView { get; private set; }
		public NodeInfo Info { get; private set; }

		protected virtual bool HasParent => true;
		protected abstract int MaxChildCount { get; }

		public virtual SerializableParameter[] Parameters => Array.Empty<SerializableParameter>();
		public int Order { get; private set; }

		public Port ParentPort { get; private set; }
		public Port ChildrenPort { get; private set; }

		VisualElement parameterContainer;
		Label orderLabel;

		protected VisualElement CreateParameterControl(SingularSerializableParameter parameter, string controlName, Action<SingularSerializableParameter> clampAction = null)
		{
			VisualElement control;

			switch (parameter.Type)
			{
				case ParameterType.behaviorAction:

					control = new VisualElement();

					var buttons = new VisualElement {style = {flexDirection = FlexDirection.Row, paddingRight = 2f, paddingLeft = 2f}};
					var actionLabel = new Label {style = {paddingLeft = 8f, paddingRight = 8f}};

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

					parameter.OnValueChangedMethods += OnBehaviorActionChanged;
					OnBehaviorActionChanged(); //Trigger a refresh

					void OnBehaviorActionChanged()
					{
						parameter.LoadBehaviorAction(GraphView.editorWindow.ImportData); //Refresh action name
						actionLabel.text = parameter.BehaviorActionValue == null ? "Missing Action" : parameter.BehaviorActionValue.ToString();

						//Behavior action parameter controls
						const string ParameterGroupName = "Behavior Action Parameters Group";
						VisualElement group = control.Q<VisualElement>(ParameterGroupName);

						if (group != null) control.Remove(group); //If had old group remove/destroy it
						var parameters = parameter.BehaviorActionValue?.method.Parameters;

						if (parameters == null || parameters.Count == 0) return; //If no parameter for this action

						group = new VisualElement {name = ParameterGroupName}; //Create group
						var accessor = ((SerializableParameter)parameter).BehaviorActionParameters;

						for (int i = 0; i < parameters.Count; i++)
						{
							BehaviorActionParameterInfo parameterInfo = parameters[i];
							group.Add(CreateParameterControl(accessor[i], parameterInfo.name));
						}

						control.Add(group);
					}

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

				case ParameterType.enumeration:

					control = new EnumField();
					//TODO

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

			control.Query<FloatField>().ForEach(field => field.style.minWidth = 60f);
			Label label = control.Q<Label>();

			if (label != null)
			{
				label.style.minWidth = 0f;
				label.style.paddingRight = 20f;
			}

			return control;
		}

		protected void GenerateParameterControl(SerializableParameter parameter, string controlName, Action<SingularSerializableParameter> clampAction = null)
		{
			var control = CreateParameterControl(parameter, controlName, clampAction);
			TryGetParameterContainer().Add(control);
		}

		/// <summary>
		/// Recalculate this node's order in parent.
		/// If <paramref name="propagateToSiblings"/> is true, then the order of all its siblings will be recalculated too
		/// </summary>
		public void RecalculateOrder(bool propagateToSiblings = true)
		{
			Port parentInputPort = ParentPort?.connections?.FirstOrDefault()?.output;

			if (parentInputPort == null || parentInputPort.capacity == Port.Capacity.Single) SetEmpty();
			else
			{
				TreeGraphNode parentNode = (TreeGraphNode)parentInputPort.node;

				if (GraphView.IsRemovingElement(this))
				{
					if (propagateToSiblings)
					{
						//Loop through all parent's children connections
						foreach (Edge edge in parentNode.ChildrenPort.connections)
						{
							if (edge.input.node is TreeGraphNode node && node != this) node.RecalculateOrder(false); //Important false to avoid infinite recursion
						}
					}

					SetEmpty();
					return;
				}

				int order = 0;
				float y = GetPositionImmediate().y;

				//Loop through all parent's children connections
				foreach (Edge edge in parentNode.ChildrenPort.connections)
				{
					if (!(edge.input.node is TreeGraphNode node) || node == this) continue;
					if (node.GetPositionImmediate().y < y && !GraphView.IsRemovingElement(node)) order++;

					if (propagateToSiblings) node.RecalculateOrder(false); //NOTE: This false is really important to avoid infinite recursions!
				}

				orderLabel.text = order.ToString(); //This looks better than "Order 1", however if it gets too difficult to understand we can change it back
				Order = order;
			}

			void SetEmpty()
			{
				if (orderLabel != null) orderLabel.text = "";
				Order = 0;
			}
		}

		protected VisualElement TryGetParameterContainer()
		{
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

			return parameterContainer;
		}

		/// <summary>
		/// <see cref="Node.GetPosition"/> does not update for newly created nodes so we have to use this
		/// </summary>
		public Vector2 GetPositionImmediate() => new Vector2(style.left.value.value, style.top.value.value);
	}

	public class RootNode : TreeGraphNode
	{
		public override void Initialize(TreeGraphView graphView, NodeInfo info)
		{
			base.Initialize(graphView, info);

			contextSelector = new PopupField<SerializableMethod>(
				"Target Context", representativeMethods, 0,
				method =>
				{
					if (representativeMethods.Count != 1) GraphView.editorWindow.SetTargetContextType(contextSelector?.value);
					return "Select";
				},
				method =>
				{
					if (method == null) return "Select";
					if (method.Method == null) return "Missing";

					return method.TargetContextType.ToString();
				}
			);
			typeLabel = new Label("None");

			{
				// Because the choices property in PopupField is internal, which according to https://forum.unity.com/threads/maskfield-choices-internal.672670/
				// is a bug. So we will use reflection to set it for now

				var property = contextSelector.GetType().GetProperty("choices", BindingFlags.Instance | BindingFlags.NonPublic);
				if (property == null) throw new Exception("Reflection not working!!!");

				//Should be contextSelector.choices = representativeActions
				property.SetValue(contextSelector, representativeMethods);
			}

			VisualElement parameterContainer = TryGetParameterContainer();
			var labelStyle = contextSelector.Q<Label>().style;

			labelStyle.paddingTop = 0f;
			labelStyle.paddingLeft = 4f;
			labelStyle.paddingRight = 7f;

			contextSelector[1].style.paddingBottom = 0f; //Set selector bottom padding to 0
			typeLabel.style.minWidth = labelStyle.minWidth = 64f;
			typeLabel.style.paddingRight = typeLabel.style.paddingLeft = 8f;

			inputContainer.style.justifyContent = Justify.Center;

			inputContainer.Add(contextSelector);
			parameterContainer.Add(typeLabel);

			GraphView.editorWindow.OnTargetContextChangedMethods += RecalculateTargetContext;
			RecalculateTargetContext();
		}

		protected override bool HasParent => false;
		protected override int MaxChildCount => 1;

		PopupField<SerializableMethod> contextSelector;
		Label typeLabel;

		readonly List<SerializableMethod> representativeMethods = new List<SerializableMethod> {null};

		void RecalculateTargetContext()
		{
			TreeGraphEditorWindow window = GraphView.editorWindow;

			if (window.ImportData == null)
			{
				representativeMethods.Clear();
				representativeMethods.Add(null);

				contextSelector.index = 0;
				typeLabel.text = "No action import data selected";

				return;
			}

			if (true /*Can change target type*/)
			{
				representativeMethods.Clear();
				representativeMethods.Add(null);

				foreach (SerializableMethod method in from import in window.ImportData.actions
													  where import.method != null
													  group import by import.method.TargetContextType
													  into types
													  select types.First().method)
				{
					representativeMethods.Add(method);
					if (method.TargetContextType == window.TargetContextType) contextSelector.index = representativeMethods.Count - 1;
				}
			}

			typeLabel.text = window.TargetContextType?.ToString() ?? "None";
		}
	}

	public class LeafNode : TreeGraphNode
	{
		public override void Initialize(TreeGraphView graphView, NodeInfo info)
		{
			base.Initialize(graphView, info);
			GenerateParameterControl(Parameters[0], "Action");
		}

		protected override int MaxChildCount => 0;
		public override SerializableParameter[] Parameters { get; } = {new SerializableParameter((BehaviorAction)null)}; //Set action to null behavior action
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
		protected override int MaxChildCount => int.MaxValue;
	}

	public class BlockerNode : TreeGraphNode
	{
		public override void Initialize(TreeGraphView graphView, NodeInfo info)
		{
			base.Initialize(graphView, info);
			GenerateParameterControl(Parameters[0], "Chance", parameter => parameter.Float1Value = Mathf.Clamp01(parameter.Float1Value));
		}

		protected override int MaxChildCount => 1;
		public override SerializableParameter[] Parameters { get; } = {new SerializableParameter(1f)}; //Set chance to 1f
	}

	public class ConditionerNode : TreeGraphNode
	{
		public override void Initialize(TreeGraphView graphView, NodeInfo info)
		{
			base.Initialize(graphView, info);
			GenerateParameterControl(Parameters[0], "Condition");
		}

		protected override int MaxChildCount => 1;
		public override SerializableParameter[] Parameters { get; } = {new SerializableParameter((BehaviorAction)null)}; //Set condition to null
	}

	public class ConstantNode : TreeGraphNode
	{
		public override void Initialize(TreeGraphView graphView, NodeInfo info)
		{
			base.Initialize(graphView, info);
			GenerateParameterControl(Parameters[0], "Success");
		}

		protected override int MaxChildCount => 1;
		public override SerializableParameter[] Parameters { get; } = {new SerializableParameter(true)}; //Set success to true
	}
}