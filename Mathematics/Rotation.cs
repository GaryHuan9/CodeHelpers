using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace CodeHelpers.Mathematics
{
	[StructLayout(LayoutKind.Explicit)] //Quaternion
	public readonly struct Rotation : IEquatable<Rotation>, IFormattable
	{
		/// <summary>
		/// Creates a <see cref="Rotation"/> in the ZXY rotation order.
		/// </summary>
		public Rotation(Float3 angles) : this(angles.x, angles.y, angles.z) { }

		/// <summary>
		/// Creates a <see cref="Rotation"/> in the ZXY rotation order.
		/// </summary>
		public Rotation(float angleX, float angleY, float angleZ)
		{
			float radiansX = angleX / 2f * Scalars.DegreeToRadian;
			float radiansY = angleY / 2f * Scalars.DegreeToRadian;
			float radiansZ = angleZ / 2f * Scalars.DegreeToRadian;

			float sinX = (float)Math.Sin(radiansX);
			float cosX = (float)Math.Cos(radiansX);

			float sinY = (float)Math.Sin(radiansY);
			float cosY = (float)Math.Cos(radiansY);

			float sinZ = (float)Math.Sin(radiansZ);
			float cosZ = (float)Math.Cos(radiansZ);

			d = new Float4
			(
				sinX * cosY * cosZ - cosX * sinY * sinZ,
				cosX * sinY * cosZ + sinX * cosY * sinZ,
				cosX * cosY * sinZ - sinX * sinY * cosZ,
				cosX * cosY * cosZ + sinX * sinY * sinZ
			);
		}

		/// <summary>
		/// Creates a <see cref="Rotation"/> from an <paramref name="axis"/> and an <paramref name="angle"/>.
		/// </summary>
		public Rotation(in Float3 axis, float angle)
		{
			float radians = angle / 2f * Scalars.DegreeToRadian;

			float sin = (float)Math.Sin(radians);
			float cos = (float)Math.Cos(radians);

			d = new Float4
			(
				axis.x * sin,
				axis.y * sin,
				axis.z * sin,
				cos
			);
		}

		Rotation(float x, float y, float z, float w) : this(new Float4(x, y, z, w)) { }
		Rotation(in Float4 d) => this.d = d;

		[FieldOffset(0)] readonly Float4 d;

		public static readonly Rotation identity = new Rotation(0f, 0f, 0f, 1f);

		public Rotation Normalized => new Rotation(d.Normalized);
		public Rotation Conjugate => new Rotation(-d.x, -d.y, -d.z, d.w);

		public Rotation Inverse => new Rotation(Conjugate.d / d.SquaredMagnitude);

		public Float3 Angles
		{
			get
			{
				float wxyz = d.w * d.x + d.y * d.z;
				float xxyy = d.x * d.x + d.y * d.y;

				float wyzx = d.w * d.y - d.z * d.x;

				float wzxy = d.w * d.z + d.x * d.y;
				float yyzz = d.y * d.y + d.z * d.z;

				return new Float3
					   (
						   (float)Math.Atan2(2f * wxyz, 1f - 2f * xxyy),
						   (float)Math.Asin(wyzx.Clamp(-0.5f, 0.5f) * 2f),
						   (float)Math.Atan2(2f * wzxy, 1f - 2f * yyzz)
					   ) * Scalars.RadianToDegree;
			}
		}

		public Rotation Damp(in Rotation target, ref Float4 velocity, float smoothTime, float deltaTime) => Damp(this, target, ref velocity, smoothTime, deltaTime);

		public static Rotation Damp(in Rotation current, in Rotation target, ref Float4 velocity, float smoothTime, float deltaTime)
		{
			//Code based on: https://gist.github.com/maxattack/4c7b4de00f5c1b95a33b

			if (deltaTime < Scalars.Epsilon) return current;
			ref readonly Float4 currentD = ref current.d;

			Float4 targetD = target.d;

			if (currentD.Dot(targetD) < 0f) targetD = -targetD;

			Float4 result = currentD.Damp(targetD, ref velocity, smoothTime, deltaTime).Normalized;
			velocity -= velocity.Project(result);

			return new Rotation(result);
		}

		public static Rotation operator *(in Rotation first, in Rotation second)
		{
			Float3 xyz0 = first.d.XYZ;
			Float3 xyz1 = second.d.XYZ;

			float w0 = first.d.w;
			float w1 = second.d.w;

			Float3 cross = xyz0.Cross(xyz1);

			return new Rotation
			(
				w0 * xyz1.x + w1 * xyz0.x + cross.x,
				w0 * xyz1.y + w1 * xyz0.y + cross.y,
				w0 * xyz1.z + w1 * xyz0.z + cross.z,
				w0 * w1 - xyz0.Dot(xyz1)
			);
		}

		public static Rotation operator /(in Rotation first, in Rotation second)
		{
			float inverse = 1f / second.d.SquaredMagnitude;

			Float3 xyz0 = first.d.XYZ;
			Float3 xyz1 = second.d.XYZ * -inverse;

			float w0 = first.d.w;
			float w1 = second.d.w * inverse;

			Float3 cross = xyz0.Cross(xyz1);

			return new Rotation
			(
				w0 * xyz1.x + w1 * xyz0.x + cross.x,
				w0 * xyz1.y + w1 * xyz0.y + cross.y,
				w0 * xyz1.z + w1 * xyz0.z + cross.z,
				w0 * w1 - xyz0.Dot(xyz1)
			);
		}

		public static Float3 operator *(in Rotation first, in Float3 second) => Apply(first, second);
		public static Float3 operator /(in Rotation first, in Float3 second) => Apply(first.Inverse, second);

		static Float3 Apply(in Rotation rotation, in Float3 point)
		{
			ref readonly Float4 d = ref rotation.d;

			Float4 dd = d.Squared;
			Float3 dw = d.w * 2f * d.XYZ;
			Float2 dz = d.z * 2f * d.XY;
			float dy_x = d.y * 2f * d.x;

			return new Float3
			(
				dd.w * point.x + dw.y * point.z - dw.z * point.y + dd.x * point.x + dy_x * point.y + dz.x * point.z - dd.z * point.x - dd.y * point.x,
				dy_x * point.x + dd.y * point.y + dz.y * point.z + dw.z * point.x - dd.z * point.y + dd.w * point.y - dw.x * point.z - dd.x * point.y,
				dz.x * point.x + dz.y * point.y + dd.z * point.z - dw.y * point.x - dd.y * point.z + dw.x * point.y - dd.x * point.z + dd.w * point.z
			);
		}

		public override bool Equals(object obj) => obj is Rotation other && Equals(other);
		public bool Equals(Rotation other) => d.Equals(other.d);
		public override int GetHashCode() => d.GetHashCode();

#if CODEHELPERS_UNITY
		public static implicit operator Rotation(UnityEngine.Quaternion value) => new Rotation(value.x, value.y, value.z, value.w);
		public static implicit operator UnityEngine.Quaternion(in Rotation value) => new UnityEngine.Quaternion(value.d.x, value.d.y, value.d.z, value.d.w);
#endif

		public override string ToString() => d.ToString();

		public string ToString(string format) => ToString(format, CultureInfo.InvariantCulture);
		public string ToString(string format, IFormatProvider provider) => d.ToString(format, provider);
	}
}