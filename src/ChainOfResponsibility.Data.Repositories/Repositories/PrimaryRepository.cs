using ChainOfResponsibility.Data.Abstractions;
using ChainOfResponsibility.Data.Models;
using ChainOfResponsibility.Data.Models.Abstractions;
using ChainOfResponsibility.Data.Repositories.Abstractions.Interfaces;
using Core.Abstractions.Interfaces;

namespace ChainOfResponsibility.Data.Repositories.Repositories;

public class PrimaryRepository<TEntity> : RepositoryBase<TEntity>, IPrimaryRepository<TEntity> where TEntity : PrimaryBase 
{
    public PrimaryRepository(IUserContext userContext, IDatabaseContext databaseContext) 
        : base(userContext, databaseContext)
    {
    }
    
    public virtual TEntity Create(TEntity entity)
    {
        // TODO: 
        return entity;
    }

    public virtual TEntity Get(int id)
    {
        throw new NotImplementedException();
    }

    public virtual TEntity Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual void Delete(int id)
    {
        throw new NotImplementedException();
    }
}