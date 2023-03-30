using ChainOfResponsibility.Implementation.Data;
using ChainOfResponsibility.Implementation.Services.Parameters;
using ChainOfResponsibility.Implementation.Services.Results;
using ChainOfResponsibility.Sync;
using Core;
using Core.Abstractions.Interfaces;

namespace ChainOfResponsibility.Implementation.Services.Handlers
{
    public class ValidateRequest : OrderedHandlerBase<IUnitOfWork, CreateDemoParameter, CreateDemoResult>
    {
        public override int Order => 20;
        public override CreateDemoResult Handle(IContext<IUnitOfWork> context, CreateDemoParameter parameter, CreateDemoResult result)
        {
            var parameterValid = true;
            if (!parameterValid)
            {
                result.StatusCode = ResultCode.BadRequest;
                result.Message = "You missed something.";
                return result;
            }

            return NextHandler.Handle(context, parameter, result);
        }
    }
}
