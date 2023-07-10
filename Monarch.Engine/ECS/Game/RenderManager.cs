using Silk.NET.Windowing;

namespace Monarch.Engine.ECS.Game
{
    public abstract class RenderManager : IRender
    {
        protected ISystemProvider? _systemProvider;

        public void SetSystemProvider(ISystemProvider systemProvider) => _systemProvider = systemProvider;

        public abstract void SetView(IView view);

        public abstract void Load();

        public abstract void Start();

        public abstract void Render(double deltaTime);

        public abstract void TakeScreenshot();

        public abstract void Close();
    }
}
