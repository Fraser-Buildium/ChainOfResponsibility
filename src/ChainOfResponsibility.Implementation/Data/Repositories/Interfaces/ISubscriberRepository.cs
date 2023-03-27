using ChainOfResponsibility.Implementation.Data.Models;
using Core.Interfaces;

namespace ChainOfResponsibility.Implementation.Data.Repositories.Interfaces;

public interface ISubscriberRepository<TEntity> where TEntity: SubscriberBase
{
    TEntity Create(TEntity entity);
    TEntity Get(int id);
    TEntity Update(TEntity entity);
    void Delete(int id);
}