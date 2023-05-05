using System;

namespace Monarch.Shared.Game
{
    public enum RoundPhase
    {
        Action,
        Resource,
        Structure,
        Population,
        Religion
    }

    public static class RoundPhaseUtilities
    {
        public static RoundPhase Next(this RoundPhase phase)
        {
            var values = Enum.GetValues<RoundPhase>();
            var phaseIndex = (int)phase;
            var nextIndex = phaseIndex + 1;
            return values[nextIndex % values.Length];
        }

        public static bool IsLast(this RoundPhase phase)
        {
            var values = Enum.GetValues<RoundPhase>();
            var phaseIndex = (int)phase;
            return phaseIndex == values.Length - 1;
        }
    }
    

    // Every round should have different "phases"
    //  - Resource production phase (uses population/province productivity and structure modifiers to calculate)
    //      - Produce raw resources
    //      - Produce structure resources
    //  - Population phase (uses happiness, education, and province security to calculate)
    //      - Check for riot/rebellion
    //      - 
    //  - Religion phase ()
    //      - 
    //  - Neighbor phase
    //      - 
}
