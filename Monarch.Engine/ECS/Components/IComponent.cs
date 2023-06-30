using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monarch.Engine.ECS.Components
{
    public interface IComponent
    {
        int EntityID { get; }
    }
}
