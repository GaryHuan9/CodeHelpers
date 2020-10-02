using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;
using CodeHelpers.InputHelpers;
using CodeHelpers.Events;
using CodeHelpers.ThreadHelpers;

namespace CodeHelpers
{
	[DefaultExecutionOrder(-200)]
	public class CodeHelperMonoBehavior : MonoBehaviour
	{
		void Awake()
		{
			if (SingletonHelper.QuietDestroyCurrent(ref instance, this) != this) return;
			frameTimeHelper = gameObject.AddComponent<FrameTimeHelper>();

			DontDestroyOnLoad(this);

			ThreadHelper.MainThread = System.Threading.Thread.CurrentThread;
		}

		/// <summary>
		/// Invoked on Unity's draw gizmos phase.
		/// NOTE: Remember to use <see cref="WeakEventHandler{TListener}"/> if you want to avoid memory leaks!
		/// </summary>
		public static event Action UnityDrawGizmosMethods;

		/// <summary>
		/// Invoked on Unity's pre update phase.
		/// NOTE: Remember to use <see cref="WeakEventHandler{TListener}"/> if you want to avoid memory leaks!
		/// </summary>
		public static event Action UnityPreUpdateMethods;

		/// <summary>
		/// Invoked on Unity's update phase.
		/// NOTE: Remember to use <see cref="WeakEventHandler{TListener}"/> if you want to avoid memory leaks!
		/// </summary>
		public static event Action UnityUpdateMethods;

		/// <summary>
		/// Invoked on Unity's late update phase.
		/// NOTE: Remember to use <see cref="WeakEventHandler{TListener}"/> if you want to avoid memory leaks!
		/// </summary>
		public static event Action UnityLateUpdateMethods;

		/// <summary>
		/// Invoked on Unity's fixed update phase.
		/// NOTE: Remember to use <see cref="WeakEventHandler{TListener}"/> if you want to avoid memory leaks!
		/// </summary>
		public static event Action UnityFixedUpdateMethods;

		/// <summary>
		/// Invoked on Unity's end update phase.
		/// NOTE: Remember to use <see cref="WeakEventHandler{TListener}"/> if you want to avoid memory leaks!
		/// </summary>
		public static event Action UnityEndUpdateMethods;

		/// <summary>
		/// Invoked on Unity's post render phase.
		/// NOTE: Remember to use <see cref="WeakEventHandler{TListener}"/> if you want to avoid memory leaks!
		/// </summary>
		public static event Action UnityPostRenderMethods;

		/// <summary>
		/// Invoked when the application quits
		/// NOTE: Remember to use <see cref="WeakEventHandler{TListener}"/> if you want to avoid memory leaks!
		/// </summary>
		public static event Action OnApplicationQuitMethods;

		/// <summary>
		/// NOTE: Any delegate subscribed to this will only be invoked once!
		/// </summary>
		public static event Action OnUnityPreUpdateMethods;

		/// <summary>
		/// NOTE: Any delegate subscribed to this will only be invoked once!
		/// </summary>
		public static event Action OnUnityUpdateMethods;

		/// <summary>
		/// NOTE: Any delegate subscribed to this will only be invoked once!
		/// </summary>
		public static event Action OnUnityLateUpdateMethods;

		/// <summary>
		/// NOTE: Any delegate subscribed to this will only be invoked once!
		/// </summary>
		public static event Action OnUnityFixedUpdateMethods;

		/// <summary>
		/// NOTE: Any delegate subscribed to this will only be invoked once!
		/// </summary>
		public static event Action OnUnityEndUpdateMethods;

		internal static CodeHelperMonoBehavior instance;
		internal static FrameTimeHelper frameTimeHelper;

		public static FramePhase FramePhase { get; private set; }
		public static float FrameTime => (float)frameTimeHelper.Elapsed.TotalMilliseconds;

		static bool _isGamePaused;

#if UNITY_EDITOR
		public static bool IsGamePaused => _isGamePaused || UnityEditor.EditorApplication.isPaused;
#else
		public static bool IsGamePaused => _isGamePaused;
#endif

		public static bool IsGameQuitting { get; private set; }

		void Start() => StartCoroutine(EndOfFrameCoroutine(EndUpdate));
		void OnApplicationPause(bool pauseStatus) => _isGamePaused = pauseStatus;

#region Updates

		void PreUpdate()
		{
			InputHelper.PreUpdate();
			FramePhase = FramePhase.Pre;

			CodeHelper.invokeBeforeFrame.InvokeAll();

			//EVERYTHING THAT'S NOT INTERNAL SHOULD BE AFTER THIS LINE

			UnityPreUpdateMethods?.Invoke();

			OnUnityPreUpdateMethods?.Invoke();
			OnUnityPreUpdateMethods = null;
		}

		void Update()
		{
			PreUpdate();

			FramePhase = FramePhase.Middle;

			CodeHelper.invokeNextFrame.InvokeAll();
			UnityUpdateMethods?.Invoke();

			OnUnityUpdateMethods?.Invoke();
			OnUnityUpdateMethods = null;
		}

		void FixedUpdate()
		{
			FramePhase = FramePhase.Fixed;

			UnityFixedUpdateMethods?.Invoke();

			OnUnityFixedUpdateMethods?.Invoke();
			OnUnityFixedUpdateMethods = null;
		}

		void LateUpdate()
		{
			FramePhase = FramePhase.Late;

			UnityLateUpdateMethods?.Invoke();

			OnUnityLateUpdateMethods?.Invoke();
			OnUnityLateUpdateMethods = null;
		}

		void EndUpdate()
		{
			FramePhase = FramePhase.End;

			CodeHelper.invokeEndFrame.InvokeAll();
			UnityEndUpdateMethods?.Invoke();

			OnUnityEndUpdateMethods?.Invoke();
			OnUnityEndUpdateMethods = null;
		}

#endregion

		void OnApplicationQuit()
		{
			IsGameQuitting = true;

			OnApplicationQuitMethods?.Invoke();
			UnityDrawGizmosMethods = null;
		}

		void OnPostRender()
		{
			UnityPostRenderMethods?.Invoke();
		}

		static IEnumerator EndOfFrameCoroutine(Action action)
		{
			WaitForEndOfFrame endUpdate = new WaitForEndOfFrame();
			WaitUntil unPause = new WaitUntil(() => !IsGamePaused);

			while (true)
			{
				yield return endUpdate;
				if (IsGamePaused) yield return unPause;

				action();
			}
		}

		void OnDrawGizmos()
		{
			UnityDrawGizmosMethods?.Invoke();
		}

		[DefaultExecutionOrder(200)]
		public class FrameTimeHelper : MonoBehaviour
		{
			void Awake()
			{
				stopwatch = new Stopwatch();
				StartCoroutine(EndOfFrameCoroutine(OnEndOfFrame));
			}

			Stopwatch stopwatch;

			public TimeSpan Elapsed => stopwatch.Elapsed;

			void OnEndOfFrame()
			{
				stopwatch.Reset();
				stopwatch.Start();
			}
		}
	}

	public enum FramePhase
	{
		Pre,
		Middle,
		Late,
		Fixed,
		End
	}
}