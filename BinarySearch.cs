using System.ComponentModel.DataAnnotations;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

[MemoryDiagnoser,InProcess]
public class BinarySearch
{
    [GlobalSetup]
    public void Setup()
    {
        _Context =  Enumerable.Range(0, 32_000_000).ToArray();
    }
    [Range(0,1_000_000)]
    public int _paran;
    private readonly Consumer _consumer = new();
    public int[]? _Context;
    [Benchmark]
    public void Consumer() => _consumer.Consume(Find(_Context, _paran));
    [Benchmark]
    public void Consumer2() => _consumer.Consume(FindAux(_Context, _paran,0,_Context!.Length - 1));
    public static int Find(ReadOnlySpan<int> input,in int value)
    {
        int l = 0;
        int r = input.Length - 1;
        while (l <= r)
        {
            int mid = (l + r) / 2;
            if (input[mid] < value)
            {
                l = mid + 1;
            }
            else if (input[mid] > value)
            {
                r = mid - 1;
            }
            else
                return mid;
        }
        return -1;
    }

    private static int FindAux(ReadOnlySpan<int> input,in int value, int l, int r)
    {
        if (l > r)
        {
            return -1;
        }

        int mid = (l + r) / 2;
        return input[mid] == value ? mid : input[mid] < value ? FindAux(input, value, mid + 1, r) : FindAux(input, value, l, mid - 1);
    }
}