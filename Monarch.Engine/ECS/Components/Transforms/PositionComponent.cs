using Monarch.Engine.Maths;

namespace Monarch.Engine.ECS.Components
{
    public record class PositionComponent(
        Vector3f Position
    ) : IComponent;
}
