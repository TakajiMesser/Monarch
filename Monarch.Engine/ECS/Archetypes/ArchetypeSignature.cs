using System.Collections;

namespace Monarch.Engine.ECS.Archetypes
{
    public class ArchetypeSignature
    {
        public ArchetypeSignature(params Type[] componentTypes) => ComponentTypes = componentTypes;

        public Type[] ComponentTypes { get; }

        private readonly BitArray _bits;

        public ComponentSignature(params Type[] componentTypes)
        {
            _bits = new(new[]
                {

                });
        }
    }
}
