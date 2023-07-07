using Microsoft.EntityFrameworkCore;
using NeDersin.Infrastructure.Contexts;

namespace NeDersin.WepAPI.Extensions
{
    static public class AddDbContextExtension
    {
        public static IServiceCollection AddContext(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<NeDersinDbContext>
             (
                 opt =>
                 {
                     opt.UseSqlServer(connectionString);
                     opt.UseLoggerFactory(LoggerFactory.Create(builder =>
                     {
                         builder.AddConsole();
                         builder.SetMinimumLevel(LogLevel.Warning); //açılıştaki bir sürü konsol çıktısını önlemek için
                     }));
                 }
             );
            return services;

        }
    }
}
