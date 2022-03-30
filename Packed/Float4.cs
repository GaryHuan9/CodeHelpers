using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeHelpers.Mathematics;

namespace CodeHelpers.Packed
{
	[StructLayout(LayoutKind.Sequential)]
	public readonly partial struct Float4 : IEquatable<Float4>, IFormattable
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float4(float x, float y, float z, float w)
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}

		public float X { get; }
		public float Y { get; }
		public float Z { get; }
		public float W { get; }

#region Properties

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
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X * X + Y * Y + Z * Z + W * W;
		}

		public double SquaredMagnitudeDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)X * X + (double)Y * Y + (double)Z * Z + (double)W * W;
		}

		public float Product
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X * Y * Z * W;
		}

		public double ProductDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)X * Y * Z * W;
		}

		public float ProductAbsoluted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs(X * Y * Z * W);
		}

		public double ProductAbsolutedDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => Math.Abs((double)X * Y * Z * W);
		}

		public float Sum
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => X + Y + Z + W;
		}

		public double SumDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (double)X + Y + Z + W;
		}

		public float Average
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => (float)AverageDouble;
		}

		public double AverageDouble
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => ((double)X + Y + Z + W) / 4d;
		}

		public float MinComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X < Y)
				{
					if (X < Z) return X < W ? X : W;
					return Z < W ? Z : W;
				}

				if (Y < Z) return Y < W ? Y : W;
				return Z < W ? Z : W;
			}
		}

		public int MinIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X < Y)
				{
					if (X < Z) return X < W ? 0 : 3;
					return Z < W ? 2 : 3;
				}

				if (Y < Z) return Y < W ? 1 : 3;
				return Z < W ? 2 : 3;
			}
		}

		public float MaxComponent
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X > Y)
				{
					if (X > Z) return X > W ? X : W;
					return Z > W ? Z : W;
				}

				if (Y > Z) return Y > W ? Y : W;
				return Z > W ? Z : W;
			}
		}

		public int MaxIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X > Y)
				{
					if (X > Z) return X > W ? 0 : 3;
					return Z > W ? 2 : 3;
				}

				if (Y > Z) return Y > W ? 1 : 3;
				return Z > W ? 2 : 3;
			}
		}

		public float this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
#if CODE_HELPERS_UNSAFE
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
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float4(Math.Abs(X), Math.Abs(Y), Math.Abs(Z), Math.Abs(W));
		}

		public Int4 Signed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int4(X.Sign(), Y.Sign(), Z.Sign(), W.Sign());
		}

		public Float4 Normalized
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				double squared = SquaredMagnitudeDouble;
				if (squared.AlmostEquals()) return Zero;

				return 1f / (float)Math.Sqrt(squared) * this;
			}
		}

		public Float4 Squared
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float4(X * X, Y * Y, Z * Z, W * W);
		}

		public Float4 Sorted
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X < Y)
				{
					if (Y < Z) //XYZ
					{
						if (Z < W) return XYZW;
						if (Y < W) return XYWZ;
						if (X < W) return XWYZ;

						return WXYZ;
					}

					if (X < Z) //XZY
					{
						if (Y < W) return XZYW;
						if (Z < W) return XZWY;
						if (X < W) return XWZY;

						return WXZY;
					}

					//ZXY

					if (Y < W) return ZXYW;
					if (X < W) return ZXWY;
					if (Z < W) return ZWXY;

					return WZXY;
				}

				if (X < Z) //YXZ
				{
					if (Z < W) return YXZW;
					if (X < W) return YXWZ;
					if (Y < W) return YWXZ;

					return WYXZ;
				}

				if (Y < Z) //YZX
				{
					if (X < W) return YZXW;
					if (Z < W) return YZWX;
					if (Y < W) return YWZX;

					return WYZX;
				}

				//ZYX

				if (X < W) return ZYXW;
				if (Y < W) return ZYWX;
				if (Z < W) return ZWYX;

				return WZYX;
			}
		}

		public Float4 SortedReversed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get
			{
				if (X > Y)
				{
					if (Y > Z) //XYZ
					{
						if (Z > W) return XYZW;
						if (Y > W) return XYWZ;
						if (X > W) return XWYZ;

						return WXYZ;
					}

					if (X > Z) //XZY
					{
						if (Y > W) return XZYW;
						if (Z > W) return XZWY;
						if (X > W) return XWZY;

						return WXZY;
					}

					//ZXY

					if (Y > W) return ZXYW;
					if (X > W) return ZXWY;
					if (Z > W) return ZWXY;

					return WZXY;
				}

				if (X > Z) //YXZ
				{
					if (Z > W) return YXZW;
					if (X > W) return YXWZ;
					if (Y > W) return YWXZ;

					return WYXZ;
				}

				if (Y > Z) //YZX
				{
					if (X > W) return YZXW;
					if (Z > W) return YZWX;
					if (Y > W) return YWZX;

					return WYZX;
				}

				//ZYX

				if (X > W) return ZYXW;
				if (Y > W) return ZYWX;
				if (Z > W) return ZWYX;

				return WZYX;
			}
		}

		public Int4 Floored
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int4((int)Math.Floor(X), (int)Math.Floor(Y), (int)Math.Floor(Z), (int)Math.Floor(W));
		}

		public Float4 FlooredFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float4((float)Math.Floor(X), (float)Math.Floor(Y), (float)Math.Floor(Z), (float)Math.Floor(W));
		}

		public Int4 Ceiled
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int4((int)Math.Ceiling(X), (int)Math.Ceiling(Y), (int)Math.Ceiling(Z), (int)Math.Ceiling(W));
		}

		public Float4 CeiledFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float4((float)Math.Ceiling(X), (float)Math.Ceiling(Y), (float)Math.Ceiling(Z), (float)Math.Ceiling(W));
		}

		public Int4 Rounded
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Int4((int)Math.Round(X), (int)Math.Round(Y), (int)Math.Round(Z), (int)Math.Round(W));
		}

		public Float4 RoundedFloat
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Float4((float)Math.Round(X), (float)Math.Round(Y), (float)Math.Round(Z), (float)Math.Round(W));
		}

#endregion

#endregion

#region Methods

#region Instance

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Dot(in Float4 other) => X * other.X + Y * other.Y + Z * other.Z + W * other.W;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DotDouble(in Float4 other) => (double)X * other.X + (double)Y * other.Y + (double)Z * other.Z + (double)W * other.W;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Angle(in Float4 other)
		{
			double squared = SquaredMagnitudeDouble * other.SquaredMagnitudeDouble;
			if (squared.AlmostEquals()) return 0f;

			double magnitude = Math.Sqrt(squared);
			if (magnitude.AlmostEquals()) return 0f;

			return (float)Math.Acos(DotDouble(other) / magnitude) * Scalars.RadianToDegree;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float Distance(in Float4 other) => (other - this).Magnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double DistanceDouble(in Float4 other) => (other - this).MagnitudeDouble;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public float SquaredDistance(in Float4 other) => (other - this).SquaredMagnitude;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public double SquaredDistanceDouble(in Float4 other) => (other - this).SquaredMagnitudeDouble;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Min(in Float4 other) => new Float4(Math.Min(X, other.X), Math.Min(Y, other.Y), Math.Min(Z, other.Z), Math.Min(W, other.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Max(in Float4 other) => new Float4(Math.Max(X, other.X), Math.Max(Y, other.Y), Math.Max(Z, other.Z), Math.Max(W, other.W));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Clamp(in Float4 min, in Float4 max) => new Float4(X.Clamp(min.X, max.X), Y.Clamp(min.Y, max.Y), Z.Clamp(min.Z, max.Z), W.Clamp(min.W, max.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Clamp(float min = 0f, float max = 1f) => new Float4(X.Clamp(min, max), Y.Clamp(min, max), Z.Clamp(min, max), W.Clamp(min, max));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float4 ClampMagnitude(float max)
		{
			double squared = SquaredMagnitudeDouble;
			if (squared <= (double)max * max) return this;

			float scale = max / (float)Math.Sqrt(squared);
			return new Float4(X * scale, Y * scale, Z * scale, W * scale);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Power(in Float4 value) => new Float4((float)Math.Pow(X, value.X), (float)Math.Pow(Y, value.Y), (float)Math.Pow(Z, value.Z), (float)Math.Pow(W, value.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Power(float value) => new Float4((float)Math.Pow(X, value), (float)Math.Pow(Y, value), (float)Math.Pow(Z, value), (float)Math.Pow(W, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Lerp(in Float4 other, in Float4 value) => new Float4(Scalars.Lerp(X, other.X, value.X), Scalars.Lerp(Y, other.Y, value.Y), Scalars.Lerp(Z, other.Z, value.Z), Scalars.Lerp(W, other.W, value.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Lerp(in Float4 other, float value) => new Float4(Scalars.Lerp(X, other.X, value), Scalars.Lerp(Y, other.Y, value), Scalars.Lerp(Z, other.Z, value), Scalars.Lerp(W, other.W, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 InverseLerp(in Float4 other, in Float4 value) => new Float4(Scalars.InverseLerp(X, other.X, value.X), Scalars.InverseLerp(Y, other.Y, value.Y), Scalars.InverseLerp(Z, other.Z, value.Z), Scalars.InverseLerp(W, other.W, value.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 InverseLerp(in Float4 other, float value) => new Float4(Scalars.InverseLerp(X, other.X, value), Scalars.InverseLerp(Y, other.Y, value), Scalars.InverseLerp(Z, other.Z, value), Scalars.InverseLerp(W, other.W, value));

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Repeat(in Float4 length) => new Float4(X.Repeat(length.X), Y.Repeat(length.Y), Z.Repeat(length.Z), W.Repeat(length.W));
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Repeat(float length) => new Float4(X.Repeat(length), Y.Repeat(length), Z.Repeat(length), W.Repeat(length));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float4 Damp(in Float4 target, ref Float4 velocity, in Float4 smoothTime, float deltaTime)
		{
			float velocityX = velocity.X;
			float velocityY = velocity.Y;
			float velocityZ = velocity.Z;
			float velocityW = velocity.W;

			Float4 result = new Float4
			(
				X.Damp(target.X, ref velocityX, smoothTime.X, deltaTime),
				Y.Damp(target.Y, ref velocityY, smoothTime.Y, deltaTime),
				Z.Damp(target.Z, ref velocityZ, smoothTime.Z, deltaTime),
				W.Damp(target.W, ref velocityW, smoothTime.W, deltaTime)
			);

			velocity = new Float4(velocityX, velocityY, velocityZ, velocityW);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Float4 Damp(in Float4 target, ref Float4 velocity, float smoothTime, float deltaTime) => Damp(target, ref velocity, (Float4)smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Reflect(in Float4 normal) => -2f * Dot(normal) * normal + this;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public Float4 Project(in Float4 normal) => normal * (Dot(normal) / normal.SquaredMagnitude);

		public override string ToString() => ToString(string.Empty);

		public string ToString(string format) => ToString(format, CultureInfo.InvariantCulture);

		public string ToString(string format, IFormatProvider provider) => $"({X.ToString(format, provider)}, {Y.ToString(format, provider)}, {Z.ToString(format, provider)}, {W.ToString(format, provider)})";

		// ReSharper disable CompareOfFloatsByEqualityOperator
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool EqualsExact(in Float4 other) => X == other.X && Y == other.Y && Z == other.Z && W == other.W;
		// ReSharper restore CompareOfFloatsByEqualityOperator

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Float4 other && Equals(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Float4 other) => EqualsFast(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool EqualsFast(in Float4 other) => X.AlmostEquals(other.X) && Y.AlmostEquals(other.Y) && Z.AlmostEquals(other.Z) && W.AlmostEquals(other.W);

		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = X.GetHashCode();
				hashCode = (hashCode * 397) ^ Y.GetHashCode();
				hashCode = (hashCode * 397) ^ Z.GetHashCode();
				hashCode = (hashCode * 397) ^ W.GetHashCode();
				return hashCode;
			}
		}

#endregion

#region Static

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Dot(in Float4 value, in Float4 other) => value.Dot(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double DotDouble(in Float4 value, in Float4 other) => value.DotDouble(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Angle(in Float4 first, in Float4 second) => first.Angle(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Distance(in Float4 value, in Float4 other) => value.Distance(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double DistanceDouble(in Float4 value, in Float4 other) => value.DistanceDouble(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static float SquaredDistance(in Float4 value, in Float4 other) => value.SquaredDistance(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static double SquaredDistanceDouble(in Float4 value, in Float4 other) => value.SquaredDistanceDouble(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Min(in Float4 value, in Float4 other) => value.Min(other);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Max(in Float4 value, in Float4 other) => value.Max(other);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Clamp(in Float4 value, in Float4 min, in Float4 max) => value.Clamp(min, max);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Clamp(in Float4 value, float min = 0f, float max = 1f) => value.Clamp(min, max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 ClampMagnitude(in Float4 value, float max) => value.ClampMagnitude(max);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Power(in Float4 value, in Float4 power) => value.Power(power);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Power(in Float4 value, float power) => value.Power(power);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Lerp(in Float4 first, in Float4 second, in Float4 value) => first.Lerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Lerp(in Float4 first, in Float4 second, float value) => first.Lerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 InverseLerp(in Float4 first, in Float4 second, in Float4 value) => first.InverseLerp(second, value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 InverseLerp(in Float4 first, in Float4 second, float value) => first.InverseLerp(second, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Repeat(in Float4 value, in Float4 length) => value.Repeat(length);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Repeat(in Float4 value, float length) => value.Repeat(length);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Damp(in Float4 current, in Float4 target, ref Float4 velocity, in Float4 smoothTime, float deltaTime) => current.Damp(target, ref velocity, smoothTime, deltaTime);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Damp(in Float4 current, in Float4 target, ref Float4 velocity, float smoothTime, float deltaTime) => current.Damp(target, ref velocity, smoothTime, deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Reflect(in Float4 value, in Float4 normal) => value.Reflect(normal);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 Project(in Float4 value, in Float4 normal) => value.Project(normal);

#endregion

#region Create

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Float4 Create(int index, float value)
		{
#if CODE_HELPERS_UNSAFE
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
#if CODE_HELPERS_UNSAFE
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
#if CODE_HELPERS_UNSAFE
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

#if CODE_HELPERS_UNITY
		public UnityEngine.Vector4 U() => this;
#endif

#endregion

#region Operators

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator +(in Float4 first, in Float4 second) => new Float4(first.X + second.X, first.Y + second.Y, first.Z + second.Z, first.W + second.W);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator -(in Float4 first, in Float4 second) => new Float4(first.X - second.X, first.Y - second.Y, first.Z - second.Z, first.W - second.W);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator *(in Float4 first, in Float4 second) => new Float4(first.X * second.X, first.Y * second.Y, first.Z * second.Z, first.W * second.W);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator /(in Float4 first, in Float4 second) => new Float4(first.X / second.X, first.Y / second.Y, first.Z / second.Z, first.W / second.W);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator *(in Float4 first, float second) => new Float4(first.X * second, first.Y * second, first.Z * second, first.W * second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator /(in Float4 first, float second) => new Float4(first.X / second, first.Y / second, first.Z / second, first.W / second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator *(float first, in Float4 second) => new Float4(first * second.X, first * second.Y, first * second.Z, first * second.W);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator /(float first, in Float4 second) => new Float4(first / second.X, first / second.Y, first / second.Z, first / second.W);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator +(in Float4 value) => value;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator -(in Float4 value) => new Float4(-value.X, -value.Y, -value.Z, -value.W);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator %(in Float4 first, in Float4 second) => new Float4(first.X % second.X, first.Y % second.Y, first.Z % second.Z, first.W % second.W);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator %(in Float4 first, float second) => new Float4(first.X % second, first.Y % second, first.Z % second, first.W % second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static Float4 operator %(float first, in Float4 second) => new Float4(first % second.X, first % second.Y, first % second.Z, first % second.W);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(in Float4 first, in Float4 second) => first.EqualsFast(second);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(in Float4 first, in Float4 second) => !first.EqualsFast(second);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(in Float4 first, in Float4 second) => first.X < second.X && first.Y < second.Y && first.Z < second.Z && first.W < second.W;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(in Float4 first, in Float4 second) => first.X > second.X && first.Y > second.Y && first.Z > second.Z && first.W > second.W;

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(in Float4 first, in Float4 second) => first.X <= second.X && first.Y <= second.Y && first.Z <= second.Z && first.W <= second.W;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(in Float4 first, in Float4 second) => first.X >= second.X && first.Y >= second.Y && first.Z >= second.Z && first.W >= second.W;

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
			public SeriesEnumerable(in Float4 value) => enumerator = new Enumerator(value);

			readonly Enumerator enumerator;

			public Enumerator GetEnumerator() => enumerator;

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			IEnumerator<float> IEnumerable<float>.GetEnumerator() => GetEnumerator();

			public struct Enumerator : IEnumerator<float>
			{
				public Enumerator(in Float4 source)
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