using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
        => string.IsNullOrEmpty(identifier) ? identifier : CleanIdentifier(replacement: identifier);

    private static string CleanIdentifier(ReadOnlySpan<char> replacement)
    {
        var textClean = new StringBuilder();

        char buffer = ' ';

        for (int i = 0; i < replacement.Length; i++)
        {
            if (!char.IsLetter(buffer) || char.IsBetween(replacement[i], 'α', 'ω')) continue;
            //Replace ' ' for _
            else if (char.IsWhiteSpace(replacement[i]))
            {
                textClean.Append('_');
                continue;
            }
            //Constrains \0 insert CTRL
            else if (char.IsControl(replacement[i]))
            {
                textClean.Append("CTRL");
                continue;
            }
            //Buffer is - and i value is [character] insert to upper character
            else if (buffer.Equals('-') && !replacement[i].Equals('-'))
            {
                buffer = replacement[i];
                textClean.Append(char.ToUpper(buffer));
                continue;
            }
            else
            {
                buffer = replacement[i];
                if (buffer.Equals('-')) continue;
                textClean.Append(replacement[i]);
            }
        }

        return textClean.ToString();
    }
}