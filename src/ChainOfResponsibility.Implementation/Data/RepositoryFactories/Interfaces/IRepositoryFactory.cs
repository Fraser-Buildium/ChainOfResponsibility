using ChainOfResponsibility.Implementation.Data.Interfaces;
using ChainOfResponsibility.Implementation.Data.Models;
using ChainOfResponsibility.Implementation.Data.Repositories.Interfaces;
using Core.Interfaces;

namespace ChainOfResponsibility.Implementation.Data.RepositoryFactories.Interfaces;

public interface IRepositoryFactory
{
    IPrimaryRepository<TEntity> GetPrimaryRepository<TEntity>(IUserContext userContext, IDatabaseContext databaseContext) where TEntity : PrimaryBase;
    ISubscriberRepository<TEntity> GetSubscriberRepository<TEntity>(IUserContext userContext, IDatabaseContext databaseContext) where TEntity : SubscriberBase;
}