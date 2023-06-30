using Silk.NET.OpenGL;
using Texture = Monarch.Engine.Rendering.OpenGL.Textures.Texture;

namespace Monarch.Engine.Rendering.OpenGL.Buffers
{
    public class FrameBuffer : OpenGLObject
    {
        private Texture? _depthStencilTexture = null;
        private readonly Dictionary<FramebufferAttachment, Texture> _textures = new();
        private readonly Dictionary<FramebufferAttachment, RenderBuffer> _renderBuffers = new();

        public FrameBuffer(GL gl) : base(gl) { }

        public override void Load()
        {
            base.Load();

            Bind();
            Attach();
            Unbind();
        }

        protected override uint Create() => _gl.GenFramebuffer();
        protected override void Delete() => _gl.DeleteFramebuffer(Handle);

        public override void Bind() => _gl.BindFramebuffer(FramebufferTarget.Framebuffer, Handle);
        public override void Unbind() => _gl.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

        public void BindForDraw() => _gl.BindFramebuffer(FramebufferTarget.DrawFramebuffer, Handle);
        public void UnbindForDraw() => _gl.BindFramebuffer(FramebufferTarget.DrawFramebuffer, 0);

        public void BindForRead() => _gl.BindFramebuffer(FramebufferTarget.ReadFramebuffer, Handle);
        public void UnbindForRead() => _gl.BindFramebuffer(FramebufferTarget.ReadFramebuffer, 0);

        public void AddDepthStencilTexture(Texture texture) => _depthStencilTexture = texture;
        public void Add(FramebufferAttachment attachment, Texture texture) => _textures.Add(attachment, texture);
        public void Add(FramebufferAttachment attachment, RenderBuffer renderBuffer) => _renderBuffers.Add(attachment, renderBuffer);

        public void Clear()
        {
            _depthStencilTexture = null;
            _textures.Clear();
            _renderBuffers.Clear();
        }

        private void Attach()
        {
            if (_depthStencilTexture != null)
            {
                _gl.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthStencilAttachment, _depthStencilTexture.Handle, 0);
            }

            foreach (var texture in _textures)
            {
                _gl.FramebufferTexture(FramebufferTarget.Framebuffer, texture.Key, texture.Value.Handle, 0);
            }

            foreach (var renderBuffer in _renderBuffers)
            {
                _gl.FramebufferRenderbuffer(FramebufferTarget.Framebuffer, renderBuffer.Key, RenderbufferTarget.Renderbuffer, renderBuffer.Value.Handle);
            }

            // Check if the framebuffer is "complete"
            if ((FramebufferStatus)_gl.CheckFramebufferStatus(FramebufferTarget.Framebuffer) != FramebufferStatus.Complete)
            {
                throw new Exception("Error in FrameBuffer: " + _gl.CheckFramebufferStatus(FramebufferTarget.Framebuffer));
            }
        }

        public void BindAndDraw()
        {
            BindForDraw();

            _gl.DrawBuffers((uint)_textures.Count, _textures.Keys
                .Where(k => k != FramebufferAttachment.DepthAttachment)
                .Select(k => (DrawBufferMode)k)
                .ToArray());

            foreach (var attachment in _renderBuffers)
            {
                _gl.DrawBuffer((DrawBufferMode)attachment.Key);
            }
        }

        public void BindAndDraw(params DrawBufferMode[] colorBuffers)
        {
            BindForDraw();
            _gl.DrawBuffers((uint)colorBuffers.Length, colorBuffers);
        }

        public void BindAndRead(ReadBufferMode readBuffer)
        {
            BindForRead();
            _gl.ReadBuffer(readBuffer);
        }
    }
}
