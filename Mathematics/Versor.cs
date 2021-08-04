using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CodeHelpers.Mathematics
{
	/// <summary>
	/// A unit-length quaternion for 3D ZXY rotation.
	/// </summary>
	public readonly struct Versor : IEquatable<Versor>, IFormattable
	{
		/// <summary>
		/// Creates a <see cref="Versor"/> in the ZXY rotation order.
		/// </summary>
		public Versor(float angleX, float angleY, float angleZ) : this(new Float3(angleX, angleY, angleZ)) { }

		/// <summary>
		/// Creates a <see cref="Versor"/> in the ZXY rotation order.
		/// </summary>
		public Versor(Float3 angles) : this(CreateSin(angles *= Scalars.DegreeToRadian / 2f), CreateCos(angles)) { }

		static Float3 CreateSin(in Float3 radians) => new Float3((float)Math.Sin(radians.x), (float)Math.Sin(radians.y), (float)Math.Sin(radians.z));
		static Float3 CreateCos(in Float3 radians) => new Float3((float)Math.Cos(radians.x), (float)Math.Cos(radians.y), (float)Math.Cos(radians.z));

		/// <summary>
		/// Creates a <see cref="Versor"/> in the ZXY rotation order based on XYZ sin and cos values.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal Versor(in Float3 sin, in Float3 cos) => d = new Float4
														 (
															 sin.x * cos.y * cos.z - cos.x * sin.y * sin.z,
															 cos.x * sin.y * cos.z + sin.x * cos.y * sin.z,
															 cos.x * cos.y * sin.z - sin.x * sin.y * cos.z,
															 cos.x * cos.y * cos.z + sin.x * sin.y * sin.z
														 );

		/// <summary>
		/// Creates a <see cref="Versor"/> from an <paramref name="axis"/> and an <paramref name="angle"/>.
		/// </summary>
		public Versor(Float3 axis, float angle)
		{
			float radians = Scalars.DegreeToRadian / 2f * angle;

			float sin = (float)Math.Sin(radians);
			float cos = (float)Math.Cos(radians);

			axis = axis.Normalized;

			d = new Float4
			(
				axis.x * sin,
				axis.y * sin,
				axis.z * sin,
				cos
			);
		}

		Versor(float x, float y, float z, float w) : this(new Float4(x, y, z, w)) { }
		Versor(in Float4 d) => this.d = d;

		readonly Float4 d;

		public static readonly Versor identity = new Versor(0f, 0f, 0f, 1f);

		public Versor Conjugate => new Versor(-d.x, -d.y, -d.z, d.w);
		public Versor Inverse => Conjugate;

		public Float3 Angles
		{
			get
			{
				float wx_yz = d.w * d.x + d.y * d.z;
				float xx_yy = d.x * d.x + d.y * d.y;

				float wy_zx = d.w * d.y - d.z * d.x;

				float wz_xy = d.w * d.z + d.x * d.y;
				float yy_zz = d.y * d.y + d.z * d.z;

				return new Float3
					   (
						   (float)Math.Atan2(2f * wx_yz, 1f - 2f * xx_yy),
						   (float)Math.Asin(wy_zx.Clamp(-0.5f, 0.5f) * 2f),
						   (float)Math.Atan2(2f * wz_xy, 1f - 2f * yy_zz)
					   ) * Scalars.RadianToDegree;
			}
		}

		public Versor Damp(in Versor target, ref Float4 velocity, float smoothTime, float deltaTime) => Damp(this, target, ref velocity, smoothTime, deltaTime);

		public static Versor Damp(in Versor current, in Versor target, ref Float4 velocity, float smoothTime, float deltaTime)
		{
			//Code based on: https://gist.github.com/maxattack/4c7b4de00f5c1b95a33b

			if (deltaTime < Scalars.Epsilon) return current;
			ref readonly Float4 currentD = ref current.d;

			Float4 targetD = target.d;

			if (currentD.Dot(targetD) < 0f) targetD = -targetD;

			Float4 result = currentD.Damp(targetD, ref velocity, smoothTime, deltaTime).Normalized;
			velocity -= velocity.Project(result);

			return new Versor(result);
		}

#if CODEHELPERS_UNITY
		public UnityEngine.Quaternion U() => this;
#endif

		public static Versor operator *(in Versor first, in Versor second) => Apply(first, second, false);
		public static Versor operator /(in Versor first, in Versor second) => Apply(first, second, true);

		public static Float3 operator *(in Versor first, in Float3 second) => Apply(first, second, false);
		public static Float3 operator /(in Versor first, in Float3 second) => Apply(first, second, true);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static Versor Apply(in Versor first, in Versor second, bool conjugate)
		{
			Float3 xyz0 = first.d.XYZ;
			Float3 xyz1 = second.d.XYZ;

			if (conjugate) xyz1 = -xyz1;

			float w0 = first.d.w;
			float w1 = second.d.w;

			Float3 cross = xyz0.Cross(xyz1);

			return new Versor
			(
				w0 * xyz1.x + w1 * xyz0.x + cross.x,
				w0 * xyz1.y + w1 * xyz0.y + cross.y,
				w0 * xyz1.z + w1 * xyz0.z + cross.z,
				w0 * w1 - xyz0.Dot(xyz1)
			);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static Float3 Apply(in Versor first, in Float3 second, bool conjugate)
		{
			ref readonly Float4 d = ref first.d;

			Float4 dd = d.Squared;
			Float3 dw = d.w * 2f * d.XYZ;
			Float2 dz = d.z * 2f * d.XY;
			float dy_x = d.y * 2f * d.x;

			if (conjugate) dw = -dw;

			return new Float3
			(
				dd.w * second.x + dw.y * second.z - dw.z * second.y + dd.x * second.x + dy_x * second.y + dz.x * second.z - dd.z * second.x - dd.y * second.x,
				dy_x * second.x + dd.y * second.y + dz.y * second.z + dw.z * second.x - dd.z * second.y + dd.w * second.y - dw.x * second.z - dd.x * second.y,
				dz.x * second.x + dz.y * second.y + dd.z * second.z - dw.y * second.x - dd.y * second.z + dw.x * second.y - dd.x * second.z + dd.w * second.z
			);
		}

		public static bool operator ==(Versor left, Versor right) => left.Equals(right);
		public static bool operator !=(Versor left, Versor right) => !left.Equals(right);

		public override bool Equals(object obj) => obj is Versor other && Equals(other);
		public bool Equals(Versor other) => d.Equals(other.d);
		public override int GetHashCode() => d.GetHashCode();

#if CODEHELPERS_UNITY
		public static implicit operator Versor(UnityEngine.Quaternion value) => new Versor(value.x, value.y, value.z, value.w);
		public static implicit operator UnityEngine.Quaternion(in Versor value) => new UnityEngine.Quaternion(value.d.x, value.d.y, value.d.z, value.d.w);
#endif

		public override string ToString() => d.ToString();

		public string ToString(string format) => ToString(format, CultureInfo.InvariantCulture);
		public string ToString(string format, IFormatProvider provider) => d.ToString(format, provider);
	}
}