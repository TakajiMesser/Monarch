using Monarch.Shared.Game.Actions;
using Monarch.Shared.Game.Phases;
using Monarch.Shared.Game.Setup;

namespace Monarch.Shared.Game
{
    public class GameController : IGameController
    {
        private readonly GameState _state = new();

        public IGameState State => _state;

        public void ProcessAction(IGameAction action)
        {
            switch (action)
            {
                case SetUpGame setUpGame:
                    SetUpGame(setUpGame.Config);
                    break;
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

        private void SetUpGame(IGameConfig config)
        {
            var layoutRandomizer = new Random(config.LayoutSeed);
            _state.Board.SetUp(config.TileRows, config.TileColumns, layoutRandomizer);

            // TODO - Randomly place all factions on the board, with rules
            _state.GameRandomizer = new Random(config.GameSeed);
            _state.PlayerCount = config.PlayerCount;

            for (var i = 0; i < config.PlayerCount; i++)
            {
                // TODO - For now, have first player be human and the rest be AI
                /*var player = new Player(i, "Name", i == 0 ? PlayerType.Human : PlayerType.AI);
                var empire = new Empire();

                _players.Add(player);
                _empires.Add(empire);*/
            }
        }

        private void StartGame()
        {
            _state.PlayerTurn = 0;
            _state.RoundNumber = 1;
            _state.RoundPhase = RoundPhase.Action;
        }

        private void IncrementRound()
        {
            IncrementPhase();
            _state.PlayerTurn = 0;
            _state.RoundNumber++;
        }

        private void IncrementPhase()
        {
            _state.RoundPhase = _state.RoundPhase.Next();
        }

        private void IncrementTurn()
        {
            _state.PlayerTurn++;
        }
    }
}
