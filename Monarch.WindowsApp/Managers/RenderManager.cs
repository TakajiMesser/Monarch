using Monarch.Engine.HID;
using Monarch.Engine.Maths;
using Monarch.Engine.Rendering.OpenGL.Buffers;
using Monarch.Engine.Rendering.Renderers;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;
using System.Drawing;
using System.Drawing.Imaging;
using Font = Monarch.Engine.UI.Fonts.Font;
using Texture = Monarch.Engine.Rendering.OpenGL.Textures.Texture;

namespace Monarch.WindowsApp.Managers
{
    internal class RenderManager : Monarch.Engine.ECS.Game.RenderManager
    {
        private GL? _gl;
        private Display? _display;

        private GridRenderer? _gridRenderer;
        private ScreenRenderer? _screenRenderer;
        private UIRenderer? _uiRenderer;
        private TextRenderer? _textRenderer;
        private TestRenderer? _testRenderer;

        private Font? _font;
        private Texture? _fontTexture;

        private Texture? _worldTexture;
        private FrameBuffer? _worldFrameBuffer;

        public override void SetView(IView view)
        {
            _gl = view.CreateOpenGL();
            _display = new Display((uint)view!.Size.X, (uint)view!.Size.Y);

            view.Resize += (size) =>
            {
                _display.Window = new Resolution((uint)size.X, (uint)size.Y);
            };
        }

        public override void Load()
        {
            var clearColor = Color4.Purple;
            _gl!.ClearColor(clearColor.R, clearColor.G, clearColor.B, clearColor.A);

            _gridRenderer = new(_display!);
            _gridRenderer.Load(_gl!);

            _screenRenderer = new(_display!);
            _screenRenderer.Load(_gl!);

            _uiRenderer = new(_display!);
            _uiRenderer.Load(_gl!);

            _textRenderer = new(_display!);
            _textRenderer.Load(_gl!);
            LoadFontTexture(_gl!);
            SaveTextureToFile(_gl!, _fontTexture!, "Font-texture.png");

            _testRenderer = new(_display!);
            _testRenderer.Load(_gl!);
            _testRenderer.SetVertex(0.0f, 0.0f, 0.0f);

            _worldTexture = new Texture(_gl!, _display!.Resolution.Width, _display!.Resolution.Height, 0u)
            {
                Target = TextureTarget.Texture2D,
                EnableMipMap = false,
                EnableAnisotropy = false,
                InternalFormat = InternalFormat.Rgba16f,
                PixelFormat = Silk.NET.OpenGL.PixelFormat.Rgba,
                PixelType = Silk.NET.OpenGL.PixelType.Float,
                MinFilter = TextureMinFilter.Linear,
                MagFilter = TextureMagFilter.Linear,
                WrapMode = TextureWrapMode.ClampToBorder
            };
            _worldTexture.Load();
            _display.ResolutionChanged += (s, args) =>
            {
                _worldTexture.Resize(args.Resolution.Width, args.Resolution.Height, 0u);
            };
            _worldFrameBuffer = new(_gl!);
            _worldFrameBuffer.Add(FramebufferAttachment.ColorAttachment0, _worldTexture!);
            _worldFrameBuffer.Load();
        }

        public override void Start()
        {

        }

        /*private const double CLEAR_THRESHOLD = 2.0;
        private Color4[] _clearColors = new[] { Color4.Red, Color4.Green, Color4.Blue };
        private double _clearTime = 0.0;
        private int _clearIndex = 0;*/

        public override void Render(double deltaTime)
        {
            /*_clearTime += deltaTime;
            if (_clearTime >= CLEAR_THRESHOLD)
            {
                _clearTime -= CLEAR_THRESHOLD;
                var color = _clearColors[_clearIndex];
                _gl!.ClearColor(color.R, color.G, color.B, color.A);
                _clearIndex = (_clearIndex + 1) % _clearColors.Length;
            }*/

            // Bind to worldFrameBuffer/worldTexture, and use GridRenderer to render grid
            //_gl!.BindFramebuffer(FramebufferTarget.DrawFramebuffer, 0);
            _worldFrameBuffer!.BindAndDraw(DrawBufferMode.ColorAttachment0);
            _gl!.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            _gl!.Viewport(0, 0, _display!.Resolution.Width, _display!.Resolution.Height);
            _gl!.Enable(EnableCap.DepthTest);
            _gl!.DepthMask(true);
            _gl!.DepthFunc(DepthFunction.Less);
            //_gl!.Enable(EnableCap.CullFace);
            //_gl!.CullFace(GLEnum.Back);
            //_gl!.Disable(EnableCap.DepthTest);
            _gridRenderer!.Render(_gl);

            // Render worldTexture using ScreenRenderer, which should handle binding appropriately
            _screenRenderer!.Render(_gl, _worldTexture!);

            /*_gl!.BindFramebuffer(FramebufferTarget.DrawFramebuffer, 0);
            _gl!.Clear(ClearBufferMask.ColorBufferBit);
            _gl!.Viewport(0, 0, _display.Window.Width, _display.Window.Height);
            _gl!.Disable(EnableCap.DepthTest);
            _gl!.Disable(EnableCap.CullFace);
            _gl!.DepthMask(false);*/

            // Render UI-level contents (ui quads, text, and test points)
            //_uiRenderer!.Render(_gl!);
            //_textRenderer!.RenderText(_gl!, _font!.Value, _fontTexture!, "Test Text", 200, 200);
            //_testRenderer!.SetVertex(0.0f, 0.0f, 0.0f);
            //_testRenderer!.Render(_gl);
        }

        public override void Close()
        {
            _gridRenderer?.Dispose();
            _screenRenderer?.Dispose();
            _uiRenderer?.Dispose();
            _textRenderer?.Dispose();
            _testRenderer?.Dispose();
        }

        /*public record struct Font(
            string FilePath,
            float Size,
            int GlyphsPerLine = 16,
            int GlyphLineCount = 16,
            int GlyphWidth = 24,
            int GlyphHeight = 32,
            int XSpacing = 4,
            int YSpacing = 5);*/
        
        /**
         * TODO - We want to generate a bitmap image of our font grid, which we then save to a PNG file.
         *  The font definition contains some helper parameters.
         *  Glyphs per line, glyph line count, glyph width, and glyph height...
         *  Part of the issue here is that we want to scale these values by the font size, actually.
         *  How do we do this? We actually need to iterate through all possible characters and measure each one
         *  Once we determine the max width and max height, we can begin
         */ 
        private void LoadFontTexture(GL gl)
        {
            _font = new Font("Resources\\Roboto-Regular.ttf");
            var fontDefinition = _font.Value;

            var bitmapWidth = fontDefinition.GlyphsPerLine * fontDefinition.GlyphWidth;
            var bitmapHeight = fontDefinition.GlyphLineCount * fontDefinition.GlyphHeight;
            var maxDimension = Math.Max(bitmapWidth, bitmapHeight);
            using var bitmap = new System.Drawing.Bitmap(maxDimension, maxDimension, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using var fontCollection = new System.Drawing.Text.PrivateFontCollection();
            fontCollection.AddFontFile(fontDefinition.FilePath);

            using var font = new System.Drawing.Font(fontCollection.Families.First(), fontDefinition.Size);
            using (var graphics = System.Drawing.Graphics.FromImage(bitmap))
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                for (var i = fontDefinition.StartCharacter; i <= fontDefinition.EndCharacter; i++)
                {
                    var character = ((char)i).ToString();
                    var index = i - fontDefinition.StartCharacter;

                    var row = index / fontDefinition.GlyphsPerLine;
                    var column = index % fontDefinition.GlyphsPerLine;
                    var x = column * fontDefinition.GlyphWidth;
                    var y = row * fontDefinition.GlyphHeight;

                    // The x and y parameters for DrawString are relative to the upper-left corner
                    graphics.DrawString(character, font, Brushes.White, x, y);
                }
            }

            var data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);

            _fontTexture = new Texture(gl, (uint)bitmap.Width, (uint)bitmap.Height, 0u)
            {
                Target = TextureTarget.Texture2D,
                MinFilter = TextureMinFilter.Linear,
                MagFilter = TextureMagFilter.Linear,
                WrapMode = TextureWrapMode.Repeat,
                EnableMipMap = false,
                EnableAnisotropy = false
            };

            switch (data.PixelFormat)
            {
                case System.Drawing.Imaging.PixelFormat.Format8bppIndexed:
                    _fontTexture.InternalFormat = InternalFormat.Rgb8;
                    //texture.PixelFormat = PixelFormat.ColorIndex;
                    //texture.PixelType = PixelType.Bitmap;
                    break;
                case System.Drawing.Imaging.PixelFormat.Format24bppRgb:
                    _fontTexture.InternalFormat = InternalFormat.Rgb8;
                    _fontTexture.PixelFormat = Silk.NET.OpenGL.PixelFormat.Bgr;
                    _fontTexture.PixelType = Silk.NET.OpenGL.PixelType.UnsignedByte;
                    break;
                case System.Drawing.Imaging.PixelFormat.Format32bppArgb:
                    _fontTexture.InternalFormat = InternalFormat.Rgba;
                    _fontTexture.PixelFormat = Silk.NET.OpenGL.PixelFormat.Bgra;
                    _fontTexture.PixelType = Silk.NET.OpenGL.PixelType.UnsignedByte;
                    break;
            }

            _fontTexture.Load(data.Scan0);

            bitmap.UnlockBits(data);
            bitmap.Dispose();
        }

        public override void TakeScreenshot()
        {
            /*var width = (int)_display!.Resolution.Width;
            var height = (int)_display!.Resolution.Height;
            var bitmap = new Bitmap(width, height);
            var data = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            unsafe
            {
                _gl!.ReadPixels(0, 0, (uint)width, (uint)height, GLEnum.Bgra, GLEnum.UnsignedByte, data.Scan0.ToPointer());
            }
            
            _gl!.Finish();

            bitmap.UnlockBits(data);
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            var fileName = DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00")
                + "_"
                + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00")
                + ".png";

            bitmap.Save(fileName, ImageFormat.Png);
            bitmap.Dispose();*/
            SaveTextureToFile(_gl!, _worldTexture!, "World-texture.png");
        }

        private void SaveTextureToFile(GL gl, Texture texture, string filePath)
        {
            // Create a frame buffer for our texture
            var frameBuffer = new FrameBuffer(gl);
            frameBuffer.Add(FramebufferAttachment.ColorAttachment0, texture);
            frameBuffer.Load();

            // Bind the frame buffer for reading
            frameBuffer.BindAndRead(ReadBufferMode.ColorAttachment0);
            gl.PixelStore(PixelStoreParameter.UnpackAlignment, 1);

            // Create bitmap to transfer texture pixels over to
            var bitmap = new Bitmap((int)texture.Width, (int)texture.Height);
            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, (int)texture.Width, (int)texture.Height), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            unsafe
            {
                gl.ReadPixels(0, 0, texture.Width, texture.Height, Silk.NET.OpenGL.PixelFormat.Bgra, Silk.NET.OpenGL.PixelType.UnsignedByte, data.Scan0.ToPointer());
            }
            
            gl.Finish();

            bitmap.UnlockBits(data);
            //bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            bitmap.Save(filePath, ImageFormat.Png);
            bitmap.Dispose();
        }
    }
}
