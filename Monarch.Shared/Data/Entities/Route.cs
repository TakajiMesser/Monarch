using Monarch.Shared.Game.Boards;

namespace Monarch.Shared.Data.Entities
{
    public record struct Route(
        int ID,
        Coordinates Coordinates,
        int EmpireID) : IEntity, ICoordinate;
}
