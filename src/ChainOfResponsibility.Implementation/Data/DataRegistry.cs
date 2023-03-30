using ChainOfResponsibility.Data.Abstractions;
using ChainOfResponsibility.Data.Repositories.Abstractions.Interfaces;
using ChainOfResponsibility.Data.Repositories.RepositoryFactories;
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