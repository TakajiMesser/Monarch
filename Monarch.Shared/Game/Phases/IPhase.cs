using System;
using System.Collections.Generic;
using System.Text;

namespace Monarch.Shared.Game.Phases
{
    public interface IPhase
    {
        bool TryProcess();
    }
}
