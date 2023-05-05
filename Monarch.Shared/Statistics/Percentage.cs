using System;

namespace Monarch.Shared.Statistics
{
    public class Percentage : IStatistic
    {
        private int _value;

        public Percentage(int value = 100) => Value = value;

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

                    if (_value >= 100)
                    {
                        _value = 100;
                        Maxed?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler Changed;
        public event EventHandler Depleted;
        public event EventHandler Maxed;
    }
}
