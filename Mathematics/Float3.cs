using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CodeHelpers.Mathematics
{
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct Float3 : IEquatable<Float3>, IFormattable
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		[FieldOffset(0)] public readonly float x;
		[FieldOffset(4)] public readonly float y;
		[FieldOffset(8)] public readonly float z;

#region Swizzled4

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXX => new Float4(x, x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXY => new Float4(x, x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXZ => new Float4(x, x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXX_ => new Float4(x, x, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYX => new Float4(x, x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYY => new Float4(x, x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYZ => new Float4(x, x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXY_ => new Float4(x, x, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZX => new Float4(x, x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZY => new Float4(x, x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZZ => new Float4(x, x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZ_ => new Float4(x, x, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX_X => new Float4(x, x, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX_Y => new Float4(x, x, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX_Z => new Float4(x, x, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX__ => new Float4(x, x, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXX => new Float4(x, y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXY => new Float4(x, y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXZ => new Float4(x, y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYX_ => new Float4(x, y, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYX => new Float4(x, y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYY => new Float4(x, y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYZ => new Float4(x, y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYY_ => new Float4(x, y, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZX => new Float4(x, y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZY => new Float4(x, y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZZ => new Float4(x, y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZ_ => new Float4(x, y, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY_X => new Float4(x, y, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY_Y => new Float4(x, y, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY_Z => new Float4(x, y, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY__ => new Float4(x, y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZXX => new Float4(x, z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZXY => new Float4(x, z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZXZ => new Float4(x, z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZX_ => new Float4(x, z, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZYX => new Float4(x, z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZYY => new Float4(x, z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZYZ => new Float4(x, z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZY_ => new Float4(x, z, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZX => new Float4(x, z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZY => new Float4(x, z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZZ => new Float4(x, z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZ_ => new Float4(x, z, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZ_X => new Float4(x, z, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZ_Y => new Float4(x, z, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZ_Z => new Float4(x, z, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZ__ => new Float4(x, z, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_XX => new Float4(x, 0f, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_XY => new Float4(x, 0f, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_XZ => new Float4(x, 0f, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_X_ => new Float4(x, 0f, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_YX => new Float4(x, 0f, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_YY => new Float4(x, 0f, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_YZ => new Float4(x, 0f, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_Y_ => new Float4(x, 0f, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_ZX => new Float4(x, 0f, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_ZY => new Float4(x, 0f, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_ZZ => new Float4(x, 0f, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_Z_ => new Float4(x, 0f, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X__X => new Float4(x, 0f, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X__Y => new Float4(x, 0f, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X__Z => new Float4(x, 0f, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X___ => new Float4(x, 0f, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXX => new Float4(y, x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXY => new Float4(y, x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXZ => new Float4(y, x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXX_ => new Float4(y, x, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYX => new Float4(y, x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYY => new Float4(y, x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYZ => new Float4(y, x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXY_ => new Float4(y, x, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZX => new Float4(y, x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZY => new Float4(y, x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZZ => new Float4(y, x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZ_ => new Float4(y, x, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX_X => new Float4(y, x, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX_Y => new Float4(y, x, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX_Z => new Float4(y, x, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX__ => new Float4(y, x, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXX => new Float4(y, y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXY => new Float4(y, y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXZ => new Float4(y, y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYX_ => new Float4(y, y, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYX => new Float4(y, y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYY => new Float4(y, y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYZ => new Float4(y, y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYY_ => new Float4(y, y, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZX => new Float4(y, y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZY => new Float4(y, y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZZ => new Float4(y, y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZ_ => new Float4(y, y, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY_X => new Float4(y, y, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY_Y => new Float4(y, y, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY_Z => new Float4(y, y, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY__ => new Float4(y, y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZXX => new Float4(y, z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZXY => new Float4(y, z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZXZ => new Float4(y, z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZX_ => new Float4(y, z, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZYX => new Float4(y, z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZYY => new Float4(y, z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZYZ => new Float4(y, z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZY_ => new Float4(y, z, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZX => new Float4(y, z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZY => new Float4(y, z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZZ => new Float4(y, z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZ_ => new Float4(y, z, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZ_X => new Float4(y, z, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZ_Y => new Float4(y, z, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZ_Z => new Float4(y, z, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZ__ => new Float4(y, z, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_XX => new Float4(y, 0f, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_XY => new Float4(y, 0f, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_XZ => new Float4(y, 0f, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_X_ => new Float4(y, 0f, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_YX => new Float4(y, 0f, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_YY => new Float4(y, 0f, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_YZ => new Float4(y, 0f, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_Y_ => new Float4(y, 0f, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_ZX => new Float4(y, 0f, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_ZY => new Float4(y, 0f, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_ZZ => new Float4(y, 0f, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_Z_ => new Float4(y, 0f, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y__X => new Float4(y, 0f, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y__Y => new Float4(y, 0f, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y__Z => new Float4(y, 0f, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y___ => new Float4(y, 0f, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXXX => new Float4(z, x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXXY => new Float4(z, x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXXZ => new Float4(z, x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXX_ => new Float4(z, x, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXYX => new Float4(z, x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXYY => new Float4(z, x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXYZ => new Float4(z, x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXY_ => new Float4(z, x, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZX => new Float4(z, x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZY => new Float4(z, x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZZ => new Float4(z, x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZ_ => new Float4(z, x, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZX_X => new Float4(z, x, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZX_Y => new Float4(z, x, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZX_Z => new Float4(z, x, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZX__ => new Float4(z, x, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYXX => new Float4(z, y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYXY => new Float4(z, y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYXZ => new Float4(z, y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYX_ => new Float4(z, y, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYYX => new Float4(z, y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYYY => new Float4(z, y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYYZ => new Float4(z, y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYY_ => new Float4(z, y, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZX => new Float4(z, y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZY => new Float4(z, y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZZ => new Float4(z, y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZ_ => new Float4(z, y, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZY_X => new Float4(z, y, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZY_Y => new Float4(z, y, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZY_Z => new Float4(z, y, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZY__ => new Float4(z, y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZXX => new Float4(z, z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZXY => new Float4(z, z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZXZ => new Float4(z, z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZX_ => new Float4(z, z, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZYX => new Float4(z, z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZYY => new Float4(z, z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZYZ => new Float4(z, z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZY_ => new Float4(z, z, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZX => new Float4(z, z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZY => new Float4(z, z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZZ => new Float4(z, z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZ_ => new Float4(z, z, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZ_X => new Float4(z, z, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZ_Y => new Float4(z, z, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZ_Z => new Float4(z, z, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZ__ => new Float4(z, z, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_XX => new Float4(z, 0f, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_XY => new Float4(z, 0f, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_XZ => new Float4(z, 0f, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_X_ => new Float4(z, 0f, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_YX => new Float4(z, 0f, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_YY => new Float4(z, 0f, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_YZ => new Float4(z, 0f, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_Y_ => new Float4(z, 0f, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_ZX => new Float4(z, 0f, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_ZY => new Float4(z, 0f, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_ZZ => new Float4(z, 0f, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_Z_ => new Float4(z, 0f, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z__X => new Float4(z, 0f, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z__Y => new Float4(z, 0f, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z__Z => new Float4(z, 0f, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z___ => new Float4(z, 0f, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XXX => new Float4(0f, x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XXY => new Float4(0f, x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XXZ => new Float4(0f, x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XX_ => new Float4(0f, x, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XYX => new Float4(0f, x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XYY => new Float4(0f, x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XYZ => new Float4(0f, x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XY_ => new Float4(0f, x, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XZX => new Float4(0f, x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XZY => new Float4(0f, x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XZZ => new Float4(0f, x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XZ_ => new Float4(0f, x, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X_X => new Float4(0f, x, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X_Y => new Float4(0f, x, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X_Z => new Float4(0f, x, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X__ => new Float4(0f, x, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YXX => new Float4(0f, y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YXY => new Float4(0f, y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YXZ => new Float4(0f, y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YX_ => new Float4(0f, y, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YYX => new Float4(0f, y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YYY => new Float4(0f, y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YYZ => new Float4(0f, y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YY_ => new Float4(0f, y, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YZX => new Float4(0f, y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YZY => new Float4(0f, y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YZZ => new Float4(0f, y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YZ_ => new Float4(0f, y, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y_X => new Float4(0f, y, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y_Y => new Float4(0f, y, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y_Z => new Float4(0f, y, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y__ => new Float4(0f, y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZXX => new Float4(0f, z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZXY => new Float4(0f, z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZXZ => new Float4(0f, z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZX_ => new Float4(0f, z, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZYX => new Float4(0f, z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZYY => new Float4(0f, z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZYZ => new Float4(0f, z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZY_ => new Float4(0f, z, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZZX => new Float4(0f, z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZZY => new Float4(0f, z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZZZ => new Float4(0f, z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZZ_ => new Float4(0f, z, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Z_X => new Float4(0f, z, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Z_Y => new Float4(0f, z, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Z_Z => new Float4(0f, z, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Z__ => new Float4(0f, z, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __XX => new Float4(0f, 0f, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __XY => new Float4(0f, 0f, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __XZ => new Float4(0f, 0f, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __X_ => new Float4(0f, 0f, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __YX => new Float4(0f, 0f, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __YY => new Float4(0f, 0f, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __YZ => new Float4(0f, 0f, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __Y_ => new Float4(0f, 0f, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __ZX => new Float4(0f, 0f, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __ZY => new Float4(0f, 0f, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __ZZ => new Float4(0f, 0f, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __Z_ => new Float4(0f, 0f, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ___X => new Float4(0f, 0f, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ___Y => new Float4(0f, 0f, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ___Z => new Float4(0f, 0f, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ____ => new Float4(0f, 0f, 0f, 0f);

#endregion

#region Swizzled3

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXX => new Float3(x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXY => new Float3(x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXZ => new Float3(x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XX_ => new Float3(x, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYX => new Float3(x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYY => new Float3(x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYZ => new Float3(x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XY_ => new Float3(x, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZX => new Float3(x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZY => new Float3(x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZZ => new Float3(x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZ_ => new Float3(x, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X_X => new Float3(x, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X_Y => new Float3(x, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X_Z => new Float3(x, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X__ => new Float3(x, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXX => new Float3(y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXY => new Float3(y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXZ => new Float3(y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YX_ => new Float3(y, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYX => new Float3(y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYY => new Float3(y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYZ => new Float3(y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YY_ => new Float3(y, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZX => new Float3(y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZY => new Float3(y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZZ => new Float3(y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZ_ => new Float3(y, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y_X => new Float3(y, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y_Y => new Float3(y, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y_Z => new Float3(y, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y__ => new Float3(y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXX => new Float3(z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXY => new Float3(z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXZ => new Float3(z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZX_ => new Float3(z, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYX => new Float3(z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYY => new Float3(z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYZ => new Float3(z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZY_ => new Float3(z, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZX => new Float3(z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZY => new Float3(z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZZ => new Float3(z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZ_ => new Float3(z, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Z_X => new Float3(z, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Z_Y => new Float3(z, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Z_Z => new Float3(z, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Z__ => new Float3(z, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _XX => new Float3(0f, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _XY => new Float3(0f, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _XZ => new Float3(0f, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _X_ => new Float3(0f, x, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _YX => new Float3(0f, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _YY => new Float3(0f, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _YZ => new Float3(0f, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _Y_ => new Float3(0f, y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _ZX => new Float3(0f, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _ZY => new Float3(0f, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _ZZ => new Float3(0f, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _Z_ => new Float3(0f, z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 __X => new Float3(0f, 0f, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 __Y => new Float3(0f, 0f, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 __Z => new Float3(0f, 0f, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ___ => new Float3(0f, 0f, 0f);

#endregion

#region Swizzled2

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XX => new Float2(x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XY => new Float2(x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XZ => new Float2(x, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YX => new Float2(y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YY => new Float2(y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YZ => new Float2(y, z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZX => new Float2(z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZY => new Float2(z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZZ => new Float2(z, z);

#endregion

#region Static Properties

		public static readonly Float3 right = new Float3(1f, 0f, 0f);
		public static readonly Float3 left = new Float3(-1f, 0f, 0f);

		public static readonly Float3 up = new Float3(0f, 1f, 0f);
		public static readonly Float3 down = new Float3(0f, -1f, 0f);

		public static readonly Float3 forward = new Float3(0f, 0f, 1f);
		public static readonly Float3 backward = new Float3(0f, 0f, -1f);

		public static readonly Float3 zero = new Float3(0f, 0f, 0f);

		public static readonly Float3 one = new Float3(1f, 1f, 1f);
		public static readonly Float3 negativeOne = new Float3(-1f, -1f, -1f);

		public static readonly Float3 half = new Float3(0.5f, 0.5f, 0.5f);
		public static readonly Float3 negativeHalf = new Float3(-0.5f, -0.5f, -0.5f);

		public static readonly Float3 maxValue = new Float3(float.MaxValue, float.MaxValue, float.MaxValue);
		public static readonly Float3 minValue = new Float3(float.MinValue, float.MinValue, float.MinValue);

		public static readonly Float3 positiveInfinity = new Float3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
		public static readonly Float3 negativeInfinity = new Float3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

		public static readonly Float3 epsilon = new Float3(Scalars.Epsilon, Scalars.Epsilon, Scalars.Epsilon);
		public static readonly Float3 NaN = new Float3(float.NaN, float.NaN, float.NaN);

#endregion

#region Instance Properties

#region Scalar Returns

		public float Magnitude
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (float)MagnitudeDouble;
		}

		public double MagnitudeDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Sqrt(SquaredMagnitudeDouble);
		}

		public float SquaredMagnitude
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x * x + y * y + z * z;
		}

		public double SquaredMagnitudeDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)x * x + (double)y * y + (double)z * z;
		}

		public float Product
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x * y * z;
		}

		public double ProductDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)x * y * z;
		}

		public float ProductAbsoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs(x * y * z);
		}

		public double ProductAbsolutedDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs((double)x * y * z);
		}

		public float Sum
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x + y + z;
		}

		public double SumDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)x + y + z;
		}

		public float Average
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (float)AverageDouble;
		}

		public double AverageDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => ((double)x + y + z) / 3d;
		}

		public float MinComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x < y) return x < z ? x : z;
				return y < z ? y : z;
			}
		}

		public int MinIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x < y) return x < z ? 0 : 2;
				return y < z ? 1 : 2;
			}
		}

		public float MaxComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x > y) return x > z ? x : z;
				return y > z ? y : z;
			}
		}

		public int MaxIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x > y) return x > z ? 0 : 2;
				return y > z ? 1 : 2;
			}
		}

		public float this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
#if UNSAFE_CODE_ENABLED
				unsafe //This unsafe version can be 3.75 times faster (700ms vs 200ms) compiled in release mode when the if statement is omitted
				{
					if (index < 0 || 2 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
					fixed (Float3* pointer = &this) return ((float*)pointer)[index];
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

#region Float3 Returns

		public Float3 Absoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float3(Math.Abs(x), Math.Abs(y), Math.Abs(z));
		}

		public Int3 Signed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3(x.Sign(), y.Sign(), z.Sign());
		}

		public Float3 Normalized
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				double squared = SquaredMagnitudeDouble;
				if (squared.AlmostEquals()) return zero;

				return 1f / (float)Math.Sqrt(squared) * this;
			}
		}

		public Float3 Squared
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float3(x * x, y * y, z * z);
		}

		public Float3 Sorted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x < y)
				{
					if (y < z) return XYZ;
					if (x < z) return XZY;

					return ZXY;
				}

				if (x < z) return YXZ;
				if (y < z) return YZX;

				return ZYX;
			}
		}

		public Float3 SortedReversed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (x > y)
				{
					if (y > z) return XYZ;
					if (x > z) return XZY;

					return ZXY;
				}

				if (x > z) return YXZ;
				if (y > z) return YZX;

				return ZYX;
			}
		}

		public Int3 Floored
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3((int)Math.Floor(x), (int)Math.Floor(y), (int)Math.Floor(z));
		}

		public Float3 FlooredFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float3((float)Math.Floor(x), (float)Math.Floor(y), (float)Math.Floor(z));
		}

		public Int3 Ceiled
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3((int)Math.Ceiling(x), (int)Math.Ceiling(y), (int)Math.Ceiling(z));
		}

		public Float3 CeiledFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float3((float)Math.Ceiling(x), (float)Math.Ceiling(y), (float)Math.Ceiling(z));
		}

		public Int3 Rounded
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3((int)Math.Round(x), (int)Math.Round(y), (int)Math.Round(z));
		}

		public Float3 RoundedFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float3((float)Math.Round(x), (float)Math.Round(y), (float)Math.Round(z));
		}

#endregion

#endregion

#region Methods

#region Instance

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Cross(in Float3 other) => new Float3
		(
			(float)((double)y * other.z - (double)z * other.y),
			(float)((double)z * other.x - (double)x * other.z),
			(float)((double)x * other.y - (double)y * other.x)
		);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Dot(in Float3 other) => x * other.x + y * other.y + z * other.z;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DotDouble(in Float3 other) => (double)x * other.x + (double)y * other.y + (double)z * other.z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Angle(in Float3 other)
		{
			double squared = SquaredMagnitudeDouble * other.SquaredMagnitudeDouble;
			if (squared.AlmostEquals()) return 0f;

			double magnitude = Math.Sqrt(squared);
			if (magnitude.AlmostEquals()) return 0f;

			return (float)Math.Acos(DotDouble(other) / magnitude) * Scalars.RadianToDegree;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SignedAngle(in Float3 other, in Float3 normal)
		{
			float angle = Angle(other);
			return Cross(other).Dot(normal) < 0f ? -angle : angle;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Distance(in Float3 other) => (other - this).Magnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DistanceDouble(in Float3 other) => (other - this).MagnitudeDouble;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SquaredDistance(in Float3 other) => (other - this).SquaredMagnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double SquaredDistanceDouble(in Float3 other) => (other - this).SquaredMagnitudeDouble;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Min(in Float3 other) => new Float3(Math.Min(x, other.x), Math.Min(y, other.y), Math.Min(z, other.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Max(in Float3 other) => new Float3(Math.Max(x, other.x), Math.Max(y, other.y), Math.Max(z, other.z));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Clamp(in Float3 min, in Float3 max) => new Float3(x.Clamp(min.x, max.x), y.Clamp(min.y, max.y), z.Clamp(min.z, max.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Clamp(float min = 0f, float max = 1f) => new Float3(x.Clamp(min, max), y.Clamp(min, max), z.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3 ClampMagnitude(float max)
		{
			double squared = SquaredMagnitudeDouble;
			if (squared <= (double)max * max) return this;

			float scale = max / (float)Math.Sqrt(squared);
			return new Float3(x * scale, y * scale, z * scale);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Power(in Float3 value) => new Float3((float)Math.Pow(x, value.x), (float)Math.Pow(y, value.y), (float)Math.Pow(z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Power(float value) => new Float3((float)Math.Pow(x, value), (float)Math.Pow(y, value), (float)Math.Pow(z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Lerp(in Float3 other, in Float3 value) => new Float3(Scalars.Lerp(x, other.x, value.x), Scalars.Lerp(y, other.y, value.y), Scalars.Lerp(z, other.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Lerp(in Float3 other, float value) => new Float3(Scalars.Lerp(x, other.x, value), Scalars.Lerp(y, other.y, value), Scalars.Lerp(z, other.z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 InverseLerp(in Float3 other, in Float3 value) => new Float3(Scalars.InverseLerp(x, other.x, value.x), Scalars.InverseLerp(y, other.y, value.y), Scalars.InverseLerp(z, other.z, value.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 InverseLerp(in Float3 other, float value) => new Float3(Scalars.InverseLerp(x, other.x, value), Scalars.InverseLerp(y, other.y, value), Scalars.InverseLerp(z, other.z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Repeat(in Float3 length) => new Float3(x.Repeat(length.x), y.Repeat(length.y), z.Repeat(length.z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Repeat(float length) => new Float3(x.Repeat(length), y.Repeat(length), z.Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXY(float degree) => CreateXY(XY.Rotate(degree), z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXY(float degree, Float2 pivot) => CreateXY(XY.Rotate(degree, pivot), z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXY(float degree, in Float3 pivot) => CreateXY(XY.Rotate(degree, pivot.XY), z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXZ(float degree) => CreateXZ(XZ.Rotate(degree), y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXZ(float degree, Float2 pivot) => CreateXZ(XZ.Rotate(degree, pivot), y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXZ(float degree, in Float3 pivot) => CreateXZ(XZ.Rotate(degree, pivot.XZ), y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateYZ(float degree) => CreateYZ(YZ.Rotate(degree), x);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateYZ(float degree, Float2 pivot) => CreateYZ(YZ.Rotate(degree, pivot), x);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateYZ(float degree, in Float3 pivot) => CreateYZ(YZ.Rotate(degree, pivot.YZ), x);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3 Damp(in Float3 target, ref Float3 velocity, in Float3 smoothTime, float deltaTime)
		{
			float velocityX = velocity.x;
			float velocityY = velocity.y;
			float velocityZ = velocity.z;

			Float3 result = new Float3
			(
				Scalars.Damp(x, target.x, ref velocityX, smoothTime.x, deltaTime),
				Scalars.Damp(y, target.y, ref velocityY, smoothTime.y, deltaTime),
				Scalars.Damp(z, target.z, ref velocityZ, smoothTime.z, deltaTime)
			);

			velocity = new Float3(velocityX, velocityY, velocityZ);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3 Damp(in Float3 target, ref Float3 velocity, float smoothTime, float deltaTime) => Damp(target, ref velocity, (Float3)smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Reflect(in Float3 normal) => -2f * Dot(normal) * normal + this;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Project(in Float3 normal) => normal * (Dot(normal) / normal.SquaredMagnitude);

#endregion

#region Static

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Cross(in Float3 first, in Float3 second) => first.Cross(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Dot(in Float3 value, in Float3 other) => value.Dot(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double DotDouble(in Float3 value, in Float3 other) => value.DotDouble(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Angle(in Float3 first, in Float3 second) => first.Angle(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float SignedAngle(in Float3 first, in Float3 second, in Float3 normal) => first.SignedAngle(second, normal);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Distance(in Float3 value, in Float3 other) => value.Distance(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double DistanceDouble(in Float3 value, in Float3 other) => value.DistanceDouble(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float SquaredDistance(in Float3 value, in Float3 other) => value.SquaredDistance(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double SquaredDistanceDouble(in Float3 value, in Float3 other) => value.SquaredDistanceDouble(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Min(in Float3 value, in Float3 other) => value.Min(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Max(in Float3 value, in Float3 other) => value.Max(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Clamp(in Float3 value, in Float3 min, in Float3 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Clamp(in Float3 value, float min = 0f, float max = 1f) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 ClampMagnitude(in Float3 value, float max) => value.ClampMagnitude(max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Power(in Float3 value, in Float3 power) => value.Power(power);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Power(in Float3 value, float power) => value.Power(power);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Lerp(in Float3 first, in Float3 second, in Float3 value) => first.Lerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Lerp(in Float3 first, in Float3 second, float value) => first.Lerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 InverseLerp(in Float3 first, in Float3 second, in Float3 value) => first.InverseLerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 InverseLerp(in Float3 first, in Float3 second, float value) => first.InverseLerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Repeat(in Float3 value, in Float3 length) => value.Repeat(length);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Repeat(in Float3 value, float length) => value.Repeat(length);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXY(in Float3 value, float degree) => value.RotateXY(degree);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXY(in Float3 value, float degree, Float2 pivot) => value.RotateXY(degree, pivot);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXY(in Float3 value, float degree, in Float3 pivot) => value.RotateXY(degree, pivot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXZ(in Float3 value, float degree) => value.RotateXZ(degree);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXZ(in Float3 value, float degree, Float2 pivot) => value.RotateXZ(degree, pivot);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateXZ(in Float3 value, float degree, in Float3 pivot) => value.RotateXZ(degree, pivot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateYZ(in Float3 value, float degree) => value.RotateYZ(degree);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateYZ(in Float3 value, float degree, Float2 pivot) => value.RotateYZ(degree, pivot);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 RotateYZ(in Float3 value, float degree, in Float3 pivot) => value.RotateYZ(degree, pivot);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Damp(in Float3 current, in Float3 target, ref Float3 velocity, in Float3 smoothTime, float deltaTime) => current.Damp(target, ref velocity, smoothTime, deltaTime);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Damp(in Float3 current, in Float3 target, ref Float3 velocity, float smoothTime, float deltaTime) => current.Damp(target, ref velocity, smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Reflect(in Float3 value, in Float3 normal) => value.Reflect(normal);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 Project(in Float3 value, in Float3 normal) => value.Project(normal);

#endregion

#region Create

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Float3 Create(int index, float value)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 2 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Float3 result = default;
				((float*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Float3(value, 0f, 0f);
				case 1:  return new Float3(0f, value, 0f);
				case 2:  return new Float3(0f, 0f, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Float3 Create(int index, float value, float other)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 2 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Float3 result = new Float3(other, other, other);
				((float*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Float3(value, other, other);
				case 1:  return new Float3(other, value, other);
				case 2:  return new Float3(other, other, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float3 CreateX(float value, float other = 0f) => new Float3(value, other, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float3 CreateY(float value, float other = 0f) => new Float3(other, value, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float3 CreateZ(float value, float other = 0f) => new Float3(other, other, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float3 CreateXY(Float2 value, float other = 0f) => new Float3(value.x, value.y, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float3 CreateYZ(Float2 value, float other = 0f) => new Float3(other, value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float3 CreateXZ(Float2 value, float other = 0f) => new Float3(value.x, other, value.y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3 Replace(int index, float value)
		{
#if UNSAFE_CODE_ENABLED
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

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceX(float value) => new Float3(value, y, z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceY(float value) => new Float3(x, value, z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceZ(float value) => new Float3(x, y, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceXY(Float2 value) => new Float3(value.x, value.y, z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceYZ(Float2 value) => new Float3(x, value.x, value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceXZ(Float2 value) => new Float3(value.x, y, value.y);

#if CODEHELPERS_UNITY
		public UnityEngine.Vector3 U() => this;
#endif

#endregion

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator +(in Float3 first, in Float3 second) => new Float3(first.x + second.x, first.y + second.y, first.z + second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator -(in Float3 first, in Float3 second) => new Float3(first.x - second.x, first.y - second.y, first.z - second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(in Float3 first, in Float3 second) => new Float3(first.x * second.x, first.y * second.y, first.z * second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(in Float3 first, in Float3 second) => new Float3(first.x / second.x, first.y / second.y, first.z / second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(in Float3 first, float second) => new Float3(first.x * second, first.y * second, first.z * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(in Float3 first, float second) => new Float3(first.x / second, first.y / second, first.z / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(float first, in Float3 second) => new Float3(first * second.x, first * second.y, first * second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(float first, in Float3 second) => new Float3(first / second.x, first / second.y, first / second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator +(in Float3 value) => value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator -(in Float3 value) => new Float3(-value.x, -value.y, -value.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(in Float3 first, in Float3 second) => new Float3(first.x % second.x, first.y % second.y, first.z % second.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(in Float3 first, float second) => new Float3(first.x % second, first.y % second, first.z % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(float first, in Float3 second) => new Float3(first % second.x, first % second.y, first % second.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(in Float3 first, in Float3 second) => first.EqualsFast(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(in Float3 first, in Float3 second) => !first.EqualsFast(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(in Float3 first, in Float3 second) => first.x < second.x && first.y < second.y && first.z < second.z;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(in Float3 first, in Float3 second) => first.x > second.x && first.y > second.y && first.z > second.z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(in Float3 first, in Float3 second) => first.x <= second.x && first.y <= second.y && first.z <= second.z;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(in Float3 first, in Float3 second) => first.x >= second.x && first.y >= second.y && first.z >= second.z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool EqualsExact(in Float3 other) => x == other.x && y == other.y && z == other.z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Float3 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Float3 other) => EqualsFast(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool EqualsFast(in Float3 other) => x.AlmostEquals(other.x) && y.AlmostEquals(other.y) && z.AlmostEquals(other.z);

		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = x.GetHashCode();
				hashCode = (hashCode * 397) ^ y.GetHashCode();
				hashCode = (hashCode * 397) ^ z.GetHashCode();
				return hashCode;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(in Float3 value) => new Int2((int)value.x, (int)value.y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(in Float3 value) => new Int3((int)value.x, (int)value.y, (int)value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(in Float3 value) => new Int4((int)value.x, (int)value.y, (int)value.z, 0);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(in Float3 value) => value.XY;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(float value) => new Float3(value, value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(in Float3 value) => new Float4(value.x, value.y, value.z, 0f);

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float3(UnityEngine.Vector3 value) => new Float3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector3(in Float3 value) => new UnityEngine.Vector3(value.x, value.y, value.z);
#endif

#endregion

		public override string ToString() => $"({x}, {y}, {z})";

		public string ToString(string format) => ToString(format, CultureInfo.InvariantCulture);
		public string ToString(string format, IFormatProvider provider) => $"({x.ToString(format, provider)}, {y.ToString(format, provider)}, {z.ToString(format, provider)})";

#region Enumerations

		/// <summary>
		/// Returns an enumerable that can be put into a foreach loop.
		/// Yields the two components of this vector in a series.
		/// </summary>
		public SeriesEnumerable Series() => new SeriesEnumerable(this);

		public readonly struct SeriesEnumerable : IEnumerable<float>
		{
			public SeriesEnumerable(in Float3 value) => enumerator = new Enumerator(value);

			readonly Enumerator enumerator;

			public Enumerator GetEnumerator() => enumerator;

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			IEnumerator<float> IEnumerable<float>.GetEnumerator() => GetEnumerator();

			public struct Enumerator : IEnumerator<float>
			{
				public Enumerator(in Float3 source)
				{
					this.source = source;
					index = -1;
				}

				readonly Float3 source;
				int index;

				object IEnumerator.Current => Current;
				public float Current => source[index];

				public bool MoveNext() => index++ < 2;
				public void Reset() => index = -1;

				public void Dispose() { }
			}
		}

#endregion

	}
}