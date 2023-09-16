using System.Collections;

namespace Monarch.Engine.ECS.Components
{
    public struct ComponentSignature
    {
        private readonly BitArray _bits;

        public ComponentSignature(params Type[] componentTypes)
        {
            _bits = new(new[]
                {
                    
                });
        }


    }
}
