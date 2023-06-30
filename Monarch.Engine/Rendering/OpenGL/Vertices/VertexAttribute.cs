using Silk.NET.OpenGL;

namespace Monarch.Engine.Rendering.OpenGL.Vertices
{
    public class VertexAttribute
    {
        public string Name { get; private set; }

        private readonly int _size;
        private readonly VertexAttribPointerType _type;
        private readonly bool _normalize;
        private readonly uint _stride;
        private readonly IntPtr _offset;

        public VertexAttribute(string name, int size, VertexAttribPointerType type, uint stride, int offset, bool normalize = false)
        {
            Name = name;
            _size = size;
            _type = type;
            _stride = stride;
            _offset = (IntPtr)offset;
            _normalize = normalize;
        }

        public void Set(GL gl, uint index)
        {
            unsafe
            {
                gl.VertexAttribPointer(index, _size, _type, _normalize, _stride, _offset.ToPointer());
            }

            gl.EnableVertexAttribArray(index);

            /*if (_type == VertexAttribPointerType.Int)
            {
                GL.VertexAttribIPointer(index, _size, VertexAttribIntegerType.Int, _normalize, _stride, _offset);
            }*/
        }
    }
}
