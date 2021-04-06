using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CodeHelpers.Mathematics
{
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Int4 : IEquatable<Int4>, IFormattable
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Int4(int x, int y, int z, int w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		public readonly int x;
		public readonly int y;
		public readonly int z;
		public readonly int w;

#region Swizzled4

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXXX => new Int4(x, x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXXY => new Int4(x, x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXXZ => new Int4(x, x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXXW => new Int4(x, x, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXX_ => new Int4(x, x, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXYX => new Int4(x, x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXYY => new Int4(x, x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXYZ => new Int4(x, x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXYW => new Int4(x, x, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXY_ => new Int4(x, x, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXZX => new Int4(x, x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXZY => new Int4(x, x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXZZ => new Int4(x, x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXZW => new Int4(x, x, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXZ_ => new Int4(x, x, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXWX => new Int4(x, x, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXWY => new Int4(x, x, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXWZ => new Int4(x, x, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXWW => new Int4(x, x, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXW_ => new Int4(x, x, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX_X => new Int4(x, x, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX_Y => new Int4(x, x, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX_Z => new Int4(x, x, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX_W => new Int4(x, x, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX__ => new Int4(x, x, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYXX => new Int4(x, y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYXY => new Int4(x, y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYXZ => new Int4(x, y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYXW => new Int4(x, y, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYX_ => new Int4(x, y, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYYX => new Int4(x, y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYYY => new Int4(x, y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYYZ => new Int4(x, y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYYW => new Int4(x, y, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYY_ => new Int4(x, y, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYZX => new Int4(x, y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYZY => new Int4(x, y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYZZ => new Int4(x, y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYZW => new Int4(x, y, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYZ_ => new Int4(x, y, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYWX => new Int4(x, y, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYWY => new Int4(x, y, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYWZ => new Int4(x, y, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYWW => new Int4(x, y, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYW_ => new Int4(x, y, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY_X => new Int4(x, y, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY_Y => new Int4(x, y, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY_Z => new Int4(x, y, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY_W => new Int4(x, y, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY__ => new Int4(x, y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZXX => new Int4(x, z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZXY => new Int4(x, z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZXZ => new Int4(x, z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZXW => new Int4(x, z, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZX_ => new Int4(x, z, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZYX => new Int4(x, z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZYY => new Int4(x, z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZYZ => new Int4(x, z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZYW => new Int4(x, z, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZY_ => new Int4(x, z, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZZX => new Int4(x, z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZZY => new Int4(x, z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZZZ => new Int4(x, z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZZW => new Int4(x, z, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZZ_ => new Int4(x, z, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZWX => new Int4(x, z, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZWY => new Int4(x, z, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZWZ => new Int4(x, z, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZWW => new Int4(x, z, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZW_ => new Int4(x, z, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZ_X => new Int4(x, z, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZ_Y => new Int4(x, z, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZ_Z => new Int4(x, z, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZ_W => new Int4(x, z, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XZ__ => new Int4(x, z, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWXX => new Int4(x, w, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWXY => new Int4(x, w, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWXZ => new Int4(x, w, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWXW => new Int4(x, w, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWX_ => new Int4(x, w, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWYX => new Int4(x, w, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWYY => new Int4(x, w, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWYZ => new Int4(x, w, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWYW => new Int4(x, w, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWY_ => new Int4(x, w, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWZX => new Int4(x, w, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWZY => new Int4(x, w, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWZZ => new Int4(x, w, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWZW => new Int4(x, w, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWZ_ => new Int4(x, w, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWWX => new Int4(x, w, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWWY => new Int4(x, w, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWWZ => new Int4(x, w, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWWW => new Int4(x, w, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XWW_ => new Int4(x, w, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XW_X => new Int4(x, w, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XW_Y => new Int4(x, w, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XW_Z => new Int4(x, w, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XW_W => new Int4(x, w, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XW__ => new Int4(x, w, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_XX => new Int4(x, 0, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_XY => new Int4(x, 0, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_XZ => new Int4(x, 0, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_XW => new Int4(x, 0, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_X_ => new Int4(x, 0, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_YX => new Int4(x, 0, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_YY => new Int4(x, 0, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_YZ => new Int4(x, 0, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_YW => new Int4(x, 0, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_Y_ => new Int4(x, 0, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_ZX => new Int4(x, 0, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_ZY => new Int4(x, 0, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_ZZ => new Int4(x, 0, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_ZW => new Int4(x, 0, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_Z_ => new Int4(x, 0, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_WX => new Int4(x, 0, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_WY => new Int4(x, 0, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_WZ => new Int4(x, 0, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_WW => new Int4(x, 0, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_W_ => new Int4(x, 0, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X__X => new Int4(x, 0, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X__Y => new Int4(x, 0, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X__Z => new Int4(x, 0, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X__W => new Int4(x, 0, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X___ => new Int4(x, 0, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXXX => new Int4(y, x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXXY => new Int4(y, x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXXZ => new Int4(y, x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXXW => new Int4(y, x, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXX_ => new Int4(y, x, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXYX => new Int4(y, x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXYY => new Int4(y, x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXYZ => new Int4(y, x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXYW => new Int4(y, x, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXY_ => new Int4(y, x, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXZX => new Int4(y, x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXZY => new Int4(y, x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXZZ => new Int4(y, x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXZW => new Int4(y, x, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXZ_ => new Int4(y, x, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXWX => new Int4(y, x, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXWY => new Int4(y, x, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXWZ => new Int4(y, x, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXWW => new Int4(y, x, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXW_ => new Int4(y, x, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX_X => new Int4(y, x, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX_Y => new Int4(y, x, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX_Z => new Int4(y, x, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX_W => new Int4(y, x, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX__ => new Int4(y, x, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYXX => new Int4(y, y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYXY => new Int4(y, y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYXZ => new Int4(y, y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYXW => new Int4(y, y, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYX_ => new Int4(y, y, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYYX => new Int4(y, y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYYY => new Int4(y, y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYYZ => new Int4(y, y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYYW => new Int4(y, y, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYY_ => new Int4(y, y, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYZX => new Int4(y, y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYZY => new Int4(y, y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYZZ => new Int4(y, y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYZW => new Int4(y, y, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYZ_ => new Int4(y, y, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYWX => new Int4(y, y, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYWY => new Int4(y, y, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYWZ => new Int4(y, y, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYWW => new Int4(y, y, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYW_ => new Int4(y, y, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY_X => new Int4(y, y, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY_Y => new Int4(y, y, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY_Z => new Int4(y, y, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY_W => new Int4(y, y, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY__ => new Int4(y, y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZXX => new Int4(y, z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZXY => new Int4(y, z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZXZ => new Int4(y, z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZXW => new Int4(y, z, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZX_ => new Int4(y, z, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZYX => new Int4(y, z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZYY => new Int4(y, z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZYZ => new Int4(y, z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZYW => new Int4(y, z, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZY_ => new Int4(y, z, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZZX => new Int4(y, z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZZY => new Int4(y, z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZZZ => new Int4(y, z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZZW => new Int4(y, z, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZZ_ => new Int4(y, z, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZWX => new Int4(y, z, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZWY => new Int4(y, z, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZWZ => new Int4(y, z, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZWW => new Int4(y, z, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZW_ => new Int4(y, z, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZ_X => new Int4(y, z, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZ_Y => new Int4(y, z, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZ_Z => new Int4(y, z, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZ_W => new Int4(y, z, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YZ__ => new Int4(y, z, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWXX => new Int4(y, w, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWXY => new Int4(y, w, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWXZ => new Int4(y, w, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWXW => new Int4(y, w, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWX_ => new Int4(y, w, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWYX => new Int4(y, w, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWYY => new Int4(y, w, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWYZ => new Int4(y, w, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWYW => new Int4(y, w, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWY_ => new Int4(y, w, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWZX => new Int4(y, w, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWZY => new Int4(y, w, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWZZ => new Int4(y, w, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWZW => new Int4(y, w, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWZ_ => new Int4(y, w, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWWX => new Int4(y, w, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWWY => new Int4(y, w, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWWZ => new Int4(y, w, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWWW => new Int4(y, w, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YWW_ => new Int4(y, w, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YW_X => new Int4(y, w, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YW_Y => new Int4(y, w, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YW_Z => new Int4(y, w, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YW_W => new Int4(y, w, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YW__ => new Int4(y, w, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_XX => new Int4(y, 0, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_XY => new Int4(y, 0, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_XZ => new Int4(y, 0, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_XW => new Int4(y, 0, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_X_ => new Int4(y, 0, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_YX => new Int4(y, 0, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_YY => new Int4(y, 0, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_YZ => new Int4(y, 0, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_YW => new Int4(y, 0, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_Y_ => new Int4(y, 0, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_ZX => new Int4(y, 0, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_ZY => new Int4(y, 0, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_ZZ => new Int4(y, 0, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_ZW => new Int4(y, 0, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_Z_ => new Int4(y, 0, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_WX => new Int4(y, 0, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_WY => new Int4(y, 0, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_WZ => new Int4(y, 0, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_WW => new Int4(y, 0, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_W_ => new Int4(y, 0, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y__X => new Int4(y, 0, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y__Y => new Int4(y, 0, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y__Z => new Int4(y, 0, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y__W => new Int4(y, 0, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y___ => new Int4(y, 0, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXXX => new Int4(z, x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXXY => new Int4(z, x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXXZ => new Int4(z, x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXXW => new Int4(z, x, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXX_ => new Int4(z, x, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXYX => new Int4(z, x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXYY => new Int4(z, x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXYZ => new Int4(z, x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXYW => new Int4(z, x, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXY_ => new Int4(z, x, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXZX => new Int4(z, x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXZY => new Int4(z, x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXZZ => new Int4(z, x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXZW => new Int4(z, x, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXZ_ => new Int4(z, x, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXWX => new Int4(z, x, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXWY => new Int4(z, x, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXWZ => new Int4(z, x, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXWW => new Int4(z, x, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZXW_ => new Int4(z, x, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZX_X => new Int4(z, x, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZX_Y => new Int4(z, x, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZX_Z => new Int4(z, x, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZX_W => new Int4(z, x, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZX__ => new Int4(z, x, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYXX => new Int4(z, y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYXY => new Int4(z, y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYXZ => new Int4(z, y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYXW => new Int4(z, y, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYX_ => new Int4(z, y, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYYX => new Int4(z, y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYYY => new Int4(z, y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYYZ => new Int4(z, y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYYW => new Int4(z, y, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYY_ => new Int4(z, y, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYZX => new Int4(z, y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYZY => new Int4(z, y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYZZ => new Int4(z, y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYZW => new Int4(z, y, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYZ_ => new Int4(z, y, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYWX => new Int4(z, y, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYWY => new Int4(z, y, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYWZ => new Int4(z, y, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYWW => new Int4(z, y, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZYW_ => new Int4(z, y, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZY_X => new Int4(z, y, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZY_Y => new Int4(z, y, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZY_Z => new Int4(z, y, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZY_W => new Int4(z, y, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZY__ => new Int4(z, y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZXX => new Int4(z, z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZXY => new Int4(z, z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZXZ => new Int4(z, z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZXW => new Int4(z, z, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZX_ => new Int4(z, z, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZYX => new Int4(z, z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZYY => new Int4(z, z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZYZ => new Int4(z, z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZYW => new Int4(z, z, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZY_ => new Int4(z, z, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZZX => new Int4(z, z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZZY => new Int4(z, z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZZZ => new Int4(z, z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZZW => new Int4(z, z, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZZ_ => new Int4(z, z, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZWX => new Int4(z, z, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZWY => new Int4(z, z, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZWZ => new Int4(z, z, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZWW => new Int4(z, z, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZW_ => new Int4(z, z, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZ_X => new Int4(z, z, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZ_Y => new Int4(z, z, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZ_Z => new Int4(z, z, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZ_W => new Int4(z, z, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZZ__ => new Int4(z, z, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWXX => new Int4(z, w, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWXY => new Int4(z, w, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWXZ => new Int4(z, w, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWXW => new Int4(z, w, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWX_ => new Int4(z, w, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWYX => new Int4(z, w, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWYY => new Int4(z, w, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWYZ => new Int4(z, w, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWYW => new Int4(z, w, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWY_ => new Int4(z, w, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWZX => new Int4(z, w, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWZY => new Int4(z, w, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWZZ => new Int4(z, w, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWZW => new Int4(z, w, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWZ_ => new Int4(z, w, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWWX => new Int4(z, w, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWWY => new Int4(z, w, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWWZ => new Int4(z, w, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWWW => new Int4(z, w, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZWW_ => new Int4(z, w, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZW_X => new Int4(z, w, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZW_Y => new Int4(z, w, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZW_Z => new Int4(z, w, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZW_W => new Int4(z, w, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ZW__ => new Int4(z, w, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_XX => new Int4(z, 0, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_XY => new Int4(z, 0, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_XZ => new Int4(z, 0, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_XW => new Int4(z, 0, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_X_ => new Int4(z, 0, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_YX => new Int4(z, 0, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_YY => new Int4(z, 0, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_YZ => new Int4(z, 0, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_YW => new Int4(z, 0, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_Y_ => new Int4(z, 0, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_ZX => new Int4(z, 0, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_ZY => new Int4(z, 0, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_ZZ => new Int4(z, 0, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_ZW => new Int4(z, 0, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_Z_ => new Int4(z, 0, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_WX => new Int4(z, 0, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_WY => new Int4(z, 0, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_WZ => new Int4(z, 0, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_WW => new Int4(z, 0, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z_W_ => new Int4(z, 0, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z__X => new Int4(z, 0, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z__Y => new Int4(z, 0, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z__Z => new Int4(z, 0, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z__W => new Int4(z, 0, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Z___ => new Int4(z, 0, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXXX => new Int4(w, x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXXY => new Int4(w, x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXXZ => new Int4(w, x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXXW => new Int4(w, x, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXX_ => new Int4(w, x, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXYX => new Int4(w, x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXYY => new Int4(w, x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXYZ => new Int4(w, x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXYW => new Int4(w, x, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXY_ => new Int4(w, x, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXZX => new Int4(w, x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXZY => new Int4(w, x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXZZ => new Int4(w, x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXZW => new Int4(w, x, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXZ_ => new Int4(w, x, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXWX => new Int4(w, x, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXWY => new Int4(w, x, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXWZ => new Int4(w, x, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXWW => new Int4(w, x, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WXW_ => new Int4(w, x, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WX_X => new Int4(w, x, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WX_Y => new Int4(w, x, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WX_Z => new Int4(w, x, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WX_W => new Int4(w, x, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WX__ => new Int4(w, x, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYXX => new Int4(w, y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYXY => new Int4(w, y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYXZ => new Int4(w, y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYXW => new Int4(w, y, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYX_ => new Int4(w, y, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYYX => new Int4(w, y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYYY => new Int4(w, y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYYZ => new Int4(w, y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYYW => new Int4(w, y, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYY_ => new Int4(w, y, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYZX => new Int4(w, y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYZY => new Int4(w, y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYZZ => new Int4(w, y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYZW => new Int4(w, y, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYZ_ => new Int4(w, y, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYWX => new Int4(w, y, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYWY => new Int4(w, y, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYWZ => new Int4(w, y, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYWW => new Int4(w, y, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WYW_ => new Int4(w, y, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WY_X => new Int4(w, y, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WY_Y => new Int4(w, y, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WY_Z => new Int4(w, y, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WY_W => new Int4(w, y, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WY__ => new Int4(w, y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZXX => new Int4(w, z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZXY => new Int4(w, z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZXZ => new Int4(w, z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZXW => new Int4(w, z, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZX_ => new Int4(w, z, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZYX => new Int4(w, z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZYY => new Int4(w, z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZYZ => new Int4(w, z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZYW => new Int4(w, z, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZY_ => new Int4(w, z, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZZX => new Int4(w, z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZZY => new Int4(w, z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZZZ => new Int4(w, z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZZW => new Int4(w, z, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZZ_ => new Int4(w, z, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZWX => new Int4(w, z, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZWY => new Int4(w, z, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZWZ => new Int4(w, z, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZWW => new Int4(w, z, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZW_ => new Int4(w, z, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZ_X => new Int4(w, z, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZ_Y => new Int4(w, z, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZ_Z => new Int4(w, z, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZ_W => new Int4(w, z, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WZ__ => new Int4(w, z, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWXX => new Int4(w, w, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWXY => new Int4(w, w, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWXZ => new Int4(w, w, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWXW => new Int4(w, w, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWX_ => new Int4(w, w, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWYX => new Int4(w, w, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWYY => new Int4(w, w, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWYZ => new Int4(w, w, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWYW => new Int4(w, w, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWY_ => new Int4(w, w, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWZX => new Int4(w, w, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWZY => new Int4(w, w, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWZZ => new Int4(w, w, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWZW => new Int4(w, w, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWZ_ => new Int4(w, w, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWWX => new Int4(w, w, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWWY => new Int4(w, w, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWWZ => new Int4(w, w, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWWW => new Int4(w, w, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WWW_ => new Int4(w, w, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WW_X => new Int4(w, w, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WW_Y => new Int4(w, w, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WW_Z => new Int4(w, w, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WW_W => new Int4(w, w, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 WW__ => new Int4(w, w, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_XX => new Int4(w, 0, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_XY => new Int4(w, 0, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_XZ => new Int4(w, 0, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_XW => new Int4(w, 0, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_X_ => new Int4(w, 0, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_YX => new Int4(w, 0, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_YY => new Int4(w, 0, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_YZ => new Int4(w, 0, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_YW => new Int4(w, 0, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_Y_ => new Int4(w, 0, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_ZX => new Int4(w, 0, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_ZY => new Int4(w, 0, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_ZZ => new Int4(w, 0, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_ZW => new Int4(w, 0, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_Z_ => new Int4(w, 0, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_WX => new Int4(w, 0, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_WY => new Int4(w, 0, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_WZ => new Int4(w, 0, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_WW => new Int4(w, 0, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W_W_ => new Int4(w, 0, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W__X => new Int4(w, 0, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W__Y => new Int4(w, 0, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W__Z => new Int4(w, 0, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W__W => new Int4(w, 0, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 W___ => new Int4(w, 0, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XXX => new Int4(0, x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XXY => new Int4(0, x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XXZ => new Int4(0, x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XXW => new Int4(0, x, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XX_ => new Int4(0, x, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XYX => new Int4(0, x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XYY => new Int4(0, x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XYZ => new Int4(0, x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XYW => new Int4(0, x, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XY_ => new Int4(0, x, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XZX => new Int4(0, x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XZY => new Int4(0, x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XZZ => new Int4(0, x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XZW => new Int4(0, x, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XZ_ => new Int4(0, x, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XWX => new Int4(0, x, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XWY => new Int4(0, x, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XWZ => new Int4(0, x, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XWW => new Int4(0, x, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XW_ => new Int4(0, x, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X_X => new Int4(0, x, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X_Y => new Int4(0, x, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X_Z => new Int4(0, x, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X_W => new Int4(0, x, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X__ => new Int4(0, x, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YXX => new Int4(0, y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YXY => new Int4(0, y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YXZ => new Int4(0, y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YXW => new Int4(0, y, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YX_ => new Int4(0, y, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YYX => new Int4(0, y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YYY => new Int4(0, y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YYZ => new Int4(0, y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YYW => new Int4(0, y, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YY_ => new Int4(0, y, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YZX => new Int4(0, y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YZY => new Int4(0, y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YZZ => new Int4(0, y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YZW => new Int4(0, y, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YZ_ => new Int4(0, y, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YWX => new Int4(0, y, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YWY => new Int4(0, y, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YWZ => new Int4(0, y, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YWW => new Int4(0, y, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YW_ => new Int4(0, y, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y_X => new Int4(0, y, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y_Y => new Int4(0, y, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y_Z => new Int4(0, y, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y_W => new Int4(0, y, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y__ => new Int4(0, y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZXX => new Int4(0, z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZXY => new Int4(0, z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZXZ => new Int4(0, z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZXW => new Int4(0, z, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZX_ => new Int4(0, z, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZYX => new Int4(0, z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZYY => new Int4(0, z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZYZ => new Int4(0, z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZYW => new Int4(0, z, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZY_ => new Int4(0, z, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZZX => new Int4(0, z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZZY => new Int4(0, z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZZZ => new Int4(0, z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZZW => new Int4(0, z, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZZ_ => new Int4(0, z, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZWX => new Int4(0, z, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZWY => new Int4(0, z, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZWZ => new Int4(0, z, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZWW => new Int4(0, z, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _ZW_ => new Int4(0, z, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Z_X => new Int4(0, z, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Z_Y => new Int4(0, z, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Z_Z => new Int4(0, z, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Z_W => new Int4(0, z, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Z__ => new Int4(0, z, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WXX => new Int4(0, w, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WXY => new Int4(0, w, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WXZ => new Int4(0, w, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WXW => new Int4(0, w, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WX_ => new Int4(0, w, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WYX => new Int4(0, w, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WYY => new Int4(0, w, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WYZ => new Int4(0, w, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WYW => new Int4(0, w, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WY_ => new Int4(0, w, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WZX => new Int4(0, w, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WZY => new Int4(0, w, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WZZ => new Int4(0, w, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WZW => new Int4(0, w, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WZ_ => new Int4(0, w, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WWX => new Int4(0, w, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WWY => new Int4(0, w, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WWZ => new Int4(0, w, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WWW => new Int4(0, w, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _WW_ => new Int4(0, w, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _W_X => new Int4(0, w, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _W_Y => new Int4(0, w, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _W_Z => new Int4(0, w, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _W_W => new Int4(0, w, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _W__ => new Int4(0, w, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __XX => new Int4(0, 0, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __XY => new Int4(0, 0, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __XZ => new Int4(0, 0, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __XW => new Int4(0, 0, x, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __X_ => new Int4(0, 0, x, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __YX => new Int4(0, 0, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __YY => new Int4(0, 0, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __YZ => new Int4(0, 0, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __YW => new Int4(0, 0, y, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __Y_ => new Int4(0, 0, y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __ZX => new Int4(0, 0, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __ZY => new Int4(0, 0, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __ZZ => new Int4(0, 0, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __ZW => new Int4(0, 0, z, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __Z_ => new Int4(0, 0, z, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __WX => new Int4(0, 0, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __WY => new Int4(0, 0, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __WZ => new Int4(0, 0, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __WW => new Int4(0, 0, w, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __W_ => new Int4(0, 0, w, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ___X => new Int4(0, 0, 0, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ___Y => new Int4(0, 0, 0, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ___Z => new Int4(0, 0, 0, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ___W => new Int4(0, 0, 0, w);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ____ => new Int4(0, 0, 0, 0);

#endregion

#region Swizzled3

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXX => new Int3(x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXY => new Int3(x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXZ => new Int3(x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXW => new Int3(x, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYX => new Int3(x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYY => new Int3(x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYZ => new Int3(x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYW => new Int3(x, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZX => new Int3(x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZY => new Int3(x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZZ => new Int3(x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XZW => new Int3(x, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XWX => new Int3(x, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XWY => new Int3(x, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XWZ => new Int3(x, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XWW => new Int3(x, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXX => new Int3(y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXY => new Int3(y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXZ => new Int3(y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXW => new Int3(y, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYX => new Int3(y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYY => new Int3(y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYZ => new Int3(y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYW => new Int3(y, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZX => new Int3(y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZY => new Int3(y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZZ => new Int3(y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YZW => new Int3(y, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YWX => new Int3(y, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YWY => new Int3(y, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YWZ => new Int3(y, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YWW => new Int3(y, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXX => new Int3(z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXY => new Int3(z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXZ => new Int3(z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZXW => new Int3(z, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYX => new Int3(z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYY => new Int3(z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYZ => new Int3(z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZYW => new Int3(z, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZX => new Int3(z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZY => new Int3(z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZZ => new Int3(z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZZW => new Int3(z, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZWX => new Int3(z, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZWY => new Int3(z, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZWZ => new Int3(z, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ZWW => new Int3(z, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WXX => new Int3(w, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WXY => new Int3(w, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WXZ => new Int3(w, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WXW => new Int3(w, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WYX => new Int3(w, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WYY => new Int3(w, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WYZ => new Int3(w, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WYW => new Int3(w, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WZX => new Int3(w, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WZY => new Int3(w, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WZZ => new Int3(w, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WZW => new Int3(w, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WWX => new Int3(w, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WWY => new Int3(w, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WWZ => new Int3(w, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 WWW => new Int3(w, w, w);

#endregion

#region Swizzled2

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XX => new Int2(x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XY => new Int2(x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XZ => new Int2(x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XW => new Int2(x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YX => new Int2(y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YY => new Int2(y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YZ => new Int2(y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YW => new Int2(y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 ZX => new Int2(z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 ZY => new Int2(z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 ZZ => new Int2(z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 ZW => new Int2(z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 WX => new Int2(w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 WY => new Int2(w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 WZ => new Int2(w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 WW => new Int2(w, w);

#endregion

#region Static Properties

		public static readonly Int4 right = new Int4(1, 0, 0, 0);
		public static readonly Int4 left = new Int4(-1, 0, 0, 0);

		public static readonly Int4 up = new Int4(0, 1, 0, 0);
		public static readonly Int4 down = new Int4(0, -1, 0, 0);

		public static readonly Int4 forward = new Int4(0, 0, 1, 0);
		public static readonly Int4 backward = new Int4(0, 0, -1, 0);

		public static readonly Int4 ana = new Int4(0, 0, 0, 1);
		public static readonly Int4 kata = new Int4(0, 0, 0, -1);

		public static readonly Int4 zero = new Int4(0, 0, 0, 0);

		public static readonly Int4 one = new Int4(1, 1, 1, 1);
		public static readonly Int4 negativeOne = new Int4(-1, -1, -1, 1);

		public static readonly Int4 maxValue = new Int4(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);
		public static readonly Int4 minValue = new Int4(int.MinValue, int.MinValue, int.MinValue, int.MinValue);

#endregion

#region Instance Properties

#region Scaler Returns

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
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x * x + y * y + z * z + w * w;
		}

		public long SquaredMagnitudeLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)x * x + (long)y * y + (long)z * z + (long)w * w;
		}

		public int Product
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x * y * z * w;
		}

		public long ProductLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)x * y * z * w;
		}

		public int ProductAbsoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs(x * y * z * w);
		}

		public long ProductAbsolutedLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs((long)x * y * z * w);
		}

		public int Sum
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x + y + z + w;
		}

		public long SumLong
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (long)x + y + z + w;
		}

		public float Average
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (float)AverageDouble;
		}

		public double AverageDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => ((double)x + y + z + w) / 4d;
		}

		public int MinComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x < y)
				{
					if (x < z) return x < w ? x : w;
					return z < w ? z : w;
				}

				if (y < z) return y < w ? y : w;
				return z < w ? z : w;
			}
		}

		public int MinIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x < y)
				{
					if (x < z) return x < w ? 0 : 3;
					return z < w ? 2 : 3;
				}

				if (y < z) return y < w ? 1 : 3;
				return z < w ? 2 : 3;
			}
		}

		public int MaxComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x > y)
				{
					if (x > z) return x > w ? x : w;
					return z > w ? z : w;
				}

				if (y > z) return y > w ? y : w;
				return z > w ? z : w;
			}
		}

		public int MaxIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x > y)
				{
					if (x > z) return x > w ? 0 : 3;
					return z > w ? 2 : 3;
				}

				if (y > z) return y > w ? 1 : 3;
				return z > w ? 2 : 3;
			}
		}

		public int this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
#if UNSAFE_CODE_ENABLED
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
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int4(Math.Abs(x), Math.Abs(y), Math.Abs(z), Math.Abs(w));
		}

		public Int4 Signed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int4(x.Sign(), y.Sign(), z.Sign(), w.Sign());
		}

		public Float4 Normalized
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				long squared = SquaredMagnitudeLong;
				if (squared == 0) return Float4.zero;

				return this / (float)Math.Sqrt(squared);
			}
		}

		public Int4 Squared
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int4(x * x, y * y, z * z, w * w);
		}

		public Int4 Sorted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x < y)
				{
					if (y < z) //XYZ
					{
						if (z < w) return XYZW;
						if (y < w) return XYWZ;
						if (x < w) return XWYZ;

						return WXYZ;
					}

					if (x < z) //XZY
					{
						if (y < w) return XZYW;
						if (z < w) return XZWY;
						if (x < w) return XWZY;

						return WXZY;
					}

					//ZXY

					if (y < w) return ZXYW;
					if (x < w) return ZXWY;
					if (z < w) return ZWXY;

					return WZXY;
				}

				if (x < z) //YXZ
				{
					if (z < w) return YXZW;
					if (x < w) return YXWZ;
					if (y < w) return YWXZ;

					return WYXZ;
				}

				if (y < z) //YZX
				{
					if (x < w) return YZXW;
					if (z < w) return YZWX;
					if (y < w) return YWZX;

					return WYZX;
				}

				//ZYX

				if (x < w) return ZYXW;
				if (y < w) return ZYWX;
				if (z < w) return ZWYX;

				return WZYX;
			}
		}

		public Int4 SortedReversed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x > y)
				{
					if (y > z) //XYZ
					{
						if (z > w) return XYZW;
						if (y > w) return XYWZ;
						if (x > w) return XWYZ;

						return WXYZ;
					}

					if (x > z) //XZY
					{
						if (y > w) return XZYW;
						if (z > w) return XZWY;
						if (x > w) return XWZY;

						return WXZY;
					}

					//ZXY

					if (y > w) return ZXYW;
					if (x > w) return ZXWY;
					if (z > w) return ZWXY;

					return WZXY;
				}

				if (x > z) //YXZ
				{
					if (z > w) return YXZW;
					if (x > w) return YXWZ;
					if (y > w) return YWXZ;

					return WYXZ;
				}

				if (y > z) //YZX
				{
					if (x > w) return YZXW;
					if (z > w) return YZWX;
					if (y > w) return YWZX;

					return WYZX;
				}

				//ZYX

				if (x > w) return ZYXW;
				if (y > w) return ZYWX;
				if (z > w) return ZWYX;

				return WZYX;
			}
		}

#endregion

#endregion

#region Methods

#region Instance

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public int Dot(in Int4 other) => x * other.x + y * other.y + z * other.z + w * other.w;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public long DotLong(in Int4 other) => (long)x * other.x + (long)y * other.y + (long)z * other.z + (long)w * other.w;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Angle(in Int4 other)
		{
			double magnitude = Math.Sqrt(SquaredMagnitudeLong * other.SquaredMagnitudeLong);
			return Scalars.AlmostEquals(magnitude, 0d) ? 0f : (float)Math.Acos(DotLong(other) / magnitude) * Scalars.RadianToDegree;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Distance(in Int4 other) => (other - this).Magnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DistanceDouble(in Int4 other) => (other - this).MagnitudeDouble;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public int SquaredDistance(in Int4 other) => (other - this).SquaredMagnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public long SquaredDistanceLong(in Int4 other) => (other - this).SquaredMagnitudeLong;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Min(in Int4 other) => new Int4(Math.Min(x, other.x), Math.Min(y, other.y), Math.Min(z, other.z), Math.Min(w, other.w));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Max(in Int4 other) => new Int4(Math.Max(x, other.x), Math.Max(y, other.y), Math.Max(z, other.z), Math.Max(w, other.w));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Clamp(in Int4 min, in Int4 max) => new Int4(x.Clamp(min.x, max.x), y.Clamp(min.y, max.y), z.Clamp(min.z, max.z), w.Clamp(min.w, max.w));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Clamp(int min, int max) => new Int4(x.Clamp(min, max), y.Clamp(min, max), z.Clamp(min, max), w.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Clamp(in Float4 min, in Float4 max) => new Float4(x.Clamp(min.x, max.x), y.Clamp(min.y, max.y), z.Clamp(min.z, max.z), w.Clamp(min.w, max.w));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Clamp(float min, float max) => new Float4(x.Clamp(min, max), y.Clamp(min, max), z.Clamp(min, max), w.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float4 ClampMagnitude(float max)
		{
			double squared = SquaredMagnitudeLong;
			if (squared <= (double)max * max) return this;

			float scale = max / (float)Math.Sqrt(squared);
			return new Float4(x * scale, y * scale, z * scale, w * scale);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Power(in Float4 value) => new Float4((float)Math.Pow(x, value.x), (float)Math.Pow(y, value.y), (float)Math.Pow(z, value.z), (float)Math.Pow(w, value.w));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Power(float value) => new Float4((float)Math.Pow(x, value), (float)Math.Pow(y, value), (float)Math.Pow(z, value), (float)Math.Pow(w, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Lerp(in Int4 other, in Int4 value) => new Int4(Scalars.Lerp(x, other.x, value.x), Scalars.Lerp(y, other.y, value.y), Scalars.Lerp(z, other.z, value.z), Scalars.Lerp(w, other.w, value.w));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Lerp(in Int4 other, int value) => new Int4(Scalars.Lerp(x, other.x, value), Scalars.Lerp(y, other.y, value), Scalars.Lerp(z, other.z, value), Scalars.Lerp(w, other.w, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Lerp(in Int4 other, in Float4 value) => new Float4(Scalars.Lerp(x, other.x, value.x), Scalars.Lerp(y, other.y, value.y), Scalars.Lerp(z, other.z, value.z), Scalars.Lerp(z, other.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Lerp(in Int4 other, float value) => new Float4(Scalars.Lerp(x, other.x, value), Scalars.Lerp(y, other.y, value), Scalars.Lerp(z, other.z, value), Scalars.Lerp(z, other.z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 InverseLerp(in Int4 other, in Int4 value) => new Int4(Scalars.InverseLerp(x, other.x, value.x), Scalars.InverseLerp(y, other.y, value.y), Scalars.InverseLerp(z, other.z, value.z), Scalars.InverseLerp(w, other.w, value.w));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 InverseLerp(in Int4 other, int value) => new Int4(Scalars.InverseLerp(x, other.x, value), Scalars.InverseLerp(y, other.y, value), Scalars.InverseLerp(z, other.z, value), Scalars.InverseLerp(w, other.w, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 InverseLerp(in Int4 other, in Float4 value) => new Float4(Scalars.InverseLerp(x, other.x, value.x), Scalars.InverseLerp(y, other.y, value.y), Scalars.InverseLerp(z, other.z, value.z), Scalars.InverseLerp(w, other.w, value.w));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 InverseLerp(in Int4 other, float value) => new Float4(Scalars.InverseLerp(x, other.x, value), Scalars.InverseLerp(y, other.y, value), Scalars.InverseLerp(z, other.z, value), Scalars.InverseLerp(w, other.w, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Repeat(in Int4 length) => new Int4(x.Repeat(length.x), y.Repeat(length.y), z.Repeat(length.z), w.Repeat(length.w));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Repeat(int length) => new Int4(x.Repeat(length), y.Repeat(length), z.Repeat(length), w.Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Repeat(in Float4 length) => new Float4(((float)x).Repeat(length.x), ((float)y).Repeat(length.y), ((float)z).Repeat(length.z), ((float)z).Repeat(length.w));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Repeat(float length) => new Float4(((float)x).Repeat(length), ((float)y).Repeat(length), ((float)z).Repeat(length), ((float)w).Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 FlooredDivide(in Int4 divisor) => new Int4(x.FlooredDivide(divisor.x), y.FlooredDivide(divisor.y), z.FlooredDivide(divisor.z), w.FlooredDivide(divisor.w));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 FlooredDivide(int divisor) => new Int4(x.FlooredDivide(divisor), y.FlooredDivide(divisor), z.FlooredDivide(divisor), w.FlooredDivide(divisor));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 CeiledDivide(in Int4 divisor) => new Int4(x.CeiledDivide(divisor.x), y.CeiledDivide(divisor.y), z.CeiledDivide(divisor.z), w.CeiledDivide(divisor.w));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 CeiledDivide(int divisor) => new Int4(x.CeiledDivide(divisor), y.CeiledDivide(divisor), z.CeiledDivide(divisor), w.CeiledDivide(divisor));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Damp(in Float4 target, ref Float4 velocity, in Float4 smoothTime, float deltaTime) => Float4.Damp(this, target, ref velocity, smoothTime, deltaTime);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Damp(in Float4 target, ref Float4 velocity, float smoothTime, float deltaTime) => Float4.Damp(this, target, ref velocity, smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 Reflect(in Int4 normal) => -2 * Dot(normal) * normal + this;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Project(in Float4 normal) => normal * (normal.Dot(this) / normal.SquaredMagnitude);

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
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 Clamp(in Int4 value, int min, int max) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Clamp(in Int4 value, in Float4 min, in Float4 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Clamp(in Int4 value, float min, float max) => value.Clamp(min, max);

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
#if UNSAFE_CODE_ENABLED
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
#if UNSAFE_CODE_ENABLED
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
#if UNSAFE_CODE_ENABLED
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

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator +(in Int4 first, in Int4 second) => new Int4(first.x + second.x, first.y + second.y, first.z + second.z, first.w + second.w);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator -(in Int4 first, in Int4 second) => new Int4(first.x - second.x, first.y - second.y, first.z - second.z, first.w - second.w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator *(in Int4 first, in Int4 second) => new Int4(first.x * second.x, first.y * second.y, first.z * second.z, first.w * second.w);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator /(in Int4 first, in Int4 second) => new Int4(first.x / second.x, first.y / second.y, first.z / second.z, first.w / second.w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator *(in Int4 first, int second) => new Int4(first.x * second, first.y * second, first.z * second, first.w * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator /(in Int4 first, int second) => new Int4(first.x / second, first.y / second, first.z / second, first.w / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator *(in Int4 first, float second) => new Float4(first.x * second, first.y * second, first.z * second, first.w * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator /(in Int4 first, float second) => new Float4(first.x / second, first.y / second, first.z / second, first.w / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator *(int first, in Int4 second) => new Int4(first * second.x, first * second.y, first * second.z, first * second.w);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator /(int first, in Int4 second) => new Int4(first / second.x, first / second.y, first / second.z, first / second.w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator *(float first, in Int4 second) => new Float4(first * second.x, first * second.y, first * second.z, first * second.w);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator /(float first, in Int4 second) => new Float4(first / second.x, first / second.y, first / second.z, first / second.w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator +(in Int4 value) => value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator -(in Int4 value) => new Int4(-value.x, -value.y, -value.z, -value.w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator %(in Int4 first, in Int4 second) => new Int4(first.x % second.x, first.y % second.y, first.z % second.z, first.w % second.w);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator %(in Int4 first, int second) => new Int4(first.x % second, first.y % second, first.z % second, first.w % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator %(int first, in Int4 second) => new Int4(first % second.x, first % second.y, first % second.z, first % second.w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator %(in Int4 first, float second) => new Float4(first.x % second, first.y % second, first.z % second, first.w % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator %(float first, in Int4 second) => new Float4(first % second.x, first % second.y, first % second.z, first % second.w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(in Int4 first, in Int4 second) => first.Equals(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(in Int4 first, in Int4 second) => !first.Equals(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(in Int4 first, in Int4 second) => first.x < second.x && first.y < second.y && first.z < second.z && first.w < second.w;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(in Int4 first, in Int4 second) => first.x > second.x && first.y > second.y && first.z > second.z && first.w > second.w;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(in Int4 first, in Int4 second) => first.x <= second.x && first.y <= second.y && first.z <= second.z && first.w <= second.w;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(in Int4 first, in Int4 second) => first.x >= second.x && first.y >= second.y && first.z >= second.z && first.w >= second.w;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Int4 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Int4 other) => EqualsFast(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool EqualsFast(in Int4 other) => x == other.x && y == other.y && z == other.z && w == other.w;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(in Int4 value) => value.XY;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(in Int4 value) => value.XYZ;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(int value) => new Int4(value, value, value, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(in Int4 value) => new Float2(value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(in Int4 value) => new Float3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float4(in Int4 value) => new Float4(value.x, value.y, value.z, value.w);

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector4(in Int4 value) => new UnityEngine.Vector4(value.x, value.y, value.z, value.w);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Quaternion(in Int4 value) => new UnityEngine.Quaternion(value.x, value.y, value.z, value.w);
#endif

#endregion

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = x.GetHashCode();
				hashCode = (hashCode * 397) ^ y.GetHashCode();
				hashCode = (hashCode * 397) ^ z.GetHashCode();
				hashCode = (hashCode * 397) ^ w.GetHashCode();
				return hashCode;
			}
		}

		public override string ToString() => $"({x}, {y}, {z}, {w})";

		public string ToString(string format) => ToString(format, CultureInfo.InvariantCulture);
		public string ToString(string format, IFormatProvider formatProvider) => $"({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";

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