using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.Repositories.Interfaces;

namespace Persistence
{
    /// <summary>
    /// Repository Injector class.
    /// </summary>
    public class RepositoryInjector
    {
        /// <summary>
        /// Register Services.
        /// </summary>
        /// <param name="service">The Service.</param>
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<IWordRepository, WordRepository>()
            .AddScoped<IRepositoryManager, RepositoryManager>()
            .AddScoped<IRepositoryContext, RepositoryContext>();
        }
    }
}
