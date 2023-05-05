using Monarch.Shared.Game;

namespace Monarch.Shared.Logs.Entries
{
    public class PhaseEntered : IEntry
    {
        public PhaseEntered(RoundPhase phase) => Phase = phase;

        public RoundPhase Phase { get; }
        public string Text => "Entered " + Phase + " phase.";
    }
}
