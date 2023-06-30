using Monarch.Shared.Game.Actions;
using Monarch.Shared.Game.Boards;
using Monarch.Shared.Game.Phases;
using Monarch.Shared.Game.Setup;
using Monarch.Shared.Logs;
using Monarch.Shared.Logs.Entries;
using Monarch.Shared.Models.Empires;
using Monarch.Shared.Models.Players;
using Monarch.Shared.Repositories;

namespace Monarch.Shared.Game
{
    public class GameHandler : IGameManager
    {
        private readonly IGameController _gameController;
        private readonly IGameLogger _gameLogger;
        private readonly IPlayerRepository _playerRepository;
        private readonly IEmpireRepository _empireRepository;

        private readonly Log _log = new();
        private readonly Board _board = new();
        private Random? _gameRandomizer;

        public GamePhase GamePhase { get; private set; }
        public RoundPhase RoundPhase { get; private set; }
        public int RoundNumber { get; private set; }
        public int PlayerTurn { get; private set; }
        public int PlayerCount { get; private set; }
        public ILog Log => _log;
        public IBoard Board => _board;

        public GameHandler(
            IGameController gameController,
            IGameLogger gameLogger,
            IPlayerRepository playerRepository,
            IEmpireRepository empireRepository)
        {
            _gameController = gameController;
            _gameLogger = gameLogger;
            _playerRepository = playerRepository;
            _empireRepository = empireRepository;
        }

        public IPlayer GetPlayer(int id) => _playerRepository.Get(id);

        public void SetUp(IGameConfig config)
        {
            PlayerCount = config.PlayerCount;

            var layoutRandomizer = new Random(config.LayoutSeed);
            _board.SetUp(config.TileRows, config.TileColumns, layoutRandomizer);

            // TODO - Randomly place all factions on the board, with rules
            _gameRandomizer = new Random(config.GameSeed);

            for (var i = 0; i < config.PlayerCount; i++)
            {
                var empire = new Empire(i, "Name");
                var player = new Player(i, i, "Name", i == 0 ? PlayerType.Human : PlayerType.AI, empire);

                _playerRepository.InsertOrUpdate(player);
                _empireRepository.InsertOrUpdate(empire);
            }

            GamePhase = GamePhase.SetUp;
        }

        public void Start()
        {
            if (GamePhase != GamePhase.SetUp) throw new InvalidOperationException("Cannot start while state is " + GamePhase);
            GamePhase = GamePhase.Processing;
            RoundNumber = 1;
            PlayerTurn = 0;
            RoundPhase = RoundPhase.Action;
            _log.AddEntry(new RoundStart(RoundNumber));
            Process();
        }

        public void TakeAction(IPlayerAction action)
        {
            // TODO - Also check current phase?
            if (GamePhase != GamePhase.Waiting) throw new InvalidOperationException("Cannot take action while state is " + GamePhase);
            GamePhase = GamePhase.Processing;
            // TODO - Handle player actions and add to game log
            _log.AddEntry(new ActionTaken(PlayerTurn, action));
            Process();
        }

        public void EndTurn()
        {
            // TODO - Also check current phase?
            if (GamePhase != GamePhase.Waiting) throw new InvalidOperationException("Cannot end turn while state is " + GamePhase);
            GamePhase = GamePhase.Processing;
            IncrementTurn();
            Process();
        }

        private void Process()
        {
            while (GamePhase == GamePhase.Processing)
            {
                if (HandlePhase(RoundPhase))
                {
                    if (RoundPhase.IsLast())
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
                    GamePhase = GamePhase.Waiting;
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
            while (PlayerTurn < PlayerCount)
            {
                // Check if the next player is a human or AI, and handle accordingly
                var player = _playerRepository.Get(PlayerTurn);

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
            foreach (var id in _empireRepository.GetIDs())
            {
                var empire = _empireRepository.GetOrDefault(id);

                if (empire != null)
                {
                    empire.ExtractResources();
                }
            }

            return true;
        }

        private bool HandleStructurePhase()
        {
            foreach (var id in _empireRepository.GetIDs())
            {
                var empire = _empireRepository.GetOrDefault(id);

                if (empire != null)
                {
                    empire.Settlements

                    empire.ExtractResources();
                }
            }

            foreach (var empire in _empires)
            {
                foreach (var settlement in empire.Settlements)
                {
                    settlement.ApplyStructureModifiers();
                }
            }

            return true;
        }

        private bool HandlePopulationPhase()
        {
            foreach (var empire in _empires)
            {
                foreach (var settlement in empire.Settlements)
                {
                    settlement.UpdatePopulation();
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
            PlayerTurn = 0;
            _log.AddEntry(new RoundEnd(RoundNumber));
            RoundNumber++;
            _log.AddEntry(new RoundStart(RoundNumber));
        }

        private void IncrementPhase()
        {
            RoundPhase = RoundPhase.Next();
            _log.AddEntry(new RoundPhaseEntered(RoundPhase));
        }

        private void IncrementTurn()
        {
            _log.AddEntry(new TurnEnd(PlayerTurn));
            PlayerTurn++;
            _log.AddEntry(new TurnStart(PlayerTurn));
        }

        private bool HandlePlayerTurn(IPlayer player) => player.PlayerType switch
        {
            PlayerType.Human => false, // TODO - We need to "wait" for player input
            PlayerType.AI => true, // TODO - We should use AIManager to execute AI player actions
            _ => throw new ArgumentOutOfRangeException("Could not handle player type " + player.PlayerType)
        };
    }
}
