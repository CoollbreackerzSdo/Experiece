using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class SumOfMultiples
{
    [Benchmark]
    public void E1()
    {
        var a = MySum(new[] { 43, 47, 21, 32, 43, 43, 12, 2, 12, 1, 4, 87, 298, 3, 13, 2, 3543, 12, 54, 454, 1, 2, 4, 12, 2, 12, 5, 6, 56, 13 }, 10000);
    }
    [Benchmark]
    public void E2()
    {
        var a = EiSum(new[] { 43, 47, 21, 32, 43, 43, 12, 2, 12, 1, 4, 87, 298, 3, 13, 2, 3543, 12, 54, 454, 1, 2, 4, 12, 2, 12, 5, 6, 56, 13 }, 10000);
    }

    public int MySum(IEnumerable<int> multiples, int max)
        => JoinMultiples(multiples, max).Distinct().Sum();

    private static IEnumerable<int> JoinMultiples(IEnumerable<int> multiples, int max)
    {
        foreach (var item in multiples)
        {
            for (int i = item; i < max; i += item)
            {
                yield return i;
            }
        }
    }
    public int EiSum(IEnumerable<int> multiples, int max)
    {
        return Enumerable.Range(0, max)
                .Where(item => multiples.Any(item2 => (item2 != 0) && item % item2 == 0))
                .Sum();
    }
}