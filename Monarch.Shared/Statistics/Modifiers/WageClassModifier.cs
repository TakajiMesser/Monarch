using System;
using Monarch.Shared.Populations;

namespace Monarch.Shared.Statistics.Modifiers
{
    public enum WageClassStatistic
    {
        Happiness,
        Education,
        Religiosity,
        //Security,
        //Productivity
    }

    public class WageClassModifier : Modifier<WageClass>
    {
        public WageClassStatistic Statistic { get; set; }

        protected override IStatistic GetStatistic(WageClass target) => Statistic switch
        {
            WageClassStatistic.Happiness => target.Happiness,
            WageClassStatistic.Education => target.Education,
            WageClassStatistic.Religiosity => target.Religiosity,
            //WageClassStatistic.Security => target.Security,
            //WageClassStatistic.Productivity => target.Productivity,
            _ => throw new ArgumentOutOfRangeException("Could not handle WageClassStatistic " + Statistic)
        };
    }
}
