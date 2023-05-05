using System;

namespace Monarch.Shared.Statistics
{
    public class Count : IStatistic
    {
        private int _value;

        public Count(int value = 0) => Value = value;

        public int Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    Changed?.Invoke(this, EventArgs.Empty);

                    if (_value <= 0)
                    {
                        _value = 0;
                        Depleted?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler? Changed;
        public event EventHandler? Depleted;
    }
}
