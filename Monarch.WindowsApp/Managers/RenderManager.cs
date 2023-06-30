using Monarch.Engine.HID;
using Monarch.Engine.Maths;
using Monarch.Engine.Rendering.Renderers;
using Silk.NET.OpenGL;
using System.Drawing.Imaging;
using System.Drawing;
using Font = Monarch.Engine.UI.Fonts.Font;
using Texture = Monarch.Engine.Rendering.OpenGL.Textures.Texture;
using Monarch.Engine.Rendering.OpenGL.Buffers;
using Monarch.Engine.Rendering.Vertices;

namespace Monarch.WindowsApp.Managers
{
    internal class RenderManager
    {
        private GL? _gl;
        private Display? _display;

        //private GridRenderer? _gridRenderer;
        //private ScreenRenderer? _screenRenderer;
        private UIRenderer? _uiRenderer;
        //private TextRenderer? _textRenderer;
        //private TestRenderer? _testRenderer;

        private Font? _font;
        private Texture? _fontTexture;

        public void Load(GL gl, Display display)
        {
            _gl = gl;
            _display = display;

            var clearColor = Color4.Purple;
            _gl.ClearColor(clearColor.R, clearColor.G, clearColor.B, clearColor.A);

            /*_gridRenderer = new(display);
            _gridRenderer.Load(gl);

            _screenRenderer = new(display);
            _screenRenderer.Load(gl);*/

            _uiRenderer = new(display);
            _uiRenderer.Load(gl);
            _uiRenderer!.SetVertices(new[]
            {
                new ViewQuadVertex(
                    position: new Vector3f(200f, 200f, 0f),
                    borderThickness: 10f,
                    size: new Vector2f(0.5f, 100f),
                    cornerRadius: new Vector2f(16f, 16f),
                    color: Color4.Green,
                    borderColor: Color4.Red//,
                    //SelectionID: Color4.Plum
                    )
            });

            //_textRenderer = new(display);
            //_textRenderer.Load(gl);
            LoadFontTexture(gl);
            //SaveTextureToFile(gl, _fontTexture!, "Font-texture.png");

            //_testRenderer = new(display);
            //_testRenderer.Load(gl);
            //_testRenderer.SetVertex(0.0f, 0.0f, 0.0f);
        }

        /*private const double CLEAR_THRESHOLD = 2.0;
        private Color4[] _clearColors = new[] { Color4.Red, Color4.Green, Color4.Blue };
        private double _clearTime = 0.0;
        private int _clearIndex = 0;*/

        public void Render(double deltaTime)
        {
            /*_clearTime += deltaTime;
            if (_clearTime >= CLEAR_THRESHOLD)
            {
                _clearTime -= CLEAR_THRESHOLD;
                var color = _clearColors[_clearIndex];
                _gl!.ClearColor(color.R, color.G, color.B, color.A);
                _clearIndex = (_clearIndex + 1) % _clearColors.Length;
            }*/

            //_gl!.BindFramebuffer(FramebufferTarget.DrawFramebuffer, 0);
            _gl!.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            _gl!.Viewport(0, 0, _display!.Window.Width, _display!.Window.Height);
            _gl!.Disable(EnableCap.DepthTest);

            //_gridRenderer!.Render(_gl, );
            //_screenRenderer!.Render(_gl, _gridRenderer.OutputTexture!);

            _uiRenderer!.Render(_gl);
            //_textRenderer!.RenderText(_gl!, _font!.Value, _fontTexture!, "Test text", 200, 200);
            //_testRenderer!.SetVertex(0.0f, 0.0f, 0.0f);
            //_testRenderer!.Render(_gl);
        }

        public void Close()
        {
            //_gridRenderer?.Dispose();
            //_screenRenderer?.Dispose();
            _uiRenderer?.Dispose();
            //_textRenderer?.Dispose();
            //_testRenderer?.Dispose();
        }

        private void LoadFontTexture(GL gl)
        {
            _font = new Font("Resources\\Roboto-Regular.ttf", 16);
            var fontDefinition = _font.Value;

            var bitmapWidth = fontDefinition.GlyphsPerLine * fontDefinition.GlyphWidth;
            var bitmapHeight = fontDefinition.GlyphLineCount * fontDefinition.GlyphHeight;
            var maxDimension = Math.Max(bitmapWidth, bitmapHeight);

            using (var fontCollection = new System.Drawing.Text.PrivateFontCollection())
            {
                fontCollection.AddFontFile(fontDefinition.FilePath);

                using (var font = new System.Drawing.Font(fontCollection.Families.First(), fontDefinition.Size))
                {
                    using (var bitmap = new System.Drawing.Bitmap(maxDimension, maxDimension, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                    {
                        using (var graphics = System.Drawing.Graphics.FromImage(bitmap))
                        {
                            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                            for (var i = 0; i < fontDefinition.GlyphLineCount; i++)
                            {
                                for (var j = 0; j < fontDefinition.GlyphsPerLine; j++)
                                {
                                    var character = (char)(i * fontDefinition.GlyphsPerLine + j);
                                    graphics.DrawString(character.ToString(), font, Brushes.White, j * fontDefinition.GlyphWidth, i * fontDefinition.GlyphHeight);
                                }
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
                                _fontTexture.PixelType = PixelType.UnsignedByte;
                                break;
                            case System.Drawing.Imaging.PixelFormat.Format32bppArgb:
                                _fontTexture.InternalFormat = InternalFormat.Rgba;
                                _fontTexture.PixelFormat = Silk.NET.OpenGL.PixelFormat.Bgra;
                                _fontTexture.PixelType = PixelType.UnsignedByte;
                                break;
                        }

                        _fontTexture.Load(data.Scan0);

                        bitmap.UnlockBits(data);
                        bitmap.Dispose();
                    }
                }
            }
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
                gl.ReadPixels(0, 0, texture.Width, texture.Height, Silk.NET.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0.ToPointer());
            }
            
            gl.Finish();

            bitmap.UnlockBits(data);
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            bitmap.Save(filePath, ImageFormat.Png);
            bitmap.Dispose();
        }
    }
}
