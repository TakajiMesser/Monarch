using Monarch.Engine.Maths;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpiceEngine.Core.Utilities
{
    public static class VectorExtensions
    {
        public static float AngleBetween(this Vector2f vectorA, Vector2f vectorB)
        {
            var cosAngle = Vector2f.Dot(vectorA, vectorB) / (vectorA.Length * vectorB.Length);
            return (float)Math.Acos(cosAngle);
        }

        public static float AngleBetween(this Vector3f vectorA, Vector3f vectorB)
        {
            var cosAngle = Vector3f.Dot(vectorA, vectorB) / (vectorA.Length * vectorB.Length);
            return (float)Math.Acos(cosAngle);
        }

        public static bool IsSignificant(this Vector2f vector) => vector.X >= MathExtensions.EPSILON || vector.X <= -MathExtensions.EPSILON
            || vector.Y >= MathExtensions.EPSILON || vector.Y <= -MathExtensions.EPSILON;

        public static bool IsSignificant(this Vector3f vector) => vector.X >= MathExtensions.EPSILON || vector.X <= -MathExtensions.EPSILON
            || vector.Y >= MathExtensions.EPSILON || vector.Y <= -MathExtensions.EPSILON
            || vector.Z >= MathExtensions.EPSILON || vector.Z <= -MathExtensions.EPSILON;

        public static Color4 ToColor4(this Vector4f vector) => new(vector.X, vector.Y, vector.Z, vector.W);

        public static Vector3f ToRadians(this Vector3f vector) => new(UnitConversions.ToRadians(vector.X), UnitConversions.ToRadians(vector.Y), UnitConversions.ToRadians(vector.Z));

        public static Vector3f ToDegrees(this Vector3f vector) => new(UnitConversions.ToDegrees(vector.X), UnitConversions.ToDegrees(vector.Y), UnitConversions.ToDegrees(vector.Z));

        public static Vector3f Average(this IEnumerable<Vector3f> vertices) => new()
        {
            X = vertices.Average(v => v.X),
            Y = vertices.Average(v => v.Y),
            Z = vertices.Average(v => v.Z)
        };
    }
}
