using Monarch.Engine.Maths;

namespace Monarch.Engine.ECS.Components.Cameras
{
    public record class CameraComponent : IComponent
    {
        public required Vector3f Translation { get; set; }
        public required Vector3f LookAt { get; set; }
        public required Vector3f Up { get; set; }
    }
}
