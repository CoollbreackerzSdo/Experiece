

public static class ScrabbleScore
{
    public static int Score(string input)
        => Score(input.ToUpper().AsSpan());
    public static int Score(ReadOnlySpan<char> input)
    {
        int result = 0;
        var scope = input.GetEnumerator();
        while (scope.MoveNext())
        {
            switch (scope.Current)
            {
                case 'A':
                case 'E':
                case 'I':
                case 'O':
                case 'U':
                case 'L':
                case 'N':
                case 'R':
                case 'S':
                case 'T':
                    result += 1;
                    continue;
                case 'D':
                case 'G':
                    result += 2;
                    continue;
                case 'B':
                case 'C':
                case 'M':
                case 'P':
                    result += 3;
                    continue;
                case 'F':
                case 'H':
                case 'V':
                case 'W':
                case 'Y':
                    result += 4;
                    continue;
                case 'K':
                    result += 5;
                    continue;
                case 'J':
                case 'X':
                    result += 8;
                    continue;
                case 'Q':
                case 'Z':
                    result += 10;
                    continue;
                default:
                    continue;
            }
        }

        return result;
    }
}
