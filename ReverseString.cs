using System.Text;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        var output = new StringBuilder();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            output.Append(input[i]);
        }

        return output.ToString();
    }
}