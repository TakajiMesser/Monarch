namespace Monarch.Shared.Logs.Entries
{
    public class TurnStart : IEntry
    {
        public TurnStart(int turn) => Turn = turn;

        public int Turn { get; }
        public string Text => "Player " + Turn + " started their turn.";
    }
}
