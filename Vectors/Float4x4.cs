using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeHelpers;
using CodeHelpers.Vectors;

namespace ForceRenderer.CodeHelpers.Vectors
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
				switch (x)
				{
					case 0:
					{
						switch (y)
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
						switch (y)
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
						switch (y)
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
						switch (y)
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

#region Static Properties

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

				if (Scalars.AlmostEquals(determinant, 0f))
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

		public Float3 MultiplyPoint(Float3 point) => new Float3
		(
			f00 * point.x + f01 * point.y + f02 * point.z + f03, f10 * point.x + f11 * point.y + f12 * point.z + f13, f20 * point.x + f21 * point.y + f22 * point.z + f23
		);

		public Float3 MultiplyDirection(Float3 point) => new Float3
		(
			f00 * point.x + f01 * point.y + f02 * point.z, f10 * point.x + f11 * point.y + f12 * point.z, f20 * point.x + f21 * point.y + f22 * point.z
		);

		public static Float4x4 Position(Float3 position) => new Float4x4
		(
			1f, 0f, 0f, position.x,
			0f, 1f, 0f, position.y,
			0f, 0f, 1f, position.z,
			0f, 0f, 0f, 1f
		);

		/// <summary>
		/// Returns a rotational matrix that applies in ZXY order.
		/// </summary>
		public static Float4x4 Rotation(Float3 rotation)
		{
			float radZ = rotation.z * Scalars.DegreeToRadian;
			float radX = rotation.x * Scalars.DegreeToRadian;
			float radY = rotation.y * Scalars.DegreeToRadian;

			float sinZ = (float)Math.Sin(radZ);
			float cosZ = (float)Math.Cos(radZ);

			float sinX = (float)Math.Sin(radX);
			float cosX = (float)Math.Cos(radX);

			float sinY = (float)Math.Sin(radY);
			float cosY = (float)Math.Cos(radY);

			//NOTE: Currently rotation is implemented with 3 separate matrices then multiplying them together
			//We can improve the performance by directly merging all 3, but I really do not want to do that right now!

			Float4x4 z = new Float4x4
			(
				cosZ, -sinZ, 0f, 0f,
				sinZ, cosZ, 0f, 0f,
				0f, 0f, 1f, 0f,
				0f, 0f, 0f, 1f
			);

			Float4x4 x = new Float4x4
			(
				1f, 0f, 0f, 0f,
				0f, cosX, -sinX, 0f,
				0f, sinX, cosX, 0f,
				0f, 0f, 0f, 1f
			);

			Float4x4 y = new Float4x4
			(
				cosY, 0f, sinY, 0f,
				0f, 1f, 0f, 0f,
				-sinY, 0f, cosY, 0f,
				0f, 0f, 0f, 1f
			);

			return y * x * z; //Matrix multiplication order is reversed
		}

		public static Float4x4 Scale(Float3 scale) => new Float4x4
		(
			scale.x, 0f, 0f, 0f,
			0f, scale.y, 0f, 0f,
			0f, 0f, scale.z, 0f,
			0f, 0f, 0f, 1f
		);

		/// <summary>
		/// Returns a combined transformation matrix. Scaling is applied first, then rotation, finally translation.
		/// </summary>
		public static Float4x4 Transformation(Float3 position, Float3 rotation, Float3 scale) => Position(position) * Rotation(rotation) * Scale(scale);

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Float4x4 operator *(in Float4x4 l, in Float4x4 r) => new Float4x4
		(
			l.f00 * r.f00 + l.f01 * r.f10 + l.f02 * r.f20 + l.f03 * r.f30, l.f00 * r.f01 + l.f01 * r.f11 + l.f02 * r.f21 + l.f03 * r.f31, l.f00 * r.f02 + l.f01 * r.f12 + l.f02 * r.f22 + l.f03 * r.f32, l.f00 * r.f03 + l.f01 * r.f13 + l.f02 * r.f23 + l.f03 * r.f33,
			l.f10 * r.f00 + l.f11 * r.f10 + l.f12 * r.f20 + l.f13 * r.f30, l.f10 * r.f01 + l.f11 * r.f11 + l.f12 * r.f21 + l.f13 * r.f31, l.f10 * r.f02 + l.f11 * r.f12 + l.f12 * r.f22 + l.f13 * r.f32, l.f10 * r.f03 + l.f11 * r.f13 + l.f12 * r.f23 + l.f13 * r.f33,
			l.f20 * r.f00 + l.f21 * r.f10 + l.f22 * r.f20 + l.f23 * r.f30, l.f20 * r.f01 + l.f21 * r.f11 + l.f22 * r.f21 + l.f23 * r.f31, l.f20 * r.f02 + l.f21 * r.f12 + l.f22 * r.f22 + l.f23 * r.f32, l.f20 * r.f03 + l.f21 * r.f13 + l.f22 * r.f23 + l.f23 * r.f33,
			l.f30 * r.f00 + l.f31 * r.f10 + l.f32 * r.f20 + l.f33 * r.f30, l.f30 * r.f01 + l.f31 * r.f11 + l.f32 * r.f21 + l.f33 * r.f31, l.f30 * r.f02 + l.f31 * r.f12 + l.f32 * r.f22 + l.f33 * r.f32, l.f30 * r.f03 + l.f31 * r.f13 + l.f32 * r.f23 + l.f33 * r.f33
		);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Float4 operator *(in Float4x4 first, Float4 second) => new Float4
		(
			first.f00 * second.x + first.f01 * second.y + first.f02 * second.z + first.f03 * second.w,
			first.f10 * second.x + first.f11 * second.y + first.f12 * second.z + first.f13 * second.w,
			first.f20 * second.x + first.f21 * second.y + first.f22 * second.z + first.f23 * second.w,
			first.f30 * second.x + first.f31 * second.y + first.f32 * second.z + first.f33 * second.w
		);

		public static bool operator ==(in Float4x4 first, in Float4x4 second) => first.Equals(second);
		public static bool operator !=(in Float4x4 first, in Float4x4 second) => !first.Equals(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool EqualsFast(in Float4x4 other) => Scalars.AlmostEquals(f00, other.f00) && Scalars.AlmostEquals(f01, other.f01) && Scalars.AlmostEquals(f02, other.f02) && Scalars.AlmostEquals(f03, other.f03) &&
													 Scalars.AlmostEquals(f10, other.f10) && Scalars.AlmostEquals(f11, other.f11) && Scalars.AlmostEquals(f12, other.f12) && Scalars.AlmostEquals(f13, other.f13) &&
													 Scalars.AlmostEquals(f20, other.f20) && Scalars.AlmostEquals(f21, other.f21) && Scalars.AlmostEquals(f22, other.f22) && Scalars.AlmostEquals(f23, other.f23) &&
													 Scalars.AlmostEquals(f30, other.f30) && Scalars.AlmostEquals(f31, other.f31) && Scalars.AlmostEquals(f32, other.f32) && Scalars.AlmostEquals(f33, other.f33);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool EqualsExact(in Float4x4 other) => f00 == other.f00 && f01 == other.f01 && f02 == other.f02 && f03 == other.f03 &&
													  f10 == other.f10 && f11 == other.f11 && f12 == other.f12 && f13 == other.f13 &&
													  f20 == other.f20 && f21 == other.f21 && f22 == other.f22 && f23 == other.f23 &&
													  f30 == other.f30 && f31 == other.f31 && f32 == other.f32 && f33 == other.f33;

		public override bool Equals(object obj) => obj is Float4x4 other && EqualsFast(other);
		public bool Equals(Float4x4 other) => EqualsFast(other);

#endregion

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			var hashCode = new HashCode();

			hashCode.Add(f00);
			hashCode.Add(f01);
			hashCode.Add(f02);
			hashCode.Add(f03);

			hashCode.Add(f10);
			hashCode.Add(f11);
			hashCode.Add(f12);
			hashCode.Add(f13);

			hashCode.Add(f20);
			hashCode.Add(f21);
			hashCode.Add(f22);
			hashCode.Add(f23);

			hashCode.Add(f30);
			hashCode.Add(f31);
			hashCode.Add(f32);
			hashCode.Add(f33);

			return hashCode.ToHashCode();
		}

		public override string ToString() => ToString(string.Empty);
		public string ToString(string format) => ToString(format, CultureInfo.InvariantCulture);

		public string ToString(string format, IFormatProvider formatProvider) =>
			$"{f00.ToString(format, formatProvider)}\t{f01.ToString(format, formatProvider)}\t{f02.ToString(format, formatProvider)}\t{f03.ToString(format, formatProvider)}\n" +
			$"{f10.ToString(format, formatProvider)}\t{f11.ToString(format, formatProvider)}\t{f12.ToString(format, formatProvider)}\t{f13.ToString(format, formatProvider)}\n" +
			$"{f20.ToString(format, formatProvider)}\t{f21.ToString(format, formatProvider)}\t{f22.ToString(format, formatProvider)}\t{f23.ToString(format, formatProvider)}\n" +
			$"{f30.ToString(format, formatProvider)}\t{f31.ToString(format, formatProvider)}\t{f32.ToString(format, formatProvider)}\t{f33.ToString(format, formatProvider)}\n";
	}
}