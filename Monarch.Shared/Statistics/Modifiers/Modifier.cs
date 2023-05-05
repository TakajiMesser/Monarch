using System;

namespace Monarch.Shared.Statistics.Modifiers
{
    public abstract class Modifier<T> where T : IModifiable
    {
        public int Addend { get; set; } = 0;
        public float Multiplier { get; set; } = 1.0f;

        public void ApplyTo(IModifiable modifiable)
        {
            if (modifiable.GetType() != typeof(T)) throw new ArgumentException("Modifiable type must be " + typeof(T));
            ApplyTo((T)modifiable);
        }

        public void ApplyTo(T target) => ApplyTo(GetStatistic(target));

        protected abstract IStatistic GetStatistic(T target);

        private void ApplyTo(IStatistic statistic)
        {
            statistic.Value += Addend;
            statistic.Value = (int)Math.Round(statistic.Value * Multiplier);
        }
    }
}
