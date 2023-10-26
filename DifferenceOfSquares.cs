public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        var result = 0;

        for (int i = 1; i <= max; i++)
        {
            result += i;
        }

        return (int)Math.Pow(result, 2);
    }

    public static int CalculateSumOfSquares(int max)
    {
        var result = 0;

        for (int i = 1; i <= max; i++)
        {
            result += (int)Math.Pow(i, 2);
        }

        return result;
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        var squareOfSum = 0;
        var sumOfSquares = 0;

        for (int i = 1; i <= max; i++)
        {
            squareOfSum += i;
            sumOfSquares += (int)Math.Pow(i, 2);
        }

        squareOfSum = (int)Math.Pow(squareOfSum, 2);
        return squareOfSum - sumOfSquares;
    }
}