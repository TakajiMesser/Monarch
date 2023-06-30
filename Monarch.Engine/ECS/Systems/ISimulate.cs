namespace Monarch.Engine.ECS.Systems
{
    public interface ISimulate
    {
        void Load();
        void Start();
        void Update(float deltaTime);
    }
}
