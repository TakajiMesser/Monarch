using Monarch.Engine.HID;
using Monarch.Engine.Maths;
using Monarch.Engine.Properties;
using Monarch.Engine.Rendering.OpenGL.Buffers;
using Monarch.Engine.Rendering.OpenGL.Shaders;
using Monarch.Engine.Rendering.OpenGL.Vertices;
using Monarch.Engine.Rendering.Vertices;
using Silk.NET.OpenGL;
using Texture = Monarch.Engine.Rendering.OpenGL.Textures.Texture;

namespace Monarch.Engine.Rendering.Renderers
{
    public class GridRenderer : Renderer
    {
        private ShaderProgram? _program;
        private VertexArray<Vertex2D>? _vertexArray;
        private VertexBuffer<Vertex2D>? _vertexBuffer;

        public GridRenderer(Display display) : base(display) { }

        public Texture? OutputTexture { get; private set; }

        protected override void LoadPrograms(GL gl)
        {
            _program = new(gl, new[]
            {
                new ShaderDefinition(ShaderType.VertexShader, Resources.screen_vert),
                new ShaderDefinition(ShaderType.FragmentShader, Resources.screen_frag)
            });
            _program.Load();
        }

        protected override void LoadTextures(GL gl)
        {
            OutputTexture = new(gl, _display.Resolution.Width, _display.Resolution.Height, 0u)
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
            OutputTexture.Load();
        }

        protected override void LoadBuffers(GL gl)
        {
            _vertexArray = new VertexArray<Vertex2D>(gl);
            _vertexBuffer = new VertexBuffer<Vertex2D>(gl);

            _vertexBuffer.Load();
            _vertexBuffer.Bind();
            _vertexArray.Load();
            _vertexBuffer.Unbind();

            _vertexBuffer.AddVertices(
                new Vertex2D(new Vector2f(1f, 1f)),
                new Vertex2D(new Vector2f(-1f, 1f)),
                new Vertex2D(new Vector2f(1f, -1f)),
                new Vertex2D(new Vector2f(-1f, -1f)));
        }

        public void Render(GL gl, Texture texture)
        {
            if (texture.Target != TextureTarget.Texture2D) throw new ArgumentException("Cannot handle texture target " + texture.Target, nameof(texture));

            gl.BindFramebuffer(FramebufferTarget.DrawFramebuffer, 0);
            gl.Clear(ClearBufferMask.ColorBufferBit);
            gl.Viewport(0, 0, _display.Resolution.Width, _display.Resolution.Height);

            _program!.Bind();
            _program!.BindTexture(texture, "textureSampler", 0);

            _vertexArray!.Bind();
            _vertexBuffer!.Bind();

            _vertexBuffer!.Buffer();
            _vertexBuffer!.DrawTriangleStrips();

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
