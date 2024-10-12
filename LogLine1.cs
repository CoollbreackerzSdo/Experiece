static partial class LogLine
{
    public static LogLevelInfo ParseLogLevel(ReadOnlySpan<char> logLine)
        => logLine[1..4] switch
        {
            "TRC" => LogLevelInfo.Trace,
            "DBG" => LogLevelInfo.Debug,
            "INF" => LogLevelInfo.Info,
            "WRN" => LogLevelInfo.Warning,
            "ERR" => LogLevelInfo.Error,
            "FTL" => LogLevelInfo.Fatal,
            _ => LogLevelInfo.Unknown
        };

    public static string OutputForShortLog(LogLevelInfo logLevel, ReadOnlySpan<char> message)
        => $"{(int)logLevel}:{message}";
}
