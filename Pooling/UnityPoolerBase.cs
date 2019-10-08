using System;
using CodeHelpers.DelayedExecution;
using UnityEngine;

namespace CodeHelpers.ObjectPooling
{
	public abstract class UnityPoolerBase<T> : PoolerBase<T> where T : UnityEngine.Object, new()
	{
		protected abstract T PrefabObject { get; }

		protected override T GetNewObject() => UnityEngine.Object.Instantiate(PrefabObject);
		protected override void Reset(T target) => SetEnable(target, true);

		public override void ReleaseObject(T target)
		{
			if (pool.Count < MaxPoolSize)
			{
				SetEnable(target, false);
				pool.Push(target);
			}
			else
			{
				DelayedDestroy.Destroy(target);
			}
		}

		void SetEnable(T target, bool enable)
		{
			if (target is Behaviour) ((Behaviour)(UnityEngine.Object)target).enabled = enable;
			if (target is GameObject) ((GameObject)(UnityEngine.Object)target).SetActive(enable);
		}
	}
}
