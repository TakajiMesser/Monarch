using System;
using System.Collections.Generic;
using System.Text;

namespace Monarch.Shared.Game.Phases
{
    public abstract class Phase : IPhase
    {
        public abstract bool TryProcess();
    }
}
