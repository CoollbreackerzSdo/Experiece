using System.Text;

public static class RotationalCipher
{                           
    public static string Rotate(string text, int shiftKey)
        => shiftKey == 26 || shiftKey == 0 || string.IsNullOrEmpty(text) ? text : Rotate(text.AsSpan(), shiftKey);

    private static string Rotate(ReadOnlySpan<char> textOnlySpan, int shiftKey)
    {
        //------------------------------------------------------------//
        {
            var result = new StringBuilder();

            foreach (var item in textOnlySpan)
            {
                if (!char.IsLetter(item))               
                {
                    result.Append(item);
                    continue;
                }
                {
                    var positionInitial = (char.IsLower(item) ? 'a' : 'A');
                    result.Append((char)(positionInitial + ((item - positionInitial + shiftKey) % 26)));
                }
            }

            return result.ToString();
        }
    }
}