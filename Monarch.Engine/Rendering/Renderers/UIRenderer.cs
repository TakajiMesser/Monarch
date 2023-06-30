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
    public class UIRenderer : Renderer
    {
        private ShaderProgram? _program;
        private VertexArray<ViewQuadVertex>? _vertexArray;
        private VertexBuffer<ViewQuadVertex>? _vertexBuffer;
        //private FrameBuffer? _frameBuffer;

        public UIRenderer(Display display) : base(display) { }

        //public Texture? OutputTexture { get; private set; }

        protected override void LoadPrograms(GL gl)
        {
            _program = new(gl, new[]
            {
                new ShaderDefinition(ShaderType.VertexShader, Resources.uiquad_vert),
                new ShaderDefinition(ShaderType.GeometryShader, Resources.uiquad_geom),
                new ShaderDefinition(ShaderType.FragmentShader, Resources.uiquad_frag)
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
            _vertexArray = new VertexArray<ViewQuadVertex>(gl);
            _vertexBuffer = new VertexBuffer<ViewQuadVertex>(gl);
            //_frameBuffer = new(gl);

            //_frameBuffer.Add(FramebufferAttachment.ColorAttachment0, OutputTexture);
            //_frameBuffer.Load();

            _vertexBuffer.Load();
            _vertexBuffer.Bind();
            _vertexArray.Load();
            _vertexBuffer.Unbind();
        }

        protected override void Resize(Resolution resolution)
        {
            //OutputTexture!.Resize(resolution.Width, resolution.Height, 0u);
        }

        public void SetVertices(IEnumerable<ViewQuadVertex> vertices)
        {
            _vertexBuffer!.Clear();
            _vertexBuffer!.AddVertices(vertices);
        }

        public void Render(GL gl)
        {
            /*gl.Enable(EnableCap.Blend);
            gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            gl.Disable(EnableCap.DepthTest);
            gl.BindFramebuffer(FramebufferTarget.DrawFramebuffer, 0);*/

            _program!.Bind();
            _program!.SetUniform("resolution", new Vector2f(_display.Resolution.Width, _display.Resolution.Height));
            _program!.SetUniform("halfResolution", new Vector2f(_display.Resolution.Width / 2f, _display.Resolution.Height / 2f));

            _vertexArray!.Bind();
            _vertexBuffer!.Bind();
            _vertexBuffer!.Buffer();
            _vertexBuffer!.DrawPoints();

            _vertexArray!.Unbind();
            _vertexBuffer!.Unbind();

            //gl.Disable(EnableCap.Blend);
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
