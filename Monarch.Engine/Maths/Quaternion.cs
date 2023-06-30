﻿using SpiceEngine.Core.Utilities;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Maths
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Quaternion : IEquatable<Quaternion>
    {
        public Quaternion(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Quaternion(Vector3f eulerAngles) : this(eulerAngles.X, eulerAngles.Y, eulerAngles.Z) { }
        public Quaternion(float rotationX, float rotationY, float rotationZ)
        {
            rotationX *= 0.5f;
            rotationY *= 0.5f;
            rotationZ *= 0.5f;

            var c1 = (float)Math.Cos(rotationX);
            var c2 = (float)Math.Cos(rotationY);
            var c3 = (float)Math.Cos(rotationZ);
            var s1 = (float)Math.Sin(rotationX);
            var s2 = (float)Math.Sin(rotationY);
            var s3 = (float)Math.Sin(rotationZ);


            X = (s1 * c2 * c3) + (c1 * s2 * s3);
            Y = (c1 * s2 * c3) - (s1 * c2 * s3);
            Z = (c1 * c2 * s3) + (s1 * s2 * c3);
            W = (c1 * c2 * c3) - (s1 * s2 * s3);
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }

        public Vector3f Xyz
        {
            get => new(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        public bool IsReal => X.IsReal() && Y.IsReal() && Z.IsReal() && W.IsReal();

        public float Length => (float)Math.Sqrt(LengthSquared);

        public float LengthSquared => X * X + Y * Y + Z * Z + W * W;

        public static readonly Quaternion Identity = new(0f, 0f, 0f, 1f);

        public Quaternion Inverted()
        {
            var lengthSquared = LengthSquared;

            if (lengthSquared != 0f)
            {
                var i = 1.0f / lengthSquared;
                return new(X * -i, Y * -i, Z * -i, W * i);
            }
            else
            {
                return this;
            }
        }

        public Quaternion Normalized()
        {
            var scale = 1.0f / Length;
            return new(X * scale, Y * scale, Z * scale, W * scale);
        }

        public Vector3f ToEulerAngles()
        {
            //reference
            //http://en.wikipedia.org/wiki/Conversion_between_quaternions_and_Euler_angles
            //http://www.euclideanspace.com/maths/geometry/rotations/conversions/quaternionToEuler/

            var q = this;

            // Threshold for the singularities found at the north/south poles.
            const float SINGULARITY_THRESHOLD = 0.4999995f;

            var sqw = q.W * q.W;
            var sqx = q.X * q.X;
            var sqy = q.Y * q.Y;
            var sqz = q.Z * q.Z;
            var unit = sqx + sqy + sqz + sqw; // if normalised is one, otherwise is correction factor
            var singularityTest = (q.X * q.Z) + (q.W * q.Y);

            float x, y, z;

            if (singularityTest > SINGULARITY_THRESHOLD* unit)
            {
                z = (float) (2 * Math.Atan2(q.X, q.W));
                y = MathExtensions.HALF_PI;
                x = 0;
            }
            else if (singularityTest< -SINGULARITY_THRESHOLD* unit)
            {
                z = (float) (-2 * Math.Atan2(q.X, q.W));
                y = -MathExtensions.HALF_PI;
                x = 0;
            }
            else
            {
                z = (float)Math.Atan2(2 * ((q.W * q.Z) - (q.X * q.Y)), sqw + sqx - sqy - sqz);
                y = (float)Math.Asin(2 * singularityTest / unit);
                x = (float)Math.Atan2(2 * ((q.W * q.X) - (q.Y * q.Z)), sqw - sqx - sqy + sqz);
            }

            return new(x, y, z);
        }

        public Vector4f ToAxisAngle()
        {
            var quaternion = Math.Abs(W) > 1.0f
                ? Normalized()
                : this;

            var w = 2f * (float)Math.Acos(quaternion.W);
            var den = (float)Math.Sqrt(1f - quaternion.W * quaternion.W);

            if (den > 0.0001f)
            {
                return new Vector4f()
                {
                    X = quaternion.X / den,
                    Y = quaternion.Y / den,
                    Z = quaternion.Z / den,
                    W = w
                };
            }
            else
            {
                return new(1.0f, 0.0f, 0.0f, w);
            }
        }

        public override string ToString() => "<" + X + "," + Y + "," + Z + "," + W + ">";

        public override bool Equals(object obj) => obj is Quaternion quaternion && Equals(quaternion);

        public bool Equals(Quaternion other) => X == other.X && Y == other.Y && Z == other.Z && W == other.W;

        public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);

        public static Quaternion FromAxisAngle(Vector3f axis, float angle)
        {
            if (axis.LengthSquared == 0.0f)
            {
                return Identity;
            }

            var result = Identity;

            angle *= 0.5f;
            axis = axis.Normalized();
            result.Xyz = axis * (float)Math.Sin(angle);
            result.W = (float)Math.Cos(angle);

            return result.Normalized();
        }

        public static Quaternion FromEulerAngles(Vector3f eulerAngles) => FromEulerAngles(eulerAngles.X, eulerAngles.Y, eulerAngles.Z);
        public static Quaternion FromEulerAngles(float rotationX, float rotationY, float rotationZ) => new(rotationX, rotationY, rotationZ);

        public static Quaternion FromMatrix(Matrix3 matrix)
        {
            var trace = matrix.Trace;

            if (trace > 0)
            {
                var s = 1f / (float)Math.Sqrt(trace + 1) * 2;
                var invS = 1f / s;

                return new(
                    (matrix.M21 - matrix.M12) * invS,
                    (matrix.M02 - matrix.M20) * invS,
                    (matrix.M10 - matrix.M01) * invS,
                    s * 0.25f
                );
            }
            else
            {
                if (matrix.M00 > matrix.M11 && matrix.M00 > matrix.M22)
                {
                    var s = (float)Math.Sqrt(1 + matrix.M00 - matrix.M11 - matrix.M22) * 2f;
                    var invS = 1f / s;

                    return new(
                        s * 0.25f,
                        (matrix.M01 + matrix.M10) * invS,
                        (matrix.M02 + matrix.M20) * invS,
                        (matrix.M21 - matrix.M12) * invS
                    );
                }
                else if (matrix.M11 > matrix.M22)
                {
                    var s = (float)Math.Sqrt(1 + matrix.M11 - matrix.M00 - matrix.M22) * 2;
                    var invS = 1f / s;

                    return new(
                        (matrix.M01 + matrix.M10) * invS,
                        s * 0.25f,
                        (matrix.M12 + matrix.M21) * invS,
                        (matrix.M02 - matrix.M20) * invS
                    );
                }
                else
                {
                    var s = (float)Math.Sqrt(1 + matrix.M22 - matrix.M00 - matrix.M11) * 2;
                    var invS = 1f / s;

                    return new(
                        (matrix.M02 + matrix.M20) * invS,
                        (matrix.M12 + matrix.M21) * invS,
                        s * 0.25f,
                        (matrix.M10 - matrix.M01) * invS
                    );
                }
            }
        }

        public static Quaternion operator +(Quaternion left, Quaternion right)
        {
            var x = left.X + left.Y;
            var y = left.Y + right.Y;
            var z = left.Z + right.Z;
            var w = left.W + right.W;

            return new(x, y, z, w);
        }

        public static Quaternion operator -(Quaternion left, Quaternion right)
        {
            var x = left.X - left.Y;
            var y = left.Y - right.Y;
            var z = left.Z - right.Z;
            var w = left.W - right.W;

            return new(x, y, z, w);
        }

        public static Quaternion operator *(Quaternion left, Quaternion right)
        {
            var vector = (right.W * left.Xyz) + (left.W * right.Xyz) + Vector3f.Cross(left.Xyz, right.Xyz);
            return new(vector.X, vector.Y, vector.Z, (left.W * right.W) - Vector3f.Dot(left.Xyz, right.Xyz));
        }

        public static Quaternion operator *(Quaternion quaternion, float scale) => new(scale * quaternion.X, scale * quaternion.Y, scale * quaternion.Z, scale * quaternion.W);

        public static Quaternion operator *(float scale, Quaternion quaternion) => new(scale * quaternion.X, scale * quaternion.Y, scale * quaternion.Z, scale * quaternion.W);

        public static Vector3f operator *(Quaternion quaternion, Vector3f vector)
        {
            var xyz = new Vector3f(quaternion.X, quaternion.Y, quaternion.Z);
            var temp = Vector3f.Cross(xyz, vector);
            var temp2 = vector * quaternion.W;
            temp += temp2;
            temp2 = Vector3f.Cross(xyz, temp);
            temp2 *= 2f;
            return vector + temp2;
        }

        public static bool operator ==(Quaternion left, Quaternion right) => left.Equals(right);

        public static bool operator !=(Quaternion left, Quaternion right) => !(left == right);
    }
}
