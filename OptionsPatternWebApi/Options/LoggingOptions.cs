namespace OptionsPatternWebApi.Options;

public enum LoggerType
{
    Serilog,
    Nlog
}

public class LoggingOptions
{
    public LoggerType LogType { get; private set; } = LoggerType.Serilog;
    public int ArchiveInDays { get; set; }

    public void EnableSerilog()
    {
        LogType = LoggerType.Serilog;
    }

    public void EnableNlog()
    {
        LogType = LoggerType.Nlog;
    }

}
