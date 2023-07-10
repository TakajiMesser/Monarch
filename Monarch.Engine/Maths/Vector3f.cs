using SpiceEngine.Core.Utilities;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Maths
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3f : IEquatable<Vector3f>
    {
        public Vector3f(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector2f Xy
        {
            get => new(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public bool IsReal => X.IsReal() && Y.IsReal() && Z.IsReal();

        public float LengthSquared => X * X + Y * Y + Z * Z;

        public float Length => (float)Math.Sqrt(LengthSquared);

        public float LengthFast => 1.0f / MathExtensions.InverseSqrtFast(LengthSquared);

        public Vector3f Normalized()
        {
            var scale = 1.0f / Length;
            return new Vector3f(X * scale, Y * scale, Z * scale);
        }

        public Vector3f NormalizedFast()
        {
            var scale = MathExtensions.InverseSqrtFast(LengthSquared);
            return new Vector3f(X * scale, Y * scale, Z * scale);
        }

        public override string ToString() => "<" + X + "," + Y + "," + Z + ">";

        public override bool Equals(object obj) => obj is Vector3f vector && Equals(vector);

        public bool Equals(Vector3f other) => X == other.X && Y == other.Y && Z == other.Z;

        public override int GetHashCode() => HashCode.Combine(X, Y, Z);

        public static readonly Vector3f UnitX = new(1f, 0f, 0f);

        public static readonly Vector3f UnitY = new(0f, 1f, 0f);

        public static readonly Vector3f UnitZ = new(0f, 0f, 1f);

        public static readonly Vector3f Zero = new(0f, 0f, 0f);

        public static readonly Vector3f One = new(1f, 1f, 1f);

        public static Vector3f Diagonal(float length) => new(length, length, length);

        public static bool operator ==(Vector3f left, Vector3f right) => left.Equals(right);

        public static bool operator !=(Vector3f left, Vector3f right) => !(left == right);

        public static Vector3f operator +(Vector3f left, Vector3f right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        public static Vector3f operator -(Vector3f left, Vector3f right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        public static Vector3f operator -(Vector3f vector) => new(-vector.X, -vector.Y, -vector.Z);

        public static Vector3f operator *(Vector3f vector, float scale) => new(vector.X * scale, vector.Y * scale, vector.Z * scale);

        public static Vector3f operator *(Vector3f left, Vector3f right) => new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

        public static Vector3f operator /(Vector3f vector, float scale) => new(vector.X / scale, vector.Y / scale, vector.Z / scale);

        public static Vector3f operator /(Vector3f left, Vector3f right) => new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

        public static Vector3f operator *(float scale, Vector3f vector) => new(scale * vector.X, scale * vector.Y, scale * vector.Z);

        /*public static Vector3f operator *(Quaternion quaternion, Vector3f vector)
        {
            var vectorQuat = new Quaternion(vector.X, vector.Y, vector.Z, 1.0f);
            var invertedQuat = quaternion.Inverted();
            var rotatedQuat = (quaternion * vectorQuat) * invertedQuat;

            return new Vector3f(rotatedQuat.X, rotatedQuat.Y, rotatedQuat.Z);
        }*/

        public static float Dot(Vector3f left, Vector3f right) => left.X * right.X + left.Y * right.Y + left.Z * right.Z;

        public static Vector3f Cross(Vector3f left, Vector3f right) => new(left.Y * right.Z - left.Z * right.Y, left.Z * right.X - left.X * right.Z, left.X * right.Y - left.Y * right.X);
    }
}
