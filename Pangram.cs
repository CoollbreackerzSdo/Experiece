public static class Pangram
{
    public static bool IsPangram(string input)
        => string.IsNullOrEmpty(input) ? false : IsEnglishPangram(input.ToLower());
    private static bool IsEnglishPangram(ReadOnlySpan<char> input)
    {
        var buffer = new HashSet<char>();

        foreach (var item in input)
        {
            if (!char.IsLetter(item)) continue;
            buffer.Add(item);
        }

        return buffer.Count == 26;
    }
}