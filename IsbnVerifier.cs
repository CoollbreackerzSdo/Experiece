public static class IsbnVerifier
{
    public static bool IsValid(ReadOnlySpan<char> number)
    {
        if (number.IsEmpty) return false;

        int result = 0;
        int numbers = 0;
        int mod = 10;
        for (var i = 0; i < number.Length; i++)
        {
            if (char.IsNumber(number[i]) || number[i] == 'X')
            {
                if (number[i] == 'X')
                {
                    result += 10 * mod;
                    mod--;
                    continue;
                }
                result += int.Parse(number[i].ToString()) * mod;
                mod--;
                numbers++;
                continue;
            }
            else if (char.IsLetter(number[i])) return false;
        }
        return result % 11 == 0 && result != 0 && numbers !> 9;
    }
}