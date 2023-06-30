using SpiceEngine.Core.Utilities;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Maths
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Vector4f : IEquatable<Vector4f>
    {
        public Vector4f(Vector3f xyz, float w) : this(xyz.X, xyz.Y, xyz.Z, w) { }
        public Vector4f(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        [FieldOffset(0)]
        public float X;
        //public float X { get; set; }

        [FieldOffset(4)]
        public float Y;
        //public float Y { get; set; }

        [FieldOffset(8)]
        public float Z;
        //public float Z { get; set; }

        [FieldOffset(12)]
        public float W;
        //public float W { get; set; }


        public Vector2f Xy
        {
            get => new(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

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

        public float this[int index]
        {
            get
            {
                return index switch
                {
                    0 => X,
                    1 => Y,
                    2 => Z,
                    3 => W,
                    _ => throw new IndexOutOfRangeException("You tried to access this vector at index: " + index)
                };
            }

            set
            {
                switch (index)
                {
                    case 0:
                        X = value;
                        break;
                    case 1:
                        Y = value;
                        break;
                    case 2:
                        Z = value;
                        break;
                    case 3:
                        W = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("You tried to set this vector at index: " + index);
                }
            }
        }

        public bool IsReal => X.IsReal() && Y.IsReal() && Z.IsReal() && W.IsReal();

        public float LengthSquared => X * X + Y * Y + Z * Z + W * W;

        public float Length => (float)Math.Sqrt(LengthSquared);

        public float LengthFast => 1.0f / MathExtensions.InverseSqrtFast(LengthSquared);

        public Vector4f Normalized()
        {
            var scale = 1.0f / Length;
            return new Vector4f(X * scale, Y * scale, Z * scale, W * scale);
        }

        public Vector4f NormalizedFast()
        {
            var scale = MathExtensions.InverseSqrtFast(LengthSquared);
            return new Vector4f(X * scale, Y * scale, Z * scale, W * scale);
        }

        public override string ToString() => "<" + X + "," + Y + "," + Z + "," + W + ">";

        public override bool Equals(object obj) => obj is Vector4f vector && Equals(vector);

        public bool Equals(Vector4f other) => X == other.X && Y == other.Y && Z == other.Z && W == other.W;

        public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);

        public static readonly Vector4f UnitX = new(1f, 0f, 0f, 0f);

        public static readonly Vector4f UnitY = new(0f, 1f, 0f, 0f);

        public static readonly Vector4f UnitZ = new(0f, 0f, 1f, 0f);

        public static readonly Vector4f UnitW = new(0f, 0f, 0f, 1f);

        public static readonly Vector4f Zero = new(0f, 0f, 0f, 0f);

        public static readonly Vector4f One = new(1f, 1f, 1f, 1f);

        public static bool operator ==(Vector4f left, Vector4f right) => left.Equals(right);

        public static bool operator !=(Vector4f left, Vector4f right) => !(left == right);

        public static Vector4f operator +(Vector4f left, Vector4f right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

        public static Vector4f operator -(Vector4f left, Vector4f right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

        public static Vector4f operator -(Vector4f vector) => new(-vector.X, -vector.Y, -vector.Z, -vector.W);

        public static Vector4f operator *(Vector4f vector, float scale) => new(vector.X * scale, vector.Y * scale, vector.Z * scale, vector.W * scale);

        public static Vector4f operator *(Vector4f left, Vector4f right) => new(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);

        public static Vector4f operator *(Quaternion quaternion, Vector4f vector) => Transform(vector, quaternion);

        public static Vector4f operator *(Vector4f vector, Matrix4 matrix) => TransformRow(vector, matrix);

        public static Vector4f operator *(Matrix4 matrix, Vector4f vector) => TransformColumn(vector, matrix);

        /*public static Vector4f operator *(Vector4f vector, CMatrix4 matrix) => new Vector4f(
            (vector.X * matrix.M00) + (vector.Y * matrix.M10) + (vector.Z * matrix.M20) + (vector.W * matrix.M30),
            (vector.X * matrix.M01) + (vector.Y * matrix.M11) + (vector.Z * matrix.M21) + (vector.W * matrix.M31),
            (vector.X * matrix.M02) + (vector.Y * matrix.M12) + (vector.Z * matrix.M22) + (vector.W * matrix.M32),
            (vector.X * matrix.M03) + (vector.Y * matrix.M13) + (vector.Z * matrix.M23) + (vector.W * matrix.M33));

        public static Vector4f operator *(CMatrix4 matrix, Vector4f vector) => new Vector4f(
            (matrix.M00 * vector.X) + (matrix.M01 * vector.Y) + (matrix.M02 * vector.Z) + (matrix.M03 * vector.W),
            (matrix.M10 * vector.X) + (matrix.M11 * vector.Y) + (matrix.M12 * vector.Z) + (matrix.M13 * vector.W),
            (matrix.M20 * vector.X) + (matrix.M21 * vector.Y) + (matrix.M22 * vector.Z) + (matrix.M23 * vector.W),
            (matrix.M30 * vector.X) + (matrix.M31 * vector.Y) + (matrix.M32 * vector.Z) + (matrix.M33 * vector.W));*/

        public static Vector4f operator /(Vector4f vector, float scale) => new(vector.X / scale, vector.Y / scale, vector.Z / scale, vector.W / scale);

        public static Vector4f operator /(Vector4f left, Vector4f right) => new(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);

        public static float Dot(Vector4f left, Vector4f right) => left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;

        public static Vector4f Transform(Quaternion quaternion, Vector4f vector)
        {
            var vectorQuat = new Quaternion(vector.X, vector.Y, vector.Z, vector.W);
            var invertedQuat = quaternion.Inverted();
            var rotatedQuat = (quaternion * vectorQuat) * invertedQuat;

            return new(rotatedQuat.X, rotatedQuat.Y, rotatedQuat.Z, rotatedQuat.W);
        }

        public static Vector4f Transform(Vector4f vector, Quaternion quaternion)
        {
            var v = new Quaternion(vector.X, vector.Y, vector.Z, vector.W);
            var i = quaternion.Inverted();
            var t = quaternion * v;
            v = t * i;

            return new(v.X, v.Y, v.Z, v.W);
        }

        public static Vector4f TransformRow(Vector4f vector, Matrix4 matrix) => new(
            (vector.X * matrix.Row0.X) + (vector.Y * matrix.Row1.X) + (vector.Z * matrix.Row2.X) + (vector.W * matrix.Row3.X),
            (vector.X * matrix.Row0.Y) + (vector.Y * matrix.Row1.Y) + (vector.Z * matrix.Row2.Y) + (vector.W * matrix.Row3.Y),
            (vector.X * matrix.Row0.Z) + (vector.Y * matrix.Row1.Z) + (vector.Z * matrix.Row2.Z) + (vector.W * matrix.Row3.Z),
            (vector.X * matrix.Row0.W) + (vector.Y * matrix.Row1.W) + (vector.Z * matrix.Row2.W) + (vector.W * matrix.Row3.W));

        public static Vector4f TransformColumn(Vector4f vector, Matrix4 matrix) => new(
            (matrix.Row0.X * vector.X) + (matrix.Row0.Y * vector.Y) + (matrix.Row0.Z * vector.Z) + (matrix.Row0.W * vector.W),
            (matrix.Row1.X * vector.X) + (matrix.Row1.Y * vector.Y) + (matrix.Row1.Z * vector.Z) + (matrix.Row1.W * vector.W),
            (matrix.Row2.X * vector.X) + (matrix.Row2.Y * vector.Y) + (matrix.Row2.Z * vector.Z) + (matrix.Row2.W * vector.W),
            (matrix.Row3.X * vector.X) + (matrix.Row3.Y * vector.Y) + (matrix.Row3.Z * vector.Z) + (matrix.Row3.W * vector.W));
    }
}
