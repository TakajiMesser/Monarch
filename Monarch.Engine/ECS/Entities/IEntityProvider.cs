namespace Monarch.Engine.ECS.Entities
{
    public interface IEntityProvider
    {
        bool HasEntity(int id);
        bool HasEntity(string name);

        IEntity GetEntity(int id);
        IEntity? GetEntityOrDefault(int id);

        INamedEntity GetEntity(string name);
        INamedEntity? GetEntityOrDefault(string name);
    }
}
