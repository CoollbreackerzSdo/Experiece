using System.Text;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

[MemoryDiagnoser,IterationsColumn]
public class Acronym
{
    [Benchmark]
    public void ATestMin() => new Consumer().Consume(Abbreviate(_text));
    [Benchmark]
    public void ATestNoMin() => new Consumer().Consume(Ab2(_text));

    private readonly string _text = "Something - I made up from thin air";

    public string Abbreviate(ReadOnlySpan<char> value)
    {
        if (value.IsEmpty) throw new NullReferenceException();

        var result = new StringBuilder();

        if (char.IsLetter(value[0])) result.Append(value[0]);
        for (int i = 1; i < value.Length; i++)
        {
            if ((value[i - 1] == ' ' || value[i - 1] == '_' || value[i - 1] == '-') && char.IsLetter(value[i]))
            {
                result.Append(char.ToUpper(value[i]));
            }
        }

        return result.ToString();
    }
    public string Ab2(string phrase)
    {
        string[] sentance = phrase.Split(new char[] { ' ', '_', '-' }, StringSplitOptions.RemoveEmptyEntries);
        string abberviation = "";
        foreach (string word in sentance)
        {
            abberviation += word[0].ToString().ToUpper();
        }
        return abberviation;
    }
}