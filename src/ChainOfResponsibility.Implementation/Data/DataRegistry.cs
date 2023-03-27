using ChainOfResponsibility.Implementation.Data.Interfaces;
using ChainOfResponsibility.Implementation.Data.RepositoryFactories;
using ChainOfResponsibility.Implementation.Data.RepositoryFactories.Interfaces;
using ChainOfResponsibility.Implementation.Data.UnitOfWorkFactories;
using ChainOfResponsibility.Implementation.Data.UnitOfWorkFactories.Interfaces;
using Lamar;

namespace ChainOfResponsibility.Implementation.Data;

public class DataRegistry : ServiceRegistry
{
    public DataRegistry()
    {
        For<IDatabaseContextBuilder>().Use<DatabaseContextBuilder>();
        For<IUnitOfWorkFactory>().Use<UnitOfWorkFactory>();
        For<IRepositoryFactory>().Use<RepositoryFactory>();
    }
}