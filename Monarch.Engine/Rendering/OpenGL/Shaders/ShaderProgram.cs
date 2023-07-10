using Monarch.Engine.Maths;
using Monarch.Engine.Rendering.OpenGL.Buffers;
using Silk.NET.OpenGL;
using Texture = Monarch.Engine.Rendering.OpenGL.Textures.Texture;

namespace Monarch.Engine.Rendering.OpenGL.Shaders
{
    public class ShaderProgram : OpenGLObject
    {
        public ShaderProgram(GL gl, params ShaderDefinition[] definitions) : base(gl) => Definitions = definitions;

        public ShaderDefinition[] Definitions { get; }

        public override void Load()
        {
            base.Load();

            var shaders = Definitions.Select(d => new Shader(_gl, d));

            foreach (var shader in shaders)
            {
                shader.Load();
                _gl.AttachShader(Handle, shader.Handle);
            }

            _gl.LinkProgram(Handle);

            var linkStatus = _gl.GetProgram(Handle, GLEnum.LinkStatus);
            if (linkStatus == 0)
            {
                var errorLog = _gl.GetProgramInfoLog(Handle);
                Unload();
                throw new Exception("Shader linking failed: " + errorLog);
            }

            foreach (var shader in shaders)
            {
                _gl.DetachShader(Handle, shader.Handle);
            }
        }

        protected override uint Create() => _gl.CreateProgram();
        protected override void Delete() => _gl.DeleteProgram(Handle);

        public override void Bind() => _gl.UseProgram(Handle);
        public override void Unbind() => _gl.UseProgram(0);

        public int GetAttributeLocation(string name) => _gl.GetAttribLocation(Handle, name);

        public int GetUniformLocation(string name) => _gl.GetUniformLocation(Handle, name);

        public void BindUniformBlock(string name, uint binding)
        {
            var blockIndex = _gl.GetUniformBlockIndex(Handle, name);
            _gl.UniformBlockBinding(Handle, blockIndex, binding);
        }

        public void BindShaderStorageBlock<T>(ShaderStorageBuffer<T> buffer)
        {
            _gl.ShaderStorageBlockBinding(buffer.Handle, 0u, buffer.Binding);
        }

        public void BindShaderStorageBlock(string name, uint binding)
        {
            var blockIndex = 0u;
            _gl.ShaderStorageBlockBinding(Handle, blockIndex, binding);
        }

        public void BindTexture(Texture texture, string name, uint index)
        {
            var location = GetUniformLocation(name);

            _gl.ActiveTexture(TextureUnit.Texture0 + (int)index);
            texture.Bind();
            _gl.Uniform1(location, index);
        }

        /*var diffuseMap = textureProvider.RetrieveTexture(textureMapping.DiffuseIndex);
        GL.Uniform1(GetUniformLocation("useDiffuseMap"), (diffuseMap != null) ? 1 : 0);
        if (diffuseMap != null)
        {
            BindTexture(diffuseMap, "diffuseMap", 0);
        }*/

        public void BindImageTexture(Texture texture, string name, uint index)
        {
            var location = GetUniformLocation(name);

            _gl.ActiveTexture(TextureUnit.Texture0 + (int)index);
            //texture.BindImageTexture(index);
            _gl.Uniform1(location, index);
        }

        public void SetUniform<T>(string name, T value) where T : struct
        {
            switch (value)
            {
                case Matrix4 matrix4:
                    SetUniform(name, matrix4);
                    break;
                case Matrix4[] matrices:
                    SetUniform(name, matrices);
                    break;
                case Vector2f vector2:
                    SetUniform(name, vector2);
                    break;
                case Vector3f vector3:
                    SetUniform(name, vector3);
                    break;
                case Vector4f vector4:
                    SetUniform(name, vector4);
                    break;
                case Color4 color4:
                    SetUniform(name, color4);
                    break;
                case float floatValue:
                    SetUniform(name, floatValue);
                    break;
                case int intValue:
                    SetUniform(name, intValue);
                    break;
                default:
                    throw new Exception("Could not handle uniform of type " + typeof(T));
            }
        }

        private void SetMatrix4Uniform(int location, ref Matrix4 matrix)
        {
            _gl.UniformMatrix4(location, 1, false, matrix.Values);

            /*unsafe
            {
                fixed (float* matrix_ptr = &matrix.Values[0])
                {
                    _gl.UniformMatrix4(location, 16u, false, matrix_ptr);
                }

                /*fixed (float* matrix_ptr = &matrix.Row0.X)
                {
                    GL.UniformMatrix4(location, 1, false, matrix_ptr);
                }*
            }*/
        }

        public void SetUniform(string name, Matrix4 matrix)
        {
            var location = GetUniformLocation(name);
            SetMatrix4Uniform(location, ref matrix);
        }

        public void SetUniform(string name, Matrix4[] matrices)
        {
            for (var i = 0; i < matrices.Length; i++)
            {
                var iLocation = GetUniformLocation(name + "[" + i + "]");
                SetMatrix4Uniform(iLocation, ref matrices[i]);
            }

            /*int location = GetUniformLocation(name);
            float[] values = new float[16 * matrices.Length];

            for (var i = 0; i < matrices.Length; i++)
            {
                var columns = new Vector4[]
                {
                    matrices[i].Column0,
                    matrices[i].Column1,
                    matrices[i].Column2,
                    matrices[i].Column3
                };

                for (var j = 0; j < 4; j++)
                {
                    values[i * 16 + j * 4] = columns[j].X;
                    values[i * 16 + j * 4 + 1] = columns[j].Y;
                    values[i * 16 + j * 4 + 2] = columns[j].Z;
                    values[i * 16 + j * 4 + 3] = columns[j].W;
                }
            }

            GL.UniformMatrix4(location, matrices.Length, true, values);*/
        }

        public void SetUniform(string name, Vector2f vector)
        {
            var location = GetUniformLocation(name);
            _gl.Uniform2(location, vector.X, vector.Y);
        }

        public void SetUniform(string name, Vector3f vector)
        {
            var location = GetUniformLocation(name);
            _gl.Uniform3(location, vector.X, vector.Y, vector.Z);
        }

        public void SetUniform(string name, Vector4f vector)
        {
            var location = GetUniformLocation(name);
            _gl.Uniform4(location, vector.X, vector.Y, vector.Z, vector.W);
        }

        public void SetUniform(string name, Color4 color)
        {
            var location = GetUniformLocation(name);
            _gl.Uniform4(location, color.R, color.G, color.B, color.A);
        }

        public void SetUniform(string name, float value)
        {
            var location = GetUniformLocation(name);
            _gl.Uniform1(location, value);
        }

        public void SetUniform(string name, int value)
        {
            var location = GetUniformLocation(name);
            _gl.Uniform1(location, value);
        }

        public int GetVertexAttributeLocation(string name)
        {
            var index = GetAttributeLocation(name);
            if (index == -1)
            {
                // Note that any attributes not explicitly used in the shaders will be optimized out by the shader compiler, resulting in (index == -1)
                //throw new ArgumentOutOfRangeException(_name + " not found in program attributes");
            }

            return index;
        }
    }
}
