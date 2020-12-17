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
	public readonly struct Float4 : IEquatable<Float4>, IFormattable
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float4(float x, float y, float z, float w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		public readonly float x;
		public readonly float y;
		public readonly float z;
		public readonly float w;

#region Swizzled4

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXX => new Float4(x, x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXY => new Float4(x, x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXZ => new Float4(x, x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXXW => new Float4(x, x, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYX => new Float4(x, x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYY => new Float4(x, x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYZ => new Float4(x, x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXYW => new Float4(x, x, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZX => new Float4(x, x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZY => new Float4(x, x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZZ => new Float4(x, x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXZW => new Float4(x, x, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXWX => new Float4(x, x, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXWY => new Float4(x, x, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXWZ => new Float4(x, x, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XXWW => new Float4(x, x, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXX => new Float4(x, y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXY => new Float4(x, y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXZ => new Float4(x, y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYXW => new Float4(x, y, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYX => new Float4(x, y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYY => new Float4(x, y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYZ => new Float4(x, y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYYW => new Float4(x, y, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZX => new Float4(x, y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZY => new Float4(x, y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZZ => new Float4(x, y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYZW => new Float4(x, y, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYWX => new Float4(x, y, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYWY => new Float4(x, y, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYWZ => new Float4(x, y, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XYWW => new Float4(x, y, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZXX => new Float4(x, z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZXY => new Float4(x, z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZXZ => new Float4(x, z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZXW => new Float4(x, z, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZYX => new Float4(x, z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZYY => new Float4(x, z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZYZ => new Float4(x, z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZYW => new Float4(x, z, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZX => new Float4(x, z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZY => new Float4(x, z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZZ => new Float4(x, z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZZW => new Float4(x, z, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZWX => new Float4(x, z, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZWY => new Float4(x, z, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZWZ => new Float4(x, z, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XZWW => new Float4(x, z, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWXX => new Float4(x, w, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWXY => new Float4(x, w, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWXZ => new Float4(x, w, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWXW => new Float4(x, w, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWYX => new Float4(x, w, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWYY => new Float4(x, w, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWYZ => new Float4(x, w, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWYW => new Float4(x, w, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWZX => new Float4(x, w, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWZY => new Float4(x, w, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWZZ => new Float4(x, w, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWZW => new Float4(x, w, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWWX => new Float4(x, w, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWWY => new Float4(x, w, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWWZ => new Float4(x, w, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 XWWW => new Float4(x, w, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXX => new Float4(y, x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXY => new Float4(y, x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXZ => new Float4(y, x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXXW => new Float4(y, x, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYX => new Float4(y, x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYY => new Float4(y, x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYZ => new Float4(y, x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXYW => new Float4(y, x, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZX => new Float4(y, x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZY => new Float4(y, x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZZ => new Float4(y, x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXZW => new Float4(y, x, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXWX => new Float4(y, x, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXWY => new Float4(y, x, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXWZ => new Float4(y, x, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YXWW => new Float4(y, x, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXX => new Float4(y, y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXY => new Float4(y, y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXZ => new Float4(y, y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYXW => new Float4(y, y, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYX => new Float4(y, y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYY => new Float4(y, y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYZ => new Float4(y, y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYYW => new Float4(y, y, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZX => new Float4(y, y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZY => new Float4(y, y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZZ => new Float4(y, y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYZW => new Float4(y, y, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYWX => new Float4(y, y, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYWY => new Float4(y, y, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYWZ => new Float4(y, y, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YYWW => new Float4(y, y, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZXX => new Float4(y, z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZXY => new Float4(y, z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZXZ => new Float4(y, z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZXW => new Float4(y, z, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZYX => new Float4(y, z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZYY => new Float4(y, z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZYZ => new Float4(y, z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZYW => new Float4(y, z, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZX => new Float4(y, z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZY => new Float4(y, z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZZ => new Float4(y, z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZZW => new Float4(y, z, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZWX => new Float4(y, z, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZWY => new Float4(y, z, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZWZ => new Float4(y, z, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YZWW => new Float4(y, z, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWXX => new Float4(y, w, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWXY => new Float4(y, w, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWXZ => new Float4(y, w, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWXW => new Float4(y, w, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWYX => new Float4(y, w, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWYY => new Float4(y, w, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWYZ => new Float4(y, w, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWYW => new Float4(y, w, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWZX => new Float4(y, w, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWZY => new Float4(y, w, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWZZ => new Float4(y, w, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWZW => new Float4(y, w, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWWX => new Float4(y, w, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWWY => new Float4(y, w, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWWZ => new Float4(y, w, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 YWWW => new Float4(y, w, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXXX => new Float4(z, x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXXY => new Float4(z, x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXXZ => new Float4(z, x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXXW => new Float4(z, x, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXYX => new Float4(z, x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXYY => new Float4(z, x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXYZ => new Float4(z, x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXYW => new Float4(z, x, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZX => new Float4(z, x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZY => new Float4(z, x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZZ => new Float4(z, x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXZW => new Float4(z, x, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXWX => new Float4(z, x, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXWY => new Float4(z, x, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXWZ => new Float4(z, x, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZXWW => new Float4(z, x, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYXX => new Float4(z, y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYXY => new Float4(z, y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYXZ => new Float4(z, y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYXW => new Float4(z, y, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYYX => new Float4(z, y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYYY => new Float4(z, y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYYZ => new Float4(z, y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYYW => new Float4(z, y, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZX => new Float4(z, y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZY => new Float4(z, y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZZ => new Float4(z, y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYZW => new Float4(z, y, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYWX => new Float4(z, y, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYWY => new Float4(z, y, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYWZ => new Float4(z, y, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZYWW => new Float4(z, y, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZXX => new Float4(z, z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZXY => new Float4(z, z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZXZ => new Float4(z, z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZXW => new Float4(z, z, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZYX => new Float4(z, z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZYY => new Float4(z, z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZYZ => new Float4(z, z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZYW => new Float4(z, z, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZX => new Float4(z, z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZY => new Float4(z, z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZZ => new Float4(z, z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZZW => new Float4(z, z, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZWX => new Float4(z, z, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZWY => new Float4(z, z, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZWZ => new Float4(z, z, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZZWW => new Float4(z, z, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWXX => new Float4(z, w, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWXY => new Float4(z, w, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWXZ => new Float4(z, w, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWXW => new Float4(z, w, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWYX => new Float4(z, w, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWYY => new Float4(z, w, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWYZ => new Float4(z, w, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWYW => new Float4(z, w, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWZX => new Float4(z, w, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWZY => new Float4(z, w, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWZZ => new Float4(z, w, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWZW => new Float4(z, w, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWWX => new Float4(z, w, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWWY => new Float4(z, w, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWWZ => new Float4(z, w, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 ZWWW => new Float4(z, w, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXXX => new Float4(w, x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXXY => new Float4(w, x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXXZ => new Float4(w, x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXXW => new Float4(w, x, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXYX => new Float4(w, x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXYY => new Float4(w, x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXYZ => new Float4(w, x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXYW => new Float4(w, x, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXZX => new Float4(w, x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXZY => new Float4(w, x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXZZ => new Float4(w, x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXZW => new Float4(w, x, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXWX => new Float4(w, x, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXWY => new Float4(w, x, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXWZ => new Float4(w, x, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WXWW => new Float4(w, x, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYXX => new Float4(w, y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYXY => new Float4(w, y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYXZ => new Float4(w, y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYXW => new Float4(w, y, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYYX => new Float4(w, y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYYY => new Float4(w, y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYYZ => new Float4(w, y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYYW => new Float4(w, y, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYZX => new Float4(w, y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYZY => new Float4(w, y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYZZ => new Float4(w, y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYZW => new Float4(w, y, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYWX => new Float4(w, y, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYWY => new Float4(w, y, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYWZ => new Float4(w, y, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WYWW => new Float4(w, y, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZXX => new Float4(w, z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZXY => new Float4(w, z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZXZ => new Float4(w, z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZXW => new Float4(w, z, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZYX => new Float4(w, z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZYY => new Float4(w, z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZYZ => new Float4(w, z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZYW => new Float4(w, z, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZZX => new Float4(w, z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZZY => new Float4(w, z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZZZ => new Float4(w, z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZZW => new Float4(w, z, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZWX => new Float4(w, z, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZWY => new Float4(w, z, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZWZ => new Float4(w, z, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WZWW => new Float4(w, z, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWXX => new Float4(w, w, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWXY => new Float4(w, w, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWXZ => new Float4(w, w, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWXW => new Float4(w, w, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWYX => new Float4(w, w, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWYY => new Float4(w, w, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWYZ => new Float4(w, w, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWYW => new Float4(w, w, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWZX => new Float4(w, w, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWZY => new Float4(w, w, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWZZ => new Float4(w, w, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWZW => new Float4(w, w, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWWX => new Float4(w, w, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWWY => new Float4(w, w, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWWZ => new Float4(w, w, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float4 WWWW => new Float4(w, w, w, w);

#endregion

#region Swizzled3

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXX => new Float3(x, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXY => new Float3(x, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXZ => new Float3(x, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XXW => new Float3(x, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYX => new Float3(x, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYY => new Float3(x, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYZ => new Float3(x, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XYW => new Float3(x, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZX => new Float3(x, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZY => new Float3(x, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZZ => new Float3(x, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XZW => new Float3(x, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XWX => new Float3(x, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XWY => new Float3(x, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XWZ => new Float3(x, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 XWW => new Float3(x, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXX => new Float3(y, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXY => new Float3(y, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXZ => new Float3(y, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YXW => new Float3(y, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYX => new Float3(y, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYY => new Float3(y, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYZ => new Float3(y, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YYW => new Float3(y, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZX => new Float3(y, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZY => new Float3(y, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZZ => new Float3(y, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YZW => new Float3(y, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YWX => new Float3(y, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YWY => new Float3(y, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YWZ => new Float3(y, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 YWW => new Float3(y, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXX => new Float3(z, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXY => new Float3(z, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXZ => new Float3(z, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZXW => new Float3(z, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYX => new Float3(z, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYY => new Float3(z, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYZ => new Float3(z, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZYW => new Float3(z, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZX => new Float3(z, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZY => new Float3(z, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZZ => new Float3(z, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZZW => new Float3(z, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZWX => new Float3(z, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZWY => new Float3(z, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZWZ => new Float3(z, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 ZWW => new Float3(z, w, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WXX => new Float3(w, x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WXY => new Float3(w, x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WXZ => new Float3(w, x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WXW => new Float3(w, x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WYX => new Float3(w, y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WYY => new Float3(w, y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WYZ => new Float3(w, y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WYW => new Float3(w, y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WZX => new Float3(w, z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WZY => new Float3(w, z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WZZ => new Float3(w, z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WZW => new Float3(w, z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WWX => new Float3(w, w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WWY => new Float3(w, w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WWZ => new Float3(w, w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float3 WWW => new Float3(w, w, w);

#endregion

#region Swizzled2

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XX => new Float2(x, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XY => new Float2(x, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XZ => new Float2(x, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 XW => new Float2(x, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YX => new Float2(y, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YY => new Float2(y, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YZ => new Float2(y, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 YW => new Float2(y, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZX => new Float2(z, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZY => new Float2(z, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZZ => new Float2(z, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 ZW => new Float2(z, w);

		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 WX => new Float2(w, x);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 WY => new Float2(w, y);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 WZ => new Float2(w, z);
		[EditorBrowsable(EditorBrowsableState.Never)] public Float2 WW => new Float2(w, w);

#endregion

#region Static Properties

		public static readonly Float4 right = new Float4(1f, 0f, 0f, 0f);
		public static readonly Float4 left = new Float4(-1f, 0f, 0f, 0f);

		public static readonly Float4 up = new Float4(0f, 1f, 0f, 0f);
		public static readonly Float4 down = new Float4(0f, -1f, 0f, 0f);

		public static readonly Float4 forward = new Float4(0f, 0f, 1f, 0f);
		public static readonly Float4 backward = new Float4(0f, 0f, -1f, 0f);

		public static readonly Float4 ana = new Float4(0f, 0f, 0f, 1f);
		public static readonly Float4 kata = new Float4(0f, 0f, 0f, -1f);

		public static readonly Float4 zero = new Float4(0f, 0f, 0f, 0f);

		public static readonly Float4 one = new Float4(1f, 1f, 1f, 1f);
		public static readonly Float4 negativeOne = new Float4(-1f, -1f, -1f, 1f);

		public static readonly Float4 half = new Float4(0.5f, 0.5f, 0.5f, 0f);
		public static readonly Float4 negativeHalf = new Float4(-0.5f, -0.5f, -0.5f, 0f);

		public static readonly Float4 maxValue = new Float4(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
		public static readonly Float4 minValue = new Float4(float.MinValue, float.MinValue, float.MinValue, float.MinValue);

		public static readonly Float4 positiveInfinity = new Float4(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
		public static readonly Float4 negativeInfinity = new Float4(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

		public static readonly Float4 epsilon = new Float4(Scalars.Epsilon, Scalars.Epsilon, Scalars.Epsilon, Scalars.Epsilon);
		public static readonly Float4 NaN = new Float4(float.NaN, float.NaN, float.NaN, float.NaN);

#endregion

#region Instance Properties

#region Scaler Returns

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
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x * x + y * y + z * z + w * w;
		}

		public double SquaredMagnitudeDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)x * x + (double)y * y + (double)z * z + (double)w * w;
		}

		public float Product
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x * y * z * w;
		}

		public double ProductDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)x * y * z * w;
		}

		public float ProductAbsoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs(x * y * z * w);
		}

		public double ProductAbsolutedDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs((double)x * y * z * w);
		}

		public float Sum
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => x + y + z + w;
		}

		public double SumDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)x + y + z + w;
		}

		public float Average
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (float)AverageDouble;
		}

		public double AverageDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => ((double)x + y + z + w) / 4d;
		}

		public float MinComponent
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

		public float MaxComponent
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

		public float this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
#if UNSAFE_CODE_ENABLED
				unsafe
				{
					if (index < 0 || 3 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
					fixed (Float4* pointer = &this) return ((float*)pointer)[index];
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

#region Float4 Returns

		public Float4 Absoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float4(Math.Abs(x), Math.Abs(y), Math.Abs(z), Math.Abs(w));
		}

		public Float4 Normalized
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				double squared = SquaredMagnitudeDouble;
				if (AlmostEqualsZero(squared)) return zero;

				return this / (float)Math.Sqrt(squared);
			}
		}

		public Float4 Sorted
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

		public Float4 SortedReversed
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

		public Float4 FlooredFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float4((float)Math.Floor(x), (float)Math.Floor(y), (float)Math.Floor(z), (float)Math.Floor(w));
		}

		public Float4 CeiledFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float4((float)Math.Ceiling(x), (float)Math.Ceiling(y), (float)Math.Ceiling(z), (float)Math.Ceiling(w));
		}

		public Float4 RoundedFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float4((float)Math.Round(x), (float)Math.Round(y), (float)Math.Round(z), (float)Math.Round(w));
		}

#endregion

#endregion

#region Methods

#region Instance

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Dot(Float4 other) => x * other.x + y * other.y + z * other.z + w * other.w;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DotDouble(Float4 other) => (double)x * other.x + (double)y * other.y + (double)z * other.z + (double)w * other.w;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Min(Float4 other) => new Float4(Math.Min(x, other.x), Math.Min(y, other.y), Math.Min(z, other.z), Math.Min(w, other.w));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Max(Float4 other) => new Float4(Math.Max(x, other.x), Math.Max(y, other.y), Math.Max(z, other.z), Math.Max(w, other.w));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Clamp(Float4 min, Float4 max) => new Float4(x.Clamp(min.x, max.x), y.Clamp(min.y, max.y), z.Clamp(min.z, max.z), w.Clamp(min.w, max.w));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Clamp(float min, float max) => new Float4(x.Clamp(min, max), y.Clamp(min, max), z.Clamp(min, max), w.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float4 ClampMagnitude(float max)
		{
			double squared = SquaredMagnitudeDouble;
			if (squared <= (double)max * max) return this;

			float scale = max / (float)Math.Sqrt(squared);
			return new Float4(x * scale, y * scale, z * scale, w * scale);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Lerp(Float4 other, Float4 value) => new Float4(Scalars.Lerp(x, other.x, value.x), Scalars.Lerp(y, other.y, value.y), Scalars.Lerp(z, other.z, value.z), Scalars.Lerp(w, other.w, value.w));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Lerp(Float4 other, float value) => new Float4(Scalars.Lerp(x, other.x, value), Scalars.Lerp(y, other.y, value), Scalars.Lerp(z, other.z, value), Scalars.Lerp(w, other.w, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 InverseLerp(Float4 other, Float4 value) => new Float4(Scalars.InverseLerp(x, other.x, value.x), Scalars.InverseLerp(y, other.y, value.y), Scalars.InverseLerp(z, other.z, value.z), Scalars.InverseLerp(w, other.w, value.w));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 InverseLerp(Float4 other, float value) => new Float4(Scalars.InverseLerp(x, other.x, value), Scalars.InverseLerp(y, other.y, value), Scalars.InverseLerp(z, other.z, value), Scalars.InverseLerp(w, other.w, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Repeat(Float4 length) => new Float4(x.Repeat(length.x), y.Repeat(length.y), z.Repeat(length.z), w.Repeat(length.w));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Repeat(float length) => new Float4(x.Repeat(length), y.Repeat(length), z.Repeat(length), w.Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float4 Damp(Float4 target, ref Float4 velocity, Float4 smoothTime, float deltaTime)
		{
			float velocityX = velocity.x;
			float velocityY = velocity.y;
			float velocityZ = velocity.z;
			float velocityW = velocity.w;

			Float4 result = new Float4
			(
				Scalars.Damp(x, target.x, ref velocityX, smoothTime.x, deltaTime),
				Scalars.Damp(y, target.y, ref velocityY, smoothTime.y, deltaTime),
				Scalars.Damp(z, target.z, ref velocityZ, smoothTime.z, deltaTime),
				Scalars.Damp(w, target.w, ref velocityW, smoothTime.w, deltaTime)
			);

			velocity = new Float4(velocityX, velocityY, velocityZ, velocityW);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float4 Damp(Float4 target, ref Float4 velocity, float smoothTime, float deltaTime) => Damp(target, ref velocity, (Float4)smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Reflect(Float4 normal) => -2f * Dot(normal) * normal + this;

#endregion

#region Static

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Dot(Float4 first, Float4 second) => first.Dot(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double DotDouble(Float4 first, Float4 second) => first.DotDouble(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Min(Float4 first, Float4 second) => first.Min(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Max(Float4 first, Float4 second) => first.Max(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Clamp(Float4 value, Float4 min, Float4 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Clamp(Float4 value, float min, float max) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 ClampMagnitude(Float4 value, float max) => value.ClampMagnitude(max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Lerp(Float4 first, Float4 second, Float4 value) => first.Lerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Lerp(Float4 first, Float4 second, float value) => first.Lerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 InverseLerp(Float4 first, Float4 second, Float4 value) => first.InverseLerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 InverseLerp(Float4 first, Float4 second, float value) => first.InverseLerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Repeat(Float4 value, Float4 length) => value.Repeat(length);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Repeat(Float4 value, float length) => value.Repeat(length);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Damp(Float4 current, Float4 target, ref Float4 velocity, Float4 smoothTime, float deltaTime) => current.Damp(target, ref velocity, smoothTime, deltaTime);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Damp(Float4 current, Float4 target, ref Float4 velocity, float smoothTime, float deltaTime) => current.Damp(target, ref velocity, smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Reflect(Float4 value, Float4 normal) => value.Reflect(normal);

#endregion

#region Create

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Float4 Create(int index, float value)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 3 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Float4 result = default;
				((float*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Float4(value, 0f, 0f, 0f);
				case 1:  return new Float4(0f, value, 0f, 0f);
				case 2:  return new Float4(0f, 0f, value, 0f);
				case 3:  return new Float4(0f, 0f, 0f, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Float4 Create(int index, float value, float other)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 3 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Float4 result = new Float4(other, other, other, other);
				((float*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Float4(value, other, other, other);
				case 1:  return new Float4(other, value, other, other);
				case 2:  return new Float4(other, other, value, other);
				case 3:  return new Float4(other, other, other, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float4 Replace(int index, float value)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (index < 0 || 3 < index) throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);

				Float4 result = this; //Make a copy of this struct
				((float*)&result)[index] = value;

				return result;
			}
#else
			switch (index)
			{
				case 0:  return new Float4(value, y, z, w);
				case 1:  return new Float4(x, value, z, w);
				case 2:  return new Float4(x, y, value, w);
				case 3:  return new Float4(x, y, z, value);
				default: throw ExceptionHelper.Invalid(nameof(index), index, InvalidType.outOfBounds);
			}
#endif
		}

#if CODEHELPERS_UNITY
		public UnityEngine.Vector4 U() => new UnityEngine.Vector4(x, y, z, w);
#endif

#endregion

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator +(Float4 first, Float4 second) => new Float4(first.x + second.x, first.y + second.y, first.z + second.z, first.w + second.w);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator -(Float4 first, Float4 second) => new Float4(first.x - second.x, first.y - second.y, first.z - second.z, first.w - second.w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator *(Float4 first, Float4 second) => new Float4(first.x * second.x, first.y * second.y, first.z * second.z, first.w * second.w);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator /(Float4 first, Float4 second) => new Float4(first.x / second.x, first.y / second.y, first.z / second.z, first.w / second.w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator *(Float4 first, float second) => new Float4(first.x * second, first.y * second, first.z * second, first.w * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator /(Float4 first, float second) => new Float4(first.x / second, first.y / second, first.z / second, first.w / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator *(float first, Float4 second) => new Float4(first * second.x, first * second.y, first * second.z, first * second.w);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator /(float first, Float4 second) => new Float4(first / second.x, first / second.y, first / second.z, first / second.w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator +(Float4 value) => value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator -(Float4 value) => new Float4(-value.x, -value.y, -value.z, -value.w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator %(Float4 first, Float4 second) => new Float4(first.x % second.x, first.y % second.y, first.z % second.z, first.w % second.w);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator %(Float4 first, float second) => new Float4(first.x % second, first.y % second, first.z % second, first.w % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator %(float first, Float4 second) => new Float4(first % second.x, first % second.y, first % second.z, first % second.w);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Float4 first, Float4 second) => first.Equals(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Float4 first, Float4 second) => !first.Equals(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool EqualsExact(Float4 other) => x == other.x && y == other.y && z == other.z && w == other.w;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Float4 other && Equals(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Float4 other)
		{
			double dx = x - other.x;
			double dy = y - other.y;
			double dz = z - other.z;
			double dw = w - other.w;
			return AlmostEqualsZero(dx * dx + dy * dy + dz * dz + dw * dw);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator Float4(float value) => new Float4(value, value, value, value);

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float4(UnityEngine.Vector4 value) => new Float4(value.x, value.y, value.z, value.w);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Vector4(Float4 value) => new UnityEngine.Vector4(value.x, value.y, value.z, value.w);
#endif

		[MethodImpl(MethodImplOptions.AggressiveInlining)] static bool AlmostEqualsZero(double squaredMagnitude) => Scalars.AlmostEquals(squaredMagnitude, 0d);

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

		public readonly struct SeriesEnumerable : IEnumerable<float>
		{
			public SeriesEnumerable(Float4 value) => enumerator = new Enumerator(value);

			readonly Enumerator enumerator;

			public Enumerator GetEnumerator() => enumerator;

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			IEnumerator<float> IEnumerable<float>.GetEnumerator() => GetEnumerator();

			public struct Enumerator : IEnumerator<float>
			{
				public Enumerator(Float4 source)
				{
					this.source = source;
					index = -1;
				}

				readonly Float4 source;
				int index;

				object IEnumerator.Current => Current;
				public float Current => source[index];

				public bool MoveNext() => index++ < 3;
				public void Reset() => index = -1;

				public void Dispose() { }
			}
		}

#endregion

	}
}