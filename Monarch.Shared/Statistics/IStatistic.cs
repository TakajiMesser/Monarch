using System;

namespace Monarch.Shared.Statistics
{
    public interface IStatistic
    {
        int Value { get; set; }

        event EventHandler? Changed;
        event EventHandler? Depleted;
    }
}
