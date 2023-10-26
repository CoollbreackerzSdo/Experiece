using System.Text;
public static class RomanNumeralExtension
{
    public static string ToRoman(this int value)
    {
        var result = new StringBuilder();

        var numbersRomans = new Dictionary<int, string>()
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };

        foreach (var item in numbersRomans)
        {
            while (value >= item.Key)
            {
                result.Append(item.Value);
                value -= item.Key;
            }
        }

        return result.ToString();
    }
}