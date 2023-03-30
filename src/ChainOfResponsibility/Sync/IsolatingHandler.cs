using System.Net;
using ChainOfResponsibility.Interfaces.Sync;
using Core;
using Core.Abstractions.Interfaces;
using Microsoft.Extensions.Logging;

namespace ChainOfResponsibility.Sync
{
    public class IsolatingHandler<TUnitOfWork, TParameter, TResult> 
        : HandlerBase<TUnitOfWork, TParameter, TResult> where TResult : class, IResult
    {
        public const string UnexpectedExceptionMessage = "An unexpected error occurred.";

        private IInitiatoryHandler<TUnitOfWork, TParameter, TResult>? _wrappedHandler;
        private readonly ILogger _logger;

        public IsolatingHandler(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(_wrappedHandler?.GetType() ?? GetType());
        }

        public void SetWrapped(IInitiatoryHandler<TUnitOfWork, TParameter, TResult> wrappedHandler)
        {
            if (_wrappedHandler != null)
            {
                throw new InvalidOperationException("Wrapped handler previously specified.");
            }

            if (NextHandler is not TerminatingHandler<TUnitOfWork, TParameter, TResult>)
            {
                throw new InvalidOperationException("Cannot wrap a handler, if the NextHandler is already set.");
            }

            _wrappedHandler = wrappedHandler;
        }

        public override void SetNext(IHandler<TUnitOfWork, TParameter, TResult> nextHandler)
        {
            if (_wrappedHandler == null)
            {
                base.SetNext(nextHandler);
                return;
            }

            _wrappedHandler.SetNext(nextHandler);
        }

        public override TResult Handle(IContext<TUnitOfWork> context, TParameter parameter, TResult result)
        {
            try
            {
                if (!result.StatusCode.IsSuccessful)
                {
                    return result;
                }

                if (_wrappedHandler != null)
                {
                    return _wrappedHandler.Handle(context, parameter, result);
                }
                    
                return NextHandler.Handle(context, parameter, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, UnexpectedExceptionMessage);

                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Message = UnexpectedExceptionMessage;
                return result;
            }
        }
    }
}
