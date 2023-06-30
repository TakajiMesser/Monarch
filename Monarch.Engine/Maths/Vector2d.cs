using SpiceEngine.Core.Utilities;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Maths
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2d : IEquatable<Vector2d>
    {
        public Vector2d(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public bool IsReal => X.IsReal() && Y.IsReal();

        public double LengthSquared => X * X + Y * Y;

        public double Length => Math.Sqrt(LengthSquared);

        public double LengthFast => 1.0 / MathExtensions.InverseSqrtFast((float)LengthSquared);

        public override string ToString() => "<" + X + "," + Y + ">";

        public override bool Equals(object obj) => obj is Vector2i vector && Equals(vector);

        public bool Equals(Vector2d other) => X == other.X && Y == other.Y;

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static readonly Vector2d UnitX = new(1, 0);

        public static readonly Vector2d UnitY = new(0, 1);

        public static readonly Vector2d Zero = new(0, 0);

        public static readonly Vector2d One = new(1, 1);

        public static bool operator ==(Vector2d left, Vector2d right) => left.Equals(right);

        public static bool operator !=(Vector2d left, Vector2d right) => !(left == right);

        public static Vector2d operator +(Vector2d left, Vector2d right) => new(left.X + right.X, left.Y + right.Y);

        public static Vector2d operator -(Vector2d left, Vector2d right) => new(left.X - right.X, left.Y - right.Y);

        public static Vector2d operator -(Vector2d vector) => new(-vector.X, -vector.Y);

        public static Vector2d operator *(Vector2d vector, int scale) => new(vector.X * scale, vector.Y * scale);

        public static Vector2d operator *(Vector2d left, Vector2d right) => new(left.X * right.X, left.Y * right.Y);

        public static Vector2d operator /(Vector2d left, Vector2d right) => new(left.X / right.X, left.Y / right.Y);

        public static double Dot(Vector2d left, Vector2d right) => left.X * right.X + left.Y * right.Y;
    }
}
