using Monarch.Shared.Game.Actions;
using Monarch.Shared.Game.Phases;
using Monarch.Shared.Game.Setup;
using Monarch.Shared.Logs;
using Monarch.Shared.Logs.Entries;
using System;

namespace Monarch.Shared.Game
{
    public class GameController : IGameController
    {
        private readonly IGameState _state;
        private readonly ILog _log;

        private Random? _gameRandomizer;

        public GameController(
            IGameState state,
            ILog log)
        {
            _state = state;
            _log = log;
        }

        public RoundPhase RoundPhase => _state.RoundPhase;
        public int RoundNumber => _state.RoundNumber;
        public int PlayerTurn => _state.PlayerTurn;

        public void SetUp(IGameConfig config)
        {
            var layoutRandomizer = new Random(config.LayoutSeed);
            _state.Board.SetUp(config.TileRows, config.TileColumns, layoutRandomizer);

            // TODO - Randomly place all factions on the board, with rules
            _gameRandomizer = new Random(config.GameSeed);

            for (var i = 0; i < config.PlayerCount; i++)
            {
                // TODO - For now, have first player be human and the rest be AI
                /*var player = new Player(i, "Name", i == 0 ? PlayerType.Human : PlayerType.AI);
                var empire = new Empire();

                _players.Add(player);
                _empires.Add(empire);*/
            }
        }

        public void ProcessAction(IGameAction action)
        {
            switch (action)
            {
                case StartGame _:
                    StartGame();
                    break;
                case IncrementRound _:
                    IncrementRound();
                    break;
                case IncrementPhase _:
                    IncrementPhase();
                    break;
                case IncrementTurn _:
                    IncrementTurn();
                    break;
                case MoveUnit moveUnit:
                    break;
            }
        }

        private void StartGame()
        {
            _state.PlayerTurn = 0;
            _state.RoundNumber = 1;
            _state.RoundPhase = RoundPhase.Action;
            _log.AddEntry(new RoundStart(_state.RoundNumber));
        }

        private void IncrementRound()
        {
            IncrementPhase();
            _state.PlayerTurn = 0;
            _log.AddEntry(new RoundEnd(_state.RoundNumber));
            _state.RoundNumber++;
            _log.AddEntry(new RoundStart(_state.RoundNumber));
        }

        private void IncrementPhase()
        {
            _state.RoundPhase = _state.RoundPhase.Next();
            _log.AddEntry(new PhaseEntered(_state.RoundPhase));
        }

        private void IncrementTurn()
        {
            _log.AddEntry(new TurnEnd(_state.PlayerTurn));
            _state.PlayerTurn++;
            _log.AddEntry(new TurnStart(_state.PlayerTurn));
        }
    }
}
