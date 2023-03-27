using ChainOfResponsibility.Implementation.Data.Interfaces;
using ChainOfResponsibility.Implementation.Data.RepositoryFactories;
using ChainOfResponsibility.Implementation.Data.RepositoryFactories.Interfaces;
using ChainOfResponsibility.Implementation.Data.UnitOfWorkFactories.Interfaces;
using Core.Interfaces;
using Lamar;

namespace ChainOfResponsibility.Implementation.Data.UnitOfWorkFactories;

public class UnitOfWorkRegistry : ServiceRegistry
{
    public UnitOfWorkRegistry()
    {
        Injectable<IUserContext>();
        Injectable<IDatabaseContext>();
        For<IRepositoryFactory>().Use<RepositoryFactory>();
        For<IUnitOfWork>().Use<UnitOfWork>();
    }
}