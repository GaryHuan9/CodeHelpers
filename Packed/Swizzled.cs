using System.ComponentModel;

namespace CodeHelpers.Packed
{
	public partial struct Float2
	{

#region Four

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXX => new Float4(X, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXY => new Float4(X, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXX_ => new Float4(X, X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYX => new Float4(X, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYY => new Float4(X, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXY_ => new Float4(X, X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX_X => new Float4(X, X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX_Y => new Float4(X, X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX__ => new Float4(X, X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXX => new Float4(X, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXY => new Float4(X, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYX_ => new Float4(X, Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYX => new Float4(X, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYY => new Float4(X, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYY_ => new Float4(X, Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY_X => new Float4(X, Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY_Y => new Float4(X, Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY__ => new Float4(X, Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_XX => new Float4(X, 0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_XY => new Float4(X, 0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_X_ => new Float4(X, 0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_YX => new Float4(X, 0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_YY => new Float4(X, 0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_Y_ => new Float4(X, 0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X__X => new Float4(X, 0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X__Y => new Float4(X, 0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X___ => new Float4(X, 0f, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXX => new Float4(Y, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXY => new Float4(Y, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXX_ => new Float4(Y, X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYX => new Float4(Y, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYY => new Float4(Y, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXY_ => new Float4(Y, X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX_X => new Float4(Y, X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX_Y => new Float4(Y, X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX__ => new Float4(Y, X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXX => new Float4(Y, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXY => new Float4(Y, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYX_ => new Float4(Y, Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYX => new Float4(Y, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYY => new Float4(Y, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYY_ => new Float4(Y, Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY_X => new Float4(Y, Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY_Y => new Float4(Y, Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY__ => new Float4(Y, Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_XX => new Float4(Y, 0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_XY => new Float4(Y, 0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_X_ => new Float4(Y, 0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_YX => new Float4(Y, 0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_YY => new Float4(Y, 0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_Y_ => new Float4(Y, 0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y__X => new Float4(Y, 0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y__Y => new Float4(Y, 0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y___ => new Float4(Y, 0f, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XXX => new Float4(0f, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XXY => new Float4(0f, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XX_ => new Float4(0f, X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XYX => new Float4(0f, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XYY => new Float4(0f, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XY_ => new Float4(0f, X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X_X => new Float4(0f, X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X_Y => new Float4(0f, X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X__ => new Float4(0f, X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YXX => new Float4(0f, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YXY => new Float4(0f, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YX_ => new Float4(0f, Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YYX => new Float4(0f, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YYY => new Float4(0f, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YY_ => new Float4(0f, Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y_X => new Float4(0f, Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y_Y => new Float4(0f, Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y__ => new Float4(0f, Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __XX => new Float4(0f, 0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __XY => new Float4(0f, 0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __X_ => new Float4(0f, 0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __YX => new Float4(0f, 0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __YY => new Float4(0f, 0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __Y_ => new Float4(0f, 0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ___X => new Float4(0f, 0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ___Y => new Float4(0f, 0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ____ => new Float4(0f, 0f, 0f, 0f);

#endregion

#region Three

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXX => new Float3(X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXY => new Float3(X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XX_ => new Float3(X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYX => new Float3(X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYY => new Float3(X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XY_ => new Float3(X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X_X => new Float3(X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X_Y => new Float3(X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 X__ => new Float3(X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXX => new Float3(Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXY => new Float3(Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YX_ => new Float3(Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYX => new Float3(Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYY => new Float3(Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YY_ => new Float3(Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y_X => new Float3(Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y_Y => new Float3(Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 Y__ => new Float3(Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _XX => new Float3(0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _XY => new Float3(0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _X_ => new Float3(0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _YX => new Float3(0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _YY => new Float3(0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 _Y_ => new Float3(0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 __X => new Float3(0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 __Y => new Float3(0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ___ => new Float3(0f, 0f, 0f);

#endregion

#region Two

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XX => new Float2(X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XY => new Float2(X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 X_ => new Float2(X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YX => new Float2(Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YY => new Float2(Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 Y_ => new Float2(Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 _X => new Float2(0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 _Y => new Float2(0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 __ => new Float2(0f, 0f);

#endregion

	}

	public partial struct Float3
	{

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

	}

	//OPTIMIZE
	public partial struct Float4
	{

#region Four

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXX => new Float4(X, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXY => new Float4(X, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXZ => new Float4(X, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXW => new Float4(X, X, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXX_ => new Float4(X, X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYX => new Float4(X, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYY => new Float4(X, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYZ => new Float4(X, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYW => new Float4(X, X, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXY_ => new Float4(X, X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZX => new Float4(X, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZY => new Float4(X, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZZ => new Float4(X, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZW => new Float4(X, X, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZ_ => new Float4(X, X, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXWX => new Float4(X, X, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXWY => new Float4(X, X, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXWZ => new Float4(X, X, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXWW => new Float4(X, X, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXW_ => new Float4(X, X, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX_X => new Float4(X, X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX_Y => new Float4(X, X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX_Z => new Float4(X, X, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX_W => new Float4(X, X, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XX__ => new Float4(X, X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXX => new Float4(X, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXY => new Float4(X, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXZ => new Float4(X, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXW => new Float4(X, Y, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYX_ => new Float4(X, Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYX => new Float4(X, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYY => new Float4(X, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYZ => new Float4(X, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYW => new Float4(X, Y, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYY_ => new Float4(X, Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZX => new Float4(X, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZY => new Float4(X, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZZ => new Float4(X, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZW => new Float4(X, Y, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZ_ => new Float4(X, Y, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYWX => new Float4(X, Y, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYWY => new Float4(X, Y, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYWZ => new Float4(X, Y, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYWW => new Float4(X, Y, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYW_ => new Float4(X, Y, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY_X => new Float4(X, Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY_Y => new Float4(X, Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY_Z => new Float4(X, Y, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY_W => new Float4(X, Y, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XY__ => new Float4(X, Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZXX => new Float4(X, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZXY => new Float4(X, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZXZ => new Float4(X, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZXW => new Float4(X, Z, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZX_ => new Float4(X, Z, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZYX => new Float4(X, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZYY => new Float4(X, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZYZ => new Float4(X, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZYW => new Float4(X, Z, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZY_ => new Float4(X, Z, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZX => new Float4(X, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZY => new Float4(X, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZZ => new Float4(X, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZW => new Float4(X, Z, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZ_ => new Float4(X, Z, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZWX => new Float4(X, Z, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZWY => new Float4(X, Z, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZWZ => new Float4(X, Z, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZWW => new Float4(X, Z, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZW_ => new Float4(X, Z, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZ_X => new Float4(X, Z, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZ_Y => new Float4(X, Z, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZ_Z => new Float4(X, Z, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZ_W => new Float4(X, Z, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZ__ => new Float4(X, Z, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWXX => new Float4(X, W, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWXY => new Float4(X, W, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWXZ => new Float4(X, W, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWXW => new Float4(X, W, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWX_ => new Float4(X, W, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWYX => new Float4(X, W, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWYY => new Float4(X, W, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWYZ => new Float4(X, W, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWYW => new Float4(X, W, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWY_ => new Float4(X, W, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWZX => new Float4(X, W, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWZY => new Float4(X, W, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWZZ => new Float4(X, W, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWZW => new Float4(X, W, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWZ_ => new Float4(X, W, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWWX => new Float4(X, W, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWWY => new Float4(X, W, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWWZ => new Float4(X, W, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWWW => new Float4(X, W, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWW_ => new Float4(X, W, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XW_X => new Float4(X, W, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XW_Y => new Float4(X, W, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XW_Z => new Float4(X, W, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XW_W => new Float4(X, W, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XW__ => new Float4(X, W, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_XX => new Float4(X, 0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_XY => new Float4(X, 0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_XZ => new Float4(X, 0f, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_XW => new Float4(X, 0f, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_X_ => new Float4(X, 0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_YX => new Float4(X, 0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_YY => new Float4(X, 0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_YZ => new Float4(X, 0f, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_YW => new Float4(X, 0f, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_Y_ => new Float4(X, 0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_ZX => new Float4(X, 0f, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_ZY => new Float4(X, 0f, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_ZZ => new Float4(X, 0f, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_ZW => new Float4(X, 0f, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_Z_ => new Float4(X, 0f, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_WX => new Float4(X, 0f, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_WY => new Float4(X, 0f, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_WZ => new Float4(X, 0f, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_WW => new Float4(X, 0f, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X_W_ => new Float4(X, 0f, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X__X => new Float4(X, 0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X__Y => new Float4(X, 0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X__Z => new Float4(X, 0f, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X__W => new Float4(X, 0f, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 X___ => new Float4(X, 0f, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXX => new Float4(Y, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXY => new Float4(Y, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXZ => new Float4(Y, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXW => new Float4(Y, X, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXX_ => new Float4(Y, X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYX => new Float4(Y, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYY => new Float4(Y, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYZ => new Float4(Y, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYW => new Float4(Y, X, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXY_ => new Float4(Y, X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZX => new Float4(Y, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZY => new Float4(Y, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZZ => new Float4(Y, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZW => new Float4(Y, X, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZ_ => new Float4(Y, X, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXWX => new Float4(Y, X, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXWY => new Float4(Y, X, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXWZ => new Float4(Y, X, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXWW => new Float4(Y, X, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXW_ => new Float4(Y, X, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX_X => new Float4(Y, X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX_Y => new Float4(Y, X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX_Z => new Float4(Y, X, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX_W => new Float4(Y, X, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YX__ => new Float4(Y, X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXX => new Float4(Y, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXY => new Float4(Y, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXZ => new Float4(Y, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXW => new Float4(Y, Y, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYX_ => new Float4(Y, Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYX => new Float4(Y, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYY => new Float4(Y, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYZ => new Float4(Y, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYW => new Float4(Y, Y, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYY_ => new Float4(Y, Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZX => new Float4(Y, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZY => new Float4(Y, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZZ => new Float4(Y, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZW => new Float4(Y, Y, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZ_ => new Float4(Y, Y, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYWX => new Float4(Y, Y, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYWY => new Float4(Y, Y, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYWZ => new Float4(Y, Y, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYWW => new Float4(Y, Y, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYW_ => new Float4(Y, Y, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY_X => new Float4(Y, Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY_Y => new Float4(Y, Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY_Z => new Float4(Y, Y, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY_W => new Float4(Y, Y, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YY__ => new Float4(Y, Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZXX => new Float4(Y, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZXY => new Float4(Y, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZXZ => new Float4(Y, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZXW => new Float4(Y, Z, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZX_ => new Float4(Y, Z, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZYX => new Float4(Y, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZYY => new Float4(Y, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZYZ => new Float4(Y, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZYW => new Float4(Y, Z, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZY_ => new Float4(Y, Z, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZX => new Float4(Y, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZY => new Float4(Y, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZZ => new Float4(Y, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZW => new Float4(Y, Z, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZ_ => new Float4(Y, Z, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZWX => new Float4(Y, Z, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZWY => new Float4(Y, Z, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZWZ => new Float4(Y, Z, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZWW => new Float4(Y, Z, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZW_ => new Float4(Y, Z, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZ_X => new Float4(Y, Z, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZ_Y => new Float4(Y, Z, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZ_Z => new Float4(Y, Z, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZ_W => new Float4(Y, Z, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZ__ => new Float4(Y, Z, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWXX => new Float4(Y, W, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWXY => new Float4(Y, W, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWXZ => new Float4(Y, W, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWXW => new Float4(Y, W, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWX_ => new Float4(Y, W, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWYX => new Float4(Y, W, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWYY => new Float4(Y, W, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWYZ => new Float4(Y, W, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWYW => new Float4(Y, W, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWY_ => new Float4(Y, W, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWZX => new Float4(Y, W, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWZY => new Float4(Y, W, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWZZ => new Float4(Y, W, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWZW => new Float4(Y, W, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWZ_ => new Float4(Y, W, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWWX => new Float4(Y, W, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWWY => new Float4(Y, W, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWWZ => new Float4(Y, W, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWWW => new Float4(Y, W, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWW_ => new Float4(Y, W, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YW_X => new Float4(Y, W, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YW_Y => new Float4(Y, W, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YW_Z => new Float4(Y, W, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YW_W => new Float4(Y, W, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YW__ => new Float4(Y, W, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_XX => new Float4(Y, 0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_XY => new Float4(Y, 0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_XZ => new Float4(Y, 0f, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_XW => new Float4(Y, 0f, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_X_ => new Float4(Y, 0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_YX => new Float4(Y, 0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_YY => new Float4(Y, 0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_YZ => new Float4(Y, 0f, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_YW => new Float4(Y, 0f, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_Y_ => new Float4(Y, 0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_ZX => new Float4(Y, 0f, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_ZY => new Float4(Y, 0f, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_ZZ => new Float4(Y, 0f, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_ZW => new Float4(Y, 0f, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_Z_ => new Float4(Y, 0f, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_WX => new Float4(Y, 0f, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_WY => new Float4(Y, 0f, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_WZ => new Float4(Y, 0f, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_WW => new Float4(Y, 0f, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y_W_ => new Float4(Y, 0f, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y__X => new Float4(Y, 0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y__Y => new Float4(Y, 0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y__Z => new Float4(Y, 0f, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y__W => new Float4(Y, 0f, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Y___ => new Float4(Y, 0f, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXXX => new Float4(Z, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXXY => new Float4(Z, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXXZ => new Float4(Z, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXXW => new Float4(Z, X, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXX_ => new Float4(Z, X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXYX => new Float4(Z, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXYY => new Float4(Z, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXYZ => new Float4(Z, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXYW => new Float4(Z, X, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXY_ => new Float4(Z, X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZX => new Float4(Z, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZY => new Float4(Z, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZZ => new Float4(Z, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZW => new Float4(Z, X, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZ_ => new Float4(Z, X, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXWX => new Float4(Z, X, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXWY => new Float4(Z, X, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXWZ => new Float4(Z, X, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXWW => new Float4(Z, X, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXW_ => new Float4(Z, X, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZX_X => new Float4(Z, X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZX_Y => new Float4(Z, X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZX_Z => new Float4(Z, X, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZX_W => new Float4(Z, X, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZX__ => new Float4(Z, X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYXX => new Float4(Z, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYXY => new Float4(Z, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYXZ => new Float4(Z, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYXW => new Float4(Z, Y, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYX_ => new Float4(Z, Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYYX => new Float4(Z, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYYY => new Float4(Z, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYYZ => new Float4(Z, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYYW => new Float4(Z, Y, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYY_ => new Float4(Z, Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZX => new Float4(Z, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZY => new Float4(Z, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZZ => new Float4(Z, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZW => new Float4(Z, Y, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZ_ => new Float4(Z, Y, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYWX => new Float4(Z, Y, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYWY => new Float4(Z, Y, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYWZ => new Float4(Z, Y, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYWW => new Float4(Z, Y, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYW_ => new Float4(Z, Y, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZY_X => new Float4(Z, Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZY_Y => new Float4(Z, Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZY_Z => new Float4(Z, Y, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZY_W => new Float4(Z, Y, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZY__ => new Float4(Z, Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZXX => new Float4(Z, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZXY => new Float4(Z, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZXZ => new Float4(Z, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZXW => new Float4(Z, Z, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZX_ => new Float4(Z, Z, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZYX => new Float4(Z, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZYY => new Float4(Z, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZYZ => new Float4(Z, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZYW => new Float4(Z, Z, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZY_ => new Float4(Z, Z, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZX => new Float4(Z, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZY => new Float4(Z, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZZ => new Float4(Z, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZW => new Float4(Z, Z, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZ_ => new Float4(Z, Z, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZWX => new Float4(Z, Z, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZWY => new Float4(Z, Z, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZWZ => new Float4(Z, Z, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZWW => new Float4(Z, Z, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZW_ => new Float4(Z, Z, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZ_X => new Float4(Z, Z, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZ_Y => new Float4(Z, Z, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZ_Z => new Float4(Z, Z, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZ_W => new Float4(Z, Z, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZ__ => new Float4(Z, Z, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWXX => new Float4(Z, W, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWXY => new Float4(Z, W, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWXZ => new Float4(Z, W, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWXW => new Float4(Z, W, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWX_ => new Float4(Z, W, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWYX => new Float4(Z, W, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWYY => new Float4(Z, W, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWYZ => new Float4(Z, W, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWYW => new Float4(Z, W, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWY_ => new Float4(Z, W, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWZX => new Float4(Z, W, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWZY => new Float4(Z, W, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWZZ => new Float4(Z, W, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWZW => new Float4(Z, W, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWZ_ => new Float4(Z, W, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWWX => new Float4(Z, W, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWWY => new Float4(Z, W, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWWZ => new Float4(Z, W, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWWW => new Float4(Z, W, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWW_ => new Float4(Z, W, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZW_X => new Float4(Z, W, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZW_Y => new Float4(Z, W, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZW_Z => new Float4(Z, W, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZW_W => new Float4(Z, W, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZW__ => new Float4(Z, W, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_XX => new Float4(Z, 0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_XY => new Float4(Z, 0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_XZ => new Float4(Z, 0f, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_XW => new Float4(Z, 0f, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_X_ => new Float4(Z, 0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_YX => new Float4(Z, 0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_YY => new Float4(Z, 0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_YZ => new Float4(Z, 0f, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_YW => new Float4(Z, 0f, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_Y_ => new Float4(Z, 0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_ZX => new Float4(Z, 0f, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_ZY => new Float4(Z, 0f, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_ZZ => new Float4(Z, 0f, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_ZW => new Float4(Z, 0f, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_Z_ => new Float4(Z, 0f, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_WX => new Float4(Z, 0f, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_WY => new Float4(Z, 0f, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_WZ => new Float4(Z, 0f, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_WW => new Float4(Z, 0f, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z_W_ => new Float4(Z, 0f, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z__X => new Float4(Z, 0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z__Y => new Float4(Z, 0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z__Z => new Float4(Z, 0f, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z__W => new Float4(Z, 0f, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 Z___ => new Float4(Z, 0f, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXXX => new Float4(W, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXXY => new Float4(W, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXXZ => new Float4(W, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXXW => new Float4(W, X, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXX_ => new Float4(W, X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXYX => new Float4(W, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXYY => new Float4(W, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXYZ => new Float4(W, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXYW => new Float4(W, X, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXY_ => new Float4(W, X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXZX => new Float4(W, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXZY => new Float4(W, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXZZ => new Float4(W, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXZW => new Float4(W, X, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXZ_ => new Float4(W, X, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXWX => new Float4(W, X, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXWY => new Float4(W, X, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXWZ => new Float4(W, X, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXWW => new Float4(W, X, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXW_ => new Float4(W, X, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WX_X => new Float4(W, X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WX_Y => new Float4(W, X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WX_Z => new Float4(W, X, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WX_W => new Float4(W, X, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WX__ => new Float4(W, X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYXX => new Float4(W, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYXY => new Float4(W, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYXZ => new Float4(W, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYXW => new Float4(W, Y, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYX_ => new Float4(W, Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYYX => new Float4(W, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYYY => new Float4(W, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYYZ => new Float4(W, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYYW => new Float4(W, Y, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYY_ => new Float4(W, Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYZX => new Float4(W, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYZY => new Float4(W, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYZZ => new Float4(W, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYZW => new Float4(W, Y, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYZ_ => new Float4(W, Y, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYWX => new Float4(W, Y, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYWY => new Float4(W, Y, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYWZ => new Float4(W, Y, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYWW => new Float4(W, Y, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYW_ => new Float4(W, Y, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WY_X => new Float4(W, Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WY_Y => new Float4(W, Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WY_Z => new Float4(W, Y, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WY_W => new Float4(W, Y, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WY__ => new Float4(W, Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZXX => new Float4(W, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZXY => new Float4(W, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZXZ => new Float4(W, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZXW => new Float4(W, Z, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZX_ => new Float4(W, Z, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZYX => new Float4(W, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZYY => new Float4(W, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZYZ => new Float4(W, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZYW => new Float4(W, Z, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZY_ => new Float4(W, Z, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZZX => new Float4(W, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZZY => new Float4(W, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZZZ => new Float4(W, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZZW => new Float4(W, Z, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZZ_ => new Float4(W, Z, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZWX => new Float4(W, Z, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZWY => new Float4(W, Z, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZWZ => new Float4(W, Z, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZWW => new Float4(W, Z, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZW_ => new Float4(W, Z, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZ_X => new Float4(W, Z, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZ_Y => new Float4(W, Z, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZ_Z => new Float4(W, Z, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZ_W => new Float4(W, Z, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZ__ => new Float4(W, Z, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWXX => new Float4(W, W, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWXY => new Float4(W, W, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWXZ => new Float4(W, W, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWXW => new Float4(W, W, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWX_ => new Float4(W, W, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWYX => new Float4(W, W, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWYY => new Float4(W, W, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWYZ => new Float4(W, W, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWYW => new Float4(W, W, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWY_ => new Float4(W, W, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWZX => new Float4(W, W, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWZY => new Float4(W, W, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWZZ => new Float4(W, W, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWZW => new Float4(W, W, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWZ_ => new Float4(W, W, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWWX => new Float4(W, W, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWWY => new Float4(W, W, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWWZ => new Float4(W, W, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWWW => new Float4(W, W, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWW_ => new Float4(W, W, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WW_X => new Float4(W, W, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WW_Y => new Float4(W, W, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WW_Z => new Float4(W, W, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WW_W => new Float4(W, W, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WW__ => new Float4(W, W, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_XX => new Float4(W, 0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_XY => new Float4(W, 0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_XZ => new Float4(W, 0f, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_XW => new Float4(W, 0f, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_X_ => new Float4(W, 0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_YX => new Float4(W, 0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_YY => new Float4(W, 0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_YZ => new Float4(W, 0f, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_YW => new Float4(W, 0f, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_Y_ => new Float4(W, 0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_ZX => new Float4(W, 0f, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_ZY => new Float4(W, 0f, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_ZZ => new Float4(W, 0f, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_ZW => new Float4(W, 0f, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_Z_ => new Float4(W, 0f, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_WX => new Float4(W, 0f, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_WY => new Float4(W, 0f, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_WZ => new Float4(W, 0f, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_WW => new Float4(W, 0f, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W_W_ => new Float4(W, 0f, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W__X => new Float4(W, 0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W__Y => new Float4(W, 0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W__Z => new Float4(W, 0f, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W__W => new Float4(W, 0f, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 W___ => new Float4(W, 0f, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XXX => new Float4(0f, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XXY => new Float4(0f, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XXZ => new Float4(0f, X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XXW => new Float4(0f, X, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XX_ => new Float4(0f, X, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XYX => new Float4(0f, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XYY => new Float4(0f, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XYZ => new Float4(0f, X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XYW => new Float4(0f, X, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XY_ => new Float4(0f, X, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XZX => new Float4(0f, X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XZY => new Float4(0f, X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XZZ => new Float4(0f, X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XZW => new Float4(0f, X, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XZ_ => new Float4(0f, X, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XWX => new Float4(0f, X, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XWY => new Float4(0f, X, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XWZ => new Float4(0f, X, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XWW => new Float4(0f, X, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _XW_ => new Float4(0f, X, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X_X => new Float4(0f, X, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X_Y => new Float4(0f, X, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X_Z => new Float4(0f, X, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X_W => new Float4(0f, X, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _X__ => new Float4(0f, X, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YXX => new Float4(0f, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YXY => new Float4(0f, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YXZ => new Float4(0f, Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YXW => new Float4(0f, Y, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YX_ => new Float4(0f, Y, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YYX => new Float4(0f, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YYY => new Float4(0f, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YYZ => new Float4(0f, Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YYW => new Float4(0f, Y, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YY_ => new Float4(0f, Y, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YZX => new Float4(0f, Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YZY => new Float4(0f, Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YZZ => new Float4(0f, Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YZW => new Float4(0f, Y, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YZ_ => new Float4(0f, Y, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YWX => new Float4(0f, Y, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YWY => new Float4(0f, Y, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YWZ => new Float4(0f, Y, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YWW => new Float4(0f, Y, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _YW_ => new Float4(0f, Y, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y_X => new Float4(0f, Y, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y_Y => new Float4(0f, Y, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y_Z => new Float4(0f, Y, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y_W => new Float4(0f, Y, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Y__ => new Float4(0f, Y, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZXX => new Float4(0f, Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZXY => new Float4(0f, Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZXZ => new Float4(0f, Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZXW => new Float4(0f, Z, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZX_ => new Float4(0f, Z, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZYX => new Float4(0f, Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZYY => new Float4(0f, Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZYZ => new Float4(0f, Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZYW => new Float4(0f, Z, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZY_ => new Float4(0f, Z, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZZX => new Float4(0f, Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZZY => new Float4(0f, Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZZZ => new Float4(0f, Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZZW => new Float4(0f, Z, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZZ_ => new Float4(0f, Z, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZWX => new Float4(0f, Z, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZWY => new Float4(0f, Z, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZWZ => new Float4(0f, Z, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZWW => new Float4(0f, Z, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _ZW_ => new Float4(0f, Z, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Z_X => new Float4(0f, Z, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Z_Y => new Float4(0f, Z, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Z_Z => new Float4(0f, Z, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Z_W => new Float4(0f, Z, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _Z__ => new Float4(0f, Z, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WXX => new Float4(0f, W, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WXY => new Float4(0f, W, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WXZ => new Float4(0f, W, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WXW => new Float4(0f, W, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WX_ => new Float4(0f, W, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WYX => new Float4(0f, W, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WYY => new Float4(0f, W, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WYZ => new Float4(0f, W, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WYW => new Float4(0f, W, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WY_ => new Float4(0f, W, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WZX => new Float4(0f, W, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WZY => new Float4(0f, W, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WZZ => new Float4(0f, W, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WZW => new Float4(0f, W, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WZ_ => new Float4(0f, W, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WWX => new Float4(0f, W, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WWY => new Float4(0f, W, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WWZ => new Float4(0f, W, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WWW => new Float4(0f, W, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _WW_ => new Float4(0f, W, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _W_X => new Float4(0f, W, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _W_Y => new Float4(0f, W, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _W_Z => new Float4(0f, W, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _W_W => new Float4(0f, W, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 _W__ => new Float4(0f, W, 0f, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __XX => new Float4(0f, 0f, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __XY => new Float4(0f, 0f, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __XZ => new Float4(0f, 0f, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __XW => new Float4(0f, 0f, X, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __X_ => new Float4(0f, 0f, X, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __YX => new Float4(0f, 0f, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __YY => new Float4(0f, 0f, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __YZ => new Float4(0f, 0f, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __YW => new Float4(0f, 0f, Y, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __Y_ => new Float4(0f, 0f, Y, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __ZX => new Float4(0f, 0f, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __ZY => new Float4(0f, 0f, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __ZZ => new Float4(0f, 0f, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __ZW => new Float4(0f, 0f, Z, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __Z_ => new Float4(0f, 0f, Z, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __WX => new Float4(0f, 0f, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __WY => new Float4(0f, 0f, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __WZ => new Float4(0f, 0f, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __WW => new Float4(0f, 0f, W, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 __W_ => new Float4(0f, 0f, W, 0f);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ___X => new Float4(0f, 0f, 0f, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ___Y => new Float4(0f, 0f, 0f, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ___Z => new Float4(0f, 0f, 0f, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ___W => new Float4(0f, 0f, 0f, W);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ____ => new Float4(0f, 0f, 0f, 0f);

#endregion

#region Three

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXX => new Float3(X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXY => new Float3(X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXZ => new Float3(X, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXW => new Float3(X, X, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYX => new Float3(X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYY => new Float3(X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYZ => new Float3(X, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYW => new Float3(X, Y, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZX => new Float3(X, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZY => new Float3(X, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZZ => new Float3(X, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZW => new Float3(X, Z, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XWX => new Float3(X, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XWY => new Float3(X, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XWZ => new Float3(X, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XWW => new Float3(X, W, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXX => new Float3(Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXY => new Float3(Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXZ => new Float3(Y, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXW => new Float3(Y, X, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYX => new Float3(Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYY => new Float3(Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYZ => new Float3(Y, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYW => new Float3(Y, Y, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZX => new Float3(Y, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZY => new Float3(Y, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZZ => new Float3(Y, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZW => new Float3(Y, Z, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YWX => new Float3(Y, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YWY => new Float3(Y, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YWZ => new Float3(Y, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YWW => new Float3(Y, W, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXX => new Float3(Z, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXY => new Float3(Z, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXZ => new Float3(Z, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXW => new Float3(Z, X, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYX => new Float3(Z, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYY => new Float3(Z, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYZ => new Float3(Z, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYW => new Float3(Z, Y, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZX => new Float3(Z, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZY => new Float3(Z, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZZ => new Float3(Z, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZW => new Float3(Z, Z, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZWX => new Float3(Z, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZWY => new Float3(Z, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZWZ => new Float3(Z, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZWW => new Float3(Z, W, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WXX => new Float3(W, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WXY => new Float3(W, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WXZ => new Float3(W, X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WXW => new Float3(W, X, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WYX => new Float3(W, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WYY => new Float3(W, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WYZ => new Float3(W, Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WYW => new Float3(W, Y, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WZX => new Float3(W, Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WZY => new Float3(W, Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WZZ => new Float3(W, Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WZW => new Float3(W, Z, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WWX => new Float3(W, W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WWY => new Float3(W, W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WWZ => new Float3(W, W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WWW => new Float3(W, W, W);

#endregion

#region Two

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XX => new Float2(X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XY => new Float2(X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XZ => new Float2(X, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XW => new Float2(X, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YX => new Float2(Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YY => new Float2(Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YZ => new Float2(Y, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YW => new Float2(Y, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZX => new Float2(Z, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZY => new Float2(Z, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZZ => new Float2(Z, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZW => new Float2(Z, W);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 WX => new Float2(W, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 WY => new Float2(W, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 WZ => new Float2(W, Z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 WW => new Float2(W, W);

#endregion

	}

	public partial struct Int2
	{

#region Four

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXXX => new Int4(X, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXXY => new Int4(X, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXX_ => new Int4(X, X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXYX => new Int4(X, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXYY => new Int4(X, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XXY_ => new Int4(X, X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX_X => new Int4(X, X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX_Y => new Int4(X, X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XX__ => new Int4(X, X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYXX => new Int4(X, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYXY => new Int4(X, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYX_ => new Int4(X, Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYYX => new Int4(X, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYYY => new Int4(X, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XYY_ => new Int4(X, Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY_X => new Int4(X, Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY_Y => new Int4(X, Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 XY__ => new Int4(X, Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_XX => new Int4(X, 0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_XY => new Int4(X, 0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_X_ => new Int4(X, 0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_YX => new Int4(X, 0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_YY => new Int4(X, 0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X_Y_ => new Int4(X, 0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X__X => new Int4(X, 0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X__Y => new Int4(X, 0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 X___ => new Int4(X, 0, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXXX => new Int4(Y, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXXY => new Int4(Y, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXX_ => new Int4(Y, X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXYX => new Int4(Y, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXYY => new Int4(Y, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YXY_ => new Int4(Y, X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX_X => new Int4(Y, X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX_Y => new Int4(Y, X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YX__ => new Int4(Y, X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYXX => new Int4(Y, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYXY => new Int4(Y, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYX_ => new Int4(Y, Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYYX => new Int4(Y, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYYY => new Int4(Y, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YYY_ => new Int4(Y, Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY_X => new Int4(Y, Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY_Y => new Int4(Y, Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 YY__ => new Int4(Y, Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_XX => new Int4(Y, 0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_XY => new Int4(Y, 0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_X_ => new Int4(Y, 0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_YX => new Int4(Y, 0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_YY => new Int4(Y, 0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y_Y_ => new Int4(Y, 0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y__X => new Int4(Y, 0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y__Y => new Int4(Y, 0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 Y___ => new Int4(Y, 0, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XXX => new Int4(0, X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XXY => new Int4(0, X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XX_ => new Int4(0, X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XYX => new Int4(0, X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XYY => new Int4(0, X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _XY_ => new Int4(0, X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X_X => new Int4(0, X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X_Y => new Int4(0, X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _X__ => new Int4(0, X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YXX => new Int4(0, Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YXY => new Int4(0, Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YX_ => new Int4(0, Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YYX => new Int4(0, Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YYY => new Int4(0, Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _YY_ => new Int4(0, Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y_X => new Int4(0, Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y_Y => new Int4(0, Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 _Y__ => new Int4(0, Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __XX => new Int4(0, 0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __XY => new Int4(0, 0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __X_ => new Int4(0, 0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __YX => new Int4(0, 0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __YY => new Int4(0, 0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 __Y_ => new Int4(0, 0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ___X => new Int4(0, 0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ___Y => new Int4(0, 0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int4 ____ => new Int4(0, 0, 0, 0);

#endregion

#region Three

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXX => new Int3(X, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XXY => new Int3(X, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XX_ => new Int3(X, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYX => new Int3(X, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XYY => new Int3(X, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 XY_ => new Int3(X, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X_X => new Int3(X, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X_Y => new Int3(X, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 X__ => new Int3(X, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXX => new Int3(Y, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YXY => new Int3(Y, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YX_ => new Int3(Y, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYX => new Int3(Y, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YYY => new Int3(Y, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 YY_ => new Int3(Y, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y_X => new Int3(Y, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y_Y => new Int3(Y, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 Y__ => new Int3(Y, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _XX => new Int3(0, X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _XY => new Int3(0, X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _X_ => new Int3(0, X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _YX => new Int3(0, Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _YY => new Int3(0, Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 _Y_ => new Int3(0, Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 __X => new Int3(0, 0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 __Y => new Int3(0, 0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int3 ___ => new Int3(0, 0, 0);

#endregion

#region Two

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XX => new Int2(X, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 XY => new Int2(X, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 X_ => new Int2(X, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YX => new Int2(Y, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 YY => new Int2(Y, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 Y_ => new Int2(Y, 0);

		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 _X => new Int2(0, X);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 _Y => new Int2(0, Y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Int2 __ => new Int2(0, 0);

#endregion

	}

	public partial struct Int3
	{

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

	}

	public partial struct Int4
	{

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

	}
}