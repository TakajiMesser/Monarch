using Monarch.Engine.HID;
using Monarch.Engine.Maths;
using Monarch.Engine.Properties;
using Monarch.Engine.Rendering.OpenGL.Buffers;
using Monarch.Engine.Rendering.OpenGL.Shaders;
using Monarch.Engine.Rendering.OpenGL.Vertices;
using Monarch.Engine.Rendering.Vertices;
using Monarch.Engine.UI.Fonts;
using Silk.NET.OpenGL;
using Texture = Monarch.Engine.Rendering.OpenGL.Textures.Texture;

namespace Monarch.Engine.Rendering.Renderers
{
    public class TextRenderer : Renderer
    {
        private ShaderProgram? _program;
        private VertexArray<TextVertex>? _vertexArray;
        private VertexBuffer<TextVertex>? _vertexBuffer;
        //private FrameBuffer? _frameBuffer;

        public TextRenderer(Display display) : base(display) { }

        //public Texture? OutputTexture { get; private set; }

        protected override void LoadPrograms(GL gl)
        {
            _program = new(gl, new[]
            {
                new ShaderDefinition(ShaderType.VertexShader, Resources.text_vert),
                new ShaderDefinition(ShaderType.FragmentShader, Resources.text_frag)
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
            _vertexArray = new VertexArray<TextVertex>(gl);
            _vertexBuffer = new VertexBuffer<TextVertex>(gl);
            /*_frameBuffer = new(gl);

            _frameBuffer.Add(FramebufferAttachment.ColorAttachment0, OutputTexture);
            _frameBuffer.Load();*/

            _vertexBuffer.Load();
            _vertexBuffer.Bind();
            _vertexArray.Load();
            _vertexBuffer.Unbind();
        }

        protected override void Resize(Resolution resolution)
        {
            //OutputTexture.Resize(resolution.Width, resolution.Height, 0u);
        }

        public void RenderText(
            GL gl,
            Font font,
            Texture texture,
            string text,
            int x,
            int y,
            float fontScale = 1.0f,
            bool wordWrap = false)
        {
            gl.Enable(EnableCap.Blend);
            gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            gl.Disable(EnableCap.DepthTest);
            gl.BindFramebuffer(FramebufferTarget.DrawFramebuffer, 0);

            var uStep = (float)font.GlyphWidth / texture.Width;
            var vStep = (float)font.GlyphHeight / texture.Height;

            var width = (int)(font.GlyphWidth * fontScale);
            var height = (int)(font.GlyphHeight * fontScale);

            var initialX = x;
            _vertexBuffer!.Clear();

            for (var i = 0; i < text.Length; i++)
            {
                char character = text[i];
                var index = character - font.StartCharacter;

                var u = index % font.GlyphsPerLine * uStep;
                var v = index / font.GlyphsPerLine * vStep;

                if (wordWrap && x + width > _display!.Window.Width)
                {
                    x = initialX;
                    y += height;
                }

                var ptr = new Vector2f(x + width, y + height);
                var ptl = new Vector2f(x, y + height);
                var pbl = new Vector2f(x, y);
                var pbr = new Vector2f(x + width, y);

                var tbr = new Vector2f(u + uStep, v);
                var tbl = new Vector2f(u, v);
                var ttl = new Vector2f(u, v + vStep);
                var ttr = new Vector2f(u + uStep, v + vStep);

                var textColor = Color4.White;
                _vertexBuffer!.AddVertices(new[]
                {
                    new TextVertex(ptl, ttl, textColor),
                    new TextVertex(pbl, tbl, textColor),
                    new TextVertex(ptr, ttr, textColor),
                    new TextVertex(pbr, tbr, textColor),
                });

                x += width;
            }
            
            _program!.Bind();
            _program!.BindTexture(texture, "textureSampler", 0);
            _program!.SetUniform("halfResolution", new Vector2f(_display!.Resolution.Width / 2f, _display!.Resolution.Height / 2f));

            _vertexArray!.Bind();
            _vertexBuffer!.Bind();
            _vertexBuffer!.Buffer();

            _vertexBuffer!.DrawTriangleStrips();

            _vertexArray!.Unbind();
            _vertexBuffer!.Unbind();

            gl.Disable(EnableCap.Blend);
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
