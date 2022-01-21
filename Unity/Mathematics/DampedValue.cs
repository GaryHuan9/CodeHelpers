#if CODE_HELPERS_UNITY

using System;
using CodeHelpers.Mathematics;
using UnityEngine;

namespace CodeHelpers.Unity.Mathematics
{
	[Serializable]
	public class DampedValue
	{
		public DampedValue(float target = 0f, float smoothTime = 1f)
		{
			Target = target;
			SmoothTime = smoothTime;
		}

		[SerializeField] float _current;
		[SerializeField] float _velocity;

		public float Current
		{
			get => _current;
			set
			{
				if (_current.AlmostEquals(value)) return;

				_current = value;
				Changed = true;

				OnCurrentChangedMethods?.Invoke(this);
			}
		}

		public float Velocity
		{
			get => _velocity;
			private set => _velocity = value;
		}

		[field: SerializeField] public DampedMode Mode { get; set; } = DampedMode.damp;

		/// <summary>
		/// The <see cref="Target"/> of this <see cref="DampedValue"/> to advance <see cref="Current"/> towards.
		/// </summary>
		[field: SerializeField] public float Target { get; set; }

		/// <summary>
		/// This property performs differently under different <see cref="Mode"/>. If <see cref="Mode"/> is <see cref="DampedMode.damp"/>,
		/// this value indicates the approximated time for <see cref="Current"/> to arrive at <see cref="Target"/>. If <see cref="Mode"/>
		/// is <see cref="DampedMode.linear"/>, this value indicates the time it takes for <see cref="Current"/> to navigate a distance of 1.
		/// </summary>
		[field: SerializeField] public float SmoothTime { get; set; }

		/// <summary>
		/// Indicates whether <see cref="Current"/> has been changed during or since the last time we invoked <see cref="Update(float)"/>.
		/// </summary>
		public bool Changed { get; private set; }

		/// <summary>
		/// This delegate is invoked anytime <see cref="Current"/> is modified.
		/// </summary>
		public event Action<DampedValue> OnCurrentChangedMethods;

		public void Update(float deltaTime)
		{
			float current;

			switch (Mode)
			{
				case DampedMode.damp:
				{
					current = Scalars.Damp(Current, Target, ref _velocity, SmoothTime, deltaTime);
					break;
				}
				case DampedMode.linear:
				{
					float maxDelta = deltaTime / SmoothTime;
					float distance = Target - Current;

					if (Math.Abs(distance) <= maxDelta) current = Target;
					else current = Current + maxDelta * Math.Sign(distance);

					CalculateVelocity();

					break;
				}
				case DampedMode.instant:
				{
					current = Target;
					CalculateVelocity();

					break;
				}
				default: throw ExceptionHelper.Invalid(nameof(Mode), Mode, InvalidType.unexpected);
			}

			Changed = false;
			Current = current;

			void CalculateVelocity() => Velocity = (current - Current) / deltaTime;
		}

		public static void Update(float deltaTime, params DampedValue[] values)
		{
			for (int i = 0; i < values.Length; i++) values[i].Update(deltaTime);
		}
	}

	public enum DampedMode : byte
	{
		damp,
		linear,
		instant
	}
}

#endif