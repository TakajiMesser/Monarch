namespace Monarch.Shared.Data.Entities
{
    public record struct Empire(
        int ID,
        string Name,
        int PlayerID) : IEntity;
}
