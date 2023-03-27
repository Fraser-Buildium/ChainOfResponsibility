using Core;

namespace ChainOfResponsibility.Interfaces.Async
{
    public interface IOrderedAsyncHandler<TUnitOfWork, TParameter, TResult> 
        : IInitiatoryAsyncHandler<TUnitOfWork, TParameter, TResult> where TResult : class, IResult
    {
        int Order { get; }
    }
}
