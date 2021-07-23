using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CodeHelpers.Mathematics
{
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Float4x4 : IEquatable<Float4x4>, IFormattable
	{
		public Float4x4(float f00, float f01, float f02, float f03,
						float f10, float f11, float f12, float f13,
						float f20, float f21, float f22, float f23,
						float f30, float f31, float f32, float f33)
		{
			this.f00 = f00;
			this.f01 = f01;
			this.f02 = f02;
			this.f03 = f03;

			this.f10 = f10;
			this.f11 = f11;
			this.f12 = f12;
			this.f13 = f13;

			this.f20 = f20;
			this.f21 = f21;
			this.f22 = f22;
			this.f23 = f23;

			this.f30 = f30;
			this.f31 = f31;
			this.f32 = f32;
			this.f33 = f33;
		}

		public Float4x4(in Float4x4 source) : this
		(
			source.f00, source.f01, source.f02, source.f03,
			source.f10, source.f11, source.f12, source.f13,
			source.f20, source.f21, source.f22, source.f23,
			source.f30, source.f31, source.f32, source.f33
		) { }

		public Float4x4(in Float4 row0, in Float4 row1, in Float4 row2, in Float4 row3) : this
		(
			row0.x, row0.y, row0.z, row0.w,
			row1.x, row1.y, row1.z, row1.w,
			row2.x, row2.y, row2.z, row2.w,
			row3.x, row3.y, row3.z, row3.w
		) { }

		// 00 01 02 03
		// 10 11 12 13
		// 20 21 22 23
		// 30 31 32 33

		public readonly float f00;
		public readonly float f01;
		public readonly float f02;
		public readonly float f03;

		public readonly float f10;
		public readonly float f11;
		public readonly float f12;
		public readonly float f13;

		public readonly float f20;
		public readonly float f21;
		public readonly float f22;
		public readonly float f23;

		public readonly float f30;
		public readonly float f31;
		public readonly float f32;
		public readonly float f33;

		public float this[int row, int column]
		{
			get
			{
#if UNSAFE_CODE_ENABLED
				unsafe
				{
					if (row < 0 || 3 < row || column < 0 || 3 < column) throw ExceptionHelper.Invalid($"{nameof(row)} or {nameof(column)}", new Int2(row, column), InvalidType.outOfBounds);
					fixed (Float4x4* pointer = &this) return ((float*)pointer)[row * 4 + column];
				}
#else
				switch (row)
				{
					case 0:
					{
						switch (column)
						{
							case 0: return f00;
							case 1: return f01;
							case 2: return f02;
							case 3: return f03;
						}

						break;
					}
					case 1:
					{
						switch (column)
						{
							case 0: return f10;
							case 1: return f11;
							case 2: return f12;
							case 3: return f13;
						}

						break;
					}
					case 2:
					{
						switch (column)
						{
							case 0: return f20;
							case 1: return f21;
							case 2: return f22;
							case 3: return f23;
						}

						break;
					}
					case 3:
					{
						switch (column)
						{
							case 0: return f30;
							case 1: return f31;
							case 2: return f32;
							case 3: return f33;
						}

						break;
					}
				}

				throw ExceptionHelper.Invalid($"{nameof(row)} or {nameof(column)}", new Int2(row, column), InvalidType.outOfBounds);
#endif
			}
		}

		public Float4 GetRow(int row)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (row < 0 || 3 < row) throw ExceptionHelper.Invalid(nameof(row), row, InvalidType.outOfBounds);
				fixed (Float4x4* pointer = &this) return ((Float4*)pointer)[row];
			}
#else
			switch (row)
			{
				case 0: return new Float4(f00, f01, f02, f03);
				case 1: return new Float4(f10, f11, f12, f13);
				case 2: return new Float4(f20, f21, f22, f23);
				case 3: return new Float4(f30, f31, f32, f33);
			}

			throw ExceptionHelper.Invalid(nameof(row), row, InvalidType.outOfBounds);
#endif
		}

		public Float4 GetColumn(int column)
		{
#if UNSAFE_CODE_ENABLED
			unsafe
			{
				if (column < 0 || 3 < column) throw ExceptionHelper.Invalid(nameof(column), column, InvalidType.outOfBounds);

				fixed (Float4x4* pointer = &this)
				{
					float* p = (float*)pointer;
					return new Float4(p[column], p[column + 4], p[column + 8], p[column + 12]);
				}
			}
#else
			switch (column)
			{
				case 0: return new Float4(f00, f10, f20, f30);
				case 1: return new Float4(f01, f11, f21, f31);
				case 2: return new Float4(f02, f12, f22, f32);
				case 3: return new Float4(f03, f13, f23, f33);
			}

			throw ExceptionHelper.Invalid(nameof(column), column, InvalidType.outOfBounds);
#endif
		}

#region Static Properties

		/// <summary>
		/// The idempotent <see cref="Float4x4"/> value.
		/// </summary>
		public static readonly Float4x4 identity = new Float4x4
		(
			1f, 0f, 0f, 0f,
			0f, 1f, 0f, 0f,
			0f, 0f, 1f, 0f,
			0f, 0f, 0f, 1f
		);

#endregion

#region Instance Properties

		public float Determinant
		{
			get
			{
				// 00 01 02 03
				// 10 11 12 13
				// 20 21 22 23
				// 30 31 32 33

				//2x2 determinants
				float d21_32 = f21 * f32 - f22 * f31;
				float d21_33 = f21 * f33 - f23 * f31;
				float d22_33 = f22 * f33 - f23 * f32;

				float d20_31 = f20 * f31 - f21 * f30;
				float d20_32 = f20 * f32 - f22 * f30;
				float d20_33 = f20 * f33 - f23 * f30;

				//First row mirrors
				float m00 = f11 * d22_33 - f12 * d21_33 + f13 * d21_32;
				float m01 = f10 * d22_33 - f12 * d20_33 + f13 * d20_32;
				float m02 = f10 * d21_33 - f11 * d20_33 + f13 * d20_31;
				float m03 = f10 * d21_32 - f11 * d20_32 + f12 * d20_31;

				return f00 * m00 - f01 * m01 + f02 * m02 - f03 * m03;
			}
		}

		public Float4x4 Absoluted => new Float4x4
		(
			Math.Abs(f00), Math.Abs(f01), Math.Abs(f02), Math.Abs(f03),
			Math.Abs(f10), Math.Abs(f11), Math.Abs(f12), Math.Abs(f13),
			Math.Abs(f20), Math.Abs(f21), Math.Abs(f22), Math.Abs(f23),
			Math.Abs(f30), Math.Abs(f31), Math.Abs(f32), Math.Abs(f33)
		);

		public Float4x4 Transposed => new Float4x4
		(
			f00, f10, f20, f30,
			f01, f11, f21, f31,
			f02, f12, f22, f32,
			f03, f13, f23, f33
		);

		public Float4x4 Inversed
		{
			get
			{
				// 00 01 02 03
				// 10 11 12 13
				// 20 21 22 23
				// 30 31 32 33

				//2x2 determinants
				float d21_32 = f21 * f32 - f22 * f31;
				float d21_33 = f21 * f33 - f23 * f31;
				float d22_33 = f22 * f33 - f23 * f32;

				float d20_31 = f20 * f31 - f21 * f30;
				float d20_32 = f20 * f32 - f22 * f30;
				float d20_33 = f20 * f33 - f23 * f30;

				//First row mirrors
				float m00 = f11 * d22_33 - f12 * d21_33 + f13 * d21_32;
				float m01 = f10 * d22_33 - f12 * d20_33 + f13 * d20_32;
				float m02 = f10 * d21_33 - f11 * d20_33 + f13 * d20_31;
				float m03 = f10 * d21_32 - f11 * d20_32 + f12 * d20_31;

				float determinant = f00 * m00 - f01 * m01 + f02 * m02 - f03 * m03;

				if (determinant.AlmostEquals())
				{
					//Invalid inverse
					return new Float4x4
					(
						float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN,
						float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN
					);
				}

				//Second row mirrors
				float m10 = f01 * d22_33 - f02 * d21_33 + f03 * d21_32;
				float m11 = f00 * d22_33 - f02 * d20_33 + f03 * d20_32;
				float m12 = f00 * d21_33 - f01 * d20_33 + f03 * d20_31;
				float m13 = f00 * d21_32 - f01 * d20_32 + f02 * d20_31;

				//2x2 determinants
				float d01_12 = f01 * f12 - f02 * f11;
				float d01_13 = f01 * f13 - f03 * f11;
				float d02_13 = f02 * f13 - f03 * f12;

				float d00_11 = f00 * f11 - f01 * f10;
				float d00_12 = f00 * f12 - f02 * f10;
				float d00_13 = f00 * f13 - f03 * f10;

				//Third row mirrors
				float m20 = f31 * d02_13 - f32 * d01_13 + f33 * d01_12;
				float m21 = f30 * d02_13 - f32 * d00_13 + f33 * d00_12;
				float m22 = f30 * d01_13 - f31 * d00_13 + f33 * d00_11;
				float m23 = f30 * d01_12 - f31 * d00_12 + f32 * d00_11;

				//Fourth row mirrors
				float m30 = f21 * d02_13 - f22 * d01_13 + f23 * d01_12;
				float m31 = f20 * d02_13 - f22 * d00_13 + f23 * d00_12;
				float m32 = f20 * d01_13 - f21 * d00_13 + f23 * d00_11;
				float m33 = f20 * d01_12 - f21 * d00_12 + f22 * d00_11;

				float oneOver = 1f / determinant;

				return new Float4x4
				(
					m00 * oneOver, -m10 * oneOver, m20 * oneOver, -m30 * oneOver,
					-m01 * oneOver, m11 * oneOver, -m21 * oneOver, m31 * oneOver,
					m02 * oneOver, -m12 * oneOver, m22 * oneOver, -m32 * oneOver,
					-m03 * oneOver, m13 * oneOver, -m23 * oneOver, m33 * oneOver
				);
			}
		}

#endregion

		public Float3 MultiplyPoint(in Float3 point) => new Float3
		(
			f00 * point.x + f01 * point.y + f02 * point.z + f03, f10 * point.x + f11 * point.y + f12 * point.z + f13, f20 * point.x + f21 * point.y + f22 * point.z + f23
		);

		public Float3 MultiplyDirection(in Float3 direction) => new Float3
		(
			f00 * direction.x + f01 * direction.y + f02 * direction.z, f10 * direction.x + f11 * direction.y + f12 * direction.z, f20 * direction.x + f21 * direction.y + f22 * direction.z
		);

		public void MultiplyBounds(ref Float3 center, ref Float3 extend)
		{
			center = MultiplyPoint(center);
			extend = Absoluted.MultiplyDirection(extend);
		}

		public static Float4x4 Position(in Float3 position) => new Float4x4
		(
			1f, 0f, 0f, position.x,
			0f, 1f, 0f, position.y,
			0f, 0f, 1f, position.z,
			0f, 0f, 0f, 1f
		);

		/// <summary>
		/// Returns a rotational matrix that applies in ZXY order.
		/// </summary>
		public static Float4x4 Rotation(in Float3 rotation)
		{
			float radX = rotation.x * Scalars.DegreeToRadian;
			float radY = rotation.y * Scalars.DegreeToRadian;
			float radZ = rotation.z * Scalars.DegreeToRadian;

			float sinX = (float)Math.Sin(radX);
			float cosX = (float)Math.Cos(radX);

			float sinY = (float)Math.Sin(radY);
			float cosY = (float)Math.Cos(radY);

			float sinZ = (float)Math.Sin(radZ);
			float cosZ = (float)Math.Cos(radZ);

			return new Float4x4 //Multiplied with order yxz because matrix multiplication order is reversed
			(
				cosY * cosZ + sinY * sinX * sinZ, cosY * -sinZ + sinY * sinX * cosZ, sinY * cosX, 0f,
				cosX * sinZ, cosX * cosZ, -sinX, 0f,
				-sinY * cosZ + cosY * sinX * sinZ, sinY * sinZ + cosY * sinX * cosZ, cosY * cosX, 0f,
				0f, 0f, 0f, 1f
			);
		}

		public static Float4x4 Scale(in Float3 scale) => new Float4x4
		(
			scale.x, 0f, 0f, 0f,
			0f, scale.y, 0f, 0f,
			0f, 0f, scale.z, 0f,
			0f, 0f, 0f, 1f
		);

		/// <summary>
		/// Returns a combined transformation matrix. Scaling is applied first, then rotation, finally translation.
		/// </summary>
		public static Float4x4 Transformation(in Float3 position, in Float3 rotation, in Float3 scale) => Position(position) * Rotation(rotation) * Scale(scale);

		/// <summary>
		/// Creates a rotation matrix out of a quaternion.
		/// </summary>
		public static Float4x4 Rotation(in Float4 quaternion)
		{
			Float4 q = quaternion.Normalized;

			float xx = q.x * q.x * 2f;
			float xy = q.x * q.y * 2f;
			float xz = q.x * q.z * 2f;
			float xw = q.x * q.w * 2f;

			float yy = q.y * q.y * 2f;
			float yz = q.y * q.z * 2f;
			float yw = q.y * q.w * 2f;

			float zz = q.z * q.z * 2f;
			float zw = q.z * q.w * 2f;

			return new Float4x4
			(
				1f - yy - zz, xy - zw, xz + yw, 0f,
				xy + zw, 1f - xx - zz, yz - xw, 0f,
				xz - yw, yz + xw, 1f - xx - yy, 0f,
				0f, 0f, 0f, 1f
			);
		}

		/// <summary>
		/// Returns random matrix for debug purposes; will be removed.
		/// </summary>
		public static Float4x4 GetRandom(float min = -1000f, float max = 1000f) => new Float4x4
		(
			RandomHelper.Range(min, max), RandomHelper.Range(min, max), RandomHelper.Range(min, max), RandomHelper.Range(min, max),
			RandomHelper.Range(min, max), RandomHelper.Range(min, max), RandomHelper.Range(min, max), RandomHelper.Range(min, max),
			RandomHelper.Range(min, max), RandomHelper.Range(min, max), RandomHelper.Range(min, max), RandomHelper.Range(min, max),
			RandomHelper.Range(min, max), RandomHelper.Range(min, max), RandomHelper.Range(min, max), RandomHelper.Range(min, max)
		);

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Float4x4 operator *(in Float4x4 first, in Float4x4 second) => new Float4x4
		(
			first.f00 * second.f00 + first.f01 * second.f10 + first.f02 * second.f20 + first.f03 * second.f30, first.f00 * second.f01 + first.f01 * second.f11 + first.f02 * second.f21 + first.f03 * second.f31, first.f00 * second.f02 + first.f01 * second.f12 + first.f02 * second.f22 + first.f03 * second.f32, first.f00 * second.f03 + first.f01 * second.f13 + first.f02 * second.f23 + first.f03 * second.f33,
			first.f10 * second.f00 + first.f11 * second.f10 + first.f12 * second.f20 + first.f13 * second.f30, first.f10 * second.f01 + first.f11 * second.f11 + first.f12 * second.f21 + first.f13 * second.f31, first.f10 * second.f02 + first.f11 * second.f12 + first.f12 * second.f22 + first.f13 * second.f32, first.f10 * second.f03 + first.f11 * second.f13 + first.f12 * second.f23 + first.f13 * second.f33,
			first.f20 * second.f00 + first.f21 * second.f10 + first.f22 * second.f20 + first.f23 * second.f30, first.f20 * second.f01 + first.f21 * second.f11 + first.f22 * second.f21 + first.f23 * second.f31, first.f20 * second.f02 + first.f21 * second.f12 + first.f22 * second.f22 + first.f23 * second.f32, first.f20 * second.f03 + first.f21 * second.f13 + first.f22 * second.f23 + first.f23 * second.f33,
			first.f30 * second.f00 + first.f31 * second.f10 + first.f32 * second.f20 + first.f33 * second.f30, first.f30 * second.f01 + first.f31 * second.f11 + first.f32 * second.f21 + first.f33 * second.f31, first.f30 * second.f02 + first.f31 * second.f12 + first.f32 * second.f22 + first.f33 * second.f32, first.f30 * second.f03 + first.f31 * second.f13 + first.f32 * second.f23 + first.f33 * second.f33
		);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Float4 operator *(in Float4x4 first, in Float4 second) => new Float4
		(
			first.f00 * second.x + first.f01 * second.y + first.f02 * second.z + first.f03 * second.w,
			first.f10 * second.x + first.f11 * second.y + first.f12 * second.z + first.f13 * second.w,
			first.f20 * second.x + first.f21 * second.y + first.f22 * second.z + first.f23 * second.w,
			first.f30 * second.x + first.f31 * second.y + first.f32 * second.z + first.f33 * second.w
		);

		public static bool operator ==(in Float4x4 first, in Float4x4 second) => first.EqualsFast(second);
		public static bool operator !=(in Float4x4 first, in Float4x4 second) => !first.EqualsFast(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool EqualsFast(in Float4x4 other) => f00.AlmostEquals(other.f00) && f01.AlmostEquals(other.f01) && f02.AlmostEquals(other.f02) && f03.AlmostEquals(other.f03) &&
													 f10.AlmostEquals(other.f10) && f11.AlmostEquals(other.f11) && f12.AlmostEquals(other.f12) && f13.AlmostEquals(other.f13) &&
													 f20.AlmostEquals(other.f20) && f21.AlmostEquals(other.f21) && f22.AlmostEquals(other.f22) && f23.AlmostEquals(other.f23) &&
													 f30.AlmostEquals(other.f30) && f31.AlmostEquals(other.f31) && f32.AlmostEquals(other.f32) && f33.AlmostEquals(other.f33);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool EqualsExact(in Float4x4 other) => f00 == other.f00 && f01 == other.f01 && f02 == other.f02 && f03 == other.f03 &&
													  f10 == other.f10 && f11 == other.f11 && f12 == other.f12 && f13 == other.f13 &&
													  f20 == other.f20 && f21 == other.f21 && f22 == other.f22 && f23 == other.f23 &&
													  f30 == other.f30 && f31 == other.f31 && f32 == other.f32 && f33 == other.f33;

		public override bool Equals(object obj) => obj is Float4x4 other && EqualsFast(other);
		public bool Equals(Float4x4 other) => EqualsFast(other);

#if CODEHELPERS_UNITY
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Float4x4(in UnityEngine.Matrix4x4 value) => new Float4x4
		(
			value.m00, value.m01, value.m02, value.m03,
			value.m10, value.m11, value.m12, value.m13,
			value.m20, value.m21, value.m22, value.m23,
			value.m30, value.m31, value.m32, value.m33
		);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnityEngine.Matrix4x4(in Float4x4 value) => new UnityEngine.Matrix4x4
		(
			new UnityEngine.Vector4(value.f00, value.f10, value.f20, value.f30),
			new UnityEngine.Vector4(value.f01, value.f11, value.f21, value.f31),
			new UnityEngine.Vector4(value.f02, value.f12, value.f22, value.f32),
			new UnityEngine.Vector4(value.f03, value.f13, value.f23, value.f33)
		);
#endif

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = f00.GetHashCode();
				hashCode = (hashCode * 397) ^ f01.GetHashCode();
				hashCode = (hashCode * 397) ^ f02.GetHashCode();
				hashCode = (hashCode * 397) ^ f03.GetHashCode();
				hashCode = (hashCode * 397) ^ f10.GetHashCode();
				hashCode = (hashCode * 397) ^ f11.GetHashCode();
				hashCode = (hashCode * 397) ^ f12.GetHashCode();
				hashCode = (hashCode * 397) ^ f13.GetHashCode();
				hashCode = (hashCode * 397) ^ f20.GetHashCode();
				hashCode = (hashCode * 397) ^ f21.GetHashCode();
				hashCode = (hashCode * 397) ^ f22.GetHashCode();
				hashCode = (hashCode * 397) ^ f23.GetHashCode();
				hashCode = (hashCode * 397) ^ f30.GetHashCode();
				hashCode = (hashCode * 397) ^ f31.GetHashCode();
				hashCode = (hashCode * 397) ^ f32.GetHashCode();
				hashCode = (hashCode * 397) ^ f33.GetHashCode();
				return hashCode;
			}
		}

#endregion

		public override string ToString() => ToString(string.Empty);
		public string ToString(string format) => ToString(format, CultureInfo.InvariantCulture);

		public string ToString(string format, IFormatProvider formatProvider) =>
			$"{f00.ToString(format, formatProvider)}\t{f01.ToString(format, formatProvider)}\t{f02.ToString(format, formatProvider)}\t{f03.ToString(format, formatProvider)}\n" +
			$"{f10.ToString(format, formatProvider)}\t{f11.ToString(format, formatProvider)}\t{f12.ToString(format, formatProvider)}\t{f13.ToString(format, formatProvider)}\n" +
			$"{f20.ToString(format, formatProvider)}\t{f21.ToString(format, formatProvider)}\t{f22.ToString(format, formatProvider)}\t{f23.ToString(format, formatProvider)}\n" +
			$"{f30.ToString(format, formatProvider)}\t{f31.ToString(format, formatProvider)}\t{f32.ToString(format, formatProvider)}\t{f33.ToString(format, formatProvider)}\n";
	}
}