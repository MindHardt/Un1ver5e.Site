using Serilog;

Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        config
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables();
    })
    .UseSerilog((ctx, logger) =>
    {
        logger.ReadFrom.Configuration(ctx.Configuration);
    })
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Un1ver5e.Site.Server.Startup>();
    })
    .Build()
    .Run();