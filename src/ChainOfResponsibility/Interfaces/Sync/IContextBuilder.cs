using Core.Abstractions.Interfaces;

namespace ChainOfResponsibility.Interfaces.Sync;

public interface IContextBuilder<out TUnitOfWork>
{
    IContext<TUnitOfWork> Build(IUserContext context);
}