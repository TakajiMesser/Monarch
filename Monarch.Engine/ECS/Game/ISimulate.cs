using Silk.NET.Windowing;

namespace Monarch.Engine.ECS.Game
{
    public interface ISimulate
    {
        void SetSystemProvider(ISystemProvider systemProvider);
        void SetView(IView view);
        void Load();
        void Start();
        void Update(double deltaTime);
        void Close();
    }
}
