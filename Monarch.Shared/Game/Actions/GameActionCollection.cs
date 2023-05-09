using System.Collections.Generic;

namespace Monarch.Shared.Game.Actions
{
    public class GameActionCollection
    {
        private readonly List<IGameAction> _actions = new();

        public int Count => _actions.Count;

        public IGameAction GetAction(int index) => _actions[index];
    }
}
