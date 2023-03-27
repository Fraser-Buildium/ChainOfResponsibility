using Core;

namespace ChainOfResponsibility.Interfaces.Sync
{
    public interface IOrderedHandler<TUnitOfWork, TParameter, TResult> 
        : IInitiatoryHandler<TUnitOfWork, TParameter, TResult> where TResult : class, IResult
    {
        int Order { get; }
    }
}
