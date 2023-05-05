namespace Monarch.Shared.Game.Players
{
    public interface IPlayer
    {
        int Slot { get; }
        string Name { get; }
        PlayerType PlayerType { get; }
    }
}
