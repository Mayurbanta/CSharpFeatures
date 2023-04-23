using OptionsPatternWebApi.Extensions;
using OptionsPatternWebApi.Options;

namespace OptionsPatternWebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Register Options
        builder.Services.Configure<ApplicationOptions>(
            builder.Configuration.GetSection(nameof(ApplicationOptions)));

        // Add logging options in AddLogger extension method and then add it to IOptions 
        builder.Services.AddLogger(opts =>
        {
            opts.EnableSerilog();
            opts.ArchiveInDays = 7;
        });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
