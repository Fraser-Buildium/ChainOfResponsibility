using ChainOfResponsibility.Implementation.Data.Interfaces;
using ChainOfResponsibility.Implementation.Data.Repositories;
using ChainOfResponsibility.Implementation.Data.Repositories.Interfaces;
using ChainOfResponsibility.Implementation.Data.RepositoryFactories.Interfaces;
using Core;
using Core.Interfaces;
using Lamar;

namespace ChainOfResponsibility.Implementation.Data.RepositoryFactories;

public class RepositoryRegistry : ServiceRegistry
{
    public RepositoryRegistry()
    {
        Injectable<IUserContext>();
        Injectable<IDatabaseContext>();
        For(typeof(IPrimaryRepository<>)).Use(typeof(PrimaryRepository<>));
        
        For(typeof(ISubscriberRepository<>)).Use(typeof(SubscriberRepository<>));
        Scan(x =>
        {
            x.TheCallingAssembly();
            x.ConnectImplementationsToTypesClosing(typeof(ISubscriberRepository<>));
            x.ConnectImplementationsToTypesClosing(typeof(IPrimaryRepository<>));
        });
    }
}