namespace Monarch.Engine.ECS.Entities
{
    public class EntityManager : IEntityProvider, IEntityLoader
    {
        private readonly EntitySet _entities = new();

        public bool HasEntity(int id) => _entities.HasEntity(id);
        public bool HasEntity(string name) => _entities.HasEntity(name);

        public IEntity GetEntity(int id) => _entities.GetEntity(id);
        public IEntity? GetEntityOrDefault(int id) => _entities.GetEntityOrDefault(id);

        public INamedEntity GetEntity(string name) => _entities.GetEntity(name);
        public INamedEntity? GetEntityOrDefault(string name) => _entities.GetEntityOrDefault(name);

        public int GetNextAvailableID() => _entities.Count;

        public void AddEntity(IEntity entity) => _entities.AddEntity(entity);

        public int LoadBuilder(IEntityBuilder builder)
        {
            var id = _entities.Count;
            var entity = builder.Build(id);

            AddEntity(entity);
            return id;
        }
    }
}
