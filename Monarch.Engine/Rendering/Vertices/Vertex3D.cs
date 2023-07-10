using Monarch.Engine.Maths;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Rendering.Vertices
{
    [StructLayout(LayoutKind.Sequential)]
    public record struct Vertex3D(
        Vector3f Position
        ) : IVertex3D;
}
