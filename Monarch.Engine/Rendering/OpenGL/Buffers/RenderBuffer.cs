using Silk.NET.OpenGL;

namespace Monarch.Engine.Rendering.OpenGL.Buffers
{
    public class RenderBuffer : OpenGLObject
    {
        public RenderBuffer(GL gl, uint width, uint height, RenderbufferTarget target = RenderbufferTarget.Renderbuffer, InternalFormat format = InternalFormat.Rgba) : base(gl)
        {
            Width = width;
            Height = height;
            Target = target;
            Format = format;
        }

        public uint Width { get; private set; }
        public uint Height { get; private set; }

        public RenderbufferTarget Target { get; private set; }
        public InternalFormat Format { get; set; }

        public override void Load()
        {
            base.Load();

            Bind();
            ReserveMemory();
        }

        protected override uint Create() => _gl.GenRenderbuffer();
        protected override void Delete() => _gl.DeleteRenderbuffer(Handle);

        public override void Bind() => _gl.BindRenderbuffer(Target, Handle);
        public override void Unbind() => _gl.BindRenderbuffer(Target, 0);

        public void ReserveMemory() => _gl.RenderbufferStorage(Target, Format, Width, Height);

        public void Resize(uint width, uint height)
        {
            Width = width;
            Height = height;

            Bind();
            ReserveMemory();
        }
    }
}
