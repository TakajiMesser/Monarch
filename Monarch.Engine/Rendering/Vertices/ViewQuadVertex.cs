using Monarch.Engine.Maths;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Rendering.Vertices
{
    /*[StructLayout(LayoutKind.)]
    public record struct ViewQuadVertex(
        Vector3f Position,
        float BorderThickness,
        Vector2f Size,
        Vector2f CornerRadius,
        Color4 Color,
        Color4 BorderColor//,
        //Color4 SelectionID
        ) : IVertex3D;*/

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public record struct ViewQuadVertex : IVertex3D
    {
        public ViewQuadVertex(Vector3f position, float borderThickness, Vector2f size, Vector2f cornerRadius, Color4 color, Color4 borderColor)
        {
            Position = position;
            /*BorderThickness = borderThickness;
            Size = size;
            CornerRadius = cornerRadius;
            Color = color;
            BorderColor = borderColor;*/
        }

        //[FieldOffset(0)]
        public Vector3f Position;

        /*[FieldOffset(12)]
        public float BorderThickness;

        [FieldOffset(16)]
        public Vector2f Size;

        [FieldOffset(24)]
        public Vector2f CornerRadius;

        [FieldOffset(32)]
        public Color4 Color;

        [FieldOffset(48)]
        public Color4 BorderColor;*/
    }
}
