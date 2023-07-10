using Monarch.Engine.Maths;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Rendering.Vertices
{
    [StructLayout(LayoutKind.Sequential)]
    public record struct TextVertex(
        Vector2f Position,
        Vector2f TextureCoords,
        Color4 Color
        ) : IVertex2D;
}
