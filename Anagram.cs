
using BenchmarkDotNet.Attributes;

public class Anagram
{
    public Anagram(string baseWord)
    {
        _BaseWord = baseWord.ToLower();
    }
    public string[] FindAnagrams(string[] potentialMatches)
        => potentialMatches
        .Where(x => x.Length == _BaseWord.Length && x != _BaseWord)
        .Where(x => IsAnagram(x.ToLower()))
        .ToArray();
    private bool IsAnagram(string text)
        => string.Equals(string.Concat(text.OrderBy(x => x)), string.Concat(_BaseWord.OrderBy(x => x)));

    private readonly string _BaseWord;
}
[MemoryDiagnoser]
public class AnagramTests
{
    [Benchmark]
    public void E1Anagram()
    {
        var candidates = new[]
        {
            "cashregister",
            "Carthorse",
            "radishes"
        };
        var sut = new Anagram("orchestra");
        var model = sut.FindAnagrams(candidates);
    }
    [Benchmark]
    public void E2Anagram()
    {
        var candidates = new[]
        {
            "enlists",
            "google",
            "inlets",
            "banana"
        };
        var sut = new Anagram("listen");
        var model = sut.FindAnagrams(candidates);
    }
    [Benchmark]
    public void E3Anagram()
    {
        var candidates = new[]
        {
            "LISTEN",
            "Silent"
        };
        var sut = new Anagram("LISTEN");
        var model = sut.FindAnagrams(candidates);
    }
}