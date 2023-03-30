using ChainOfResponsibility.Data.Abstractions;
using ChainOfResponsibility.Data.Models.Abstractions;
using Core.Abstractions.Interfaces;

namespace ChainOfResponsibility.Data.Repositories.Abstractions.Interfaces;

public interface IRepositoryFactory
{
    IPrimaryRepository<TEntity> GetPrimaryRepository<TEntity>(IUserContext userContext, IDatabaseContext databaseContext) where TEntity : PrimaryBase;
    ISubscriberRepository<TEntity> GetSubscriberRepository<TEntity>(IUserContext userContext, IDatabaseContext databaseContext) where TEntity : SubscriberBase;
}