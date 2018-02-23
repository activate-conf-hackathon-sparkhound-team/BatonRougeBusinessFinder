using BRBF.Core;
using BRBF.Core.Business.Import;
using BRBF.DataAccess;
using BRBF.DataAccess.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace BRBF.Importer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(args, serviceCollection);

            var configuration = new JobHostConfiguration();
            configuration.Queues.MaxPollingInterval = TimeSpan.FromSeconds(10);
            configuration.Queues.BatchSize = 1;
            configuration.JobActivator = new JobActivator(serviceCollection.BuildServiceProvider());
            configuration.UseTimers();

            var host = new JobHost(configuration);
            host.RunAndBlock();
        }

        private static void ConfigureServices(string[] args, IServiceCollection serviceCollection)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Setup your configuration:
            var configuration = new ConfigurationBuilder()
                //.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            // Azure connection strings
            Environment.SetEnvironmentVariable("AzureWebJobsDashboard", configuration.GetConnectionString("WebJobsDashboard"));
            Environment.SetEnvironmentVariable("AzureWebJobsStorage", configuration.GetConnectionString("WebJobsStorage"));

            // Setup container
            serviceCollection.Configure<AppSettings>(configuration);
            serviceCollection.AddScoped<WebJobsMethods, WebJobsMethods>();
            serviceCollection.AddScoped<IImportDataService, ImportDataService>();

            serviceCollection
                .AddDbContext<BatonRougeBusinessFinderDbContext>(options => 
                    options.UseSqlServer(configuration.GetConnectionString("DbContext")));
        }
    }
}
