using Monarch.Engine.Maths;
using System.Linq;
using System.Transactions;

namespace Monarch.Engine.ECS.Components
{
    public record struct CameraComponent(
        int EntityID,
        Vector3f Translation,
        Vector3f LookAt,
        Vector3f Up
    ) : IComponent;
}
