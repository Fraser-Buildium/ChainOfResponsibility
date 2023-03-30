using Core.Abstractions.Interfaces;

namespace ChainOfResponsibility.Data.Abstractions;

public interface IDatabaseContextBuilder
{
    IDatabaseContext Build(IUserContext userContext);
}