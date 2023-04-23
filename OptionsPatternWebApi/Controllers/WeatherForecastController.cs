using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionsPatternWebApi.Options;

namespace OptionsPatternWebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,

        IOptions<LoggingOptions> logOptions,
        IOptionsSnapshot<LoggingOptions> logOptionsSnapshot,
        IOptionsMonitor<LoggingOptions> logOptionsMonitor,

         IOptions<ApplicationOptions> applicationOptions,
        IOptionsSnapshot<ApplicationOptions> applicationOptionsSnapshot,
        IOptionsMonitor<ApplicationOptions> applicationOptionsMonitor


        )
    {
        _logger = logger;


        // Custom created these options during service registration
        var logoptionsValue = logOptions.Value.ArchiveInDays; //like a singleton 
        var logOptionsSnapshotValue = logOptionsSnapshot.Value.ArchiveInDays; // like scoped
        var logOptionsMonitorValue = logOptionsMonitor.CurrentValue.ArchiveInDays; //like transient

        // picked setting from appsettings.json and injected in the controller as IOptions
        var applicationoptionsValue = applicationOptions.Value.ExampleValue; //like a singleton 
        var applicationOptionsSnapshotValue = applicationOptionsSnapshot.Value.ExampleValue; // like scoped
        var applicationOptionsMonitorValue = applicationOptionsMonitor.CurrentValue.ExampleValue; //like transient



    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
