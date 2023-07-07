using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace NeDersin.WepAPI.Extensions
{
    static public class LoggerExtension
    {
        static public void SetMinLevelToWarning(this ILoggingBuilder builder) => builder.SetMinimumLevel(LogLevel.Warning);
        static public void AddLoggerToService(this IServiceCollection services) => services.AddLogging(c => c.SetMinLevelToWarning());
    }
}
