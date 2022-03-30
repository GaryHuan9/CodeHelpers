using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeHelpers.Mathematics;

namespace CodeHelpers.Packed
{
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Int4 : IEquatable<Int4>, IFormattable
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Int4(int x, int y, int z, int w)
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}

		public int X { get; }
		public int Y { get; }
		public int Z { get; }
		public int W { get; }

#region Properties

#region Static

		public static Int4 Right { get; } = new Int4(1, 0, 0, 0);
		public static Int4 Left { get; } = new Int4(-1, 0, 0, 0);

		public static Int4 Up { get; } = new Int4(0, 1, 0, 0);
		public static Int4 Down { get; } = new Int4(0, -1, 0, 0);

		public static Int4 Forward { get; } = new Int4(0, 0, 1, 0);
		public static Int4 Backward { get; } = new Int4(0, 0, -1, 0);

		public static Int4 Ana { get; } = new Int4(0, 0, 0, 1);
		public static Int4 Kata { get; } = new Int4(0, 0, 0, -1);

		public static Int4 Zero { get; } = new Int4(0, 0, 0, 0);
		public static Int4 One { get; } = new Int4(1, 1, 1, 1);
		public static Int4 NegativeOne { get; } = new Int4(-1, -1, -1, 1);

		public static Int4 MaxValue { get; } = new Int4(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);
		public static Int4 MinValue { get; } = new Int4(int.MinValue, int.MinValue, int.MinValue, int.MinValue);

#endregion

#region Instance

#region Swizzled

#region Four

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXXX => new Int4(X, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXXY => new Int4(X, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXXZ => new Int4(X, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXXW => new Int4(X, X, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXX_ => new Int4(X, X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXYX => new Int4(X, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXYY => new Int4(X, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXYZ => new Int4(X, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXYW => new Int4(X, X, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXY_ => new Int4(X, X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXZX => new Int4(X, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXZY => new Int4(X, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXZZ => new Int4(X, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXZW => new Int4(X, X, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXZ_ => new Int4(X, X, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXWX => new Int4(X, X, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXWY => new Int4(X, X, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXWZ => new Int4(X, X, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXWW => new Int4(X, X, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXW_ => new Int4(X, X, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX_X => new Int4(X, X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX_Y => new Int4(X, X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX_Z => new Int4(X, X, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX_W => new Int4(X, X, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX__ => new Int4(X, X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYXX => new Int4(X, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYXY => new Int4(X, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYXZ => new Int4(X, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYXW => new Int4(X, Y, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYX_ => new Int4(X, Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYYX => new Int4(X, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYYY => new Int4(X, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYYZ => new Int4(X, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYYW => new Int4(X, Y, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYY_ => new Int4(X, Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYZX => new Int4(X, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYZY => new Int4(X, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYZZ => new Int4(X, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYZW => new Int4(X, Y, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYZ_ => new Int4(X, Y, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYWX => new Int4(X, Y, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYWY => new Int4(X, Y, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYWZ => new Int4(X, Y, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYWW => new Int4(X, Y, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYW_ => new Int4(X, Y, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY_X => new Int4(X, Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY_Y => new Int4(X, Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY_Z => new Int4(X, Y, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY_W => new Int4(X, Y, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY__ => new Int4(X, Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZXX => new Int4(X, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZXY => new Int4(X, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZXZ => new Int4(X, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZXW => new Int4(X, Z, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZX_ => new Int4(X, Z, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZYX => new Int4(X, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZYY => new Int4(X, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZYZ => new Int4(X, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZYW => new Int4(X, Z, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZY_ => new Int4(X, Z, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZZX => new Int4(X, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZZY => new Int4(X, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZZZ => new Int4(X, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZZW => new Int4(X, Z, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZZ_ => new Int4(X, Z, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZWX => new Int4(X, Z, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZWY => new Int4(X, Z, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZWZ => new Int4(X, Z, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZWW => new Int4(X, Z, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZW_ => new Int4(X, Z, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZ_X => new Int4(X, Z, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZ_Y => new Int4(X, Z, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZ_Z => new Int4(X, Z, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZ_W => new Int4(X, Z, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZ__ => new Int4(X, Z, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWXX => new Int4(X, W, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWXY => new Int4(X, W, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWXZ => new Int4(X, W, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWXW => new Int4(X, W, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWX_ => new Int4(X, W, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWYX => new Int4(X, W, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWYY => new Int4(X, W, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWYZ => new Int4(X, W, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWYW => new Int4(X, W, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWY_ => new Int4(X, W, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWZX => new Int4(X, W, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWZY => new Int4(X, W, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWZZ => new Int4(X, W, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWZW => new Int4(X, W, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWZ_ => new Int4(X, W, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWWX => new Int4(X, W, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWWY => new Int4(X, W, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWWZ => new Int4(X, W, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWWW => new Int4(X, W, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWW_ => new Int4(X, W, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XW_X => new Int4(X, W, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XW_Y => new Int4(X, W, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XW_Z => new Int4(X, W, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XW_W => new Int4(X, W, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XW__ => new Int4(X, W, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_XX => new Int4(X, 0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_XY => new Int4(X, 0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_XZ => new Int4(X, 0, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_XW => new Int4(X, 0, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_X_ => new Int4(X, 0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_YX => new Int4(X, 0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_YY => new Int4(X, 0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_YZ => new Int4(X, 0, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_YW => new Int4(X, 0, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_Y_ => new Int4(X, 0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_ZX => new Int4(X, 0, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_ZY => new Int4(X, 0, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_ZZ => new Int4(X, 0, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_ZW => new Int4(X, 0, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_Z_ => new Int4(X, 0, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_WX => new Int4(X, 0, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_WY => new Int4(X, 0, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_WZ => new Int4(X, 0, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_WW => new Int4(X, 0, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_W_ => new Int4(X, 0, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X__X => new Int4(X, 0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X__Y => new Int4(X, 0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X__Z => new Int4(X, 0, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X__W => new Int4(X, 0, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X___ => new Int4(X, 0, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXXX => new Int4(Y, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXXY => new Int4(Y, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXXZ => new Int4(Y, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXXW => new Int4(Y, X, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXX_ => new Int4(Y, X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXYX => new Int4(Y, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXYY => new Int4(Y, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXYZ => new Int4(Y, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXYW => new Int4(Y, X, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXY_ => new Int4(Y, X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXZX => new Int4(Y, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXZY => new Int4(Y, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXZZ => new Int4(Y, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXZW => new Int4(Y, X, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXZ_ => new Int4(Y, X, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXWX => new Int4(Y, X, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXWY => new Int4(Y, X, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXWZ => new Int4(Y, X, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXWW => new Int4(Y, X, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXW_ => new Int4(Y, X, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX_X => new Int4(Y, X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX_Y => new Int4(Y, X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX_Z => new Int4(Y, X, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX_W => new Int4(Y, X, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX__ => new Int4(Y, X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYXX => new Int4(Y, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYXY => new Int4(Y, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYXZ => new Int4(Y, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYXW => new Int4(Y, Y, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYX_ => new Int4(Y, Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYYX => new Int4(Y, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYYY => new Int4(Y, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYYZ => new Int4(Y, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYYW => new Int4(Y, Y, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYY_ => new Int4(Y, Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYZX => new Int4(Y, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYZY => new Int4(Y, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYZZ => new Int4(Y, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYZW => new Int4(Y, Y, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYZ_ => new Int4(Y, Y, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYWX => new Int4(Y, Y, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYWY => new Int4(Y, Y, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYWZ => new Int4(Y, Y, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYWW => new Int4(Y, Y, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYW_ => new Int4(Y, Y, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY_X => new Int4(Y, Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY_Y => new Int4(Y, Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY_Z => new Int4(Y, Y, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY_W => new Int4(Y, Y, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY__ => new Int4(Y, Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZXX => new Int4(Y, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZXY => new Int4(Y, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZXZ => new Int4(Y, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZXW => new Int4(Y, Z, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZX_ => new Int4(Y, Z, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZYX => new Int4(Y, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZYY => new Int4(Y, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZYZ => new Int4(Y, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZYW => new Int4(Y, Z, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZY_ => new Int4(Y, Z, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZZX => new Int4(Y, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZZY => new Int4(Y, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZZZ => new Int4(Y, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZZW => new Int4(Y, Z, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZZ_ => new Int4(Y, Z, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZWX => new Int4(Y, Z, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZWY => new Int4(Y, Z, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZWZ => new Int4(Y, Z, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZWW => new Int4(Y, Z, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZW_ => new Int4(Y, Z, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZ_X => new Int4(Y, Z, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZ_Y => new Int4(Y, Z, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZ_Z => new Int4(Y, Z, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZ_W => new Int4(Y, Z, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZ__ => new Int4(Y, Z, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWXX => new Int4(Y, W, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWXY => new Int4(Y, W, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWXZ => new Int4(Y, W, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWXW => new Int4(Y, W, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWX_ => new Int4(Y, W, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWYX => new Int4(Y, W, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWYY => new Int4(Y, W, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWYZ => new Int4(Y, W, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWYW => new Int4(Y, W, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWY_ => new Int4(Y, W, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWZX => new Int4(Y, W, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWZY => new Int4(Y, W, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWZZ => new Int4(Y, W, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWZW => new Int4(Y, W, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWZ_ => new Int4(Y, W, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWWX => new Int4(Y, W, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWWY => new Int4(Y, W, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWWZ => new Int4(Y, W, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWWW => new Int4(Y, W, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWW_ => new Int4(Y, W, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YW_X => new Int4(Y, W, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YW_Y => new Int4(Y, W, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YW_Z => new Int4(Y, W, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YW_W => new Int4(Y, W, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YW__ => new Int4(Y, W, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_XX => new Int4(Y, 0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_XY => new Int4(Y, 0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_XZ => new Int4(Y, 0, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_XW => new Int4(Y, 0, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_X_ => new Int4(Y, 0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_YX => new Int4(Y, 0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_YY => new Int4(Y, 0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_YZ => new Int4(Y, 0, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_YW => new Int4(Y, 0, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_Y_ => new Int4(Y, 0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_ZX => new Int4(Y, 0, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_ZY => new Int4(Y, 0, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_ZZ => new Int4(Y, 0, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_ZW => new Int4(Y, 0, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_Z_ => new Int4(Y, 0, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_WX => new Int4(Y, 0, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_WY => new Int4(Y, 0, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_WZ => new Int4(Y, 0, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_WW => new Int4(Y, 0, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_W_ => new Int4(Y, 0, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y__X => new Int4(Y, 0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y__Y => new Int4(Y, 0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y__Z => new Int4(Y, 0, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y__W => new Int4(Y, 0, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y___ => new Int4(Y, 0, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXXX => new Int4(Z, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXXY => new Int4(Z, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXXZ => new Int4(Z, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXXW => new Int4(Z, X, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXX_ => new Int4(Z, X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXYX => new Int4(Z, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXYY => new Int4(Z, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXYZ => new Int4(Z, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXYW => new Int4(Z, X, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXY_ => new Int4(Z, X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXZX => new Int4(Z, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXZY => new Int4(Z, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXZZ => new Int4(Z, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXZW => new Int4(Z, X, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXZ_ => new Int4(Z, X, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXWX => new Int4(Z, X, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXWY => new Int4(Z, X, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXWZ => new Int4(Z, X, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXWW => new Int4(Z, X, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXW_ => new Int4(Z, X, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZX_X => new Int4(Z, X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZX_Y => new Int4(Z, X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZX_Z => new Int4(Z, X, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZX_W => new Int4(Z, X, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZX__ => new Int4(Z, X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYXX => new Int4(Z, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYXY => new Int4(Z, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYXZ => new Int4(Z, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYXW => new Int4(Z, Y, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYX_ => new Int4(Z, Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYYX => new Int4(Z, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYYY => new Int4(Z, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYYZ => new Int4(Z, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYYW => new Int4(Z, Y, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYY_ => new Int4(Z, Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYZX => new Int4(Z, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYZY => new Int4(Z, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYZZ => new Int4(Z, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYZW => new Int4(Z, Y, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYZ_ => new Int4(Z, Y, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYWX => new Int4(Z, Y, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYWY => new Int4(Z, Y, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYWZ => new Int4(Z, Y, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYWW => new Int4(Z, Y, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYW_ => new Int4(Z, Y, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZY_X => new Int4(Z, Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZY_Y => new Int4(Z, Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZY_Z => new Int4(Z, Y, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZY_W => new Int4(Z, Y, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZY__ => new Int4(Z, Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZXX => new Int4(Z, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZXY => new Int4(Z, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZXZ => new Int4(Z, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZXW => new Int4(Z, Z, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZX_ => new Int4(Z, Z, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZYX => new Int4(Z, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZYY => new Int4(Z, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZYZ => new Int4(Z, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZYW => new Int4(Z, Z, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZY_ => new Int4(Z, Z, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZZX => new Int4(Z, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZZY => new Int4(Z, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZZZ => new Int4(Z, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZZW => new Int4(Z, Z, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZZ_ => new Int4(Z, Z, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZWX => new Int4(Z, Z, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZWY => new Int4(Z, Z, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZWZ => new Int4(Z, Z, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZWW => new Int4(Z, Z, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZW_ => new Int4(Z, Z, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZ_X => new Int4(Z, Z, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZ_Y => new Int4(Z, Z, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZ_Z => new Int4(Z, Z, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZ_W => new Int4(Z, Z, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZ__ => new Int4(Z, Z, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWXX => new Int4(Z, W, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWXY => new Int4(Z, W, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWXZ => new Int4(Z, W, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWXW => new Int4(Z, W, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWX_ => new Int4(Z, W, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWYX => new Int4(Z, W, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWYY => new Int4(Z, W, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWYZ => new Int4(Z, W, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWYW => new Int4(Z, W, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWY_ => new Int4(Z, W, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWZX => new Int4(Z, W, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWZY => new Int4(Z, W, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWZZ => new Int4(Z, W, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWZW => new Int4(Z, W, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWZ_ => new Int4(Z, W, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWWX => new Int4(Z, W, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWWY => new Int4(Z, W, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWWZ => new Int4(Z, W, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWWW => new Int4(Z, W, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWW_ => new Int4(Z, W, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZW_X => new Int4(Z, W, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZW_Y => new Int4(Z, W, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZW_Z => new Int4(Z, W, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZW_W => new Int4(Z, W, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZW__ => new Int4(Z, W, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_XX => new Int4(Z, 0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_XY => new Int4(Z, 0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_XZ => new Int4(Z, 0, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_XW => new Int4(Z, 0, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_X_ => new Int4(Z, 0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_YX => new Int4(Z, 0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_YY => new Int4(Z, 0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_YZ => new Int4(Z, 0, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_YW => new Int4(Z, 0, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_Y_ => new Int4(Z, 0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_ZX => new Int4(Z, 0, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_ZY => new Int4(Z, 0, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_ZZ => new Int4(Z, 0, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_ZW => new Int4(Z, 0, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_Z_ => new Int4(Z, 0, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_WX => new Int4(Z, 0, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_WY => new Int4(Z, 0, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_WZ => new Int4(Z, 0, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_WW => new Int4(Z, 0, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_W_ => new Int4(Z, 0, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z__X => new Int4(Z, 0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z__Y => new Int4(Z, 0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z__Z => new Int4(Z, 0, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z__W => new Int4(Z, 0, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z___ => new Int4(Z, 0, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXXX => new Int4(W, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXXY => new Int4(W, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXXZ => new Int4(W, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXXW => new Int4(W, X, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXX_ => new Int4(W, X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXYX => new Int4(W, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXYY => new Int4(W, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXYZ => new Int4(W, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXYW => new Int4(W, X, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXY_ => new Int4(W, X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXZX => new Int4(W, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXZY => new Int4(W, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXZZ => new Int4(W, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXZW => new Int4(W, X, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXZ_ => new Int4(W, X, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXWX => new Int4(W, X, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXWY => new Int4(W, X, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXWZ => new Int4(W, X, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXWW => new Int4(W, X, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXW_ => new Int4(W, X, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WX_X => new Int4(W, X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WX_Y => new Int4(W, X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WX_Z => new Int4(W, X, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WX_W => new Int4(W, X, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WX__ => new Int4(W, X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYXX => new Int4(W, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYXY => new Int4(W, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYXZ => new Int4(W, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYXW => new Int4(W, Y, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYX_ => new Int4(W, Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYYX => new Int4(W, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYYY => new Int4(W, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYYZ => new Int4(W, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYYW => new Int4(W, Y, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYY_ => new Int4(W, Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYZX => new Int4(W, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYZY => new Int4(W, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYZZ => new Int4(W, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYZW => new Int4(W, Y, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYZ_ => new Int4(W, Y, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYWX => new Int4(W, Y, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYWY => new Int4(W, Y, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYWZ => new Int4(W, Y, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYWW => new Int4(W, Y, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYW_ => new Int4(W, Y, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WY_X => new Int4(W, Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WY_Y => new Int4(W, Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WY_Z => new Int4(W, Y, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WY_W => new Int4(W, Y, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WY__ => new Int4(W, Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZXX => new Int4(W, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZXY => new Int4(W, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZXZ => new Int4(W, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZXW => new Int4(W, Z, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZX_ => new Int4(W, Z, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZYX => new Int4(W, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZYY => new Int4(W, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZYZ => new Int4(W, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZYW => new Int4(W, Z, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZY_ => new Int4(W, Z, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZZX => new Int4(W, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZZY => new Int4(W, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZZZ => new Int4(W, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZZW => new Int4(W, Z, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZZ_ => new Int4(W, Z, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZWX => new Int4(W, Z, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZWY => new Int4(W, Z, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZWZ => new Int4(W, Z, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZWW => new Int4(W, Z, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZW_ => new Int4(W, Z, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZ_X => new Int4(W, Z, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZ_Y => new Int4(W, Z, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZ_Z => new Int4(W, Z, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZ_W => new Int4(W, Z, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZ__ => new Int4(W, Z, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWXX => new Int4(W, W, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWXY => new Int4(W, W, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWXZ => new Int4(W, W, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWXW => new Int4(W, W, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWX_ => new Int4(W, W, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWYX => new Int4(W, W, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWYY => new Int4(W, W, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWYZ => new Int4(W, W, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWYW => new Int4(W, W, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWY_ => new Int4(W, W, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWZX => new Int4(W, W, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWZY => new Int4(W, W, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWZZ => new Int4(W, W, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWZW => new Int4(W, W, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWZ_ => new Int4(W, W, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWWX => new Int4(W, W, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWWY => new Int4(W, W, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWWZ => new Int4(W, W, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWWW => new Int4(W, W, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWW_ => new Int4(W, W, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WW_X => new Int4(W, W, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WW_Y => new Int4(W, W, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WW_Z => new Int4(W, W, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WW_W => new Int4(W, W, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WW__ => new Int4(W, W, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_XX => new Int4(W, 0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_XY => new Int4(W, 0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_XZ => new Int4(W, 0, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_XW => new Int4(W, 0, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_X_ => new Int4(W, 0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_YX => new Int4(W, 0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_YY => new Int4(W, 0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_YZ => new Int4(W, 0, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_YW => new Int4(W, 0, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_Y_ => new Int4(W, 0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_ZX => new Int4(W, 0, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_ZY => new Int4(W, 0, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_ZZ => new Int4(W, 0, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_ZW => new Int4(W, 0, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_Z_ => new Int4(W, 0, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_WX => new Int4(W, 0, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_WY => new Int4(W, 0, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_WZ => new Int4(W, 0, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_WW => new Int4(W, 0, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_W_ => new Int4(W, 0, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W__X => new Int4(W, 0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W__Y => new Int4(W, 0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W__Z => new Int4(W, 0, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W__W => new Int4(W, 0, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W___ => new Int4(W, 0, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XXX => new Int4(0, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XXY => new Int4(0, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XXZ => new Int4(0, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XXW => new Int4(0, X, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XX_ => new Int4(0, X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XYX => new Int4(0, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XYY => new Int4(0, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XYZ => new Int4(0, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XYW => new Int4(0, X, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XY_ => new Int4(0, X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XZX => new Int4(0, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XZY => new Int4(0, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XZZ => new Int4(0, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XZW => new Int4(0, X, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XZ_ => new Int4(0, X, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XWX => new Int4(0, X, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XWY => new Int4(0, X, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XWZ => new Int4(0, X, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XWW => new Int4(0, X, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XW_ => new Int4(0, X, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X_X => new Int4(0, X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X_Y => new Int4(0, X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X_Z => new Int4(0, X, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X_W => new Int4(0, X, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X__ => new Int4(0, X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YXX => new Int4(0, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YXY => new Int4(0, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YXZ => new Int4(0, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YXW => new Int4(0, Y, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YX_ => new Int4(0, Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YYX => new Int4(0, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YYY => new Int4(0, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YYZ => new Int4(0, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YYW => new Int4(0, Y, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YY_ => new Int4(0, Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YZX => new Int4(0, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YZY => new Int4(0, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YZZ => new Int4(0, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YZW => new Int4(0, Y, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YZ_ => new Int4(0, Y, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YWX => new Int4(0, Y, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YWY => new Int4(0, Y, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YWZ => new Int4(0, Y, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YWW => new Int4(0, Y, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YW_ => new Int4(0, Y, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y_X => new Int4(0, Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y_Y => new Int4(0, Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y_Z => new Int4(0, Y, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y_W => new Int4(0, Y, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y__ => new Int4(0, Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZXX => new Int4(0, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZXY => new Int4(0, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZXZ => new Int4(0, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZXW => new Int4(0, Z, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZX_ => new Int4(0, Z, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZYX => new Int4(0, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZYY => new Int4(0, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZYZ => new Int4(0, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZYW => new Int4(0, Z, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZY_ => new Int4(0, Z, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZZX => new Int4(0, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZZY => new Int4(0, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZZZ => new Int4(0, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZZW => new Int4(0, Z, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZZ_ => new Int4(0, Z, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZWX => new Int4(0, Z, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZWY => new Int4(0, Z, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZWZ => new Int4(0, Z, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZWW => new Int4(0, Z, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZW_ => new Int4(0, Z, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Z_X => new Int4(0, Z, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Z_Y => new Int4(0, Z, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Z_Z => new Int4(0, Z, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Z_W => new Int4(0, Z, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Z__ => new Int4(0, Z, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WXX => new Int4(0, W, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WXY => new Int4(0, W, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WXZ => new Int4(0, W, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WXW => new Int4(0, W, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WX_ => new Int4(0, W, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WYX => new Int4(0, W, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WYY => new Int4(0, W, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WYZ => new Int4(0, W, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WYW => new Int4(0, W, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WY_ => new Int4(0, W, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WZX => new Int4(0, W, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WZY => new Int4(0, W, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WZZ => new Int4(0, W, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WZW => new Int4(0, W, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WZ_ => new Int4(0, W, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WWX => new Int4(0, W, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WWY => new Int4(0, W, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WWZ => new Int4(0, W, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WWW => new Int4(0, W, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WW_ => new Int4(0, W, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _W_X => new Int4(0, W, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _W_Y => new Int4(0, W, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _W_Z => new Int4(0, W, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _W_W => new Int4(0, W, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _W__ => new Int4(0, W, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __XX => new Int4(0, 0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __XY => new Int4(0, 0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __XZ => new Int4(0, 0, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __XW => new Int4(0, 0, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __X_ => new Int4(0, 0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __YX => new Int4(0, 0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __YY => new Int4(0, 0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __YZ => new Int4(0, 0, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __YW => new Int4(0, 0, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __Y_ => new Int4(0, 0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __ZX => new Int4(0, 0, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __ZY => new Int4(0, 0, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __ZZ => new Int4(0, 0, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __ZW => new Int4(0, 0, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __Z_ => new Int4(0, 0, Z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __WX => new Int4(0, 0, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __WY => new Int4(0, 0, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __WZ => new Int4(0, 0, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __WW => new Int4(0, 0, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __W_ => new Int4(0, 0, W, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ___X => new Int4(0, 0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ___Y => new Int4(0, 0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ___Z => new Int4(0, 0, 0, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ___W => new Int4(0, 0, 0, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ____ => new Int4(0, 0, 0, 0);

#endregion

#region Three

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXX => new Int3(X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXY => new Int3(X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXZ => new Int3(X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXW => new Int3(X, X, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYX => new Int3(X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYY => new Int3(X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYZ => new Int3(X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYW => new Int3(X, Y, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZX => new Int3(X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZY => new Int3(X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZZ => new Int3(X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZW => new Int3(X, Z, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XWX => new Int3(X, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XWY => new Int3(X, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XWZ => new Int3(X, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XWW => new Int3(X, W, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXX => new Int3(Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXY => new Int3(Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXZ => new Int3(Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXW => new Int3(Y, X, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYX => new Int3(Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYY => new Int3(Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYZ => new Int3(Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYW => new Int3(Y, Y, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZX => new Int3(Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZY => new Int3(Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZZ => new Int3(Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZW => new Int3(Y, Z, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YWX => new Int3(Y, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YWY => new Int3(Y, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YWZ => new Int3(Y, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YWW => new Int3(Y, W, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXX => new Int3(Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXY => new Int3(Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXZ => new Int3(Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXW => new Int3(Z, X, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYX => new Int3(Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYY => new Int3(Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYZ => new Int3(Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYW => new Int3(Z, Y, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZX => new Int3(Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZY => new Int3(Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZZ => new Int3(Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZW => new Int3(Z, Z, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZWX => new Int3(Z, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZWY => new Int3(Z, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZWZ => new Int3(Z, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZWW => new Int3(Z, W, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WXX => new Int3(W, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WXY => new Int3(W, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WXZ => new Int3(W, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WXW => new Int3(W, X, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WYX => new Int3(W, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WYY => new Int3(W, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WYZ => new Int3(W, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WYW => new Int3(W, Y, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WZX => new Int3(W, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WZY => new Int3(W, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WZZ => new Int3(W, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WZW => new Int3(W, Z, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WWX => new Int3(W, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WWY => new Int3(W, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WWZ => new Int3(W, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WWW => new Int3(W, W, W);

#endregion

#region Two

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XX => new Int2(X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XY => new Int2(X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XZ => new Int2(X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XW => new Int2(X, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YX => new Int2(Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YY => new Int2(Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YZ => new Int2(Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YW => new Int2(Y, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 ZX => new Int2(Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 ZY => new Int2(Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 ZZ => new Int2(Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 ZW => new Int2(Z, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 WX => new Int2(W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 WY => new Int2(W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 WZ => new Int2(W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 WW => new Int2(W, W);

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
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X * X + Y * Y + Z * Z + W * W;
		}

		public long SquaredMagnitudeLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)X * X + (long)Y * Y + (long)Z * Z + (long)W * W;
		}

		public int Product
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X * Y * Z * W;
		}

		public long ProductLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)X * Y * Z * W;
		}

		public int ProductAbsoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs(X * Y * Z * W);
		}

		public long ProductAbsolutedLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs((long)X * Y * Z * W);
		}

		public int Sum
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X + Y + Z + W;
		}

		public long SumLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)X + Y + Z + W;
		}

		public float Average
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (float)AverageDouble;
		}

		public double AverageDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => ((double)X + Y + Z + W) / 4d;
		}

		public int MinComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X < Y)
				{
					if (X < Z) return X < W ? X : W;
					return Z < W ? Z : W;
				}

				if (Y < Z) return Y < W ? Y : W;
				return Z < W ? Z : W;
			}
		}

		public int MinIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X < Y)
				{
					if (X < Z) return X < W ? 0 : 3;
					return Z < W ? 2 : 3;
				}

				if (Y < Z) return Y < W ? 1 : 3;
				return Z < W ? 2 : 3;
			}
		}

		public int MaxComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X > Y)
				{
					if (X > Z) return X > W ? X : W;
					return Z > W ? Z : W;
				}

				if (Y > Z) return Y > W ? Y : W;
				return Z > W ? Z : W;
			}
		}

		public int MaxIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X > Y)
				{
					if (X > Z) return X > W ? 0 : 3;
					return Z > W ? 2 : 3;
				}

				if (Y > Z) return Y > W ? 1 : 3;
				return Z > W ? 2 : 3;
			}
		}

		public int this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
#if CODE_HELPERS_UNSAFE
				unsafe
				{
					if (index < 0 || 3 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
					fixed (Int4* pointer = &this) return ((int*)pointer)[index];
				}
#else
				switch (index)
				{
					case 0: return x;
					case 1: return y;
					case 2: return z;
					case 3: return w;
				}

				throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
#endif
			}
		}

#endregion

#region Int4 Returns

		public Int4 Absoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int4(Math.Abs(X), Math.Abs(Y), Math.Abs(Z), Math.Abs(W));
		}

		public Int4 Signed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int4(X.Sign(), Y.Sign(), Z.Sign(), W.Sign());
		}

		public Float4 Normalized
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				long squared = SquaredMagnitudeLong;
				if (squared == 0) return Float4.Zero;

				return 1f / (float)Math.Sqrt(squared) * this;
			}
		}

		public Int4 Squared
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int4(X * X, Y * Y, Z * Z, W * W);
		}

		public Int4 Sorted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X < Y)
				{
					if (Y < Z) //XYZ
					{
						if (Z < W) return XYZW;
						if (Y < W) return XYWZ;
						if (X < W) return XWYZ;

						return WXYZ;
					}

					if (X < Z) //XZY
					{
						if (Y < W) return XZYW;
						if (Z < W) return XZWY;
						if (X < W) return XWZY;

						return WXZY;
					}

					//ZXY

					if (Y < W) return ZXYW;
					if (X < W) return ZXWY;
					if (Z < W) return ZWXY;

					return WZXY;
				}

				if (X < Z) //YXZ
				{
					if (Z < W) return YXZW;
					if (X < W) return YXWZ;
					if (Y < W) return YWXZ;

					return WYXZ;
				}

				if (Y < Z) //YZX
				{
					if (X < W) return YZXW;
					if (Z < W) return YZWX;
					if (Y < W) return YWZX;

					return WYZX;
				}

				//ZYX

				if (X < W) return ZYXW;
				if (Y < W) return ZYWX;
				if (Z < W) return ZWYX;

				return WZYX;
			}
		}

		public Int4 SortedReversed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X > Y)
				{
					if (Y > Z) //XYZ
					{
						if (Z > W) return XYZW;
						if (Y > W) return XYWZ;
						if (X > W) return XWYZ;

						return WXYZ;
					}

					if (X > Z) //XZY
					{
						if (Y > W) return XZYW;
						if (Z > W) return XZWY;
						if (X > W) return XWZY;

						return WXZY;
					}

					//ZXY

					if (Y > W) return ZXYW;
					if (X > W) return ZXWY;
					if (Z > W) return ZWXY;

					return WZXY;
				}

				if (X > Z) //YXZ
				{
					if (Z > W) return YXZW;
					if (X > W) return YXWZ;
					if (Y > W) return YWXZ;

					return WYXZ;
				}

				if (Y > Z) //YZX
				{
					if (X > W) return YZXW;
					if (Z > W) return YZWX;
					if (Y > W) return YWZX;

					return WYZX;
				}

				//ZYX

				if (X > W) return ZYXW;
				if (Y > W) return ZYWX;
				if (Z > W) return ZWYX;

				return WZYX;
			}
		}

#endregion

#endregion

#endregion

#region Methods

#region Instance

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public int Dot(in Int4 other) => X * other.X + Y * other.Y + Z * other.Z + W * other.W;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public long DotLong(in Int4 other) => (long)X * other.X + (long)Y * other.Y + (long)Z * other.Z + (long)W * other.W;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Angle(in Int4 other)
		{
			long squared = SquaredMagnitudeLong * other.SquaredMagnitudeLong;
			if (squared == 0) return 0f;

			return (float)Math.Acos(DotLong(other) / Math.Sqrt(squared)) * Scalars.RadianToDegree;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Distance(in Int4 other) => (other - this).Magnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DistanceDouble(in Int4 other) => (other - this).MagnitudeDouble;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public int SquaredDistance(in Int4 other) => (other - this).SquaredMagnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public long SquaredDistanceLong(in Int4 other) => (other - this).SquaredMagnitudeLong;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Min(in Int4 other) => new Int4(Math.Min(X, other.X), Math.Min(Y, other.Y), Math.Min(Z, other.Z), Math.Min(W, other.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Max(in Int4 other) => new Int4(Math.Max(X, other.X), Math.Max(Y, other.Y), Math.Max(Z, other.Z), Math.Max(W, other.W));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Clamp(in Int4 min, in Int4 max) => new Int4(X.Clamp(min.X, max.X), Y.Clamp(min.Y, max.Y), Z.Clamp(min.Z, max.Z), W.Clamp(min.W, max.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Clamp(int min = 0, int max = 1) => new Int4(X.Clamp(min, max), Y.Clamp(min, max), Z.Clamp(min, max), W.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Clamp(in Float4 min, in Float4 max) => new Float4(X.Clamp(min.X, max.X), Y.Clamp(min.Y, max.Y), Z.Clamp(min.Z, max.Z), W.Clamp(min.W, max.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Clamp(float min, float max = 1f) => new Float4(X.Clamp(min, max), Y.Clamp(min, max), Z.Clamp(min, max), W.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float4 ClampMagnitude(float max)
		{
			double squared = SquaredMagnitudeLong;
			if (squared <= (double)max * max) return this;

			float scale = max / (float)Math.Sqrt(squared);
			return new Float4(X * scale, Y * scale, Z * scale, W * scale);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Power(in Float4 value) => new Float4((float)Math.Pow(X, value.X), (float)Math.Pow(Y, value.Y), (float)Math.Pow(Z, value.Z), (float)Math.Pow(W, value.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Power(float value) => new Float4((float)Math.Pow(X, value), (float)Math.Pow(Y, value), (float)Math.Pow(Z, value), (float)Math.Pow(W, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Lerp(in Int4 other, in Int4 value) => new Int4(Scalars.Lerp(X, other.X, value.X), Scalars.Lerp(Y, other.Y, value.Y), Scalars.Lerp(Z, other.Z, value.Z), Scalars.Lerp(W, other.W, value.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Lerp(in Int4 other, int value) => new Int4(Scalars.Lerp(X, other.X, value), Scalars.Lerp(Y, other.Y, value), Scalars.Lerp(Z, other.Z, value), Scalars.Lerp(W, other.W, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Lerp(in Int4 other, in Float4 value) => new Float4(Scalars.Lerp(X, other.X, value.X), Scalars.Lerp(Y, other.Y, value.Y), Scalars.Lerp(Z, other.Z, value.Z), Scalars.Lerp(Z, other.Z, value.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Lerp(in Int4 other, float value) => new Float4(Scalars.Lerp(X, other.X, value), Scalars.Lerp(Y, other.Y, value), Scalars.Lerp(Z, other.Z, value), Scalars.Lerp(Z, other.Z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 InverseLerp(in Int4 other, in Int4 value) => new Int4(Scalars.InverseLerp(X, other.X, value.X), Scalars.InverseLerp(Y, other.Y, value.Y), Scalars.InverseLerp(Z, other.Z, value.Z), Scalars.InverseLerp(W, other.W, value.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 InverseLerp(in Int4 other, int value) => new Int4(Scalars.InverseLerp(X, other.X, value), Scalars.InverseLerp(Y, other.Y, value), Scalars.InverseLerp(Z, other.Z, value), Scalars.InverseLerp(W, other.W, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 InverseLerp(in Int4 other, in Float4 value) => new Float4(Scalars.InverseLerp(X, other.X, value.X), Scalars.InverseLerp(Y, other.Y, value.Y), Scalars.InverseLerp(Z, other.Z, value.Z), Scalars.InverseLerp(W, other.W, value.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 InverseLerp(in Int4 other, float value) => new Float4(Scalars.InverseLerp(X, other.X, value), Scalars.InverseLerp(Y, other.Y, value), Scalars.InverseLerp(Z, other.Z, value), Scalars.InverseLerp(W, other.W, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Repeat(in Int4 length) => new Int4(X.Repeat(length.X), Y.Repeat(length.Y), Z.Repeat(length.Z), W.Repeat(length.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Repeat(int length) => new Int4(X.Repeat(length), Y.Repeat(length), Z.Repeat(length), W.Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Repeat(in Float4 length) => new Float4(((float)X).Repeat(length.X), ((float)Y).Repeat(length.Y), ((float)Z).Repeat(length.Z), ((float)Z).Repeat(length.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Repeat(float length) => new Float4(((float)X).Repeat(length), ((float)Y).Repeat(length), ((float)Z).Repeat(length), ((float)W).Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 FlooredDivide(in Int4 divisor) => new Int4(X.FlooredDivide(divisor.X), Y.FlooredDivide(divisor.Y), Z.FlooredDivide(divisor.Z), W.FlooredDivide(divisor.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 FlooredDivide(int divisor) => new Int4(X.FlooredDivide(divisor), Y.FlooredDivide(divisor), Z.FlooredDivide(divisor), W.FlooredDivide(divisor));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 CeiledDivide(in Int4 divisor) => new Int4(X.CeiledDivide(divisor.X), Y.CeiledDivide(divisor.Y), Z.CeiledDivide(divisor.Z), W.CeiledDivide(divisor.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 CeiledDivide(int divisor) => new Int4(X.CeiledDivide(divisor), Y.CeiledDivide(divisor), Z.CeiledDivide(divisor), W.CeiledDivide(divisor));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Damp(in Float4 target, ref Float4 velocity, in Float4 smoothTime, float deltaTime) => Float4.Damp(this, target, ref velocity, smoothTime, deltaTime);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Damp(in Float4 target, ref Float4 velocity, float smoothTime, float deltaTime) => Float4.Damp(this, target, ref velocity, smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Reflect(in Int4 normal) => -2 * Dot(normal) * normal + this;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Project(in Float4 normal) => normal * (normal.Dot(this) / normal.SquaredMagnitude);

		public override string ToString() => ToString(string.Empty);

		public string ToString(string format) => ToString(format, CultureInfo.InvariantCulture);
		public string ToString(string format, IFormatProvider provider) => $"({X.ToString(format, provider)}, {Y.ToString(format, provider)}, {Z.ToString(format, provider)}, {W.ToString(format, provider)})";

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Int4 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Int4 other) => EqualsFast(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool EqualsFast(in Int4 other) => X == other.X && Y == other.Y && Z == other.Z && W == other.W;

		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = X.GetHashCode();
				hashCode = (hashCode * 397) ^ Y.GetHashCode();
				hashCode = (hashCode * 397) ^ Z.GetHashCode();
				hashCode = (hashCode * 397) ^ W.GetHashCode();
				return hashCode;
			}
		}

#endregion

#region Static

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Dot(in Int4 value, in Int4 other) => value.Dot(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double DotLong(in Int4 value, in Int4 other) => value.DotLong(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Angle(in Int4 first, in Int4 second) => first.Angle(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Distance(in Int4 value, in Int4 other) => value.Distance(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double DistanceDouble(in Int4 value, in Int4 other) => value.DistanceDouble(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float SquaredDistance(in Int4 value, in Int4 other) => value.SquaredDistance(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double SquaredDistanceLong(in Int4 value, in Int4 other) => value.SquaredDistanceLong(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 Min(in Int4 value, in Int4 other) => value.Min(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 Max(in Int4 value, in Int4 other) => value.Max(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 Clamp(in Int4 value, in Int4 min, in Int4 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 Clamp(in Int4 value, int min = 0, int max = 1) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Clamp(in Int4 value, in Float4 min, in Float4 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Clamp(in Int4 value, float min, float max = 1f) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 ClampMagnitude(in Int4 value, float max) => value.ClampMagnitude(max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Power(in Float4 value, in Float4 power) => value.Power(power);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Power(in Float4 value, float power) => value.Power(power);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 Lerp(in Int4 first, in Int4 second, in Int4 value) => first.Lerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 Lerp(in Int4 first, in Int4 second, int value) => first.Lerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Lerp(in Int4 first, in Int4 second, in Float4 value) => first.Lerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Lerp(in Int4 first, in Int4 second, float value) => first.Lerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 InverseLerp(in Int4 first, in Int4 second, in Int4 value) => first.InverseLerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 InverseLerp(in Int4 first, in Int4 second, int value) => first.InverseLerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 InverseLerp(in Int4 first, in Int4 second, in Float4 value) => first.InverseLerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 InverseLerp(in Int4 first, in Int4 second, float value) => first.InverseLerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 Repeat(in Int4 value, in Int4 length) => value.Repeat(length);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 Repeat(in Int4 value, int length) => value.Repeat(length);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Repeat(in Int4 value, in Float4 length) => value.Repeat(length);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Repeat(in Int4 value, float length) => value.Repeat(length);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 FlooredDivide(in Int4 value, in Int4 divisor) => value.FlooredDivide(divisor);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 FlooredDivide(in Int4 value, int divisor) => value.FlooredDivide(divisor);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 CeiledDivide(in Int4 value, in Int4 divisor) => value.CeiledDivide(divisor);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 CeiledDivide(in Int4 value, int divisor) => value.CeiledDivide(divisor);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Damp(in Int4 current, in Float4 target, ref Float4 velocity, in Float4 smoothTime, float deltaTime) => Float4.Damp(current, target, ref velocity, smoothTime, deltaTime);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Damp(in Int4 current, in Float4 target, ref Float4 velocity, float smoothTime, float deltaTime) => Float4.Damp(current, target, ref velocity, smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 Reflect(in Int4 value, in Int4 normal) => value.Reflect(normal);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Project(in Int4 value, in Float4 normal) => value.Project(normal);

#endregion

#region Create

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int4 Create(int index, int value)
		{
#if CODE_HELPERS_UNSAFE
			unsafe
			{
				if (index < 0 || 3 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Int4 result = default;
				((int*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Int4(value, 0, 0, 0);
				case 1:  return new Int4(0, value, 0, 0);
				case 2:  return new Int4(0, 0, value, 0);
				case 3:  return new Int4(0, 0, 0, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int4 Create(int index, int value, int other)
		{
#if CODE_HELPERS_UNSAFE
			unsafe
			{
				if (index < 0 || 3 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Int4 result = new Int4(other, other, other, other);
				((int*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Int4(value, other, other, other);
				case 1:  return new Int4(other, value, other, other);
				case 2:  return new Int4(other, other, value, other);
				case 3:  return new Int4(other, other, other, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Int4 Replace(int index, int value)
		{
#if CODE_HELPERS_UNSAFE
			unsafe
			{
				if (index < 0 || 3 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Int4 result = this; //Make a copy of this struct
				((int*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Int4(value, y, z, w);
				case 1:  return new Int4(x, value, z, w);
				case 2:  return new Int4(x, y, value, w);
				case 3:  return new Int4(x, y, z, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator +(in Int4 first, in Int4 second) => new Int4(first.X + second.X, first.Y + second.Y, first.Z + second.Z, first.W + second.W);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator -(in Int4 first, in Int4 second) => new Int4(first.X - second.X, first.Y - second.Y, first.Z - second.Z, first.W - second.W);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator *(in Int4 first, in Int4 second) => new Int4(first.X * second.X, first.Y * second.Y, first.Z * second.Z, first.W * second.W);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator /(in Int4 first, in Int4 second) => new Int4(first.X / second.X, first.Y / second.Y, first.Z / second.Z, first.W / second.W);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator *(in Int4 first, int second) => new Int4(first.X * second, first.Y * second, first.Z * second, first.W * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator /(in Int4 first, int second) => new Int4(first.X / second, first.Y / second, first.Z / second, first.W / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator *(in Int4 first, float second) => new Float4(first.X * second, first.Y * second, first.Z * second, first.W * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator /(in Int4 first, float second) => new Float4(first.X / second, first.Y / second, first.Z / second, first.W / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator *(int first, in Int4 second) => new Int4(first * second.X, first * second.Y, first * second.Z, first * second.W);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator /(int first, in Int4 second) => new Int4(first / second.X, first / second.Y, first / second.Z, first / second.W);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator *(float first, in Int4 second) => new Float4(first * second.X, first * second.Y, first * second.Z, first * second.W);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator /(float first, in Int4 second) => new Float4(first / second.X, first / second.Y, first / second.Z, first / second.W);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator +(in Int4 value) => value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator -(in Int4 value) => new Int4(-value.X, -value.Y, -value.Z, -value.W);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator %(in Int4 first, in Int4 second) => new Int4(first.X % second.X, first.Y % second.Y, first.Z % second.Z, first.W % second.W);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator %(in Int4 first, int second) => new Int4(first.X % second, first.Y % second, first.Z % second, first.W % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator %(int first, in Int4 second) => new Int4(first % second.X, first % second.Y, first % second.Z, first % second.W);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator %(in Int4 first, float second) => new Float4(first.X % second, first.Y % second, first.Z % second, first.W % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator %(float first, in Int4 second) => new Float4(first % second.X, first % second.Y, first % second.Z, first % second.W);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(in Int4 first, in Int4 second) => first.EqualsFast(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(in Int4 first, in Int4 second) => !first.EqualsFast(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(in Int4 first, in Int4 second) => first.X < second.X && first.Y < second.Y && first.Z < second.Z && first.W < second.W;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(in Int4 first, in Int4 second) => first.X > second.X && first.Y > second.Y && first.Z > second.Z && first.W > second.W;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(in Int4 first, in Int4 second) => first.X <= second.X && first.Y <= second.Y && first.Z <= second.Z && first.W <= second.W;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(in Int4 first, in Int4 second) => first.X >= second.X && first.Y >= second.Y && first.Z >= second.Z && first.W >= second.W;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(in Int4 value) => value.XY;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(in Int4 value) => value.XYZ;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(int value) => new Int4(value, value, value, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(in Int4 value) => new Float2(value.X, value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(in Int4 value) => new Float3(value.X, value.Y, value.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float4(in Int4 value) => new Float4(value.X, value.Y, value.Z, value.W);

#if CODE_HELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector4(in Int4 value) => new UnityEngine.Vector4(value.X, value.Y, value.Z, value.W);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Quaternion(in Int4 value) => new UnityEngine.Quaternion(value.X, value.Y, value.Z, value.W);
#endif

#endregion

#endregion

#region Enumerations

		/// <summary>
		/// Returns an enumerable that can be put into a foreach loop.
		/// Yields the two components of this vector in a series.
		/// </summary>
		public SeriesEnumerable Series() => new SeriesEnumerable(this);

		public readonly struct SeriesEnumerable : IEnumerable<int>
		{
			public SeriesEnumerable(in Int4 value) => enumerator = new Enumerator(value);

			readonly Enumerator enumerator;

			public Enumerator GetEnumerator() => enumerator;

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			IEnumerator<int> IEnumerable<int>.GetEnumerator() => GetEnumerator();

			public struct Enumerator : IEnumerator<int>
			{
				public Enumerator(in Int4 source)
				{
					this.source = source;
					index = -1;
				}

				readonly Int4 source;
				int index;

				object IEnumerator.Current => Current;
				public int Current => source[index];

				public bool MoveNext() => index++ < 3;
				public void Reset() => index = -1;

				public void Dispose() { }
			}
		}

#endregion

	}
}