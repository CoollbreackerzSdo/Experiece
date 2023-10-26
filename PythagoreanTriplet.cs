public static class PythagoreanTriplet
{//terminar
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        for (int a = 1; a < sum / 3; a++)
        {
            for (int b = a + 1, c = sum - a - b;b < c;b++, c--)
            {
                if (isTriple(a, b, c))
                    yield return (a, b, c);
            }
        }
    }
    private static bool isTriple(int a,int b,int c) 
        => Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2);
}