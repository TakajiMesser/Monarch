using Monarch.Engine.ECS.Components;
using Monarch.Engine.ECS.Entities;
using Monarch.Engine.ECS.Game;
using Monarch.Engine.Maths;
using System.Numerics;

namespace Monarch.Engine.ECS.Systems
{
    public class ComponentSystem
    {
        //public Dictionary<Type, >

        public IEnumerable<Tuple<IEntity, TComponent>> GetEntities<TComponent>() where TComponent : IComponent
        {
            return Enumerable.Empty<Tuple<IEntity, TComponent>>();
        }

        public void DoShit()
        {
            /*var positionComponent = new PositionComponent();

            foreach (var result in GetEntities<PositionComponent>())
            {
                result.Item1;
                var position = result.Item2;

                position.Position += Vector3f.One;
            }*/
        }
    }
}
