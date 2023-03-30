using Core;
using Core.Abstractions.Interfaces;

namespace ChainOfResponsibility.Interfaces.Sync
{
    public interface IHandler<in TUnitOfWork, in TParameter, TResult>
        where TResult: class, IResult
    {
        public TResult Handle(IContext<TUnitOfWork> context, TParameter parameter, TResult result);
    }
}