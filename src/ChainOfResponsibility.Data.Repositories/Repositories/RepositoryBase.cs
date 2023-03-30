using ChainOfResponsibility.Data.Abstractions;
using ChainOfResponsibility.Data.Models;
using ChainOfResponsibility.Data.Models.Abstractions;
using Core.Abstractions.Interfaces;

namespace ChainOfResponsibility.Data.Repositories.Repositories;

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