using Core;
using Core.Interfaces;

namespace ChainOfResponsibility.Interfaces.Async
{
    public interface IAsyncChainBuilder<in TUnitOfWork, in TParameter, TResult> where TResult : class, IResult
    {
        IAsyncChain<TParameter, TResult> Build(IAsyncContext<TUnitOfWork> context);
    }
}
