using ChainOfResponsibility.Data.Models.Abstractions;

namespace ChainOfResponsibility.Data.Repositories.Abstractions.Interfaces;

public interface IPrimaryRepository<TEntity> where TEntity: PrimaryBase
{
    TEntity Create(TEntity entity);
    TEntity Get(int id);
    TEntity Update(TEntity entity);
    void Delete(int id);
}