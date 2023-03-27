using Core;

namespace ChainOfResponsibility.Interfaces.Async
{
    public interface IAsyncChain<in TParameter, TResult> where TResult : class, IResult
    {
        Task<TResult> ExecuteAsync(TParameter parameter, TResult result);
    }
}
