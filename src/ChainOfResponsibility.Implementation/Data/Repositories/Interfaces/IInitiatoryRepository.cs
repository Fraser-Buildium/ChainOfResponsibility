using Core.Interfaces;

namespace ChainOfResponsibility.Implementation.Data.Repositories.Interfaces;

public interface IInitiatoryRepository
{
    void Initialize(IUserContext userContext, string connectionString);
}