﻿using ChainOfResponsibility.Implementation.Data.Interfaces;
using ChainOfResponsibility.Implementation.Data.Models;
using ChainOfResponsibility.Implementation.Data.Repositories.Interfaces;
using ChainOfResponsibility.Implementation.Data.RepositoryFactories.Interfaces;
using Core.Interfaces;
using Lamar;

namespace ChainOfResponsibility.Implementation.Data.RepositoryFactories;

public class RepositoryFactory : IRepositoryFactory
{
    private Container m_container;

    public RepositoryFactory()
    {
        // TODO: Does this have a service locator code smell? Or, is this similar to the proxy suggestion from below?
        // See: https://freecontent.manning.com/dependency-injection-in-net-2nd-edition-abuse-of-abstract-factories/
        m_container = new Container(x => x.IncludeRegistry<RepositoryRegistry>());
    }
    
    public IPrimaryRepository<TEntity> GetPrimaryRepository<TEntity>(IUserContext userContext, IDatabaseContext databaseContext) where TEntity : PrimaryBase
    {
        var nested = m_container.GetNestedContainer();
        nested.Inject(userContext);
        nested.Inject(databaseContext);
        return nested.GetInstance<IPrimaryRepository<TEntity>>();
    }

    public ISubscriberRepository<TEntity> GetSubscriberRepository<TEntity>(IUserContext userContext, IDatabaseContext databaseContext) where TEntity : SubscriberBase
    {
        var nested = m_container.GetNestedContainer();
        nested.Inject(userContext);
        nested.Inject(databaseContext);
        return nested.GetInstance<ISubscriberRepository<TEntity>>();
    }
}