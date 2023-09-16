using Monarch.Engine.Maths;

namespace Monarch.Engine.ECS.Components
{
    public record class PositionComponent : IComponent
    {
        public required Vector3f Position { get; set; }
    }
        Vector3f Position
        ) : IComponent;

    /*public record class PositionComponent(
        Vector3f Position
    ) : IComponent;*/
}
