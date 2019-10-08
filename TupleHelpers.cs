namespace CodeHelpers
{
	public static class TupleHelper
	{
		public static (T2, T1) Swap<T1, T2>(this (T1, T2) tuple) => (tuple.Item2, tuple.Item1);

		public static (T1, T3, T2) SwapXZY<T1, T2, T3>(this (T1, T2, T3) tuple) => (tuple.Item1, tuple.Item3, tuple.Item2);
		public static (T2, T1, T3) SwapYXZ<T1, T2, T3>(this (T1, T2, T3) tuple) => (tuple.Item2, tuple.Item1, tuple.Item3);
		public static (T2, T3, T1) SwapYZX<T1, T2, T3>(this (T1, T2, T3) tuple) => (tuple.Item2, tuple.Item3, tuple.Item1);
		public static (T3, T1, T2) SwapZXY<T1, T2, T3>(this (T1, T2, T3) tuple) => (tuple.Item3, tuple.Item1, tuple.Item2);
		public static (T3, T2, T1) SwapZYX<T1, T2, T3>(this (T1, T2, T3) tuple) => (tuple.Item3, tuple.Item2, tuple.Item1);
	}
}