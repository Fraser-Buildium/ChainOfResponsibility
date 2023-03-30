using ChainOfResponsibility.Implementation.Data;
using ChainOfResponsibility.Implementation.Services.Parameters;
using ChainOfResponsibility.Implementation.Services.Results;
using ChainOfResponsibility.Sync;
using Core;
using Core.Abstractions.Interfaces;
using Microsoft.Extensions.Logging;

namespace ChainOfResponsibility.Implementation.Services.Handlers
{
    public class InsertDemoEntity : OrderedHandlerBase<IUnitOfWork, CreateDemoParameter, CreateDemoResult>
    {
        private ILogger _logger;

        public InsertDemoEntity(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(GetType());
        }

        public override int Order => 40;

        public override CreateDemoResult Handle(IContext<IUnitOfWork> context, CreateDemoParameter parameter, CreateDemoResult result)
        {
            if (result.Entity == null)
            {
                _logger.LogError("Entity not created for insertion.");
                result.StatusCode = ResultCode.InternalServerError;
                result.Message = "Something went wrong";
                return result;
            }

            return NextHandler.Handle(context, parameter, result);
        }
    }
}
