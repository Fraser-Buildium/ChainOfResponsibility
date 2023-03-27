using Core.Interfaces;

namespace ChainOfResponsibility.Interfaces.Async;

public interface IAsyncContextBuilder<out TUnitOfWork>
{
    IAsyncContext<TUnitOfWork> Build(IUserContext userContext, CancellationToken cancellationToken);
}