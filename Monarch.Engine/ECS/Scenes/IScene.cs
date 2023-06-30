using Monarch.Engine.ECS.Entities;

namespace Monarch.Engine.ECS.Scenes
{
    public interface IScene
    {
        int EntityCount { get; }
        IEnumerable<IEntity> Entities { get; }

        void AddEntity(IEntity entity);
        void RemoveEntity(IEntity entity);
    }
}