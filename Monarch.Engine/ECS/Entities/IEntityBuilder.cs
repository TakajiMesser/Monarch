namespace Monarch.Engine.ECS.Entities
{
    public interface IEntityBuilder
    {
        IEntity Build(int id);
    }
}
