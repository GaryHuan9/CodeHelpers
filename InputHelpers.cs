﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeHelpers;

namespace CodeHelpers.InputHelpers
{
	public static class InputHelper
	{
		static readonly Dictionary<InputSource, InputInfo> registeredInfo = new Dictionary<InputSource, InputInfo>();

		static float Time => UnityEngine.Time.unscaledTime;
		const float DefaultCheckDelay = 0.25f;

		/// <summary>
		/// This is invoked specifically by <see cref="CodeHelperMonoBehaviour"/> to make sure it is in the pre update frame phase and before all other pre update invokes
		/// </summary>
		internal static void PreUpdate()
		{
			foreach (var pair in registeredInfo) pair.Value.Update();
		}

		public static void RegisterInput(int mouseButton) => RegisterInput(new InputSource(mouseButton));
		public static void RegisterInput(KeyCode keyCode) => RegisterInput(new InputSource(keyCode));

		static void RegisterInput(InputSource source)
		{
			if (registeredInfo.ContainsKey(source)) return; //Input already registered
			registeredInfo.Add(source, new InputInfo(source));
		}

		/// <summary>
		/// Is the current input any number? Returns null if no number
		/// </summary>
		public static int? AnyNumber => int.TryParse(Input.inputString, out int outInt) ? outInt : (int?)null;

		public static Vector2Int GetWASDMovement(KeyCode wKey = KeyCode.W, KeyCode aKey = KeyCode.A, KeyCode sKey = KeyCode.S, KeyCode dKey = KeyCode.D) =>
			new Vector2Int
			(
				(Input.GetKey(dKey) ? 1 : 0) + (Input.GetKey(aKey) ? -1 : 0),
				(Input.GetKey(wKey) ? 1 : 0) + (Input.GetKey(sKey) ? -1 : 0)
			);
		
		static InputInfo GetInfo(InputSource source) => registeredInfo.TryGetValue(source) ?? throw ExceptionHelper.Invalid(nameof(source), source, "is not registered!");

		//NOTE: The following check method should/would be invoked after all input are already updated this frame
		
		static bool GetInputHeldLessThan(InputSource source, float time = DefaultCheckDelay) => source.IsInputUp && Time - GetInfo(source).LastInputDownTime < time;

		public static bool GetInputHeldLessThan(int mouseButton) => GetInputHeldLessThan(new InputSource(mouseButton));
		public static bool GetInputHeldLessThan(KeyCode keyCode) => GetInputHeldLessThan(new InputSource(keyCode));
		
		static bool GetInputDoublePressed(InputSource source, float time = DefaultCheckDelay) => source.IsInputDown && Time - GetInfo(source).PreviousInputDownTime < time;

		public static bool GetInputDoublePressed(int mouseButton) => GetInputDoublePressed(new InputSource(mouseButton));
		public static bool GetInputDoublePressed(KeyCode keyCode) => GetInputDoublePressed(new InputSource(keyCode));

		class InputInfo
		{
			public InputInfo(InputSource source) => this.source = source;

			readonly InputSource source;

			public float LastInputDownTime { get; private set; } = float.MinValue;
			public float PreviousInputDownTime { get; private set; } = float.MinValue;
			
			public float LastInputUpTime { get; private set; } = float.MinValue;
			public float PreviousInputUpTime { get; private set; } = float.MinValue;
			
			public void Update()
			{
				if (source.IsInputDown)
				{
					PreviousInputDownTime = LastInputDownTime;
					LastInputDownTime = Time;
				}

				if (source.IsInputUp)
				{
					PreviousInputUpTime = LastInputUpTime;
					LastInputUpTime = Time;
				}
			}
		}

		readonly struct InputSource
		{
			public InputSource(KeyCode keyCode) => keyData = (int)keyCode;
			public InputSource(int mouseButton) => keyData = -mouseButton - 1;

			readonly int keyData; //If this is larger or equals to 0 then it is a key, or else it is a mouse button, -1=left -2=right -3=middle
			public bool IsKeyboardKey => keyData >= 0;

			public KeyCode KeyCode => IsKeyboardKey ? (KeyCode)keyData : throw new Exception("Input is not a keyboard key");
			public int MouseButton => IsKeyboardKey ? throw new Exception("Input is not a mouse button") : -keyData - 1;

			public bool IsInputDown => IsKeyboardKey ? Input.GetKeyDown((KeyCode)keyData) : Input.GetMouseButtonDown(-keyData - 1);
			public bool IsInputUp => IsKeyboardKey ? Input.GetKeyUp((KeyCode)keyData) : Input.GetMouseButtonUp(-keyData - 1);

			public override int GetHashCode() => keyData;
		}
	}
}