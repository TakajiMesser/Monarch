using Monarch.Engine.HID;
using Silk.NET.OpenGL;

namespace Monarch.Engine.Rendering.Renderers
{
    public abstract class Renderer : IDisposable
    {
        protected readonly Display _display;

        public Renderer(Display display) => _display = display;

        public void Load(GL gl)
        {
            LoadPrograms(gl);
            LoadTextures(gl);
            LoadBuffers(gl);

            _display.ResolutionChanged += (s, args) => Resize(args.Resolution);
        }

        protected virtual void LoadPrograms(GL gl) { }
        protected virtual void LoadTextures(GL gl) { }
        protected virtual void LoadBuffers(GL gl) { }

        protected virtual void Resize(Resolution resolution) { }

        public abstract void Dispose();
    }
}
