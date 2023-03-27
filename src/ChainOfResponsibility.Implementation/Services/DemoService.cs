using ChainOfResponsibility.Implementation.Data;
using ChainOfResponsibility.Implementation.Services.Interfaces;
using ChainOfResponsibility.Implementation.Services.Parameters;
using ChainOfResponsibility.Implementation.Services.Results;
using ChainOfResponsibility.Interfaces.Sync;
using Core.Interfaces;

namespace ChainOfResponsibility.Implementation.Services
{
    public sealed class DemoService : IDemoService
    {
        private readonly IChainBuilder<IUnitOfWork, CreateDemoParameter, CreateDemoResult> m_builder;
        private readonly IContextBuilder<IUnitOfWork> m_contextBuilder;

        public DemoService(IChainBuilder<IUnitOfWork, CreateDemoParameter, CreateDemoResult> builder, IContextBuilder<IUnitOfWork> contextBuilder)
        {
            m_builder = builder;
            m_contextBuilder = contextBuilder;
        }
        public CreateDemoResult Create(IUserContext userContext, CreateDemoParameter parameter)
        {
            // TODO: Use IChainFactory to select a chain builder, and context builder, instead of using a chain builder directly.
            var context = m_contextBuilder.Build(userContext);
            return m_builder.Build(context)
                .Execute(parameter, new CreateDemoResult());
        }
    }
}