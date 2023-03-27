using ChainOfResponsibility.Implementation.Services.Parameters;
using ChainOfResponsibility.Implementation.Services.Results;
using Core.Interfaces;

namespace ChainOfResponsibility.Implementation.Services.Interfaces
{
    public interface IDemoService
    {
        CreateDemoResult Create(IUserContext usercontext, CreateDemoParameter parameter);
    }
}
