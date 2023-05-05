using Monarch.Shared.Statistics;
using System;

namespace Monarch.Shared.Populations
{
    public class Population
    {
        public Population(int upperAmount, int middleAmount, int lowerAmount)
        {
            Upper = new WageClass(upperAmount);
            Middle = new WageClass(middleAmount);
            Lower = new WageClass(lowerAmount);

            Upper.Amount.Changed += Amount_Changed;
            Middle.Amount.Changed += Amount_Changed;
            Lower.Amount.Changed += Amount_Changed;

            Amount = new Count(upperAmount + middleAmount + lowerAmount);

            // TODO - Signal when a population reaches zero
            //Count.Depleted += (s, args) => ;
        }

        public WageClass Upper { get; }
        public WageClass Middle { get; }
        public WageClass Lower { get; }

        public Count Amount { get; }

        private void Amount_Changed(object sender, EventArgs e) => Amount.Value = Upper.Amount.Value + Middle.Amount.Value + Lower.Amount.Value;

        // TODO - Determine interactions between different WageClasses
        // How to measure income disparity?
    }
}
