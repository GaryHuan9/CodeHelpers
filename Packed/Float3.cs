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
	public readonly struct Float3 : IEquatable<Float3>, IFormattable
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public float X { get; }
		public float Y { get; }
		public float Z { get; }

#region Properties

#region Static

		public static Float3 Right => new Float3(1f, 0f, 0f);
		public static Float3 Left => new Float3(-1f, 0f, 0f);

		public static Float3 Up => new Float3(0f, 1f, 0f);
		public static Float3 Down => new Float3(0f, -1f, 0f);

		public static Float3 Forward => new Float3(0f, 0f, 1f);
		public static Float3 Backward => new Float3(0f, 0f, -1f);

		public static Float3 Zero => new Float3(0f, 0f, 0f);

		public static Float3 One => new Float3(1f, 1f, 1f);
		public static Float3 NegativeOne => new Float3(-1f, -1f, -1f);

		public static Float3 Half => new Float3(0.5f, 0.5f, 0.5f);
		public static Float3 NegativeHalf => new Float3(-0.5f, -0.5f, -0.5f);

		public static Float3 MaxValue => new Float3(float.MaxValue, float.MaxValue, float.MaxValue);
		public static Float3 MinValue => new Float3(float.MinValue, float.MinValue, float.MinValue);

		public static Float3 PositiveInfinity => new Float3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
		public static Float3 NegativeInfinity => new Float3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

		public static Float3 Epsilon => new Float3(Scalars.Epsilon, Scalars.Epsilon, Scalars.Epsilon);
		public static Float3 NaN => new Float3(float.NaN, float.NaN, float.NaN);

#endregion

#region Instance

#region Swizzled

#region Four

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXX => new Float4(X, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXY => new Float4(X, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXZ => new Float4(X, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXX_ => new Float4(X, X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYX => new Float4(X, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYY => new Float4(X, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYZ => new Float4(X, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXY_ => new Float4(X, X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZX => new Float4(X, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZY => new Float4(X, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZZ => new Float4(X, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZ_ => new Float4(X, X, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX_X => new Float4(X, X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX_Y => new Float4(X, X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX_Z => new Float4(X, X, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX__ => new Float4(X, X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXX => new Float4(X, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXY => new Float4(X, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXZ => new Float4(X, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYX_ => new Float4(X, Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYX => new Float4(X, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYY => new Float4(X, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYZ => new Float4(X, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYY_ => new Float4(X, Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZX => new Float4(X, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZY => new Float4(X, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZZ => new Float4(X, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZ_ => new Float4(X, Y, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY_X => new Float4(X, Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY_Y => new Float4(X, Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY_Z => new Float4(X, Y, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY__ => new Float4(X, Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZXX => new Float4(X, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZXY => new Float4(X, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZXZ => new Float4(X, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZX_ => new Float4(X, Z, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZYX => new Float4(X, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZYY => new Float4(X, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZYZ => new Float4(X, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZY_ => new Float4(X, Z, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZX => new Float4(X, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZY => new Float4(X, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZZ => new Float4(X, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZ_ => new Float4(X, Z, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZ_X => new Float4(X, Z, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZ_Y => new Float4(X, Z, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZ_Z => new Float4(X, Z, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZ__ => new Float4(X, Z, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_XX => new Float4(X, 0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_XY => new Float4(X, 0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_XZ => new Float4(X, 0f, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_X_ => new Float4(X, 0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_YX => new Float4(X, 0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_YY => new Float4(X, 0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_YZ => new Float4(X, 0f, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_Y_ => new Float4(X, 0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_ZX => new Float4(X, 0f, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_ZY => new Float4(X, 0f, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_ZZ => new Float4(X, 0f, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_Z_ => new Float4(X, 0f, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X__X => new Float4(X, 0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X__Y => new Float4(X, 0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X__Z => new Float4(X, 0f, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X___ => new Float4(X, 0f, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXX => new Float4(Y, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXY => new Float4(Y, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXZ => new Float4(Y, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXX_ => new Float4(Y, X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYX => new Float4(Y, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYY => new Float4(Y, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYZ => new Float4(Y, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXY_ => new Float4(Y, X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZX => new Float4(Y, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZY => new Float4(Y, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZZ => new Float4(Y, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZ_ => new Float4(Y, X, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX_X => new Float4(Y, X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX_Y => new Float4(Y, X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX_Z => new Float4(Y, X, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX__ => new Float4(Y, X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXX => new Float4(Y, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXY => new Float4(Y, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXZ => new Float4(Y, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYX_ => new Float4(Y, Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYX => new Float4(Y, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYY => new Float4(Y, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYZ => new Float4(Y, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYY_ => new Float4(Y, Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZX => new Float4(Y, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZY => new Float4(Y, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZZ => new Float4(Y, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZ_ => new Float4(Y, Y, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY_X => new Float4(Y, Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY_Y => new Float4(Y, Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY_Z => new Float4(Y, Y, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY__ => new Float4(Y, Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZXX => new Float4(Y, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZXY => new Float4(Y, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZXZ => new Float4(Y, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZX_ => new Float4(Y, Z, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZYX => new Float4(Y, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZYY => new Float4(Y, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZYZ => new Float4(Y, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZY_ => new Float4(Y, Z, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZX => new Float4(Y, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZY => new Float4(Y, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZZ => new Float4(Y, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZ_ => new Float4(Y, Z, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZ_X => new Float4(Y, Z, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZ_Y => new Float4(Y, Z, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZ_Z => new Float4(Y, Z, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZ__ => new Float4(Y, Z, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_XX => new Float4(Y, 0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_XY => new Float4(Y, 0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_XZ => new Float4(Y, 0f, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_X_ => new Float4(Y, 0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_YX => new Float4(Y, 0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_YY => new Float4(Y, 0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_YZ => new Float4(Y, 0f, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_Y_ => new Float4(Y, 0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_ZX => new Float4(Y, 0f, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_ZY => new Float4(Y, 0f, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_ZZ => new Float4(Y, 0f, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_Z_ => new Float4(Y, 0f, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y__X => new Float4(Y, 0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y__Y => new Float4(Y, 0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y__Z => new Float4(Y, 0f, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y___ => new Float4(Y, 0f, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXXX => new Float4(Z, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXXY => new Float4(Z, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXXZ => new Float4(Z, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXX_ => new Float4(Z, X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXYX => new Float4(Z, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXYY => new Float4(Z, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXYZ => new Float4(Z, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXY_ => new Float4(Z, X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZX => new Float4(Z, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZY => new Float4(Z, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZZ => new Float4(Z, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZ_ => new Float4(Z, X, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZX_X => new Float4(Z, X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZX_Y => new Float4(Z, X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZX_Z => new Float4(Z, X, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZX__ => new Float4(Z, X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYXX => new Float4(Z, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYXY => new Float4(Z, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYXZ => new Float4(Z, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYX_ => new Float4(Z, Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYYX => new Float4(Z, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYYY => new Float4(Z, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYYZ => new Float4(Z, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYY_ => new Float4(Z, Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZX => new Float4(Z, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZY => new Float4(Z, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZZ => new Float4(Z, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZ_ => new Float4(Z, Y, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZY_X => new Float4(Z, Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZY_Y => new Float4(Z, Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZY_Z => new Float4(Z, Y, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZY__ => new Float4(Z, Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZXX => new Float4(Z, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZXY => new Float4(Z, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZXZ => new Float4(Z, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZX_ => new Float4(Z, Z, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZYX => new Float4(Z, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZYY => new Float4(Z, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZYZ => new Float4(Z, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZY_ => new Float4(Z, Z, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZX => new Float4(Z, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZY => new Float4(Z, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZZ => new Float4(Z, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZ_ => new Float4(Z, Z, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZ_X => new Float4(Z, Z, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZ_Y => new Float4(Z, Z, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZ_Z => new Float4(Z, Z, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZ__ => new Float4(Z, Z, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_XX => new Float4(Z, 0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_XY => new Float4(Z, 0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_XZ => new Float4(Z, 0f, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_X_ => new Float4(Z, 0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_YX => new Float4(Z, 0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_YY => new Float4(Z, 0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_YZ => new Float4(Z, 0f, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_Y_ => new Float4(Z, 0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_ZX => new Float4(Z, 0f, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_ZY => new Float4(Z, 0f, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_ZZ => new Float4(Z, 0f, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_Z_ => new Float4(Z, 0f, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z__X => new Float4(Z, 0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z__Y => new Float4(Z, 0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z__Z => new Float4(Z, 0f, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z___ => new Float4(Z, 0f, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XXX => new Float4(0f, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XXY => new Float4(0f, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XXZ => new Float4(0f, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XX_ => new Float4(0f, X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XYX => new Float4(0f, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XYY => new Float4(0f, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XYZ => new Float4(0f, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XY_ => new Float4(0f, X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XZX => new Float4(0f, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XZY => new Float4(0f, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XZZ => new Float4(0f, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XZ_ => new Float4(0f, X, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X_X => new Float4(0f, X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X_Y => new Float4(0f, X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X_Z => new Float4(0f, X, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X__ => new Float4(0f, X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YXX => new Float4(0f, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YXY => new Float4(0f, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YXZ => new Float4(0f, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YX_ => new Float4(0f, Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YYX => new Float4(0f, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YYY => new Float4(0f, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YYZ => new Float4(0f, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YY_ => new Float4(0f, Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YZX => new Float4(0f, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YZY => new Float4(0f, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YZZ => new Float4(0f, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YZ_ => new Float4(0f, Y, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y_X => new Float4(0f, Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y_Y => new Float4(0f, Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y_Z => new Float4(0f, Y, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y__ => new Float4(0f, Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZXX => new Float4(0f, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZXY => new Float4(0f, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZXZ => new Float4(0f, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZX_ => new Float4(0f, Z, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZYX => new Float4(0f, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZYY => new Float4(0f, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZYZ => new Float4(0f, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZY_ => new Float4(0f, Z, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZZX => new Float4(0f, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZZY => new Float4(0f, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZZZ => new Float4(0f, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZZ_ => new Float4(0f, Z, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Z_X => new Float4(0f, Z, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Z_Y => new Float4(0f, Z, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Z_Z => new Float4(0f, Z, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Z__ => new Float4(0f, Z, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __XX => new Float4(0f, 0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __XY => new Float4(0f, 0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __XZ => new Float4(0f, 0f, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __X_ => new Float4(0f, 0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __YX => new Float4(0f, 0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __YY => new Float4(0f, 0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __YZ => new Float4(0f, 0f, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __Y_ => new Float4(0f, 0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __ZX => new Float4(0f, 0f, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __ZY => new Float4(0f, 0f, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __ZZ => new Float4(0f, 0f, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __Z_ => new Float4(0f, 0f, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ___X => new Float4(0f, 0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ___Y => new Float4(0f, 0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ___Z => new Float4(0f, 0f, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ____ => new Float4(0f, 0f, 0f, 0f);

#endregion

#region Three

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXX => new Float3(X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXY => new Float3(X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXZ => new Float3(X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XX_ => new Float3(X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYX => new Float3(X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYY => new Float3(X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYZ => new Float3(X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XY_ => new Float3(X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZX => new Float3(X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZY => new Float3(X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZZ => new Float3(X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZ_ => new Float3(X, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X_X => new Float3(X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X_Y => new Float3(X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X_Z => new Float3(X, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X__ => new Float3(X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXX => new Float3(Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXY => new Float3(Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXZ => new Float3(Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YX_ => new Float3(Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYX => new Float3(Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYY => new Float3(Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYZ => new Float3(Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YY_ => new Float3(Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZX => new Float3(Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZY => new Float3(Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZZ => new Float3(Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZ_ => new Float3(Y, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y_X => new Float3(Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y_Y => new Float3(Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y_Z => new Float3(Y, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y__ => new Float3(Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXX => new Float3(Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXY => new Float3(Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXZ => new Float3(Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZX_ => new Float3(Z, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYX => new Float3(Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYY => new Float3(Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYZ => new Float3(Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZY_ => new Float3(Z, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZX => new Float3(Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZY => new Float3(Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZZ => new Float3(Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZ_ => new Float3(Z, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Z_X => new Float3(Z, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Z_Y => new Float3(Z, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Z_Z => new Float3(Z, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Z__ => new Float3(Z, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _XX => new Float3(0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _XY => new Float3(0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _XZ => new Float3(0f, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _X_ => new Float3(0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _YX => new Float3(0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _YY => new Float3(0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _YZ => new Float3(0f, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _Y_ => new Float3(0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _ZX => new Float3(0f, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _ZY => new Float3(0f, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _ZZ => new Float3(0f, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _Z_ => new Float3(0f, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 __X => new Float3(0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 __Y => new Float3(0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 __Z => new Float3(0f, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ___ => new Float3(0f, 0f, 0f);

#endregion

#region Two

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XX => new Float2(X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XY => new Float2(X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XZ => new Float2(X, Z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YX => new Float2(Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YY => new Float2(Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YZ => new Float2(Y, Z);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZX => new Float2(Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZY => new Float2(Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZZ => new Float2(Z, Z);

#endregion

#endregion

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
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X * X + Y * Y + Z * Z;
		}

		public double SquaredMagnitudeDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)X * X + (double)Y * Y + (double)Z * Z;
		}

		public float Product
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X * Y * Z;
		}

		public double ProductDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)X * Y * Z;
		}

		public float ProductAbsoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs(X * Y * Z);
		}

		public double ProductAbsolutedDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs((double)X * Y * Z);
		}

		public float Sum
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X + Y + Z;
		}

		public double SumDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)X + Y + Z;
		}

		public float Average
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (float)AverageDouble;
		}

		public double AverageDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => ((double)X + Y + Z) / 3d;
		}

		public float MinComponent
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

		public float MaxComponent
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

		public float this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
#if CODE_HELPERS_UNSAFE
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
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float3(Math.Abs(X), Math.Abs(Y), Math.Abs(Z));
		}

		public Int3 Signed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3(X.Sign(), Y.Sign(), Z.Sign());
		}

		public Float3 Normalized
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				double squared = SquaredMagnitudeDouble;
				if (squared.AlmostEquals()) return Zero;

				return 1f / (float)Math.Sqrt(squared) * this;
			}
		}

		public Float3 Squared
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float3(X * X, Y * Y, Z * Z);
		}

		public Float3 Sorted
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

		public Float3 SortedReversed
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

		public Int3 Floored
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3((int)Math.Floor(X), (int)Math.Floor(Y), (int)Math.Floor(Z));
		}

		public Float3 FlooredFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float3((float)Math.Floor(X), (float)Math.Floor(Y), (float)Math.Floor(Z));
		}

		public Int3 Ceiled
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3((int)Math.Ceiling(X), (int)Math.Ceiling(Y), (int)Math.Ceiling(Z));
		}

		public Float3 CeiledFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float3((float)Math.Ceiling(X), (float)Math.Ceiling(Y), (float)Math.Ceiling(Z));
		}

		public Int3 Rounded
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int3((int)Math.Round(X), (int)Math.Round(Y), (int)Math.Round(Z));
		}

		public Float3 RoundedFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float3((float)Math.Round(X), (float)Math.Round(Y), (float)Math.Round(Z));
		}

#endregion

#endregion

#endregion

#region Methods

#region Instance

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Cross(in Float3 other) => new Float3
		(
			(float)((double)Y * other.Z - (double)Z * other.Y),
			(float)((double)Z * other.X - (double)X * other.Z),
			(float)((double)X * other.Y - (double)Y * other.X)
		);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Dot(in Float3 other) => X * other.X + Y * other.Y + Z * other.Z;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DotDouble(in Float3 other) => (double)X * other.X + (double)Y * other.Y + (double)Z * other.Z;

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

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Min(in Float3 other) => new Float3(Math.Min(X, other.X), Math.Min(Y, other.Y), Math.Min(Z, other.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Max(in Float3 other) => new Float3(Math.Max(X, other.X), Math.Max(Y, other.Y), Math.Max(Z, other.Z));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Clamp(in Float3 min, in Float3 max) => new Float3(X.Clamp(min.X, max.X), Y.Clamp(min.Y, max.Y), Z.Clamp(min.Z, max.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Clamp(float min = 0f, float max = 1f) => new Float3(X.Clamp(min, max), Y.Clamp(min, max), Z.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3 ClampMagnitude(float max)
		{
			double squared = SquaredMagnitudeDouble;
			if (squared <= (double)max * max) return this;

			float scale = max / (float)Math.Sqrt(squared);
			return new Float3(X * scale, Y * scale, Z * scale);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Power(in Float3 value) => new Float3((float)Math.Pow(X, value.X), (float)Math.Pow(Y, value.Y), (float)Math.Pow(Z, value.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Power(float value) => new Float3((float)Math.Pow(X, value), (float)Math.Pow(Y, value), (float)Math.Pow(Z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Lerp(in Float3 other, in Float3 value) => new Float3(Scalars.Lerp(X, other.X, value.X), Scalars.Lerp(Y, other.Y, value.Y), Scalars.Lerp(Z, other.Z, value.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Lerp(in Float3 other, float value) => new Float3(Scalars.Lerp(X, other.X, value), Scalars.Lerp(Y, other.Y, value), Scalars.Lerp(Z, other.Z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 InverseLerp(in Float3 other, in Float3 value) => new Float3(Scalars.InverseLerp(X, other.X, value.X), Scalars.InverseLerp(Y, other.Y, value.Y), Scalars.InverseLerp(Z, other.Z, value.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 InverseLerp(in Float3 other, float value) => new Float3(Scalars.InverseLerp(X, other.X, value), Scalars.InverseLerp(Y, other.Y, value), Scalars.InverseLerp(Z, other.Z, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Repeat(in Float3 length) => new Float3(X.Repeat(length.X), Y.Repeat(length.Y), Z.Repeat(length.Z));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Repeat(float length) => new Float3(X.Repeat(length), Y.Repeat(length), Z.Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXY(float degree) => CreateXY(XY.Rotate(degree), Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXY(float degree, Float2 pivot) => CreateXY(XY.Rotate(degree, pivot), Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXY(float degree, in Float3 pivot) => CreateXY(XY.Rotate(degree, pivot.XY), Z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXZ(float degree) => CreateXZ(XZ.Rotate(degree), Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXZ(float degree, Float2 pivot) => CreateXZ(XZ.Rotate(degree, pivot), Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateXZ(float degree, in Float3 pivot) => CreateXZ(XZ.Rotate(degree, pivot.XZ), Y);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateYZ(float degree) => CreateYZ(YZ.Rotate(degree), X);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateYZ(float degree, Float2 pivot) => CreateYZ(YZ.Rotate(degree, pivot), X);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 RotateYZ(float degree, in Float3 pivot) => CreateYZ(YZ.Rotate(degree, pivot.YZ), X);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3 Damp(in Float3 target, ref Float3 velocity, in Float3 smoothTime, float deltaTime)
		{
			float velocityX = velocity.X;
			float velocityY = velocity.Y;
			float velocityZ = velocity.Z;

			Float3 result = new Float3
			(
				X.Damp(target.X, ref velocityX, smoothTime.X, deltaTime),
				Y.Damp(target.Y, ref velocityY, smoothTime.Y, deltaTime),
				Z.Damp(target.Z, ref velocityZ, smoothTime.Z, deltaTime)
			);

			velocity = new Float3(velocityX, velocityY, velocityZ);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float3 Damp(in Float3 target, ref Float3 velocity, float smoothTime, float deltaTime) => Damp(target, ref velocity, (Float3)smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Reflect(in Float3 normal) => -2f * Dot(normal) * normal + this;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float3 Project(in Float3 normal) => normal * (Dot(normal) / normal.SquaredMagnitude);

		public override string ToString() => ToString(string.Empty);

		public string ToString(string format) => ToString(format, CultureInfo.InvariantCulture);
		public string ToString(string format, IFormatProvider provider) => $"({X.ToString(format, provider)}, {Y.ToString(format, provider)}, {Z.ToString(format, provider)})";

		// ReSharper disable CompareOfFloatsByEqualityOperator
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool EqualsExact(in Float3 other) => X == other.X && Y == other.Y && Z == other.Z;
		// ReSharper restore CompareOfFloatsByEqualityOperator

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Float3 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Float3 other) => EqualsFast(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool EqualsFast(in Float3 other) => X.AlmostEquals(other.X) && Y.AlmostEquals(other.Y) && Z.AlmostEquals(other.Z);

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
#if CODE_HELPERS_UNSAFE
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
#if CODE_HELPERS_UNSAFE
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

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float3 CreateXY(Float2 value, float other = 0f) => new Float3(value.X, value.Y, other);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float3 CreateYZ(Float2 value, float other = 0f) => new Float3(other, value.X, value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public static Float3 CreateXZ(Float2 value, float other = 0f) => new Float3(value.X, other, value.Y);

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

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceX(float value) => new Float3(value, Y, Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceY(float value) => new Float3(X, value, Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceZ(float value) => new Float3(X, Y, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceXY(Float2 value) => new Float3(value.X, value.Y, Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceYZ(Float2 value) => new Float3(X, value.X, value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining), EditorBrowsable(EditorBrowsableState.Never)] public Float3 ReplaceXZ(Float2 value) => new Float3(value.X, Y, value.Y);

#if CODE_HELPERS_UNITY
		public UnityEngine.Vector3 U() => this;
#endif

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator +(in Float3 first, in Float3 second) => new Float3(first.X + second.X, first.Y + second.Y, first.Z + second.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator -(in Float3 first, in Float3 second) => new Float3(first.X - second.X, first.Y - second.Y, first.Z - second.Z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(in Float3 first, in Float3 second) => new Float3(first.X * second.X, first.Y * second.Y, first.Z * second.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(in Float3 first, in Float3 second) => new Float3(first.X / second.X, first.Y / second.Y, first.Z / second.Z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(in Float3 first, float second) => new Float3(first.X * second, first.Y * second, first.Z * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(in Float3 first, float second) => new Float3(first.X / second, first.Y / second, first.Z / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator *(float first, in Float3 second) => new Float3(first * second.X, first * second.Y, first * second.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator /(float first, in Float3 second) => new Float3(first / second.X, first / second.Y, first / second.Z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator +(in Float3 value) => value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator -(in Float3 value) => new Float3(-value.X, -value.Y, -value.Z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(in Float3 first, in Float3 second) => new Float3(first.X % second.X, first.Y % second.Y, first.Z % second.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(in Float3 first, float second) => new Float3(first.X % second, first.Y % second, first.Z % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float3 operator %(float first, in Float3 second) => new Float3(first % second.X, first % second.Y, first % second.Z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(in Float3 first, in Float3 second) => first.EqualsFast(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(in Float3 first, in Float3 second) => !first.EqualsFast(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(in Float3 first, in Float3 second) => first.X < second.X && first.Y < second.Y && first.Z < second.Z;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(in Float3 first, in Float3 second) => first.X > second.X && first.Y > second.Y && first.Z > second.Z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(in Float3 first, in Float3 second) => first.X <= second.X && first.Y <= second.Y && first.Z <= second.Z;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(in Float3 first, in Float3 second) => first.X >= second.X && first.Y >= second.Y && first.Z >= second.Z;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int2(in Float3 value) => new Int2((int)value.X, (int)value.Y);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int3(in Float3 value) => new Int3((int)value.X, (int)value.Y, (int)value.Z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Int4(in Float3 value) => new Int4((int)value.X, (int)value.Y, (int)value.Z, 0);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float2(in Float3 value) => value.XY;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float3(float value) => new Float3(value, value, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(in Float3 value) => new Float4(value.X, value.Y, value.Z, 0f);

#if CODE_HELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float3(UnityEngine.Vector3 value) => new Float3(value.x, value.y, value.z);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector3(in Float3 value) => new UnityEngine.Vector3(value.X, value.Y, value.Z);
#endif

#endregion

#endregion

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