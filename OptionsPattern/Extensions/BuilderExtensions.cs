using Microsoft.Extensions.DependencyInjection;

namespace OptionsPattern.Extensions;

public static class BuilderExtensions
{
    public static void AddLogger(this IServiceCollection services, Action<LoggingOptions> logOptions)
    {
        LoggingOptions logOpts = new();

        logOptions?.Invoke(logOpts);

        if (logOpts.EnableSeriLog)
        {
            services.AddTransient<SeriLog>();
        }
        else
        {
            services.AddTransient<NLog>();
        }

        //services.Configure
    }

}


public class LoggingOptions
{
    public bool EnableNLog { get; private set; } = true;
    public bool EnableSeriLog { get; private set; } = false;
    public int ArchiveAfterDays { get; set; }

    public void UseSerilog() => EnableSeriLog = true;

    public void UseNLog() => EnableSeriLog = false;

}

public class NLog
{

}

public class SeriLog
{

}