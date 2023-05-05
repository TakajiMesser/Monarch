using System;

namespace Monarch.Shared.Statistics.Modifiers
{
    public interface IModifier
    {
        int Value { get; set; }

        event EventHandler Changed;
        event EventHandler Depleted;

        void ApplyTo(IModifiable modifiable);
    }
}
