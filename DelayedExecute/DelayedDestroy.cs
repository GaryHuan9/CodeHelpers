using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace CodeHelpers.DelayedExecution
{
	public static class DelayedDestroy
	{
		static readonly Queue<Object> destroyQueue = new Queue<Object>();
		static readonly DelayedJob destroyJob = new DelayedJob(DestroyJobEnumerator(), 0.8f);

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
			if (target == null) throw ExceptionHelper.Invalid(nameof(target), target, InvalidType.isNull);
			if (target is Transform transform) target = transform.gameObject;

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
			}

			//Add to job
			destroyQueue.Enqueue(target);
			if (!destroyJob.IsJobExecuting) DelayedController.StartJob(destroyJob);
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

		static IEnumerator<int> DestroyJobEnumerator()
		{
			while (true)
			{
				if (destroyQueue.Count == 0) yield return DelayedJob.ExitExecutionMark;
				else
				{
					Object.Destroy(destroyQueue.Dequeue());
					yield return 0;
				}
			}
		}
	}
}