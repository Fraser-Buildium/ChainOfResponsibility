using ChainOfResponsibility.Interfaces.Sync;
using Core;
using Core.Abstractions.Interfaces;

namespace ChainOfResponsibility.Sync
{
    public sealed class TerminatingHandler<TUnitOfWork, TParameter, TResult> 
        : IHandler<TUnitOfWork, TParameter, TResult> where TResult : class, IResult
    {
        public TResult Handle(IContext<TUnitOfWork> context, TParameter parameter, TResult result)
        {
            return result;
        }
    }
}
