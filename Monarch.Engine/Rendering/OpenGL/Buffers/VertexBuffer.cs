using Monarch.Engine.Rendering.Vertices;
using Silk.NET.OpenGL;
using SpiceEngine.Core.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Monarch.Engine.Rendering.OpenGL.Buffers
{
    public class VertexBuffer<T> : OpenGLObject where T : struct, IVertex
    {
        private readonly int _vertexSize;
        private readonly List<T> _vertices = new();

        public VertexBuffer(GL gl) : base(gl) => _vertexSize = UnitConversions.SizeOf(typeof(T));

        public int Count => _vertices.Count;

        protected override uint Create() => _gl.GenBuffer();
        protected override void Delete() => _gl.DeleteBuffer(Handle);

        public override void Bind() => _gl.BindBuffer(BufferTargetARB.ArrayBuffer, Handle);
        public override void Unbind() => _gl.BindBuffer(BufferTargetARB.ArrayBuffer, 0);

        public void AddVertex(T vertex) => _vertices.Add(vertex);
        public void AddVertices(params T[] vertices) => _vertices.AddRange(vertices);
        public void AddVertices(IEnumerable<T> vertices) => _vertices.AddRange(vertices);

        public void InsertVertex(int index, T vertex) => _vertices.Insert(index, vertex);

        public void SetVertex(int index, T vertex) => _vertices[index] = vertex;

        public T GetVertex(int index) => _vertices[index];

        public void Clear() => _vertices.Clear();

        public void Buffer()
        {
            unsafe
            {
                /*var itemArray = _vertices.ToArray();
                var data = (Span<T>)itemArray;

                fixed (void* d = data)
                {
                    _gl.BufferData(
                        BufferTargetARB.UniformBuffer,
                        (nuint)(data.Length * sizeof(T)),
                        d,
                        BufferUsageARB.StaticDraw);
                }*/

                var itemArray = _vertices.ToArray();
                var handle = GCHandle.Alloc(itemArray, GCHandleType.Pinned);

                try
                {
                    _gl.BufferData(BufferTargetARB.ArrayBuffer, (nuint)(_vertexSize * _vertices.Count), handle.AddrOfPinnedObject(), BufferUsageARB.StaticDraw);
                }
                finally
                {
                    handle.Free();
                }

                /*fixed (void* itemsPtr = itemArray)
                {
                    _gl.BufferData(BufferTargetARB.UniformBuffer, (nuint)(_vertexSize * _vertices.Count), itemsPtr, BufferUsageARB.DynamicDraw);
                }*/

                /*fixed (T* itemsPtr = &itemArray[0])
                {
                    _gl.BufferData(BufferTargetARB.UniformBuffer, (nuint)(_vertexSize * _vertices.Count), itemsPtr, BufferUsageARB.DynamicDraw);
                }*/
            }
        }

        public void DrawPoints() => _gl.DrawArrays(PrimitiveType.Points, 0, (uint)_vertices.Count);

        public void DrawTriangles() => _gl.DrawArrays(PrimitiveType.Triangles, 0, (uint)_vertices.Count);

        public void DrawTriangleStrips() => _gl.DrawArrays(PrimitiveType.TriangleStrip, 0, (uint)_vertices.Count);

        public void DrawQuads() => _gl.DrawArrays(PrimitiveType.Quads, 0, (uint)_vertices.Count);
    }
}
