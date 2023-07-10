using Monarch.Engine.Maths;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Rendering.Vertices
{
    [StructLayout(LayoutKind.Sequential)]
    public record struct TexturedVertex2D(
        Vector2f Position,
        Vector2f TextureCoords
        ) : IVertex2D;
}
