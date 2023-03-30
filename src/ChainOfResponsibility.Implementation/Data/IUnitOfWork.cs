using ChainOfResponsibility.Data.Models;
using ChainOfResponsibility.Data.Models.Abstractions;
using ChainOfResponsibility.Data.Repositories.Abstractions.Interfaces;

namespace ChainOfResponsibility.Implementation.Data;

public interface IUnitOfWork
{
    IPrimaryRepository<TEntity> GetPrimaryRepository<TEntity>()
        where TEntity: PrimaryBase;

    ISubscriberRepository<TEntity> GetSubscriberRepository<TEntity>() 
        where TEntity: SubscriberBase;

    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}