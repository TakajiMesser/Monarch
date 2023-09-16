namespace Monarch.Engine.ECS.Archetypes
{
    public record struct ArchetypeQuery(
        Type[] ComponentTypes,
        List<Archetype> Matches
        );
}
