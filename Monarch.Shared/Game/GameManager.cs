using Monarch.Shared.Game.Boards;
using Monarch.Shared.Game.Empires;
using Monarch.Shared.Game.Players;
using Monarch.Shared.Game.Players.Actions;
using Monarch.Shared.Game.Setup;
using Monarch.Shared.Logs;
using Monarch.Shared.Logs.Entries;
using System;
using System.Collections.Generic;

namespace Monarch.Shared.Game
{
    public class GameManager : IGameManager
    {
        private readonly Log _log = new();
        private readonly Board _board = new();
        private readonly List<Empire> _empires = new();
        private readonly List<Player> _players = new();
        private Random? _gameRandomizer;

        public int TurnIndex { get; private set; }
        public int RoundNumber { get; private set; }
        public int PlayerCount { get; private set; }

        public GameState State { get; private set; }
        public RoundPhase Phase { get; private set; }
        public ILog Log => _log;
        public IBoard Board => _board;

        public IPlayer GetPlayer(int index) => _players[index];

        public void SetUp(IGameConfig config)
        {
            var layoutRandomizer = new Random(config.LayoutSeed);
            _board.SetUp(config.TileRows, config.TileColumns, layoutRandomizer);

            // TODO - Randomly place all factions on the board, with rules
            _gameRandomizer = new Random(config.GameSeed);

            for (var i = 0; i < config.PlayerCount; i++)
            {
                var player = new Player(i, "Name", i == 0 ? PlayerType.Human : PlayerType.AI);
                var empire = new Empire();

                _players.Add(player);
                _empires.Add(empire);
            }

            State = GameState.SetUp;
        }

        public void Start()
        {
            if (State != GameState.SetUp) throw new InvalidOperationException("Cannot start while state is " + State);
            State = GameState.Processing;
            TurnIndex = 0;
            RoundNumber = 1;
            Phase = RoundPhase.Action;
            _log.AddEntry(new RoundStart(RoundNumber));
            Process();
        }

        public void TakeAction(IPlayerAction action)
        {
            // TODO - Also check current phase?
            if (State != GameState.Waiting) throw new InvalidOperationException("Cannot take action while state is " + State);
            State = GameState.Processing;
            // TODO - Handle player actions and add to game log
            _log.AddEntry(new ActionTaken(TurnIndex, action));
            Process();
        }

        public void EndTurn()
        {
            // TODO - Also check current phase?
            if (State != GameState.Waiting) throw new InvalidOperationException("Cannot end turn while state is " + State);
            State = GameState.Processing;
            IncrementTurn();
            Process();
        }

        private void Process()
        {
            while (State == GameState.Processing)
            {
                if (HandlePhase(Phase))
                {
                    if (Phase.IsLast())
                    {
                        IncrementRound();
                    }
                    else
                    {
                        IncrementPhase();
                    }
                }
                else
                {
                    State = GameState.Waiting;
                    return;
                }
            }
        }

        private bool HandlePhase(RoundPhase phase) => phase switch
        {
            RoundPhase.Action => HandleActionPhase(),
            RoundPhase.Resource => HandleResourcePhase(),
            RoundPhase.Structure => HandleStructurePhase(),
            RoundPhase.Population => HandlePopulationPhase(),
            RoundPhase.Religion => HandleReligionPhase(),
            _ => throw new ArgumentOutOfRangeException("Could not handle phase " + phase)
        };

        private bool HandleActionPhase()
        {
            while (TurnIndex < _players.Count)
            {
                // Check if the next player is a human or AI, and handle accordingly
                var player = _players[TurnIndex];

                if (HandlePlayerTurn(player))
                {
                    // Since the player was an AI and we handled their turn, we can proceed
                    IncrementTurn();
                }
                else
                {
                    // Since the player was a human, we should wait for input
                    return false;
                }
            }

            // We have completed all player turns, so we should proceed to the next phase
            return true;
        }

        private bool HandleResourcePhase()
        {
            foreach (var empire in _empires)
            {
                empire.ExtractResources();
            }

            return true;
        }

        private bool HandleStructurePhase()
        {
            foreach (var empire in _empires)
            {
                foreach (var province in empire.Provinces)
                {
                    province.ApplyStructureModifiers();
                }
            }

            return true;
        }

        private bool HandlePopulationPhase()
        {
            foreach (var empire in _empires)
            {
                foreach (var province in empire.Provinces)
                {
                    province.UpdatePopulation();
                }
            }

            return true;
        }

        private bool HandleReligionPhase()
        {
            return true;
        }

        private void IncrementRound()
        {
            IncrementPhase();
            TurnIndex = 0;
            _log.AddEntry(new RoundEnd(RoundNumber));
            RoundNumber++;
            _log.AddEntry(new RoundStart(RoundNumber));
        }

        private void IncrementPhase()
        {
            Phase = Phase.Next();
            _log.AddEntry(new PhaseEntered(Phase));
        }

        private void IncrementTurn()
        {
            _log.AddEntry(new TurnEnd(TurnIndex));
            TurnIndex++;
            _log.AddEntry(new TurnStart(TurnIndex));
        }

        private bool HandlePlayerTurn(Player player) => player.PlayerType switch
        {
            PlayerType.Human => false, // TODO - We need to "wait" for player input
            PlayerType.AI => true, // TODO - We should use AIManager to execute AI player actions
            _ => throw new ArgumentOutOfRangeException("Could not handle player type " + player.PlayerType)
        };
    }
}
