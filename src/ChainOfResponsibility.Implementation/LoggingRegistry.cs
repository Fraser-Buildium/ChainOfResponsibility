using Lamar;
using Microsoft.Extensions.Logging;

namespace ChainOfResponsibility.Implementation;

public class LoggingRegistry : ServiceRegistry
{
    public LoggingRegistry()
    {
        For<ILoggerFactory>().Use(LoggerFactory
            .Create(builder => builder
                .AddConsole()
                .AddFilter(level => level >= LogLevel.Warning))).Singleton();
    }
}