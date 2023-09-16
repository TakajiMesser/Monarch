using Monarch.Engine.Maths;
using System.Linq;
using System.Transactions;

namespace Monarch.Engine.ECS.Components
{
    public record struct RotationComponent(
        Quaternion Rotation
    ) : IComponent;
}
