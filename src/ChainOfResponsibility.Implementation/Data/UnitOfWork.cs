using ChainOfResponsibility.Implementation.Data.Interfaces;
using ChainOfResponsibility.Implementation.Data.Models;
using ChainOfResponsibility.Implementation.Data.Repositories.Interfaces;
using ChainOfResponsibility.Implementation.Data.RepositoryFactories.Interfaces;
using Core.Interfaces;

namespace ChainOfResponsibility.Implementation.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserContext m_userContext;
        private IDatabaseContext m_databaseContext;
        private IRepositoryFactory m_repositoryFactory;
        public UnitOfWork(IUserContext userContext, IDatabaseContext databaseContext, IRepositoryFactory repositoryFactory)
        {
            m_userContext = userContext;
            m_databaseContext = databaseContext;
            m_repositoryFactory = repositoryFactory;
        }


        public IPrimaryRepository<TEntity> GetPrimaryRepository<TEntity>()
            where TEntity: PrimaryBase
        {
            return m_repositoryFactory.GetPrimaryRepository<TEntity>(m_userContext, m_databaseContext);
        }
        
        public ISubscriberRepository<TEntity> GetSubscriberRepository<TEntity>() 
            where TEntity: SubscriberBase
        {
            return m_repositoryFactory.GetSubscriberRepository<TEntity>(m_userContext, m_databaseContext);
        }

        public void BeginTransaction()
        {
            // TODO: Implement starting a database transaction.
        }

        public void CommitTransaction()
        {
            // TODO: Implement committing a database transaction.
        }

        public void RollbackTransaction()
        {
            // TODO: Implement rolling a database transaction back.
        }
    }
}
