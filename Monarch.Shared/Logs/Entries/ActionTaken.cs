using Monarch.Shared.Game.Actions;

namespace Monarch.Shared.Logs.Entries
{
    public class ActionTaken : IEntry
    {
        public ActionTaken(int turn, IPlayerAction action)
        {
            Turn = turn;
            Action = action;
        }

        public int Turn { get; }
        public IPlayerAction Action { get; }
        public string Text => "Player " + Turn + " took an action.";
    }
}
