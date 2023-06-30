namespace Monarch.Engine.ECS.Components
{
    public class ComponentSet<TComponent> where TComponent : IComponent
    {
        private readonly List<TComponent> _components = new();
        private readonly Dictionary<int, int> _indexByID = new();

        public bool HasComponent(int entityID) => _indexByID.ContainsKey(entityID);

        public TComponent GetComponent(int entityID)
        {
            var index = _indexByID[entityID];
            return _components[index];
        }

        public TComponent? GetComponentOrDefault(int entityID) => HasComponent(entityID)
            ? GetComponent(entityID)
            : default;

        public IEnumerable<TComponent> Components => _components;

        public int Count => _components.Count;

        public void AddComponent(TComponent component)
        {
            _indexByID.Add(component.EntityID, Count);
            _components.Add(component);
        }

        public void ReplaceComponent(TComponent component)
        {
            var index = _indexByID[component.EntityID];
            _components[index] = component;
        }

        public void RemoveComponent(int entityID)
        {
            var index = _indexByID[entityID];

            _components.RemoveAt(index);
            _indexByID.Remove(entityID);
        }

        public void Clear()
        {
            _components.Clear();
            _indexByID.Clear();
        }
    }
}
