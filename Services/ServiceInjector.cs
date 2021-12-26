using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Mappings;
using Services.Models;

namespace Services
{
    /// <summary>
    /// Service Injector class.
    /// </summary>
    public class ServiceInjector
    {
        /// <summary>
        /// Register Services.
        /// </summary>
        /// <param name="service">The Service.</param>
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<IServiceManager, ServiceManager>()
            .AddScoped<IWordLadderService, WordLadderService>()
            .AddScoped<IWordService, WordService>()
            .AddAutoMapper(typeof(WordMapping))
            .AddValidatorsFromAssemblyContaining<WordModel>();
        }
    }
}
