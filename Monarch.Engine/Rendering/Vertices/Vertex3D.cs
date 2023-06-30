using Monarch.Engine.Maths;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Rendering.Vertices
{
    /*[StructLayout(LayoutKind.Sequential)]
    public record struct Vertex3D(
        Vector3f Position
        ) : IVertex3D;*/

    [StructLayout(LayoutKind.Explicit)]
    public record struct Vertex3D : IVertex3D
    {
        public Vertex3D(Vector3f position) => Position = position;

        [FieldOffset(0)]
        public Vector3f Position;
    }
}
