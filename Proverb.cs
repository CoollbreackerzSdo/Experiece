public static class Proverb
{
    public static string[] Recite(string[] subjects)
        => subjects.Length == 0 ? Array.Empty<string>()
        : subjects.Zip(subjects.Skip(1))
            .Select(compresionPair => $"For want of a {compresionPair.First} the {compresionPair.Second} was lost.")
            .Append($"And all for the want of a {subjects.First()}.").ToArray();
}