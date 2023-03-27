using ChainOfResponsibility.Implementation.Data;
using ChainOfResponsibility.Implementation.Services.Parameters;
using ChainOfResponsibility.Implementation.Services.Results;
using ChainOfResponsibility.Sync;
using Core;
using Core.Interfaces;

namespace ChainOfResponsibility.Implementation.Services.Handlers
{
    public class CheckPermissions : OrderedHandlerBase<IUnitOfWork, CreateDemoParameter, CreateDemoResult>
    {
        public override int Order => 10;

        public override CreateDemoResult Handle(IContext<IUnitOfWork> context, CreateDemoParameter parameter, CreateDemoResult result)
        {
            var failsSecurityCheck = false;
            if (failsSecurityCheck)
            {
                result.StatusCode = ResultCode.Forbidden;
                result.Message = "Forbidden";
                return result;
            }

            return this.NextHandler.Handle(context, parameter, result);
        }

        
    }
}
