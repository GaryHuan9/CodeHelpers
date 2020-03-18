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
			window.CurrentData = data;
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

		BehaviorTreeBlueprintData _currentData;
		ActionImportData _importData;

		public BehaviorTreeBlueprintData CurrentData
		{
			get => _currentData;
			set
			{
				if (CurrentData == value) return;
				_currentData = value;

				dataField?.SetValueWithoutNotify(value);
				UpdateTargetTypeLabel();
			}
		}

		public ActionImportData ImportData
		{
			get => _importData;
			set
			{
				if (ImportData == value) return;
				_importData = value;

				var menu = targetTypesMenu.menu;
				var typeList = menu.MenuItems();

				typeList.Clear();
				UpdateTargetTypeLabel();
				if (value == null) return;

				foreach (var type in from import in value.imports
									 group import by import.method.Type
									 into types
									 select types.Key)
				{
					menu.AppendAction(
						type.ToString(), _ =>
						{
							if (CurrentData == null) return;

							CurrentData.TargetType = type;
							UpdateTargetTypeLabel();
						}
					);
				}
			}
		}

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

			dataField = new ObjectField("Behavior Tree Data") {allowSceneObjects = false, objectType = typeof(BehaviorTreeBlueprintData), value = CurrentData};
			var importField = new ObjectField("Action Import Data") {allowSceneObjects = false, objectType = typeof(ActionImportData), value = ImportData};

			targetTypesMenu = new ToolbarMenu {text = "Target Type", variant = ToolbarMenu.Variant.Default};
			targetTypeLabel = new Label();

			targetTypesMenu.styleSheets.Add(MainStyleSheet);
			UpdateTargetTypeLabel();

			dataField.RegisterValueChangedCallback(changeEvent => CurrentData = (BehaviorTreeBlueprintData)changeEvent.newValue);
			importField.RegisterValueChangedCallback(changeEvent => ImportData = (ActionImportData)changeEvent.newValue);

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
			graphView = new TreeGraphView(this) {name = "Tree Graph"};
			graphView.StretchToParentSize();

			rootVisualElement.Add(graphView);
		}

		void UpdateTargetTypeLabel()
		{
			var type = CurrentData == null ? null : CurrentData.TargetType;
			targetTypeLabel.text = type == null ? "None" : type.ToString();
		}
	}
}