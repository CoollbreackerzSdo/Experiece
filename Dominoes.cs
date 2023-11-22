public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        if (dominoes.Any())
            return CanChain(dominoes.ToArray().AsSpan());
        else
            return true;

        static bool CanChain(Span<(int DotCount1, int DotCount2)> dominoes)
        {
            var firstDominoFace = dominoes[0];
            if (dominoes.Length == 1)
            {
                return firstDominoFace.DotCount1 == firstDominoFace.DotCount2;
            }
            for (int i = 1; i < dominoes.Length; ++i)
            {
                var currentDominoFace = dominoes[i];
                if (currentDominoFace.DotCount1 == firstDominoFace.DotCount1)
                {
                    dominoes[i].DotCount1 = firstDominoFace.DotCount2;
                    if (CanChain(dominoes.Slice(start: 1))) return true;
                }
                if (currentDominoFace.DotCount1 == firstDominoFace.DotCount2)
                {
                    dominoes[i].DotCount1 = firstDominoFace.DotCount1;
                    if (CanChain(dominoes.Slice(start: 1))) return true;
                }
                dominoes[i].DotCount1 = currentDominoFace.DotCount1;
            }
            return false;
        }
    }
}