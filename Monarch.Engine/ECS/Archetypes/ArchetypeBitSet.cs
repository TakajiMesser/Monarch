namespace Monarch.Engine.ECS.Archetypes
{
    public class ArchetypeBitSet
    {
        public ArchetypeBitSet(params Type[] componentTypes) => ComponentTypes = componentTypes;

        public Type[] ComponentTypes { get; }
    }
}
