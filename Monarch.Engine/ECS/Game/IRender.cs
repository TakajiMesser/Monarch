using Silk.NET.Windowing;

namespace Monarch.Engine.ECS.Game
{
    public interface IRender
    {
        void SetSystemProvider(ISystemProvider systemProvider);
        void SetView(IView view);
        void Load();
        void Start();
        void Render(double deltaTime);
        void TakeScreenshot();
        void Close();
    }
}
