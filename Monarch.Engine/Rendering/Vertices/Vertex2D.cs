﻿using Monarch.Engine.Maths;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Rendering.Vertices
{
    [StructLayout(LayoutKind.Sequential)]
    public record struct Vertex2D(
        Vector2f Position
        ) : IVertex2D;
}
