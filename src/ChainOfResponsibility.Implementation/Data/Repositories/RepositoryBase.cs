using ChainOfResponsibility.Implementation.Data.Interfaces;
using ChainOfResponsibility.Implementation.Data.Models;
using Core.Interfaces;

namespace ChainOfResponsibility.Implementation.Data.Repositories;

public abstract class RepositoryBase<TEntity> where TEntity: EntityBase
{
    protected readonly IUserContext UserContext ;
    protected readonly IDatabaseContext DatabaseContext;

    protected RepositoryBase(IUserContext userContext, IDatabaseContext databaseContext)
    {
        UserContext = userContext;
        DatabaseContext = databaseContext;
    }
}