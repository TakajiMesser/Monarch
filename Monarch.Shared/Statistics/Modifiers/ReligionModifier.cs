using Monarch.Shared.Goods;
using Monarch.Shared.Populations;
using System;

namespace Monarch.Shared.Statistics.Modifiers
{
    public enum ReligionModifierStatistic
    {
        Approval,
        Influence
    }

    public class ReligionModifier : Modifier<Church>
    {
        public ReligionModifierStatistic Statistic { get; set; }

        protected override IStatistic GetStatistic(Church target) => Statistic switch
        {
            ReligionModifierStatistic.Approval => target.Approval,
            ReligionModifierStatistic.Influence => target.Influence,
            _ => throw new ArgumentOutOfRangeException("Could not handle ReligionModifierStatistic " + Statistic)
        };
    }
}
