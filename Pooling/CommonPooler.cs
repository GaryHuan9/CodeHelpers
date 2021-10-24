using System.Diagnostics;
using System.Text;

namespace CodeHelpers.Pooling
{
	public static class CommonPooler
	{
		public static readonly StringBuilderPooler stringBuilder = new StringBuilderPooler();
		public static readonly StopwatchPooler stopwatch = new StopwatchPooler();

#if CODEHELPERS_UNITY
		public static readonly MeshPooler mesh = new MeshPooler();
#endif
	}

	public class StringBuilderPooler : PoolerBase<StringBuilder>
	{
		public StringBuilderPooler(int maxPoolSize = 4) => MaxPoolSize = maxPoolSize;

		protected override int MaxPoolSize { get; }

		protected override StringBuilder GetNewObject() => new StringBuilder();
		protected override void Reset(StringBuilder target) => target.Clear();
	}

	public class StopwatchPooler : PoolerBase<Stopwatch>
	{
		public StopwatchPooler(int maxPoolSize = 4) => MaxPoolSize = maxPoolSize;

		protected override int MaxPoolSize { get; }

		protected override Stopwatch GetNewObject() => new Stopwatch();
		protected override void Reset(Stopwatch target) => target.Reset();
	}

#if CODEHELPERS_UNITY
	public class MeshPooler : PoolerBase<UnityEngine.Mesh>
	{
		protected override int MaxPoolSize => 6;

		public override UnityEngine.Mesh GetObject()
		{
			UnityEngine.Mesh mesh;

			do mesh = base.GetObject();
			while (mesh == null);

			return mesh;
		}

		public override void ReleaseObject(UnityEngine.Mesh target)
		{
			if (target == null) return;
			base.ReleaseObject(target);
		}

		protected override UnityEngine.Mesh GetNewObject() => new UnityEngine.Mesh();
		protected override void Reset(UnityEngine.Mesh target) => target.Clear();
	}

#endif
}