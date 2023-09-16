using Monarch.Engine.ECS.Components;
using Monarch.Engine.ECS.Entities;
using Monarch.Engine.ECS.Game;
using Monarch.Engine.Maths;
using System.Collections;
using System.Numerics;

namespace Monarch.Engine.ECS.Systems
{
    public class ECSSystem
    {
        public void RegisterComponentType(Type type)
        {

        }

        public BitArray GetComponentSignature(params Type[] types)
        {
            var bits = new BitArray()



            return bits;
        }

        public IEnumerable<Tuple<IEntity, TComponent>> GetEntities<TComponent>() where TComponent : IComponent
        {

        }

        public void DoShit()
        {
            var positionComponent = new PositionComponent();

            foreach (var result in GetEntities<PositionComponent>())
            {
                result.Item1;
                var position = result.Item2;



                position.Position += Vector3f.One;
            }
        }
    }
}
