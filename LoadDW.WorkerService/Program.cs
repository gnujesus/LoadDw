using LoadDW.Data.Context;
using LoadDW.Data.Interfaces;
using LoadDW.Data.Services;
using LoadDW.WorkerService;
using Microsoft.EntityFrameworkCore;

internal class Program {
    private static void Main(string[] args) { 
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) => 
    Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) => 
    {
        services.AddDbContextPool<NorthwindContext>(options => options.UseSqlServer(hostContext.Configuration.GetConnectionString("Northwind")));
        services.AddDbContextPool<DwContext>(options => options.UseSqlServer(hostContext.Configuration.GetConnectionString("DW")));

        services.AddScoped<IDataServiceDw, DataServiceDw>();
        services.AddHostedService<Worker>();
    });
}
