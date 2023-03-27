using ChainOfResponsibility.Interfaces.Sync;
using Core;
using Core.Interfaces;

namespace ChainOfResponsibility.Sync
{
    public class Chain<TUnitOfWork, TParameter, TResult> 
        : IChain<TParameter, TResult> where TResult : class, IResult
    {
        protected readonly IContext<TUnitOfWork> Context;
        protected readonly IHandler<TUnitOfWork, TParameter, TResult>? FirstHandler;

        public Chain(IContext<TUnitOfWork> context, IHandler<TUnitOfWork, TParameter, TResult>? firstHandler)
        {
            Context = context;
            FirstHandler = firstHandler;
        }

        public TResult Execute(TParameter parameter, TResult result)
        {
            return FirstHandler?.Handle(Context, parameter, result) ?? result;
        }
    }
}
