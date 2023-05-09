using Monarch.Shared.Game.Boards;

namespace Monarch.Shared.Data.Entities
{
    public enum UnitType
    {
        Settler,
        Diplomat,
        Trader,
        Warrior,
        Soldier
    }

    public record struct Unit(
        int ID,
        Coordinates Coordinates,
        UnitType UnitType,
        float Speed,
        int EmpireID) : IEntity, ICoordinate;
}
