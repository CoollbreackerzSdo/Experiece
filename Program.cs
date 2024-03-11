using System.Diagnostics;
Console.WriteLine();

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
        => old.SelectMany(x => x.Value.Select(v => KeyValuePair.Create(v.ToLowerInvariant(),x.Key))).OrderBy(old => old.Key).ToDictionary();

    private static IEnumerable<KeyValuePair<string,int>> MapOldDigital(Dictionary<int, string[]> old)
    {
        foreach (var itemMolder in old)
        {
            foreach (var maps in itemMolder.Value)
            {
                yield return new(maps.ToLower(),itemMolder.Key);
            }
        }
    }
}