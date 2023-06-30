namespace Monarch.Engine.UI.Fonts
{
    // For now, we are treating all fonts as monospaced
    public record struct Font(
        string FilePath,
        int Size,
        int GlyphsPerLine = 16,
        int GlyphLineCount = 16,
        int GlyphWidth = 24,
        int GlyphHeight = 32,
        int XSpacing = 4,
        int YSpacing = 5);
}
