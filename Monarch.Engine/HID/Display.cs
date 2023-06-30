namespace Monarch.Engine.HID
{
    public class Display
    {
        private Resolution _resolution;
        private Resolution _window;

        public Display(uint width, uint height, bool isFullScreen)
        {
            _resolution = new(width, height);
            _window = new(width, height);
            IsFullscreen = isFullScreen;
        }

        public Resolution Resolution
        {
            get => _resolution;
            set
            {
                _resolution = value;
                ResolutionChanged?.Invoke(this, new ResolutionEventArgs(value));
            }
        }

        public Resolution Window
        {
            get => _window;
            set
            {
                _window = value;
                WindowChanged?.Invoke(this, new ResolutionEventArgs(value));
            }
        }

        public bool IsFullscreen { get; set; }

        public event EventHandler<ResolutionEventArgs>? ResolutionChanged;
        public event EventHandler<ResolutionEventArgs>? WindowChanged;
    }
}
