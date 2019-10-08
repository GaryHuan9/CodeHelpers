using System;
using UnityEngine;

namespace CodeHelpers
{
	public static class CurveHelper
	{
		public static InputCheckMode CheckMode { get; set; } = InputCheckMode.exception;

		static void CheckRange(ref float input)
		{
			switch (CheckMode)
			{
				case InputCheckMode.exception:
					if (input < 0f || input > 1f) throw ExceptionHelper.Invalid(nameof(input), input, InvalidType.outOfBounds);
					break;

				case InputCheckMode.clamp:
					input = Mathf.Clamp01(input);
					break;

				default: throw ExceptionHelper.NotPossible;
			}
		}

		public static float Flip(float input)
		{
			CheckRange(ref input);
			return 1f - input;
		}

		public static float Linear(float input)
		{
			CheckRange(ref input);
			return input;
		}

		public static float Sigmoid(float input)
		{
			CheckRange(ref input);
			return 0.5f + 0.5f * Mathf.Sin(input * Mathf.PI - Mathf.PI * 0.5f);
		}

		public static float EaseIn(float input)
		{
			CheckRange(ref input);
			return input * input;
		}

		public static float EaseOut(float input)
		{
			CheckRange(ref input);
			return Flip(EaseIn(input));
		}

		/// <summary>
		/// <paramref name="acceleration"/> is how fast will input speed up/slow down
		/// 0 means no speed change (linear); negative means slowing down; positive means speeding up
		/// </summary>
		public static float Ease(float input, float acceleration)
		{
			CheckRange(ref input);
			return Mathf.Pow(input, acceleration >= 0f ? acceleration + 1f : 1f / -(acceleration - 1f));
		}

		/// <summary>
		/// <paramref name="steepness"/> is how quick the input will grow in the middle
		/// lowest is 0f which means default speed
		/// Graph: https://www.desmos.com/calculator/v1ah3eu5zd
		/// </summary>
		public static float Sigmoid(float input, float steepness)
		{
			CheckRange(ref input);
			if (steepness < 0f) throw ExceptionHelper.Invalid(nameof(steepness), steepness, InvalidType.outOfBounds);

			steepness += 1f;
			float bounds = 0.5f * (steepness - 1f) / steepness;

			if (input <= bounds) return 0f;
			if (input >= 1f - bounds) return 1f;

			return 0.5f + 0.5f * Mathf.Sin((input * Mathf.PI - Mathf.PI * 0.5f) * steepness);
		}

		public enum InputCheckMode
		{
			exception,
			clamp
		}
	}
}