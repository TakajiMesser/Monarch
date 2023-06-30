using Silk.NET.OpenGL;

namespace Monarch.Engine.Rendering.OpenGL.Shaders
{
    public record struct ShaderDefinition(
        ShaderType ShaderType,
        string Code
        );
}
