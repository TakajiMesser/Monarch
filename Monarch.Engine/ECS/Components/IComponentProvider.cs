namespace Monarch.Engine.ECS.Components
{
    public interface IComponentProvider { }
    public interface IComponentProvider<TComponent> : IComponentProvider where TComponent : IComponent
    {
        bool HasComponent(int entityID);

        TComponent GetComponent(int entityID);
        TComponent? GetComponentOrDefault(int entityID);
    }
}
