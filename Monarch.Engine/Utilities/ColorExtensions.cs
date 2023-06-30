using Monarch.Engine.Maths;

namespace SpiceEngine.Core.Utilities
{
    public static class ColorExtensions
    {
        public static Vector3f ToRGB(this Color4 color) => new Vector3f(color.R, color.G, color.B);

        public static Vector4f ToVector4(this Color4 color) => new Vector4f(color.R, color.G, color.B, color.A);
    }
}
