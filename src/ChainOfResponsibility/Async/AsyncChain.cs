using Core.Interfaces;
using ChainOfResponsibility.Interfaces.Async;
using Core;

namespace ChainOfResponsibility.Async
{
    public class AsyncChain<TUnitOfWork, TParameter, TResult>
        : IAsyncChain<TParameter, TResult> where TResult : class, IResult
    {
        protected readonly IAsyncContext<TUnitOfWork> Context;
        protected readonly IAsyncHandler<TUnitOfWork, TParameter, TResult>? FirstHandler;

        public AsyncChain(IAsyncContext<TUnitOfWork> context, IAsyncHandler<TUnitOfWork, TParameter, TResult>? firstHandler)
        {
            Context = context;
            FirstHandler = firstHandler;
        }

        public async Task<TResult> ExecuteAsync(TParameter parameter, TResult result)
        {
            if (FirstHandler == null)
            {
                return await Task.FromResult(result);
            }
            return await FirstHandler.HandleAsync(Context, parameter, result).ConfigureAwait(false);
        }
    }
}
