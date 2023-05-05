namespace Monarch.Shared.Logs.Entries
{
    public class RoundStart : IEntry
    {
        public RoundStart(int roundNumber) => RoundNumber = roundNumber;

        public int RoundNumber { get; }
        public string Text => "Round " + RoundNumber + " started.";
    }
}
