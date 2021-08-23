#if CODEHELPERS_UNITY

using System.Collections.Generic;
using UnityEngine;

namespace CodeHelpers.Unity.DelayedExecute
{
	public static class DelayedDestroy
	{
		static readonly List<Object> mustDestroyList = new List<Object>();
		static readonly Queue<Object> destroyQueue = new Queue<Object>();

		static readonly DelayedJob destroyJob = new DelayedJob(DestroyJobEnumerable(), 0.8f);

		/// <summary>
		/// The maximum time allowed to use in one frame to destroy objects.
		/// </summary>
		public static float MaxUsedMillisecond
		{
			get => destroyJob.MaxExecutionMillisecond;
			set => destroyJob.MaxExecutionMillisecond = value;
		}

		public static void Destroy(Object target)
		{
			if (target is null) throw ExceptionHelper.Invalid(nameof(target), InvalidType.isNull);
			if (target == null) return; //These two null comparison are actually different to unity types

			if (target is Transform transform) target = transform.gameObject;

			bool mustDestroy = false;

			//Disable target if available
			switch (target)
			{
				case Behaviour behaviour:

					behaviour.enabled = false;

					break;

				case GameObject gameObject:

					gameObject.SetActive(false);
					gameObject.transform.SetParent(null);

					break;

				case Rigidbody rigidbody:

					rigidbody.detectCollisions = false;
					rigidbody.isKinematic = true;

					break;

				case Rigidbody2D rigidbody:

					rigidbody.isKinematic = true;

					break;

				case Component component:

					mustDestroy = true;
					break;
			}

			//Add to job
			if (mustDestroy) mustDestroyList.Add(target);
			else destroyQueue.Enqueue(target);

			if (!destroyJob.IsJobExecuting) DelayedController.Start(destroyJob);
		}

		/// <summary>
		/// Destroy all the children game object in this <paramref name="transform"/>.
		/// </summary>
		public static void DestroyAllChildren(this Transform transform) //This sounds evil...
		{
			while (transform.childCount > 0) Destroy(transform.GetChild(0));
		}

		/// <summary>
		/// Destroy all the children game object in this <paramref name="gameObject"/>.
		/// </summary>
		public static void DestroyAllChildren(this GameObject gameObject) => gameObject.transform.DestroyAllChildren();

		static IEnumerable<int> DestroyJobEnumerable()
		{
			while (true)
			{
				if (mustDestroyList.Count != 0)
				{
					for (int i = 0; i < mustDestroyList.Count; i++) Object.Destroy(mustDestroyList[i]);
					mustDestroyList.Clear();

					yield return 0;
				}

				if (destroyQueue.Count != 0)
				{
					Object.Destroy(destroyQueue.Dequeue());
					yield return 1;
				}
				else yield return DelayedJob.ExitExecutionMark;
			}
		}
	}
}

#endif