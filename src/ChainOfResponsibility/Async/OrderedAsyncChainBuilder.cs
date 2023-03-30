using ChainOfResponsibility.Interfaces.Async;
using Core;
using Core.Abstractions.Interfaces;

namespace ChainOfResponsibility.Async
{
    public class OrderedAsyncChainBuilder<TUnitOfWork, TParameter, TResult> 
        : AsyncChainBuilderBase<TUnitOfWork, TParameter, TResult>, IAsyncChainBuilder<TUnitOfWork, TParameter, TResult> where TResult : class, IResult
    {
        protected readonly List<IOrderedAsyncHandler<TUnitOfWork, TParameter, TResult>> Handlers;
        public OrderedAsyncChainBuilder(IEnumerable<IOrderedAsyncHandler<TUnitOfWork, TParameter, TResult>> handlers)
        {
            Handlers = handlers.ToList();

            ValidateLoop(Handlers);
        }

        public override IAsyncChain<TParameter, TResult> Build(IAsyncContext<TUnitOfWork> context)
        {
            IAsyncHandler<TUnitOfWork, TParameter, TResult>? firstHandler = null;
            IInitiatoryAsyncHandler<TUnitOfWork, TParameter, TResult>? previousHandler = null;

            foreach (var handler in Handlers.OrderBy(h => h.Order))
            {
                firstHandler ??= handler;

                previousHandler?.SetNext(handler);

                previousHandler = handler;
            }

            var finalHandler = new TerminatingAsyncHandler<TUnitOfWork, TParameter, TResult>();
            previousHandler?.SetNext(finalHandler);
            firstHandler ??= finalHandler;

            return new AsyncChain<TUnitOfWork, TParameter, TResult>(context, firstHandler);
        }
    }
}
