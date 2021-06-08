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

		public float Velocity => _velocity;

		[field: SerializeField] public float Target { get; set; }
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
			Changed = false;
			Current = Scalars.Damp(Current, Target, ref _velocity, SmoothTime, deltaTime);
		}

		public static void Update(float deltaTime, params DampedValue[] values)
		{
			for (int i = 0; i < values.Length; i++) values[i].Update(deltaTime);
		}
	}
}