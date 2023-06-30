using Monarch.Shared.Game.Actions;

namespace Monarch.Shared.Game
{
    /// <summary>
    /// The GameController maintains the current GameState,
    /// and handles all changes in state as a stream of GameActions.
    /// It is responsible for performing any mutations on the GameState,
    /// and for updating the game log.
    /// All received GameActions are assumed to be valid
    /// (i.e. it is the caller's responsibility to confirm validity first).
    /// </summary>
    public interface IGameController
    {
        IGameState State { get; }

        void ProcessAction(IGameAction action);
    }
}
