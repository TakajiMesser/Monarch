namespace Monarch.Engine.UI.Fonts
{
    // For now, we are treating all fonts as monospaced
    public record struct Font(
        string FilePath,
        float Size = 16f,
        int StartCharacter = 32,
        int EndCharacter = 126,
        int GlyphsPerLine = 12,
        int GlyphLineCount = 12,
        int GlyphWidth = 32,
        int GlyphHeight = 32
        );
}
