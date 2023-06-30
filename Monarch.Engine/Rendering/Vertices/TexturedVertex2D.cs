using Monarch.Engine.Maths;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Rendering.Vertices
{
    /*[StructLayout(LayoutKind.Sequential)]
    public record struct TexturedVertex2D(
        Vector2f Position,
        Vector2f TextureCoords
        ) : IVertex2D;*/

    [StructLayout(LayoutKind.Explicit)]
    public record struct TexturedVertex2D : IVertex2D
    {
        public TexturedVertex2D(Vector2f position, Vector2f textureCoords)
        {
            Position = position;
            TextureCoords = textureCoords;
        }

        [FieldOffset(0)]
        public Vector2f Position;

        [FieldOffset(8)]
        public Vector2f TextureCoords;
    }
}
