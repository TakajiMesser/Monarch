using Monarch.Shared.Game.Boards;

namespace Monarch.Shared.Data.Entities
{
    public enum SettlementType
    {
        Tribe,
        Village,
        Town,
        City,
        Metropolis
    }

    public record struct Settlement(
        int ID,
        string Name,
        SettlementType SettlementType,
        Coordinates Coordinates,
        int EmpireID) : IEntity, ICoordinate;
}
