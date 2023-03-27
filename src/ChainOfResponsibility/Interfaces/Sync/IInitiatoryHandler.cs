using Core;

namespace ChainOfResponsibility.Interfaces.Sync
{
    public interface IInitiatoryHandler<TUnitOfWork, TParameter, TResult> 
        : IHandler<TUnitOfWork, TParameter, TResult> where TResult : class, IResult
    {
        void SetNext(IHandler<TUnitOfWork, TParameter, TResult> nextHandler);
    }
}
