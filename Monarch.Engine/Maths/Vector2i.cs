using SpiceEngine.Core.Utilities;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Maths
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2i : IEquatable<Vector2i>
    {
        public Vector2i(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public float LengthSquared => X * X + Y * Y;

        public float Length => (float)Math.Sqrt(LengthSquared);

        public float LengthFast => 1.0f / MathExtensions.InverseSqrtFast(LengthSquared);

        public override string ToString() => "<" + X + "," + Y + ">";

        public override bool Equals(object obj) => obj is Vector2i vector && Equals(vector);

        public bool Equals(Vector2i other) => X == other.X && Y == other.Y;

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static readonly Vector2i UnitX = new(1, 0);

        public static readonly Vector2i UnitY = new(0, 1);

        public static readonly Vector2i Zero = new(0, 0);

        public static readonly Vector2i One = new(1, 1);

        public static bool operator ==(Vector2i left, Vector2i right) => left.Equals(right);

        public static bool operator !=(Vector2i left, Vector2i right) => !(left == right);

        public static Vector2i operator +(Vector2i left, Vector2i right) => new(left.X + right.X, left.Y + right.Y);

        public static Vector2i operator -(Vector2i left, Vector2i right) => new(left.X - right.X, left.Y - right.Y);

        public static Vector2i operator -(Vector2i vector) => new(-vector.X, -vector.Y);

        public static Vector2i operator *(Vector2i vector, int scale) => new(vector.X * scale, vector.Y * scale);

        public static Vector2i operator *(Vector2i left, Vector2i right) => new(left.X * right.X, left.Y * right.Y);

        public static Vector2i operator /(Vector2i left, Vector2i right) => new(left.X / right.X, left.Y / right.Y);

        public static float Dot(Vector2i left, Vector2i right) => left.X * right.X + left.Y * right.Y;
    }
}
