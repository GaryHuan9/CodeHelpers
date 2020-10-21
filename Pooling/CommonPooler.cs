using System.Diagnostics;
using System.Text;

namespace CodeHelpers.ObjectPooling
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
		protected override int MaxPoolSize => 4;

		protected override StringBuilder GetNewObject() => new StringBuilder();
		protected override void Reset(StringBuilder target) => target.Clear();
	}

	public class StopwatchPooler : PoolerBase<Stopwatch>
	{
		protected override int MaxPoolSize => 4;

		protected override Stopwatch GetNewObject() => new Stopwatch();
		protected override void Reset(Stopwatch target) => target.Reset();
	}

#if CODEHELPERS_UNITY

	public class MeshPooler : PoolerBase<UnityEngine.Mesh>
	{
		protected override int MaxPoolSize => 6;

		protected override UnityEngine.Mesh GetNewObject() => new UnityEngine.Mesh();
		protected override void Reset(UnityEngine.Mesh target) => target.Clear();
	}

#endif
}