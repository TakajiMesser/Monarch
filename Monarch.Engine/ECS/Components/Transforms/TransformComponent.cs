using Monarch.Engine.Maths;

namespace Monarch.Engine.ECS.Components
{
    public record class TransformComponent : IComponent
    {
        public required Vector3f Position { get; set; }
        public required Quaternion Rotation { get; set; }
        public required Vector3f Scale { get; set; }
    }
}
