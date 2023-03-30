using ChainOfResponsibility.Data.Abstractions;
using ChainOfResponsibility.Data.Models.Subscriber;
using ChainOfResponsibility.Data.Repositories.Abstractions.Interfaces;
using ChainOfResponsibility.Data.Repositories.Repositories;
using Core.Abstractions.Interfaces;
using Lamar;

namespace ChainOfResponsibility.Data.Repositories.RepositoryFactories;

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