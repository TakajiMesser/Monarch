using SpiceEngine.Core.Utilities;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Maths
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Vector2f : IEquatable<Vector2f>
    {
        public Vector2f(float x, float y)
        {
            X = x;
            Y = y;
        }

        [FieldOffset(0)]
        public float X;
        //public float X { get; set; }

        [FieldOffset(4)]
        public float Y;
        //public float Y { get; set; }

        public bool IsReal => X.IsReal() && Y.IsReal();

        public float LengthSquared => X * X + Y * Y;

        public float Length => (float)Math.Sqrt(LengthSquared);

        public float LengthFast => 1.0f / MathExtensions.InverseSqrtFast(LengthSquared);

        public Vector2f Normalized()
        {
            var scale = 1.0f / Length;
            return new Vector2f(X * scale, Y * scale);
        }

        public Vector2f NormalizedFast()
        {
            var scale = MathExtensions.InverseSqrtFast(LengthSquared);
            return new Vector2f(X * scale, Y * scale);
        }

        public override string ToString() => "<" + X + "," + Y + ">";

        public override bool Equals(object obj) => obj is Vector2f vector && Equals(vector);

        public bool Equals(Vector2f other) => X == other.X && Y == other.Y;

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static readonly Vector2f UnitX = new(1f, 0f);

        public static readonly Vector2f UnitY = new(0f, 1f);

        public static readonly Vector2f Zero = new(0f, 0f);

        public static readonly Vector2f One = new(1f, 1f);

        public static Vector2f Diagonal(float length) => new(length, length);

        public static bool operator ==(Vector2f left, Vector2f right) => left.Equals(right);

        public static bool operator !=(Vector2f left, Vector2f right) => !(left == right);

        public static Vector2f operator +(Vector2f left, Vector2f right) => new(left.X + right.X, left.Y + right.Y);

        public static Vector2f operator -(Vector2f left, Vector2f right) => new(left.X - right.X, left.Y - right.Y);

        public static Vector2f operator -(Vector2f vector) => new(-vector.X, -vector.Y);

        public static Vector2f operator *(Vector2f vector, float scale) => new(vector.X * scale, vector.Y * scale);

        public static Vector2f operator *(Vector2f left, Vector2f right) => new(left.X * right.X, left.Y * right.Y);

        public static Vector2f operator /(Vector2f left, Vector2f right) => new(left.X / right.X, left.Y / right.Y);

        public static float Dot(Vector2f left, Vector2f right) => left.X * right.X + left.Y * right.Y;
    }
}
