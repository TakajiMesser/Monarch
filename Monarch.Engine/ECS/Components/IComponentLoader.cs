using Monarch.Engine.ECS.Entities;

namespace Monarch.Engine.ECS.Components
{
    public interface IComponentLoader
    {
        void LoadBuilder(int entityID, IEntityBuilder builder);
    }
}
