using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OptionsPatternWebApi.Options;
using System.Configuration;

namespace OptionsPatternWebApi.Extensions;

public static class BuilderExtensions
{
    public static void AddLogger(this IServiceCollection services, Action<LoggingOptions> logOptions)
    {
        LoggingOptions logOpts = new();

        logOptions?.Invoke(logOpts);

        if (logOpts.LogType == LoggerType.Serilog)
        {
            services.AddTransient<Serilog>();
        }
        else if (logOpts.LogType == LoggerType.Nlog)
        {
            services.AddTransient<Nlog>();
        }

        // Register these seetings with IOptions
        services.Configure(logOptions);

    }
}

public class Serilog
{

}

public class Nlog
{

}
