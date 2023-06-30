using Monarch.Engine.ECS.Components;
using Monarch.Engine.ECS.Entities;

namespace Monarch.Engine.ECS.Systems
{
    public class SystemManager : ISystemProvider
    {
        private readonly Dictionary<Type, IComponentProvider> _componentProviderByType = new();
        private readonly Dictionary<Type, IGameSystem> _gameSystemByType = new();

        protected List<IGameSystem> _gameSystems = new();

        public IEntityProvider? EntityProvider { get; set; }

        public bool HasComponentProvider<T>() where T : IComponent => _componentProviderByType.ContainsKey(typeof(T));
        public bool HasGameSystem<T>() where T : IGameSystem => _gameSystemByType.ContainsKey(typeof(T));

        public bool HasEntity(int id)
        {
            var provider = EntityProvider;
            return provider != null && provider.HasEntity(id);
        }

        public bool HasComponent<T>(int entityID) where T : IComponent
        {
            var provider = GetComponentProviderOrDefault<T>();
            return provider != null && provider.HasComponent(entityID);
        }

        public IComponentProvider<T> GetComponentProvider<T>() where T : IComponent => (IComponentProvider<T>)_componentProviderByType[typeof(T)];
        public IComponentProvider<T>? GetComponentProviderOrDefault<T>() where T : IComponent => HasComponentProvider<T>() ? GetComponentProvider<T>() : default;

        public T GetGameSystem<T>() where T : IGameSystem => (T)_gameSystemByType[typeof(T)];
        public T? GetGameSystemOrDefault<T>() where T : IGameSystem => HasGameSystem<T>() ? GetGameSystem<T>() : default;

        public IEntity GetEntity(int id) => EntityProvider!.GetEntity(id);
        public IEntity? GetEntityOrDefault(int id)
        {
            var provider = EntityProvider;
            return provider != null
                ? provider.GetEntityOrDefault(id)
                : default;
        }

        public T GetComponent<T>(int entityID) where T : IComponent => GetComponentProvider<T>().GetComponent(entityID);
        public T? GetComponentOrDefault<T>(int entityID) where T : IComponent
        {
            var provider = GetComponentProviderOrDefault<T>();
            return provider != null
                ? provider.GetComponentOrDefault(entityID)
                : default;
        }

        public virtual void AddComponentProvider<T>(IComponentProvider componentProvider) where T : IComponent
        {
            if (componentProvider is not IComponentProvider<T>) throw new ArgumentException("Component Provider must provide type " + typeof(T).Name);
            _componentProviderByType.Add(typeof(T), componentProvider);
        }

        public virtual void AddGameSystem<T>(T gameSystem) where T : IGameSystem
        {
            gameSystem.SetSystemProvider(this);
            _gameSystemByType.Add(typeof(T), gameSystem);
            _gameSystems.Add(gameSystem);
        }

        public IEnumerable<IGameSystem> GetGameSystems() => _gameSystems;
    }
}
