using ChainOfResponsibility.Interfaces.Async;
using Core;
using Core.Abstractions.Interfaces;

namespace ChainOfResponsibility.Async
{
    public abstract class AsyncChainBuilderBase<TUnitOfWork, TParameter, TResult>
        : IAsyncChainBuilder<TUnitOfWork, TParameter, TResult> where TResult : class, IResult
    {
        public abstract IAsyncChain<TParameter, TResult> Build(IAsyncContext<TUnitOfWork> context);

        protected void ValidateLoop(IEnumerable<IAsyncHandler<TUnitOfWork, TParameter, TResult>> handlers)
        {
            var handlersToValidate = handlers.ToList();
            int index = 1;
            foreach (var handler in handlersToValidate)
            {
                var loopDetected = handlersToValidate.Skip(index)
                    .Any(h0 => ReferenceEquals(h0, handler));
                if (loopDetected)
                {
                    throw new InvalidOperationException($"Loop detected on {handler.GetType()}! Chain of responsibility should not have duplicate instances.");
                }

                index++;
            }
        }
        
    }
}
