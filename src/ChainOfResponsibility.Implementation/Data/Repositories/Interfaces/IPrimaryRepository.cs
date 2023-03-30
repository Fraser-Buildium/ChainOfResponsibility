using ChainOfResponsibility.Implementation.Data.Models;

namespace ChainOfResponsibility.Implementation.Data.Repositories.Interfaces;

public interface IPrimaryRepository<TEntity> where TEntity: PrimaryBase
{
    TEntity Create(TEntity entity);
    TEntity Get(int id);
    TEntity Update(TEntity entity);
    void Delete(int id);
}