#if CODE_HELPERS_UNITY

using System.Text;
using CodeHelpers.Diagnostics;
using CodeHelpers.Pooling;
using UnityEngine;

namespace CodeHelpers.Unity.Diagnostics
{
	public static class DebugHelperUnity
	{
		static readonly StringBuilderPooler builderPooler = new StringBuilderPooler();

		public static void PrintHierarchy()
		{
			using var builderHandle = builderPooler.Fetch();
			StringBuilder builder = builderHandle.Target;

			foreach (var root in Object.FindObjectsOfType<Transform>())
			{
				if (root.parent == null) PrintDeeper(root, 0);
			}

			void PrintDeeper(Transform parent, int depth)
			{
				builder.AppendLine($"{new string('\t', depth)}{parent}");

				for (int i = 0; i < parent.childCount; i++)
				{
					PrintDeeper(parent.GetChild(i), depth + 1);
				}
			}

			DebugHelper.Log(builder.ToString());
		}
	}
}

#endif