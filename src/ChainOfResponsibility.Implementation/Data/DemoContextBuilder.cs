using ChainOfResponsibility.Implementation.Data.UnitOfWorkFactories.Interfaces;
using ChainOfResponsibility.Interfaces.Sync;
using Core.Interfaces;

namespace ChainOfResponsibility.Implementation.Data;

public class DemoContextBuilder : IContextBuilder<IUnitOfWork>
{
    private readonly IUnitOfWorkFactory m_unitOfWorkFactory;
    
    public DemoContextBuilder(IUnitOfWorkFactory unitOfWorkFactory)
    {
        m_unitOfWorkFactory = unitOfWorkFactory;
    }
    
    public IContext<IUnitOfWork> Build(IUserContext userContext)
    {
        // TODO: Replace with a call to IUnitOfWorkFactory that accepts an IUserContext
        var unitOfWork = m_unitOfWorkFactory.CreateUnitOfWork(userContext);
        return new DemoContext(unitOfWork, userContext);
    }
}