using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PfpToDbService.Services;
using Serilog;

namespace PfpToDbService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            var config = serviceProvider.GetRequiredService<IConfiguration>();

            var connectionString = config.GetConnectionString("DefaultConnection") ?? string.Empty;

            if (string.IsNullOrEmpty(connectionString))
            {
                logger.LogError("Please provide a connection string in appsettings.json file");
                return;
            }

            var parser = new PfpFileParser(serviceProvider.GetRequiredService<ILogger<PfpFileParser>>());
            var dbService = new DatabaseService(connectionString, serviceProvider.GetRequiredService<ILogger<DatabaseService>>());
            var fileMonitorService = new FileMonitorService(config, parser, dbService, serviceProvider.GetRequiredService<ILogger<FileMonitorService>>());

            logger.LogInformation("PFP to Database Service is starting...");

            fileMonitorService.StartMonitoring();

            logger.LogInformation("Monitoring folders for .pfp files. Press ENTER to stop.");
            Console.ReadLine();

            fileMonitorService.StopMonitoring();
            logger.LogInformation("PFP to Database Service stopped.");
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(configure => configure.AddSerilog())
                    .AddTransient<Program>();

            services.AddSingleton(configuration);
        }
    }
}
