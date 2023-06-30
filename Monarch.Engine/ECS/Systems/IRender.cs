namespace Monarch.Engine.ECS.Systems
{
    public interface IRender
    {
        void Load();
        void Start();
        void Render(float deltaTime);
    }
}
