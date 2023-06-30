namespace Monarch.Engine.ECS.Entities
{
    public class NamedEntity : Entity, INamedEntity
    {
        public NamedEntity(int id, string name) : base(id) => Name = name;

        public string Name { get; }
    }
}
