using CodeHelpers.ObjectPooling;
using UnityEngine;

namespace CodeHelpers.MeshHelpers
{
	public class MeshPooler : PoolerBase<Mesh>
	{
		public MeshPooler(int maxPoolSize = 6) => MaxPoolSize = maxPoolSize;

		protected override int MaxPoolSize { get; }

		protected override Mesh GetNewObject() => new Mesh();
		protected override void Reset(Mesh target) => target.Clear();
	}
}