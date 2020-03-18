using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.Assertions;
using Assembly = System.Reflection.Assembly;

namespace CodeHelpers.AI.BehaviorTrees.UIEditor
{
	public class ActionImportDataEditorWindow : EditorWindow
	{
		[MenuItem("Window/CodeHelpers/Behavior Trees/Action Import Editor")]
		public static void Open() => Open(null);

		public static void Open(ActionImportData data)
		{
			var window = GetWindow<ActionImportDataEditorWindow>("Action Import Editor");

			window.minSize = new Vector2(500f, 300f);

			window.currentData = data;
			window.Show();
		}

		void OnEnable()
		{
			header = new HeaderSection(this);
			selection = new SelectionSection(this);
			actionEdit = new ActionEditSection(this);
			methodSearch = new MethodSearchSection(this);
		}

		ActionImportData currentData;
		bool isDirtied;

		HeaderSection header;
		SelectionSection selection;
		ActionEditSection actionEdit;
		MethodSearchSection methodSearch;

		void OnGUI()
		{
			DefineSections();
			header.Draw();

			if (currentData == null)
			{
				GUILayout.Label("No Method Import Data Selected");
				return;
			}

			selection.Draw();
			actionEdit.Draw();
			methodSearch.Draw();

			if (isDirtied)
			{
				EditorUtility.SetDirty(currentData);
				isDirtied = false;
			}
		}

		void DefineSections()
		{
			Vector2 size = position.size;

			header.orientation = new Rect(0f, 0f, size.x, 30f);
			selection.orientation = new Rect(0f, header.orientation.height, 300f, size.y - header.orientation.height);

			actionEdit.orientation = new Rect
			(
				selection.orientation.width, header.orientation.height,
				(size.x - selection.orientation.width) / 3f, size.y - header.orientation.height
			);

			methodSearch.orientation = new Rect
			(
				actionEdit.orientation.xMax, actionEdit.orientation.yMin,
				actionEdit.orientation.width * 2f, actionEdit.orientation.height
			);
		}

		abstract class Section
		{
			protected Section(ActionImportDataEditorWindow window) => this.window = window;

			protected readonly ActionImportDataEditorWindow window;
			public Rect orientation;

			protected virtual GUIStyle AreaStyle => null;

			public void Draw()
			{
				if (AreaStyle == null) GUILayout.BeginArea(orientation);
				else GUILayout.BeginArea(orientation, AreaStyle);

				DrawInternal();
				GUILayout.EndArea();
			}

			protected abstract void DrawInternal();

			protected void MarkDataDirty() => window.isDirtied = true;
			protected bool RemoveItemWarn(string message) => EditorUtility.DisplayDialog(message, "", "Ok", "Cancel");
		}

		class HeaderSection : Section
		{
			public HeaderSection(ActionImportDataEditorWindow window) : base(window) { }

			protected override void DrawInternal()
			{
				GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();

				GUILayout.Label("Action Import Data");
				window.currentData = (ActionImportData)EditorGUILayout.ObjectField(window.currentData, typeof(ActionImportData), false);

				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
			}
		}

		class SelectionSection : Section
		{
			public SelectionSection(ActionImportDataEditorWindow window) : base(window) { }

			Vector2 scrollPosition;
			public ActionImport Selected { get; private set; }

			protected override void DrawInternal()
			{
				var imports = window.currentData.imports;
				Assert.IsNotNull(imports);

				GUILayout.BeginHorizontal();

				if (GUILayout.Button("Add New"))
				{
					imports.Add(new ActionImport());
					MarkDataDirty();
				}

				GUILayout.EndHorizontal();

				scrollPosition = GUILayout.BeginScrollView(scrollPosition);

				for (int i = 0; i < imports.Count; i++)
				{
					ActionImport import = imports[i];
					bool selected = Selected == import;

					GUILayout.BeginHorizontal(EditorStyles.helpBox);

					GUILayout.Label(import.name);
					GUILayout.FlexibleSpace();

					if (GUILayout.Button("Remove") && RemoveItemWarn("Remove method?"))
					{
						imports.RemoveAt(i);
						MarkDataDirty();
						if (selected) Selected = null;

						i--;
						continue;
					}

					if (GUILayout.Toggle(selected, "Edit", GUI.skin.button) != selected) Selected = selected ? null : import;

					GUILayout.EndHorizontal();
				}

				GUILayout.EndScrollView();
			}
		}

		class ActionEditSection : Section
		{
			public ActionEditSection(ActionImportDataEditorWindow window) : base(window) { }

			protected override GUIStyle AreaStyle => EditorStyles.helpBox;

			protected override void DrawInternal()
			{
				ActionImport selected = window.selection.Selected;

				if (selected == null)
				{
					GUILayout.Label("No action selected");
					return;
				}

				string newName = EditorGUILayout.TextField("Action Name", selected.name);
				if (newName != selected.name)
				{
					selected.name = newName;
					MarkDataDirty();
				}

				EditorGUILayout.Space();

				GUILayout.BeginVertical(EditorStyles.helpBox);
				GUILayout.BeginHorizontal();

				GUILayout.Label("Method");
				GUILayout.FlexibleSpace();

				GUILayout.Label(selected.method != null ? selected.method.ToString() : "None");

				GUILayout.EndHorizontal();
				GUILayout.BeginHorizontal();

				GUILayout.Label("Target type");
				GUILayout.FlexibleSpace();
				GUILayout.Label(selected.method != null ? selected.method.Type.ToString() : "None");

				GUILayout.EndHorizontal();

				if (selected.method != null && GUILayout.Button("Remove Method") && RemoveItemWarn("Remove assigned method?")) AssignMethod(null);

				GUILayout.EndVertical();

				if (selected.method == null)
				{
					GUILayout.BeginHorizontal(EditorStyles.helpBox);

					EditorGUIUtility.SetIconSize(Vector2.one * EditorGUIUtility.singleLineHeight);
					GUILayout.Label(EditorGUIUtility.IconContent("console.warnicon"));

					GUILayout.FlexibleSpace();
					GUILayout.Label("No assigned method! This behavior action will not show up when searching", new GUIStyle(GUI.skin.label) {wordWrap = true});

					GUILayout.EndHorizontal();
				}
			}

			public void AssignMethod(SerializableMethod method)
			{
				ActionImport selected = window.selection.Selected;

				if (selected == null)
				{
					EditorUtility.DisplayDialog("No action selected!", "Please select an action before assigning the method.", "ok");
					return;
				}

				if (selected.method == method) return;
				if (selected.method != null && !RemoveItemWarn("Replace method?")) return;

				selected.method = method;
				MarkDataDirty();
			}
		}

		class MethodSearchSection : Section
		{
			public MethodSearchSection(ActionImportDataEditorWindow window) : base(window) { }

			protected override GUIStyle AreaStyle => EditorStyles.helpBox;

			Dictionary<Assembly, AssemblyState> assemblies;
			SerializableMethod[] methodPaths;

			string searchingKeyword;
			string sortedKeyword; //The keyword that we last used to sort the paths

			Vector2 assemblyScrollPosition;
			Vector2 methodScrollPosition;

			protected override void DrawInternal()
			{
				GUILayout.BeginVertical(EditorStyles.helpBox);
				GUILayout.BeginHorizontal();

				if (GUILayout.Button("Rescan Assemblies") || assemblies == null) ScanAssembly();
				if (GUILayout.Button("Rescan Behavior Actions") || methodPaths == null) ScanActions();

				GUILayout.EndHorizontal();
				GUILayout.BeginHorizontal();

				EditorGUIUtility.SetIconSize(Vector2.one * EditorGUIUtility.singleLineHeight);
				GUILayout.Label(EditorGUIUtility.IconContent("Search Icon"));

				searchingKeyword = GUILayout.TextField(searchingKeyword);
				if (searchingKeyword != sortedKeyword) SortMethodPaths();

				GUILayout.EndHorizontal();
				GUILayout.EndVertical();

				GUILayout.BeginHorizontal();
				GUILayout.BeginVertical(EditorStyles.helpBox);

				GUILayout.Label("Select assemblies to scan for behavior actions");
				EditorGUILayout.Space();

				assemblyScrollPosition = GUILayout.BeginScrollView(assemblyScrollPosition);

				foreach (KeyValuePair<Assembly, AssemblyState> pair in assemblies)
				{
					pair.Value.included = GUILayout.Toggle(pair.Value.included, pair.Key.GetName().Name);
				}

				GUILayout.EndScrollView();
				GUILayout.EndVertical();

				methodScrollPosition = GUILayout.BeginScrollView(methodScrollPosition);

				if (methodPaths.Length == 0)
				{
					GUILayout.BeginHorizontal(EditorStyles.helpBox);

					GUILayout.Label("No method scanned");
					GUILayout.FlexibleSpace();

					GUILayout.EndHorizontal();
				}

				for (int i = 0; i < methodPaths.Length; i++)
				{
					var method = methodPaths[i];
					GUILayout.BeginHorizontal(EditorStyles.helpBox);

					GUILayout.Label(method.ToString());
					GUILayout.FlexibleSpace();

					if (GUILayout.Button("Assign")) window.actionEdit.AssignMethod(method);

					GUILayout.EndHorizontal();
				}

				GUILayout.EndScrollView();
				GUILayout.EndHorizontal();
			}

			void ScanAssembly()
			{
				if (assemblies == null) assemblies = new Dictionary<Assembly, AssemblyState>();
				var source = AppDomain.CurrentDomain.GetAssemblies();

				HashSet<Assembly> containedAssemblies = new HashSet<Assembly>(assemblies.Keys); //Assemblies we need to remove
				var allowedAssemblyNames = new HashSet<string>(CompilationPipeline.GetAssemblies().Select(assembly => assembly.name));

				for (int i = 0; i < source.Length; i++)
				{
					Assembly assembly = source[i];
					string name = assembly.GetName().Name;

					if (assembly.IsDynamic || !allowedAssemblyNames.Contains(name) || name.StartsWith("Unity.")) continue;
					containedAssemblies.Remove(assembly);

					if (assemblies.ContainsKey(assembly)) continue;
					assemblies.Add(assembly, new AssemblyState(name.StartsWith("Assembly-CSharp")));
				}

				foreach (Assembly assembly in containedAssemblies) assemblies.Remove(assembly);                                      //Remove old assemblies
				assemblies = assemblies.OrderBy(pair => pair.Key.GetName().Name).ToDictionary(pair => pair.Key, pair => pair.Value); //Who cares about allocation? XD
			}

			void ScanActions()
			{
				Assert.IsNotNull(assemblies);

				SortMethodPaths
				(
					from pair in assemblies
					where pair.Value.included
					from type in pair.Key.GetTypes()
					from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
					where Attribute.IsDefined(method, typeof(BehaviorActionAttribute)) && method.GetParameters().Length == 1
					select new SerializableMethod(method)
				);
			}

			void SortMethodPaths(IEnumerable<SerializableMethod> paths = null)
			{
				methodPaths = (paths ?? methodPaths).OrderByDescending(method => method.CompareToKeyword(searchingKeyword)).ToArray();
				sortedKeyword = searchingKeyword;
			}

			class AssemblyState
			{
				public AssemblyState(bool included = false) => this.included = included;

				/// <summary>
				/// Should this assembly be included during method scanning?
				/// </summary>
				public bool included;
			}
		}
	}
}