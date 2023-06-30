using Monarch.Shared.Game.Actions;
using Monarch.Shared.Logs;
using Monarch.Shared.Logs.Entries;

namespace Monarch.Shared.Game
{
    public class GameLogger : IGameLogger
    {
        private readonly Log _log = new();

        public void PreLogAction(IGameState state, IGameAction action)
        {
            switch (action)
            {
                case SetUpGame setUpGame:
                    break;
                case StartGame _:
                    break;
                case IncrementRound _:
                    _log.AddEntry(new RoundEnd(state.RoundNumber));
                    break;
                case IncrementPhase _:
                    break;
                case IncrementTurn _:
                    _log.AddEntry(new TurnEnd(state.PlayerTurn));
                    break;
                case MoveUnit moveUnit:
                    break;
            }
        }

        public void PostLogAction(IGameState state, IGameAction action)
        {
            switch (action)
            {
                case SetUpGame setUpGame:
                    break;
                case StartGame _:
                    _log.AddEntry(new RoundStart(state.RoundNumber));
                    break;
                case IncrementRound _:
                    _log.AddEntry(new RoundStart(state.RoundNumber));
                    break;
                case IncrementPhase _:
                    _log.AddEntry(new RoundPhaseEntered(state.RoundPhase));
                    break;
                case IncrementTurn _:
                    _log.AddEntry(new TurnStart(state.PlayerTurn));
                    break;
                case MoveUnit moveUnit:
                    break;
            }
        }
    }
}
