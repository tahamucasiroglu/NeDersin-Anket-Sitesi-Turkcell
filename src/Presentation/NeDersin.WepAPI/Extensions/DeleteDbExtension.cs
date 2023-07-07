using NeDersin.Infrastructure.Contexts;

namespace NeDersin.WepAPI.Extensions
{
    static public class DeleteDbExtension
    {
        static public void DeleteDbIfExist(this IServiceProvider services)
        {
            using (var context = services.CreateScope().ServiceProvider.GetRequiredService<NeDersinDbContext>())
            {
                if (context.Database.CanConnect())
                {
                    context.Database.EnsureDeleted();
                }
            }
        }
    }
}
