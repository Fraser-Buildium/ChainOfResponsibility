using Core.Interfaces;

namespace ChainOfResponsibility.Implementation.Data.UnitOfWorkFactories.Interfaces;

public interface IUnitOfWorkFactory
{
    IUnitOfWork CreateUnitOfWork(IUserContext userContext);
}