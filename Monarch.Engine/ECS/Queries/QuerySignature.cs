using Monarch.Engine.ECS.Components;
using System.Collections;

namespace Monarch.Engine.ECS.Queries
{
    public readonly record struct QuerySignature(
        BitArray RequiredBits,
        BitArray OptionalBits
        );
}
