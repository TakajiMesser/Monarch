using Monarch.Engine.HID;
using Monarch.Engine.Maths;
using Monarch.Engine.Properties;
using Monarch.Engine.Rendering.OpenGL.Buffers;
using Monarch.Engine.Rendering.OpenGL.Shaders;
using Monarch.Engine.Rendering.OpenGL.Vertices;
using Monarch.Engine.Rendering.Vertices;
using Silk.NET.OpenGL;

namespace Monarch.Engine.Rendering.Renderers
{
    public class TestRenderer : Renderer
    {
        private ShaderProgram? _program;
        private VertexArray<Vertex3D>? _vertexArray;
        private VertexBuffer<Vertex3D>? _vertexBuffer;
        //private FrameBuffer? _frameBuffer;

        public TestRenderer(Display display) : base(display) { }

        //public Texture? OutputTexture { get; private set; }

        protected override void LoadPrograms(GL gl)
        {
            _program = new(gl, new[]
            {
                new ShaderDefinition(ShaderType.VertexShader, Resources.test_vert),
                new ShaderDefinition(ShaderType.FragmentShader, Resources.test_frag)
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
            _vertexArray = new VertexArray<Vertex3D>(gl);
            _vertexBuffer = new VertexBuffer<Vertex3D>(gl);
            /*_frameBuffer = new(gl);

            _frameBuffer.Add(FramebufferAttachment.ColorAttachment0, OutputTexture!);
            _frameBuffer.Load();*/

            _vertexBuffer.Load();
            _vertexBuffer.Bind();
            _vertexArray.Load();
            _vertexBuffer.Unbind();
        }

        protected override void Resize(Resolution resolution)
        {
            //OutputTexture!.Resize(resolution.Width, resolution.Height, 0u);
        }

        public void SetVertex(float x, float y, float z)
        {
            _vertexBuffer!.Clear();
            _vertexBuffer!.AddVertex(
                new Vertex3D(
                    position: new Vector3f(x, y, z)
                    )
                );
        }

        public void Render(GL gl)
        {
            //gl.Disable(EnableCap.DepthTest);
            //gl.BindFramebuffer(FramebufferTarget.DrawFramebuffer, 0);

            _program!.Bind();

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
            //_frameBuffer?.Dispose();
        }
    }
}
