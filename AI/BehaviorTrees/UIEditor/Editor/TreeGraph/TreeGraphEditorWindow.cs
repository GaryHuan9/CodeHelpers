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
			window.minSize = new Vector2(500f, 300f);
		}

		void OnEnable()
		{
			ConstructGraphView();
			ConstructToolbar();

			serializer = new TreeGraphSerializer(this, graphView);
		}

		TreeGraphView graphView;
		Toolbar toolbar;
		TreeGraphSerializer serializer;

		ObjectField dataField;
		ObjectField importField;

		BehaviorTreeBlueprintData _currentData;
		ActionImportData _importData;

		public BehaviorTreeBlueprintData CurrentData
		{
			get => _currentData;
			private set
			{
				if (CurrentData == value) return;
				_currentData = value;

				dataField?.SetValueWithoutNotify(CurrentData);
				ImportData = CurrentData == null ? null : CurrentData.importData;

				if (CurrentData != null) DeserializeTreeData();
			}
		}

		public ActionImportData ImportData
		{
			get => _importData;
			private set
			{
				if (ImportData == value) return;
				_importData = value;

				if (CurrentData != null)
				{
					CurrentData.importData = ImportData;
					if (value == null) SetTargetContextType(null);

					MarkDirty();
				}

				importField?.SetValueWithoutNotify(ImportData);
				if (ImportData != null) ImportData.RecalculateGuidMapping();

				OnTargetContextChangedMethods?.Invoke();
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

			dataField.Q<Label>().style.minWidth = 64f;
			importField.Q<Label>().style.minWidth = 64f;

			dataField.RegisterValueChangedCallback(changeEvent => CurrentData = (BehaviorTreeBlueprintData)changeEvent.newValue);
			importField.RegisterValueChangedCallback(changeEvent => ImportData = (ActionImportData)changeEvent.newValue);

			var saveButton = new ToolbarButton(() => serializer.SerializeCurrent()) {text = "Save"};
			var loadButton = new ToolbarButton(DeserializeTreeData) {text = "Load"};

			toolbar.Add(new ToolbarSpacer {flex = true});
			toolbar.Add(dataField);
			toolbar.Add(new ToolbarSpacer {flex = true});
			toolbar.Add(importField);
			toolbar.Add(new ToolbarSpacer {flex = true});
			toolbar.Add(saveButton);
			toolbar.Add(loadButton);
			toolbar.Add(new ToolbarSpacer {flex = true});

			rootVisualElement.Add(toolbar);
		}

		void ConstructGraphView()
		{
			graphView = new TreeGraphView(this) {name = "Tree Graph"};
			graphView.StretchToParentSize();

			rootVisualElement.Add(graphView);
		}

		public void SetTargetContextType(SerializableMethod contextTypeMethod)
		{
			if (contextTypeMethod?.TargetContextType == TargetContextType) return;

			if (CurrentData != null)
			{
				CurrentData.targetContextTypeMethod = contextTypeMethod;
				MarkDirty();
			}

			OnTargetContextChangedMethods?.Invoke();
		}

		void MarkDirty()
		{
			EditorUtility.SetDirty(CurrentData);
		}

		void DeserializeTreeData()
		{
			if (CurrentData.rootNodes?.Length > 0) serializer.DeserializeData();
			else
			{
				graphView.DeleteAllElements();
				graphView.CreateRootNode();
			}
		}
	}
}