using ChainOfResponsibility.Interfaces.Async;
using Core;
using Core.Interfaces;

namespace ChainOfResponsibility.Async
{
    public sealed class TerminatingAsyncHandler<TUnitOfWork, TParameter, TResult> 
        : IAsyncHandler<TUnitOfWork, TParameter, TResult> where TResult : class, IResult
    {
        public const string ClientClosedRequestMessage = "Client closed request.";

        public async Task<TResult> HandleAsync(IAsyncContext<TUnitOfWork> context, TParameter parameter, TResult result)
        {
            if (context.CancellationToken.IsCancellationRequested)
            {
                result.StatusCode = ResultCode.BadRequest;
                result.Message = ClientClosedRequestMessage;
            }

            return await Task.FromResult(result);
        }
    }
}
