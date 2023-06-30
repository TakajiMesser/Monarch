using Silk.NET.OpenGL;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Rendering.OpenGL.Buffers
{
    public class VertexIndexBuffer : OpenGLObject
    {
        private readonly List<ushort> _indices = new();

        public VertexIndexBuffer(GL gl) : base(gl) { }

        protected override uint Create() => _gl.GenBuffer();
        protected override void Delete() => _gl.DeleteBuffer(Handle);

        public override void Bind() => _gl.BindBuffer(BufferTargetARB.ElementArrayBuffer, Handle);
        public override void Unbind() => _gl.BindBuffer(BufferTargetARB.ElementArrayBuffer, 0);

        public void AddIndex(ushort index) => _indices.Add(index);

        public void AddIndices(IEnumerable<ushort> indices) => _indices.AddRange(indices);

        public void Clear() => _indices.Clear();

        public void Buffer()
        {
            unsafe
            {
                var itemArray = _indices.ToArray();

                fixed (ushort* itemsPtr = &itemArray[0])
                {
                    _gl.BufferData(BufferTargetARB.ElementArrayBuffer, (nuint)(Marshal.SizeOf<ushort>() * _indices.Count), itemsPtr, BufferUsageARB.StreamDraw);
                }
            }
        }

        public void Draw() => _gl.DrawElements(PrimitiveType.Triangles, (uint)_indices.Count, DrawElementsType.UnsignedShort, IntPtr.Zero);
    }
}
