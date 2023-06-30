using Monarch.Shared.Game.Boards;
using Monarch.Shared.Game.Setup;

namespace Monarch.Shared.Game.Actions
{
    public interface IGameAction { }

    public record struct SetUpGame(IGameConfig Config) : IGameAction;

    public record struct StartGame : IGameAction;

    public record struct IncrementRound : IGameAction;

    public record struct IncrementPhase : IGameAction;

    public record struct IncrementTurn : IGameAction;

    public record struct MoveUnit(
        int UnitID,
        Coordinates Coordinates) : IGameAction;
}
