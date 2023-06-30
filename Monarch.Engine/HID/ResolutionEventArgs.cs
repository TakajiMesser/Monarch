namespace Monarch.Engine.HID
{
    public class ResolutionEventArgs : EventArgs
    {
        public ResolutionEventArgs(Resolution resolution) => Resolution = resolution;

        public Resolution Resolution { get; }
    }
}
