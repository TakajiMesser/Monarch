using Silk.NET.OpenGL;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Rendering.OpenGL.Buffers
{
    public abstract class ShaderStorageBuffer<T> : OpenGLObject
    {
        protected readonly int _size;

        public ShaderStorageBuffer(GL gl, string name, uint binding) : base(gl)
        {
            Name = name;
            Binding = binding;
            _size = Marshal.SizeOf<T>();
        }

        public string Name { get; }
        public uint Binding { get; }

        protected override uint Create() => _gl.GenBuffer();
        protected override void Delete() => _gl.DeleteBuffer(Handle);

        public override void Bind() => _gl.BindBuffer(BufferTargetARB.ShaderStorageBuffer, Handle);
        public override void Unbind() => _gl.BindBuffer(BufferTargetARB.ShaderStorageBuffer, 0);

        public void Buffer() => _gl.BindBufferBase(BufferTargetARB.ShaderStorageBuffer, Binding, Handle);
        // GL.BindBuffer(BufferTarget.ShaderStorageBuffer, _handle);
        // GL.BindBufferBase(BufferRangeTarget.ShaderStorageBuffer, index, _id);
        // GL.BufferData(BufferTarget.ShaderStorageBuffer, (int)EngineHelper.size.vec2, ref default_luminosity, BufferUsageHint.DynamicCopy);
        // GL.GetBufferSubData(BufferTarget.ShaderStorageBuffer, (IntPtr)0, exp_size, ref lumRead);
    }
}
