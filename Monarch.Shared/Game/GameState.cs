using Monarch.Shared.Game.Boards;
using Monarch.Shared.Game.Phases;
using System;

namespace Monarch.Shared.Game
{
    public class GameState : IGameState
    {
        public RoundPhase RoundPhase { get; set; }
        public int RoundNumber { get; set; }
        public int PlayerTurn { get; set; }
        public Board Board { get; } = new();
        public Random? GameRandomizer { get; set; }
    }
}
