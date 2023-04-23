using Microsoft.Extensions.DependencyInjection;
using OptionsPattern.Extensions;
using System.Configuration;
using System.Data;

namespace OptionsPattern;

internal class Program
{
    static void Main(string[] args)
    {

        NullCheckClass nullCheckClass = new NullCheckClass();
        var ppl = nullCheckClass.GetPeople();

    

        if (ppl != null)
        {
            var count = ppl.Count;
            foreach (var person in ppl)
            {
                Console.WriteLine(person.Address?.AddressLine1 ?? "No Address");
            }
        }



        Console.WriteLine("Hello, World!");

        IServiceProvider provider = ConfigureServices();
    }

    public static IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddLogger(opts =>
        {
            opts.UseSerilog();
            opts.ArchiveAfterDays = 7;
        });
        return services.BuildServiceProvider();
    }
}
