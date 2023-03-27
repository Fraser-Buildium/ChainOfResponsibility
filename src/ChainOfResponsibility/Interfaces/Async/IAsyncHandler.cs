using Core;
using Core.Interfaces;

namespace ChainOfResponsibility.Interfaces.Async
{
    public interface IAsyncHandler<in TUnitOfWork, in TParameter, TResult>
        where TResult: class, IResult
    {
        public Task<TResult> HandleAsync(IAsyncContext<TUnitOfWork> context, TParameter parameter, TResult result);
    }
}