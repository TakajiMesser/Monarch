namespace Monarch.Engine.ECS.Game
{
    public abstract class GameManager : SystemManager
    {
        public abstract void Load();

        public abstract void Start();

        protected void Update(double deltaTime) => Simulator?.Update(deltaTime);

        protected void Render(double deltaTime) => Renderer?.Render(deltaTime);

        protected void Close()
        {
            Simulator?.Close();
            Renderer?.Close();
        }
    }
}
