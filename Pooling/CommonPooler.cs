using System.Text;

namespace CodeHelpers.ObjectPooling
{
	public static class CommonPooler
	{
		public static readonly StringBuilderPooler stringBuilder = new StringBuilderPooler();
	}

	public class StringBuilderPooler : PoolerBase<StringBuilder>
	{
		protected override int MaxPoolSize => 4;

		protected override StringBuilder GetNewObject() => new StringBuilder();
		protected override void Reset(StringBuilder target) => target.Clear();
	}
}