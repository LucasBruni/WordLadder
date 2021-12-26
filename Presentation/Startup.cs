using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistence;
using Services;
using System;

namespace Presentation
{
    /// <summary>
    /// Startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configure services.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <returns>IServiceProvider.</returns>
        public IServiceProvider ConfigureServices()
        {
            var service = new ServiceCollection();

            ServiceInjector.RegisterServices(service);
            RepositoryInjector.RegisterServices(service);

            return service.AddLogging(config => config.ClearProviders().AddConsole().SetMinimumLevel(LogLevel.Debug))
            .AddScoped<Program>()
            .BuildServiceProvider();
        }
    }
}
