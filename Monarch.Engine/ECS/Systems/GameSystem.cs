namespace Monarch.Engine.ECS.Systems
{
    public abstract class GameSystem : IGameSystem
    {
        protected ISystemProvider? _systemProvider;

        public void SetSystemProvider(ISystemProvider systemProvider) => _systemProvider = systemProvider;

        public virtual void Load() { }

        public virtual void Start() { }

        public abstract void Update(float deltaTime);
    }
}
