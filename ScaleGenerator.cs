public static class ScaleGenerator
{
    public static string[] Chromatic(string tonic)
    {
        var baseScale = !tonic.EndsWith('b') && !tonic.StartsWith('F') ? _SharpNote : _FlatNote;

        int position = Array.IndexOf(baseScale, tonic);

        return baseScale[position..baseScale.Length].Concat(baseScale[0..position]).ToArray();
    }

    public static string[] Interval(string tonic, ReadOnlySpan<char> pattern)
    {
        var baseScale = new string[] { "C", "G", "D", "A", "E", "B", "F#", "a", "e", "b", "f#", "c#", "g#", "d#" }.Contains(tonic) 
            ? _SharpNote : _FlatNote;

        tonic = tonic.Length > 1 ? $"{char.ToUpper(tonic[0])}{tonic[1]}" : tonic.ToUpper(); 

        var index = Array.IndexOf(baseScale,tonic);

        var result = new List<string>() { baseScale[index] };

        foreach (char item in pattern)
        {
            index += char.IsUpper(item) ? item == 'A' ? 3 : 2 : 1;
            index %= baseScale.Length;
            result.Add(baseScale[index]);
        }

        return result.ToArray();
    }

    private readonly static string[] _SharpNote = new[] { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#" };
    private readonly static string[] _FlatNote = new[] { "A", "Bb", "B", "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab" };
}