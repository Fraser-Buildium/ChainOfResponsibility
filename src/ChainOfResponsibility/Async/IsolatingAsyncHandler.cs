using ChainOfResponsibility.Interfaces.Async;
using Core;
using Core.Abstractions.Interfaces;
using Microsoft.Extensions.Logging;

namespace ChainOfResponsibility.Async
{
    public sealed class IsolatingAsyncHandler<TUnitOfWork, TParameter, TResult> 
        : AsyncHandlerBase<TUnitOfWork, TParameter, TResult> where TResult : class, IResult
    {
        public const string ClientClosedRequestMessage = "Client closed request.";
        public const string UnexpectedExceptionMessage = "An unexpected error occurred.";

        private IInitiatoryAsyncHandler<TUnitOfWork, TParameter, TResult>? _wrappedHandler;
        private readonly ILogger _logger;

        public IsolatingAsyncHandler(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(_wrappedHandler?.GetType() ?? GetType());
        }

        public void SetWrapped(IInitiatoryAsyncHandler<TUnitOfWork, TParameter, TResult> wrappedHandler)
        {
            if (_wrappedHandler != null)
            {
                throw new InvalidOperationException("Wrapped handler previously specified.");
            }

            if (NextHandler is not TerminatingAsyncHandler<TUnitOfWork, TParameter, TResult>)
            {
                throw new InvalidOperationException("Cannot wrap a handler, if the NextHandler is already set.");
            }

            _wrappedHandler = wrappedHandler;
        }

        public override void SetNext(IAsyncHandler<TUnitOfWork, TParameter, TResult> nextHandler)
        {
            if (_wrappedHandler == null)
            {
                base.SetNext(nextHandler);
                return;
            }

            _wrappedHandler.SetNext(nextHandler);
        }

        public override async Task<TResult> HandleAsync(IAsyncContext<TUnitOfWork> context, TParameter parameter,
            TResult result)
        {
            try
            {
                if (context.CancellationToken.IsCancellationRequested)
                {
                    result.StatusCode = ResultCode.BadRequest;
                    result.Message = ClientClosedRequestMessage;
                    return result;
                }

                if (!result.StatusCode.IsSuccessful)
                {
                    return result;
                }

                if (_wrappedHandler != null)
                {
                    return await _wrappedHandler.HandleAsync(context, parameter, result).ConfigureAwait(false);
                }
                
                return await NextHandler.HandleAsync(context, parameter, result).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                result.StatusCode = ResultCode.BadRequest;
                result.Message = ClientClosedRequestMessage;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, UnexpectedExceptionMessage);

                result.StatusCode = ResultCode.InternalServerError;
                result.Message = UnexpectedExceptionMessage;
                return result;
            }
        }
    }
}
