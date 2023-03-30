using ChainOfResponsibility.Implementation.Data;
using Core.Abstractions.Interfaces;

namespace ChainOfResponsibility.Implementation
{
    public class DemoContext : IContext<IUnitOfWork>
    {
        public DemoContext(IUnitOfWork unitOfWork, IUserContext userContext)
        {
            UserContext = userContext;
            UnitOfWork = unitOfWork;
            LoggingContext = new Dictionary<string, object>
            {
                {"accountId", userContext.AccountId},
                {"username", userContext.ActingUserName},
                {"actingUserId", userContext.ActingUserId},
            };

            if (userContext.ActingUserGuid != null)
            {
                LoggingContext["actingUserGuid"] = userContext.ActingUserGuid.Value;
            }
        }
        
        public IUserContext UserContext { get; }
        public IUnitOfWork UnitOfWork { get; }
        public Dictionary<string, object> LoggingContext { get; }
    }
}
