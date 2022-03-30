using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeHelpers.Mathematics;

namespace CodeHelpers.Packed
{
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Int3 : IEquatable<Int3>, IFormattable
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Int3(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public int X { get; }
		public int Y { get; }
		public int Z { get; }

#region Properties

#region Static

		public static Int3 Right => new Int3(1, 0, 0);
		public static Int3 Left => new Int3(-1, 0, 0);

		public static Int3 Up => new Int3(0, 1, 0);
		public static Int3 Down => new Int3(0, -1, 0);

		public static Int3 Forward => new Int3(0, 0, 1);
		public static Int3 Backward => new Int3(0, 0, -1);

		public static Int3 One => new Int3(1, 1, 1);
		public static Int3 Zero => new Int3(0, 0, 0);
		public static Int3 NegativeOne => new Int3(-1, -1, -1);

		public static Int3 MaxValue => new Int3(int.MaxValue, int.MaxValue, int.MaxValue);
		public static Int3 MinValue => new Int3(int.MinValue, int.MinValue, int.MinValue);

		public static readonly ReadOnlyCollection<Int3> units8 = new ReadOnlyCollection<Int3>
		(
			new[]
			{
				new Int3(0, 0, 0), new Int3(1, 0, 0), new Int3(0, 0, 1), new Int3(1, 0, 1),
				new Int3(0, 1, 0), new Int3(1, 1, 0), new Int3(0, 1, 1), new Int3(1, 1, 1)
			}
		);

		public static readonly ReadOnlyCollection<Int3> faces6 = new ReadOnlyCollection<Int3>
		(
			new[]
			{
				new Int3(1, 0, 0), new Int3(-1, 0, 0),
				new Int3(0, 1, 0), new Int3(0, -1, 0),
				new Int3(0, 0, 1), new Int3(0, 0, -1)
			}
		);

		public static readonly ReadOnlyCollection<Int3> vertices8 = new ReadOnlyCollection<Int3>
		(
			new[]
			{
				new Int3(1, 1, 1), new Int3(-1, 1, 1), new Int3(1, 1, -1), new Int3(-1, 1, -1),
				new Int3(1, -1, 1), new Int3(-1, -1, 1), new Int3(1, -1, -1), new Int3(-1, -1, -1)
			}
		);

		public static readonly ReadOnlyCollection<Int3> edges12 = new ReadOnlyCollection<Int3>
		(
			new[]
			{
				new Int3(1, 1, 0), new Int3(0, 1, 1), new Int3(-1, 1, 0), new Int3(0, 1, -1),
				new Int3(1, 0, 1), new Int3(-1, 0, 1), new Int3(-1, 0, -1), new Int3(1, 0, -1),
				new Int3(1, -1, 0), new Int3(0, -1, 1), new Int3(-1, -1, 0), new Int3(0, -1, -1)
			}
		);

		public static readonly ReadOnlyCollection<Int3> facesVertices14 = new ReadOnlyCollection<Int3>(faces6.Concat(vertices8).ToArray());
		public static readonly ReadOnlyCollection<Int3> facesEdges18 = new ReadOnlyCollection<Int3>(faces6.Concat(edges12).ToArray());
		public static readonly ReadOnlyCollection<Int3> verticesEdges20 = new ReadOnlyCollection<Int3>(vertices8.Concat(edges12).ToArray());

		public static readonly ReadOnlyCollection<Int3> facesVerticesEdges26 = new ReadOnlyCollection<Int3>(faces6.Concat(vertices8).Concat(edges12).ToArray());

#endregion

#region Instance

#region Swizzled

#region Four

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXXX => new Int4(X, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXXY => new Int4(X, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXXZ => new Int4(X, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXX_ => new Int4(X, X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXYX => new Int4(X, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXYY => new Int4(X, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXYZ => new Int4(X, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXY_ => new Int4(X, X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXZX => new Int4(X, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXZY => new Int4(X, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXZZ => new Int4(X, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXZ_ => new Int4(X, X, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX_X => new Int4(X, X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX_Y => new Int4(X, X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX_Z => new Int4(X, X, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX__ => new Int4(X, X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYXX => new Int4(X, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYXY => new Int4(X, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYXZ => new Int4(X, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYX_ => new Int4(X, Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYYX => new Int4(X, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYYY => new Int4(X, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYYZ => new Int4(X, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYY_ => new Int4(X, Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYZX => new Int4(X, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYZY => new Int4(X, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYZZ => new Int4(X, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYZ_ => new Int4(X, Y, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY_X => new Int4(X, Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY_Y => new Int4(X, Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY_Z => new Int4(X, Y, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY__ => new Int4(X, Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZXX => new Int4(X, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZXY => new Int4(X, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZXZ => new Int4(X, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZX_ => new Int4(X, Z, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZYX => new Int4(X, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZYY => new Int4(X, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZYZ => new Int4(X, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZY_ => new Int4(X, Z, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZZX => new Int4(X, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZZY => new Int4(X, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZZZ => new Int4(X, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZZ_ => new Int4(X, Z, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZ_X => new Int4(X, Z, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZ_Y => new Int4(X, Z, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZ_Z => new Int4(X, Z, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZ__ => new Int4(X, Z, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_XX => new Int4(X, 0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_XY => new Int4(X, 0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_XZ => new Int4(X, 0, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_X_ => new Int4(X, 0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_YX => new Int4(X, 0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_YY => new Int4(X, 0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_YZ => new Int4(X, 0, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_Y_ => new Int4(X, 0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_ZX => new Int4(X, 0, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_ZY => new Int4(X, 0, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_ZZ => new Int4(X, 0, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_Z_ => new Int4(X, 0, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X__X => new Int4(X, 0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X__Y => new Int4(X, 0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X__Z => new Int4(X, 0, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X___ => new Int4(X, 0, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXXX => new Int4(Y, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXXY => new Int4(Y, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXXZ => new Int4(Y, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXX_ => new Int4(Y, X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXYX => new Int4(Y, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXYY => new Int4(Y, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXYZ => new Int4(Y, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXY_ => new Int4(Y, X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXZX => new Int4(Y, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXZY => new Int4(Y, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXZZ => new Int4(Y, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXZ_ => new Int4(Y, X, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX_X => new Int4(Y, X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX_Y => new Int4(Y, X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX_Z => new Int4(Y, X, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX__ => new Int4(Y, X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYXX => new Int4(Y, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYXY => new Int4(Y, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYXZ => new Int4(Y, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYX_ => new Int4(Y, Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYYX => new Int4(Y, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYYY => new Int4(Y, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYYZ => new Int4(Y, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYY_ => new Int4(Y, Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYZX => new Int4(Y, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYZY => new Int4(Y, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYZZ => new Int4(Y, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYZ_ => new Int4(Y, Y, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY_X => new Int4(Y, Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY_Y => new Int4(Y, Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY_Z => new Int4(Y, Y, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY__ => new Int4(Y, Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZXX => new Int4(Y, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZXY => new Int4(Y, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZXZ => new Int4(Y, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZX_ => new Int4(Y, Z, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZYX => new Int4(Y, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZYY => new Int4(Y, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZYZ => new Int4(Y, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZY_ => new Int4(Y, Z, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZZX => new Int4(Y, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZZY => new Int4(Y, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZZZ => new Int4(Y, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZZ_ => new Int4(Y, Z, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZ_X => new Int4(Y, Z, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZ_Y => new Int4(Y, Z, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZ_Z => new Int4(Y, Z, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZ__ => new Int4(Y, Z, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_XX => new Int4(Y, 0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_XY => new Int4(Y, 0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_XZ => new Int4(Y, 0, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_X_ => new Int4(Y, 0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_YX => new Int4(Y, 0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_YY => new Int4(Y, 0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_YZ => new Int4(Y, 0, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_Y_ => new Int4(Y, 0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_ZX => new Int4(Y, 0, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_ZY => new Int4(Y, 0, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_ZZ => new Int4(Y, 0, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_Z_ => new Int4(Y, 0, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y__X => new Int4(Y, 0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y__Y => new Int4(Y, 0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y__Z => new Int4(Y, 0, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y___ => new Int4(Y, 0, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXXX => new Int4(Z, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXXY => new Int4(Z, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXXZ => new Int4(Z, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXX_ => new Int4(Z, X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXYX => new Int4(Z, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXYY => new Int4(Z, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXYZ => new Int4(Z, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXY_ => new Int4(Z, X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXZX => new Int4(Z, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXZY => new Int4(Z, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXZZ => new Int4(Z, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXZ_ => new Int4(Z, X, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZX_X => new Int4(Z, X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZX_Y => new Int4(Z, X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZX_Z => new Int4(Z, X, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZX__ => new Int4(Z, X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYXX => new Int4(Z, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYXY => new Int4(Z, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYXZ => new Int4(Z, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYX_ => new Int4(Z, Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYYX => new Int4(Z, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYYY => new Int4(Z, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYYZ => new Int4(Z, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYY_ => new Int4(Z, Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYZX => new Int4(Z, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYZY => new Int4(Z, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYZZ => new Int4(Z, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYZ_ => new Int4(Z, Y, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZY_X => new Int4(Z, Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZY_Y => new Int4(Z, Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZY_Z => new Int4(Z, Y, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZY__ => new Int4(Z, Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZXX => new Int4(Z, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZXY => new Int4(Z, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZXZ => new Int4(Z, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZX_ => new Int4(Z, Z, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZYX => new Int4(Z, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZYY => new Int4(Z, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZYZ => new Int4(Z, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZY_ => new Int4(Z, Z, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZZX => new Int4(Z, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZZY => new Int4(Z, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZZZ => new Int4(Z, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZZ_ => new Int4(Z, Z, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZ_X => new Int4(Z, Z, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZ_Y => new Int4(Z, Z, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZ_Z => new Int4(Z, Z, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZ__ => new Int4(Z, Z, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_XX => new Int4(Z, 0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_XY => new Int4(Z, 0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_XZ => new Int4(Z, 0, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_X_ => new Int4(Z, 0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_YX => new Int4(Z, 0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_YY => new Int4(Z, 0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_YZ => new Int4(Z, 0, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_Y_ => new Int4(Z, 0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_ZX => new Int4(Z, 0, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_ZY => new Int4(Z, 0, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_ZZ => new Int4(Z, 0, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_Z_ => new Int4(Z, 0, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z__X => new Int4(Z, 0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z__Y => new Int4(Z, 0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z__Z => new Int4(Z, 0, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z___ => new Int4(Z, 0, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XXX => new Int4(0, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XXY => new Int4(0, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XXZ => new Int4(0, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XX_ => new Int4(0, X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XYX => new Int4(0, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XYY => new Int4(0, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XYZ => new Int4(0, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XY_ => new Int4(0, X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XZX => new Int4(0, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XZY => new Int4(0, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XZZ => new Int4(0, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XZ_ => new Int4(0, X, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X_X => new Int4(0, X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X_Y => new Int4(0, X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X_Z => new Int4(0, X, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X__ => new Int4(0, X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YXX => new Int4(0, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YXY => new Int4(0, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YXZ => new Int4(0, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YX_ => new Int4(0, Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YYX => new Int4(0, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YYY => new Int4(0, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YYZ => new Int4(0, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YY_ => new Int4(0, Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YZX => new Int4(0, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YZY => new Int4(0, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YZZ => new Int4(0, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YZ_ => new Int4(0, Y, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y_X => new Int4(0, Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y_Y => new Int4(0, Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y_Z => new Int4(0, Y, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y__ => new Int4(0, Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZXX => new Int4(0, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZXY => new Int4(0, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZXZ => new Int4(0, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZX_ => new Int4(0, Z, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZYX => new Int4(0, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZYY => new Int4(0, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZYZ => new Int4(0, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZY_ => new Int4(0, Z, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZZX => new Int4(0, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZZY => new Int4(0, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZZZ => new Int4(0, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZZ_ => new Int4(0, Z, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Z_X => new Int4(0, Z, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Z_Y => new Int4(0, Z, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Z_Z => new Int4(0, Z, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Z__ => new Int4(0, Z, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __XX => new Int4(0, 0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __XY => new Int4(0, 0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __XZ => new Int4(0, 0, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __X_ => new Int4(0, 0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __YX => new Int4(0, 0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __YY => new Int4(0, 0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __YZ => new Int4(0, 0, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __Y_ => new Int4(0, 0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __ZX => new Int4(0, 0, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __ZY => new Int4(0, 0, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __ZZ => new Int4(0, 0, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __Z_ => new Int4(0, 0, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ___X => new Int4(0, 0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ___Y => new Int4(0, 0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ___Z => new Int4(0, 0, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ____ => new Int4(0, 0, 0, 0);

#endregion

#region Three

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXX => new Int3(X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXY => new Int3(X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXZ => new Int3(X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XX_ => new Int3(X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYX => new Int3(X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYY => new Int3(X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYZ => new Int3(X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XY_ => new Int3(X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZX => new Int3(X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZY => new Int3(X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZZ => new Int3(X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZ_ => new Int3(X, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X_X => new Int3(X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X_Y => new Int3(X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X_Z => new Int3(X, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X__ => new Int3(X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXX => new Int3(Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXY => new Int3(Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXZ => new Int3(Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YX_ => new Int3(Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYX => new Int3(Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYY => new Int3(Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYZ => new Int3(Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YY_ => new Int3(Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZX => new Int3(Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZY => new Int3(Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZZ => new Int3(Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZ_ => new Int3(Y, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y_X => new Int3(Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y_Y => new Int3(Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y_Z => new Int3(Y, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y__ => new Int3(Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXX => new Int3(Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXY => new Int3(Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXZ => new Int3(Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZX_ => new Int3(Z, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYX => new Int3(Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYY => new Int3(Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYZ => new Int3(Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZY_ => new Int3(Z, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZX => new Int3(Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZY => new Int3(Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZZ => new Int3(Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZ_ => new Int3(Z, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Z_X => new Int3(Z, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Z_Y => new Int3(Z, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Z_Z => new Int3(Z, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Z__ => new Int3(Z, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _XX => new Int3(0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _XY => new Int3(0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _XZ => new Int3(0, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _X_ => new Int3(0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _YX => new Int3(0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _YY => new Int3(0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _YZ => new Int3(0, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _Y_ => new Int3(0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _ZX => new Int3(0, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _ZY => new Int3(0, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _ZZ => new Int3(0, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _Z_ => new Int3(0, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 __X => new Int3(0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 __Y => new Int3(0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 __Z => new Int3(0, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ___ => new Int3(0, 0, 0);

#endregion

#region Two

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XX => new Int2(X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XY => new Int2(X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XZ => new Int2(X, Z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YX => new Int2(Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YY => new Int2(Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YZ => new Int2(Y, Z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 ZX => new Int2(Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 ZY => new Int2(Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 ZZ => new Int2(Z, Z);

#endregion

#endregion

#region Scalar Returns

		public float Magnitude
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (float)MagnitudeDouble;
		}

		public double MagnitudeDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Sqrt(SquaredMagnitudeLong);
		}

		public int SquaredMagnitude
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X * X + Y * Y + Z * Z;
		}

		public long SquaredMagnitudeLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)X * X + (long)Y * Y + (long)Z * Z;
		}

		public int Product
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X * Y * Z;
		}

		public long ProductLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)X * Y * Z;
		}

		public int ProductAbsoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs(X * Y * Z);
		}

		public long ProductAbsolutedLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs((long)X * Y * Z);
		}

		public int Sum
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X + Y + Z;
		}

		public long SumLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)X + Y + Z;
		}

		public float Average
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (float)AverageDouble;
		}

		public double AverageDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => ((double)X + Y + Z) / 3d;
		}

		public int MinComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X < Y) return X < Z ? X : Z;
				return Y < Z ? Y : Z;
			}
		}

		public int MinIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X < Y) return X < Z ? 0 : 2;
				return Y < Z ? 1 : 2;
			}
		}

		public int MaxComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X > Y) return X > Z ? X : Z;
				return Y > Z ? Y : Z;
			}
		}

		public int MaxIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X > Y) return X > Z ? 0 : 2;
				return Y > Z ? 1 : 2;
			}
		}

		public int this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
#if CODE_HELPERS_UNSAFE
				unsafe
				{
					if (index < 0 || 2 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
					fixed (Int3* pointer = &this) return ((int*)pointer)[index];
				}
#else
				switch (index)
				{
					case 0: return x;
					case 1: return y;
					case 2: return z;
				}

				throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
#endif
			}
		}

#endregion

#region Int3 Returns

		public Int3 Absoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3(Math.Abs(X), Math.Abs(Y), Math.Abs(Z));
		}

		public Int3 Signed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3(X.Sign(), Y.Sign(), Z.Sign());
		}

		public Float3 Normalized
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				long squared = SquaredMagnitudeLong;
				if (squared == 0) return Float3.Zero;

				return 1f / (float)Math.Sqrt(squared) * this;
			}
		}

		public Int3 Squared
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3(X * X, Y * Y, Z * Z);
		}

		public Int3 Sorted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X < Y)
				{
					if (Y < Z) return XYZ;
					if (X < Z) return XZY;

					return ZXY;
				}

				if (X < Z) return YXZ;
				if (Y < Z) return YZX;

				return ZYX;
			}
		}

		public Int3 SortedReversed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X > Y)
				{
					if (Y > Z) return XYZ;
					if (X > Z) return XZY;

					return ZXY;
				}

				if (X > Z) return YXZ;
				if (Y > Z) return YZX;

				return ZYX;
			}
		}

#endregion

#endregion

#endregion

#region Methods

#region Instance

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Cross(in Int3 other) => new Int3
		(
			(int)((long)Y * other.Z - (long)Z * other.Y),
			(int)((long)Z * other.X - (long)X * other.Z),
			(int)((long)X * other.Y - (long)Y * other.X)
		);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public int Dot(in Int3 other) => X * other.X + Y * other.Y + Z * other.Z;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public long DotLong(in Int3 other) => (long)X * other.X + (long)Y * other.Y + (long)Z * other.Z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Angle(in Int3 other)
		{
			long squared = SquaredMagnitudeLong * other.SquaredMagnitudeLong;
			if (squared == 0) return 0f;

			return (float)Math.Acos(DotLong(other) / Math.Sqrt(squared)) * Scalars.RadianToDegree;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SignedAngle(in Int3 other, in Int3 normal)
		{
			float angle = Angle(other);
			return Cross(other).Dot(normal) < 0f ? -angle : angle;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Distance(in Int3 other) => (other - this).Magnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DistanceDouble(in Int3 other) => (other - this).MagnitudeDouble;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public int SquaredDistance(in Int3 other) => (other - this).SquaredMagnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public long SquaredDistanceLong(in Int3 other) => (other - this).SquaredMagnitudeLong;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Min(in Int3 other) => new Int3(Math.Min(X, other.X), Math.Min(Y, other.Y), Math.Min(Z, other.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Max(in Int3 other) => new Int3(Math.Max(X, other.X), Math.Max(Y, other.Y), Math.Max(Z, other.Z));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Clamp(in Int3 min, in Int3 max) => new Int3(X.Clamp(min.X, max.X), Y.Clamp(min.Y, max.Y), Z.Clamp(min.Z, max.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Clamp(int min = 0, int max = 1) => new Int3(X.Clamp(min, max), Y.Clamp(min, max), Z.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Clamp(in Float3 min, in Float3 max) => new Float3(X.Clamp(min.X, max.X), Y.Clamp(min.Y, max.Y), Z.Clamp(min.Z, max.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Clamp(float min, float max = 1f) => new Float3(X.Clamp(min, max), Y.Clamp(min, max), Z.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3 ClampMagnitude(float max)
		{
			double squared = SquaredMagnitudeLong;
			if (squared <= (double)max * max) return this;

			float scale = max / (float)Math.Sqrt(squared);
			return new Float3(X * scale, Y * scale, Z * scale);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Power(in Float3 value) => new Float3((float)Math.Pow(X, value.X), (float)Math.Pow(Y, value.Y), (float)Math.Pow(Z, value.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Power(float value) => new Float3((float)Math.Pow(X, value), (float)Math.Pow(Y, value), (float)Math.Pow(Z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Lerp(in Int3 other, in Int3 value) => new Int3(Scalars.Lerp(X, other.X, value.X), Scalars.Lerp(Y, other.Y, value.Y), Scalars.Lerp(Z, other.Z, value.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Lerp(in Int3 other, int value) => new Int3(Scalars.Lerp(X, other.X, value), Scalars.Lerp(Y, other.Y, value), Scalars.Lerp(Z, other.Z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Lerp(in Int3 other, in Float3 value) => new Float3(Scalars.Lerp(X, other.X, value.X), Scalars.Lerp(Y, other.Y, value.Y), Scalars.Lerp(Z, other.Z, value.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Lerp(in Int3 other, float value) => new Float3(Scalars.Lerp(X, other.X, value), Scalars.Lerp(Y, other.Y, value), Scalars.Lerp(Z, other.Z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 InverseLerp(in Int3 other, in Int3 value) => new Int3(Scalars.InverseLerp(X, other.X, value.X), Scalars.InverseLerp(Y, other.Y, value.Y), Scalars.InverseLerp(Z, other.Z, value.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 InverseLerp(in Int3 other, int value) => new Int3(Scalars.InverseLerp(X, other.X, value), Scalars.InverseLerp(Y, other.Y, value), Scalars.InverseLerp(Z, other.Z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 InverseLerp(in Int3 other, in Float3 value) => new Float3(Scalars.InverseLerp(X, other.X, value.X), Scalars.InverseLerp(Y, other.Y, value.Y), Scalars.InverseLerp(Z, other.Z, value.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 InverseLerp(in Int3 other, float value) => new Float3(Scalars.InverseLerp(X, other.X, value), Scalars.InverseLerp(Y, other.Y, value), Scalars.InverseLerp(Z, other.Z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Repeat(in Int3 length) => new Int3(X.Repeat(length.X), Y.Repeat(length.Y), Z.Repeat(length.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Repeat(int length) => new Int3(X.Repeat(length), Y.Repeat(length), Z.Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Repeat(in Float3 length) => new Float3(((float)X).Repeat(length.X), ((float)Y).Repeat(length.Y), ((float)Z).Repeat(length.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Repeat(float length) => new Float3(((float)X).Repeat(length), ((float)Y).Repeat(length), ((float)Z).Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 FlooredDivide(in Int3 divisor) => new Int3(X.FlooredDivide(divisor.X), Y.FlooredDivide(divisor.Y), Z.FlooredDivide(divisor.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 FlooredDivide(int divisor) => new Int3(X.FlooredDivide(divisor), Y.FlooredDivide(divisor), Z.FlooredDivide(divisor));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 CeiledDivide(in Int3 divisor) => new Int3(X.CeiledDivide(divisor.X), Y.CeiledDivide(divisor.Y), Z.CeiledDivide(divisor.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 CeiledDivide(int divisor) => new Int3(X.CeiledDivide(divisor), Y.CeiledDivide(divisor), Z.CeiledDivide(divisor));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXY(float degree) => Float3.CreateXY(XY.Rotate(degree), Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXY(float degree, Float2 pivot) => Float3.CreateXY(XY.Rotate(degree, pivot), Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXY(float degree, in Float3 pivot) => Float3.CreateXY(XY.Rotate(degree, pivot.XY), Z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXZ(float degree) => Float3.CreateXZ(XZ.Rotate(degree), Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXZ(float degree, Float2 pivot) => Float3.CreateXZ(XZ.Rotate(degree, pivot), Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXZ(float degree, in Float3 pivot) => Float3.CreateXZ(XZ.Rotate(degree, pivot.XZ), Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateYZ(float degree) => Float3.CreateYZ(YZ.Rotate(degree), X);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateYZ(float degree, Float2 pivot) => Float3.CreateYZ(YZ.Rotate(degree, pivot), X);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateYZ(float degree, in Float3 pivot) => Float3.CreateYZ(YZ.Rotate(degree, pivot.YZ), X);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Damp(in Float3 target, ref Float3 velocity, in Float3 smoothTime, float deltaTime) => Float3.Damp(this, target, ref velocity, smoothTime, deltaTime);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Damp(in Float3 target, ref Float3 velocity, float smoothTime, float deltaTime) => Float3.Damp(this, target, ref velocity, smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 Reflect(in Int3 normal) => -2 * Dot(normal) * normal + this;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Project(in Float3 normal) => normal * (normal.Dot(this) / normal.SquaredMagnitude);

		public override string ToString() => ToString(string.Empty);

		public string ToString(string format) => ToString(format, CultureInfo.InvariantCulture);
		public string ToString(string format, IFormatProvider provider) => $"({X.ToString(format, provider)}, {Y.ToString(format, provider)}, {Z.ToString(format, provider)})";

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Int3 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Int3 other) => EqualsFast(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool EqualsFast(in Int3 other) => X == other.X && Y == other.Y && Z == other.Z;

		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = X.GetHashCode();
				hashCode = (hashCode * 397) ^ Y.GetHashCode();
				hashCode = (hashCode * 397) ^ Z.GetHashCode();
				return hashCode;
			}
		}

#endregion

#region Static

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Cross(in Int3 first, in Int3 second) => first.Cross(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static int Dot(in Int3 value, in Int3 other) => value.Dot(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static long DotLong(in Int3 value, in Int3 other) => value.DotLong(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Angle(in Int3 first, in Int3 second) => first.Angle(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float SignedAngle(in Int3 first, in Int3 second, in Int3 normal) => first.SignedAngle(second, normal);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Distance(in Int3 value, in Int3 other) => value.Distance(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double DistanceDouble(in Int3 value, in Int3 other) => value.DistanceDouble(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static int SquaredDistance(in Int3 value, in Int3 other) => value.SquaredDistance(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static long SquaredDistanceLong(in Int3 value, in Int3 other) => value.SquaredDistanceLong(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Min(in Int3 value, in Int3 other) => value.Min(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Max(in Int3 value, in Int3 other) => value.Max(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Clamp(in Int3 value, in Int3 min, in Int3 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Clamp(in Int3 value, int min = 0, int max = 1) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Clamp(in Int3 value, in Float3 min, in Float3 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Clamp(in Int3 value, float min, float max = 1f) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 ClampMagnitude(in Int3 value, float max) => value.ClampMagnitude(max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Power(in Float3 value, in Float3 power) => value.Power(power);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Power(in Float3 value, float power) => value.Power(power);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Lerp(in Int3 first, in Int3 second, in Int3 value) => first.Lerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Lerp(in Int3 first, in Int3 second, int value) => first.Lerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Lerp(in Int3 first, in Int3 second, in Float3 value) => first.Lerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Lerp(in Int3 first, in Int3 second, float value) => first.Lerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 InverseLerp(in Int3 first, in Int3 second, in Int3 value) => first.InverseLerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 InverseLerp(in Int3 first, in Int3 second, int value) => first.InverseLerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 InverseLerp(in Int3 first, in Int3 second, in Float3 value) => first.InverseLerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 InverseLerp(in Int3 first, in Int3 second, float value) => first.InverseLerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Repeat(in Int3 value, in Int3 length) => value.Repeat(length);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Repeat(in Int3 value, int length) => value.Repeat(length);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Repeat(in Int3 value, in Float3 length) => value.Repeat(length);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Repeat(in Int3 value, float length) => value.Repeat(length);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 FlooredDivide(in Int3 value, in Int3 divisor) => value.FlooredDivide(divisor);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 FlooredDivide(in Int3 value, int divisor) => value.FlooredDivide(divisor);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 CeiledDivide(in Int3 value, in Int3 divisor) => value.CeiledDivide(divisor);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 CeiledDivide(in Int3 value, int divisor) => value.CeiledDivide(divisor);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXY(in Int3 value, float degree) => value.RotateXY(degree);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXY(in Int3 value, float degree, Float2 pivot) => value.RotateXY(degree, pivot);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXY(in Int3 value, float degree, in Float3 pivot) => value.RotateXY(degree, pivot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXZ(in Int3 value, float degree) => value.RotateXZ(degree);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXZ(in Int3 value, float degree, Float2 pivot) => value.RotateXZ(degree, pivot);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXZ(in Int3 value, float degree, in Float3 pivot) => value.RotateXZ(degree, pivot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateYZ(in Int3 value, float degree) => value.RotateYZ(degree);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateYZ(in Int3 value, float degree, Float2 pivot) => value.RotateYZ(degree, pivot);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateYZ(in Int3 value, float degree, in Float3 pivot) => value.RotateYZ(degree, pivot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Damp(in Int3 current, in Float3 target, ref Float3 velocity, in Float3 smoothTime, float deltaTime) => Float3.Damp(current, target, ref velocity, smoothTime, deltaTime);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Damp(in Int3 current, in Float3 target, ref Float3 velocity, float smoothTime, float deltaTime) => Float3.Damp(current, target, ref velocity, smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Reflect(in Int3 value, in Int3 normal) => value.Reflect(normal);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Project(in Int3 value, in Float3 normal) => value.Project(normal);

#endregion

#region Create

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int3 Create(int index, int value)
		{
#if CODE_HELPERS_UNSAFE
			unsafe
			{
				if (index < 0 || 2 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Int3 result = default;
				((int*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Int3(value, 0, 0);
				case 1:  return new Int3(0, value, 0);
				case 2:  return new Int3(0, 0, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int3 Create(int index, int value, int other)
		{
#if CODE_HELPERS_UNSAFE
			unsafe
			{
				if (index < 0 || 2 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Int3 result = new Int3(other, other, other);
				((int*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Int3(value, other, other);
				case 1:  return new Int3(other, value, other);
				case 2:  return new Int3(other, other, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateX(int value, int other = 0) => new Int3(value, other, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateY(int value, int other = 0) => new Int3(other, value, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateZ(int value, int other = 0) => new Int3(other, other, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateXY(Int2 value, int other = 0) => new Int3(value.X, value.Y, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateYZ(Int2 value, int other = 0) => new Int3(other, value.X, value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Int3 CreateXZ(Int2 value, int other = 0) => new Int3(value.X, other, value.Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Int3 Replace(int index, int value)
		{
#if CODE_HELPERS_UNSAFE
			unsafe
			{
				if (index < 0 || 2 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Int3 result = this; //Make a copy of this struct
				((int*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Int3(value, y, z);
				case 1:  return new Int3(x, value, z);
				case 2:  return new Int3(x, y, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3 Replace(int index, float value)
		{
#if CODE_HELPERS_UNSAFE
			unsafe
			{
				if (index < 0 || 2 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Float3 result = this; //Make a copy of this struct
				((float*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Float3(value, y, z);
				case 1:  return new Float3(x, value, z);
				case 2:  return new Float3(x, y, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int3 ReplaceX(int value) => new Int3(value, Y, Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int3 ReplaceY(int value) => new Int3(X, value, Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int3 ReplaceZ(int value) => new Int3(X, Y, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceX(float value) => new Float3(value, Y, Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceY(float value) => new Float3(X, value, Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceZ(float value) => new Float3(X, Y, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int3 ReplaceXY(Int2 value) => new Int3(value.X, value.Y, Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int3 ReplaceYZ(Int2 value) => new Int3(X, value.X, value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Int3 ReplaceXZ(Int2 value) => new Int3(value.X, Y, value.Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceXY(Float2 value) => new Float3(value.X, value.Y, Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceYZ(Float2 value) => new Float3(X, value.X, value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceXZ(Float2 value) => new Float3(value.X, Y, value.Y);

#if CODE_HELPERS_UNITY
		public UnityEngine.Vector3Int U() => this;
#endif

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator +(in Int3 first, in Int3 second) => new Int3(first.X + second.X, first.Y + second.Y, first.Z + second.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator -(in Int3 first, in Int3 second) => new Int3(first.X - second.X, first.Y - second.Y, first.Z - second.Z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator *(in Int3 first, in Int3 second) => new Int3(first.X * second.X, first.Y * second.Y, first.Z * second.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator /(in Int3 first, in Int3 second) => new Int3(first.X / second.X, first.Y / second.Y, first.Z / second.Z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator *(in Int3 first, int second) => new Int3(first.X * second, first.Y * second, first.Z * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator /(in Int3 first, int second) => new Int3(first.X / second, first.Y / second, first.Z / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(in Int3 first, float second) => new Float3(first.X * second, first.Y * second, first.Z * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(in Int3 first, float second) => new Float3(first.X / second, first.Y / second, first.Z / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator *(int first, in Int3 second) => new Int3(first * second.X, first * second.Y, first * second.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator /(int first, in Int3 second) => new Int3(first / second.X, first / second.Y, first / second.Z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(float first, in Int3 second) => new Float3(first * second.X, first * second.Y, first * second.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(float first, in Int3 second) => new Float3(first / second.X, first / second.Y, first / second.Z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator +(in Int3 value) => value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator -(in Int3 value) => new Int3(-value.X, -value.Y, -value.Z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator %(in Int3 first, in Int3 second) => new Int3(first.X % second.X, first.Y % second.Y, first.Z % second.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator %(in Int3 first, int second) => new Int3(first.X % second, first.Y % second, first.Z % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator %(int first, in Int3 second) => new Int3(first % second.X, first % second.Y, first % second.Z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(in Int3 first, float second) => new Float3(first.X % second, first.Y % second, first.Z % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(float first, in Int3 second) => new Float3(first % second.X, first % second.Y, first % second.Z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(in Int3 first, in Int3 second) => first.EqualsFast(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(in Int3 first, in Int3 second) => !first.EqualsFast(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(in Int3 first, in Int3 second) => first.X < second.X && first.Y < second.Y && first.Z < second.Z;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(in Int3 first, in Int3 second) => first.X > second.X && first.Y > second.Y && first.Z > second.Z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(in Int3 first, in Int3 second) => first.X <= second.X && first.Y <= second.Y && first.Z <= second.Z;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(in Int3 first, in Int3 second) => first.X >= second.X && first.Y >= second.Y && first.Z >= second.Z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(in Int3 value) => value.XY;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(int value) => new Int3(value, value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(in Int3 value) => new Int4(value.X, value.Y, value.Z, 0);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(in Int3 value) => new Float2(value.X, value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float3(in Int3 value) => new Float3(value.X, value.Y, value.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(in Int3 value) => new Float4(value.X, value.Y, value.Z, 0f);

#if CODE_HELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Int3(UnityEngine.Vector3Int value) => new Int3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector3Int(in Int3 value) => new UnityEngine.Vector3Int(value.X, value.Y, value.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector3(in Int3 value) => new UnityEngine.Vector3(value.X, value.Y, value.Z);
#endif

#endregion

#endregion

#region Enumerations

		/// <summary>
		/// Returns an enumerable that can be put into a foreach loop.
		/// Yields the three components of this vector in a series.
		/// </summary>
		public SeriesEnumerable Series() => new SeriesEnumerable(this);

		/// <summary>
		/// Returns an enumerable that can be put into a foreach loop; from (0,0,0) to (vector.x-1,vector.y-1,vector.z-1)
		/// If <paramref name="zeroAsOne"/> is true then the loop will treat zeros in the vector as ones.
		/// </summary>
		public LoopEnumerable Loop(bool zeroAsOne = false) => new LoopEnumerable(this, zeroAsOne);

		public readonly struct SeriesEnumerable : IEnumerable<int>
		{
			public SeriesEnumerable(in Int3 value) => enumerator = new Enumerator(value);

			readonly Enumerator enumerator;

			public Enumerator GetEnumerator() => enumerator;

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			IEnumerator<int> IEnumerable<int>.GetEnumerator() => GetEnumerator();

			public struct Enumerator : IEnumerator<int>
			{
				public Enumerator(in Int3 source)
				{
					this.source = source;
					index = -1;
				}

				readonly Int3 source;
				int index;

				object IEnumerator.Current => Current;
				public int Current => source[index];

				public bool MoveNext() => index++ < 2;
				public void Reset() => index = -1;

				public void Dispose() { }
			}
		}

		public readonly struct LoopEnumerable : IEnumerable<Int3>
		{
			public LoopEnumerable(in Int3 vector, bool zeroAsOne) => enumerator = new Enumerator(vector, zeroAsOne);

			readonly Enumerator enumerator;

			public Enumerator GetEnumerator() => enumerator;

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			IEnumerator<Int3> IEnumerable<Int3>.GetEnumerator() => GetEnumerator();

			public struct Enumerator : IEnumerator<Int3>
			{
				internal Enumerator(Int3 size, bool zeroAsOne)
				{
					direction = size.Signed;
					size = size.Absoluted;

					if (zeroAsOne) size = One.Max(size);
					this.size = size;

					product = size.Product;
					current = -1;
				}

				readonly Int3 direction;
				readonly Int3 size;

				readonly int product;
				int current;

				object IEnumerator.Current => Current;

				public Int3 Current => new Int3
				(
					current / (size.Y * size.Z) * direction.X,
					current / size.Z % size.Y * direction.Y,
					current % size.Z * direction.Z
				);

				public bool MoveNext() => ++current < product;

				public void Reset() => current = -1;
				public void Dispose() { }
			}
		}

#endregion

	}
}