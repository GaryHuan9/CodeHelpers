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
		ObjectField importField;
		ToolbarMenu targetContextMenu;
		Label targetContextLabel;

		BehaviorTreeBlueprintData _currentData;
		ActionImportData _importData;

		public BehaviorTreeBlueprintData CurrentData
		{
			get => _currentData;
			set
			{
				if (CurrentData == value) return;
				_currentData = value;

				dataField?.SetValueWithoutNotify(CurrentData);
				ImportData = CurrentData == null ? null : CurrentData.importData;
			}
		}

		public ActionImportData ImportData
		{
			get => _importData;
			set
			{
				DebugHelper.Log("HIHI");

				if (ImportData == value) return;
				_importData = value;

				if (CurrentData != null)
				{
					CurrentData.importData = ImportData;
					EditorUtility.SetDirty(CurrentData);
				}

				importField?.SetValueWithoutNotify(ImportData);
				RecalculateTargetContextMenu();

				SetTargetContextType(CurrentData == null ? null : CurrentData.targetContextTypeMethod);
			}
		}

		public Type TargetContextType => CurrentData == null || CurrentData.targetContextTypeMethod == null ? null : CurrentData.targetContextTypeMethod.TargetContextType;

		public event Action OnTargetContextChangedMethods;

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
			importField = new ObjectField("Action Import Data") {allowSceneObjects = false, objectType = typeof(ActionImportData), value = ImportData};

			targetContextMenu = new ToolbarMenu {text = "Target Type", variant = ToolbarMenu.Variant.Default};
			targetContextLabel = new Label();

			targetContextMenu.styleSheets.Add(MainStyleSheet);

			dataField.RegisterValueChangedCallback(changeEvent => CurrentData = (BehaviorTreeBlueprintData)changeEvent.newValue);
			importField.RegisterValueChangedCallback(changeEvent => ImportData = (ActionImportData)changeEvent.newValue);

			toolbar.Add(new ToolbarSpacer {flex = true});
			toolbar.Add(dataField);
			toolbar.Add(new ToolbarSpacer {flex = true});

			toolbar.Add(importField);
			toolbar.Add(targetContextMenu);
			toolbar.Add(targetContextLabel);
			toolbar.Add(new ToolbarSpacer {flex = true});

			rootVisualElement.Add(toolbar);

			RecalculateTargetContextMenu();
			RecalculateTargetContextLabel();
		}

		void ConstructGraphView()
		{
			graphView = new TreeGraphView(this) {name = "Tree Graph"};
			graphView.StretchToParentSize();

			rootVisualElement.Add(graphView);
		}

		void SetTargetContextType(SerializableMethod contextTypeMethod)
		{
			if (contextTypeMethod?.TargetContextType == TargetContextType) return;

			if (CurrentData != null)
			{
				CurrentData.targetContextTypeMethod = contextTypeMethod;
				EditorUtility.SetDirty(CurrentData);
			}

			RecalculateTargetContextLabel();
			OnTargetContextChangedMethods?.Invoke();
		}

		void RecalculateTargetContextMenu()
		{
			var menu = targetContextMenu.menu;

			menu.MenuItems().Clear();
			if (ImportData == null) return;

			foreach (var pair in from import in ImportData.actions
								 group import by import.method.TargetContextType
								 into types
								 select (types.Key, types.First()))
			{
				menu.AppendAction(pair.Key.ToString(), _ => SetTargetContextType(pair.Item2.method));
			}
		}

		void RecalculateTargetContextLabel() => targetContextLabel.text = TargetContextType?.ToString() ?? "None";
	}
}