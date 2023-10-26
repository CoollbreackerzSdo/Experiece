using System.Text;

public static class LogAnalysis
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string text, string start)
        => text.Split(start)[1];
    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string log, string start, string end)
    {
        var startSkip = log.Split(start);

        var result = new string[startSkip.Length - 1];

        for (int i = 1; i < startSkip.Length; i++)
        {
            var endSkip = startSkip[i].Split(end);

            if (endSkip.Length > 1)
            {
                result[i - 1] = endSkip[0];
                break;
            }

            result[i - 1] = startSkip[i];
        }

        return string.Concat(result);
    }
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string log)
        => log.Split(':')[1].Trim();
    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string logLine)
    {
        var flag = false;

        var result = "";

        foreach (var item in logLine)
        {
            if (item is ']' && flag) break;

            else if (flag) result += item;

            else if (flag is false && item is '[') flag = !flag;
        }

        return result;
    }
}