using UnityEngine;
using System.Collections;
using System;
using CodeHelpers.InputHelpers;
using System.Reflection;

namespace CodeHelpers
{
	[AddComponentMenu("CodeHelper"), DefaultExecutionOrder(-200)]
	public class CodeHelperMonoBehaviour : MonoBehaviour
	{
		void Awake()
		{
			if (SingletonHelper.QuietDestroyCurrent(ref instance, this) != this) return;

			DontDestroyOnLoad(this);

			typeof(ThreadHelpers.ThreadHelper).GetField("mainThread", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, System.Threading.Thread.CurrentThread);
		}

		public static event Action OnApplicationQuitMethods;
		public static event Action UnityDrawGizmosMethods;

		public static event Action UnityPreUpdateMethods;
		public static event Action UnityUpdateMethods;
		public static event Action UnityLateUpdateMethods;
		public static event Action UnityEndUpdateMethods;

		public static event Action UnityPostRenderMethods;

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
		public static event Action OnUnityEndUpdateMethods;

		internal static CodeHelperMonoBehaviour instance;

		public static FramePhase FramePhase { get; private set; }

		public static bool IsGamePaused { get; private set; }
		public static bool IsGameQuitted { get; private set; }

		void Start()
		{
			StartCoroutine(EndOfFrameUpdate());
		}

#region Updates

		void PreUpdate()
		{
			InputHelper.inputInfoFromKey.ForEach(thisPair => thisPair.Value.UpdateInfo());

			FramePhase = FramePhase.pre;

			CodeHelper.invokeBeforeFrame.InvokeAll();

			//EVERYTHING THAT'S NOT INTERNAL SHOULD BE AFTER THIS LINE

			UnityPreUpdateMethods?.Invoke();

			OnUnityPreUpdateMethods?.Invoke();
			OnUnityPreUpdateMethods = null;
		}

		void Update()
		{
			PreUpdate();

			FramePhase = FramePhase.middle;

			CodeHelper.invokeNextFrame.InvokeAll();
			UnityUpdateMethods?.Invoke();

			OnUnityUpdateMethods?.Invoke();
			OnUnityUpdateMethods = null;
		}

		void LateUpdate()
		{
			FramePhase = FramePhase.late;

			UnityLateUpdateMethods?.Invoke();

			OnUnityLateUpdateMethods?.Invoke();
			OnUnityLateUpdateMethods = null;
		}

		void EndUpdate()
		{
			FramePhase = FramePhase.end;

			CodeHelper.invokeEndFrame.InvokeAll();
			UnityEndUpdateMethods?.Invoke();

			OnUnityEndUpdateMethods?.Invoke();
			OnUnityEndUpdateMethods = null;
		}

#endregion

		void OnApplicationQuit()
		{
			IsGameQuitted = true;

			OnApplicationQuitMethods?.Invoke();
			UnityDrawGizmosMethods = null;
		}

		void OnPostRender()
		{
			UnityPostRenderMethods?.Invoke();
		}

		IEnumerator EndOfFrameUpdate()
		{
			WaitForEndOfFrame endUpdate = new WaitForEndOfFrame();
			WaitUntil unPause = new WaitUntil(() => !IsGamePaused);

			while (true)
			{
				if (IsGamePaused) yield return unPause;
				yield return endUpdate;

				EndUpdate();
			}
		}

		void OnDrawGizmos()
		{
			UnityDrawGizmosMethods?.Invoke();
		}

		void OnApplicationFocus(bool hasFocus)
		{
			IsGamePaused = !hasFocus;
		}

		void OnApplicationPause(bool pauseStatus)
		{
			IsGamePaused = pauseStatus;
		}
	}

	public enum FramePhase
	{
		pre,
		middle,
		late,
		end
	}
}