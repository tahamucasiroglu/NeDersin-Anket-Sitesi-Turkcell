using Microsoft.Extensions.Logging;
using NeDersin.WepAPI.Enumeration.HateoasEnumeration;
using NeDersin.WepAPI.Filters;

namespace NeDersin.WepAPI.Extensions
{
    static public class AddSingletonExtension
    {
        static public IServiceCollection AddSingletons(this IServiceCollection services)
        {
            services.AddSingleton<HateoasEnumeration>();

            services.AddSingleton<LogFilterAttribute>();

            return services;
        }
    }
}
