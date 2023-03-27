using ChainOfResponsibility.Interfaces.Sync;
using Core;
using Core.Interfaces;

namespace ChainOfResponsibility.Sync
{
    public abstract class HandlerBase<TUnitOfWork, TParameter, TResult> 
        : IInitiatoryHandler<TUnitOfWork, TParameter, TResult> where TResult : class, IResult
    {
        protected HandlerBase()
        {
            NextHandler = new TerminatingHandler<TUnitOfWork, TParameter, TResult>();
        }

        protected IHandler<TUnitOfWork, TParameter, TResult> NextHandler { get; private set; }

        public virtual void SetNext(IHandler<TUnitOfWork, TParameter, TResult> nextHandler)
        {
            if (NextHandler is not TerminatingHandler<TUnitOfWork, TParameter, TResult>)
            {
                throw new InvalidOperationException($"{nameof(NextHandler)} already set.");
            }

            NextHandler = nextHandler;
        }

        public abstract TResult Handle(IContext<TUnitOfWork> context, TParameter parameter, TResult result);
    }
}
