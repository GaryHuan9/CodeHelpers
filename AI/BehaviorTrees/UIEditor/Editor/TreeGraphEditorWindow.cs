using System;
using System.Linq;
using CodeHelpers.DebugHelpers;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using PopupWindow = UnityEngine.UIElements.PopupWindow;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	public class TreeGraphEditorWindow : EditorWindow
	{
		[MenuItem("Window/CodeHelpers/Behavior Trees/Graph Editor")]
		public static void Open() => Open(null);

		public static void Open(BehaviorTreeBlueprintData data)
		{
			var window = GetWindow<TreeGraphEditorWindow>("Graph Editor");
			window.OnDataChanged(data);
		}

		void OnEnable()
		{
			ConstructGraphView();
			ConstructToolbar();
		}

		TreeGraphView graphView;
		Toolbar toolbar;

		ObjectField dataField;
		ToolbarMenu targetTypesMenu;
		Label targetTypeLabel;

		BehaviorTreeBlueprintData currentData;

		static StyleSheet _mainStyleSheet;
		public static StyleSheet MainStyleSheet => _mainStyleSheet != null ? _mainStyleSheet : _mainStyleSheet = Resources.Load<StyleSheet>("BehaviorTreeGraph");

		void OnDisable()
		{
			rootVisualElement.Remove(graphView);
			rootVisualElement.Remove(toolbar);
		}

		void ConstructToolbar()
		{
			toolbar = new Toolbar();
			toolbar.styleSheets.Add(MainStyleSheet);

			dataField = new ObjectField("Behavior Tree Data") {allowSceneObjects = false, objectType = typeof(BehaviorTreeBlueprintData)};
			var importField = new ObjectField("Action Import Data") {allowSceneObjects = false, objectType = typeof(ActionImportData)};

			targetTypesMenu = new ToolbarMenu {text = "Target Type", variant = ToolbarMenu.Variant.Default};
			targetTypeLabel = new Label("None");

			targetTypesMenu.styleSheets.Add(MainStyleSheet);

			dataField.SetValueWithoutNotify(currentData);
			dataField.RegisterValueChangedCallback(changeEvent => OnDataChanged((BehaviorTreeBlueprintData)changeEvent.newValue));
			importField.RegisterValueChangedCallback(changeEvent => OnActionImportDataChanged((ActionImportData)changeEvent.newValue));

			toolbar.Add(new ToolbarSpacer {flex = true});
			toolbar.Add(dataField);
			toolbar.Add(new ToolbarSpacer {flex = true});

			toolbar.Add(importField);
			toolbar.Add(targetTypesMenu);
			toolbar.Add(targetTypeLabel);
			toolbar.Add(new ToolbarSpacer {flex = true});

			rootVisualElement.Add(toolbar);
		}

		void ConstructGraphView()
		{
			graphView = new TreeGraphView {name = "Tree Graph"};
			graphView.StretchToParentSize();

			graphView.RegisterCallback<KeyUpEvent>(OnKeyUp);

			rootVisualElement.Add(graphView);
		}

		void OnDataChanged(BehaviorTreeBlueprintData data)
		{
			currentData = data;
			dataField.SetValueWithoutNotify(data);

			OnTargetTypeChanged(data != null ? data.TargetType : null);
		}

		void OnActionImportDataChanged(ActionImportData data)
		{
			var menu = targetTypesMenu.menu;
			var typeList = menu.MenuItems();

			typeList.Clear();

			foreach (var type in from import in data.imports
								 group import by import.method.Type
								 into types
								 select types.Key)
			{
				menu.AppendAction(type.ToString(), _ => OnTargetTypeChanged(type));
			}
		}

		void OnTargetTypeChanged(SerializableType type)
		{
			if (currentData == null) return;

			currentData.TargetType = type;
			targetTypeLabel.text = type == null ? "None" : type.ToString();
		}

		void OnKeyUp(KeyUpEvent keyEvent)
		{
			if (keyEvent.character != ' ') return; //Only listens for the space key
			graphView.EnableNodeAdder(keyEvent.originalMousePosition);
		}
	}
}