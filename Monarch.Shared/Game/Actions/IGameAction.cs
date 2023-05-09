using Monarch.Shared.Game.Boards;

namespace Monarch.Shared.Game.Actions
{
    public interface IGameAction { }

    public record StartGame : IGameAction;

    public record IncrementRound : IGameAction;

    public record IncrementPhase : IGameAction;

    public record IncrementTurn : IGameAction;

    public record MoveUnit(
        int UnitID,
        Coordinates Coordinates) : IGameAction;
}
