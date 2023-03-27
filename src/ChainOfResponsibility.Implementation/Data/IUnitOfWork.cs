using ChainOfResponsibility.Implementation.Data.Models;
using ChainOfResponsibility.Implementation.Data.Repositories.Interfaces;

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