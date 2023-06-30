namespace Monarch.Engine.ECS.Systems
{
    public interface IGameSystem
    {
        void SetSystemProvider(ISystemProvider systemProvider);
        void Load();
        void Start();
        void Update(float deltaTime);
    }
}
