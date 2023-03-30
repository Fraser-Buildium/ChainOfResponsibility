using ChainOfResponsibility.Implementation.Data;
using ChainOfResponsibility.Implementation.Services.Handlers;
using ChainOfResponsibility.Implementation.Services.Interfaces;
using ChainOfResponsibility.Implementation.Services.Parameters;
using ChainOfResponsibility.Implementation.Services.Results;
using ChainOfResponsibility.Interfaces.Sync;
using ChainOfResponsibility.Sync;
using Lamar;

namespace ChainOfResponsibility.Implementation.Services;

public class DemoRegistry : ServiceRegistry
{
    public DemoRegistry()
    {
        // TODO: This seems like a good candidate for source generation.
        For<IOrderedHandler<IUnitOfWork, CreateDemoParameter, CreateDemoResult>>()
            .Add<CheckPermissions>()
            .Scoped();
        For<IOrderedHandler<IUnitOfWork, CreateDemoParameter, CreateDemoResult>>()
            .Add<ValidateRequest>()
            .Scoped();
        For<IOrderedHandler<IUnitOfWork, CreateDemoParameter, CreateDemoResult>>()
            .Add<CreateDemoEntity>()
            .Scoped();
        For<IOrderedHandler<IUnitOfWork, CreateDemoParameter, CreateDemoResult>>()
            .Add<InsertDemoEntity>()
            .Scoped();

        For<IDemoService>()
            .Use<DemoService>()
            .Scoped();

        For<IContextBuilder<IUnitOfWork>>()
            .Use<DemoContextBuilder>()
            .Scoped();
        For<IChainBuilder<IUnitOfWork, CreateDemoParameter, CreateDemoResult>>()
            .Use<OrderedChainBuilder<IUnitOfWork, CreateDemoParameter, CreateDemoResult>>();
    }
}