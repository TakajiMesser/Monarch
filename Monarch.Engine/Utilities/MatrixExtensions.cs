﻿using Monarch.Engine.Maths;

namespace SpiceEngine.Core.Utilities
{
    public static class MatrixExtensions
    {
        public static Vector3f GetTranslation(this Matrix4 transform) =>
            //new Vector3f(transform.M14, transform.M24, transform.M34);
            new Vector3f(transform.M03, transform.M13, transform.M23);

        public static Vector3f GetScale(this Matrix4 transform) => new Vector3f(transform.Column0.Length, transform.Column1.Length, transform.Column2.Length);

        public static Quaternion GetRotation(this Matrix4 transform)
        {
            var scale = transform.GetScale();
            var rotationMatrix = new Matrix3()
            {
                M00 = transform.M11 / scale.X,
                M01 = transform.M12 / scale.Y,
                M02 = transform.M13 / scale.Z,
                M10 = transform.M21 / scale.X,
                M11 = transform.M22 / scale.Y,
                M12 = transform.M23 / scale.Z,
                M20 = transform.M31 / scale.X,
                M21 = transform.M32 / scale.Y,
                M22 = transform.M33 / scale.Z
            };

            /*var rotationMatrix = new Matrix3()
            {
                M00 = transform.M00 / scale.X,
                M01 = transform.M01 / scale.Y,
                M02 = transform.M02 / scale.Z,
                M10 = transform.M10 / scale.X,
                M11 = transform.M11 / scale.Y,
                M12 = transform.M12 / scale.Z,
                M20 = transform.M20 / scale.X,
                M21 = transform.M21 / scale.Y,
                M22 = transform.M22 / scale.Z
            };*/

            return Quaternion.FromMatrix(rotationMatrix);
        }

        public static Matrix3 GetRotationMatrix(this Matrix4 transform)
        {
            var scale = transform.GetScale();
            return new Matrix3()
            {
                M00 = transform.M11 / scale.X,
                M01 = transform.M12 / scale.Y,
                M02 = transform.M13 / scale.Z,
                M10 = transform.M21 / scale.X,
                M11 = transform.M22 / scale.Y,
                M12 = transform.M23 / scale.Z,
                M20 = transform.M31 / scale.X,
                M21 = transform.M32 / scale.Y,
                M22 = transform.M33 / scale.Z
            };
            /*return new Matrix3()
            {
                M00 = transform.M00 / scale.X,
                M01 = transform.M01 / scale.Y,
                M02 = transform.M02 / scale.Z,
                M10 = transform.M10 / scale.X,
                M11 = transform.M11 / scale.Y,
                M12 = transform.M12 / scale.Z,
                M20 = transform.M20 / scale.X,
                M21 = transform.M21 / scale.Y,
                M22 = transform.M22 / scale.Z
            };*/
        }
    }
}
