using Core;

namespace ChainOfResponsibility.Interfaces.Async
{
    public interface IInitiatoryAsyncHandler<TUnitOfWork, TParameter, TResult> 
        : IAsyncHandler<TUnitOfWork, TParameter, TResult> where TResult : class, IResult
    {
        void SetNext(IAsyncHandler<TUnitOfWork, TParameter, TResult> nextHandler);
    }
}
