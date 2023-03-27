using ChainOfResponsibility.Implementation.Data;
using ChainOfResponsibility.Implementation.Data.Models;
using ChainOfResponsibility.Implementation.Services.Parameters;
using ChainOfResponsibility.Implementation.Services.Results;
using ChainOfResponsibility.Sync;
using Core;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace ChainOfResponsibility.Implementation.Services.Handlers
{
    public class CreateDemoEntity : OrderedHandlerBase<IUnitOfWork, CreateDemoParameter, CreateDemoResult>
    {
        private readonly ILogger _logger;

        public CreateDemoEntity(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(GetType());
        }

        public override int Order => 30;
        public override CreateDemoResult Handle(IContext<IUnitOfWork> context, CreateDemoParameter parameter, CreateDemoResult result)
        {
            try
            {
                result.Entity = context.UnitOfWork.GetSubscriberRepository<Demo>().Create(new Demo());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error creating Demo: {ex.Message}{Environment.NewLine}{ex.StackTrace}");
                result.StatusCode = ResultCode.InternalServerError;
                result.Message = "Something went wrong.";
                return result;
            }

            return NextHandler.Handle(context, parameter, result);
        }
    }
}
