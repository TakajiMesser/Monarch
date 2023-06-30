namespace Monarch.Engine.ECS.Entities
{
    public interface INamedEntity : IEntity
    {
        string Name { get; }
    }
}
