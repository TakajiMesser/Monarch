using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monarch.Engine.ECS.Components
{
    public interface IComponentBuilder { }
    public interface IComponentBuilder<TComponent> : IComponentBuilder where TComponent : IComponent
    {
        TComponent Build(int entityID);
    }
}
