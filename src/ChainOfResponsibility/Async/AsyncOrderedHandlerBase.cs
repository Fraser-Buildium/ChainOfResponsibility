using ChainOfResponsibility.Interfaces.Async;
using Core;

namespace ChainOfResponsibility.Async
{
    public abstract class AsyncOrderedHandlerBase<TUnitOfWork, TParameter, TResult> 
        : AsyncHandlerBase<TUnitOfWork, TParameter, TResult>, IOrderedAsyncHandler<TUnitOfWork, TParameter, TResult> 
        where TResult : class, IResult
    {
        public abstract int Order { get; }
    }
}
