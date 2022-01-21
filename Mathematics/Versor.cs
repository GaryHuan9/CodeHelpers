﻿using System;
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
		/// Creates a <see cref="Versor"/> from three angles (degrees) in the ZXY rotation order.
		/// </summary>
		public Versor(float angleX, float angleY, float angleZ) : this(new Float3(angleX, angleY, angleZ)) { }

		/// <summary>
		/// Creates a <see cref="Versor"/> from three angles (degrees) in the ZXY rotation order.
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
			sin.x * cos.y * cos.z + cos.x * sin.y * sin.z,
			cos.x * sin.y * cos.z - sin.x * cos.y * sin.z,
			cos.x * cos.y * sin.z - sin.x * sin.y * cos.z,
			cos.x * cos.y * cos.z + sin.x * sin.y * sin.z
		);

		/// <summary>
		/// Creates a <see cref="Versor"/> from an <paramref name="axis"/> and an <paramref name="angle"/> (degrees).
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

		internal Versor(in Float4 d) => this.d = d;

		internal readonly Float4 d;

		public static readonly Versor identity = new Versor(Float4.ana);

		public Versor Conjugate => new Versor(-d.x, -d.y, -d.z, d.w);
		public Versor Inverse => Conjugate;

		public Float3 Angles
		{
			get
			{
				Float3 d2 = d.XYZ * 2f;
				Float4 xs = d2.x * d;

				float yy = d2.y * d.y;
				float yz = d2.y * d.z;
				float yw = d2.y * d.w;

				float zz = d2.z * d.z;
				float zw = d2.z * d.w;

				float xw_yz = xs.w - yz;
				float abs = Math.Abs(xw_yz);

				float x = abs >= 1f ? 90f * Math.Sign(xw_yz) : (float)Math.Asin(xw_yz) * Scalars.RadianToDegree;

				if (abs.AlmostEquals(1f))
				{
					//Singularity
					float y = (float)Math.Atan2(yw - xs.z, 1f - yy - zz);
					return new Float3(x, y * Scalars.RadianToDegree, 0f);
				}
				else
				{
					//General cases
					float y = (float)Math.Atan2(xs.z + yw, 1f - xs.x - yy) * Scalars.RadianToDegree;
					float z = (float)Math.Atan2(xs.y + zw, 1f - xs.x - zz) * Scalars.RadianToDegree;

					return new Float3(x, y, z);
				}
			}
		}

		public float Dot(in Versor other) => d.Dot(other.d);
		public double DotDouble(in Versor other) => d.DotDouble(other.d);

		/// <summary>
		/// Returns the smallest angle between this <see cref="Versor"/> and <paramref name="other"/>.
		/// </summary>
		public float Angle(in Versor other)
		{
			float dot = Math.Abs(Dot(other));
			if (dot.AlmostEquals()) return 0f;

			return (float)Math.Acos(dot) * 2f * Scalars.RadianToDegree;
		}

		public Versor Damp(in Versor target, ref Float4 velocity, float smoothTime, float deltaTime) => Damp(this, target, ref velocity, smoothTime, deltaTime);

		/// <summary>
		/// Returns the smallest angle between this <see cref="Versor"/> and <paramref name="other"/>.
		/// </summary>
		public static float Angle(in Versor value, in Versor other) => value.Angle(other);

		public static float Dot(in Float4 value, in Float4 other) => value.Dot(other);
		public static double DotDouble(in Float4 value, in Float4 other) => value.DotDouble(other);

		public static Versor Damp(in Versor current, in Versor target, ref Float4 velocity, float smoothTime, float deltaTime)
		{
			//Code based on: https://gist.github.com/maxattack/4c7b4de00f5c1b95a33b

			if (deltaTime < Scalars.Epsilon) return current;
			ref readonly Float4 currentData = ref current.d;

			Float4 targetData = target.d;

			if (currentData.Dot(targetData) < 0f) targetData = -targetData;

			Float4 result = currentData.Damp(targetData, ref velocity, smoothTime, deltaTime).Normalized;
			velocity -= velocity.Project(result);

			return new Versor(result);
		}

#if CODE_HELPERS_UNITY
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
				dd.w * second.x + dd.x * second.x - dw.z * second.y + dy_x * second.y + dw.y * second.z + dz.x * second.z - dd.z * second.x - dd.y * second.x,
				dy_x * second.x + dw.z * second.x + dd.y * second.y - dd.z * second.y + dz.y * second.z - dw.x * second.z + dd.w * second.y - dd.x * second.y,
				dz.x * second.x - dw.y * second.x + dz.y * second.y + dw.x * second.y + dd.z * second.z - dd.y * second.z - dd.x * second.z + dd.w * second.z
			);
		}

		public static bool operator ==(in Versor left, in Versor right) => left.Equals(right);
		public static bool operator !=(in Versor left, in Versor right) => !left.Equals(right);

		public bool Equals(in Versor other) => Math.Abs(Dot(other)).AlmostEquals(1f);
		public override bool Equals(object obj) => obj is Versor other && Equals(other);

		bool IEquatable<Versor>.Equals(Versor other) => Equals(other);

		public override int GetHashCode() => d.GetHashCode();

#if CODE_HELPERS_UNITY
		public static implicit operator Versor(UnityEngine.Quaternion value) => new Versor(value.x, value.y, value.z, value.w);
		public static implicit operator UnityEngine.Quaternion(in Versor value) => new UnityEngine.Quaternion(value.d.x, value.d.y, value.d.z, value.d.w);
#endif

		public static implicit operator Float3x3(in Versor value)
		{
			ref readonly Float4 d = ref value.d;

			Float3 d2 = d.XYZ * 2f;
			Float4 xs = d2.x * d;

			float yy = d2.y * d.y;
			float yz = d2.y * d.z;
			float yw = d2.y * d.w;

			float zz = d2.z * d.z;
			float zw = d2.z * d.w;

			return new Float3x3
			(
				1.0f - yy - zz, xs.y - zw, xs.z + yw,
				xs.y + zw, 1f - xs.x - zz, yz - xs.w,
				xs.z - yw, yz + xs.w, 1f - xs.x - yy
			);
		}

		public override string ToString() => d.ToString();

		public string ToString(string format) => ToString(format, CultureInfo.InvariantCulture);

		public string ToString(string format, IFormatProvider provider) => d.ToString(format, provider);
	}
}