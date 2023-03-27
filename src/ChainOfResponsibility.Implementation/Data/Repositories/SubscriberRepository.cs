using ChainOfResponsibility.Implementation.Data.Interfaces;
using ChainOfResponsibility.Implementation.Data.Models;
using ChainOfResponsibility.Implementation.Data.Repositories.Interfaces;
using Core.Interfaces;

namespace ChainOfResponsibility.Implementation.Data.Repositories;

public class SubscriberRepository<TEntity> : RepositoryBase<TEntity>, ISubscriberRepository<TEntity> 
    where TEntity : SubscriberBase
{
    // ReSharper disable once MemberCanBeProtected.Global
    public SubscriberRepository(IUserContext userContext, IDatabaseContext databaseContext) 
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