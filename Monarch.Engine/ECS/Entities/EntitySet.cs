namespace Monarch.Engine.ECS.Entities
{
    public class EntitySet
    {
        private readonly List<IEntity> _entities = new();
        private readonly Dictionary<int, int> _indexByID = new();
        private readonly Dictionary<string, int> _indexByName = new();

        public bool HasEntity(int id) => _indexByID.ContainsKey(id);

        public bool HasEntity(string name) => _indexByName.ContainsKey(name);

        public IEntity GetEntity(int id)
        {
            var index = _indexByID[id];
            return _entities[index];
        }

        public IEntity? GetEntityOrDefault(int id) => HasEntity(id)
            ? GetEntity(id)
            : default;

        public INamedEntity GetEntity(string name)
        {
            var index = _indexByName[name];
            return (INamedEntity)_entities[index];
        }

        public INamedEntity? GetEntityOrDefault(string name) => HasEntity(name)
            ? GetEntity(name)
            : default;

        public IEnumerable<IEntity> Entities => _entities;

        public int Count => _entities.Count;

        public void AddEntity(IEntity entity)
        {
            if (entity is INamedEntity namedEntity)
            {
                _indexByName.Add(namedEntity.Name, Count);
            }

            _indexByID.Add(entity.ID, Count);
            _entities.Add(entity);
        }

        public void Clear()
        {
            _entities.Clear();
            _indexByID.Clear();
            _indexByName.Clear();
        }
    }
}
