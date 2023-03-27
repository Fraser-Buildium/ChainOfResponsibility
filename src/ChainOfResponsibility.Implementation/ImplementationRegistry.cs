using ChainOfResponsibility.Implementation.Data;
using ChainOfResponsibility.Implementation.Data.RepositoryFactories;
using ChainOfResponsibility.Implementation.Services;
using Lamar;

namespace ChainOfResponsibility.Implementation;

public class ImplementationRegistry : ServiceRegistry
{
    public ImplementationRegistry()
    {
        IncludeRegistry<LoggingRegistry>();
        IncludeRegistry<RepositoryRegistry>();
        IncludeRegistry<DemoRegistry>();
        IncludeRegistry<DataRegistry>();
    }
}