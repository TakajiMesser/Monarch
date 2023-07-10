using Monarch.Engine.ECS.Components;
using Monarch.Engine.ECS.Entities;
using Monarch.Engine.ECS.Systems;

namespace Monarch.Engine.ECS.Game
{
    public interface ISystemProvider
    {
        ISimulate? Simulator { get; }
        IRender? Renderer { get; }
        IEntityProvider? EntityProvider { get; }

        bool HasComponentProvider<T>() where T : IComponent;
        bool HasGameSystem<T>() where T : IGameSystem;
        bool HasEntity(int id);
        bool HasComponent<T>(int entityID) where T : IComponent;

        IComponentProvider<T> GetComponentProvider<T>() where T : IComponent;
        IComponentProvider<T>? GetComponentProviderOrDefault<T>() where T : IComponent;

        T GetGameSystem<T>() where T : IGameSystem;
        T? GetGameSystemOrDefault<T>() where T : IGameSystem;

        IEntity GetEntity(int id);
        IEntity? GetEntityOrDefault(int id);

        T GetComponent<T>(int entityID) where T : IComponent;
        T? GetComponentOrDefault<T>(int entityID) where T : IComponent;

        IEnumerable<IGameSystem> GetGameSystems();
    }
}
