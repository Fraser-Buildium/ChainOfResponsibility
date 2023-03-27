using ChainOfResponsibility.Implementation.Data.Interfaces;
using ChainOfResponsibility.Implementation.Data.Models;
using ChainOfResponsibility.Implementation.Data.Repositories.Exceptions;
using ChainOfResponsibility.Implementation.Data.Repositories.Interfaces;
using Core;
using Core.Interfaces;
using JasperFx.Core.Reflection;

namespace ChainOfResponsibility.Implementation.Data.Repositories;

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