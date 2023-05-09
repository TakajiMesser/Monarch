using Monarch.Shared.Models.Empires;

namespace Monarch.Shared.Models.Players
{
    public interface IPlayer : IModel
    {
        int Slot { get; }
        string Name { get; }
        PlayerType PlayerType { get; }
        IEmpire Empire { get; }
    }
}
