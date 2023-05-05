namespace Monarch.Shared.Game.Players
{
    public class Player : IPlayer
    {
        public Player(int slot, string name, PlayerType playerType)
        {
            Slot = slot;
            Name = name;
            PlayerType = playerType;
        }

        public int Slot { get; set; }
        public string Name { get; set; }
        public PlayerType PlayerType { get; set; }
    }
}
