public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int N1, int N2)> dominoes)
    {
        dominoes = dominoes.OrderBy(x => x.N1 + x.N2);

        List<(int, int)> chain = new()
        {
            dominoes.First()
        };

        foreach (var domino in dominoes)
        {
            if (domino.Item1 == chain[chain.Count - 1].Item2)
            {
                chain.Add(domino);
            }
        }

        return chain.Count == dominoes.Count();
    }
}