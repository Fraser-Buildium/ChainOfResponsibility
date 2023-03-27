using Core;

namespace ChainOfResponsibility.Interfaces.Sync
{
    public interface IChain<in TParameter, TResult> where TResult : class, IResult
    {
        TResult Execute(TParameter parameter, TResult result);
    }
}
