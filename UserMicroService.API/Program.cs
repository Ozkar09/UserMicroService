using System;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using UserMicroService.Configuration;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace UserMicroService.API
{
    class Program
    {
        
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        static void Main(string[] args)
        {
            Logger.Info("Inicio de ejecución del aplicativo");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var pathToContentRoot = AppDomain.CurrentDomain.BaseDirectory;

            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configurationRoot =
                new ConfigurationBuilder().SetBasePath(pathToContentRoot)
                    .AddUserMicroserviceConfiguration()
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{environmentName}.json", false, reloadOnChange: true).Build();
            
            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Information);
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        }
    }
}