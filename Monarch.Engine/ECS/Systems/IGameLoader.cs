using Monarch.Engine.ECS.Components;
using Monarch.Engine.ECS.Entities;

namespace Monarch.Engine.ECS.Systems
{
    public interface IGameLoader
    {
        void SetEntityLoader(IEntityLoader entityLoader);

        void AddComponentLoader(IComponentLoader componentLoader);

        void Load(IEnumerable<IEntityBuilder> builders);
    }
}
