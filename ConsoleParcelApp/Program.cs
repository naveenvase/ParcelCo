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
    /// <summary>
    /// The <c>program</c> class readies the 
    /// envionrment like load app.config, set up logging, set up current culture, set up dependency injection e.t.c
    /// </summary>
    /// <remarks>After the enviornment is set up loads the <see cref="App"> class
    /// via dependency injection and runs it.</see>/></remarks>
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
                    coreApp.Run();
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

        /// <summary>Configures the application config settings</summary>
        /// <param name="AppConfigBuilder">The application configuration builder.</param>
        private static void ConfigureApp(IConfigurationBuilder AppConfigBuilder)
        {
            var environmentName = Environment.GetEnvironmentVariable("CURRENT_ENVIRONMENT",EnvironmentVariableTarget.Machine);

            AppConfigBuilder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
        }

        /// <summary>Configures the application services like DI, logging, application config file e.t.c</summary>
        /// <param name="services">The services.</param>
        /// <param name="appConfig">The application configuration.</param>
        private static void ConfigureServices(IServiceCollection services, IConfigurationRoot appConfig)
        {
            services
            .AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(appConfig.GetSection("Logging"));
                loggingBuilder.AddConsole();
            })
            .AddSingleton<IApp>(p => ActivatorUtilities.CreateInstance<App>(p, appConfig["ResourceSettings:Location"]));

            ServiceInjectionHelper.SetServiceCollection(services);
        }
    }
}
