using Microsoft.EntityFrameworkCore;
using NeDersin.Entities.Concrete.Entities;
using NeDersin.Infrastructure.Contexts;
using NeDersin.Services.Extensions;

namespace NeDersin.WepAPI.Extensions
{
    static public class TestDbExtension
    {
        public static void TestDb(this IServiceProvider services)
        {
            using (var context = services.CreateScope().ServiceProvider.GetRequiredService<NeDersinDbContext>())
            {
                context.Set<Response>().AsNoTracking().ToList().ForEach(response =>
                {
                    Console.WriteLine($"{response.Id} - {response.UserId} - {response.QuestionId} - {response.ResponseText}");
                });
            }
        }
    }
}
