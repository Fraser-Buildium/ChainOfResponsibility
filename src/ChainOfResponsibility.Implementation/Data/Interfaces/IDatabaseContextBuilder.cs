using Core.Interfaces;

namespace ChainOfResponsibility.Implementation.Data.Interfaces;

public interface IDatabaseContextBuilder
{
    IDatabaseContext Build(IUserContext userContext);
}