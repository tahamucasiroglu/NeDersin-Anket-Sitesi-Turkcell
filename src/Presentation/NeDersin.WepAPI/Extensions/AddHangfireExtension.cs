using Hangfire;
using Hangfire.SqlServer;

namespace NeDersin.WepAPI.Extensions
{
    static public class AddHangfireExtension
    {
        public static IServiceCollection AddCustomHangfireExtension(this IServiceCollection services, string connectionString)
        {
            services.AddHangfire(x => x.UseSqlServerStorage(connectionString));
            services.AddHangfireServer();

            

            return services;
        }
    }
}
