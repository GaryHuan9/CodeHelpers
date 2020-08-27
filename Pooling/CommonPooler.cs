using System.Text;
using UnityEngine;

namespace CodeHelpers.ObjectPooling
{
	public static class CommonPooler
	{
		public static readonly StringBuilderPooler stringBuilder = new StringBuilderPooler();
		public static readonly MeshPooler mesh = new MeshPooler();
	}

	public class StringBuilderPooler : PoolerBase<StringBuilder>
	{
		protected override int MaxPoolSize => 4;

		protected override StringBuilder GetNewObject() => new StringBuilder();
		protected override void Reset(StringBuilder target) => target.Clear();
	}

	public class MeshPooler : PoolerBase<Mesh>
	{
		protected override int MaxPoolSize => 6;

		protected override Mesh GetNewObject() => new Mesh();
		protected override void Reset(Mesh target) => target.Clear();
	}
}