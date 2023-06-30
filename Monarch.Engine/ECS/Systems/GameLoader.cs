using Monarch.Engine.ECS.Components;
using Monarch.Engine.ECS.Entities;

namespace Monarch.Engine.ECS.Systems
{
    public class GameLoader : IGameLoader
    {
        private IEntityLoader? _entityLoader;
        private readonly List<IComponentLoader> _componentLoaders = new();

        public void SetEntityLoader(IEntityLoader entityLoader) => _entityLoader = entityLoader;

        public void AddComponentLoader(IComponentLoader componentLoader) => _componentLoaders.Add(componentLoader);
        
        public void Load(IEnumerable<IEntityBuilder> builders)
        {
            var entityLoader = _entityLoader ?? throw new InvalidOperationException("Entity loader must be set before loading.");

            foreach (var builder in builders)
            {
                var entityID = entityLoader.LoadBuilder(builder);

                foreach (var componentLoader in _componentLoaders)
                {
                    componentLoader.LoadBuilder(entityID, builder);
                }
            }
        }
    }
}
