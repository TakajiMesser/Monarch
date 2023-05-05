using Monarch.Shared.Statistics;
using Monarch.Shared.Statistics.Modifiers;

namespace Monarch.Shared.Legacy.Religion
{
    public class Church : IModifiable
    {
        public Percentage Approval { get; } = new Percentage();
        public Percentage Influence { get; } = new Percentage();
    }
}
