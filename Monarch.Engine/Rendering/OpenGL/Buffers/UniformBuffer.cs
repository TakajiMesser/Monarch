using Silk.NET.OpenGL;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Rendering.OpenGL.Buffers
{
    public abstract class UniformBuffer<T> : OpenGLObject where T : struct
    {
        protected readonly int _size;

        public UniformBuffer(GL gl, string name, uint binding) : base(gl)
        {
            Name = name;
            Binding = binding;
            _size = Marshal.SizeOf<T>();
        }

        public string Name { get; }
        public uint Binding { get; }

        public override void Load()
        {
            base.Load();

            var blockIndex = _gl.GetUniformBlockIndex(Handle, Name);
            _gl.UniformBlockBinding(Handle, blockIndex, Binding);
        }

        protected override uint Create() => _gl.GenBuffer();
        protected override void Delete() => _gl.DeleteBuffer(Handle);

        public override void Bind() => _gl.BindBuffer(BufferTargetARB.UniformBuffer, Handle);
        public override void Unbind() => _gl.BindBuffer(BufferTargetARB.UniformBuffer, 0);

        public virtual void Buffer() => _gl.BindBufferBase(BufferTargetARB.UniformBuffer, Binding, Handle);
    }
}
