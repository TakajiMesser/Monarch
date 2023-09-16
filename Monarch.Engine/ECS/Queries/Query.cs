using Monarch.Engine.ECS.Components;

namespace Monarch.Engine.ECS.Queries
{
    public readonly record struct Query(
        Type[] RequiredComponentTypes,
        Type[] OptionalComponentTypes
        );
}
