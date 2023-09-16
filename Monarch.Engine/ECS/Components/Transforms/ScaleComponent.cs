using Monarch.Engine.Maths;
using System.Linq;
using System.Transactions;

namespace Monarch.Engine.ECS.Components
{
    public record struct ScaleComponent(
        Vector3f Scale
    ) : IComponent;
}
