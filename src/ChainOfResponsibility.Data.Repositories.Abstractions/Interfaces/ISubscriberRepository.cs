using ChainOfResponsibility.Data.Models.Abstractions;

namespace ChainOfResponsibility.Data.Repositories.Abstractions.Interfaces;

public interface ISubscriberRepository<TEntity> where TEntity: SubscriberBase
{
    TEntity Create(TEntity entity);
    TEntity Get(int id);
    TEntity Update(TEntity entity);
    void Delete(int id);
}