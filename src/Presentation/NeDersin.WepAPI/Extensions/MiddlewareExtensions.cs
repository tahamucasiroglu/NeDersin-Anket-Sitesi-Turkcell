using NeDersin.WepAPI.Middlewares;

namespace NeDersin.WepAPI.Extensions
{
    static public class MiddlewareExtensions
    {
        static public void AddMiddlewares(this WebApplication services)
        {
            services.UseMiddleware<JsonBodyCaughtMiddleware>();
            services.UseMiddleware<DetectBadWordsMiddleware>();
            services.UseMiddleware<UnauthorizedMiddleware>();
        }
    }
}
