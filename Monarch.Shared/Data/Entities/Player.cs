namespace Monarch.Shared.Data.Entities
{
    public enum PlayerType
    {
        Human,
        AI
    }

    public record struct Player(
        int ID,
        string Name,
        PlayerType PlayerType) : IEntity;
}
