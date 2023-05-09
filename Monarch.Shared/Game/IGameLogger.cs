using Monarch.Shared.Game.Actions;

namespace Monarch.Shared.Game
{
    /// <summary>
    /// The GameLogger watches all incoming GameActions,
    /// and updates the log to ensure that it is an accurate description of the current GameState.
    /// All received GameActions are assumed to be valid
    /// (i.e. it is the caller's responsibility to confirm validity first).
    /// </summary>
    public interface IGameLogger
    {
        void LogAction(IGameAction action);
    }
}
