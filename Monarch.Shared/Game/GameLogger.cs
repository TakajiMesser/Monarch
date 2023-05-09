using Monarch.Shared.Game.Actions;
using Monarch.Shared.Logs;

namespace Monarch.Shared.Game
{
    public class GameLogger : IGameLogger
    {
        private readonly Log _log = new();
        private readonly GameState _state = new();

        public void LogAction(IGameAction action)
        {
            switch (action)
            {
                case IncrementRound incrementRound:
                    _state.RoundNumber++;
                    break;
            }
        }
    }
}
