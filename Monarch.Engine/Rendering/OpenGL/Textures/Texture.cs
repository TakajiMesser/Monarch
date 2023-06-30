using Monarch.Engine.Maths;
using Silk.NET.OpenGL;
using PixelFormat = Silk.NET.OpenGL.PixelFormat;

namespace Monarch.Engine.Rendering.OpenGL.Textures
{
    public class Texture : OpenGLObject
    {
        private uint _maxMipMapLevels;
        private float _maxAnisotrophy;

        public Texture(GL gl, uint width, uint height, uint depth) : base(gl)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }

        public uint Width { get; private set; }
        public uint Height { get; private set; }
        public uint Depth { get; private set; }

        public TextureTarget Target { get; set; }
        public InternalFormat InternalFormat { get; set; }
        public PixelFormat PixelFormat { get; set; }
        public PixelType PixelType { get; set; }
        public TextureMinFilter MinFilter { get; set; }
        public TextureMagFilter MagFilter { get; set; }
        public TextureWrapMode WrapMode { get; set; }
        public Color4 BorderColor { get; set; }

        public bool EnableMipMap { get; set; }
        public bool EnableAnisotropy { get; set; }
        //public bool Bindless { get; set; }

        public override void Load()
        {
            base.Load();

            Bind();
            ReserveMemory();
            //Unbind();
        }

        public void Load(IntPtr pixels)
        {
            base.Load();

            Bind();
            Specify(pixels);
            SetTextureParameters();
        }

        public void Load(IntPtr[] pixels)
        {
            base.Load();

            Bind();
            Specify(pixels);
            SetTextureParameters();
        }

        protected override uint Create() => _gl.GenTexture();
        protected override void Delete() => _gl.DeleteTexture(Handle);

        public override void Bind() => _gl.BindTexture(Target, Handle);
        public override void Unbind() => _gl.BindTexture(Target, 0);

        public void BindImageTexture(uint index)
        {
            bool layered = Target == TextureTarget.Texture2DArray
                || Target == TextureTarget.TextureCubeMap
                || Target == TextureTarget.TextureCubeMapArray
                || Target == TextureTarget.Texture3D;

            _gl.BindImageTexture(index, Handle, 0, layered, 0, BufferAccessARB.WriteOnly, InternalFormat);
        }

        public void GenerateMipMap() => _gl.GenerateTextureMipmap(Handle);

        public void Resize(uint width, uint height, uint depth)
        {
            Width = width;
            Height = height;
            Depth = depth;

            Bind();
            ReserveMemory();
        }

        public Color4 ReadPixelColor(int x, int y)
        {
            var bytes = new byte[4];

            unsafe
            {
                fixed (byte* bytesPtr = &bytes[0])
                {
                    _gl.ReadPixels(x, y, 1, 1, PixelFormat, PixelType, bytesPtr);
                    return new Color4((int)bytes[0], (int)bytes[1], (int)bytes[2], (int)bytes[3]);
                }
            }
        }

        public void ReserveMemory()
        {
            Specify(IntPtr.Zero);
            SetTextureParameters();
        }

        public override void Unload()
        {
            for (var i = 0; i < _maxMipMapLevels + 1; i++)
            {
                _gl.ClearTexImage(Handle, i, PixelFormat, PixelType, IntPtr.Zero);
            }

            base.Unload();
        }

        /*public void Specify(byte[] pixels)
        {
            switch (Target)
            {
                case TextureTarget.Texture1d:
                    GL.TexImage1D(Target, 0, InternalFormat, Width, 0, PixelFormat, PixelType, pixels);
                    break;
                case TextureTarget.Texture2D:
                    GL.TexImage2D(Target, 0, InternalFormat, Width, Height, 0, PixelFormat, PixelType, pixels);
                    break;
                case TextureTarget.Texture2dArray:
                    GL.TexImage3D(Target, 0, InternalFormat, Width, Height, Depth, 0, PixelFormat, PixelType, pixels);
                    break;
                case TextureTarget.TextureCubeMap:
                    for (var i = 0; i < Depth; i++)
                    {
                        GL.TexImage2D(TextureTarget.TextureCubeMapPositiveX + i, 0, InternalFormat, Width, Height, 0, PixelFormat, PixelType, pixels);
                    }
                    break;
                case TextureTarget.TextureCubeMapArray:
                    GL.TexStorage3D(Target, _maxMipMapLevels + 1, InternalFormat, Width, Height, Depth * 6);
                    break;
                case TextureTarget.Texture3d:
                    GL.TexImage3D(Target, 0, InternalFormat, Width, Height, Depth, 0, PixelFormat, PixelType, pixels);
                    break;
                default:
                    throw new NotImplementedException("Cannot specify texture target " + Target);
            }
        }*/

        public void Specify(IntPtr pixels)
        {
            switch (Target)
            {
                case TextureTarget.Texture1D:
                    _gl.TexImage1D(Target, 0, InternalFormat, Width, 0, PixelFormat, PixelType, pixels);
                    break;
                case TextureTarget.Texture2D:
                    unsafe
                    {
                        _gl.TexImage2D(Target, 0, InternalFormat, Width, Height, 0, PixelFormat, PixelType, pixels.ToPointer());
                    }
                    break;
                case TextureTarget.Texture2DArray:
                    _gl.TexImage3D(Target, 0, InternalFormat, Width, Height, Depth, 0, PixelFormat, PixelType, pixels);
                    break;
                case TextureTarget.TextureCubeMap:
                    for (var i = 0; i < Depth; i++)
                    {
                        _gl.TexImage2D(TextureTarget.TextureCubeMapPositiveX + i, 0, InternalFormat, Width, Height, 0, PixelFormat, PixelType, pixels);
                    }
                    break;
                case TextureTarget.TextureCubeMapArray:
                    _gl.TexStorage3D(Target, _maxMipMapLevels + 1, (GLEnum)InternalFormat, Width, Height, Depth * 6u);
                    break;
                case TextureTarget.Texture3D:
                    _gl.TexImage3D(Target, 0, InternalFormat, Width, Height, Depth, 0, PixelFormat, PixelType, pixels);
                    break;
                default:
                    throw new NotImplementedException("Cannot specify texture target " + Target);
            }
        }

        public void Specify(IntPtr[] pixels)
        {
            if (pixels.Length != Depth) throw new ArgumentException("Pixel array length (" + pixels.Length + ") must match texture depth (" + Depth + ")");

            switch (Target)
            {
                case TextureTarget.Texture2DArray:
                    _gl.TexImage3D(Target, 0, InternalFormat, Width, Height, Depth, 0, PixelFormat, PixelType, IntPtr.Zero);
                    for (var i = 0; i < Depth; i++)
                    {
                        _gl.TexSubImage3D(Target, 0, 0, 0, i, Width, Height, 1, PixelFormat, PixelType, pixels[i]);
                    }
                    break;
                case TextureTarget.TextureCubeMap:
                    for (var i = 0; i < 6; i++)
                    {
                        _gl.TexImage2D(TextureTarget.TextureCubeMapPositiveX + i, 0, InternalFormat, Width, Height, 0, PixelFormat, PixelType, pixels[i]);
                    }
                    break;
                case TextureTarget.Texture3D:
                    _gl.TexImage3D(Target, 0, InternalFormat, Width, Height, Depth, 0, PixelFormat, PixelType, IntPtr.Zero);
                    for (var i = 0; i < Depth; i++)
                    {
                        _gl.TexSubImage3D(Target, 0, 0, 0, i, Width, Height, 1, PixelFormat, PixelType, pixels[i]);
                    }
                    break;
                default:
                    throw new NotImplementedException("Cannot specify texture target " + Target);
            }
        }

        public void SetTextureParameters()
        {
            if (EnableMipMap)
            {
                _maxMipMapLevels = (uint)(Math.Log(Math.Max(Width, Height), 2.0) - 1.0);
                MinFilter = TextureMinFilter.LinearMipmapLinear;

                _gl.TexParameter(Target, TextureParameterName.TextureBaseLevel, 0);
                _gl.TexParameter(Target, TextureParameterName.TextureMaxLevel, _maxMipMapLevels);

                _gl.GenerateMipmap(Target);

                // This appears to require OpenGL v4.5 :(
                //GL.GenerateTextureMipmap(_handle);
            }

            if (EnableAnisotropy)
            {
                //_maxAnisotrophy = GL.GetFloatv((GetPName)All.MaxTextureMaxAnisotropyExt);
                //GL.TexParameterf(Target, (TextureParameterName)All.TextureMaxAnisotropyExt, _maxAnisotrophy);
            }

            _gl.TexParameter(Target, TextureParameterName.TextureMinFilter, (float)MinFilter);
            _gl.TexParameter(Target, TextureParameterName.TextureMagFilter, (float)MinFilter);
            _gl.TexParameter(Target, TextureParameterName.TextureWrapS, (int)WrapMode);
            _gl.TexParameter(Target, TextureParameterName.TextureWrapT, (int)WrapMode);
            _gl.TexParameter(Target, TextureParameterName.TextureWrapR, (int)WrapMode);

            if (BorderColor != Color4.Zero)
            {
                unsafe
                {
                    var floats = new[] { BorderColor.R, BorderColor.G, BorderColor.B, BorderColor.A };

                    fixed (float* floatsPtr = &floats[0])
                    {
                        _gl.TexParameter(Target, TextureParameterName.TextureBorderColor, floatsPtr);
                    }
                }
            }
        }
    }
}
