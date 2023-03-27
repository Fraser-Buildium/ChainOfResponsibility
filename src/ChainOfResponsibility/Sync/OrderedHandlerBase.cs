using ChainOfResponsibility.Interfaces.Sync;
using Core;

namespace ChainOfResponsibility.Sync
{
    public abstract class OrderedHandlerBase<TUnitOfWork, TParameter, TResult> 
        : HandlerBase<TUnitOfWork, TParameter, TResult>, IOrderedHandler<TUnitOfWork, TParameter, TResult> where TResult : class, IResult
    {
        public abstract int Order { get; }
    }
}
