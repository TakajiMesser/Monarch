using Monarch.Engine.HID;
using Monarch.Engine.Maths;
using Monarch.Engine.Properties;
using Monarch.Engine.Rendering.OpenGL.Buffers;
using Monarch.Engine.Rendering.OpenGL.Shaders;
using Monarch.Engine.Rendering.OpenGL.Vertices;
using Monarch.Engine.Rendering.Vertices;
using Silk.NET.OpenGL;
using SpiceEngine.Core.Utilities;

namespace Monarch.Engine.Rendering.Renderers
{
    public class GridRenderer : Renderer
    {
        private ShaderProgram? _program;
        private VertexArray<GridVertex>? _vertexArray;
        private VertexBuffer<GridVertex>? _vertexBuffer;

        public GridRenderer(Display display) : base(display) { }

        //public Texture? OutputTexture { get; private set; }

        protected override void LoadPrograms(GL gl)
        {
            _program = new(gl, new[]
            {
                new ShaderDefinition(ShaderType.VertexShader, Resources.grid_vert),
                new ShaderDefinition(ShaderType.GeometryShader, Resources.grid_geom),
                new ShaderDefinition(ShaderType.FragmentShader, Resources.grid_frag)
            });
            _program.Load();
        }

        protected override void LoadTextures(GL gl)
        {
            /*OutputTexture = new(gl, _display.Resolution.Width, _display.Resolution.Height, 0u)
            {
                Target = TextureTarget.Texture2D,
                EnableMipMap = false,
                EnableAnisotropy = false,
                InternalFormat = InternalFormat.Rgba16f,
                PixelFormat = PixelFormat.Rgba,
                PixelType = PixelType.Float,
                MinFilter = TextureMinFilter.Linear,
                MagFilter = TextureMagFilter.Linear,
                WrapMode = TextureWrapMode.ClampToBorder
            };
            OutputTexture.Load();*/
        }

        protected override void LoadBuffers(GL gl)
        {
            _vertexArray = new VertexArray<GridVertex>(gl);
            _vertexBuffer = new VertexBuffer<GridVertex>(gl);

            _vertexBuffer.Load();
            _vertexBuffer.Bind();
            _vertexArray.Load();
            _vertexBuffer.Unbind();

            _vertexBuffer.AddVertices(
                new GridVertex(new Vector3f(0f, 0f, 0f), 0.05f, Color4.YellowGreen, Color4.Brown),
                new GridVertex(new Vector3f(0f, -1f, 1f), 0.02f, Color4.YellowGreen, Color4.Red),
                new GridVertex(new Vector3f(1f, 0f, -1f), 0.02f, Color4.YellowGreen, Color4.Green),
                new GridVertex(new Vector3f(-1f, 1f, 0f), 0.02f, Color4.YellowGreen, Color4.Blue)
                );
        }

        public void Render(GL gl)
        {
            //if (texture.Target != TextureTarget.Texture2D) throw new ArgumentException("Cannot handle texture target " + texture.Target, nameof(texture));

            //gl.BindFramebuffer(FramebufferTarget.DrawFramebuffer, 0);
            //gl.Clear(ClearBufferMask.ColorBufferBit);
            //gl.Viewport(0, 0, _display.Resolution.Width, _display.Resolution.Height);

            _program!.Bind();
            //_program!.BindTexture(texture, "textureSampler", 0);

            var cameraPosition = new Vector3f(0f, 0f, 20f);
            
            _program!.SetUniform("modelMatrix", Matrix4.Identity);
            //_program!.SetUniform("viewMatrix", Matrix4.Identity);
            _program!.SetUniform("projectionMatrix", Matrix4.Identity);

            _program!.SetUniform("viewMatrix", Matrix4.LookAt(
                eye: Vector3f.One,
                target: Vector3f.One,
                up: Vector3f.One
                ));

            /*_program!.SetUniform("viewMatrix", Matrix4.LookAt(
                eye: cameraPosition,//Vector3f.Zero,
                target: cameraPosition - Vector3f.UnitZ,
                up: cameraPosition + Vector3f.UnitY)
                );
            _program!.SetUniform("projectionMatrix", Matrix4.CreatePerspectiveFieldOfView(UnitConversions.ToRadians(45f), 1f, 0.1f, 1000f));*/

            var radius = 0.2f;
            var apothem = (float)Math.Sqrt(3.0) * 0.5f * radius;
            _program!.SetUniform("radius", radius);
            _program!.SetUniform("apothem", apothem);

            _vertexArray!.Bind();
            _vertexBuffer!.Bind();
            _vertexBuffer!.Buffer();
            _vertexBuffer!.DrawPoints();

            _vertexArray!.Unbind();
            _vertexBuffer!.Unbind();
        }

        public override void Dispose()
        {
            _program?.Dispose();
            _vertexArray?.Dispose();
            _vertexBuffer?.Dispose();
        }
    }
}
