using Monarch.Engine.Maths;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Rendering.Vertices
{
    /*[StructLayout(LayoutKind.Sequential)]
    public record struct Vertex2D(
        Vector2f Position
        ) : IVertex2D;*/

    [StructLayout(LayoutKind.Explicit)]
    public record struct Vertex2D : IVertex2D
    {
        public Vertex2D(Vector2f position) => Position = position;

        [FieldOffset(0)]
        public Vector2f Position;
    }
}
