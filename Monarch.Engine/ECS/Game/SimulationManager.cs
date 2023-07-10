using Silk.NET.Windowing;

namespace Monarch.Engine.ECS.Game
{
    public abstract class SimulationManager : ISimulate
    {
        protected ISystemProvider? _systemProvider;
        protected IView? _view;

        public void SetSystemProvider(ISystemProvider systemProvider) => _systemProvider = systemProvider;

        public virtual void SetView(IView view) => _view = view;

        public abstract void Load();

        public abstract void Start();

        public abstract void Update(double deltaTime);

        public abstract void Close();
    }
}
