namespace Monarch.Engine.HID
{
    public record struct Resolution(
        uint Width,
        uint Height)
    {
        public float AspectRatio => (float)Width / Height;

        public static Resolution Zero => new(0u, 0u);
    }
}
