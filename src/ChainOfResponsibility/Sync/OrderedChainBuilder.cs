using ChainOfResponsibility.Interfaces.Sync;
using Core;
using Core.Interfaces;

namespace ChainOfResponsibility.Sync
{
    public class OrderedChainBuilder<TUnitOfWork, TParameter, TResult> 
        : IChainBuilder<TUnitOfWork, TParameter, TResult> where TResult : class, IResult
    {
        protected readonly List<IOrderedHandler<TUnitOfWork, TParameter, TResult>> Handlers;

        public OrderedChainBuilder(IEnumerable<IOrderedHandler<TUnitOfWork, TParameter, TResult>> handlers)
        {
            Handlers = handlers.ToList();
        }

        public IChain<TParameter, TResult> Build(IContext<TUnitOfWork> context)
        {
            IHandler<TUnitOfWork, TParameter, TResult>? firstHandler = null;
            IInitiatoryHandler<TUnitOfWork, TParameter, TResult>? previousHandler = null;

            foreach (var handler in Handlers.OrderBy(h => h.Order))
            {
                firstHandler ??= handler;

                previousHandler?.SetNext(handler);

                previousHandler = handler;
            }

            var finalHandler = new TerminatingHandler<TUnitOfWork, TParameter, TResult>();
            previousHandler?.SetNext(finalHandler);
            firstHandler ??= finalHandler;

            return new Chain<TUnitOfWork, TParameter, TResult>(context, firstHandler);
        }
    }
}
