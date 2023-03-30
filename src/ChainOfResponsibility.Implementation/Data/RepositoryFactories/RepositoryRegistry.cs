using ChainOfResponsibility.Implementation.Data.Interfaces;
using ChainOfResponsibility.Implementation.Data.Models;
using ChainOfResponsibility.Implementation.Data.Repositories;
using ChainOfResponsibility.Implementation.Data.Repositories.Interfaces;
using Core.Interfaces;
using Lamar;

namespace ChainOfResponsibility.Implementation.Data.RepositoryFactories;

public class RepositoryRegistry : ServiceRegistry
{
    public RepositoryRegistry()
    {
        Injectable<IUserContext>();
        Injectable<IDatabaseContext>();
        For(typeof(IPrimaryRepository<>)).Use(typeof(PrimaryRepository<>)).Scoped();
        
        For(typeof(ISubscriberRepository<>)).Use(typeof(SubscriberRepository<>)).Scoped();
        For<ISubscriberRepository<Demo>>().Use<DemoRepository>().Scoped();
    }
}