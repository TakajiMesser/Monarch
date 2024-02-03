using Monarch.Engine.ECS.Entities;
using Monarch.Engine.ECS.Systems;

namespace Monarch.Engine.ECS.Components
{
    public abstract class ComponentSystem<TComponent, TBuilder> : GameSystem, IComponentLoader, IComponentProvider<TComponent> where TComponent : IComponent where TBuilder : IComponentBuilder<TComponent>
    {
        private readonly ComponentSet<TComponent> _components = new();

        public bool HasComponent(int entityID) => _components.HasComponent(entityID);

        public TComponent GetComponent(int entityID) => _components.GetComponent(entityID);

        public TComponent? GetComponentOrDefault(int entityID) => _components.GetComponentOrDefault(entityID);

        public void AddComponent(int entityID, TComponent component) => _components.AddComponent(entityID, component);

        public void LoadBuilder(int entityID, IEntityBuilder builder)
        {
            if (builder is TBuilder componentBuilder)
            {
                AddComponent(entityID, componentBuilder.Build(entityID));
            }
        }
    }
}
