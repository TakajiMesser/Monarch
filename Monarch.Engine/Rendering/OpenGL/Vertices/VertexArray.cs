using Monarch.Engine.Maths;
using Monarch.Engine.Rendering.Vertices;
using Silk.NET.OpenGL;

namespace Monarch.Engine.Rendering.OpenGL.Vertices
{
    public class VertexArray<TVertex> : OpenGLObject where TVertex : IVertex
    {
        public VertexArray(GL gl) : base(gl) { }

        public override void Load()
        {
            base.Load();

            Bind();
            SetVertexAttributes();
            Unbind();
        }

        protected override uint Create() => _gl.GenVertexArray();
        protected override void Delete() => _gl.DeleteVertexArray(Handle);

        public override void Bind() => _gl.BindVertexArray(Handle);
        public override void Unbind() => _gl.BindVertexArray(0);

        private unsafe VertexAttribute[] GetAttributes()
        {
            if (typeof(TVertex) == typeof(Vertex3D))
            {
                return new[]
                {
                    new VertexAttribute("vPosition", 3, VertexAttribPointerType.Float, 12, 0),
                };
            }
            else if (typeof(TVertex) == typeof(Vertex2D))
            {
                return new[]
                {
                    new VertexAttribute("vPosition", 2, VertexAttribPointerType.Float, 8, 0),
                };
            }
            else if (typeof(TVertex) == typeof(TexturedVertex2D))
            {
                return new[]
                {
                    new VertexAttribute("vPosition", 2, VertexAttribPointerType.Float, 16, 0),
                    new VertexAttribute("vTextureCoords", 2, VertexAttribPointerType.Float, 16, 8)
                };
            }
            else if (typeof(TVertex) == typeof(ViewQuadVertex))
            {
                return new[]
                {
                    new VertexAttribute("vPosition", 3, VertexAttribPointerType.Float, 12, 0)
                    /*new VertexAttribute("vPosition", 3, VertexAttribPointerType.Float, 64, 0),
                    new VertexAttribute("vBorderThickness", 1, VertexAttribPointerType.Float, 64, 12),
                    new VertexAttribute("vSize", 2, VertexAttribPointerType.Float, 64, 16),
                    new VertexAttribute("vCornerRadius", 2, VertexAttribPointerType.Float, 64, 24),
                    new VertexAttribute("vColor", 4, VertexAttribPointerType.Float, 64, 32),
                    new VertexAttribute("vBorderColor", 4, VertexAttribPointerType.Float, 64, 48),*/
                };
            }
            else
            {
                return Array.Empty<VertexAttribute>();
            }
        }

        private void SetVertexAttributes()
        {
            var attributes = GetAttributes();
            for (var i = 0u; i < attributes.Length; i++)
            {
                attributes[i].Set(_gl, i);
            }

            /*unsafe
            {
                Vao.VertexAttributePointer(0, 3, VertexAttribPointerType.Float, 5, 0);
                Vao.VertexAttributePointer(1, 2, VertexAttribPointerType.Float, 5, 3);
            }*/

            // TODO - This should all either be hard-coded or determined at compile time, since doing this on the fly is pointlessly wasteful
            /*uint stride = (uint)Marshal.SizeOf<TVertex>();
            int offset = 0;

            var properties = typeof(TVertex).GetProperties();

            for (var i = 0u; i < properties.Length; i++)
            {
                _gl.EnableVertexAttribArray(i);

                var size = GetSize(properties[i].PropertyType);
                //IntPtr offset = Marshal.OffsetOf<T>(properties[i].Name);
                var type = GetPointerType(properties[i].PropertyType);

                unsafe
                {
                    _gl.VertexAttribPointer(i, size, type, false, stride, ((IntPtr)offset).ToPointer());
                }

                offset += size * 4;
            }*/

            /*foreach (var attribute in VertexHelper.GetAttributes<T>())
            {
                int index = program.GetAttributeLocation(attribute.Name);
                attribute.Set(index);
            }*/
        }

        private int GetSize(Type type)
        {
            if (type == typeof(int) || type == typeof(float))
            {
                return 1;
            }
            else if (type == typeof(Vector2f))
            {
                return 2;
            }
            else if (type == typeof(Vector3f))
            {
                return 3;
            }
            else if (type == typeof(Vector4f) || type == typeof(Color4))
            {
                return 4;
            }
            else
            {
                throw new NotImplementedException("Cannot handle property type " + type);
            }
        }

        private VertexAttribPointerType GetPointerType(Type type)
        {
            if (type == typeof(int))
            {
                return VertexAttribPointerType.Int;
            }
            else if (type == typeof(float)
                || type == typeof(Vector2f)
                || type == typeof(Vector3f)
                || type == typeof(Vector4f)
                || type == typeof(Color4))
            {
                return VertexAttribPointerType.Float;
            }
            else
            {
                throw new NotImplementedException("Cannot handle property type " + type);
            }
        }
    }
}
