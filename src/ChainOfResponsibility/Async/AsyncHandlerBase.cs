using ChainOfResponsibility.Interfaces.Async;
using Core;
using Core.Abstractions.Interfaces;

namespace ChainOfResponsibility.Async
{
    public abstract class AsyncHandlerBase<TUnitOfWork, TParameter, TResult> 
        : IAsyncHandler<TUnitOfWork, TParameter, TResult> where TResult : class, IResult
    {
        protected AsyncHandlerBase()
        {
            NextHandler = new TerminatingAsyncHandler<TUnitOfWork, TParameter, TResult>();
        }

        protected IAsyncHandler<TUnitOfWork, TParameter, TResult>? NextHandler { get; private set; }

        public virtual void SetNext(IAsyncHandler<TUnitOfWork, TParameter, TResult> nextHandler)
        {
            if (NextHandler is not TerminatingAsyncHandler<TUnitOfWork, TParameter, TResult>)
            {
                throw new InvalidOperationException($"{nameof(NextHandler)} already set.");
            }

            NextHandler = nextHandler;
        }

        public abstract Task<TResult> HandleAsync(IAsyncContext<TUnitOfWork> context, TParameter parameter,
            TResult result);
    }
}
