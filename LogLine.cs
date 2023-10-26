using System.Text;

static class LogLine
{
    public static string Message(string logLine)
    {
        //var flag = false;
        //var result = new StringBuilder();
        //for (int i = 0; i < logLine.Length; i++)
        //{
        //    if (logLine[i] is '\n' or '\r') break;
        //    if (flag) result.Append(logLine[i]);
        //    if (logLine[i] is ' ') flag = true;
        //}
        //return result.ToString().TrimEnd();

        if (logLine.StartsWith("[ERROR]"))
            logLine = logLine.Remove(0, "[ERROR]:".Length);
        else if(logLine.StartsWith("[WARNING]"))
            logLine = logLine.Remove(0, "[WARNING]:".Length);
        else if (logLine.StartsWith("[INFO]"))
            logLine = logLine.Remove(0, "[INFO]:".Length);

        logLine = logLine.Trim();

        return logLine;
    }

    public static string LogLevel(string logLine){
      
      var flag = false;

      var result = "";

      foreach (var item in logLine)
      {
        if(item is ']' && flag) break;
        
        else if(flag) result += item;
        
        else if(flag is false && item is '[') flag = !flag;
      }

      return result.ToLower();
    }

    public static string Reformat(string logLine)
        => $"{Message(logLine)} ({LogLevel(logLine)})";
}