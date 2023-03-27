using Core;
using Core.Interfaces;

namespace ChainOfResponsibility.Interfaces.Sync
{
    public interface IChainBuilder<in TUnitOfWork, in TParameter, TResult> where TResult : class, IResult
    {
        IChain<TParameter, TResult> Build(IContext<TUnitOfWork> context);
    }
}
