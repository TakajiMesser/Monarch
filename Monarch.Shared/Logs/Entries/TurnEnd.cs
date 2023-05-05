namespace Monarch.Shared.Logs.Entries
{
    public class TurnEnd : IEntry
    {
        public TurnEnd(int turn) => Turn = turn;

        public int Turn { get; }
        public string Text => "Player " + Turn + " ended their turn.";
    }
}
