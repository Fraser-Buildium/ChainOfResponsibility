using ChainOfResponsibility.Data.Abstractions;
using ChainOfResponsibility.Data.Repositories.Abstractions.Interfaces;
using ChainOfResponsibility.Data.Repositories.RepositoryFactories;
using Core.Abstractions.Interfaces;
using Lamar;

namespace ChainOfResponsibility.Implementation.Data.UnitOfWorkFactories;

public class UnitOfWorkRegistry : ServiceRegistry
{
    public UnitOfWorkRegistry()
    {
        Injectable<IUserContext>();
        Injectable<IDatabaseContext>();
        For<IRepositoryFactory>().Use<RepositoryFactory>().Singleton();
        For<IUnitOfWork>().Use<UnitOfWork>();
    }
}