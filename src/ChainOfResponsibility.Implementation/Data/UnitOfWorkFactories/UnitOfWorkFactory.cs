using ChainOfResponsibility.Data.Abstractions;
using ChainOfResponsibility.Implementation.Data.UnitOfWorkFactories.Interfaces;
using Core.Abstractions.Interfaces;
using Lamar;

namespace ChainOfResponsibility.Implementation.Data.UnitOfWorkFactories;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private IDatabaseContextBuilder m_databaseContextBuilder;
    private Container m_container;

    public UnitOfWorkFactory(IDatabaseContextBuilder databaseContextBuilder)
    {
        m_databaseContextBuilder = databaseContextBuilder;
        m_container = new Container(x => x.IncludeRegistry<UnitOfWorkRegistry>());
    }
    
    public IUnitOfWork CreateUnitOfWork(IUserContext userContext)
    {
        var databaseContext = m_databaseContextBuilder.Build(userContext);
        var nested = m_container.GetNestedContainer();
        nested.Inject(userContext);
        nested.Inject(databaseContext);
        return nested.GetInstance<IUnitOfWork>();
    }
}