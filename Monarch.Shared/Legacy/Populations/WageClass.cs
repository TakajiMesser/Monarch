using Monarch.Shared.Statistics;
using Monarch.Shared.Statistics.Modifiers;

namespace Monarch.Shared.Populations
{
    public class WageClass : IModifiable
    {
        public WageClass(int amount)
        {
            Amount = new Count(amount);
            // TODO - Signal when a population reaches zero
            //Count.Depleted += (s, args) => ;
        }
        
        public Count Amount { get; }

        public Percentage Happiness { get; } = new Percentage();
        public Percentage Education { get; } = new Percentage();
        public Percentage Religiosity { get; } = new Percentage();

        // TODO - Refine this productivity calculation
        public int Productivity => Amount.Value * Happiness.Value * Education.Value;
    }
}
