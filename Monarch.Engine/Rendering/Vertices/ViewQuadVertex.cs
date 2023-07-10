using Monarch.Engine.Maths;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Rendering.Vertices
{
    [StructLayout(LayoutKind.Sequential)]
    public record struct ViewQuadVertex(
        Vector3f Position,
        float BorderThickness,
        Vector2f Size,
        Vector2f CornerRadius,
        Color4 Color,
        Color4 BorderColor//,
        //Color4 SelectionID
        ) : IVertex3D;
}
