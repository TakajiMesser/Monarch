using Monarch.Shared.Models.Empires;

namespace Monarch.Shared.Models.Players
{
    public class Player : IPlayer
    {
        public Player(int id, int slot, string name, PlayerType playerType, IEmpire empire)
        {
            ID = id;
            Slot = slot;
            Name = name;
            PlayerType = playerType;
            Empire = empire;
        }

        public int ID { get; set; }
        public int Slot { get; set; }
        public string Name { get; set; }
        public PlayerType PlayerType { get; set; }
        public IEmpire Empire { get; set; }
    }
}
