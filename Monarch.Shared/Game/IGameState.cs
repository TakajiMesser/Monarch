using Monarch.Shared.Game.Boards;
using Monarch.Shared.Game.Phases;
using System;

namespace Monarch.Shared.Game
{
    public interface IGameState
    {
        RoundPhase RoundPhase { get; set; }
        int RoundNumber { get; set; }
        int PlayerTurn { get; set; }
        Board Board { get; }
        Random? GameRandomizer { get; set; }
    }
}
