using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ParcelCo.InjectionHelper;
using System;
using System.Globalization;
using System.IO;
using System.Threading;

namespace ConsoleParcelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //setup App Configuration
                var configurationBuilder = new ConfigurationBuilder();
                ConfigureApp(configurationBuilder);
                IConfigurationRoot appConfiguration = configurationBuilder.Build();

                //setup  DI
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection, appConfiguration);

                var serviceProvider = serviceCollection.BuildServiceProvider();
                var logger = serviceProvider.GetService<ILoggerFactory>()
                    .CreateLogger<Program>();

                //setup culture
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en");
                Thread.CurrentThread.CurrentCulture = culture;

                try
                {
                    var coreApp = serviceProvider.GetService<IApp>();
                    coreApp.Run( appConfiguration["ResourceSettings:Location"]);
                }
                catch (Exception e)
                {
                    logger.LogCritical(e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }


        }

        private static void ConfigureApp(IConfigurationBuilder AppConfigBuilder)
        {
            var environmentName = Environment.GetEnvironmentVariable("CURRENT_ENVIRONMENT");

            AppConfigBuilder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
        }

        private static void ConfigureServices(IServiceCollection services, IConfigurationRoot appConfig)
        {
            services
            .AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(appConfig.GetSection("Logging"));
                loggingBuilder.AddConsole();
            })
            .AddSingleton<IApp, App>();

            ServiceInjectionHelper.SetServiceCollection(services);
        }
    }
}
