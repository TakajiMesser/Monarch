using Monarch.Engine.Maths;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Rendering.Vertices
{
    [StructLayout(LayoutKind.Sequential)]
    public record struct GridVertex(
        Vector3f Position,
        Color4 InnerColor,
        Color4 BorderColor
        ) : IVertex3D;
}
