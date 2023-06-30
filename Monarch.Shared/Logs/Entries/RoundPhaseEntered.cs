using Monarch.Shared.Game.Phases;

namespace Monarch.Shared.Logs.Entries
{
    public class RoundPhaseEntered : IEntry
    {
        public RoundPhaseEntered(RoundPhase phase) => Phase = phase;

        public RoundPhase Phase { get; }
        public string Text => "Entered " + Phase + " phase.";
    }
}
