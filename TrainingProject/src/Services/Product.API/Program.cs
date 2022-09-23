using Common.Logging;
using Product.API.Extensions;
using Product.API.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
Log.Information(messageTemplate: "Starting Product API Up");

try
{
    // Add host configurations to the container.
    builder.Host.UseSerilog(Serilogger.Configure);
    builder.Host.AddAppConfigurations();

    // Add services to the container.
    builder.Services.AddInfrastructure(builder.Configuration);

    // Use services.
    var app = builder.Build();
    app.UseInfrastructure();

    //migrate database on buid
    app.MigrateDatabase<ProductContext>((context, _) =>
    {
        ProductContextSeed.SeedProductAsync(context, Log.Logger).Wait();
    });

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down Product API complete");
    Log.CloseAndFlush();
}


