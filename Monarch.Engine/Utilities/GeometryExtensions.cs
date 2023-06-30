using Monarch.Engine.Maths;
using System.Drawing;

namespace SpiceEngine.Core.Utilities
{
    public static class GeometryExtensions
    {
        public static Vector2f ToVector2(this Point point) => new Vector2f(point.X, point.Y);
    }
}
