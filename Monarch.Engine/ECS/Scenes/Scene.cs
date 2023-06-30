using Monarch.Engine.ECS.Entities;

namespace Monarch.Engine.ECS.Scenes
{
    public class Scene : IScene
    {
        private readonly List<IEntity> _entities = new();

        public int EntityCount => _entities.Count;
        public IEnumerable<IEntity> Entities => _entities;

        public void AddEntity(IEntity entity)
        {
            _entities.Add(entity);
        }

        public void RemoveEntity(IEntity entity)
        {
            _entities.Remove(entity);
        }
    }
}