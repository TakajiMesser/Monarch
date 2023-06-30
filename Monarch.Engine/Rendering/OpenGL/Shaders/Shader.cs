using Silk.NET.OpenGL;

namespace Monarch.Engine.Rendering.OpenGL.Shaders
{
    public class Shader : OpenGLObject
    {
        public Shader(GL gl, ShaderDefinition definition) : base(gl) => Definition = definition;

        public ShaderDefinition Definition { get; }

        public override void Load()
        {
            base.Load();

            _gl.ShaderSource(Handle, Definition.Code);
            _gl.CompileShader(Handle);

            var errorLog = _gl.GetShaderInfoLog(Handle);

            if (!string.IsNullOrWhiteSpace(errorLog))
            {
                Unload();
                throw new Exception(Definition.ShaderType + " Shader failed to compile: " + errorLog);
            }
        }

        protected override uint Create() => _gl.CreateShader(Definition.ShaderType);
        protected override void Delete() => _gl.DeleteShader(Handle);

        public override void Bind() { }
        public override void Unbind() { }
    }
}
