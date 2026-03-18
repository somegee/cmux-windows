namespace Cmux.Core.Terminal;

/// <summary>
/// Determines the display width of Unicode characters.
/// CJK and fullwidth characters occupy 2 cells in a terminal.
/// </summary>
public static class UnicodeWidth
{
    /// <summary>
    /// Returns the display width of a character: 2 for wide (CJK/fullwidth), 1 for normal.
    /// </summary>
    public static int GetWidth(char c)
    {
        int cp = (int)c;

        // Fast path: ASCII and Latin
        if (cp < 0x1100)
            return 1;

        // Hangul Jamo
        if (cp >= 0x1100 && cp <= 0x115F)
            return 2;

        // CJK Radicals Supplement .. Ideographic Description Characters
        if (cp >= 0x2E80 && cp <= 0x303E)
            return 2;

        // Hiragana, Katakana, Bopomofo, Hangul Compatibility Jamo,
        // Kanbun, Bopomofo Extended, CJK Strokes, Katakana Phonetic Extensions,
        // Enclosed CJK Letters and Months, CJK Compatibility
        if (cp >= 0x3041 && cp <= 0x33BF)
            return 2;

        // CJK Compatibility Forms
        if (cp >= 0x3400 && cp <= 0x4DBF)
            return 2;

        // CJK Unified Ideographs
        if (cp >= 0x4E00 && cp <= 0x9FFF)
            return 2;

        // Hangul Syllables
        if (cp >= 0xAC00 && cp <= 0xD7AF)
            return 2;

        // CJK Compatibility Ideographs
        if (cp >= 0xF900 && cp <= 0xFAFF)
            return 2;

        // Fullwidth Forms (e.g., fullwidth ASCII, fullwidth punctuation)
        if (cp >= 0xFF01 && cp <= 0xFF60)
            return 2;

        // Fullwidth Forms continued
        if (cp >= 0xFFE0 && cp <= 0xFFE6)
            return 2;

        return 1;
    }
}
