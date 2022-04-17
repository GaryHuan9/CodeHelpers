using System.ComponentModel;
using System.Diagnostics;

namespace CodeHelpers.Packed
{
	using EB = EditorBrowsableAttribute;
	using DB = DebuggerBrowsableAttribute;
	using EBS = EditorBrowsableState;
	using DBS = DebuggerBrowsableState;
	//
	using F2 = Float2;
	using F3 = Float3;
	using F4 = Float4;
	//
	using I2 = Int2;
	using I3 = Int3;
	using I4 = Int4;

	public partial struct Float2
	{

#region Four

		[EB(EBS.Never), DB(DBS.Never)] public F4 XXXX => new F4(X, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXXY => new F4(X, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXX_ => new F4(X, X, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XXYX => new F4(X, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXYY => new F4(X, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXY_ => new F4(X, X, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XX_X => new F4(X, X, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XX_Y => new F4(X, X, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XX__ => new F4(X, X, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XYXX => new F4(X, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYXY => new F4(X, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYX_ => new F4(X, Y, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XYYX => new F4(X, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYYY => new F4(X, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYY_ => new F4(X, Y, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XY_X => new F4(X, Y, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XY_Y => new F4(X, Y, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XY__ => new F4(X, Y, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 X_XX => new F4(X, 0f, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_XY => new F4(X, 0f, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_X_ => new F4(X, 0f, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 X_YX => new F4(X, 0f, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_YY => new F4(X, 0f, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_Y_ => new F4(X, 0f, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 X__X => new F4(X, 0f, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X__Y => new F4(X, 0f, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X___ => new F4(X, 0f, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YXXX => new F4(Y, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXXY => new F4(Y, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXX_ => new F4(Y, X, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YXYX => new F4(Y, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXYY => new F4(Y, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXY_ => new F4(Y, X, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YX_X => new F4(Y, X, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YX_Y => new F4(Y, X, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YX__ => new F4(Y, X, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YYXX => new F4(Y, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYXY => new F4(Y, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYX_ => new F4(Y, Y, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YYYX => new F4(Y, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYYY => new F4(Y, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYY_ => new F4(Y, Y, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YY_X => new F4(Y, Y, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YY_Y => new F4(Y, Y, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YY__ => new F4(Y, Y, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_XX => new F4(Y, 0f, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_XY => new F4(Y, 0f, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_X_ => new F4(Y, 0f, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_YX => new F4(Y, 0f, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_YY => new F4(Y, 0f, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_Y_ => new F4(Y, 0f, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Y__X => new F4(Y, 0f, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y__Y => new F4(Y, 0f, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y___ => new F4(Y, 0f, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _XXX => new F4(0f, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XXY => new F4(0f, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XX_ => new F4(0f, X, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _XYX => new F4(0f, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XYY => new F4(0f, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XY_ => new F4(0f, X, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _X_X => new F4(0f, X, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _X_Y => new F4(0f, X, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _X__ => new F4(0f, X, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _YXX => new F4(0f, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YXY => new F4(0f, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YX_ => new F4(0f, Y, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _YYX => new F4(0f, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YYY => new F4(0f, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YY_ => new F4(0f, Y, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _Y_X => new F4(0f, Y, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _Y_Y => new F4(0f, Y, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _Y__ => new F4(0f, Y, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 __XX => new F4(0f, 0f, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __XY => new F4(0f, 0f, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __X_ => new F4(0f, 0f, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 __YX => new F4(0f, 0f, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __YY => new F4(0f, 0f, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __Y_ => new F4(0f, 0f, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ___X => new F4(0f, 0f, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ___Y => new F4(0f, 0f, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ____ => new F4(0f, 0f, 0f, 0f);

#endregion

#region Three

		[EB(EBS.Never), DB(DBS.Never)] public F3 XXX => new F3(X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XXY => new F3(X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XX_ => new F3(X, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 XYX => new F3(X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XYY => new F3(X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XY_ => new F3(X, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 X_X => new F3(X, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 X_Y => new F3(X, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 X__ => new F3(X, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 YXX => new F3(Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YXY => new F3(Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YX_ => new F3(Y, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 YYX => new F3(Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YYY => new F3(Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YY_ => new F3(Y, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 Y_X => new F3(Y, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 Y_Y => new F3(Y, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 Y__ => new F3(Y, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 _XX => new F3(0f, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 _XY => new F3(0f, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 _X_ => new F3(0f, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 _YX => new F3(0f, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 _YY => new F3(0f, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 _Y_ => new F3(0f, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 __X => new F3(0f, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 __Y => new F3(0f, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ___ => new F3(0f, 0f, 0f);

#endregion

#region Two

		[EB(EBS.Never), DB(DBS.Never)] public F2 XX => new F2(X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F2 XY => new F2(X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F2 X_ => new F2(X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F2 YX => new F2(Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F2 YY => new F2(Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F2 Y_ => new F2(Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F2 _X => new F2(0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F2 _Y => new F2(0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F2 __ => new F2(0f, 0f);

#endregion

	}

	public partial struct Float3
	{

#region Four

		[EB(EBS.Never), DB(DBS.Never)] public F4 XXXX => new F4(X, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXXY => new F4(X, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXXZ => new F4(X, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXX_ => new F4(X, X, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XXYX => new F4(X, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXYY => new F4(X, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXYZ => new F4(X, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXY_ => new F4(X, X, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XXZX => new F4(X, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXZY => new F4(X, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXZZ => new F4(X, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXZ_ => new F4(X, X, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XX_X => new F4(X, X, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XX_Y => new F4(X, X, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XX_Z => new F4(X, X, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XX__ => new F4(X, X, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XYXX => new F4(X, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYXY => new F4(X, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYXZ => new F4(X, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYX_ => new F4(X, Y, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XYYX => new F4(X, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYYY => new F4(X, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYYZ => new F4(X, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYY_ => new F4(X, Y, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XYZX => new F4(X, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYZY => new F4(X, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYZZ => new F4(X, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYZ_ => new F4(X, Y, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XY_X => new F4(X, Y, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XY_Y => new F4(X, Y, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XY_Z => new F4(X, Y, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XY__ => new F4(X, Y, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XZXX => new F4(X, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZXY => new F4(X, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZXZ => new F4(X, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZX_ => new F4(X, Z, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XZYX => new F4(X, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZYY => new F4(X, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZYZ => new F4(X, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZY_ => new F4(X, Z, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XZZX => new F4(X, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZZY => new F4(X, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZZZ => new F4(X, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZZ_ => new F4(X, Z, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XZ_X => new F4(X, Z, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZ_Y => new F4(X, Z, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZ_Z => new F4(X, Z, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZ__ => new F4(X, Z, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 X_XX => new F4(X, 0f, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_XY => new F4(X, 0f, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_XZ => new F4(X, 0f, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_X_ => new F4(X, 0f, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 X_YX => new F4(X, 0f, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_YY => new F4(X, 0f, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_YZ => new F4(X, 0f, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_Y_ => new F4(X, 0f, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 X_ZX => new F4(X, 0f, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_ZY => new F4(X, 0f, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_ZZ => new F4(X, 0f, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_Z_ => new F4(X, 0f, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 X__X => new F4(X, 0f, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X__Y => new F4(X, 0f, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X__Z => new F4(X, 0f, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X___ => new F4(X, 0f, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YXXX => new F4(Y, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXXY => new F4(Y, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXXZ => new F4(Y, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXX_ => new F4(Y, X, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YXYX => new F4(Y, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXYY => new F4(Y, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXYZ => new F4(Y, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXY_ => new F4(Y, X, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YXZX => new F4(Y, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXZY => new F4(Y, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXZZ => new F4(Y, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXZ_ => new F4(Y, X, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YX_X => new F4(Y, X, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YX_Y => new F4(Y, X, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YX_Z => new F4(Y, X, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YX__ => new F4(Y, X, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YYXX => new F4(Y, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYXY => new F4(Y, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYXZ => new F4(Y, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYX_ => new F4(Y, Y, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YYYX => new F4(Y, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYYY => new F4(Y, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYYZ => new F4(Y, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYY_ => new F4(Y, Y, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YYZX => new F4(Y, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYZY => new F4(Y, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYZZ => new F4(Y, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYZ_ => new F4(Y, Y, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YY_X => new F4(Y, Y, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YY_Y => new F4(Y, Y, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YY_Z => new F4(Y, Y, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YY__ => new F4(Y, Y, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YZXX => new F4(Y, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZXY => new F4(Y, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZXZ => new F4(Y, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZX_ => new F4(Y, Z, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YZYX => new F4(Y, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZYY => new F4(Y, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZYZ => new F4(Y, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZY_ => new F4(Y, Z, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YZZX => new F4(Y, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZZY => new F4(Y, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZZZ => new F4(Y, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZZ_ => new F4(Y, Z, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YZ_X => new F4(Y, Z, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZ_Y => new F4(Y, Z, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZ_Z => new F4(Y, Z, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZ__ => new F4(Y, Z, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_XX => new F4(Y, 0f, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_XY => new F4(Y, 0f, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_XZ => new F4(Y, 0f, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_X_ => new F4(Y, 0f, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_YX => new F4(Y, 0f, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_YY => new F4(Y, 0f, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_YZ => new F4(Y, 0f, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_Y_ => new F4(Y, 0f, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_ZX => new F4(Y, 0f, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_ZY => new F4(Y, 0f, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_ZZ => new F4(Y, 0f, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_Z_ => new F4(Y, 0f, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Y__X => new F4(Y, 0f, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y__Y => new F4(Y, 0f, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y__Z => new F4(Y, 0f, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y___ => new F4(Y, 0f, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXXX => new F4(Z, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXXY => new F4(Z, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXXZ => new F4(Z, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXX_ => new F4(Z, X, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXYX => new F4(Z, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXYY => new F4(Z, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXYZ => new F4(Z, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXY_ => new F4(Z, X, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXZX => new F4(Z, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXZY => new F4(Z, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXZZ => new F4(Z, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXZ_ => new F4(Z, X, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZX_X => new F4(Z, X, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZX_Y => new F4(Z, X, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZX_Z => new F4(Z, X, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZX__ => new F4(Z, X, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYXX => new F4(Z, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYXY => new F4(Z, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYXZ => new F4(Z, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYX_ => new F4(Z, Y, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYYX => new F4(Z, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYYY => new F4(Z, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYYZ => new F4(Z, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYY_ => new F4(Z, Y, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYZX => new F4(Z, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYZY => new F4(Z, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYZZ => new F4(Z, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYZ_ => new F4(Z, Y, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZY_X => new F4(Z, Y, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZY_Y => new F4(Z, Y, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZY_Z => new F4(Z, Y, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZY__ => new F4(Z, Y, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZXX => new F4(Z, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZXY => new F4(Z, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZXZ => new F4(Z, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZX_ => new F4(Z, Z, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZYX => new F4(Z, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZYY => new F4(Z, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZYZ => new F4(Z, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZY_ => new F4(Z, Z, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZZX => new F4(Z, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZZY => new F4(Z, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZZZ => new F4(Z, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZZ_ => new F4(Z, Z, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZ_X => new F4(Z, Z, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZ_Y => new F4(Z, Z, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZ_Z => new F4(Z, Z, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZ__ => new F4(Z, Z, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_XX => new F4(Z, 0f, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_XY => new F4(Z, 0f, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_XZ => new F4(Z, 0f, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_X_ => new F4(Z, 0f, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_YX => new F4(Z, 0f, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_YY => new F4(Z, 0f, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_YZ => new F4(Z, 0f, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_Y_ => new F4(Z, 0f, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_ZX => new F4(Z, 0f, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_ZY => new F4(Z, 0f, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_ZZ => new F4(Z, 0f, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_Z_ => new F4(Z, 0f, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Z__X => new F4(Z, 0f, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z__Y => new F4(Z, 0f, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z__Z => new F4(Z, 0f, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z___ => new F4(Z, 0f, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _XXX => new F4(0f, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XXY => new F4(0f, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XXZ => new F4(0f, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XX_ => new F4(0f, X, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _XYX => new F4(0f, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XYY => new F4(0f, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XYZ => new F4(0f, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XY_ => new F4(0f, X, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _XZX => new F4(0f, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XZY => new F4(0f, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XZZ => new F4(0f, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XZ_ => new F4(0f, X, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _X_X => new F4(0f, X, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _X_Y => new F4(0f, X, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _X_Z => new F4(0f, X, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _X__ => new F4(0f, X, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _YXX => new F4(0f, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YXY => new F4(0f, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YXZ => new F4(0f, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YX_ => new F4(0f, Y, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _YYX => new F4(0f, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YYY => new F4(0f, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YYZ => new F4(0f, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YY_ => new F4(0f, Y, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _YZX => new F4(0f, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YZY => new F4(0f, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YZZ => new F4(0f, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YZ_ => new F4(0f, Y, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _Y_X => new F4(0f, Y, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _Y_Y => new F4(0f, Y, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _Y_Z => new F4(0f, Y, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _Y__ => new F4(0f, Y, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZXX => new F4(0f, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZXY => new F4(0f, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZXZ => new F4(0f, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZX_ => new F4(0f, Z, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZYX => new F4(0f, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZYY => new F4(0f, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZYZ => new F4(0f, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZY_ => new F4(0f, Z, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZZX => new F4(0f, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZZY => new F4(0f, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZZZ => new F4(0f, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZZ_ => new F4(0f, Z, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _Z_X => new F4(0f, Z, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _Z_Y => new F4(0f, Z, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _Z_Z => new F4(0f, Z, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _Z__ => new F4(0f, Z, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 __XX => new F4(0f, 0f, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __XY => new F4(0f, 0f, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __XZ => new F4(0f, 0f, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __X_ => new F4(0f, 0f, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 __YX => new F4(0f, 0f, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __YY => new F4(0f, 0f, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __YZ => new F4(0f, 0f, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __Y_ => new F4(0f, 0f, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 __ZX => new F4(0f, 0f, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __ZY => new F4(0f, 0f, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __ZZ => new F4(0f, 0f, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __Z_ => new F4(0f, 0f, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ___X => new F4(0f, 0f, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ___Y => new F4(0f, 0f, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ___Z => new F4(0f, 0f, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ____ => new F4(0f, 0f, 0f, 0f);

#endregion

#region Three

		[EB(EBS.Never), DB(DBS.Never)] public F3 XXX => new F3(X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XXY => new F3(X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XXZ => new F3(X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XX_ => new F3(X, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 XYX => new F3(X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XYY => new F3(X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XYZ => new F3(X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XY_ => new F3(X, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 XZX => new F3(X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XZY => new F3(X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XZZ => new F3(X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XZ_ => new F3(X, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 X_X => new F3(X, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 X_Y => new F3(X, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 X_Z => new F3(X, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 X__ => new F3(X, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 YXX => new F3(Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YXY => new F3(Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YXZ => new F3(Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YX_ => new F3(Y, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 YYX => new F3(Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YYY => new F3(Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YYZ => new F3(Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YY_ => new F3(Y, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 YZX => new F3(Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YZY => new F3(Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YZZ => new F3(Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YZ_ => new F3(Y, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 Y_X => new F3(Y, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 Y_Y => new F3(Y, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 Y_Z => new F3(Y, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 Y__ => new F3(Y, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 ZXX => new F3(Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZXY => new F3(Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZXZ => new F3(Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZX_ => new F3(Z, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 ZYX => new F3(Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZYY => new F3(Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZYZ => new F3(Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZY_ => new F3(Z, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 ZZX => new F3(Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZZY => new F3(Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZZZ => new F3(Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZZ_ => new F3(Z, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 Z_X => new F3(Z, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 Z_Y => new F3(Z, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 Z_Z => new F3(Z, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 Z__ => new F3(Z, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 _XX => new F3(0f, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 _XY => new F3(0f, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 _XZ => new F3(0f, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 _X_ => new F3(0f, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 _YX => new F3(0f, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 _YY => new F3(0f, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 _YZ => new F3(0f, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 _Y_ => new F3(0f, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 _ZX => new F3(0f, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 _ZY => new F3(0f, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 _ZZ => new F3(0f, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 _Z_ => new F3(0f, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F3 __X => new F3(0f, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 __Y => new F3(0f, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 __Z => new F3(0f, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ___ => new F3(0f, 0f, 0f);

#endregion

#region Two

		[EB(EBS.Never), DB(DBS.Never)] public F2 XX => new F2(X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F2 XY => new F2(X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F2 XZ => new F2(X, Z);

		[EB(EBS.Never), DB(DBS.Never)] public F2 YX => new F2(Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F2 YY => new F2(Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F2 YZ => new F2(Y, Z);

		[EB(EBS.Never), DB(DBS.Never)] public F2 ZX => new F2(Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F2 ZY => new F2(Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F2 ZZ => new F2(Z, Z);

#endregion

	}

	//OPTIMIZE
	public partial struct Float4
	{

#region Four

		[EB(EBS.Never), DB(DBS.Never)] public F4 XXXX => new F4(X, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXXY => new F4(X, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXXZ => new F4(X, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXXW => new F4(X, X, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXX_ => new F4(X, X, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XXYX => new F4(X, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXYY => new F4(X, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXYZ => new F4(X, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXYW => new F4(X, X, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXY_ => new F4(X, X, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XXZX => new F4(X, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXZY => new F4(X, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXZZ => new F4(X, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXZW => new F4(X, X, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXZ_ => new F4(X, X, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XXWX => new F4(X, X, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXWY => new F4(X, X, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXWZ => new F4(X, X, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXWW => new F4(X, X, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XXW_ => new F4(X, X, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XX_X => new F4(X, X, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XX_Y => new F4(X, X, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XX_Z => new F4(X, X, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XX_W => new F4(X, X, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XX__ => new F4(X, X, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XYXX => new F4(X, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYXY => new F4(X, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYXZ => new F4(X, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYXW => new F4(X, Y, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYX_ => new F4(X, Y, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XYYX => new F4(X, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYYY => new F4(X, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYYZ => new F4(X, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYYW => new F4(X, Y, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYY_ => new F4(X, Y, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XYZX => new F4(X, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYZY => new F4(X, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYZZ => new F4(X, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYZW => new F4(X, Y, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYZ_ => new F4(X, Y, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XYWX => new F4(X, Y, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYWY => new F4(X, Y, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYWZ => new F4(X, Y, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYWW => new F4(X, Y, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XYW_ => new F4(X, Y, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XY_X => new F4(X, Y, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XY_Y => new F4(X, Y, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XY_Z => new F4(X, Y, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XY_W => new F4(X, Y, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XY__ => new F4(X, Y, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XZXX => new F4(X, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZXY => new F4(X, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZXZ => new F4(X, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZXW => new F4(X, Z, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZX_ => new F4(X, Z, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XZYX => new F4(X, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZYY => new F4(X, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZYZ => new F4(X, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZYW => new F4(X, Z, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZY_ => new F4(X, Z, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XZZX => new F4(X, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZZY => new F4(X, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZZZ => new F4(X, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZZW => new F4(X, Z, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZZ_ => new F4(X, Z, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XZWX => new F4(X, Z, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZWY => new F4(X, Z, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZWZ => new F4(X, Z, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZWW => new F4(X, Z, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZW_ => new F4(X, Z, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XZ_X => new F4(X, Z, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZ_Y => new F4(X, Z, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZ_Z => new F4(X, Z, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZ_W => new F4(X, Z, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XZ__ => new F4(X, Z, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XWXX => new F4(X, W, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XWXY => new F4(X, W, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XWXZ => new F4(X, W, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XWXW => new F4(X, W, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XWX_ => new F4(X, W, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XWYX => new F4(X, W, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XWYY => new F4(X, W, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XWYZ => new F4(X, W, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XWYW => new F4(X, W, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XWY_ => new F4(X, W, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XWZX => new F4(X, W, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XWZY => new F4(X, W, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XWZZ => new F4(X, W, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XWZW => new F4(X, W, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XWZ_ => new F4(X, W, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XWWX => new F4(X, W, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XWWY => new F4(X, W, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XWWZ => new F4(X, W, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XWWW => new F4(X, W, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XWW_ => new F4(X, W, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 XW_X => new F4(X, W, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XW_Y => new F4(X, W, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XW_Z => new F4(X, W, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XW_W => new F4(X, W, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 XW__ => new F4(X, W, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 X_XX => new F4(X, 0f, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_XY => new F4(X, 0f, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_XZ => new F4(X, 0f, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_XW => new F4(X, 0f, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_X_ => new F4(X, 0f, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 X_YX => new F4(X, 0f, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_YY => new F4(X, 0f, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_YZ => new F4(X, 0f, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_YW => new F4(X, 0f, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_Y_ => new F4(X, 0f, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 X_ZX => new F4(X, 0f, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_ZY => new F4(X, 0f, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_ZZ => new F4(X, 0f, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_ZW => new F4(X, 0f, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_Z_ => new F4(X, 0f, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 X_WX => new F4(X, 0f, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_WY => new F4(X, 0f, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_WZ => new F4(X, 0f, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_WW => new F4(X, 0f, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X_W_ => new F4(X, 0f, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 X__X => new F4(X, 0f, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X__Y => new F4(X, 0f, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X__Z => new F4(X, 0f, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X__W => new F4(X, 0f, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 X___ => new F4(X, 0f, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YXXX => new F4(Y, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXXY => new F4(Y, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXXZ => new F4(Y, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXXW => new F4(Y, X, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXX_ => new F4(Y, X, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YXYX => new F4(Y, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXYY => new F4(Y, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXYZ => new F4(Y, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXYW => new F4(Y, X, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXY_ => new F4(Y, X, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YXZX => new F4(Y, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXZY => new F4(Y, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXZZ => new F4(Y, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXZW => new F4(Y, X, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXZ_ => new F4(Y, X, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YXWX => new F4(Y, X, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXWY => new F4(Y, X, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXWZ => new F4(Y, X, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXWW => new F4(Y, X, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YXW_ => new F4(Y, X, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YX_X => new F4(Y, X, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YX_Y => new F4(Y, X, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YX_Z => new F4(Y, X, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YX_W => new F4(Y, X, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YX__ => new F4(Y, X, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YYXX => new F4(Y, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYXY => new F4(Y, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYXZ => new F4(Y, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYXW => new F4(Y, Y, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYX_ => new F4(Y, Y, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YYYX => new F4(Y, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYYY => new F4(Y, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYYZ => new F4(Y, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYYW => new F4(Y, Y, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYY_ => new F4(Y, Y, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YYZX => new F4(Y, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYZY => new F4(Y, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYZZ => new F4(Y, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYZW => new F4(Y, Y, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYZ_ => new F4(Y, Y, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YYWX => new F4(Y, Y, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYWY => new F4(Y, Y, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYWZ => new F4(Y, Y, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYWW => new F4(Y, Y, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YYW_ => new F4(Y, Y, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YY_X => new F4(Y, Y, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YY_Y => new F4(Y, Y, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YY_Z => new F4(Y, Y, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YY_W => new F4(Y, Y, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YY__ => new F4(Y, Y, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YZXX => new F4(Y, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZXY => new F4(Y, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZXZ => new F4(Y, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZXW => new F4(Y, Z, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZX_ => new F4(Y, Z, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YZYX => new F4(Y, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZYY => new F4(Y, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZYZ => new F4(Y, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZYW => new F4(Y, Z, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZY_ => new F4(Y, Z, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YZZX => new F4(Y, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZZY => new F4(Y, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZZZ => new F4(Y, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZZW => new F4(Y, Z, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZZ_ => new F4(Y, Z, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YZWX => new F4(Y, Z, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZWY => new F4(Y, Z, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZWZ => new F4(Y, Z, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZWW => new F4(Y, Z, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZW_ => new F4(Y, Z, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YZ_X => new F4(Y, Z, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZ_Y => new F4(Y, Z, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZ_Z => new F4(Y, Z, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZ_W => new F4(Y, Z, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YZ__ => new F4(Y, Z, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YWXX => new F4(Y, W, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YWXY => new F4(Y, W, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YWXZ => new F4(Y, W, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YWXW => new F4(Y, W, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YWX_ => new F4(Y, W, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YWYX => new F4(Y, W, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YWYY => new F4(Y, W, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YWYZ => new F4(Y, W, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YWYW => new F4(Y, W, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YWY_ => new F4(Y, W, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YWZX => new F4(Y, W, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YWZY => new F4(Y, W, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YWZZ => new F4(Y, W, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YWZW => new F4(Y, W, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YWZ_ => new F4(Y, W, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YWWX => new F4(Y, W, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YWWY => new F4(Y, W, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YWWZ => new F4(Y, W, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YWWW => new F4(Y, W, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YWW_ => new F4(Y, W, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 YW_X => new F4(Y, W, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YW_Y => new F4(Y, W, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YW_Z => new F4(Y, W, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YW_W => new F4(Y, W, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 YW__ => new F4(Y, W, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_XX => new F4(Y, 0f, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_XY => new F4(Y, 0f, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_XZ => new F4(Y, 0f, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_XW => new F4(Y, 0f, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_X_ => new F4(Y, 0f, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_YX => new F4(Y, 0f, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_YY => new F4(Y, 0f, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_YZ => new F4(Y, 0f, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_YW => new F4(Y, 0f, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_Y_ => new F4(Y, 0f, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_ZX => new F4(Y, 0f, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_ZY => new F4(Y, 0f, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_ZZ => new F4(Y, 0f, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_ZW => new F4(Y, 0f, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_Z_ => new F4(Y, 0f, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_WX => new F4(Y, 0f, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_WY => new F4(Y, 0f, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_WZ => new F4(Y, 0f, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_WW => new F4(Y, 0f, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y_W_ => new F4(Y, 0f, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Y__X => new F4(Y, 0f, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y__Y => new F4(Y, 0f, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y__Z => new F4(Y, 0f, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y__W => new F4(Y, 0f, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Y___ => new F4(Y, 0f, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXXX => new F4(Z, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXXY => new F4(Z, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXXZ => new F4(Z, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXXW => new F4(Z, X, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXX_ => new F4(Z, X, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXYX => new F4(Z, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXYY => new F4(Z, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXYZ => new F4(Z, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXYW => new F4(Z, X, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXY_ => new F4(Z, X, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXZX => new F4(Z, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXZY => new F4(Z, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXZZ => new F4(Z, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXZW => new F4(Z, X, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXZ_ => new F4(Z, X, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXWX => new F4(Z, X, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXWY => new F4(Z, X, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXWZ => new F4(Z, X, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXWW => new F4(Z, X, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZXW_ => new F4(Z, X, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZX_X => new F4(Z, X, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZX_Y => new F4(Z, X, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZX_Z => new F4(Z, X, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZX_W => new F4(Z, X, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZX__ => new F4(Z, X, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYXX => new F4(Z, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYXY => new F4(Z, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYXZ => new F4(Z, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYXW => new F4(Z, Y, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYX_ => new F4(Z, Y, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYYX => new F4(Z, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYYY => new F4(Z, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYYZ => new F4(Z, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYYW => new F4(Z, Y, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYY_ => new F4(Z, Y, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYZX => new F4(Z, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYZY => new F4(Z, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYZZ => new F4(Z, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYZW => new F4(Z, Y, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYZ_ => new F4(Z, Y, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYWX => new F4(Z, Y, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYWY => new F4(Z, Y, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYWZ => new F4(Z, Y, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYWW => new F4(Z, Y, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZYW_ => new F4(Z, Y, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZY_X => new F4(Z, Y, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZY_Y => new F4(Z, Y, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZY_Z => new F4(Z, Y, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZY_W => new F4(Z, Y, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZY__ => new F4(Z, Y, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZXX => new F4(Z, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZXY => new F4(Z, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZXZ => new F4(Z, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZXW => new F4(Z, Z, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZX_ => new F4(Z, Z, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZYX => new F4(Z, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZYY => new F4(Z, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZYZ => new F4(Z, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZYW => new F4(Z, Z, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZY_ => new F4(Z, Z, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZZX => new F4(Z, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZZY => new F4(Z, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZZZ => new F4(Z, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZZW => new F4(Z, Z, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZZ_ => new F4(Z, Z, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZWX => new F4(Z, Z, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZWY => new F4(Z, Z, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZWZ => new F4(Z, Z, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZWW => new F4(Z, Z, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZW_ => new F4(Z, Z, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZ_X => new F4(Z, Z, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZ_Y => new F4(Z, Z, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZ_Z => new F4(Z, Z, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZ_W => new F4(Z, Z, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZZ__ => new F4(Z, Z, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWXX => new F4(Z, W, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWXY => new F4(Z, W, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWXZ => new F4(Z, W, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWXW => new F4(Z, W, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWX_ => new F4(Z, W, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWYX => new F4(Z, W, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWYY => new F4(Z, W, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWYZ => new F4(Z, W, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWYW => new F4(Z, W, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWY_ => new F4(Z, W, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWZX => new F4(Z, W, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWZY => new F4(Z, W, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWZZ => new F4(Z, W, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWZW => new F4(Z, W, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWZ_ => new F4(Z, W, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWWX => new F4(Z, W, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWWY => new F4(Z, W, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWWZ => new F4(Z, W, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWWW => new F4(Z, W, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZWW_ => new F4(Z, W, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ZW_X => new F4(Z, W, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZW_Y => new F4(Z, W, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZW_Z => new F4(Z, W, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZW_W => new F4(Z, W, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ZW__ => new F4(Z, W, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_XX => new F4(Z, 0f, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_XY => new F4(Z, 0f, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_XZ => new F4(Z, 0f, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_XW => new F4(Z, 0f, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_X_ => new F4(Z, 0f, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_YX => new F4(Z, 0f, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_YY => new F4(Z, 0f, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_YZ => new F4(Z, 0f, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_YW => new F4(Z, 0f, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_Y_ => new F4(Z, 0f, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_ZX => new F4(Z, 0f, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_ZY => new F4(Z, 0f, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_ZZ => new F4(Z, 0f, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_ZW => new F4(Z, 0f, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_Z_ => new F4(Z, 0f, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_WX => new F4(Z, 0f, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_WY => new F4(Z, 0f, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_WZ => new F4(Z, 0f, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_WW => new F4(Z, 0f, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z_W_ => new F4(Z, 0f, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 Z__X => new F4(Z, 0f, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z__Y => new F4(Z, 0f, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z__Z => new F4(Z, 0f, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z__W => new F4(Z, 0f, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 Z___ => new F4(Z, 0f, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WXXX => new F4(W, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WXXY => new F4(W, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WXXZ => new F4(W, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WXXW => new F4(W, X, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WXX_ => new F4(W, X, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WXYX => new F4(W, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WXYY => new F4(W, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WXYZ => new F4(W, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WXYW => new F4(W, X, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WXY_ => new F4(W, X, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WXZX => new F4(W, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WXZY => new F4(W, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WXZZ => new F4(W, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WXZW => new F4(W, X, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WXZ_ => new F4(W, X, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WXWX => new F4(W, X, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WXWY => new F4(W, X, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WXWZ => new F4(W, X, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WXWW => new F4(W, X, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WXW_ => new F4(W, X, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WX_X => new F4(W, X, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WX_Y => new F4(W, X, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WX_Z => new F4(W, X, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WX_W => new F4(W, X, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WX__ => new F4(W, X, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WYXX => new F4(W, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WYXY => new F4(W, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WYXZ => new F4(W, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WYXW => new F4(W, Y, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WYX_ => new F4(W, Y, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WYYX => new F4(W, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WYYY => new F4(W, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WYYZ => new F4(W, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WYYW => new F4(W, Y, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WYY_ => new F4(W, Y, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WYZX => new F4(W, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WYZY => new F4(W, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WYZZ => new F4(W, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WYZW => new F4(W, Y, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WYZ_ => new F4(W, Y, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WYWX => new F4(W, Y, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WYWY => new F4(W, Y, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WYWZ => new F4(W, Y, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WYWW => new F4(W, Y, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WYW_ => new F4(W, Y, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WY_X => new F4(W, Y, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WY_Y => new F4(W, Y, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WY_Z => new F4(W, Y, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WY_W => new F4(W, Y, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WY__ => new F4(W, Y, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WZXX => new F4(W, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZXY => new F4(W, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZXZ => new F4(W, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZXW => new F4(W, Z, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZX_ => new F4(W, Z, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WZYX => new F4(W, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZYY => new F4(W, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZYZ => new F4(W, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZYW => new F4(W, Z, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZY_ => new F4(W, Z, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WZZX => new F4(W, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZZY => new F4(W, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZZZ => new F4(W, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZZW => new F4(W, Z, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZZ_ => new F4(W, Z, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WZWX => new F4(W, Z, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZWY => new F4(W, Z, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZWZ => new F4(W, Z, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZWW => new F4(W, Z, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZW_ => new F4(W, Z, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WZ_X => new F4(W, Z, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZ_Y => new F4(W, Z, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZ_Z => new F4(W, Z, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZ_W => new F4(W, Z, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WZ__ => new F4(W, Z, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WWXX => new F4(W, W, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WWXY => new F4(W, W, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WWXZ => new F4(W, W, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WWXW => new F4(W, W, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WWX_ => new F4(W, W, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WWYX => new F4(W, W, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WWYY => new F4(W, W, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WWYZ => new F4(W, W, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WWYW => new F4(W, W, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WWY_ => new F4(W, W, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WWZX => new F4(W, W, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WWZY => new F4(W, W, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WWZZ => new F4(W, W, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WWZW => new F4(W, W, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WWZ_ => new F4(W, W, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WWWX => new F4(W, W, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WWWY => new F4(W, W, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WWWZ => new F4(W, W, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WWWW => new F4(W, W, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WWW_ => new F4(W, W, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 WW_X => new F4(W, W, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WW_Y => new F4(W, W, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WW_Z => new F4(W, W, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WW_W => new F4(W, W, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 WW__ => new F4(W, W, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 W_XX => new F4(W, 0f, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W_XY => new F4(W, 0f, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W_XZ => new F4(W, 0f, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W_XW => new F4(W, 0f, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W_X_ => new F4(W, 0f, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 W_YX => new F4(W, 0f, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W_YY => new F4(W, 0f, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W_YZ => new F4(W, 0f, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W_YW => new F4(W, 0f, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W_Y_ => new F4(W, 0f, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 W_ZX => new F4(W, 0f, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W_ZY => new F4(W, 0f, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W_ZZ => new F4(W, 0f, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W_ZW => new F4(W, 0f, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W_Z_ => new F4(W, 0f, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 W_WX => new F4(W, 0f, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W_WY => new F4(W, 0f, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W_WZ => new F4(W, 0f, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W_WW => new F4(W, 0f, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W_W_ => new F4(W, 0f, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 W__X => new F4(W, 0f, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W__Y => new F4(W, 0f, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W__Z => new F4(W, 0f, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W__W => new F4(W, 0f, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 W___ => new F4(W, 0f, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _XXX => new F4(0f, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XXY => new F4(0f, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XXZ => new F4(0f, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XXW => new F4(0f, X, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XX_ => new F4(0f, X, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _XYX => new F4(0f, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XYY => new F4(0f, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XYZ => new F4(0f, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XYW => new F4(0f, X, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XY_ => new F4(0f, X, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _XZX => new F4(0f, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XZY => new F4(0f, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XZZ => new F4(0f, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XZW => new F4(0f, X, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XZ_ => new F4(0f, X, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _XWX => new F4(0f, X, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XWY => new F4(0f, X, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XWZ => new F4(0f, X, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XWW => new F4(0f, X, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _XW_ => new F4(0f, X, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _X_X => new F4(0f, X, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _X_Y => new F4(0f, X, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _X_Z => new F4(0f, X, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _X_W => new F4(0f, X, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _X__ => new F4(0f, X, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _YXX => new F4(0f, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YXY => new F4(0f, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YXZ => new F4(0f, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YXW => new F4(0f, Y, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YX_ => new F4(0f, Y, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _YYX => new F4(0f, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YYY => new F4(0f, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YYZ => new F4(0f, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YYW => new F4(0f, Y, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YY_ => new F4(0f, Y, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _YZX => new F4(0f, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YZY => new F4(0f, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YZZ => new F4(0f, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YZW => new F4(0f, Y, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YZ_ => new F4(0f, Y, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _YWX => new F4(0f, Y, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YWY => new F4(0f, Y, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YWZ => new F4(0f, Y, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YWW => new F4(0f, Y, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _YW_ => new F4(0f, Y, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _Y_X => new F4(0f, Y, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _Y_Y => new F4(0f, Y, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _Y_Z => new F4(0f, Y, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _Y_W => new F4(0f, Y, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _Y__ => new F4(0f, Y, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZXX => new F4(0f, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZXY => new F4(0f, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZXZ => new F4(0f, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZXW => new F4(0f, Z, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZX_ => new F4(0f, Z, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZYX => new F4(0f, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZYY => new F4(0f, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZYZ => new F4(0f, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZYW => new F4(0f, Z, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZY_ => new F4(0f, Z, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZZX => new F4(0f, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZZY => new F4(0f, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZZZ => new F4(0f, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZZW => new F4(0f, Z, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZZ_ => new F4(0f, Z, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZWX => new F4(0f, Z, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZWY => new F4(0f, Z, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZWZ => new F4(0f, Z, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZWW => new F4(0f, Z, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _ZW_ => new F4(0f, Z, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _Z_X => new F4(0f, Z, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _Z_Y => new F4(0f, Z, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _Z_Z => new F4(0f, Z, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _Z_W => new F4(0f, Z, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _Z__ => new F4(0f, Z, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _WXX => new F4(0f, W, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _WXY => new F4(0f, W, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _WXZ => new F4(0f, W, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _WXW => new F4(0f, W, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _WX_ => new F4(0f, W, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _WYX => new F4(0f, W, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _WYY => new F4(0f, W, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _WYZ => new F4(0f, W, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _WYW => new F4(0f, W, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _WY_ => new F4(0f, W, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _WZX => new F4(0f, W, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _WZY => new F4(0f, W, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _WZZ => new F4(0f, W, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _WZW => new F4(0f, W, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _WZ_ => new F4(0f, W, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _WWX => new F4(0f, W, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _WWY => new F4(0f, W, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _WWZ => new F4(0f, W, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _WWW => new F4(0f, W, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _WW_ => new F4(0f, W, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 _W_X => new F4(0f, W, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _W_Y => new F4(0f, W, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _W_Z => new F4(0f, W, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _W_W => new F4(0f, W, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 _W__ => new F4(0f, W, 0f, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 __XX => new F4(0f, 0f, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __XY => new F4(0f, 0f, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __XZ => new F4(0f, 0f, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __XW => new F4(0f, 0f, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __X_ => new F4(0f, 0f, X, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 __YX => new F4(0f, 0f, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __YY => new F4(0f, 0f, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __YZ => new F4(0f, 0f, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __YW => new F4(0f, 0f, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __Y_ => new F4(0f, 0f, Y, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 __ZX => new F4(0f, 0f, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __ZY => new F4(0f, 0f, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __ZZ => new F4(0f, 0f, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __ZW => new F4(0f, 0f, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __Z_ => new F4(0f, 0f, Z, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 __WX => new F4(0f, 0f, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __WY => new F4(0f, 0f, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __WZ => new F4(0f, 0f, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __WW => new F4(0f, 0f, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 __W_ => new F4(0f, 0f, W, 0f);

		[EB(EBS.Never), DB(DBS.Never)] public F4 ___X => new F4(0f, 0f, 0f, X);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ___Y => new F4(0f, 0f, 0f, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ___Z => new F4(0f, 0f, 0f, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ___W => new F4(0f, 0f, 0f, W);
		[EB(EBS.Never), DB(DBS.Never)] public F4 ____ => new F4(0f, 0f, 0f, 0f);

#endregion

#region Three

		[EB(EBS.Never), DB(DBS.Never)] public F3 XXX => new F3(X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XXY => new F3(X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XXZ => new F3(X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XXW => new F3(X, X, W);

		[EB(EBS.Never), DB(DBS.Never)] public F3 XYX => new F3(X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XYY => new F3(X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XYZ => new F3(X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XYW => new F3(X, Y, W);

		[EB(EBS.Never), DB(DBS.Never)] public F3 XZX => new F3(X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XZY => new F3(X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XZZ => new F3(X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XZW => new F3(X, Z, W);

		[EB(EBS.Never), DB(DBS.Never)] public F3 XWX => new F3(X, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XWY => new F3(X, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XWZ => new F3(X, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 XWW => new F3(X, W, W);

		[EB(EBS.Never), DB(DBS.Never)] public F3 YXX => new F3(Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YXY => new F3(Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YXZ => new F3(Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YXW => new F3(Y, X, W);

		[EB(EBS.Never), DB(DBS.Never)] public F3 YYX => new F3(Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YYY => new F3(Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YYZ => new F3(Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YYW => new F3(Y, Y, W);

		[EB(EBS.Never), DB(DBS.Never)] public F3 YZX => new F3(Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YZY => new F3(Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YZZ => new F3(Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YZW => new F3(Y, Z, W);

		[EB(EBS.Never), DB(DBS.Never)] public F3 YWX => new F3(Y, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YWY => new F3(Y, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YWZ => new F3(Y, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 YWW => new F3(Y, W, W);

		[EB(EBS.Never), DB(DBS.Never)] public F3 ZXX => new F3(Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZXY => new F3(Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZXZ => new F3(Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZXW => new F3(Z, X, W);

		[EB(EBS.Never), DB(DBS.Never)] public F3 ZYX => new F3(Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZYY => new F3(Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZYZ => new F3(Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZYW => new F3(Z, Y, W);

		[EB(EBS.Never), DB(DBS.Never)] public F3 ZZX => new F3(Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZZY => new F3(Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZZZ => new F3(Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZZW => new F3(Z, Z, W);

		[EB(EBS.Never), DB(DBS.Never)] public F3 ZWX => new F3(Z, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZWY => new F3(Z, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZWZ => new F3(Z, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 ZWW => new F3(Z, W, W);

		[EB(EBS.Never), DB(DBS.Never)] public F3 WXX => new F3(W, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 WXY => new F3(W, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 WXZ => new F3(W, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 WXW => new F3(W, X, W);

		[EB(EBS.Never), DB(DBS.Never)] public F3 WYX => new F3(W, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 WYY => new F3(W, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 WYZ => new F3(W, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 WYW => new F3(W, Y, W);

		[EB(EBS.Never), DB(DBS.Never)] public F3 WZX => new F3(W, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 WZY => new F3(W, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 WZZ => new F3(W, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 WZW => new F3(W, Z, W);

		[EB(EBS.Never), DB(DBS.Never)] public F3 WWX => new F3(W, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F3 WWY => new F3(W, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F3 WWZ => new F3(W, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F3 WWW => new F3(W, W, W);

#endregion

#region Two

		[EB(EBS.Never), DB(DBS.Never)] public F2 XX => new F2(X, X);
		[EB(EBS.Never), DB(DBS.Never)] public F2 XY => new F2(X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F2 XZ => new F2(X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F2 XW => new F2(X, W);

		[EB(EBS.Never), DB(DBS.Never)] public F2 YX => new F2(Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public F2 YY => new F2(Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F2 YZ => new F2(Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F2 YW => new F2(Y, W);

		[EB(EBS.Never), DB(DBS.Never)] public F2 ZX => new F2(Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public F2 ZY => new F2(Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F2 ZZ => new F2(Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F2 ZW => new F2(Z, W);

		[EB(EBS.Never), DB(DBS.Never)] public F2 WX => new F2(W, X);
		[EB(EBS.Never), DB(DBS.Never)] public F2 WY => new F2(W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public F2 WZ => new F2(W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public F2 WW => new F2(W, W);

#endregion

	}

	public partial struct Int2
	{

#region Four

		[EB(EBS.Never), DB(DBS.Never)] public I4 XXXX => new I4(X, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXXY => new I4(X, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXX_ => new I4(X, X, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XXYX => new I4(X, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXYY => new I4(X, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXY_ => new I4(X, X, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XX_X => new I4(X, X, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XX_Y => new I4(X, X, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XX__ => new I4(X, X, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XYXX => new I4(X, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYXY => new I4(X, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYX_ => new I4(X, Y, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XYYX => new I4(X, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYYY => new I4(X, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYY_ => new I4(X, Y, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XY_X => new I4(X, Y, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XY_Y => new I4(X, Y, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XY__ => new I4(X, Y, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 X_XX => new I4(X, 0, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_XY => new I4(X, 0, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_X_ => new I4(X, 0, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 X_YX => new I4(X, 0, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_YY => new I4(X, 0, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_Y_ => new I4(X, 0, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 X__X => new I4(X, 0, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X__Y => new I4(X, 0, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X___ => new I4(X, 0, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YXXX => new I4(Y, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXXY => new I4(Y, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXX_ => new I4(Y, X, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YXYX => new I4(Y, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXYY => new I4(Y, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXY_ => new I4(Y, X, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YX_X => new I4(Y, X, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YX_Y => new I4(Y, X, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YX__ => new I4(Y, X, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YYXX => new I4(Y, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYXY => new I4(Y, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYX_ => new I4(Y, Y, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YYYX => new I4(Y, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYYY => new I4(Y, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYY_ => new I4(Y, Y, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YY_X => new I4(Y, Y, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YY_Y => new I4(Y, Y, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YY__ => new I4(Y, Y, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_XX => new I4(Y, 0, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_XY => new I4(Y, 0, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_X_ => new I4(Y, 0, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_YX => new I4(Y, 0, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_YY => new I4(Y, 0, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_Y_ => new I4(Y, 0, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Y__X => new I4(Y, 0, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y__Y => new I4(Y, 0, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y___ => new I4(Y, 0, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _XXX => new I4(0, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XXY => new I4(0, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XX_ => new I4(0, X, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _XYX => new I4(0, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XYY => new I4(0, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XY_ => new I4(0, X, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _X_X => new I4(0, X, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _X_Y => new I4(0, X, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _X__ => new I4(0, X, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _YXX => new I4(0, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YXY => new I4(0, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YX_ => new I4(0, Y, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _YYX => new I4(0, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YYY => new I4(0, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YY_ => new I4(0, Y, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _Y_X => new I4(0, Y, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _Y_Y => new I4(0, Y, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _Y__ => new I4(0, Y, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 __XX => new I4(0, 0, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __XY => new I4(0, 0, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __X_ => new I4(0, 0, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 __YX => new I4(0, 0, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __YY => new I4(0, 0, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __Y_ => new I4(0, 0, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ___X => new I4(0, 0, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ___Y => new I4(0, 0, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ____ => new I4(0, 0, 0, 0);

#endregion

#region Three

		[EB(EBS.Never), DB(DBS.Never)] public I3 XXX => new I3(X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XXY => new I3(X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XX_ => new I3(X, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 XYX => new I3(X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XYY => new I3(X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XY_ => new I3(X, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 X_X => new I3(X, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 X_Y => new I3(X, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 X__ => new I3(X, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 YXX => new I3(Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YXY => new I3(Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YX_ => new I3(Y, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 YYX => new I3(Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YYY => new I3(Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YY_ => new I3(Y, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 Y_X => new I3(Y, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 Y_Y => new I3(Y, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 Y__ => new I3(Y, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 _XX => new I3(0, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 _XY => new I3(0, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 _X_ => new I3(0, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 _YX => new I3(0, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 _YY => new I3(0, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 _Y_ => new I3(0, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 __X => new I3(0, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 __Y => new I3(0, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ___ => new I3(0, 0, 0);

#endregion

#region Two

		[EB(EBS.Never), DB(DBS.Never)] public I2 XX => new I2(X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I2 XY => new I2(X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I2 X_ => new I2(X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I2 YX => new I2(Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I2 YY => new I2(Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I2 Y_ => new I2(Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I2 _X => new I2(0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I2 _Y => new I2(0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I2 __ => new I2(0, 0);

#endregion

	}

	public partial struct Int3
	{

#region Four

		[EB(EBS.Never), DB(DBS.Never)] public I4 XXXX => new I4(X, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXXY => new I4(X, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXXZ => new I4(X, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXX_ => new I4(X, X, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XXYX => new I4(X, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXYY => new I4(X, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXYZ => new I4(X, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXY_ => new I4(X, X, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XXZX => new I4(X, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXZY => new I4(X, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXZZ => new I4(X, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXZ_ => new I4(X, X, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XX_X => new I4(X, X, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XX_Y => new I4(X, X, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XX_Z => new I4(X, X, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XX__ => new I4(X, X, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XYXX => new I4(X, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYXY => new I4(X, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYXZ => new I4(X, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYX_ => new I4(X, Y, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XYYX => new I4(X, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYYY => new I4(X, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYYZ => new I4(X, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYY_ => new I4(X, Y, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XYZX => new I4(X, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYZY => new I4(X, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYZZ => new I4(X, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYZ_ => new I4(X, Y, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XY_X => new I4(X, Y, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XY_Y => new I4(X, Y, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XY_Z => new I4(X, Y, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XY__ => new I4(X, Y, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XZXX => new I4(X, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZXY => new I4(X, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZXZ => new I4(X, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZX_ => new I4(X, Z, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XZYX => new I4(X, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZYY => new I4(X, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZYZ => new I4(X, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZY_ => new I4(X, Z, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XZZX => new I4(X, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZZY => new I4(X, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZZZ => new I4(X, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZZ_ => new I4(X, Z, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XZ_X => new I4(X, Z, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZ_Y => new I4(X, Z, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZ_Z => new I4(X, Z, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZ__ => new I4(X, Z, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 X_XX => new I4(X, 0, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_XY => new I4(X, 0, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_XZ => new I4(X, 0, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_X_ => new I4(X, 0, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 X_YX => new I4(X, 0, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_YY => new I4(X, 0, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_YZ => new I4(X, 0, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_Y_ => new I4(X, 0, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 X_ZX => new I4(X, 0, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_ZY => new I4(X, 0, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_ZZ => new I4(X, 0, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_Z_ => new I4(X, 0, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 X__X => new I4(X, 0, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X__Y => new I4(X, 0, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X__Z => new I4(X, 0, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X___ => new I4(X, 0, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YXXX => new I4(Y, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXXY => new I4(Y, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXXZ => new I4(Y, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXX_ => new I4(Y, X, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YXYX => new I4(Y, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXYY => new I4(Y, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXYZ => new I4(Y, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXY_ => new I4(Y, X, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YXZX => new I4(Y, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXZY => new I4(Y, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXZZ => new I4(Y, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXZ_ => new I4(Y, X, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YX_X => new I4(Y, X, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YX_Y => new I4(Y, X, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YX_Z => new I4(Y, X, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YX__ => new I4(Y, X, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YYXX => new I4(Y, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYXY => new I4(Y, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYXZ => new I4(Y, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYX_ => new I4(Y, Y, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YYYX => new I4(Y, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYYY => new I4(Y, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYYZ => new I4(Y, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYY_ => new I4(Y, Y, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YYZX => new I4(Y, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYZY => new I4(Y, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYZZ => new I4(Y, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYZ_ => new I4(Y, Y, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YY_X => new I4(Y, Y, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YY_Y => new I4(Y, Y, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YY_Z => new I4(Y, Y, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YY__ => new I4(Y, Y, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YZXX => new I4(Y, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZXY => new I4(Y, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZXZ => new I4(Y, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZX_ => new I4(Y, Z, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YZYX => new I4(Y, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZYY => new I4(Y, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZYZ => new I4(Y, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZY_ => new I4(Y, Z, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YZZX => new I4(Y, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZZY => new I4(Y, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZZZ => new I4(Y, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZZ_ => new I4(Y, Z, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YZ_X => new I4(Y, Z, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZ_Y => new I4(Y, Z, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZ_Z => new I4(Y, Z, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZ__ => new I4(Y, Z, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_XX => new I4(Y, 0, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_XY => new I4(Y, 0, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_XZ => new I4(Y, 0, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_X_ => new I4(Y, 0, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_YX => new I4(Y, 0, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_YY => new I4(Y, 0, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_YZ => new I4(Y, 0, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_Y_ => new I4(Y, 0, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_ZX => new I4(Y, 0, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_ZY => new I4(Y, 0, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_ZZ => new I4(Y, 0, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_Z_ => new I4(Y, 0, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Y__X => new I4(Y, 0, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y__Y => new I4(Y, 0, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y__Z => new I4(Y, 0, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y___ => new I4(Y, 0, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXXX => new I4(Z, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXXY => new I4(Z, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXXZ => new I4(Z, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXX_ => new I4(Z, X, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXYX => new I4(Z, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXYY => new I4(Z, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXYZ => new I4(Z, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXY_ => new I4(Z, X, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXZX => new I4(Z, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXZY => new I4(Z, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXZZ => new I4(Z, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXZ_ => new I4(Z, X, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZX_X => new I4(Z, X, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZX_Y => new I4(Z, X, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZX_Z => new I4(Z, X, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZX__ => new I4(Z, X, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYXX => new I4(Z, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYXY => new I4(Z, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYXZ => new I4(Z, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYX_ => new I4(Z, Y, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYYX => new I4(Z, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYYY => new I4(Z, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYYZ => new I4(Z, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYY_ => new I4(Z, Y, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYZX => new I4(Z, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYZY => new I4(Z, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYZZ => new I4(Z, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYZ_ => new I4(Z, Y, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZY_X => new I4(Z, Y, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZY_Y => new I4(Z, Y, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZY_Z => new I4(Z, Y, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZY__ => new I4(Z, Y, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZXX => new I4(Z, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZXY => new I4(Z, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZXZ => new I4(Z, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZX_ => new I4(Z, Z, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZYX => new I4(Z, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZYY => new I4(Z, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZYZ => new I4(Z, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZY_ => new I4(Z, Z, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZZX => new I4(Z, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZZY => new I4(Z, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZZZ => new I4(Z, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZZ_ => new I4(Z, Z, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZ_X => new I4(Z, Z, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZ_Y => new I4(Z, Z, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZ_Z => new I4(Z, Z, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZ__ => new I4(Z, Z, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_XX => new I4(Z, 0, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_XY => new I4(Z, 0, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_XZ => new I4(Z, 0, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_X_ => new I4(Z, 0, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_YX => new I4(Z, 0, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_YY => new I4(Z, 0, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_YZ => new I4(Z, 0, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_Y_ => new I4(Z, 0, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_ZX => new I4(Z, 0, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_ZY => new I4(Z, 0, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_ZZ => new I4(Z, 0, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_Z_ => new I4(Z, 0, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Z__X => new I4(Z, 0, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z__Y => new I4(Z, 0, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z__Z => new I4(Z, 0, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z___ => new I4(Z, 0, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _XXX => new I4(0, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XXY => new I4(0, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XXZ => new I4(0, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XX_ => new I4(0, X, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _XYX => new I4(0, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XYY => new I4(0, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XYZ => new I4(0, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XY_ => new I4(0, X, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _XZX => new I4(0, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XZY => new I4(0, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XZZ => new I4(0, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XZ_ => new I4(0, X, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _X_X => new I4(0, X, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _X_Y => new I4(0, X, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _X_Z => new I4(0, X, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _X__ => new I4(0, X, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _YXX => new I4(0, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YXY => new I4(0, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YXZ => new I4(0, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YX_ => new I4(0, Y, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _YYX => new I4(0, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YYY => new I4(0, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YYZ => new I4(0, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YY_ => new I4(0, Y, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _YZX => new I4(0, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YZY => new I4(0, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YZZ => new I4(0, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YZ_ => new I4(0, Y, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _Y_X => new I4(0, Y, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _Y_Y => new I4(0, Y, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _Y_Z => new I4(0, Y, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _Y__ => new I4(0, Y, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZXX => new I4(0, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZXY => new I4(0, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZXZ => new I4(0, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZX_ => new I4(0, Z, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZYX => new I4(0, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZYY => new I4(0, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZYZ => new I4(0, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZY_ => new I4(0, Z, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZZX => new I4(0, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZZY => new I4(0, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZZZ => new I4(0, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZZ_ => new I4(0, Z, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _Z_X => new I4(0, Z, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _Z_Y => new I4(0, Z, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _Z_Z => new I4(0, Z, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _Z__ => new I4(0, Z, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 __XX => new I4(0, 0, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __XY => new I4(0, 0, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __XZ => new I4(0, 0, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __X_ => new I4(0, 0, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 __YX => new I4(0, 0, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __YY => new I4(0, 0, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __YZ => new I4(0, 0, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __Y_ => new I4(0, 0, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 __ZX => new I4(0, 0, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __ZY => new I4(0, 0, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __ZZ => new I4(0, 0, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __Z_ => new I4(0, 0, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ___X => new I4(0, 0, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ___Y => new I4(0, 0, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ___Z => new I4(0, 0, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ____ => new I4(0, 0, 0, 0);

#endregion

#region Three

		[EB(EBS.Never), DB(DBS.Never)] public I3 XXX => new I3(X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XXY => new I3(X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XXZ => new I3(X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XX_ => new I3(X, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 XYX => new I3(X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XYY => new I3(X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XYZ => new I3(X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XY_ => new I3(X, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 XZX => new I3(X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XZY => new I3(X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XZZ => new I3(X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XZ_ => new I3(X, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 X_X => new I3(X, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 X_Y => new I3(X, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 X_Z => new I3(X, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 X__ => new I3(X, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 YXX => new I3(Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YXY => new I3(Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YXZ => new I3(Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YX_ => new I3(Y, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 YYX => new I3(Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YYY => new I3(Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YYZ => new I3(Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YY_ => new I3(Y, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 YZX => new I3(Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YZY => new I3(Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YZZ => new I3(Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YZ_ => new I3(Y, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 Y_X => new I3(Y, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 Y_Y => new I3(Y, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 Y_Z => new I3(Y, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 Y__ => new I3(Y, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 ZXX => new I3(Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZXY => new I3(Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZXZ => new I3(Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZX_ => new I3(Z, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 ZYX => new I3(Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZYY => new I3(Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZYZ => new I3(Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZY_ => new I3(Z, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 ZZX => new I3(Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZZY => new I3(Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZZZ => new I3(Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZZ_ => new I3(Z, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 Z_X => new I3(Z, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 Z_Y => new I3(Z, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 Z_Z => new I3(Z, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 Z__ => new I3(Z, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 _XX => new I3(0, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 _XY => new I3(0, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 _XZ => new I3(0, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 _X_ => new I3(0, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 _YX => new I3(0, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 _YY => new I3(0, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 _YZ => new I3(0, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 _Y_ => new I3(0, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 _ZX => new I3(0, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 _ZY => new I3(0, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 _ZZ => new I3(0, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 _Z_ => new I3(0, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I3 __X => new I3(0, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 __Y => new I3(0, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 __Z => new I3(0, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ___ => new I3(0, 0, 0);

#endregion

#region Two

		[EB(EBS.Never), DB(DBS.Never)] public I2 XX => new I2(X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I2 XY => new I2(X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I2 XZ => new I2(X, Z);

		[EB(EBS.Never), DB(DBS.Never)] public I2 YX => new I2(Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I2 YY => new I2(Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I2 YZ => new I2(Y, Z);

		[EB(EBS.Never), DB(DBS.Never)] public I2 ZX => new I2(Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I2 ZY => new I2(Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I2 ZZ => new I2(Z, Z);

#endregion

	}

	public partial struct Int4
	{

#region Four

		[EB(EBS.Never), DB(DBS.Never)] public I4 XXXX => new I4(X, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXXY => new I4(X, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXXZ => new I4(X, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXXW => new I4(X, X, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXX_ => new I4(X, X, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XXYX => new I4(X, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXYY => new I4(X, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXYZ => new I4(X, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXYW => new I4(X, X, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXY_ => new I4(X, X, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XXZX => new I4(X, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXZY => new I4(X, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXZZ => new I4(X, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXZW => new I4(X, X, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXZ_ => new I4(X, X, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XXWX => new I4(X, X, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXWY => new I4(X, X, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXWZ => new I4(X, X, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXWW => new I4(X, X, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XXW_ => new I4(X, X, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XX_X => new I4(X, X, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XX_Y => new I4(X, X, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XX_Z => new I4(X, X, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XX_W => new I4(X, X, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XX__ => new I4(X, X, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XYXX => new I4(X, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYXY => new I4(X, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYXZ => new I4(X, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYXW => new I4(X, Y, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYX_ => new I4(X, Y, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XYYX => new I4(X, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYYY => new I4(X, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYYZ => new I4(X, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYYW => new I4(X, Y, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYY_ => new I4(X, Y, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XYZX => new I4(X, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYZY => new I4(X, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYZZ => new I4(X, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYZW => new I4(X, Y, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYZ_ => new I4(X, Y, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XYWX => new I4(X, Y, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYWY => new I4(X, Y, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYWZ => new I4(X, Y, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYWW => new I4(X, Y, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XYW_ => new I4(X, Y, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XY_X => new I4(X, Y, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XY_Y => new I4(X, Y, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XY_Z => new I4(X, Y, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XY_W => new I4(X, Y, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XY__ => new I4(X, Y, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XZXX => new I4(X, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZXY => new I4(X, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZXZ => new I4(X, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZXW => new I4(X, Z, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZX_ => new I4(X, Z, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XZYX => new I4(X, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZYY => new I4(X, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZYZ => new I4(X, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZYW => new I4(X, Z, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZY_ => new I4(X, Z, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XZZX => new I4(X, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZZY => new I4(X, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZZZ => new I4(X, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZZW => new I4(X, Z, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZZ_ => new I4(X, Z, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XZWX => new I4(X, Z, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZWY => new I4(X, Z, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZWZ => new I4(X, Z, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZWW => new I4(X, Z, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZW_ => new I4(X, Z, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XZ_X => new I4(X, Z, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZ_Y => new I4(X, Z, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZ_Z => new I4(X, Z, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZ_W => new I4(X, Z, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XZ__ => new I4(X, Z, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XWXX => new I4(X, W, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XWXY => new I4(X, W, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XWXZ => new I4(X, W, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XWXW => new I4(X, W, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XWX_ => new I4(X, W, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XWYX => new I4(X, W, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XWYY => new I4(X, W, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XWYZ => new I4(X, W, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XWYW => new I4(X, W, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XWY_ => new I4(X, W, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XWZX => new I4(X, W, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XWZY => new I4(X, W, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XWZZ => new I4(X, W, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XWZW => new I4(X, W, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XWZ_ => new I4(X, W, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XWWX => new I4(X, W, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XWWY => new I4(X, W, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XWWZ => new I4(X, W, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XWWW => new I4(X, W, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XWW_ => new I4(X, W, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 XW_X => new I4(X, W, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XW_Y => new I4(X, W, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XW_Z => new I4(X, W, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XW_W => new I4(X, W, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 XW__ => new I4(X, W, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 X_XX => new I4(X, 0, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_XY => new I4(X, 0, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_XZ => new I4(X, 0, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_XW => new I4(X, 0, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_X_ => new I4(X, 0, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 X_YX => new I4(X, 0, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_YY => new I4(X, 0, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_YZ => new I4(X, 0, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_YW => new I4(X, 0, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_Y_ => new I4(X, 0, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 X_ZX => new I4(X, 0, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_ZY => new I4(X, 0, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_ZZ => new I4(X, 0, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_ZW => new I4(X, 0, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_Z_ => new I4(X, 0, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 X_WX => new I4(X, 0, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_WY => new I4(X, 0, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_WZ => new I4(X, 0, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_WW => new I4(X, 0, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X_W_ => new I4(X, 0, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 X__X => new I4(X, 0, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X__Y => new I4(X, 0, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X__Z => new I4(X, 0, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X__W => new I4(X, 0, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 X___ => new I4(X, 0, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YXXX => new I4(Y, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXXY => new I4(Y, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXXZ => new I4(Y, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXXW => new I4(Y, X, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXX_ => new I4(Y, X, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YXYX => new I4(Y, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXYY => new I4(Y, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXYZ => new I4(Y, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXYW => new I4(Y, X, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXY_ => new I4(Y, X, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YXZX => new I4(Y, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXZY => new I4(Y, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXZZ => new I4(Y, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXZW => new I4(Y, X, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXZ_ => new I4(Y, X, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YXWX => new I4(Y, X, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXWY => new I4(Y, X, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXWZ => new I4(Y, X, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXWW => new I4(Y, X, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YXW_ => new I4(Y, X, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YX_X => new I4(Y, X, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YX_Y => new I4(Y, X, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YX_Z => new I4(Y, X, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YX_W => new I4(Y, X, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YX__ => new I4(Y, X, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YYXX => new I4(Y, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYXY => new I4(Y, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYXZ => new I4(Y, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYXW => new I4(Y, Y, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYX_ => new I4(Y, Y, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YYYX => new I4(Y, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYYY => new I4(Y, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYYZ => new I4(Y, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYYW => new I4(Y, Y, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYY_ => new I4(Y, Y, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YYZX => new I4(Y, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYZY => new I4(Y, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYZZ => new I4(Y, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYZW => new I4(Y, Y, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYZ_ => new I4(Y, Y, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YYWX => new I4(Y, Y, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYWY => new I4(Y, Y, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYWZ => new I4(Y, Y, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYWW => new I4(Y, Y, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YYW_ => new I4(Y, Y, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YY_X => new I4(Y, Y, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YY_Y => new I4(Y, Y, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YY_Z => new I4(Y, Y, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YY_W => new I4(Y, Y, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YY__ => new I4(Y, Y, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YZXX => new I4(Y, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZXY => new I4(Y, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZXZ => new I4(Y, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZXW => new I4(Y, Z, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZX_ => new I4(Y, Z, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YZYX => new I4(Y, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZYY => new I4(Y, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZYZ => new I4(Y, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZYW => new I4(Y, Z, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZY_ => new I4(Y, Z, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YZZX => new I4(Y, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZZY => new I4(Y, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZZZ => new I4(Y, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZZW => new I4(Y, Z, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZZ_ => new I4(Y, Z, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YZWX => new I4(Y, Z, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZWY => new I4(Y, Z, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZWZ => new I4(Y, Z, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZWW => new I4(Y, Z, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZW_ => new I4(Y, Z, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YZ_X => new I4(Y, Z, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZ_Y => new I4(Y, Z, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZ_Z => new I4(Y, Z, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZ_W => new I4(Y, Z, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YZ__ => new I4(Y, Z, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YWXX => new I4(Y, W, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YWXY => new I4(Y, W, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YWXZ => new I4(Y, W, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YWXW => new I4(Y, W, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YWX_ => new I4(Y, W, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YWYX => new I4(Y, W, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YWYY => new I4(Y, W, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YWYZ => new I4(Y, W, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YWYW => new I4(Y, W, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YWY_ => new I4(Y, W, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YWZX => new I4(Y, W, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YWZY => new I4(Y, W, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YWZZ => new I4(Y, W, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YWZW => new I4(Y, W, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YWZ_ => new I4(Y, W, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YWWX => new I4(Y, W, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YWWY => new I4(Y, W, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YWWZ => new I4(Y, W, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YWWW => new I4(Y, W, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YWW_ => new I4(Y, W, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 YW_X => new I4(Y, W, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YW_Y => new I4(Y, W, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YW_Z => new I4(Y, W, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YW_W => new I4(Y, W, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 YW__ => new I4(Y, W, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_XX => new I4(Y, 0, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_XY => new I4(Y, 0, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_XZ => new I4(Y, 0, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_XW => new I4(Y, 0, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_X_ => new I4(Y, 0, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_YX => new I4(Y, 0, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_YY => new I4(Y, 0, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_YZ => new I4(Y, 0, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_YW => new I4(Y, 0, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_Y_ => new I4(Y, 0, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_ZX => new I4(Y, 0, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_ZY => new I4(Y, 0, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_ZZ => new I4(Y, 0, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_ZW => new I4(Y, 0, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_Z_ => new I4(Y, 0, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_WX => new I4(Y, 0, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_WY => new I4(Y, 0, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_WZ => new I4(Y, 0, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_WW => new I4(Y, 0, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y_W_ => new I4(Y, 0, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Y__X => new I4(Y, 0, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y__Y => new I4(Y, 0, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y__Z => new I4(Y, 0, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y__W => new I4(Y, 0, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Y___ => new I4(Y, 0, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXXX => new I4(Z, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXXY => new I4(Z, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXXZ => new I4(Z, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXXW => new I4(Z, X, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXX_ => new I4(Z, X, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXYX => new I4(Z, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXYY => new I4(Z, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXYZ => new I4(Z, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXYW => new I4(Z, X, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXY_ => new I4(Z, X, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXZX => new I4(Z, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXZY => new I4(Z, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXZZ => new I4(Z, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXZW => new I4(Z, X, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXZ_ => new I4(Z, X, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXWX => new I4(Z, X, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXWY => new I4(Z, X, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXWZ => new I4(Z, X, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXWW => new I4(Z, X, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZXW_ => new I4(Z, X, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZX_X => new I4(Z, X, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZX_Y => new I4(Z, X, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZX_Z => new I4(Z, X, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZX_W => new I4(Z, X, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZX__ => new I4(Z, X, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYXX => new I4(Z, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYXY => new I4(Z, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYXZ => new I4(Z, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYXW => new I4(Z, Y, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYX_ => new I4(Z, Y, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYYX => new I4(Z, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYYY => new I4(Z, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYYZ => new I4(Z, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYYW => new I4(Z, Y, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYY_ => new I4(Z, Y, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYZX => new I4(Z, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYZY => new I4(Z, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYZZ => new I4(Z, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYZW => new I4(Z, Y, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYZ_ => new I4(Z, Y, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYWX => new I4(Z, Y, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYWY => new I4(Z, Y, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYWZ => new I4(Z, Y, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYWW => new I4(Z, Y, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZYW_ => new I4(Z, Y, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZY_X => new I4(Z, Y, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZY_Y => new I4(Z, Y, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZY_Z => new I4(Z, Y, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZY_W => new I4(Z, Y, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZY__ => new I4(Z, Y, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZXX => new I4(Z, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZXY => new I4(Z, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZXZ => new I4(Z, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZXW => new I4(Z, Z, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZX_ => new I4(Z, Z, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZYX => new I4(Z, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZYY => new I4(Z, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZYZ => new I4(Z, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZYW => new I4(Z, Z, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZY_ => new I4(Z, Z, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZZX => new I4(Z, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZZY => new I4(Z, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZZZ => new I4(Z, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZZW => new I4(Z, Z, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZZ_ => new I4(Z, Z, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZWX => new I4(Z, Z, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZWY => new I4(Z, Z, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZWZ => new I4(Z, Z, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZWW => new I4(Z, Z, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZW_ => new I4(Z, Z, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZ_X => new I4(Z, Z, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZ_Y => new I4(Z, Z, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZ_Z => new I4(Z, Z, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZ_W => new I4(Z, Z, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZZ__ => new I4(Z, Z, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWXX => new I4(Z, W, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWXY => new I4(Z, W, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWXZ => new I4(Z, W, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWXW => new I4(Z, W, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWX_ => new I4(Z, W, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWYX => new I4(Z, W, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWYY => new I4(Z, W, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWYZ => new I4(Z, W, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWYW => new I4(Z, W, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWY_ => new I4(Z, W, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWZX => new I4(Z, W, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWZY => new I4(Z, W, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWZZ => new I4(Z, W, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWZW => new I4(Z, W, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWZ_ => new I4(Z, W, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWWX => new I4(Z, W, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWWY => new I4(Z, W, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWWZ => new I4(Z, W, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWWW => new I4(Z, W, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZWW_ => new I4(Z, W, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ZW_X => new I4(Z, W, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZW_Y => new I4(Z, W, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZW_Z => new I4(Z, W, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZW_W => new I4(Z, W, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ZW__ => new I4(Z, W, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_XX => new I4(Z, 0, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_XY => new I4(Z, 0, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_XZ => new I4(Z, 0, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_XW => new I4(Z, 0, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_X_ => new I4(Z, 0, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_YX => new I4(Z, 0, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_YY => new I4(Z, 0, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_YZ => new I4(Z, 0, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_YW => new I4(Z, 0, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_Y_ => new I4(Z, 0, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_ZX => new I4(Z, 0, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_ZY => new I4(Z, 0, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_ZZ => new I4(Z, 0, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_ZW => new I4(Z, 0, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_Z_ => new I4(Z, 0, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_WX => new I4(Z, 0, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_WY => new I4(Z, 0, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_WZ => new I4(Z, 0, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_WW => new I4(Z, 0, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z_W_ => new I4(Z, 0, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 Z__X => new I4(Z, 0, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z__Y => new I4(Z, 0, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z__Z => new I4(Z, 0, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z__W => new I4(Z, 0, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 Z___ => new I4(Z, 0, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WXXX => new I4(W, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WXXY => new I4(W, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WXXZ => new I4(W, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WXXW => new I4(W, X, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WXX_ => new I4(W, X, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WXYX => new I4(W, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WXYY => new I4(W, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WXYZ => new I4(W, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WXYW => new I4(W, X, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WXY_ => new I4(W, X, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WXZX => new I4(W, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WXZY => new I4(W, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WXZZ => new I4(W, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WXZW => new I4(W, X, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WXZ_ => new I4(W, X, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WXWX => new I4(W, X, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WXWY => new I4(W, X, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WXWZ => new I4(W, X, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WXWW => new I4(W, X, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WXW_ => new I4(W, X, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WX_X => new I4(W, X, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WX_Y => new I4(W, X, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WX_Z => new I4(W, X, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WX_W => new I4(W, X, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WX__ => new I4(W, X, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WYXX => new I4(W, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WYXY => new I4(W, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WYXZ => new I4(W, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WYXW => new I4(W, Y, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WYX_ => new I4(W, Y, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WYYX => new I4(W, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WYYY => new I4(W, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WYYZ => new I4(W, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WYYW => new I4(W, Y, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WYY_ => new I4(W, Y, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WYZX => new I4(W, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WYZY => new I4(W, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WYZZ => new I4(W, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WYZW => new I4(W, Y, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WYZ_ => new I4(W, Y, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WYWX => new I4(W, Y, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WYWY => new I4(W, Y, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WYWZ => new I4(W, Y, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WYWW => new I4(W, Y, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WYW_ => new I4(W, Y, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WY_X => new I4(W, Y, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WY_Y => new I4(W, Y, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WY_Z => new I4(W, Y, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WY_W => new I4(W, Y, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WY__ => new I4(W, Y, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WZXX => new I4(W, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZXY => new I4(W, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZXZ => new I4(W, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZXW => new I4(W, Z, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZX_ => new I4(W, Z, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WZYX => new I4(W, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZYY => new I4(W, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZYZ => new I4(W, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZYW => new I4(W, Z, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZY_ => new I4(W, Z, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WZZX => new I4(W, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZZY => new I4(W, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZZZ => new I4(W, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZZW => new I4(W, Z, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZZ_ => new I4(W, Z, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WZWX => new I4(W, Z, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZWY => new I4(W, Z, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZWZ => new I4(W, Z, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZWW => new I4(W, Z, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZW_ => new I4(W, Z, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WZ_X => new I4(W, Z, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZ_Y => new I4(W, Z, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZ_Z => new I4(W, Z, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZ_W => new I4(W, Z, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WZ__ => new I4(W, Z, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WWXX => new I4(W, W, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WWXY => new I4(W, W, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WWXZ => new I4(W, W, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WWXW => new I4(W, W, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WWX_ => new I4(W, W, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WWYX => new I4(W, W, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WWYY => new I4(W, W, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WWYZ => new I4(W, W, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WWYW => new I4(W, W, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WWY_ => new I4(W, W, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WWZX => new I4(W, W, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WWZY => new I4(W, W, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WWZZ => new I4(W, W, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WWZW => new I4(W, W, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WWZ_ => new I4(W, W, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WWWX => new I4(W, W, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WWWY => new I4(W, W, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WWWZ => new I4(W, W, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WWWW => new I4(W, W, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WWW_ => new I4(W, W, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 WW_X => new I4(W, W, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WW_Y => new I4(W, W, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WW_Z => new I4(W, W, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WW_W => new I4(W, W, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 WW__ => new I4(W, W, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 W_XX => new I4(W, 0, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W_XY => new I4(W, 0, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W_XZ => new I4(W, 0, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W_XW => new I4(W, 0, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W_X_ => new I4(W, 0, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 W_YX => new I4(W, 0, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W_YY => new I4(W, 0, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W_YZ => new I4(W, 0, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W_YW => new I4(W, 0, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W_Y_ => new I4(W, 0, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 W_ZX => new I4(W, 0, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W_ZY => new I4(W, 0, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W_ZZ => new I4(W, 0, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W_ZW => new I4(W, 0, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W_Z_ => new I4(W, 0, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 W_WX => new I4(W, 0, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W_WY => new I4(W, 0, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W_WZ => new I4(W, 0, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W_WW => new I4(W, 0, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W_W_ => new I4(W, 0, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 W__X => new I4(W, 0, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W__Y => new I4(W, 0, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W__Z => new I4(W, 0, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W__W => new I4(W, 0, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 W___ => new I4(W, 0, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _XXX => new I4(0, X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XXY => new I4(0, X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XXZ => new I4(0, X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XXW => new I4(0, X, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XX_ => new I4(0, X, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _XYX => new I4(0, X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XYY => new I4(0, X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XYZ => new I4(0, X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XYW => new I4(0, X, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XY_ => new I4(0, X, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _XZX => new I4(0, X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XZY => new I4(0, X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XZZ => new I4(0, X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XZW => new I4(0, X, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XZ_ => new I4(0, X, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _XWX => new I4(0, X, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XWY => new I4(0, X, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XWZ => new I4(0, X, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XWW => new I4(0, X, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _XW_ => new I4(0, X, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _X_X => new I4(0, X, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _X_Y => new I4(0, X, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _X_Z => new I4(0, X, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _X_W => new I4(0, X, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _X__ => new I4(0, X, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _YXX => new I4(0, Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YXY => new I4(0, Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YXZ => new I4(0, Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YXW => new I4(0, Y, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YX_ => new I4(0, Y, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _YYX => new I4(0, Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YYY => new I4(0, Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YYZ => new I4(0, Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YYW => new I4(0, Y, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YY_ => new I4(0, Y, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _YZX => new I4(0, Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YZY => new I4(0, Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YZZ => new I4(0, Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YZW => new I4(0, Y, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YZ_ => new I4(0, Y, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _YWX => new I4(0, Y, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YWY => new I4(0, Y, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YWZ => new I4(0, Y, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YWW => new I4(0, Y, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _YW_ => new I4(0, Y, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _Y_X => new I4(0, Y, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _Y_Y => new I4(0, Y, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _Y_Z => new I4(0, Y, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _Y_W => new I4(0, Y, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _Y__ => new I4(0, Y, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZXX => new I4(0, Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZXY => new I4(0, Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZXZ => new I4(0, Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZXW => new I4(0, Z, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZX_ => new I4(0, Z, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZYX => new I4(0, Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZYY => new I4(0, Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZYZ => new I4(0, Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZYW => new I4(0, Z, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZY_ => new I4(0, Z, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZZX => new I4(0, Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZZY => new I4(0, Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZZZ => new I4(0, Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZZW => new I4(0, Z, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZZ_ => new I4(0, Z, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZWX => new I4(0, Z, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZWY => new I4(0, Z, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZWZ => new I4(0, Z, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZWW => new I4(0, Z, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _ZW_ => new I4(0, Z, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _Z_X => new I4(0, Z, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _Z_Y => new I4(0, Z, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _Z_Z => new I4(0, Z, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _Z_W => new I4(0, Z, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _Z__ => new I4(0, Z, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _WXX => new I4(0, W, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _WXY => new I4(0, W, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _WXZ => new I4(0, W, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _WXW => new I4(0, W, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _WX_ => new I4(0, W, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _WYX => new I4(0, W, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _WYY => new I4(0, W, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _WYZ => new I4(0, W, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _WYW => new I4(0, W, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _WY_ => new I4(0, W, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _WZX => new I4(0, W, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _WZY => new I4(0, W, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _WZZ => new I4(0, W, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _WZW => new I4(0, W, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _WZ_ => new I4(0, W, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _WWX => new I4(0, W, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _WWY => new I4(0, W, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _WWZ => new I4(0, W, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _WWW => new I4(0, W, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _WW_ => new I4(0, W, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 _W_X => new I4(0, W, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _W_Y => new I4(0, W, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _W_Z => new I4(0, W, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _W_W => new I4(0, W, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 _W__ => new I4(0, W, 0, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 __XX => new I4(0, 0, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __XY => new I4(0, 0, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __XZ => new I4(0, 0, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __XW => new I4(0, 0, X, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __X_ => new I4(0, 0, X, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 __YX => new I4(0, 0, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __YY => new I4(0, 0, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __YZ => new I4(0, 0, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __YW => new I4(0, 0, Y, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __Y_ => new I4(0, 0, Y, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 __ZX => new I4(0, 0, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __ZY => new I4(0, 0, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __ZZ => new I4(0, 0, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __ZW => new I4(0, 0, Z, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __Z_ => new I4(0, 0, Z, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 __WX => new I4(0, 0, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __WY => new I4(0, 0, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __WZ => new I4(0, 0, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __WW => new I4(0, 0, W, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 __W_ => new I4(0, 0, W, 0);

		[EB(EBS.Never), DB(DBS.Never)] public I4 ___X => new I4(0, 0, 0, X);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ___Y => new I4(0, 0, 0, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ___Z => new I4(0, 0, 0, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ___W => new I4(0, 0, 0, W);
		[EB(EBS.Never), DB(DBS.Never)] public I4 ____ => new I4(0, 0, 0, 0);

#endregion

#region Three

		[EB(EBS.Never), DB(DBS.Never)] public I3 XXX => new I3(X, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XXY => new I3(X, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XXZ => new I3(X, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XXW => new I3(X, X, W);

		[EB(EBS.Never), DB(DBS.Never)] public I3 XYX => new I3(X, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XYY => new I3(X, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XYZ => new I3(X, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XYW => new I3(X, Y, W);

		[EB(EBS.Never), DB(DBS.Never)] public I3 XZX => new I3(X, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XZY => new I3(X, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XZZ => new I3(X, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XZW => new I3(X, Z, W);

		[EB(EBS.Never), DB(DBS.Never)] public I3 XWX => new I3(X, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XWY => new I3(X, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XWZ => new I3(X, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 XWW => new I3(X, W, W);

		[EB(EBS.Never), DB(DBS.Never)] public I3 YXX => new I3(Y, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YXY => new I3(Y, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YXZ => new I3(Y, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YXW => new I3(Y, X, W);

		[EB(EBS.Never), DB(DBS.Never)] public I3 YYX => new I3(Y, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YYY => new I3(Y, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YYZ => new I3(Y, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YYW => new I3(Y, Y, W);

		[EB(EBS.Never), DB(DBS.Never)] public I3 YZX => new I3(Y, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YZY => new I3(Y, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YZZ => new I3(Y, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YZW => new I3(Y, Z, W);

		[EB(EBS.Never), DB(DBS.Never)] public I3 YWX => new I3(Y, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YWY => new I3(Y, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YWZ => new I3(Y, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 YWW => new I3(Y, W, W);

		[EB(EBS.Never), DB(DBS.Never)] public I3 ZXX => new I3(Z, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZXY => new I3(Z, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZXZ => new I3(Z, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZXW => new I3(Z, X, W);

		[EB(EBS.Never), DB(DBS.Never)] public I3 ZYX => new I3(Z, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZYY => new I3(Z, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZYZ => new I3(Z, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZYW => new I3(Z, Y, W);

		[EB(EBS.Never), DB(DBS.Never)] public I3 ZZX => new I3(Z, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZZY => new I3(Z, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZZZ => new I3(Z, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZZW => new I3(Z, Z, W);

		[EB(EBS.Never), DB(DBS.Never)] public I3 ZWX => new I3(Z, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZWY => new I3(Z, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZWZ => new I3(Z, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 ZWW => new I3(Z, W, W);

		[EB(EBS.Never), DB(DBS.Never)] public I3 WXX => new I3(W, X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 WXY => new I3(W, X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 WXZ => new I3(W, X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 WXW => new I3(W, X, W);

		[EB(EBS.Never), DB(DBS.Never)] public I3 WYX => new I3(W, Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 WYY => new I3(W, Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 WYZ => new I3(W, Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 WYW => new I3(W, Y, W);

		[EB(EBS.Never), DB(DBS.Never)] public I3 WZX => new I3(W, Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 WZY => new I3(W, Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 WZZ => new I3(W, Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 WZW => new I3(W, Z, W);

		[EB(EBS.Never), DB(DBS.Never)] public I3 WWX => new I3(W, W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I3 WWY => new I3(W, W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I3 WWZ => new I3(W, W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I3 WWW => new I3(W, W, W);

#endregion

#region Two

		[EB(EBS.Never), DB(DBS.Never)] public I2 XX => new I2(X, X);
		[EB(EBS.Never), DB(DBS.Never)] public I2 XY => new I2(X, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I2 XZ => new I2(X, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I2 XW => new I2(X, W);

		[EB(EBS.Never), DB(DBS.Never)] public I2 YX => new I2(Y, X);
		[EB(EBS.Never), DB(DBS.Never)] public I2 YY => new I2(Y, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I2 YZ => new I2(Y, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I2 YW => new I2(Y, W);

		[EB(EBS.Never), DB(DBS.Never)] public I2 ZX => new I2(Z, X);
		[EB(EBS.Never), DB(DBS.Never)] public I2 ZY => new I2(Z, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I2 ZZ => new I2(Z, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I2 ZW => new I2(Z, W);

		[EB(EBS.Never), DB(DBS.Never)] public I2 WX => new I2(W, X);
		[EB(EBS.Never), DB(DBS.Never)] public I2 WY => new I2(W, Y);
		[EB(EBS.Never), DB(DBS.Never)] public I2 WZ => new I2(W, Z);
		[EB(EBS.Never), DB(DBS.Never)] public I2 WW => new I2(W, W);

#endregion

	}
}