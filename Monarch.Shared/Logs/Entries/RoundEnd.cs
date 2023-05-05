namespace Monarch.Shared.Logs.Entries
{
    public class RoundEnd : IEntry
    {
        public RoundEnd(int roundNumber) => RoundNumber = roundNumber;

        public int RoundNumber { get; }
        public string Text => "Round " + RoundNumber + " ended.";
    }
}
