using Monarch.Shared.Game.Boards;
using Monarch.Shared.Game.Phases;

namespace Monarch.Shared.Game
{
    public interface IGameState
    {
        RoundPhase RoundPhase { get; }
        int RoundNumber { get; }
        int PlayerCount { get; }
        int PlayerTurn { get; }
        Board Board { get; }
        Random? GameRandomizer { get; }
    }
}
